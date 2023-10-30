
using System.Media;

namespace Azel_Raportare_Balkani
{
    public partial class Frm_Prognoza : Form
    {
        List<DatePutere> date_putere = new List<DatePutere>();
        List<DatePutere> date_putere_anterior = new List<DatePutere>();
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
                date_putere.Clear();
                date_putere_anterior.Clear();
                date_putere_prognoza.Clear();

                date_putere = db.GetDateEnergie(newCalendar1.SelectionStart.AddDays(-1), newCalendar1.SelectionStart.AddDays(0).AddTicks(-1));
                date_putere_anterior = db.GetDateEnergie(newCalendar1.SelectionStart.AddDays(-2), newCalendar1.SelectionStart.AddDays(-1).AddTicks(-1));
              


                label1.Text = "Ziua Precedenta: " + newCalendar1.SelectionStart.AddDays(-1).ToString("yyyy-MM-dd");
                label2.Text = "Ziua Urmatoare: " + newCalendar1.SelectionStart.AddDays(+1).ToString("yyyy-MM-dd");
               
               


                UpdateBinding();

                int contor_valori_pozitive_cuntu = date_putere.Where(x => x.Cuntu_Grup_1 > 2 || x.Cuntu_Grup_2 > 2).Count();
                int contor_valori_pozitive_craiu_1 = date_putere.Where(x => x.Craiu_1_Grup_1 > 2 || x.Craiu_1_Grup_2 > 2).Count();
                int contor_valori_pozitive_craiu_2 = date_putere.Where(x => x.Craiu_2_Grup_1 > 2 || x.Craiu_2_Grup_2 > 2).Count();
                int contor_valori_pozitive_Sebesel_1 = date_putere.Where(x => x.Sebesel_1_Grup_1 > 2 || x.Sebesel_1_Grup_2 > 2).Count();
                int contor_valori_pozitive_Sebesel_2 = date_putere.Where(x => x.Sebesel_2_Grup_1 > 2 || x.Sebesel_2_Grup_2 > 2).Count();
                int contor_valori_pozitive_Cornereva = date_putere.Where(x => x.Cornereva > 2).Count();

                int contor_valori_pozitive_cuntu_prev = date_putere_anterior.Where(x => x.Cuntu_Grup_1 > 2 || x.Cuntu_Grup_2 > 2).Count();
                int contor_valori_pozitive_craiu_1_prev = date_putere_anterior.Where(x => x.Craiu_1_Grup_1 > 2 || x.Craiu_1_Grup_2 > 2).Count();
                int contor_valori_pozitive_craiu_2_prev = date_putere_anterior.Where(x => x.Craiu_2_Grup_1 > 2 || x.Craiu_2_Grup_2 > 2).Count();
                int contor_valori_pozitive_Sebesel_1_prev = date_putere_anterior.Where(x => x.Sebesel_1_Grup_1 > 2 || x.Sebesel_1_Grup_2 > 2).Count();
                int contor_valori_pozitive_Sebesel_2_prev = date_putere_anterior.Where(x => x.Sebesel_2_Grup_1 > 2 || x.Sebesel_2_Grup_2 > 2).Count();
                int contor_valori_pozitive_Cornereva_prev = date_putere_anterior.Where(x => x.Cornereva > 2).Count();

                if (contor_valori_pozitive_cuntu < 30) contor_valori_pozitive_cuntu = 30;
                if (contor_valori_pozitive_craiu_1 < 30) contor_valori_pozitive_craiu_1 = 30;
                if (contor_valori_pozitive_craiu_2 < 30) contor_valori_pozitive_craiu_2 = 30;
                if (contor_valori_pozitive_Sebesel_1 < 30) contor_valori_pozitive_Sebesel_1 = 30;
                if (contor_valori_pozitive_Sebesel_2 < 30) contor_valori_pozitive_Sebesel_2 = 30;
                if (contor_valori_pozitive_Cornereva < 30) contor_valori_pozitive_Cornereva = 30;


                double suma_cuntu = (date_putere.Sum(x => x.Cuntu_Grup_1) + date_putere.Sum(x => x.Cuntu_Grup_2)) / contor_valori_pozitive_cuntu;
                double suma_cuntu_prev = (date_putere_anterior.Sum(x => x.Cuntu_Grup_1) + date_putere_anterior.Sum(x => x.Cuntu_Grup_2)) / contor_valori_pozitive_cuntu_prev;

