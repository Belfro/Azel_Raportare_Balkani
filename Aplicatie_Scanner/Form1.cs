using System.Windows.Forms;
using System.Drawing;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;
using ZXing.Windows.Compatibility;
using Zebra.Sdk;
using System.Runtime.InteropServices;



namespace Aplicatie_Scanner
{
   
    public partial class Aplicatie_Scanare : Form
    {
        
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
(
    int nLeftRect,
    int nTopRect,
    int nRightRect,
    int nBottomRect,
    int nWidthEllipse,
    int nHeightEllipse
    );
        public Region Old_Region;
        public Size Panel_Old_Size;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public Aplicatie_Scanare()
        {
            InitializeComponent();
            Old_Region = Region;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            Panel_Nav.Height = Btn_Printer.Height;
            Panel_Nav.Top = Btn_Printer.Top;
            //Btn_Printer.BackColor = Color.FromArgb(46, 51, 73);


            lbltitle.Text = "Printer";
            this.Panel_Form_Loader.Controls.Clear();
            Frm_Printer Frm_Printer_Vrb = new Frm_Printer() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            Frm_Printer_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.Panel_Form_Loader.Controls.Add(Frm_Printer_Vrb);
            Frm_Printer_Vrb.Show();

            timer_timp.Start();

        }


        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void Btn_Settings_Click(object sender, EventArgs e)
        {
            Panel_Nav.Height = Btn_Settings.Height;
            Panel_Nav.Top = Btn_Settings.Top;
            //Btn_Settings.BackColor = Color.FromArgb(46, 51, 73);


            lbltitle.Text = "Settings";
            this.Panel_Form_Loader.Controls.Clear();
            Frm_Settings Frm_Settings_Vrb = new Frm_Settings() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            Frm_Settings_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.Panel_Form_Loader.Controls.Add(Frm_Settings_Vrb);
            Frm_Settings_Vrb.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Dashboard_Click(object sender, EventArgs e)
        {
            Panel_Nav.Height = Btn_Dashboard.Height;
            Panel_Nav.Top = Btn_Dashboard.Top;
            Panel_Nav.Left = Btn_Dashboard.Left;
           // Btn_Dashboard.BackColor = Color.FromArgb(46, 51, 73);

            lbltitle.Text = "Dashboard";
            this.Panel_Form_Loader.Controls.Clear();
            Frm_Dashboard Frm_Dashboard_Vrb = new Frm_Dashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            Frm_Dashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.Panel_Form_Loader.Controls.Add(Frm_Dashboard_Vrb);
            Frm_Dashboard_Vrb.Show();


        }

        private void Btn_Scanner_Click(object sender, EventArgs e)
        {
            Panel_Nav.Height = Btn_Scanner.Height;
            Panel_Nav.Top = Btn_Scanner.Top;
           

            lbltitle.Text = "Scanner";
            this.Panel_Form_Loader.Controls.Clear();
            Frm_Scanner Frm_Scanner_Vrb = new Frm_Scanner() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            Frm_Scanner_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.Panel_Form_Loader.Controls.Add(Frm_Scanner_Vrb);
            Frm_Scanner_Vrb.Show();
            Btn_Scanner.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void Btn_Printer_Click(object sender, EventArgs e)
        {
            Panel_Nav.Height = Btn_Printer.Height;
            Panel_Nav.Top = Btn_Printer.Top;
            


            lbltitle.Text = "Printer";
            this.Panel_Form_Loader.Controls.Clear();
            Frm_Printer Frm_Printer_Vrb = new Frm_Printer() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            Frm_Printer_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.Panel_Form_Loader.Controls.Add(Frm_Printer_Vrb);
            Frm_Printer_Vrb.Show();
            Btn_Printer.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void Btn_Dashboard_Leave(object sender, EventArgs e)
        {
            Btn_Dashboard.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void Btn_Scanner_Leave(object sender, EventArgs e)
        {
            Btn_Scanner.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void Btn_Printer_Leave(object sender, EventArgs e)
        {
            Btn_Printer.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void Btn_Settings_Leave(object sender, EventArgs e)
        {
            Btn_Settings.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Btn_Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;        
        }

        private void Aplicatie_Scanare_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void lbltitle_Click(object sender, EventArgs e)
        {

        }

        private void timer_timp_Tick(object sender, EventArgs e)
        {
            lbl_time.Text = DateTime.Now.ToString();
        }

        private void Aplicatie_Scanare_Load(object sender, EventArgs e)
        {

        }

        private void Btn_Maximize_Click(object sender, EventArgs e)
        {
            
            if (this.WindowState == FormWindowState.Normal)
            { this.WindowState = FormWindowState.Maximized;
                Region = Old_Region;
                Panel_Old_Size = Panel_Form_Loader.Size;
                Panel_Form_Loader.Size = new Size(this.Size.Width-186, this.Size.Height - 150);
               
            }
            else
                { this.WindowState = FormWindowState.Normal;
                Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25)) ;
                Btn_Close_App.Location.Offset(-500, 0);
                Panel_Form_Loader.Size = Panel_Old_Size;
            }
        }
    }
}