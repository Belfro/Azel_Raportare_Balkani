
using System.Media;

namespace Azel_Raportare_Balkani
{
    public partial class Frm_Prognoza : Form
    {
        List<DatePutere> date_putere = new List<DatePutere>();

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


                int index = 0;
                date_putere = db.GetDateEnergie(newCalendar1.SelectionStart, newCalendar1.SelectionStart.AddDays(1).AddTicks(-1));


                List<DatePutere> date_putere_prognoza = new List<DatePutere>(date_putere.Count);
                date_putere.ForEach((item) =>
                {
                    date_putere_prognoza.Add((DatePutere)item.Clone());
                });
                UpdateBinding();




                for (int i = 0; i < date_putere.Count; i++)
                {
                    date_putere_prognoza[i].Date_Time = date_putere_prognoza[i].Date_Time.AddDays(1);
                    date_putere_prognoza[i].Cuntu_Grup_1 = 0.9 * date_putere_prognoza[i].Cuntu_Grup_1;
                    date_putere_prognoza[i].Cuntu_Grup_2 = 0.9 * date_putere_prognoza[i].Cuntu_Grup_1;
                    date_putere_prognoza[i].Craiu_1_Grup_1 = 0.9 * date_putere_prognoza[i].Craiu_1_Grup_1;
                    date_putere_prognoza[i].Craiu_1_Grup_2 = 0.9 * date_putere_prognoza[i].Craiu_1_Grup_2;
                    date_putere_prognoza[i].Craiu_2_Grup_1 = 0.9 * date_putere_prognoza[i].Craiu_2_Grup_1;
                    date_putere_prognoza[i].Craiu_2_Grup_2 = 0.9 * date_putere_prognoza[i].Craiu_2_Grup_2;
                    date_putere_prognoza[i].Sebesel_1_Grup_1 = 0.9 * date_putere_prognoza[i].Sebesel_1_Grup_1;
                    date_putere_prognoza[i].Sebesel_1_Grup_2 = 0.9 * date_putere_prognoza[i].Sebesel_1_Grup_2;
                    date_putere_prognoza[i].Sebesel_2_Grup_1 = 0.9 * date_putere_prognoza[i].Sebesel_2_Grup_1;
                    date_putere_prognoza[i].Sebesel_2_Grup_2 = 0.9 * date_putere_prognoza[i].Sebesel_2_Grup_2;
                    date_putere_prognoza[i].Cornereva = 0.9 * date_putere_prognoza[i].Cornereva;
                }



                dataGridView2.AutoGenerateColumns = false;
                dataGridView2.Columns[0].DataPropertyName = "DoarData";
                dataGridView2.Columns[1].DataPropertyName = "DoarTimp";
                dataGridView2.Columns[2].DataPropertyName = "Cuntu_Grup_1";
                dataGridView2.Columns[3].DataPropertyName = "Cuntu_Grup_2";
                dataGridView2.Columns[4].DataPropertyName = "Craiu_1_Grup_1";
                dataGridView2.Columns[5].DataPropertyName = "Craiu_1_Grup_2";
                dataGridView2.Columns[6].DataPropertyName = "Craiu_2_Grup_1";
                dataGridView2.Columns[7].DataPropertyName = "Craiu_2_Grup_2";
                dataGridView2.Columns[8].DataPropertyName = "Sebesel_1_Grup_1";
                dataGridView2.Columns[9].DataPropertyName = "Sebesel_1_Grup_2";
                dataGridView2.Columns[10].DataPropertyName = "Sebesel_2_Grup_1";
                dataGridView2.Columns[11].DataPropertyName = "Sebesel_2_Grup_2";
                dataGridView2.Columns[12].DataPropertyName = "Cornereva";
                dataGridView2.Columns[13].DataPropertyName = "Total";
                dataGridView2.DataSource = date_putere_prognoza;

            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.ToString());
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
    }
}
