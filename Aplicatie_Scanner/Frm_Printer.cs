using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using BinaryKits.Zpl.Viewer;
using BinaryKits.Zpl.Viewer.Models;
using Org.BouncyCastle.Asn1.Ocsp;
using ZXing;
using ZXing.Windows.Compatibility;

namespace Aplicatie_Scanner
{
    public partial class Frm_Printer : Form
    {
        List<DateFurnizori> furnizoriList = new List<DateFurnizori>();
        List<DateCalitate> calitateList = new List<DateCalitate>();
        List<DateLungime> LungimeList = new List<DateLungime>();
        string ID;
        string ZPLString;
        public Frm_Printer()
        {
            InitializeComponent();
            pbRomply.Visible = false;
            pbAzel.Visible = false;
            tbNrAviz.Text = "000000";
            tbNrBucati.Text = "1";
            tbNrReceptie.Text = DateTime.Now.ToString("yyMMdd");
            tbDiametruBrut.Text = "40";
        }
        public void Generare_Cod_Bare()
        {
           
            //BarcodeWriter writer = new BarcodeWriter()
            //{
            //    Format = BarcodeFormat.QR_CODE,
            //    Options = new ZXing.Common.EncodingOptions
            //    {
            //        Height = 300,
            //        Width = 300,
            //        PureBarcode = false,
            //        Margin = 10,
            //    },
            //};
           
               // var bitmap = writer.Write(ID);
          

         
            


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
            tbNrBucati.Text = ID;

            Generare_Cod_Bare();
            AdaugaIntrari(CodDeIntrodus);



            // Printer IP Address and communication port
            string ipAddress = "192.168.100.104";
            int port = 9100;

            // ZPL Command(s)
             ZPLString =
$@"^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR2,2~SD30^JUS^LRN^CI0^XZ
^XA
^MMT
^PW799
^LL1194
^LS0
^FO672,1056^GFA,02048,02048,00016,:Z64:
eJztk81qxCAUha8h0uAqgbgPWRWfQiEyWwXve7Qw7mVWoU8RZiU+ZSVxZlLIqt0MdA53c/g8Xn8BXnrpqYTA0XG0rvgUWIosLXGzxEvuz+g/znsuHhxl9yN/DVBFAVA4RQnUIJDCq+sCbNlxZYBLjjfOwgIiiBQK5/oDvESvSv/cHBLsOJocxXtepFhFeMyP6Gjm9/4CIlv2HByXO56zLAQBIYZ1e2fw6I33yvsbF+v+U1q5AcxLQFSI5QCapoGtnkFItc7FlTaHnNSEtIR0XX+cV1NOWrTojvOqzWV5R9v2kE+1nuhUg6byN8v/s/Bksbfu7VSuZ2DDpRlnxsawetNb0tu+r7uNh2YM8zCzpnCNmrjPcz5CufplvlRxhGq+bOOtU7q3+fmozb/Pw1eTn/g8zlt/ZxzVwHu8fZCX/q++Aa3CX80=:88DD
^FO64,32^GFA,11264,11264,00088,:Z64:
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:269F
^FO56,1087^GB719,0,5^FS
^BY440,440^FT180,998^BXN,22,200,0,0,1,~
^FH\^FD{ID}^FS
^FO47,177^GB738,0,5^FS
^FT94,215^A0N,28,28^FH\^FDLungime : ^FS
^FT230,215^A0N,28,28^FH\^FD1234 mm^FS
^FT89,257^A0N,28,28^FH\^FDDiametru : ^FS
^FT230,257^A0N,28,28^FH\^FD{tbDiametruBrut.Text} ⌀^FS
^FT108,300^A0N,28,28^FH\^FDCalitate : ^FS
^FT230,300^A0N,28,28^FH\^FD{cbCalitate.Text}^FS
^FT144,342^A0N,28,28^FH\^FDData : ^FS
^FT230,344^A0N,28,28^FH\^FD{DateTime.Now.Day}/{DateTime.Now.Month}/{DateTime.Now.Year}^FS
^FT99,386^A0N,28,28^FH\^FDFurnizor : ^FS
^FT230,388^A0N,28,28^FH\^FD{cbFurnizor.Text}^FS
^FT48,430^A0N,28,28^FH\^FDNr. Receptie : ^FS
^FT230,432^A0N,28,28^FH\^FD{tbNrReceptie.Text}^FS
^FO47,460^GB738,0,5^FS
^PQ1,0,1,Y^XZ";
            #region
            /*      //                        @"^XA

                  //^FX Top section with logo, name and address.
                  //^CF0,60
                  //^FO50,50^GB100,100,100^FS
                  //^FO75,75^FR^GB100,100,100^FS
                  //^FO93,93^GB40,40,40^FS
                  //^FO220,50^FDCALIN ANDREI^FS
                  //^CF0,30
                  //^FO220,115^FD AZEL^FS
                  //^FO220,155^FDMagurele^FS
                  //^FO220,195^FDIlfov^FS
                  //^FO50,250^GB700,3,3^FS

                  //^FX Second section with recipient address and permit information.
                  //^CFA,30
                  //^FO50,300^FDSimion Ersen^FS
                  //^FO50,340^FDMagurele^FS
                  //^FO50,380^FDIlfov^FS
                  //^FO50,420^FDRomania^FS
                  //^CFA,15
                  //^FO600,300^GB150,150,3^FS
                  //^FO620,340^FDSemnatura^FS
                  //^FO638,390^FDVa Rog^FS
                  //^FO50,500^GB700,3,3^FS

                  //^FX Third section with bar code.
                  //^BY5,2,270
                  //^FO300,300^BQN,2,10^FDAZEL.RO^FS

                  //^FX Fourth section (the two boxes on the bottom).
                  //^FO50,900^GB700,250,3^FS
                  //^FO400,900^GB3,250,3^FS
                  //^CF0,40
                  //^FO100,960^FDPutem^FS
                  //^FO100,1010^FDPrinta^FS
                  //^FO100,1060^FDCe Vrem^FS
                  //^CF0,130
                  //^FO440,1000^FDAZEL^FS

                  //^XZ";

                  //PrintDialog pd = new PrintDialog();
                  //pd.PrinterSettings = new PrinterSettings();
                  //if (DialogResult.OK == pd.ShowDialog(this))
                  //{
                  //    RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, ZPLString);
                  //}*/
            #endregion
            try
            {
                // Open connection
                System.Net.Sockets.TcpClient client = new System.Net.Sockets.TcpClient();
                client.Connect(ipAddress, port);

                // Write ZPL String to connection
                System.IO.StreamWriter writer =
            new System.IO.StreamWriter(client.GetStream());
                writer.Write(ZPLString);
                writer.Flush();

                // Close Connection
                writer.Close();
                client.Close();
                MessageBox.Show("Done Sending Data.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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
            Task<List<DateLungime>> task_lungime = db.GetDateLungime();

            furnizoriList = await task_furnizori;
            calitateList = await task_calitate;
            LungimeList = await task_lungime;

            await Task.WhenAll(task_furnizori,task_calitate,task_lungime);
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
                    cbFurnizor.SelectedIndex = 0;
                }
                if (calitateList != null && cbCalitate.Items.Count < calitateList.Count)
                {
                    foreach (DateCalitate Date in calitateList)
                    {
                        cbCalitate.Items.Add(Date.Calitate);
                        lblPrinterDbError.Visible = false;
                      
                    }
                    cbCalitate.SelectedIndex = 0;
                }

                if (LungimeList != null && cbLungime.Items.Count < LungimeList.Count)
                {
                    foreach (DateLungime Date in LungimeList)
                    {
                        cbLungime.Items.Add(Math.Round(Date.Lungime,2));
                        lblPrinterDbError.Visible = false;

                    }
                    cbLungime.SelectedIndex = 0;
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
           

        }

        private void cbCalitate_SelectionChangeCommitted(object sender, EventArgs e)
        {
          

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

        private void cbFurnizor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
        private void btnPreview_Click(object sender, EventArgs e)
        {
            ID = Guid.NewGuid().ToString().Replace("-", "").ToUpper();
            ZPLString =
$@"^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR2,2~SD30^JUS^LRN^CI0^XZ
^XA
^MMT
^PW799
^LL1194
^LS0
^FO672,1056^GFA,02048,02048,00016,:Z64:
eJztk81qxCAUha8h0uAqgbgPWRWfQiEyWwXve7Qw7mVWoU8RZiU+ZSVxZlLIqt0MdA53c/g8Xn8BXnrpqYTA0XG0rvgUWIosLXGzxEvuz+g/znsuHhxl9yN/DVBFAVA4RQnUIJDCq+sCbNlxZYBLjjfOwgIiiBQK5/oDvESvSv/cHBLsOJocxXtepFhFeMyP6Gjm9/4CIlv2HByXO56zLAQBIYZ1e2fw6I33yvsbF+v+U1q5AcxLQFSI5QCapoGtnkFItc7FlTaHnNSEtIR0XX+cV1NOWrTojvOqzWV5R9v2kE+1nuhUg6byN8v/s/Bksbfu7VSuZ2DDpRlnxsawetNb0tu+r7uNh2YM8zCzpnCNmrjPcz5CufplvlRxhGq+bOOtU7q3+fmozb/Pw1eTn/g8zlt/ZxzVwHu8fZCX/q++Aa3CX80=:88DD
^FO64,32^GFA,11264,11264,00088,:Z64:
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:269F
^FO56,1087^GB719,0,5^FS
^BY440,440^FT180,998^BXN,22,200,0,0,1,~
^FH\^FD{ID}^FS
^FO47,177^GB738,0,5^FS
^FT94,215^A0N,28,28^FH\^FDLungime : ^FS
^FT230,215^A0N,28,28^FH\^FD1234 mm^FS
^FT89,257^A0N,28,28^FH\^FDDiametru : ^FS
^FT230,257^A0N,28,28^FH\^FD{tbDiametruBrut.Text} ⌀^FS
^FT108,300^A0N,28,28^FH\^FDCalitate : ^FS
^FT230,300^A0N,28,28^FH\^FD{cbCalitate.Text}^FS
^FT144,342^A0N,28,28^FH\^FDData : ^FS
^FT230,344^A0N,28,28^FH\^FD{DateTime.Now.Day}/{DateTime.Now.Month}/{DateTime.Now.Year}^FS
^FT99,386^A0N,28,28^FH\^FDFurnizor : ^FS
^FT230,388^A0N,28,28^FH\^FD{cbFurnizor.Text}^FS
^FT48,430^A0N,28,28^FH\^FDNr. Receptie : ^FS
^FT230,432^A0N,28,28^FH\^FD{tbNrReceptie.Text}^FS
^FO47,460^GB738,0,5^FS
^PQ1,0,1,Y^XZ";
            try
            {

                BinaryKits.Zpl.Viewer.IPrinterStorage printerStorage = new PrinterStorage();
                var drawer = new BinaryKits.Zpl.Viewer.ZplElementDrawer(printerStorage);

                var analyzer = new BinaryKits.Zpl.Viewer.ZplAnalyzer(printerStorage);
                var analyzeInfo = analyzer.Analyze(ZPLString);
                var imageData = drawer.Draw(analyzeInfo.LabelInfos.FirstOrDefault().ZplElements);
                foreach (var labelInfo in analyzeInfo.LabelInfos)
                {
                    imageData = drawer.Draw(labelInfo.ZplElements);
                    //imageData is bytes of png image

                }
                pictureBox1.Image = (Bitmap)((new ImageConverter()).ConvertFrom(imageData));
                pbRomply.Visible = true;
                pbAzel.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);        
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
