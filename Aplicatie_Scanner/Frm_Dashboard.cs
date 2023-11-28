using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using static QRCoder.PayloadGenerator;

namespace Azel_Raportare_Balkani
{
    public partial class Frm_Dashboard : Form
    {

        public Frm_Dashboard()
        {
            InitializeComponent();
        }

        List<DateDB> date = new List<DateDB>();
        List<DatePutere> date_putere = new List<DatePutere>();
        List<DatePutere> date_putere_ora = new List<DatePutere>();
        public bool fisier_deschis = false;
        public double energie_raport_lunar = 0;
        public double debit_raport_lunar = 0;
        private void Frm_Dashboard_Load(object sender, EventArgs e)
        {
            #region DataProperty
            dataGridView1.Columns[2].DataPropertyName = "Putere";
            dataGridView1.Columns[3].DataPropertyName = "Energie";
            dataGridView1.Columns[4].DataPropertyName = "Presiune_Aductiune";
            dataGridView1.Columns[5].DataPropertyName = "Presiune_GUP";
            dataGridView1.Columns[6].DataPropertyName = "Pozitie_Injector_1";
            dataGridView1.Columns[7].DataPropertyName = "Pozitie_Injector_2";
            dataGridView1.Columns[8].DataPropertyName = "Vibratii_Generator";
            dataGridView1.Columns[9].DataPropertyName = "Debit_Turbinat_Instantaneu";
            dataGridView1.Columns[10].DataPropertyName = "Debit_Turbinat_Total";
            dataGridView1.Columns[11].DataPropertyName = "Meteo_Temperatura";
            dataGridView1.Columns[12].DataPropertyName = "Meteo_Umiditate";
            dataGridView1.Columns[13].DataPropertyName = "Meteo_Precipitatii";
            #endregion
            rbDefault.Checked = true;
            cbEnergieOra.Visible = false;
            rbPutere.Checked = false;
            rbEnergie.Checked = false;
            fisier_deschis = false;
            newCalendar1.SelectionEnd = DateTime.Now.AddDays(1).AddTicks(-1);
            cbZonaSelectie.SelectedIndex = 0;
        }


        private void Frm_Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {


        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }


        private void Search_Click(object sender, EventArgs e)
        {

            Cautare_Date();
        }

