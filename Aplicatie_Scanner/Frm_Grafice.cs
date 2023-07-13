using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using System.Collections.ObjectModel;

namespace Azel_Raportare_Balkani
{
    public partial class Frm_Grafice : Form
    {
        public ObservableCollection<ObservablePoint>[] ChartValues = new ObservableCollection<ObservablePoint>[11];

        public ObservableCollection<ISeries> seriesCollection = new ObservableCollection<ISeries>();

        List<DatePutere> date_putere = new List<DatePutere>();
        List<DatePutere> date_putere_ora = new List<DatePutere>();
        public Frm_Grafice()
        {
            InitializeComponent();


            ///////////////////////////////////////ZONA ASIGNARE PROPRIETATI CHART////////////////////////////////////////////////
            cartesianChart1.LegendPosition = LiveChartsCore.Measure.LegendPosition.Left;
            cartesianChart1.LegendTextSize = 16;
            cartesianChart1.LegendTextPaint = new SolidColorPaint(SKColors.White);
            cartesianChart1.ZoomMode = LiveChartsCore.Measure.ZoomAndPanMode.X;

            cartesianChart1.Series = seriesCollection;

            cartesianChart1.YAxes = new Axis[]
{
    new Axis
    {
        Name = "Putere",
        NamePaint = new SolidColorPaint(SKColors.White),
        MinStep = 10,
        ForceStepToMin = true,
        LabelsPaint = new SolidColorPaint(SKColors.White),
        TextSize = 10,


    }
};

            //////////////////////////////////////////////////////////////////////////////////////////////////////
        }
        private void Initialize_Lists()
        {
            for (int i = 0; i <= 10; i++)
            {
                ChartValues[i] = new ObservableCollection<ObservablePoint>();
            }

        }
        private async void Frm_Grafice_Load(object sender, EventArgs e)
        {
            Initialize_Lists();
        }
        private void Cautare_Date()
        {
            try
            {

                DataAccess db = new DataAccess();

                if (rbEnergie.Checked)
                {
                    int index = 0;
                    date_putere = db.GetDateEnergie(newCalendar1.SelectionStart, newCalendar1.SelectionEnd);
                    date_putere_ora.Clear();
                    if (cbEnergieOra.Checked)
                    {
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
                        update_chart(date_putere_ora);
                    }
                    else
                    {
                        update_chart(date_putere);
                    }

                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private async void timer1_Tick(object sender, EventArgs e)
        {

        }
        private void update_chart(List<DatePutere> date)
        {

            seriesCollection.Clear();
            for (int i = 0; i <= 10; i++)
            {
                ChartValues[i].Clear();
                foreach (var item in date.Take(10))
                {
                    switch (i)
                    {
                        case 0:
                            ChartValues[i].Add(new ObservablePoint(item.Date_Time.Ticks, item.Cuntu_Grup_1));
                            break;
                        case 1:
                            ChartValues[i].Add(new ObservablePoint(item.Date_Time.Ticks, item.Cuntu_Grup_2));
                            break;
                        case 2:
                            ChartValues[i].Add(new ObservablePoint(item.Date_Time.Ticks, item.Craiu_1_Grup_1));
                            break;
                        case 3:
                            ChartValues[i].Add(new ObservablePoint(item.Date_Time.Ticks, item.Craiu_1_Grup_2));
                            break;
                        case 4:
                            ChartValues[i].Add(new ObservablePoint(item.Date_Time.Ticks, item.Craiu_2_Grup_1));
                            break;
                        case 5:
                            ChartValues[i].Add(new ObservablePoint(item.Date_Time.Ticks, item.Craiu_2_Grup_2));
                            break;
                        case 6:
                            ChartValues[i].Add(new ObservablePoint(item.Date_Time.Ticks, item.Sebesel_1_Grup_1));
                            break;
                        case 7:
                            ChartValues[i].Add(new ObservablePoint(item.Date_Time.Ticks, item.Sebesel_1_Grup_2));
                            break;
                        case 8:
                            ChartValues[i].Add(new ObservablePoint(item.Date_Time.Ticks, item.Sebesel_2_Grup_1));
                            break;
                        case 9:
                            ChartValues[i].Add(new ObservablePoint(item.Date_Time.Ticks, item.Sebesel_2_Grup_2));
                            break;
                        case 10:
                            ChartValues[i].Add(new ObservablePoint(item.Date_Time.Ticks, item.Cornereva));
                            break;

                    }

                }
                seriesCollection.Add(new ColumnSeries<ObservablePoint> { Name = i.ToString(), Values = ChartValues[i], });
                
               
            }
            seriesCollection[0].Name = "Cuntu Grup 1";
            seriesCollection[1].Name = "Cuntu Grup 2";
            seriesCollection[2].Name = "Craiu 1 Grup 1";
            seriesCollection[3].Name = "Craiu 1 Grup 2";
            seriesCollection[4].Name = "Craiu 2 Grup 1";
            seriesCollection[5].Name = "Craiu 2 Grup 2";
            seriesCollection[6].Name = "Sebesel 1 Grup 1";
            seriesCollection[7].Name = "Sebesel 1 Grup 2";
            seriesCollection[8].Name = "Sebesel 2 Grup 1";
            seriesCollection[9].Name = "Sebesel 2 Grup 2";
            seriesCollection[10].Name = "Cornereva";

            int timespanaxis = 0;
            if (cbEnergieOra.Checked) timespanaxis = 60; else { timespanaxis = 15; }
            try
            {
                cartesianChart1.XAxes = new Axis[]
            {
    new Axis
    {
        Name = "Timp",
        NamePaint = new SolidColorPaint(SKColors.White),
        MinStep = TimeSpan.FromMinutes(timespanaxis).Ticks,
        ForceStepToMin = true,
        UnitWidth =TimeSpan.FromMinutes(timespanaxis).Ticks,
        LabelsPaint = new SolidColorPaint(SKColors.White),
        Labeler = val => new DateTime((long)val).ToString("HH:mm"),
        TextSize = 10,


    }
            };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            cartesianChart1.Series = seriesCollection;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Cuntu_Grup_2_pbX_Click(object sender, EventArgs e)
        {

        }

        private void cartesianChart1_Load(object sender, EventArgs e)
        {

        }

        private void newCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void Search_Click(object sender, EventArgs e)
        {
            Cautare_Date();
        }

        private void rbPutere_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbEnergie_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbCuntu_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCuntu.Checked)
            {
                seriesCollection[0].IsVisible = true;
                seriesCollection[1].IsVisible = true;
            }
            else
            {
                seriesCollection[0].IsVisible = false;
                seriesCollection[1].IsVisible = false;
            }

        }

        private void cbCraiu1_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCraiu1.Checked)
            {
                seriesCollection[2].IsVisible = true;
                seriesCollection[3].IsVisible = true;
            }
            else
            {
                seriesCollection[2].IsVisible = false;
                seriesCollection[3].IsVisible = false;
            }

        }

        private void cbCraiu2_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCraiu2.Checked)
            {
                seriesCollection[4].IsVisible = true;
                seriesCollection[5].IsVisible = true;
            }
            else
            {
                seriesCollection[4].IsVisible = false;
                seriesCollection[5].IsVisible = false;
            }
        }

        private void cbSebesel1_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSebesel1.Checked)
            {
                seriesCollection[6].IsVisible = true;
                seriesCollection[7].IsVisible = true;
            }
            else
            {
                seriesCollection[6].IsVisible = false;
                seriesCollection[7].IsVisible = false;
            }
        }

        private void cbSebesel2_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSebesel2.Checked)
            {
                seriesCollection[8].IsVisible = true;
                seriesCollection[9].IsVisible = true;
            }
            else
            {
                seriesCollection[8].IsVisible = false;
                seriesCollection[9].IsVisible = false;
            }
        }

        private void cbCornereva_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCornereva.Checked)
            {
                seriesCollection[10].IsVisible = true;

            }
            else
            {
                seriesCollection[10].IsVisible = false;

            }
        }
    }
}
