using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;
using ZXing.Windows.Compatibility;

namespace Aplicatie_Scanner
{
    public partial class Frm_Dashboard : Form
    {
        public Frm_Dashboard()
        {
            InitializeComponent();
        }

        List<DateDB> date = new List<DateDB>();




        private void Frm_Dashboard_Load(object sender, EventArgs e)
        {

        }


        private void Frm_Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {


        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void Search_Click(object sender, EventArgs e)
        {
            try
            {

                DataAccess db = new DataAccess();
                date = db.GetDateToataZiua(newCalendar1.SelectionStart, newCalendar1.SelectionEnd);

                UpdateBinding();
            }
            catch
            {

            }
        }

        private void UpdateBinding()
        {


            try
            {
                dataGridView1.AutoGenerateColumns = false;



                
                dataGridView1.DataSource = date;



                dataGridView1.Columns["Data"].DataPropertyName = "DoarData";
                dataGridView1.Columns["Timp"].DataPropertyName = "DoarTimp";
                dataGridView1.Columns["Barcode"].DataPropertyName = "Furnizor";
                dataGridView1.Columns["Cantitate"].DataPropertyName = "Calitate";





            }
            catch
            {

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
