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
    public partial class Frm_Scanner : Form
    {
        public Frm_Scanner()
        {
            InitializeComponent();

        }

        FilterInfoCollection Filtru;
        VideoCaptureDevice Webcam;
   private void Frm_Scanner_Load(object sender, EventArgs e)
        {
            Filtru = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in Filtru)
                cboDevice.Items.Add(filterInfo.Name);
            cboDevice.SelectedIndex = 0;
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
                    textBox1.Text = result.ToString();
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
    }
}