        private void UpdateBinding()
        {


            try
            {
                dataGridView1.AutoGenerateColumns = false;
                if (rbDefault.Checked)
                    dataGridView1.DataSource = date;
                else
                {
                    if (cbEnergieOra.Checked)
                        dataGridView1.DataSource = date_putere_ora;
                    else
                    {
                        dataGridView1.DataSource = date_putere;
                    }
                }

                dataGridView1.Columns["Data"].DataPropertyName = "DoarData";
                dataGridView1.Columns["Timp"].DataPropertyName = "DoarTimp";

                tbEnergie_Produsa.Text = "0" + " [kWh]";
                tbApa_Consumata.Text = "0" + " [1000 x m³]";
                tbPutereMedie.Text = "0" + " kW";

                tbPutereMedie.Text = Math.Round(date.Average(p => p.Putere), 2).ToString() + " kW";
                tbEnergie_Produsa.Text = (Math.Round(date[date.FindLastIndex(item => item.Energie > 0)].Energie - date[date.FindIndex(item => item.Energie > 0)].Energie, 2)).ToString() + " [kWh]";
                tbApa_Consumata.Text = (Math.Round(date[date.FindLastIndex(item => item.Debit_Turbinat_Total > 0)].Debit_Turbinat_Total - date[date.FindIndex(item => item.Debit_Turbinat_Total > 0)].Debit_Turbinat_Total, 2)).ToString() + " [1000 x m³]";


            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Cautare_Date()
        {
            bool Prima_Conditie_Selectata = false;
            string Conditii_Get_Date = "";
            try
            {

                DataAccess db = new DataAccess();

                if (rbDefault.Checked)
                {
                    date = db.GetDateToataZiua(newCalendar1.SelectionStart, newCalendar1.SelectionEnd.AddMinutes(2), Conditii_Get_Date, cbZonaSelectie.SelectedItem.ToString().Replace(" ", "_"));
                }
                if (rbPutere.Checked)
                {

                    date_putere = db.GetDatePuteri(newCalendar1.SelectionStart, newCalendar1.SelectionEnd.AddMinutes(2));
                }
                if (rbEnergie.Checked)
                {
                    int index = 0;
                    date_putere = db.GetDateEnergie(newCalendar1.SelectionStart, newCalendar1.SelectionEnd.AddMinutes(2));
                    date_putere_ora.Clear();
                    if (cbEnergieOra.Checked)
                    {

                        /*       date_putere_ora = (List<DatePutere>)date_putere.GroupBy(d => d.Date_Time.Hour)
                  .Select(
                 g => new DatePutere
                 {
                     Date_Time = g.First().Date_Time,
                     Cuntu_Grup_1 = g.Sum(s => s.Cuntu_Grup_1),
                     Cuntu_Grup_2 = g.Sum(s => s.Cuntu_Grup_2),
                     Craiu_1_Grup_1 = g.Sum(s => s.Craiu_1_Grup_1),
                     Craiu_2_Grup_1 = g.Sum(s => s.Craiu_2_Grup_1),
                     Sebesel_1_Grup_1 = g.Sum(s => s.Sebesel_1_Grup_1),
                     Sebesel_1_Grup_2 = g.Sum(s => s.Sebesel_1_Grup_2),
                     Sebesel_2_Grup_1 = g.Sum(s => s.Sebesel_2_Grup_1),
                     Sebesel_2_Grup_2 = g.Sum(s => s.Sebesel_2_Grup_2)



                 });;*/
                        for (int i = date_putere.FindIndex(x => x.Date_Time.Minute == 00); i < date_putere.Count - 4; i = i + 4)
                        {


                            date_putere_ora.Add(date_putere[i]);

                            #region Calcul Energie Per Ora
                            date_putere_ora[index].Cuntu_Grup_1 = date_putere[i].Cuntu_Grup_1 + date_putere[i + 1].Cuntu_Grup_1 + date_putere[i + 2].Cuntu_Grup_1 + date_putere[i + 3].Cuntu_Grup_1;
                            date_putere_ora[index].Cuntu_Grup_2 = date_putere[i].Cuntu_Grup_2 + date_putere[i + 1].Cuntu_Grup_2 + date_putere[i + 2].Cuntu_Grup_2 + date_putere[i + 3].Cuntu_Grup_2;
                            date_putere_ora[index].Craiu_1_Grup_1 = date_putere[i].Craiu_1_Grup_1 + date_putere[i + 1].Craiu_1_Grup_1 + date_putere[i + 2].Craiu_1_Grup_1 + date_putere[i + 3].Craiu_1_Grup_1;
                            date_putere_ora[index].Craiu_1_Grup_2 = date_putere[i].Craiu_1_Grup_2 + date_putere[i + 1].Craiu_1_Grup_2 + date_putere[i + 2].Craiu_1_Grup_2 + date_putere[i + 3].Craiu_1_Grup_2;
                            date_putere_ora[index].Craiu_2_Grup_1 = date_putere[i].Craiu_2_Grup_1 + date_putere[i + 1].Craiu_2_Grup_1 + date_putere[i + 2].Craiu_2_Grup_1 + date_putere[i + 3].Craiu_2_Grup_1;
                            date_putere_ora[index].Craiu_2_Grup_2 = date_putere[i].Craiu_2_Grup_2 + date_putere[i + 1].Craiu_2_Grup_2 + date_putere[i + 2].Craiu_2_Grup_2 + date_putere[i + 3].Craiu_2_Grup_2;
                            date_putere_ora[index].Sebesel_1_Grup_1 = date_putere[i].Sebesel_1_Grup_1 + date_putere[i + 1].Sebesel_1_Grup_1 + date_putere[i + 2].Sebesel_1_Grup_1 + date_putere[i + 3].Sebesel_1_Grup_1;
                            date_putere_ora[index].Sebesel_1_Grup_2 = date_putere[i].Sebesel_1_Grup_2 + date_putere[i + 1].Sebesel_1_Grup_2 + date_putere[i + 2].Sebesel_1_Grup_2 + date_putere[i + 3].Sebesel_1_Grup_2;
                            date_putere_ora[index].Sebesel_2_Grup_1 = date_putere[i].Sebesel_2_Grup_1 + date_putere[i + 1].Sebesel_2_Grup_1 + date_putere[i + 2].Sebesel_2_Grup_1 + date_putere[i + 3].Sebesel_2_Grup_1;
                            date_putere_ora[index].Sebesel_2_Grup_2 = date_putere[i].Sebesel_2_Grup_2 + date_putere[i + 1].Sebesel_2_Grup_2 + date_putere[i + 2].Sebesel_2_Grup_2 + date_putere[i + 3].Sebesel_2_Grup_2;
                            date_putere_ora[index].Cornereva = date_putere[i].Cornereva + date_putere[i + 1].Cornereva + date_putere[i + 2].Cornereva + date_putere[i + 3].Cornereva;
                            #endregion
                            index++;

                        }
                    }

                }

                UpdateBinding();
                if (date.Count < 1) { }
                else btnPrintCSV.Visible = true;

            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.ToString());
            }
        }
        private void cbZonaSelectie_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cautare_Date();
        }