                double suma_craiu_1 = (date_putere.Sum(x => x.Craiu_1_Grup_1) + date_putere.Sum(x => x.Craiu_1_Grup_2)) / contor_valori_pozitive_craiu_1;
                double suma_craiu_1_prev = (date_putere_anterior.Sum(x => x.Craiu_1_Grup_1) + date_putere_anterior.Sum(x => x.Craiu_1_Grup_2)) / contor_valori_pozitive_craiu_1_prev;

                double suma_craiu_2 = (date_putere.Sum(x => x.Craiu_2_Grup_1) + date_putere.Sum(x => x.Craiu_2_Grup_2)) / contor_valori_pozitive_craiu_2;
                double suma_craiu_2_prev = (date_putere_anterior.Sum(x => x.Craiu_2_Grup_1) + date_putere_anterior.Sum(x => x.Craiu_2_Grup_2)) / contor_valori_pozitive_craiu_2_prev;

                double suma_sebesel_1 = (date_putere.Sum(x => x.Sebesel_1_Grup_1) + date_putere.Sum(x => x.Sebesel_1_Grup_2)) / contor_valori_pozitive_Sebesel_1;
                double suma_sebesel_1_prev = (date_putere_anterior.Sum(x => x.Sebesel_1_Grup_1) + date_putere_anterior.Sum(x => x.Sebesel_1_Grup_2)) / contor_valori_pozitive_Sebesel_1_prev;


                double suma_sebesel_2 = (date_putere.Sum(x => x.Sebesel_2_Grup_1) + date_putere.Sum(x => x.Sebesel_2_Grup_2)) / contor_valori_pozitive_Sebesel_2;
                double suma_sebesel_2_prev = (date_putere_anterior.Sum(x => x.Sebesel_2_Grup_1) + date_putere_anterior.Sum(x => x.Sebesel_2_Grup_2)) / contor_valori_pozitive_Sebesel_2_prev;


                double suma_cornereva = (date_putere.Sum(x => x.Cornereva) + date_putere.Sum(x => x.Cornereva)) / contor_valori_pozitive_Cornereva;
                double suma_cornereva_prev = (date_putere_anterior.Sum(x => x.Cornereva) + date_putere_anterior.Sum(x => x.Cornereva)) / contor_valori_pozitive_Cornereva_prev;


                double factor_corectie_cuntu = Math.Round(suma_cuntu / suma_cuntu_prev, 2);
                double factor_corectie_craiu_1 = Math.Round((date_putere.Sum(x => x.Craiu_1_Grup_1) + date_putere.Sum(x => x.Craiu_1_Grup_2)) / (date_putere_anterior.Sum(x => x.Craiu_1_Grup_1) + date_putere_anterior.Sum(x => x.Craiu_1_Grup_2)), 2);
                double factor_corectie_craiu_2 = Math.Round((date_putere.Sum(x => x.Craiu_2_Grup_1) + date_putere.Sum(x => x.Craiu_2_Grup_2)) / (date_putere_anterior.Sum(x => x.Craiu_2_Grup_1) + date_putere_anterior.Sum(x => x.Craiu_2_Grup_2)), 2);
                double factor_corectie_sebesel_1 = Math.Round((date_putere.Sum(x => x.Sebesel_1_Grup_1) + date_putere.Sum(x => x.Sebesel_1_Grup_2)) / (date_putere_anterior.Sum(x => x.Sebesel_1_Grup_1) + date_putere_anterior.Sum(x => x.Sebesel_1_Grup_2)), 2);
                double factor_corectie_sebesel_2 = Math.Round((date_putere.Sum(x => x.Sebesel_2_Grup_1) + date_putere.Sum(x => x.Sebesel_2_Grup_2)) / (date_putere_anterior.Sum(x => x.Sebesel_2_Grup_1) + date_putere_anterior.Sum(x => x.Sebesel_2_Grup_2)), 2);
                double factor_corectie_cornereva = Math.Round((date_putere.Sum(x => x.Cornereva)) / (date_putere_anterior.Sum(x => x.Cornereva)), 2);


