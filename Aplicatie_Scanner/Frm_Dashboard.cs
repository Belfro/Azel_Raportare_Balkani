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
using iText.IO.Image;
using iText.Kernel.Geom;
using iText.Kernel.Pdf.Canvas.Draw;

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
        List<DatePutere> date_energie_ieri = new List<DatePutere>();
        List<DatePutere> date_energie_alaltaieri = new List<DatePutere>();
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
                Date.Energie_Index_Initial = date_luna.Where(x => x.Date_Time < inceputul_lunii.AddMonths(1).AddMinutes(-1)).Select(x => x.Energie).Reverse().SkipWhile(x => x == 0).FirstOrDefault(0);
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
        private void Trimitere_Raport_Lunar()
        {
            ///////////////////////////////
            ///////TRIMITERE MAIL//////////
            ///////////////////////////////
            try
            {
                var smtpClient = new SmtpClient("rhea.hostx.eu")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("raportari_Balkan@azel.ro", "-h.on^gdq+N;"),
                    EnableSsl = false,
                };

                ImageData data = ImageDataFactory.Create(ImageToByte(Azel_Raportare_Balkani.Properties.Resources.b1zoci3k_nyc));
                iText.Layout.Element.Image image = new iText.Layout.Element.Image(data);
                image.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
                image.Scale(0.6f, 0.6f);




                var mailMessage = new MailMessage
                {
                    IsBodyHtml = false,
                    From = new MailAddress("raportari_balkan@azel.ro"),
                    Subject = @$"Raport_Lunar_{DateTime.Now.AddMonths(-1).ToString("yyyy_MMMM", CultureInfo.CreateSpecificCulture("ro"))}",
                    Body = "Email Auto-Generat, nu dati reply. " +
                    "   \n \n \n Azel Design Group SRL ",





                };

                System.Net.Mail.Attachment attachment1;
                System.Net.Mail.Attachment attachment2;

                //attachment1 = new System.Net.Mail.Attachment(@$"C:\Azel\Raportari\Rapoarte_Lunare\Raport_Lunar_{DateTime.Now.AddMonths(-1).ToString("yyyy_MMMM", CultureInfo.CreateSpecificCulture("ro"))}.csv");
                attachment2 = new System.Net.Mail.Attachment(@$"C:\Azel\Raportari\Rapoarte_Lunare\Raport_{DateTime.Now.AddMonths(-1).ToString("yyyy_MMMM", CultureInfo.CreateSpecificCulture("ro"))}.pdf");
                //mailMessage.Attachments.Add(attachment1);
                mailMessage.Attachments.Add(attachment2);

                mailMessage.To.Add("crizoiu@yahoo.com");
                mailMessage.To.Add("stanfandrei@yahoo.com");
                mailMessage.To.Add("jancaj68@gmail.com");
                mailMessage.To.Add("lucian@constructim.ro");
                mailMessage.To.Add("cristian_bogdan_tm@yahoo.com");
                mailMessage.To.Add("radu@constructim.ro");
                mailMessage.To.Add("office@azel.ro");

                mailMessage.To.Add("graresita_cs@yahoo.com");
                mailMessage.To.Add("birauandrada@yahoo.com");
                mailMessage.To.Add("silvia_ruzmir@yahoo.com");

                smtpClient.Send(mailMessage);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Printare_Raport_Zilnic()
        {
            DataAccess db = new DataAccess();
            var date_raport = db.GetDateRaportZilnic();
            var date_raport_ziua_trecuta = db.GetDateRaportZilnicZiuaTrecuta();

            string subPath = @$"C:\Azel\Raportari\Rapoarte_Zilnice";

            bool exists = System.IO.Directory.Exists(subPath);

            if (!exists)
                System.IO.Directory.CreateDirectory(subPath);

            PdfWriter writer = new PdfWriter(@$"C:\Azel\Raportari\Rapoarte_Zilnice\Raport_{DateTime.Now.ToString("dd_MM_yy")}.pdf");
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);

            ImageData data = ImageDataFactory.Create(ImageToByte(Azel_Raportare_Balkani.Properties.Resources.LogoBalkan));
            iText.Layout.Element.Image image = new iText.Layout.Element.Image(data);
            image.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
            image.Scale(0.6f, 0.6f);
            document.Add(image);

            document.Add(new Paragraph(new Text("\n")));

            Paragraph header = new Paragraph($"Raport Zilnic Productie Balkan {DateTime.Now.AddDays(-1).ToString("dd.MM.yyyy")}")
               .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
               .SetFontSize(20);

            Paragraph subheader = new Paragraph($"- Generat la data de {DateTime.Now.AddDays(0).ToString("dd.MM.yyyy")} -")
           .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetFontColor(ColorConstants.LIGHT_GRAY)
           .SetFontSize(10);

            document.Add(header);
            document.Add(subheader);
            document.Add(new Paragraph(new Text("\n")));
            document.Add(new LineSeparator(new DottedLine()));
            document.Add(new Paragraph(new Text("\n")));
            // Table
            Table table = new Table(7, false).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);

            iText.Layout.Element.Cell cell11 = new iText.Layout.Element.Cell(1, 1)
               .SetBackgroundColor(ColorConstants.GRAY)
               .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
               .Add(new Paragraph("Grup"));
            iText.Layout.Element.Cell cell12 = new iText.Layout.Element.Cell(1, 1)
               .SetBackgroundColor(ColorConstants.GRAY)
               .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
               .Add(new Paragraph("Index Vechi [kWh]"));

            iText.Layout.Element.Cell cell13 = new iText.Layout.Element.Cell(1, 1)
                .SetBackgroundColor(ColorConstants.GRAY)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .Add(new Paragraph("Index Nou [kWh]"));
            iText.Layout.Element.Cell cell14 = new iText.Layout.Element.Cell(1, 1)
                .SetBackgroundColor(ColorConstants.GRAY)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .Add(new Paragraph($"Energie Produsa [kWh]"));
            iText.Layout.Element.Cell cell15 = new iText.Layout.Element.Cell(1, 1)
                .SetBackgroundColor(ColorConstants.GRAY)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .Add(new Paragraph("Timp Functionare [Ore]"));
            iText.Layout.Element.Cell cell16 = new iText.Layout.Element.Cell(1, 1)
               .SetBackgroundColor(ColorConstants.GRAY)
               .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
               .Add(new Paragraph("Energie Produsa Per Centrala [kWh]"));
            iText.Layout.Element.Cell cell17 = new iText.Layout.Element.Cell(1, 1)
                .SetBackgroundColor(ColorConstants.GRAY)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .Add(new Paragraph($"Prognoza {DateTime.Now.AddDays(+1).ToString("dd.MM")} [kWh]"));


            table.AddCell(cell11);
            table.AddCell(cell12);
            table.AddCell(cell13);
            table.AddCell(cell14);
            table.AddCell(cell15);
            table.AddCell(cell16);
            table.AddCell(cell17);
            date_putere = db.GetDatePuteri(DateTime.Now.Date.AddDays(-1), DateTime.Now.Date.AddDays(0).AddMinutes(-1));
            var prognoza = GenerarePrognozaRaportZilnic();

            for (int i = 0; i < date_raport_ziua_trecuta.Count; i++)
            {
                iText.Layout.Element.Cell cellx1 = new iText.Layout.Element.Cell(1, 1)
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                    .Add(new Paragraph(date_raport_ziua_trecuta[i].Nume_Grup.Replace('_', ' ')));

                iText.Layout.Element.Cell cellx2 = new iText.Layout.Element.Cell(1, 1)
                   .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                   .Add(new Paragraph(date_raport_ziua_trecuta[i].Energie_Rotunjita.ToString()));

                table.AddCell(cellx1);
                table.AddCell(cellx2);

                iText.Layout.Element.Cell cellx3 = new iText.Layout.Element.Cell(1, 1)
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                    .Add(new Paragraph(date_raport[i].Energie_Rotunjita.ToString()));

                iText.Layout.Element.Cell cellx4 = new iText.Layout.Element.Cell(1, 1)
                   .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                   .Add(new Paragraph((date_raport[i].Energie_Rotunjita - date_raport_ziua_trecuta[i].Energie_Rotunjita).ToString()));
                table.AddCell(cellx3);
                table.AddCell(cellx4);



                double[] contor = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                contor[0] = date_putere.Where(x => x.Cuntu_Grup_1 > 1).Count();
                contor[1] = date_putere.Where(x => x.Cuntu_Grup_2 > 1).Count();
                contor[2] = date_putere.Where(x => x.Craiu_1_Grup_1 > 1).Count();
                contor[3] = date_putere.Where(x => x.Craiu_1_Grup_2 > 1).Count();
                contor[4] = date_putere.Where(x => x.Craiu_2_Grup_1 > 1).Count();
                contor[5] = date_putere.Where(x => x.Craiu_2_Grup_2 > 1).Count();
                contor[6] = date_putere.Where(x => x.Sebesel_1_Grup_1 > 1).Count();
                contor[7] = date_putere.Where(x => x.Sebesel_1_Grup_2 > 1).Count();
                contor[8] = date_putere.Where(x => x.Sebesel_2_Grup_1 > 1).Count();
                contor[9] = date_putere.Where(x => x.Sebesel_2_Grup_2 > 1).Count();
                contor[10] = date_putere.Where(x => x.Cornereva > 1).Count();




                iText.Layout.Element.Cell cellx5 = new iText.Layout.Element.Cell(1, 1)
               .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
               .Add(new Paragraph((contor[i] / 4.0).ToString()));
                table.AddCell(cellx5);





                if (i % 2 == 0 && i < date_raport_ziua_trecuta.Count - 1)
                {
                    iText.Layout.Element.Cell cellx6 = new iText.Layout.Element.Cell(2, 1)
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetVerticalAlignment(VerticalAlignment.MIDDLE)
                    .Add(new Paragraph((date_raport[i].Energie_Rotunjita - date_raport_ziua_trecuta[i].Energie_Rotunjita + date_raport[i + 1].Energie_Rotunjita - date_raport_ziua_trecuta[i + 1].Energie_Rotunjita).ToString()));

                    table.AddCell(cellx6);

                    iText.Layout.Element.Cell cellx7 = new iText.Layout.Element.Cell(2, 1)
                   .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetVerticalAlignment(VerticalAlignment.MIDDLE)
                   .Add(new Paragraph((prognoza[i / 2].Energie_Rotunjita).ToString()));

                    table.AddCell(cellx7);
                }
                else if (i % 2 == 0 && i == date_raport_ziua_trecuta.Count - 1)
                {
                    iText.Layout.Element.Cell cellx6 = new iText.Layout.Element.Cell(1, 1)
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                    .Add(new Paragraph((date_raport[i].Energie_Rotunjita - date_raport_ziua_trecuta[i].Energie_Rotunjita).ToString()));

                    table.AddCell(cellx6);

                    iText.Layout.Element.Cell cellx7 = new iText.Layout.Element.Cell(1, 1)
                  .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetVerticalAlignment(VerticalAlignment.MIDDLE)
                  .Add(new Paragraph((prognoza[i / 2].Energie_Rotunjita).ToString()));

                    table.AddCell(cellx7);
                }


            }

            var suma_total_productie = date_raport.Sum(x => x.Energie_Rotunjita) - date_raport_ziua_trecuta.Sum(x => x.Energie_Rotunjita);
            var suma_total_prognoza = prognoza.Sum(x => x.Energie_Rotunjita);

            iText.Layout.Element.Cell cellTotal = new iText.Layout.Element.Cell(1, 5)
          .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetVerticalAlignment(VerticalAlignment.MIDDLE).SetBold()
          .Add(new Paragraph(("TOTAL")));

            table.AddCell(cellTotal);

            iText.Layout.Element.Cell cellTotalProductie = new iText.Layout.Element.Cell(1, 1)
         .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetVerticalAlignment(VerticalAlignment.MIDDLE).SetBold()
         .Add(new Paragraph((suma_total_productie.ToString())));

            table.AddCell(cellTotalProductie);
            iText.Layout.Element.Cell cellTotalPrognoza = new iText.Layout.Element.Cell(1, 1)
         .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetVerticalAlignment(VerticalAlignment.MIDDLE).SetBold()
         .Add(new Paragraph((suma_total_prognoza.ToString())));

            table.AddCell(cellTotalPrognoza);

            document.Add(table);
            document.Add(new Paragraph(new Text("\n")));

            document.Add(new Paragraph(new Text(" " +
                "Registered to the Commercial Registry under no.J 35 / 3152 / 2006" +
                "\r\nUnique code of registration : R 18737871")).SetFixedPosition(document.GetLeftMargin(), document.GetBottomMargin(), PageSize.A4.GetWidth()));
            document.Close();




        }
        private List<DateRaportZilnic> GenerarePrognozaRaportZilnic()
        {
            List<DateRaportZilnic> prognoza = new List<DateRaportZilnic>();
            bool Prima_Conditie_Selectata = false;
            string Conditii_Get_Date = "";
            try
            {

                DataAccess db = new DataAccess();
                date_energie_ieri.Clear();
                date_energie_alaltaieri.Clear();

                date_energie_ieri = db.GetDateEnergie(DateTime.Now.Date.AddDays(-1), DateTime.Now.Date.AddDays(0).AddTicks(-1));
                date_energie_alaltaieri = db.GetDateEnergie(DateTime.Now.Date.AddDays(-2), DateTime.Now.Date.AddDays(-1).AddTicks(-1));

                double[] contor_ieri = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                contor_ieri[0] = date_energie_ieri.Where(x => x.Cuntu_Grup_1 > 2 || x.Cuntu_Grup_2 > 2).Count();
                contor_ieri[1] = date_energie_ieri.Where(x => x.Craiu_1_Grup_1 > 2 || x.Craiu_1_Grup_2 > 2).Count();
                contor_ieri[2] = date_energie_ieri.Where(x => x.Craiu_2_Grup_1 > 2 || x.Craiu_2_Grup_2 > 2).Count();
                contor_ieri[3] = date_energie_ieri.Where(x => x.Sebesel_1_Grup_1 > 2 || x.Sebesel_1_Grup_2 > 2).Count();
                contor_ieri[4] = date_energie_ieri.Where(x => x.Sebesel_2_Grup_1 > 2 || x.Sebesel_2_Grup_2 > 2).Count();
                contor_ieri[5] = date_energie_ieri.Where(x => x.Cornereva > 2).Count();

                double[] contor_alaltaieri = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                contor_alaltaieri[0] = date_energie_alaltaieri.Where(x => x.Cuntu_Grup_1 > 2 || x.Cuntu_Grup_2 > 2).Count();
                contor_alaltaieri[1] = date_energie_alaltaieri.Where(x => x.Craiu_1_Grup_1 > 2 || x.Craiu_1_Grup_2 > 2).Count();
                contor_alaltaieri[2] = date_energie_alaltaieri.Where(x => x.Craiu_2_Grup_1 > 2 || x.Craiu_2_Grup_2 > 2).Count();
                contor_alaltaieri[3] = date_energie_alaltaieri.Where(x => x.Sebesel_1_Grup_1 > 2 || x.Sebesel_1_Grup_2 > 2).Count();
                contor_alaltaieri[4] = date_energie_alaltaieri.Where(x => x.Sebesel_2_Grup_1 > 2 || x.Sebesel_2_Grup_2 > 2).Count();
                contor_alaltaieri[5] = date_energie_alaltaieri.Where(x => x.Cornereva > 2).Count();

                for (int i = 0; i < 6; i++)
                {
                    if (contor_ieri[i] < 30) { contor_ieri[i] = 30; }
                    if (contor_alaltaieri[i] < 30) { contor_alaltaieri[i] = 30; }
                }

                double suma_cuntu = (date_energie_ieri.Sum(x => x.Cuntu_Grup_1) + date_energie_ieri.Sum(x => x.Cuntu_Grup_2));
                double suma_cuntu_prev = (date_energie_alaltaieri.Sum(x => x.Cuntu_Grup_1) + date_energie_alaltaieri.Sum(x => x.Cuntu_Grup_2));

                double suma_craiu_1 = (date_energie_ieri.Sum(x => x.Craiu_1_Grup_1) + date_energie_ieri.Sum(x => x.Craiu_1_Grup_2));
                double suma_craiu_1_prev = (date_energie_alaltaieri.Sum(x => x.Craiu_1_Grup_1) + date_energie_alaltaieri.Sum(x => x.Craiu_1_Grup_2));

                double suma_craiu_2 = (date_energie_ieri.Sum(x => x.Craiu_2_Grup_1) + date_energie_ieri.Sum(x => x.Craiu_2_Grup_2));
                double suma_craiu_2_prev = (date_energie_alaltaieri.Sum(x => x.Craiu_2_Grup_1) + date_energie_alaltaieri.Sum(x => x.Craiu_2_Grup_2));

                double suma_sebesel_1 = (date_energie_ieri.Sum(x => x.Sebesel_1_Grup_1) + date_energie_ieri.Sum(x => x.Sebesel_1_Grup_2));
                double suma_sebesel_1_prev = (date_energie_alaltaieri.Sum(x => x.Sebesel_1_Grup_1) + date_energie_alaltaieri.Sum(x => x.Sebesel_1_Grup_2));


                double suma_sebesel_2 = (date_energie_ieri.Sum(x => x.Sebesel_2_Grup_1) + date_energie_ieri.Sum(x => x.Sebesel_2_Grup_2));
                double suma_sebesel_2_prev = (date_energie_alaltaieri.Sum(x => x.Sebesel_2_Grup_1) + date_energie_alaltaieri.Sum(x => x.Sebesel_2_Grup_2));


                double suma_cornereva = (date_energie_ieri.Sum(x => x.Cornereva));
                double suma_cornereva_prev = (date_energie_alaltaieri.Sum(x => x.Cornereva));


                double factor_corectie_cuntu = Math.Round((suma_cuntu / contor_ieri[0]) / (suma_cuntu_prev / contor_alaltaieri[0]), 2);
                double factor_corectie_craiu_1 = Math.Round((suma_craiu_1 / contor_ieri[1]) / (suma_craiu_1_prev / contor_alaltaieri[1]), 2);
                double factor_corectie_craiu_2 = Math.Round((suma_craiu_2 / contor_ieri[2]) / (suma_craiu_2_prev / contor_alaltaieri[2]), 2);
                double factor_corectie_sebesel_1 = Math.Round((suma_sebesel_1 / contor_ieri[3]) / (suma_sebesel_1_prev / contor_alaltaieri[3]), 2);
                double factor_corectie_sebesel_2 = Math.Round((suma_sebesel_2 / contor_ieri[4]) / (suma_sebesel_2_prev / contor_alaltaieri[4]), 2);
                double factor_corectie_cornereva = Math.Round((suma_cornereva / contor_ieri[5]) / (suma_cornereva_prev / contor_alaltaieri[5]), 2);





                if (factor_corectie_cuntu < 0.8 || Double.IsNaN(factor_corectie_cuntu)) factor_corectie_cuntu = 0.8;
                if (factor_corectie_cuntu > 1.05) factor_corectie_cuntu = 1.05;
                if (factor_corectie_craiu_1 < 0.8 || Double.IsNaN(factor_corectie_craiu_1)) factor_corectie_craiu_1 = 0.8;
                if (factor_corectie_craiu_1 > 1.05) factor_corectie_craiu_1 = 1.05;
                if (factor_corectie_craiu_2 < 0.8 || Double.IsNaN(factor_corectie_craiu_2)) factor_corectie_craiu_2 = 0.8;
                if (factor_corectie_craiu_2 > 1.05) factor_corectie_craiu_2 = 1.05;
                if (factor_corectie_sebesel_1 < 0.8 || Double.IsNaN(factor_corectie_sebesel_1)) factor_corectie_sebesel_1 = 0.8;
                if (factor_corectie_sebesel_1 > 1.05) factor_corectie_sebesel_1 = 1.05;
                if (factor_corectie_sebesel_2 < 0.8 || Double.IsNaN(factor_corectie_sebesel_2)) factor_corectie_sebesel_2 = 0.8;
                if (factor_corectie_sebesel_2 > 1.05) factor_corectie_sebesel_2 = 1.05;
                if (factor_corectie_cornereva < 0.8 || Double.IsNaN(factor_corectie_cornereva)) factor_corectie_cornereva = 0.8;
                if (factor_corectie_cornereva > 1.05) factor_corectie_cornereva = 1.05;







                prognoza.Add(new DateRaportZilnic { Nume_Grup = "Cuntu", Energie = Math.Round(suma_cuntu * factor_corectie_cuntu, 2) });
                prognoza.Add(new DateRaportZilnic { Nume_Grup = "Craiu_1", Energie = Math.Round(suma_craiu_1 * factor_corectie_craiu_1, 2) });
                prognoza.Add(new DateRaportZilnic { Nume_Grup = "Craiu_2", Energie = Math.Round(suma_craiu_2 * factor_corectie_craiu_2, 2) });
                prognoza.Add(new DateRaportZilnic { Nume_Grup = "Sebesel_1", Energie = Math.Round(suma_sebesel_1 * factor_corectie_sebesel_1, 2) });
                prognoza.Add(new DateRaportZilnic { Nume_Grup = "Sebesel_2", Energie = Math.Round(suma_sebesel_2 * factor_corectie_sebesel_2, 2) });
                prognoza.Add(new DateRaportZilnic { Nume_Grup = "Cornereva", Energie = Math.Round(suma_cornereva * factor_corectie_cornereva, 2) });

                return prognoza;






            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }
        private void Trimitere_Raport_Zilnic()
        {
            ///////////////////////////////
            ///////TRIMITERE MAIL//////////
            ///////////////////////////////
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                var smtpClient = new SmtpClient("azel.ro")
                {

                    Port = 587,
                    Credentials = new NetworkCredential("raportari_balkan@azel.ro", "-h.on^gdq+N;"),
                    EnableSsl = false,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("raportari_balkan@azel.ro"),
                    Subject = @$"Raport Zilnic {DateTime.Now.ToString("dd_MM_yy")}",
                    Body = "Email Auto-Generat, nu dati reply. " +
                    "   \n \n \n Azel Design Group SRL ",




                    // IsBodyHtml = true,
                };

                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(@$"C:\Azel\Raportari\Rapoarte_Zilnice\Raport_{DateTime.Now.ToString("dd_MM_yy")}.pdf");
                mailMessage.Attachments.Add(attachment);
                mailMessage.To.Add("crizoiu@yahoo.com");
                mailMessage.To.Add("stanfandrei@yahoo.com");
                mailMessage.To.Add("jancaj68@gmail.com");
                mailMessage.To.Add("lucian@constructim.ro");
                mailMessage.To.Add("cristian_bogdan_tm@yahoo.com");
                mailMessage.To.Add("radu@constructim.ro");
                mailMessage.To.Add("office@azel.ro");

                smtpClient.Send(mailMessage);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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

        private void Btn_Print_Raport_Lunar_Click(object sender, EventArgs e)
        {
            Printare_Raport_Lunar();
            OpenFolder(@$"C:\Azel\Raportari\Rapoarte_Lunare");
        }
        private void Btn_Trimitere_Raport_Lunar_Click(object sender, EventArgs e)
        {
            Trimitere_Raport_Lunar();
            OpenFolder(@$"C:\Azel\Raportari\Rapoarte_Lunare");
        }

        private void Btn_Print_Raport_Zilnic_Click(object sender, EventArgs e)
        {
            Printare_Raport_Zilnic();
            OpenFolder(@$"C:\Azel\Raportari\Rapoarte_Zilnice");
        }

        private void Btn_Trimite_Raport_Zilnic_Click(object sender, EventArgs e)
        {
            Trimitere_Raport_Zilnic();
            OpenFolder(@$"C:\Azel\Raportari\Rapoarte_Zilnice");
        }
    }
}