        private void btnPrintCSV_Click(object sender, EventArgs e)
        {
            if (rbDefault.Checked)
                Print_Date();
            else
            {
                Print_Puteri();
            }
            if (fisier_deschis == false)
            {
                OpenFolder(@$"C:\Azel\Raportari\");
                fisier_deschis = true;
            }
            else { fisier_deschis = false; }
        }

        private void Print_Date()
        {
            string subPath = @$"C:\Azel\Raportari\";

            bool exists = System.IO.Directory.Exists(subPath);

            if (!exists)
                System.IO.Directory.CreateDirectory(subPath);
            using (StreamWriter file = File.CreateText(@$"C:\Azel\Raportari\Raport_Aplicatie_{cbZonaSelectie.Text.Replace(" ", "_")}_{DateTime.Now.ToString("yyyy-MM-dd_HH-mm")}.csv"))
            {
                file.WriteLine("Data,Timp,Putere,Energie,Presiune_Aductiune,Presiune_GUP,Pozitie_Injector_1,Pozitie_Injector_2,Vibratii_Generator,Debit_Turbinat_Instantaneu,Debit_Turbinat_Total,Meteo_Temperatura,Meteo_Umiditate,Meteo_Precipitatii");
                foreach (var arr in date)
                {
                    file.WriteLine(string.Join(",", arr.FullString));
                }
            }
        }

        private void OpenFolder(string path)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    ProcessStartInfo startinfo = new ProcessStartInfo
                    {
                        Arguments = path,
                        FileName = "explorer.exe"
                    };
                    Process.Start(startinfo);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }

        }

