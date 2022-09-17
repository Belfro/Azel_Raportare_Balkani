using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
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
        }

        private void Frm_Settings_Load(object sender, EventArgs e)
        {

        }
        private void AdaugaIntrari(String TextIntrodus)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("ConnStr")))
            {
                try
                {
                    connection.Open();
                    var cmd = connection.CreateCommand();

                    cmd.CommandText = $"Insert INTO Furnizori VALUES ({TextIntrodus}";
                    cmd.CommandTimeout = 15;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    
                    connection.Close();
                    UpdateBinding();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex.Message);
                }


            }
        }
        private void UpdateBinding()
        {

            try
            {
                using (IDbConnection connection = new SqlConnection(Helper.CnnVal("ConnStr")))
                {
                    var output = connection.Query<DateFurnizori>($"SELECT Denumire FROM Furnizori ORDER BY Data_Timp").ToList();
                }
            }
            catch (Exception ex)
            {

            }

            try
            {
                dataGridView1.AutoGenerateColumns = false;




                dataGridView1.DataSource = furnizoriList;



                dataGridView1.Columns["Nume_Furnizor"].DataPropertyName = "Denumire";
                




            }
            catch
            {

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
