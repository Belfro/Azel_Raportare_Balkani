using AForge.Video;
using AForge.Video.DirectShow;
using Dapper;
using SixLabors.ImageSharp.ColorSpaces;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using ZXing;
using ZXing.Windows.Compatibility;

namespace Aplicatie_Scanner
{
    public partial class Frm_Dashboard : Form
    {
        List<DateFurnizori> furnizoriList = new List<DateFurnizori>();
        List<DateCalitate> CalitateList = new List<DateCalitate>();
        public Frm_Dashboard()
        {
            InitializeComponent();
        }

        List<DateDB> date = new List<DateDB>();




        private void Frm_Dashboard_Load(object sender, EventArgs e)
        {
            cbZonaSelectie.SelectedIndex = 0;
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
            bool Prima_Conditie_Selectata = false;
            string Conditii_Get_Date = "";
            if (checkBoxCalitate.Checked || checkBoxFurnizor.Checked)
            { Conditii_Get_Date = "WHERE"; }

            if (checkBoxFurnizor.Checked)
            {
                if (!Prima_Conditie_Selectata)
                {
                    Conditii_Get_Date = Conditii_Get_Date + $" Furnizor = '{cbFurnizor.SelectedItem.ToString()}'";
                    Prima_Conditie_Selectata=true;
                }
                
            }

            if (checkBoxCalitate.Checked)
            {
                if (!Prima_Conditie_Selectata)
                {
                    Conditii_Get_Date = Conditii_Get_Date + $" Calitate = '{cbCalitate.SelectedItem.ToString()}'";
                    Prima_Conditie_Selectata = true;
                }
                else
                Conditii_Get_Date = Conditii_Get_Date + $" AND Calitate = '{cbCalitate.SelectedItem.ToString()}'";
            }
            
            try
            {
               
                DataAccess db = new DataAccess();
                date = db.GetDateToataZiua(newCalendar1.SelectionStart, newCalendar1.SelectionEnd,Conditii_Get_Date,cbZonaSelectie.SelectedItem.ToString().Replace(" ","_"));

                UpdateBinding();
                if (date.Count < 1) MessageBox.Show("Nu a fost gasit niciun produs !");
                else btnPrintCSV.Visible = true;
                    
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
                dataGridView1.Columns["Locatie_Actuala"].DataPropertyName = "Locatie_Actuala";
                dataGridView1.Columns["Furnizor"].DataPropertyName = "Furnizor";
                dataGridView1.Columns["Numar_Aviz"].DataPropertyName = "Numar_Aviz";
                dataGridView1.Columns["Numar_Bucati"].DataPropertyName = "Numar_Bucati";
                dataGridView1.Columns["Numar_Receptie"].DataPropertyName = "Numar_Receptie";
                dataGridView1.Columns["Lungime"].DataPropertyName = "Lungime";
                dataGridView1.Columns["Diametru"].DataPropertyName = "Diametru";
                dataGridView1.Columns["Calitate"].DataPropertyName = "Calitate";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); 
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkBoxFurnizor_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxFurnizor.Checked)
            {
                cbFurnizor.Visible = true;
                try
                {
                    using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("ConnStr")))
                    {
                        furnizoriList = connection.Query<DateFurnizori>($"select * from Furnizori").ToList();
                    }
                    cbFurnizor.Items.Clear();
                    foreach (DateFurnizori Date in furnizoriList)
                    {
                        cbFurnizor.Items.Add(Date.Denumire);
                    }
                    cbFurnizor.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);     
                }
            }
            if (!checkBoxFurnizor.Checked)
                cbFurnizor.Visible = false;
        }

        private void checkBoxCalitate_CheckedChanged(object sender, EventArgs e)
        {
            cbCalitate.Visible = true;
            try
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("ConnStr")))
                {
                    CalitateList = connection.Query<DateCalitate>($"select * from Calitate").ToList();
                }
                cbCalitate.Items.Clear();
                foreach (DateCalitate Date in CalitateList)
                {
                    cbCalitate.Items.Add(Date.Calitate);
                }
                cbCalitate.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            } 
            if (!checkBoxCalitate.Checked)
                cbCalitate.Visible = false;
        }

        private void cbZonaSelectie_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnPrintCSV_Click(object sender, EventArgs e)
        {
            string subPath = @$"C:\Azel\Raportari Romply\"; 

            bool exists = System.IO.Directory.Exists(subPath);

            if (!exists)
                System.IO.Directory.CreateDirectory(subPath);
            using (StreamWriter file = File.CreateText(@$"C:\Azel\Raportari Romply\Raport_Aplicatie_{DateTime.Now.ToString("yyyy-MM-dd_HH-mm")}.csv"))
            {
                foreach (var arr in date)
                {
                    file.WriteLine(string.Join(",", arr.FullString));
                }
            }
        }
    }
}
