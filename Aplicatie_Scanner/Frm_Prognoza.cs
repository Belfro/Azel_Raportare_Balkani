
using System.Media;

namespace Azel_Raportare_Balkani
{
    public partial class Frm_Prognoza : Form
    {
        List<DatePutere> date_energie_ieri = new List<DatePutere>();
        List<DatePutere> date_energie_alaltaieri = new List<DatePutere>();
        List<DatePutere> date_putere_prognoza = new List<DatePutere>();
        public Frm_Prognoza()
        {
            InitializeComponent();
        }

        private void Frm_Scanner_Load(object sender, EventArgs e)
        {
            newCalendar1.SelectionStart = DateTime.Now.Date.AddDays(-1);

        }




        private void timer1_Tick(object sender, EventArgs e)
        {

        }
        public void playSound()
        {
            SystemSounds.Beep.Play();
        }

        private void Frm_Scanner_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void Frm_Scanner_Leave(object sender, EventArgs e)
        {

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
                date_energie_ieri.Clear();
                date_energie_alaltaieri.Clear();

                date_energie_ieri = db.GetDateEnergie(newCalendar1.SelectionStart.Date.AddDays(-1), newCalendar1.SelectionStart.Date.AddDays(0).AddTicks(-1));
                date_energie_alaltaieri = db.GetDateEnergie(newCalendar1.SelectionStart.Date.AddDays(-2), newCalendar1.SelectionStart.Date.AddDays(-1).AddTicks(-1));

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
               
            

                label1.Text = "Ziua Precedenta: " + newCalendar1.SelectionStart.AddDays(-1).ToString("yyyy-MM-dd");
                label2.Text = "Ziua Urmatoare: " + newCalendar1.SelectionStart.AddDays(+1).ToString("yyyy-MM-dd");
               
               


                UpdateBinding();







                for (int i = 0; i < 96; i++)
                {
                    date_putere_prognoza.Add(new DatePutere
                    {
                        Date_Time = newCalendar1.SelectionStart.AddDays(1).AddMinutes(15 * i),
                        Cuntu_Grup_1 = Math.Round(((suma_cuntu * factor_corectie_cuntu)/96) * Convert.ToDouble(tbfactorCuntu.Text), 2),

                        Craiu_1_Grup_1 = Math.Round(((suma_craiu_1 * factor_corectie_craiu_1) / 96) * Convert.ToDouble(tbfactorCraiu1.Text), 2),

                        Craiu_2_Grup_1 = Math.Round(((suma_craiu_2 * factor_corectie_craiu_2) / 96) * Convert.ToDouble(tbfactorCraiu2.Text), 2),

                        Sebesel_1_Grup_1 = Math.Round(((suma_sebesel_1 * factor_corectie_sebesel_1) / 96) * Convert.ToDouble(tbfactorSebesel1.Text), 2),

                        Sebesel_2_Grup_1 = Math.Round(((suma_sebesel_2 * factor_corectie_sebesel_2) / 96) * Convert.ToDouble(tbfactorSebesel2.Text), 2),

                        Cornereva = Math.Round(((suma_cornereva * factor_corectie_cornereva) / 96) * Convert.ToDouble(tbfactorCornereva.Text), 2),
                    }

                    );
                }







                dataGridView2.AutoGenerateColumns = false;
                dataGridView2.DataSource = null;
                dataGridView2.DataSource = date_putere_prognoza;
                dataGridView2.Columns[0].DataPropertyName = "DoarData";
                dataGridView2.Columns[1].DataPropertyName = "DoarTimp";
                dataGridView2.Columns[2].DataPropertyName = "Cuntu_Grup_1";
                dataGridView2.Columns[3].DataPropertyName = "Craiu_1_Grup_1";
                dataGridView2.Columns[4].DataPropertyName = "Craiu_2_Grup_1";
                dataGridView2.Columns[5].DataPropertyName = "Sebesel_1_Grup_1";
                dataGridView2.Columns[6].DataPropertyName = "Sebesel_2_Grup_1";
                dataGridView2.Columns[7].DataPropertyName = "Cornereva";
                dataGridView2.Columns[8].DataPropertyName = "Total";


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void UpdateBinding()
        {


            try
            {
                dataGridView1.AutoGenerateColumns = false;

                dataGridView1.DataSource = date_energie_ieri;



                dataGridView1.Columns["Data"].DataPropertyName = "DoarData";
                dataGridView1.Columns["Timp"].DataPropertyName = "DoarTimp";



            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {

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
            dataGridView1.Columns[13].DataPropertyName = "Total";
            Cautare_Date();
        }

        private void tbfactorCuntu_TextChanged(object sender, EventArgs e)
        {

            if (!double.TryParse(tbfactorCuntu.Text, out double valoare_introdusa))
            {
                tbfactorCuntu.Text = 1.0.ToString();
                MessageBox.Show("Valoarea introdusa trebuie sa fie numerica!");
            }


        }

        private void tbfactorCraiu1_TextChanged(object sender, EventArgs e)
        {

            if (!double.TryParse(tbfactorCraiu1.Text, out double valoare_introdusa))
            {
                tbfactorCuntu.Text = 1.0.ToString();
                MessageBox.Show("Valoarea introdusa trebuie sa fie numerica!");
            }
        }

        private void tbfactorCraiu2_TextChanged(object sender, EventArgs e)
        {

            if (!double.TryParse(tbfactorCraiu2.Text, out double valoare_introdusa))
            {
                tbfactorCuntu.Text = 1.0.ToString();
                MessageBox.Show("Valoarea introdusa trebuie sa fie numerica!");
            }
        }

        private void tbfactorSebesel1_TextChanged(object sender, EventArgs e)
        {

            if (!double.TryParse(tbfactorSebesel1.Text, out double valoare_introdusa))
            {
                tbfactorCuntu.Text = 1.0.ToString();
                MessageBox.Show("Valoarea introdusa trebuie sa fie numerica!");
            }
        }

        private void tbfactorSebesel2_TextChanged(object sender, EventArgs e)
        {
            if (!double.TryParse(tbfactorSebesel2.Text, out double valoare_introdusa))
            {
                tbfactorCuntu.Text = 1.0.ToString();
                MessageBox.Show("Valoarea introdusa trebuie sa fie numerica!");
            }
        }

        private void tbfactorCornereva_TextChanged(object sender, EventArgs e)
        {
            if (!double.TryParse(tbfactorCornereva.Text, out double valoare_introdusa))
            {
                tbfactorCuntu.Text = 1.0.ToString();
                MessageBox.Show("Valoarea introdusa trebuie sa fie numerica!");
            }
        }

        private void btn_Print_Prognoza_Click(object sender, EventArgs e)
        {
            string subPath = @$"C:\Azel\Raportari\Prognoze";

            bool exists = System.IO.Directory.Exists(subPath);

            if (!exists)
                System.IO.Directory.CreateDirectory(subPath);
            using (StreamWriter file = File.CreateText(@$"C:\Azel\Raportari\Prognoze\Raport_Prognoza_{newCalendar1.SelectionStart.AddDays(+1).ToString("yyyy-MM-dd")}.csv"))
            {
                file.WriteLine("Data,Timp,Cuntu [kWh],Craiu 1 [kWh],Craiu 2 [kWh],Sebesel 1 [kWh],Sebesel 2 [kWh],Cornereva [kWh]");
                foreach (var arr in date_putere_prognoza)
                {
                    file.WriteLine(string.Join(",", arr.FullString));
                }
            }
        }
    }
}
