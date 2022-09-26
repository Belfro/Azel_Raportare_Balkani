using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xamarin.Forms;

namespace Aplicatie_Scanner
{
    public partial class Frm_Settings : Form
    {

      
        List<DateFurnizori> furnizoriList = new List<DateFurnizori>();
        public Frm_Settings()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void Frm_Settings_Load(object sender, EventArgs e)
        {
            
        }

        public async Task LoadDatePrinter()
        {

            DataAccess db = new DataAccess();
            Task<List<DateFurnizori>> task_furnizori = db.GetDateFurnizori();

            furnizoriList = await task_furnizori;


            await Task.WhenAll(task_furnizori);
        }
        private void AdaugaIntrari(String TextIntrodus)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("ConnStr")))
            {
                try
                {
                    string Data = $"{DateTime.Now.Day.ToString("D2")}-{DateTime.Now.Month.ToString("D2")}-{DateTime.Now.Date.ToString("yy")}";

                    string Timp = $"{DateTime.Now.Hour.ToString("D2")}:{DateTime.Now.Minute.ToString("D2")}:{DateTime.Now.Second.ToString("D2")}";

                    string Datatimp =
                        $"convert(datetime,'{Data} {Timp}',5)";
                    connection.Open();
                    var cmd = connection.CreateCommand();

                    cmd.CommandText = $"Insert INTO Furnizori (Denumire) VALUES ('{TextIntrodus}')";
                    cmd.CommandTimeout = 15;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    
                    connection.Close();
                   
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex.Message);
                }


            }
        }
      
       
        private void Btn_Add_Furnizor_Click(object sender, EventArgs e)
        {
            if (tbFurnizori.Text != "")
            {
                AdaugaIntrari(tbFurnizori.Text);
               
            }

            else
            {
                MessageBox.Show("Introduceti nume furnizor!");
            }
            
        }
        private async void timer1_Tick(object sender, EventArgs e)
        {


            
            try
            {

                await Task.Run(async () => LoadDatePrinter());





                if (furnizoriList != null)
                {
                    if (dataGridView1.RowCount != furnizoriList.Count)
                    {
                        dataGridView1.AutoGenerateColumns = false;
                        dataGridView1.DataSource = furnizoriList;
                        dataGridView1.Columns["Nume_Furnizor"].DataPropertyName = "Denumire";
                    }

                }
               
                {

                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);


            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDeleteFurnizor_Click(object sender, EventArgs e)
        {
            string? Valoare_Selectata = null;
            try
            {
                if (furnizoriList.Count > 0)
                {
                   Valoare_Selectata = dataGridView1.CurrentCell.Value.ToString();
                }
                else MessageBox.Show("Nu ati selectat niciun furnizor!");



                if (Valoare_Selectata != null)
            {
                DialogResult dialogResult = MessageBox.Show($"Sunteti sigur ca doriti sa stergeti furnizorul {dataGridView1.CurrentCell.Value}", "Stergere Furnizor", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    using (IDbConnection connection = new SqlConnection(Helper.CnnVal("ConnStr")))
                    {
                        try
                        {
                            connection.Open();
                            var cmd = connection.CreateCommand();

                            cmd.CommandText = $"Delete From Furnizori WHERE Denumire = '{dataGridView1.CurrentCell.Value.ToString()}'";
                            cmd.CommandTimeout = 15;
                            cmd.CommandType = CommandType.Text;
                            cmd.ExecuteNonQuery();

                            connection.Close();
                                MessageBox.Show("Stergere Confirmata.");
                            }

                        catch (Exception ex)
                        {
                            MessageBox.Show("Error:" + ex.Message);
                        }


                    }

                }
                else if (dialogResult == DialogResult.No)
                {

                }

            }
            }
            catch
            {
               
            }



        }

    }
}
