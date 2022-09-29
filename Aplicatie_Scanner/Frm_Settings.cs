using Dapper;
using System;
using System.Collections;
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
        List<DateCalitate> calitateList = new List<DateCalitate>();
        List<DateLungime> lungimeList = new List<DateLungime>();
        public Frm_Settings()
        {
            InitializeComponent();
        
            timer1.Start();
        }

        private async void Frm_Settings_Load(object sender, EventArgs e)
        {
            try
            {

                await Task.Run(async () => LoadDatePrinter());





                if (furnizoriList != null)
                {
                    if (dataGridViewFurnizori.RowCount != furnizoriList.Count)
                    {
                        dataGridViewFurnizori.AutoGenerateColumns = false;
                        dataGridViewFurnizori.DataSource = furnizoriList;
                        dataGridViewFurnizori.Columns["Nume_Furnizor"].DataPropertyName = "Denumire";
                    }

                }
                if (calitateList != null)
                {
                    if (dataGridViewCalitate.RowCount != calitateList.Count)
                    {
                        dataGridViewCalitate.AutoGenerateColumns = false;
                        dataGridViewCalitate.DataSource = calitateList;
                        dataGridViewCalitate.Columns["Calitate"].DataPropertyName = "Calitate";
                    }

                }
                if (lungimeList != null)
                {
                    if (dataGridViewLungime.RowCount != lungimeList.Count)
                    {
                        dataGridViewLungime.AutoGenerateColumns = false;
                        dataGridViewLungime.DataSource = lungimeList;
                        dataGridViewLungime.Columns["lungime"].DataPropertyName = "lungime";
                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);


            }
        }

        public async Task LoadDatePrinter()
        {

            DataAccess db = new DataAccess();
            Task<List<DateFurnizori>> task_furnizori = db.GetDateFurnizori();
            Task<List<DateCalitate>> task_calitate = db.GetDateCalitate();
            Task<List<DateLungime>> task_lungime = db.GetDateLungime();

            furnizoriList = await task_furnizori;
            calitateList = await task_calitate;
            lungimeList = await task_lungime;


            await Task.WhenAll(task_furnizori,task_calitate,task_lungime);
        }
        private void AdaugaIntrariFurnizori(String TextIntrodus)
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
        private void AdaugaIntrariCalitate(String TextIntrodus)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("ConnStr")))
            {
                try
                {
                    
                    connection.Open();
                    var cmd = connection.CreateCommand();

                    cmd.CommandText = $"Insert INTO Calitate (Calitate) VALUES ('{TextIntrodus}')";
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
        private void AdaugaIntrariLungime(String TextIntrodus)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("ConnStr")))
            {
                try
                {

                    connection.Open();
                    var cmd = connection.CreateCommand();

                    cmd.CommandText = $"Insert INTO Lungimi (Lungime) VALUES ('{TextIntrodus}')";
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
                AdaugaIntrariFurnizori(tbFurnizori.Text);
               
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
                    if (dataGridViewFurnizori.RowCount != furnizoriList.Count)
                    {
                        dataGridViewFurnizori.AutoGenerateColumns = false;
                        dataGridViewFurnizori.DataSource = furnizoriList;
                        dataGridViewFurnizori.Columns["Nume_Furnizor"].DataPropertyName = "Denumire";
                    }

                }


                if (calitateList != null)
                {
                    if (dataGridViewCalitate.RowCount != calitateList.Count)
                    {
                        dataGridViewCalitate.AutoGenerateColumns = false;
                        dataGridViewCalitate.DataSource = calitateList;
                        dataGridViewCalitate.Columns["Calitate"].DataPropertyName = "Calitate";
                    }

                }
                if (lungimeList != null)
                {
                   
                    if (dataGridViewLungime.RowCount != lungimeList.Count)
                    {
                        dataGridViewLungime.AutoGenerateColumns = false;
                        dataGridViewLungime.DataSource = lungimeList;
                        dataGridViewLungime.Columns["Lungime"].DataPropertyName = "Lungime";
                    }

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
                   Valoare_Selectata = dataGridViewFurnizori.CurrentCell.Value.ToString();
                }
                else MessageBox.Show("Nu ati selectat niciun furnizor!");



                if (Valoare_Selectata != null)
            {
                DialogResult dialogResult = MessageBox.Show($"Sunteti sigur ca doriti sa stergeti furnizorul {dataGridViewFurnizori.CurrentCell.Value}", "Stergere Furnizor", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    using (IDbConnection connection = new SqlConnection(Helper.CnnVal("ConnStr")))
                    {
                        try
                        {
                            connection.Open();
                            var cmd = connection.CreateCommand();

                            cmd.CommandText = $"Delete From Furnizori WHERE Denumire = '{dataGridViewFurnizori.CurrentCell.Value.ToString()}'";
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

        private void Btn_Add_Calitate_Click(object sender, EventArgs e)
        {
            if (tbCalitate.Text != "")
            {
                AdaugaIntrariCalitate(tbCalitate.Text);

            }

            else
            {
                MessageBox.Show("Introduceti Calitate!");
            }
        }

        private void btnDeleteCalitate_Click(object sender, EventArgs e)
        {
            string? Valoare_Selectata = null;
            try
            {
                if (calitateList.Count > 0)
                {
                    Valoare_Selectata = dataGridViewCalitate.CurrentCell.Value.ToString();
                }
                else MessageBox.Show("Nu ati selectat nicio calitate!");



                if (Valoare_Selectata != null)
                {
                    DialogResult dialogResult = MessageBox.Show($"Sunteti sigur ca doriti sa stergeti calitatea {dataGridViewCalitate.CurrentCell.Value}", "Stergere Furnizor", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        using (IDbConnection connection = new SqlConnection(Helper.CnnVal("ConnStr")))
                        {
                            try
                            {
                                connection.Open();
                                var cmd = connection.CreateCommand();

                                cmd.CommandText = $"Delete From Calitate WHERE Calitate = '{dataGridViewCalitate.CurrentCell.Value.ToString()}'";
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

        private void Btn_Add_Lungimi_Click(object sender, EventArgs e)
        {
            if (tbLungimi.Text != "")
            {
                AdaugaIntrariLungime(tbLungimi.Text);

            }

            else
            {
                MessageBox.Show("Introduceti Lungime!");
            }
        }

        private void btnDeleteLungime_Click(object sender, EventArgs e)
        {
            string? Valoare_Selectata = null;
            try
            {
                if (lungimeList.Count > 0)
                {
                    Valoare_Selectata = dataGridViewLungime.CurrentCell.Value.ToString();
                }
                else MessageBox.Show("Nu ati selectat nicio lungime!");



                if (Valoare_Selectata != null)
                {
                    DialogResult dialogResult = MessageBox.Show($"Sunteti sigur ca doriti sa stergeti lungimea {dataGridViewLungime.CurrentCell.Value}", "Stergere Furnizor", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        using (IDbConnection connection = new SqlConnection(Helper.CnnVal("ConnStr")))
                        {
                            try
                            {
                                connection.Open();
                                var cmd = connection.CreateCommand();

                                cmd.CommandText = $"Delete From Lungimi WHERE Lungime = '{dataGridViewLungime.CurrentCell.Value.ToString()}'";
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

        private void dataGridViewCalitate_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
