
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
               /* date_putere[1] = db.GetDateEnergie(newCalendar1.SelectionStart.AddDays(-1), newCalendar1.SelectionStart.AddDays(0).AddTicks(-1));
                date_putere[2] = db.GetDateEnergie(newCalendar1.SelectionStart.AddDays(-2), newCalendar1.SelectionStart.AddDays(-1).AddTicks(-1));
                date_putere[3] = db.GetDateEnergie(newCalendar1.SelectionStart.AddDays(-3), newCalendar1.SelectionStart.AddDays(-2).AddTicks(-1));
                date_putere[4] = db.GetDateEnergie(newCalendar1.SelectionStart.AddDays(-4), newCalendar1.SelectionStart.AddDays(-3).AddTicks(-1));
                date_putere[5] = db.GetDateEnergie(newCalendar1.SelectionStart.AddDays(-5), newCalendar1.SelectionStart.AddDays(-4).AddTicks(-1));
                date_putere[6] = db.GetDateEnergie(newCalendar1.SelectionStart.AddDays(-6), newCalendar1.SelectionStart.AddDays(-5).AddTicks(-1));*/

               



                List<DatePutere> date_putere_prognoza = new List<DatePutere>(date_putere.Count);

                  date_putere.ForEach((item) =>
                  {
                      date_putere_prognoza.Add((DatePutere)item.Clone());
                  });
               /* var prognoza = ForecastElectricity(date_putere, 96);
                for (int i = 0; i < 24; i++)
                {

                    date_putere_prognoza[i].Craiu_2_Grup_1 = prognoza[i];
                }
                */

               



               


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

                

                UpdateBinding();
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

        public double[] ForecastElectricity(List<DatePutere>[] historicalData, int forecastHorizon)
        {
            if (historicalData == null || !historicalData.Any() || forecastHorizon <= 0)
            {
                throw new ArgumentException("Invalid input data or forecast horizon.");
            }



            // Convert historical data to an array
            double[] data = historicalData[0].Select(x=>x.Craiu_2_Grup_1).ToArray();

            // Calculate the average seasonality over the last week (7 days)
            double averageSeasonality = CalculateAverageSeasonality(data, 7);

            // Calculate the Holt-Winters parameters
            double alpha = 1; // Smoothing factor
            double beta = 1;  // Trend factor
            double gamma = 1; // Seasonality factor

            int dataLength = data.Length;
            double[] level = new double[dataLength];
            double[] trend = new double[dataLength];
            double[] seasonal = new double[dataLength + forecastHorizon];

            // Initialize level, trend, and seasonal components
            level[0] = 1;
            trend[0] = 0;

            for (int i = 0; i < 7; i++)
            {
                seasonal[i] = data[i] / averageSeasonality;
            }

            // Forecast using Holt-Winters method
            for (int i = 0; i < dataLength-1; i++)
            {

                level[i + 1] = alpha * data[i] / seasonal[i] + (1 - alpha) * (level[i] + trend[i]);
                trend[i + 1] = beta * (level[i + 1] - level[i]) + (1 - beta) * trend[i];
                seasonal[i + 7] = gamma * data[i] / level[i + 1] + (1 - gamma) * seasonal[i];
            }

            // Generate forecasts for the next day
            double[] forecasts = new double[forecastHorizon];
            for (int i = 0; i < forecastHorizon-1; i++)
            {
                int dataIndex = i;
                if (dataIndex < data.Length)
                {
                    int seasonIndex = dataIndex % 7;

                    forecasts[i] = (level[dataIndex] + i * trend[dataIndex]) * seasonal[seasonIndex];
                }
                else
                {
                    // Handle the case where you run out of historical data.
                    // You can either stop forecasting or use a default value.
                    forecasts[i] = 0.0; // Default value, adjust as needed.
                }
            }

            return forecasts;
        }

        private double CalculateAverageSeasonality(double[] data, int days)
        {
            if (data.Length < days)
            {
                return 1.0; // Return a default value for seasonality
            }

            double sum = 0;
            for (int i = 0; i < days; i++)
            {
                sum += data[i] / data[i % 7];
            }

            return sum / days;
        }
    }
}
