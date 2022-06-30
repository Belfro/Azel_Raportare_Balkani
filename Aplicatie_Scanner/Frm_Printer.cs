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
            if (textBox1.Text.Length > 0)
            {
                var bitmap = writer.Write(textBox1.Text);
                pictureBox1.Image = bitmap;
            }


            return;
        }
        private void Generare_Click(object sender, EventArgs e)
        {
            Generare_Cod_Bare();
        }

        private void button_print_Click(object sender, EventArgs e)
        {

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
    }
}