                if (factor_corectie_cuntu < 0.8 || Double.IsNaN(factor_corectie_cuntu)) factor_corectie_cuntu = 0.8;
                if (factor_corectie_cuntu > 1.2) factor_corectie_cuntu = 1.2;
                if (factor_corectie_craiu_1 < 0.8 || Double.IsNaN(factor_corectie_craiu_1)) factor_corectie_craiu_1 = 0.8;
                if (factor_corectie_craiu_1 > 1.2) factor_corectie_craiu_1 = 1.2;
                if (factor_corectie_craiu_2 < 0.8 || Double.IsNaN(factor_corectie_craiu_2)) factor_corectie_craiu_2 = 0.8;
                if (factor_corectie_craiu_2 > 1.2) factor_corectie_craiu_2 = 1.2;
                if (factor_corectie_sebesel_1 < 0.8 || Double.IsNaN(factor_corectie_sebesel_1)) factor_corectie_sebesel_1 = 0.8;
                if (factor_corectie_sebesel_1 > 1.2) factor_corectie_sebesel_1 = 1.2;
                if (factor_corectie_sebesel_2 < 0.8 || Double.IsNaN(factor_corectie_sebesel_2)) factor_corectie_sebesel_2 = 0.8;
                if (factor_corectie_sebesel_2 > 1.2) factor_corectie_sebesel_2 = 1.2;
                if (factor_corectie_cornereva < 0.8 || Double.IsNaN(factor_corectie_cornereva)) factor_corectie_cornereva = 0.8;
                if (factor_corectie_cornereva > 1.2) factor_corectie_cornereva = 1.2;





                for (int i = 0; i < 96; i++)
                {
                    date_putere_prognoza.Add(new DatePutere
                    {
                        Date_Time = newCalendar1.SelectionStart.AddDays(1).AddMinutes(15 * i),
                        Cuntu_Grup_1 = Math.Round(((date_putere.Sum(x => x.Cuntu_Grup_1) + date_putere.Sum(x => x.Cuntu_Grup_2)) / contor_valori_pozitive_cuntu) * factor_corectie_cuntu * Convert.ToDouble(tbfactorCuntu.Text), 2),

                        Craiu_1_Grup_1 = Math.Round(((date_putere.Sum(x => x.Craiu_1_Grup_1) + date_putere.Sum(x => x.Craiu_1_Grup_2)) / contor_valori_pozitive_craiu_1) * factor_corectie_craiu_1 * Convert.ToDouble(tbfactorCraiu1.Text), 2),

                        Craiu_2_Grup_1 = Math.Round(((date_putere.Sum(x => x.Craiu_2_Grup_1) + date_putere.Sum(x => x.Craiu_2_Grup_2)) / contor_valori_pozitive_craiu_2) * factor_corectie_craiu_2 * Convert.ToDouble(tbfactorCraiu2.Text), 2),

                        Sebesel_1_Grup_1 = Math.Round(((date_putere.Sum(x => x.Sebesel_1_Grup_1) + date_putere.Sum(x => x.Sebesel_1_Grup_2)) / contor_valori_pozitive_Sebesel_1) * factor_corectie_sebesel_1 * Convert.ToDouble(tbfactorSebesel1.Text), 2),

                        Sebesel_2_Grup_1 = Math.Round(((date_putere.Sum(x => x.Sebesel_2_Grup_1) + date_putere.Sum(x => x.Sebesel_2_Grup_2)) / contor_valori_pozitive_Sebesel_2) * factor_corectie_sebesel_2 * Convert.ToDouble(tbfactorSebesel2.Text), 2),

                        Cornereva = Math.Round(((date_putere.Sum(x => x.Cornereva)) / contor_valori_pozitive_Cornereva) * factor_corectie_cornereva * Convert.ToDouble(tbfactorCornereva.Text), 2)
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

                dataGridView1.DataSource = date_putere;



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
                file.WriteLine("Data,Timp,Cuntu,Craiu 1,Craiu 2,Sebesel 1,Sebesel 2,Cornereva");
                foreach (var arr in date_putere_prognoza)
                {
                    file.WriteLine(string.Join(",", arr.FullString));
                }
            }
        }
    }
}