        private void Print_Puteri()
        {
            string subPath = @$"C:\Azel\Raportari\";

            bool exists = System.IO.Directory.Exists(subPath);

            if (!exists)
                System.IO.Directory.CreateDirectory(subPath);
            using (StreamWriter file = File.CreateText(@$"C:\Azel\Raportari\Raport_Aplicatie_{DateTime.Now.ToString("yyyy-MM-dd_HH-mm")}.csv"))
            {
                file.WriteLine("Data,Timp,Cuntu Grup 1,Cuntu Grup 2,Craiu 1 Grup 1,Craiu 1 Grup 2,Craiu 2 Grup 1,Craiu 2 Grup 2,Sebesel 1 Grup 1,Sebesel 1 Grup 2,Sebesel 2 Grup 1,Sebesel 2 Grup 2,Cornereva,Total");
                foreach (var arr in date)
                {
                    file.WriteLine(string.Join(",", arr.FullString));
                }
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void newCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            //Cautare_Date();
        }

        private void rbDefault_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDefault.Checked == true)
            {


                Afisare_Productie(true);


                dataGridView1.Columns[2].HeaderText = "Putere [kW]";
                dataGridView1.Columns[3].HeaderText = "Energie [kWh]";
                dataGridView1.Columns[4].HeaderText = "Presiune Aductiune [bar]";
                dataGridView1.Columns[5].HeaderText = "Presiune GUP [bar]";
                dataGridView1.Columns[6].HeaderText = "Pozitie Injector 1 [%]";
                dataGridView1.Columns[7].HeaderText = "Pozitie Injector 2 [%]";
                dataGridView1.Columns[8].HeaderText = "Vibratii Generator [Hz]";
                dataGridView1.Columns[9].HeaderText = "Debit Instantaneu [l]";
                dataGridView1.Columns[10].HeaderText = "Debit Turbinat Total [1000 x m³]";
                dataGridView1.Columns[11].HeaderText = "Temperatura Meteo [°C]";
                dataGridView1.Columns[12].HeaderText = "Umiditate Meteo [%]";
                dataGridView1.Columns[13].HeaderText = "Precipitatii Meteo [mm]";

                dataGridView1.Columns[2].DataPropertyName = "Putere";
                dataGridView1.Columns[3].DataPropertyName = "Energie";
                dataGridView1.Columns[4].DataPropertyName = "Presiune_Aductiune";
                dataGridView1.Columns[5].DataPropertyName = "Presiune_GUP";
                dataGridView1.Columns[6].DataPropertyName = "Pozitie_Injector_1";
                dataGridView1.Columns[7].DataPropertyName = "Pozitie_Injector_2";
                dataGridView1.Columns[8].DataPropertyName = "Vibratii_Generator";
                dataGridView1.Columns[9].DataPropertyName = "Debit_Turbinat_Instantaneu";
                dataGridView1.Columns[10].DataPropertyName = "Debit_Turbinat_Total";
                dataGridView1.Columns[11].DataPropertyName = "Meteo_Temperatura";
                dataGridView1.Columns[12].DataPropertyName = "Meteo_Umiditate";
                dataGridView1.Columns[13].DataPropertyName = "Meteo_Precipitatii";
                Cautare_Date();
            }

        }

        private void rbEnergie_CheckedChanged(object sender, EventArgs e)
        {

            if (rbEnergie.Checked == true)
            {
                cbEnergieOra.Visible = true;
                Afisare_Productie(false);
                cbZonaSelectie.Visible = false;
                dataGridView1.Columns[2].HeaderText = "Cuntu Grup 1";
                dataGridView1.Columns[3].HeaderText = "Cuntu Grup 2";
                dataGridView1.Columns[4].HeaderText = "Craiu 1 Grup 1";
                dataGridView1.Columns[5].HeaderText = "Craiu 1 Grup 2";
                dataGridView1.Columns[6].HeaderText = "Craiu 2 Grup 1";
                dataGridView1.Columns[7].HeaderText = "Craiu 2 Grup 2";
                dataGridView1.Columns[8].HeaderText = "Sebesel 1 Grup 1";
                dataGridView1.Columns[9].HeaderText = "Sebesel 1 Grup 2";
                dataGridView1.Columns[10].HeaderText = "Sebesel 2 Grup 1";
                dataGridView1.Columns[11].HeaderText = "Sebesel 2 Grup 2";
                dataGridView1.Columns[12].HeaderText = "Cornereva";
                dataGridView1.Columns[13].HeaderText = "Total [kWh]";

                dataGridView1.Columns[2].DataPropertyName = "Cuntu_Grup_1";
                dataGridView1.Columns[3].DataPropertyName = "Cuntu_Grup_2";
                dataGridView1.Columns[4].DataPropertyName = "Craiu_1_Grup_1";
                dataGridView1.Columns[5].DataPropertyName = "Craiu_1_Grup_2";
                dataGridView1.Columns[6].DataPropertyName = "Craiu_2_Grup_1";
                dataGridView1.Columns[7].DataPropertyName = "Craiu_2_Grup_2";
                dataGridView1.Columns[8].DataPropertyName = "Sebesel_1_Grup_1";
                dataGridView1.Columns[9].DataPropertyName = "Sebesel_1_Grup_2";
                dataGridView1.Columns[10].DataPropertyName = "Sebesel_2_Grup_1";
                dataGridView1.Columns[11].DataPropertyName = "Sebesel_2_Grup_2";
                dataGridView1.Columns[12].DataPropertyName = "Cornereva";
                dataGridView1.Columns[13].DataPropertyName = "Total [kWh]";
                Cautare_Date();
            }
            else
            {
                cbEnergieOra.Visible = false;
            }
        }

        private void rbPutere_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPutere.Checked == true)
            {
                Afisare_Productie(false);
                cbZonaSelectie.Visible = false;
                dataGridView1.Columns[2].HeaderText = "Cuntu Grup 1";
                dataGridView1.Columns[3].HeaderText = "Cuntu Grup 2";
                dataGridView1.Columns[4].HeaderText = "Craiu 1 Grup 1";
                dataGridView1.Columns[5].HeaderText = "Craiu 1 Grup 2";
                dataGridView1.Columns[6].HeaderText = "Craiu 2 Grup 1";
                dataGridView1.Columns[7].HeaderText = "Craiu 2 Grup 2";
                dataGridView1.Columns[8].HeaderText = "Sebesel 1 Grup 1";
                dataGridView1.Columns[9].HeaderText = "Sebesel 1 Grup 2";
                dataGridView1.Columns[10].HeaderText = "Sebesel 2 Grup 1";
                dataGridView1.Columns[11].HeaderText = "Sebesel 2 Grup 2";
                dataGridView1.Columns[12].HeaderText = "Cornereva";
                dataGridView1.Columns[13].HeaderText = "Total [kW]";

                dataGridView1.Columns[2].DataPropertyName = "Cuntu_Grup_1";
                dataGridView1.Columns[3].DataPropertyName = "Cuntu_Grup_2";
                dataGridView1.Columns[4].DataPropertyName = "Craiu_1_Grup_1";
                dataGridView1.Columns[5].DataPropertyName = "Craiu_1_Grup_2";
                dataGridView1.Columns[6].DataPropertyName = "Craiu_2_Grup_1";
                dataGridView1.Columns[7].DataPropertyName = "Craiu_2_Grup_2";
                dataGridView1.Columns[8].DataPropertyName = "Sebesel_1_Grup_1";
                dataGridView1.Columns[9].DataPropertyName = "Sebesel_1_Grup_2";
                dataGridView1.Columns[10].DataPropertyName = "Sebesel_2_Grup_1";
                dataGridView1.Columns[11].DataPropertyName = "Sebesel_2_Grup_2";
                dataGridView1.Columns[12].DataPropertyName = "Cornereva";
                dataGridView1.Columns[13].DataPropertyName = "Total [kW]";
                Cautare_Date();
            }
        }
        private void Afisare_Productie(bool afisare)
        {
            cbZonaSelectie.Visible = afisare;
            lblPutere_Medie.Visible = afisare;
            tbPutereMedie.Visible = afisare;
            lblEnergie_Produsa.Visible = afisare;
            tbEnergie_Produsa.Visible = afisare;
            lblApa_Consumata.Visible = afisare;
            tbApa_Consumata.Visible = afisare;
        }

        private void cbEnergieOra_CheckedChanged(object sender, EventArgs e)
        {
            Cautare_Date();
        }
        private void Printare_Raport_Lunar()
        {
            string subPath = @$"C:\Azel\Raportari\Rapoarte_Lunare";

            bool exists = System.IO.Directory.Exists(subPath);

            if (!exists)
                System.IO.Directory.CreateDirectory(subPath);



            using (StreamWriter file = File.CreateText(@$"C:\Azel\Raportari\Rapoarte_Lunare\Raport_Lunar_{dateTimePicker1.Value.ToString("yyyy_MMMM")}.csv"))
            {
                energie_raport_lunar = 0;
                debit_raport_lunar = 0;

                file.WriteLine("");
                file.WriteLine("MHC,Index Vechi Energie,Index Nou Energie,Energie Produsa,Index Vechi Debit,Index Nou Debit, Volum Apa Turbinat");

                file.WriteLine(GetDateLuna("Cuntu_Grup_1"));
                file.WriteLine(GetDateLuna("Cuntu_Grup_2"));
                file.WriteLine(GetDateLuna("Craiu_1_Grup_1"));
                file.WriteLine(GetDateLuna("Craiu_1_Grup_2"));
                file.WriteLine(GetDateLuna("Craiu_2_Grup_1"));
                file.WriteLine(GetDateLuna("Craiu_2_Grup_2"));
                file.WriteLine(GetDateLuna("Sebesel_1_Grup_1"));
                file.WriteLine(GetDateLuna("Sebesel_1_Grup_2"));
                file.WriteLine(GetDateLuna("Sebesel_2_Grup_1"));
                file.WriteLine(GetDateLuna("Sebesel_2_Grup_2"));
                file.WriteLine(GetDateLuna("Cornereva"));
                file.WriteLine("");

                file.WriteLine($",,,{Math.Round(energie_raport_lunar, 2)},,,{Math.Round(debit_raport_lunar, 2)}");
                file.WriteLine($",,,Energie Totala,,,Volum Total Turbinat");

            }

            if (fisier_deschis == false)
            {
                OpenFolder(@$"C:\Azel\Raportari\Rapoarte_Lunare");
                fisier_deschis = true;
            }
            else { fisier_deschis = false; }
        }
        public void Printare_Si_Trimitere_Raport_Lunar()
        {
            Printare_Raport_Lunar();

            ///////////////////////////////
            ///////TRIMITERE MAIL//////////
            ///////////////////////////////
            try
            {
                var smtpClient = new SmtpClient("mail.azel.ro")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("calin.rizoiu@azel.ro", "SHpQv5sMpx7k"),
                    EnableSsl = false,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("calin.rizoiu@azel.ro"),
                    Subject = @$"Raport_Lunar_{dateTimePicker1.Value.ToString("yyyy_MMMM")}",
                    Body = "Email Auto-Generat " +
                    "\n \n Azel Design Group SRL ",




                    // IsBodyHtml = true,
                };

                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(@$"C:\Azel\Raportari\Rapoarte_Lunare\Raport_Lunar_{dateTimePicker1.Value.ToString("yyyy_MMMM")}.csv");
                mailMessage.Attachments.Add(attachment);
                mailMessage.To.Add("crizoiu@yahoo.com");
                mailMessage.To.Add("stanfandrei@yahoo.com");
                mailMessage.To.Add("office@azel.ro");

                smtpClient.Send(mailMessage);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Btn_Print_Raport_Lunar_Click(object sender, EventArgs e)
        {
            Printare_Raport_Lunar();
        }
        private string GetDateLuna(string MHC)
        {
            double energie_totala = 0;
            double debit_total = 0;
            double index_initial_energie = 0;
            double index_final_energie = 0;
            double index_initial_debit = 0;
            double index_final_debit = 0;
            string rezultat = "";
            DataAccess db = new DataAccess();

            var inceputul_lunii = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, 1);
            var sfarsitul_lunii = inceputul_lunii.AddMonths(1).AddTicks(-1);
            var date_luna = db.GetDateToataZiua(inceputul_lunii, sfarsitul_lunii.AddDays(1).AddTicks(-1), "", MHC);
            if (date_luna.Any())
            {
                index_initial_energie = date_luna.Select(x => x.Energie).SkipWhile(x => x == 0).FirstOrDefault(0);
                index_final_energie = date_luna.Select(x => x.Energie).Reverse().SkipWhile(x => x == 0).FirstOrDefault(0);
                energie_totala = Math.Round((index_final_energie - index_initial_energie), 2);

                index_initial_debit = date_luna.Select(x => x.Debit_Turbinat_Total).SkipWhile(x => x == 0).FirstOrDefault(0);
                index_final_debit = date_luna.Select(x => x.Debit_Turbinat_Total).Reverse().SkipWhile(x => x == 0).FirstOrDefault(0);
                debit_total = Math.Round((index_final_debit - index_initial_debit), 2);
            }
            energie_raport_lunar = energie_raport_lunar + energie_totala;
            debit_raport_lunar = debit_raport_lunar + debit_total;

            rezultat = $"{MHC.Replace("_", " ")},{index_initial_energie},{index_final_energie},{energie_totala},{index_initial_debit},{index_final_debit},{debit_total}";
            return rezultat;

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
