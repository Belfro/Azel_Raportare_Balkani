using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;
using ZXing.Windows.Compatibility;

namespace Aplicatie_Scanner
{
    public partial class Frm_Printer : Form
    {
        List<DateFurnizori> furnizoriList = new List<DateFurnizori>();
        List<DateCalitate> calitateList = new List<DateCalitate>();
        string ID;
        public Frm_Printer()
        {
            InitializeComponent();
        }
        public void Generare_Cod_Bare()
        {
           
            BarcodeWriter writer = new BarcodeWriter()
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new ZXing.Common.EncodingOptions
                {
                    Height = 300,
                    Width = 300,
                    PureBarcode = false,
                    Margin = 10,
                },
            };
           
                var bitmap = writer.Write(ID);
            //lblLabelCodBare.Text = "Cod Bare: " + ID;
            lblLabelNrAviz.Text = ID.Length.ToString();
            pictureBox1.Image = bitmap;
            


            return;
        }
       
        private void AdaugaIntrari(String Comentariu)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("ConnStr")))
            {
                try
                {
                    connection.Open();
                    var cmd = connection.CreateCommand();

                    //SqlCommand cmd = new SqlCommand(" UPDATE Linia_1  SET Nume_Reteta = 'Modificat'; ");
                    cmd.CommandText = $"Insert INTO Produse VALUES ({Comentariu}";
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
            private void button_print_Click(object sender, EventArgs e)
        {
            ID = Guid.NewGuid().ToString().Replace("-","").ToUpper();
            string Data = $"{PrinterCalendar.SelectionStart.Day.ToString("D2")}-{PrinterCalendar.SelectionStart.Month.ToString("D2")}-{PrinterCalendar.SelectionStart.Date.ToString("yy")}";

            string Timp =  $"{DateTime.Now.Hour.ToString("D2")}:{DateTime.Now.Minute.ToString("D2")}:{DateTime.Now.Second.ToString("D2")}";
            
            string CodDeIntrodus = 
                $"convert(datetime,'{Data} {Timp}',5)"
                + ",'"
                + cbFurnizor.Text
                + "','" 
                + cbCalitate.Text
                + "','"
                + ID
                + "');";

            Generare_Cod_Bare();
            AdaugaIntrari(CodDeIntrodus);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Generare_Cod_Bare();
            }
        }
        public async Task LoadDatePrinter()
        {

            DataAccess db = new DataAccess();
            Task<List<DateCalitate>> task_calitate = db.GetDateCalitate();
            Task<List<DateFurnizori>> task_furnizori = db.GetDateFurnizori();

            furnizoriList = await task_furnizori;
            calitateList = await task_calitate;

            await Task.WhenAll(task_furnizori,task_calitate);
        }
        private async void Frm_Printer_Load(object sender, EventArgs e)
        {
            timer1.Start();
            try
            {

               
                    await Task.Run(async () => LoadDatePrinter());
      




                if (furnizoriList != null && cbFurnizor.Items.Count < furnizoriList.Count)
                {
                    foreach (DateFurnizori Date in furnizoriList)
                    {
                        cbFurnizor.Items.Add(Date.Denumire);
                        lblPrinterDbError.Visible = false;
                    }
                }
                if (calitateList != null && cbCalitate.Items.Count < calitateList.Count)
                {
                    foreach (DateCalitate Date in calitateList)
                    {
                        cbCalitate.Items.Add(Date.Calitate);
                        lblPrinterDbError.Visible = false;
                    }
                }


            }
            catch (Exception ex)
            {
                lblPrinterDbError.Visible = true;
                lblPrinterDbError.Text = "Error Connecting to the Database !";

            }


        }

        private async void timer1_Tick(object sender, EventArgs e)
        {

           
            if (furnizoriList == null && calitateList == null)
            {
                lblPrinterDbError.Visible = true;
                lblPrinterDbError.Text = "Error Connecting to the Database !";
            }
            else
            {
                lblPrinterDbError.Visible = false;
            }
            try
            {

                     await Task.Run(async () => LoadDatePrinter());
      
 
               


                if (furnizoriList != null )
                {
                    if (cbFurnizor.Items.Count < furnizoriList.Count)
                    {
                        cbFurnizor.Items.Clear();
                        foreach (DateFurnizori Date in furnizoriList)
                    {
                        cbFurnizor.Items.Add(Date.Denumire);
                    }
                    lblPrinterDbError.Visible = false;
                    }
                    
                }
                if (calitateList != null )

                        if (cbCalitate.Items.Count < calitateList.Count)
                        {
                        cbCalitate.Items.Clear();
                    foreach (DateCalitate Date in calitateList)
                    {
                        cbCalitate.Items.Add(Date.Calitate);

                    }
                    lblPrinterDbError.Visible = false;
                }
                {
                   
                }
               

            }
            catch (Exception ex)
            {

                

            }
        }

        private void cbFurnizor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            lblLabelFurnizor.Text = "Furnizor : " + cbFurnizor.SelectedItem;

        }

        private void cbCalitate_SelectionChangeCommitted(object sender, EventArgs e)
        {
            lblLabelCalitate.Text = "Calitate : " + cbCalitate.SelectedItem;

        }

        private void lblLabelCodBare_Click(object sender, EventArgs e)
        {

        }

        private void lblLabelNrAviz_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
