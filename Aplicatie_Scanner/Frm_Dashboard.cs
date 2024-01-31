using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using System.Diagnostics;
using System.Globalization;
using System.Net;
using System.Net.Mail;
using static Azel_Raportare_Balkani.Aplicatie_Raportare_Balkani;
using static QRCoder.PayloadGenerator;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Colors;

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
            for (int i = 0; i < Debit_Calculat.Index.Length; i++)
            {
                checkedListBox_Debit_Calculat.SetItemChecked(i, Debit_Calculat.Index[i]);
            }
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
        private Date_Luna GetDateLuna(DateTime Luna_Selectata, string MHC)
        {
            Date_Luna Date = new Date_Luna();

            Date.Energie_Total = 0;
            Date.Debit_Total = 0;
            Date.Energie_Index_Initial = 0;
            Date.Energie_Index_Final = 0;
            Date.Debit_Index_Initial = 0;
            Date.Debit_Index_Final = 0;
            Date.String_Csv = "";
            DataAccess db = new DataAccess();

            var inceputul_lunii = new DateTime(Luna_Selectata.AddMonths(-1).Year, (Luna_Selectata.AddMonths(-1).Month), 1);
            var sfarsitul_lunii = inceputul_lunii.AddMonths(2).AddMinutes(-1);
            var date_luna = db.GetDateToataZiua(inceputul_lunii, sfarsitul_lunii, "", MHC);
            if (date_luna.Any())
            {
                Date.Energie_Index_Initial = date_luna.Where(x => x.Date_Time < inceputul_lunii.AddMonths(1).AddMinutes(-1) ).Select(x => x.Energie).Reverse().SkipWhile(x => x == 0).FirstOrDefault(0);
                Date.Energie_Index_Final = date_luna.Select(x => x.Energie).Reverse().SkipWhile(x => x == 0).FirstOrDefault(0);
                Date.Energie_Total = Math.Round((Date.Energie_Index_Final - Date.Energie_Index_Initial), 2);

                Date.Debit_Index_Initial = date_luna.Where(x => x.Date_Time < inceputul_lunii.AddMonths(1).AddMinutes(-1)).Select(x => x.Debit_Turbinat_Total).Reverse().SkipWhile(x => x == 0).FirstOrDefault(0);
                Date.Debit_Index_Final = date_luna.Select(x => x.Debit_Turbinat_Total).Reverse().SkipWhile(x => x == 0).FirstOrDefault(0);
                Date.Debit_Total = Math.Round((Date.Debit_Index_Final - Date.Debit_Index_Initial), 2);
            }
            energie_raport_lunar = energie_raport_lunar + Date.Energie_Total;


            Date.String_Csv = $"{MHC.Replace("_", " ")},{Date.Energie_Index_Initial},{Date.Energie_Index_Final},{Date.Energie_Total},{Date.Debit_Index_Initial},{Date.Debit_Index_Final},{Date.Debit_Total}";
            return Date;

        }
        private void Verificare_Calcul_Debit(int index, Date_Luna Grup, double Coeficient)
        {
            var Total_Calculat = Grup.Energie_Total * Coeficient / 1000;
            if ((Total_Calculat > Grup.Debit_Total * 1.25 || Total_Calculat < Grup.Debit_Total * 0.75) && (Grup.Debit_Total > 1 || Grup.Energie_Total > 100))
            {
                Debit_Calculat.Index[index] = true;
            }
        }

        private void Printare_Raport_Lunar()
        {
            string subPath = @$"C:\Azel\Raportari\Rapoarte_Lunare";

            energie_raport_lunar = 0;
            debit_raport_lunar = 0;



            Date_Luna Cuntu_Grup_1 = GetDateLuna(dateTimePicker1.Value.Date, "Cuntu_Grup_1");
            Date_Luna Cuntu_Grup_2 = GetDateLuna(dateTimePicker1.Value.Date, "Cuntu_Grup_2");
            Date_Luna Craiu_1_Grup_1 = GetDateLuna(dateTimePicker1.Value.Date, "Craiu_1_Grup_1");
            Date_Luna Craiu_1_Grup_2 = GetDateLuna(dateTimePicker1.Value.Date, "Craiu_1_Grup_2");
            Date_Luna Craiu_2_Grup_1 = GetDateLuna(dateTimePicker1.Value.Date, "Craiu_2_Grup_1");
            Date_Luna Craiu_2_Grup_2 = GetDateLuna(dateTimePicker1.Value.Date, "Craiu_2_Grup_2");
            Date_Luna Sebesel_1_Grup_1 = GetDateLuna(dateTimePicker1.Value.Date, "Sebesel_1_Grup_1");
            Date_Luna Sebesel_1_Grup_2 = GetDateLuna(dateTimePicker1.Value.Date, "Sebesel_1_Grup_2");
            Date_Luna Sebesel_2_Grup_1 = GetDateLuna(dateTimePicker1.Value.Date, "Sebesel_2_Grup_1");
            Date_Luna Sebesel_2_Grup_2 = GetDateLuna(dateTimePicker1.Value.Date, "Sebesel_2_Grup_2");
            Date_Luna Cornereva = GetDateLuna(dateTimePicker1.Value.Date, "Cornereva");

            Verificare_Calcul_Debit(0, Cuntu_Grup_1, 2.895);
            Verificare_Calcul_Debit(1, Cuntu_Grup_2, 2.895);
            Verificare_Calcul_Debit(2, Craiu_1_Grup_1, 5.815);
            Verificare_Calcul_Debit(3, Craiu_1_Grup_2, 5.815);
            Verificare_Calcul_Debit(4, Craiu_2_Grup_1, 2.701);
            Verificare_Calcul_Debit(5, Craiu_2_Grup_2, 2.701);
            Verificare_Calcul_Debit(6, Sebesel_1_Grup_1, 3.698);
            Verificare_Calcul_Debit(7, Sebesel_1_Grup_2, 3.698);
            Verificare_Calcul_Debit(8, Sebesel_2_Grup_1, 3.635);
            Verificare_Calcul_Debit(9, Sebesel_2_Grup_2, 3.635);
            Verificare_Calcul_Debit(10, Cornereva, 7.996);


            bool exists = System.IO.Directory.Exists(subPath);

            if (!exists)
                System.IO.Directory.CreateDirectory(subPath);


          
            PdfWriter writer = new PdfWriter(@$"C:\Azel\Raportari\Rapoarte_Lunare\Raport_{dateTimePicker1.Value.ToString("yyyy_MMMM", CultureInfo.CreateSpecificCulture("ro"))}.pdf");
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);



            document.Add(new Paragraph(new Text("Nr.____/______")));
            //document.Add(new Paragraph(new Text("\n")));
            Paragraph header1 = new Paragraph($"Catre" +
                $"\n")
               .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
            document.Add(new Paragraph(new Text("\n")));
            Paragraph header2 = new Paragraph($"ADMINISTRATIA DE APA BANAT" +
                $"\n" +
                $"SISTEMUL DE GOSPODARIE A APELOR CARAS")
               .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
               .SetBold();

            DateTime ultima_zi = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, 1).AddMonths(1).AddMinutes(-1);

            Paragraph subheader = new Paragraph($" \t Prin prezenta va comunicam indexurile de la contoarele de apa " +
                $"MHC Muntele Mic luna {dateTimePicker1.Value.Date.ToString("MMMM", CultureInfo.CreateSpecificCulture("ro"))}" +
                $" la data de {ultima_zi.ToString("dd.MM.yyyy")}");

            document.Add(header1);
            document.Add(header2);
            document.Add(subheader);
            document.Add(new Paragraph(new Text("\n")));

            // Table
            Table table = new Table(6, false).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);

            iText.Layout.Element.Cell cell11 = new iText.Layout.Element.Cell(3, 1)
               //.SetBackgroundColor(ColorConstants.GRAY)
               .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
               .SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE)
               .Add(new Paragraph(" "));
            iText.Layout.Element.Cell cell12 = new iText.Layout.Element.Cell(3, 1)
               //.SetBackgroundColor(ColorConstants.GRAY)
               .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
               .SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE)
               .Add(new Paragraph("MHC"));

            iText.Layout.Element.Cell cell13 = new iText.Layout.Element.Cell(3, 1)
                //.SetBackgroundColor(ColorConstants.GRAY)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE)
                .Add(new Paragraph($"Energie produsa \n la {ultima_zi.AddMinutes(-1).ToString("dd.MM.yyyy")} [kWh]"));
            iText.Layout.Element.Cell cell14 = new iText.Layout.Element.Cell(1, 2)
                //.SetBackgroundColor(ColorConstants.GRAY)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE)
                .Add(new Paragraph($"Inregistrari dispozitive \n de masura la {ultima_zi.AddMinutes(-1).ToString("dd.MM.yyyy")}"));
            iText.Layout.Element.Cell cell15 = new iText.Layout.Element.Cell(1, 1)
                //.SetBackgroundColor(ColorConstants.GRAY)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE)
                .Add(new Paragraph("Volum apa uzinat"));
            iText.Layout.Element.Cell cell16 = new iText.Layout.Element.Cell(1, 1)
               //.SetBackgroundColor(ColorConstants.GRAY)
               .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
               .SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE)
               .Add(new Paragraph("Index Vechi"));
            iText.Layout.Element.Cell cell17 = new iText.Layout.Element.Cell(1, 1)
                //.SetBackgroundColor(ColorConstants.GRAY)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE)
                .Add(new Paragraph($"Index nou"));
            iText.Layout.Element.Cell cell18 = new iText.Layout.Element.Cell(1, 1)
                //.SetBackgroundColor(ColorConstants.GRAY)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE)
                .Add(new Paragraph($"(mii mc)"));
            iText.Layout.Element.Cell cell19 = new iText.Layout.Element.Cell(1, 1)
                //.SetBackgroundColor(ColorConstants.GRAY)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE)
                .Add(new Paragraph($"(mii mc)"));
            iText.Layout.Element.Cell cell20 = new iText.Layout.Element.Cell(1, 1)
                //.SetBackgroundColor(ColorConstants.GRAY)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE)
                .Add(new Paragraph($"(mii mc)"));
            iText.Layout.Element.Cell cell21 = new iText.Layout.Element.Cell(1, 1)
                //.SetBackgroundColor(ColorConstants.GRAY)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE)
                .Add(new Paragraph($" "));


            table.AddCell(cell11);
            table.AddCell(cell12);
            table.AddCell(cell13);
            table.AddCell(cell14);
            table.AddCell(cell15);
            table.AddCell(cell16);
            table.AddCell(cell17);
            table.AddCell(cell18);
            table.AddCell(cell19);
            table.AddCell(cell20);
            table.AddCell(cell21);

            Introducere_MHC_PDF(ref table, Cuntu_Grup_1, Cuntu_Grup_2, "Cuntu", 0, 2.895);
            Introducere_MHC_PDF(ref table, Craiu_1_Grup_1, Craiu_1_Grup_2, "Craiu 1", 2, 5.815);
            Introducere_MHC_PDF(ref table, Craiu_2_Grup_1, Craiu_2_Grup_2, "Craiu 2", 4, 2.701);
            Introducere_MHC_PDF(ref table, Sebesel_1_Grup_1, Sebesel_1_Grup_2, "Sebesel 1", 6, 3.698);
            Introducere_MHC_PDF(ref table, Sebesel_2_Grup_1, Sebesel_2_Grup_2, "Sebesel 2", 8, 3.635);
            Introducere_MHC_Single_PDF(ref table, Cornereva, ColorConstants.WHITE, "Cornereva", 10, 7.996);

            iText.Layout.Element.Cell cell22 = new iText.Layout.Element.Cell(1, 1)
                .SetBackgroundColor(ColorConstants.WHITE)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE)
                .SetFontSize(10)
                .Add(new Paragraph($"Total MHC-uri"));
            iText.Layout.Element.Cell cell23 = new iText.Layout.Element.Cell(1, 1)
                .SetBackgroundColor(ColorConstants.WHITE)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE)
                .Add(new Paragraph(""));
            iText.Layout.Element.Cell cell24 = new iText.Layout.Element.Cell(1, 4)
                .SetBackgroundColor(ColorConstants.WHITE)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE)
                .Add(new Paragraph(Math.Round((debit_raport_lunar), 2).ToString()));



            iText.Layout.Element.Cell cell25 = new iText.Layout.Element.Cell(1, 1)
                .SetBackgroundColor(ColorConstants.WHITE)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE)
                .SetFontSize(10)
                .Add(new Paragraph($"Total ENERGIE la {ultima_zi.AddMinutes(-1).ToString("dd.MM.yyyy")}"));
            iText.Layout.Element.Cell cell26 = new iText.Layout.Element.Cell(1, 1)
                .SetBackgroundColor(ColorConstants.WHITE)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE)
                .Add(new Paragraph(""));
            iText.Layout.Element.Cell cell27 = new iText.Layout.Element.Cell(1, 1)
                .SetBackgroundColor(ColorConstants.WHITE)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE)
                .Add(new Paragraph(Math.Round((energie_raport_lunar), 2).ToString()));
            iText.Layout.Element.Cell cell28 = new iText.Layout.Element.Cell(1, 3)
                .SetBackgroundColor(ColorConstants.WHITE)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE)
                .Add(new Paragraph(""));

            table.AddCell(cell22);
            table.AddCell(cell23);
            table.AddCell(cell24);
            table.AddCell(cell25);
            table.AddCell(cell26);
            table.AddCell(cell27);
            table.AddCell(cell28);



            document.Add(table);
            document.Close();


            using (StreamWriter file = File.CreateText(@$"C:\Azel\Raportari\Rapoarte_Lunare\Raport_Lunar_{dateTimePicker1.Value.ToString("yyyy_MMMM", CultureInfo.CreateSpecificCulture("ro"))}.csv"))
            {






                file.WriteLine("");
                file.WriteLine("MHC,Index Vechi Energie,Index Nou Energie,Energie Produsa [kWh],Index Vechi Debit,Index Nou Debit, Volum Apa Turbinat [1000 x m3]");

                file.WriteLine(Cuntu_Grup_1.String_Csv);
                file.WriteLine(Cuntu_Grup_2.String_Csv);
                file.WriteLine(Craiu_1_Grup_1.String_Csv);
                file.WriteLine(Craiu_1_Grup_2.String_Csv);
                file.WriteLine(Craiu_2_Grup_1.String_Csv);
                file.WriteLine(Craiu_2_Grup_2.String_Csv);
                file.WriteLine(Sebesel_1_Grup_1.String_Csv);
                file.WriteLine(Sebesel_1_Grup_2.String_Csv);
                file.WriteLine(Sebesel_2_Grup_1.String_Csv);
                file.WriteLine(Sebesel_2_Grup_2.String_Csv);
                file.WriteLine(Cornereva.String_Csv);
                file.WriteLine("");

                file.WriteLine($",,,{Math.Round(energie_raport_lunar, 2)},,,{Math.Round(debit_raport_lunar, 2)}");
                file.WriteLine($",,,Energie Totala [kWh],,,Volum Total Turbinat [1000 x m3]");

            }

        }

        private void Introducere_MHC_PDF(ref Table table, Date_Luna Grup_1, Date_Luna Grup_2, string MHC, int Index_Debit, double Coeficient_Debit)
        {
            #region Cells
            iText.Layout.Element.Cell cell_1 = new iText.Layout.Element.Cell(1, 1)
                .SetBackgroundColor(ColorConstants.YELLOW)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE)
                .SetFontSize(10)
                .Add(new Paragraph($"Turbina 1 - Pr. {MHC}"));
            iText.Layout.Element.Cell cell_2 = new iText.Layout.Element.Cell(2, 1)
                .SetBackgroundColor(ColorConstants.YELLOW)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE)
                .Add(new Paragraph(MHC));
            iText.Layout.Element.Cell cell_3 = new iText.Layout.Element.Cell(1, 1)
                .SetBackgroundColor(ColorConstants.YELLOW)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE)
                .Add(new Paragraph((Grup_1.Energie_Total).ToString()));
            iText.Layout.Element.Cell cell_4 = new iText.Layout.Element.Cell(1, 1)
                .SetBackgroundColor(ColorConstants.YELLOW)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE)
                .Add(new Paragraph(Grup_1.Debit_Index_Initial.ToString()));
            iText.Layout.Element.Cell cell_5 = new iText.Layout.Element.Cell(1, 1)
                .SetBackgroundColor(ColorConstants.YELLOW)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE)
                .Add(new Paragraph(Grup_1.Debit_Index_Final.ToString()));

            iText.Layout.Element.Cell cell_6 = new iText.Layout.Element.Cell(1, 1)
                .SetBackgroundColor(ColorConstants.YELLOW)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE);


            iText.Layout.Element.Cell cell_7 = new iText.Layout.Element.Cell(1, 1)
                .SetBackgroundColor(ColorConstants.YELLOW)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE)
                .SetFontSize(10)
                .Add(new Paragraph($"Turbina 2 - Pr. {MHC}"));

            iText.Layout.Element.Cell cell_8 = new iText.Layout.Element.Cell(1, 1)
                .SetBackgroundColor(ColorConstants.YELLOW)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE)
                .Add(new Paragraph((Grup_2.Energie_Total).ToString()));
            iText.Layout.Element.Cell cell_9 = new iText.Layout.Element.Cell(1, 1)
                .SetBackgroundColor(ColorConstants.YELLOW)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE)
                .Add(new Paragraph(Grup_2.Debit_Index_Initial.ToString()));
            iText.Layout.Element.Cell cell_10 = new iText.Layout.Element.Cell(1, 1)
                .SetBackgroundColor(ColorConstants.YELLOW)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE)
                .Add(new Paragraph(Grup_2.Debit_Index_Final.ToString()));

            iText.Layout.Element.Cell cell_11 = new iText.Layout.Element.Cell(1, 1)
                .SetBackgroundColor(ColorConstants.YELLOW)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE);

            iText.Layout.Element.Cell cell_12 = new iText.Layout.Element.Cell(1, 1)
                .SetBackgroundColor(ColorConstants.GREEN)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE)
                .SetFontSize(10)
                .Add(new Paragraph($"Total MHC {MHC}"));
            iText.Layout.Element.Cell cell_13 = new iText.Layout.Element.Cell(1, 1)
                .SetBackgroundColor(ColorConstants.GREEN)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE)
                .Add(new Paragraph(""));
            iText.Layout.Element.Cell cell_14 = new iText.Layout.Element.Cell(1, 4)
                .SetBackgroundColor(ColorConstants.GREEN)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE);



            if (Debit_Calculat.Index[Index_Debit])
            {
                cell_4.SetBackgroundColor(ColorConstants.RED).Add(new Paragraph(" (defect)"));
                cell_5.SetBackgroundColor(ColorConstants.RED).Add(new Paragraph(" (defect)"));
                cell_6.SetBackgroundColor(ColorConstants.RED).Add(new Paragraph(Math.Round((Grup_1.Energie_Total * Coeficient_Debit / 1000), 2).ToString())).Add(new Paragraph(" (calculat)"));
            }
            else
            {
                cell_6.Add(new Paragraph(Math.Round((Grup_1.Debit_Total), 2).ToString()));
            }

            if (Debit_Calculat.Index[Index_Debit + 1])
            {
                cell_9.SetBackgroundColor(ColorConstants.RED).Add(new Paragraph(" (defect)"));
                cell_10.SetBackgroundColor(ColorConstants.RED).Add(new Paragraph(" (defect)"));
                cell_11.SetBackgroundColor(ColorConstants.RED).Add(new Paragraph(Math.Round((Grup_2.Energie_Total * Coeficient_Debit / 1000), 2).ToString())).Add(new Paragraph(" (calculat)"));
            }
            else
            {

                cell_11.Add(new Paragraph(Math.Round((Grup_2.Debit_Total), 2).ToString()));
            }

            if (Debit_Calculat.Index[Index_Debit] && Debit_Calculat.Index[Index_Debit + 1])
            {
                cell_14.Add(new Paragraph(Math.Round((Grup_1.Energie_Total * Coeficient_Debit / 1000 + Grup_2.Energie_Total * Coeficient_Debit / 1000), 2).ToString() + " (calculat)"));
                debit_raport_lunar = debit_raport_lunar + Grup_1.Energie_Total * Coeficient_Debit / 1000 + Grup_2.Energie_Total * Coeficient_Debit / 1000;
            }
            else if (Debit_Calculat.Index[Index_Debit])
            {
                cell_14.Add(new Paragraph(Math.Round((Grup_1.Energie_Total * Coeficient_Debit / 1000 + Grup_2.Debit_Total), 2).ToString()));
                debit_raport_lunar = debit_raport_lunar + Grup_1.Energie_Total * Coeficient_Debit / 1000 + Grup_2.Debit_Total;

            }
            else if (Debit_Calculat.Index[Index_Debit + 1])
            {
                cell_14.Add(new Paragraph(Math.Round((Grup_1.Debit_Total + Grup_2.Energie_Total * Coeficient_Debit / 1000), 2).ToString()));
                debit_raport_lunar = debit_raport_lunar + (Grup_1.Debit_Total + Grup_2.Energie_Total * Coeficient_Debit / 1000);

            }
            else
            {
                cell_14.Add(new Paragraph(Math.Round((Grup_1.Debit_Total + Grup_2.Debit_Total), 2).ToString()));
                debit_raport_lunar = debit_raport_lunar + (Grup_1.Debit_Total + Grup_2.Debit_Total);

            }




            table.AddCell(cell_1);
            table.AddCell(cell_2);
            table.AddCell(cell_3);
            table.AddCell(cell_4);
            table.AddCell(cell_5);
            table.AddCell(cell_6);
            table.AddCell(cell_7);
            table.AddCell(cell_8);
            table.AddCell(cell_9);
            table.AddCell(cell_10);
            table.AddCell(cell_11);
            table.AddCell(cell_12);
            table.AddCell(cell_13);
            table.AddCell(cell_14);
            #endregion
        }

        private void Introducere_MHC_Single_PDF(ref Table table, Date_Luna Grup, iText.Kernel.Colors.Color Culoare, string MHC, int Index_Debit, double Coeficient_Debit)
        {
            #region Cells
            iText.Layout.Element.Cell cell_1 = new iText.Layout.Element.Cell(1, 1)
                .SetBackgroundColor(Culoare)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE)
                .SetFontSize(10)
                .Add(new Paragraph($"Turbina 1 - Pr. {MHC}"));
            iText.Layout.Element.Cell cell_2 = new iText.Layout.Element.Cell(1, 1)
                .SetBackgroundColor(Culoare)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE)
                .Add(new Paragraph(MHC));
            iText.Layout.Element.Cell cell_3 = new iText.Layout.Element.Cell(1, 1)
                .SetBackgroundColor(Culoare)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE)
                .Add(new Paragraph((Grup.Energie_Total).ToString()));
            iText.Layout.Element.Cell cell_4 = new iText.Layout.Element.Cell(1, 1)
                .SetBackgroundColor(Culoare)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE)
                .Add(new Paragraph(Grup.Debit_Index_Initial.ToString()));
            iText.Layout.Element.Cell cell_5 = new iText.Layout.Element.Cell(1, 1)
                .SetBackgroundColor(Culoare)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE)
                .Add(new Paragraph(Grup.Debit_Index_Final.ToString()));
            iText.Layout.Element.Cell cell_6 = new iText.Layout.Element.Cell(1, 1)
                .SetBackgroundColor(Culoare)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE)
                .Add(new Paragraph(Math.Round((Grup.Debit_Total), 2).ToString()));

            iText.Layout.Element.Cell cell_10 = new iText.Layout.Element.Cell(1, 1)
                .SetBackgroundColor(ColorConstants.GREEN)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE)
                .SetFontSize(10)
                .Add(new Paragraph($"Total MHC {MHC}"));
            iText.Layout.Element.Cell cell_11 = new iText.Layout.Element.Cell(1, 1)
                .SetBackgroundColor(ColorConstants.GREEN)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE)
                .Add(new Paragraph(""));
            iText.Layout.Element.Cell cell_12 = new iText.Layout.Element.Cell(1, 4)
                .SetBackgroundColor(ColorConstants.GREEN)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE);

            if (Debit_Calculat.Index[Index_Debit])
            {
                cell_4.SetBackgroundColor(ColorConstants.RED).Add(new Paragraph(" (defect)"));
                cell_5.SetBackgroundColor(ColorConstants.RED).Add(new Paragraph(" (defect)"));
                cell_6.SetBackgroundColor(ColorConstants.RED).Add(new Paragraph(Math.Round((Grup.Energie_Total * Coeficient_Debit / 1000), 2).ToString())).Add(new Paragraph(" (calculat)"));
                cell_12.Add(new Paragraph(Math.Round((Grup.Energie_Total * Coeficient_Debit / 1000), 2).ToString()));
                debit_raport_lunar = debit_raport_lunar + (Grup.Energie_Total * Coeficient_Debit / 1000);

            }
            else
            {
                cell_12.Add(new Paragraph(Math.Round((Grup.Debit_Total), 2).ToString()));
                debit_raport_lunar = debit_raport_lunar + (Grup.Debit_Total);
            }


            table.AddCell(cell_1);
            table.AddCell(cell_2);
            table.AddCell(cell_3);
            table.AddCell(cell_4);
            table.AddCell(cell_5);
            table.AddCell(cell_6);
            table.AddCell(cell_10);
            table.AddCell(cell_11);
            table.AddCell(cell_12);
            #endregion
        }



        private void Btn_Print_Raport_Lunar_Click(object sender, EventArgs e)
        {
            Printare_Raport_Lunar();
            OpenFolder(@$"C:\Azel\Raportari\Rapoarte_Lunare");
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

            var inceputul_lunii = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.AddMonths(-1).Month, 1);
            var sfarsitul_lunii = inceputul_lunii.AddMonths(2).AddTicks(-1);
            var date_luna = db.GetDateToataZiua(inceputul_lunii, sfarsitul_lunii.AddDays(1).AddTicks(-1), "", MHC);
            if (date_luna.Any())
            {
                index_initial_energie = date_luna.Where(x => x.Date_Time.Month < dateTimePicker1.Value.Month).Select(x => x.Energie).Reverse().SkipWhile(x => x == 0).FirstOrDefault(0);
                index_final_energie = date_luna.Select(x => x.Energie).Reverse().SkipWhile(x => x == 0).FirstOrDefault(0);
                energie_totala = Math.Round((index_final_energie - index_initial_energie), 2);

                index_initial_debit = date_luna.Where(x => x.Date_Time.Month < dateTimePicker1.Value.Month).Select(x => x.Debit_Turbinat_Total).Reverse().SkipWhile(x => x == 0).FirstOrDefault(0);
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

        private void checkedListBox_Debit_Calculat_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < Debit_Calculat.Index.Length; i++)
            {
                Debit_Calculat.Index[i] = checkedListBox_Debit_Calculat.GetItemCheckState(i) == CheckState.Checked;
            }
        }

        private void checkedListBox_Debit_Calculat_ItemCheck(object sender, ItemCheckEventArgs e)
        {
           
        }
    }
}
