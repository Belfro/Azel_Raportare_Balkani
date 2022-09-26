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
using Dapper;
using Zebra.Sdk.Comm;
using ZXing;
using ZXing.Windows.Compatibility;

namespace Aplicatie_Scanner
{
    public partial class Frm_Scanner : Form
    {
        string ID = "";
        string Locatie_Curenta = "";
        public Frm_Scanner()
        {
            InitializeComponent();
            cbLocatieNoua.Visible = true;
            lblLocatieNoua.Visible = true;
            btnModifica.Visible = true;
            cbLocatieNoua.Items.Clear();
            cbLocatieNoua.Items.Add("Etichete_Generate");
            cbLocatieNoua.Items.Add("Linie_Productie_1");
            cbLocatieNoua.SelectedIndex = 0;
        }
        List<DateFurnizori> furnizoriList = new List<DateFurnizori>();
        List<DateCalitate> calitateList = new List<DateCalitate>();
        FilterInfoCollection Filtru;
        VideoCaptureDevice Webcam;
   private void Frm_Scanner_Load(object sender, EventArgs e)
        {
            Filtru = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in Filtru)
                cboDevice.Items.Add(filterInfo.Name);
            if (cboDevice.Items.Count >1)
            {
                cboDevice.SelectedIndex = 1;
            }
            else cboDevice.SelectedIndex = 0;

            Webcam = new VideoCaptureDevice(Filtru[cboDevice.SelectedIndex].MonikerString);

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void Trigger_Click(object sender, EventArgs e)
        {
            Webcam = new VideoCaptureDevice(Filtru[cboDevice.SelectedIndex].MonikerString);
            Webcam.NewFrame += Webcam_Newframe;
            Webcam.Start();
            timer1.Start();
        }
        private void Webcam_Newframe(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void Frm_Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (Webcam.IsRunning)
                    Webcam.SignalToStop();

            }
            catch (Exception ex)
            {
                return;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                BarcodeReader reader = new BarcodeReader();
                Result result = reader.Decode((Bitmap)pictureBox1.Image);
                if (result != null)
                {
                   
                    try
                    {
                        using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("ConnStr")))
                        {


                            var output = connection.Query<DateDB>($"select * from Etichete_Generate WHERE GUID = '{result.ToString()}'" +
                                $"UNION select * from Linie_Productie_1 WHERE GUID = '{result.ToString()}' ").ToList();

                            tbFurnizor.Text = output.FirstOrDefault().Furnizor.ToString();
                            tbNrAviz.Text = output.FirstOrDefault().Numar_Aviz.ToString();
                            tbNrBucati.Text = output.FirstOrDefault().Numar_Bucati.ToString();
                            tbNrReceptie.Text = output.FirstOrDefault().Numar_Receptie.ToString();
                            tbLungime.Text = output.FirstOrDefault().Lungime.ToString();
                            tbDiametruBrut.Text = output.FirstOrDefault().Diametru.ToString();
                            tbLungime.Text = output.FirstOrDefault().Lungime.ToString();
                            cbLocatieNoua.SelectedIndex = cbLocatieNoua.FindStringExact(output.FirstOrDefault().Locatie_Actuala.ToString());
                            ID = output.FirstOrDefault().GUID.ToString();
                            tbLocatieCurenta.Text = output.FirstOrDefault().Locatie_Actuala.ToString();
                            cbLocatieNoua.Visible = true;
                            lblLocatieNoua.Visible = true;
                            btnModifica.Visible = true;
                            ////Calcul Automat Diametru NET////
                            if (output.FirstOrDefault().Diametru >= 42)
                            {
                                lblDiametruNet.Text = "Net: " + (output.FirstOrDefault().Diametru - 3).ToString();
                            } 
                            else if (output.FirstOrDefault().Diametru > 18 && output.FirstOrDefault().Diametru < 41)
                            {
                                lblDiametruNet.Text = "Net: " + (output.FirstOrDefault().Diametru - 2).ToString();
                            }
                            else
                            {
                                lblDiametruNet.Text = "Net: " + (output.FirstOrDefault().Diametru).ToString();
                            }
                            tbCalitate.Text = output.FirstOrDefault().Calitate.ToString();

                            connection.Close();
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Error:" + ex.Message);
                       
                    }
                    tbGUIDScanat.Text = result.ToString();
                    timer1.Stop();
                    pictureBox1.Image = null;
                    if (Webcam.IsRunning)
                        Webcam.SignalToStop();
                }
            }
        }

        private void Btn_Disconnect_Click(object sender, EventArgs e)
        {
            if (Webcam.IsRunning)
                Webcam.SignalToStop();
            pictureBox1.Image = null;
        }

        private void Frm_Scanner_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Webcam.IsRunning)
                Webcam.SignalToStop();
            pictureBox1.Image = null;
        }

        private void Frm_Scanner_Leave(object sender, EventArgs e)
        {
            if (Webcam.IsRunning)
                Webcam.SignalToStop();
            pictureBox1.Image = null;
        }

        private void cboDevice_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnModifica_Click(object sender, EventArgs e)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("ConnStr")))
            {
                try
                {
                    connection.Open();
                    var cmd = connection.CreateCommand();

                   
                    cmd.CommandText = $" BEGIN TRANSACTION;" +
                        $"\r\nINSERT INTO {cbLocatieNoua.Text} (Data_Timp,Furnizor,Numar_Aviz,Numar_Bucati,Numar_Receptie,Lungime,Diametru,Calitate,GUID,Locatie_Actuala)" +
                        $"\r\nSELECT Data_Timp,Furnizor,Numar_Aviz,Numar_Bucati,Numar_Receptie,Lungime,Diametru,Calitate,GUID,Locatie_Actuala" +
                        $"\r\nFROM {tbLocatieCurenta.Text}\r\nWHERE GUID = '{ID}';" +
                        $"\r\nDELETE FROM {tbLocatieCurenta.Text}" +
                        $"\r\nWHERE GUID = '{ID}';\r\nCOMMIT;";
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
