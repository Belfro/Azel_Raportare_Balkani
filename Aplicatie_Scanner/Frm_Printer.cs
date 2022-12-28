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
        public static bool Receptie_Pornita = false;
        public static int Numar_Receptie_Curenta = 1;
        public Frm_Printer()
        {
            InitializeComponent();
            pbRomply.Visible = false;
            pbAzel.Visible = false;
            tbNrAviz.Text = "000000";
            tbNrReceptie.Text = DateTime.Now.ToString("yyMMdd");
            tbDiametruBrut.Text = "40";
            ID = Guid.NewGuid().ToString().Replace("-", "").ToUpper();
            


        }
        public void Generare_Cod_Bare()
        {
          
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
                    cmd.CommandText = $"Insert INTO Etichete_Generate VALUES ({Comentariu}";
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
        private async void StergeEticheteVechi()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("ConnStr")))
            {
                try
                {
                    connection.Open();
                    var cmd = connection.CreateCommand();
                    cmd.CommandText = $"DELETE FROM Etichete_Generate WHERE Data_Timp < DATEADD(day, -7, GETDATE())";
                    cmd.CommandTimeout = 15;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    connection.Close();
                }

                catch (Exception ex)
                {
                }


            }
        }
        private void button_print_Click(object sender, EventArgs e)
        {
            if(Receptie_Pornita)
            Imprimare();


        }

    private void Imprimare()
        {

            ID = Guid.NewGuid().ToString().Replace("-", "").ToUpper();
            string Data = $"{DateTime.Now.Day.ToString("D2")}-{DateTime.Now.Month.ToString("D2")}-{DateTime.Now.Date.ToString("yy")}";

            string Timp = $"{DateTime.Now.Hour.ToString("D2")}:{DateTime.Now.Minute.ToString("D2")}:{DateTime.Now.Second.ToString("D2")}";

            string CodDeIntrodus =
                $"convert(datetime,'{Data} {Timp}',5)"
                + ",'"
                + cbFurnizor.Text
                + "','"
                + tbNrAviz.Text
                + "','"
                + tbNrReceptie.Text
                + "','"
                + lbLungime.Text
                + "','"
                + tbDiametruBrut.Text
                + "','"
                + lbCalitate.Text
                + "','"
                + ID
                + "','"
                + "Etichete_Generate"
                 + "','"
                + rtbComentariu.Text
                + "');";


            Generare_Cod_Bare();
            AdaugaIntrari(CodDeIntrodus);



            // Printer IP Address and communication port
            string ipAddress = "192.168.170.165";
            int port = 9100;
            string Data_Curenta = $"{DateTime.Now.Day.ToString("D2")}/{DateTime.Now.Month.ToString("D2")}/{DateTime.Now.Date.ToString("yy")}";
            // ZPL Command(s)
            ZPLString =
$@"^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR2,2~SD30^JUS^LRN^CI0^XZ
^XA
^MMT
^PW799
^LL1194
^LS0
^FO640,1056^GFA,02560,02560,00020,:Z64:
eJztk71qwzAURq8VCYSyeLB3k8mob5BJAndXwHof4SzGfQmhLuL6JSsIjWwHPLWUgg/y8nG4P0IGODj4JUgERI84+ZyxHqxV1jKVszPCPId5vm89vfYEwvRSrwKotYGlJzF9QwSx8OoawBYbTzhAwLj0egZFX9h+6eGbOyGZ8bzw0hLMbD10wpNVvSJ5tVr3JelSpCer+QrDlIWNF4lHWHss1eppYSjrntnZn3DGe5pvjgvv9rg/a74z4UhEHBAFPr2EUgoe559AopRtOiik2xV5w7njfBz9fj1xEXKYcMKwW49wR/gwxrF1+15zkY1sGtLK3b5/BcHrFMPkr9f8DAq40VJXytyq7Lkw8jB634zPjIKuqKbK6IUnsRWfH17KvC+jXVnrEqquzN4URBtGEIHnvp2m5j39dql3ni8MXrYQA/ofW/rg4OCFL+r7b/I=:4C0F
^FO96,32^GFA,10240,10240,00080,:Z64:
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:9CB7
^FO74,1076^GB685,0,5^FS
^BY440,440^FT180,998^BXN,22,200,0,0,1,~
^FH\^FD{ID}^FS
^FO56,177^GB699,0,5^FS
^FT94,215^A0N,28,28^FH\^FDLungime : ^FS
^FT230,215^A0N,28,28^FH\^FD{lbLungime.Text}^FS
^FT89,257^A0N,28,28^FH\^FDDiametru : ^FS
^FT230,257^A0N,28,28^FH\^FD{tbDiametruBrut.Text}^FS
^FT108,300^A0N,28,28^FH\^FDCalitate : ^FS
^FT230,300^A0N,28,28^FH\^FD{lbCalitate.Text}^FS
^FT144,342^A0N,28,28^FH\^FDData : ^FS
^FT230,344^A0N,28,28^FH\^FD{Data_Curenta}^FS
^FT99,386^A0N,28,28^FH\^FDFurnizor : ^FS
^FT230,388^A0N,28,28^FH\^FD{cbFurnizor.Text}^FS
^FT48,430^A0N,28,28^FH\^FDNr. Receptie : ^FS
^FT230,432^A0N,28,28^FH\^FD{tbNrReceptie.Text}^FS
^FO69,460^GB690,0,5^FS
^PQ1,0,1,Y^XZ";

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
                    // MessageBox.Show("Done Sending Data.");

                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show(ex.Message);
                 }
            lbCalitate.SelectedIndex = 0;
            tbDiametruBrut.SelectAll();
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
                tbID.Text = ID;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                    await Task.Run(StergeEticheteVechi);




                if (furnizoriList != null && cbFurnizor.Items.Count < furnizoriList.Count)
                {
                    foreach (DateFurnizori Date in furnizoriList)
                    {
                        cbFurnizor.Items.Add(Date.Denumire);
                        lblPrinterDbError.Visible = false;
                    }
                    cbFurnizor.SelectedIndex = 0;
                    
                }
                if (calitateList != null && lbCalitate.Items.Count < calitateList.Count)
                {
                    foreach (DateCalitate Date in calitateList)
                    {
                        
                        lbCalitate.Items.Add(Date.Calitate);
                        lblPrinterDbError.Visible = false;
                      
                    }
                   
                    lbCalitate.SelectedIndex = 0;
                }

                if (LungimeList != null && lbLungime.Items.Count < LungimeList.Count)
                {
                    foreach (DateLungime Date in LungimeList)
                    {
                        lbLungime.Items.Add(Math.Round(Date.Lungime,2));
                       
                        lblPrinterDbError.Visible = false;

                    }
                    Preview_Label();
                    lbLungime.SelectedIndex = 0;
                   
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

                        if (lbCalitate.Items.Count < calitateList.Count)
                        {
                        lbCalitate.Items.Clear();
                    foreach (DateCalitate Date in calitateList)
                    {
                        lbCalitate.Items.Add(Date.Calitate);
                       

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
            this.ActiveControl = tbDiametruBrut;
            Preview_Label();
        }
        private void Preview_Label()
        {
            string Data_Curenta = $"{DateTime.Now.Day.ToString("D2")}/{DateTime.Now.Month.ToString("D2")}/{DateTime.Now.Date.ToString("yy")}";

            ZPLString =
$@"^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR2,2~SD30^JUS^LRN^CI0^XZ
^XA
^MMT
^PW799
^LL1194
^LS0
^FO640,1056^GFA,02560,02560,00020,:Z64:
eJztk71qwzAURq8VCYSyeLB3k8mob5BJAndXwHof4SzGfQmhLuL6JSsIjWwHPLWUgg/y8nG4P0IGODj4JUgERI84+ZyxHqxV1jKVszPCPId5vm89vfYEwvRSrwKotYGlJzF9QwSx8OoawBYbTzhAwLj0egZFX9h+6eGbOyGZ8bzw0hLMbD10wpNVvSJ5tVr3JelSpCer+QrDlIWNF4lHWHss1eppYSjrntnZn3DGe5pvjgvv9rg/a74z4UhEHBAFPr2EUgoe559AopRtOiik2xV5w7njfBz9fj1xEXKYcMKwW49wR/gwxrF1+15zkY1sGtLK3b5/BcHrFMPkr9f8DAq40VJXytyq7Lkw8jB634zPjIKuqKbK6IUnsRWfH17KvC+jXVnrEqquzN4URBtGEIHnvp2m5j39dql3ni8MXrYQA/ofW/rg4OCFL+r7b/I=:4C0F
^FO96,32^GFA,10240,10240,00080,:Z64:
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:9CB7
^FO74,1076^GB685,0,5^FS
^BY440,440^FT180,998^BXN,22,200,0,0,1,~
^FH\^FD{ID}^FS
^FO56,177^GB699,0,5^FS
^FT94,215^A0N,28,28^FH\^FDLungime : ^FS
^FT230,215^A0N,28,28^FH\^FD{lbLungime.Text}^FS
^FT89,257^A0N,28,28^FH\^FDDiametru : ^FS
^FT230,257^A0N,28,28^FH\^FD{tbDiametruBrut.Text}^FS
^FT108,300^A0N,28,28^FH\^FDCalitate : ^FS
^FT230,300^A0N,28,28^FH\^FD{lbCalitate.Text}^FS
^FT144,342^A0N,28,28^FH\^FDData : ^FS
^FT230,344^A0N,28,28^FH\^FD{Data_Curenta}^FS
^FT99,386^A0N,28,28^FH\^FDFurnizor : ^FS
^FT230,388^A0N,28,28^FH\^FD{cbFurnizor.Text}^FS
^FT48,430^A0N,28,28^FH\^FDNr. Receptie : ^FS
^FT230,432^A0N,28,28^FH\^FD{tbNrReceptie.Text}^FS
^FO69,460^GB690,0,5^FS
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

      

        private void tbDiametruBrut_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return)))
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                if (Receptie_Pornita)
                Imprimare();

               
            }
           
        }

        private void btnStartReceptie_Click(object sender, EventArgs e)
        {
            if (!Receptie_Pornita)
            {
                lblReceptiePornita.Text = "Receptie Pornita!";
                lblReceptiePornita.ForeColor = Color.Lime;
                cbFurnizor.Enabled = false;
                tbNrAviz.Enabled = false;
                tbNrReceptie.Enabled = false;
                Receptie_Pornita = true;
                btn_print.Visible = true;
                btnPreview.Visible = false;
            }

        }

        private void btnStopReceptie_Click(object sender, EventArgs e)
        {
            if (Receptie_Pornita)
            {
                lblReceptiePornita.Text = "Receptie Oprita!";
                lblReceptiePornita.ForeColor = Color.Red;
                Numar_Receptie_Curenta++;
            cbFurnizor.Enabled = true;
            tbNrAviz.Enabled = true;
            tbNrReceptie.Enabled = true;
            Receptie_Pornita = false;
           
            btn_print.Visible = false;
            btnPreview.Visible = true;
               
            }
        }

      

        private void cbCalitate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lbLungime_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ActiveControl = tbDiametruBrut;
            tbDiametruBrut.SelectAll();
        }

        private void lbCalitate_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ActiveControl = tbDiametruBrut;
            tbDiametruBrut.SelectAll();
        }
    }
}
