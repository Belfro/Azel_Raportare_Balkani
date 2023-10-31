using LiveChartsCore.Defaults;
using LiveChartsCore;
using OpenTK.Audio.OpenAL;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Runtime.InteropServices;
using S7.Net;
using System.Data;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Net.Mail;
using System.Net;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Colors;
using Xamarin.Forms;
using iText.Kernel.Geom;
using iText.Kernel.Pdf.Canvas.Draw;
using System.Diagnostics;
using iText.IO.Image;
using Microsoft.Win32;
using System.Xml;

namespace Azel_Raportare_Balkani
{

    public partial class Aplicatie_Raportare_Balkani : Form
    {

        List<DatePutere> date_energie_ieri = new List<DatePutere>();
        List<DatePutere> date_energie_alaltaieri = new List<DatePutere>();

        public bool activare_print = false;
        bool _allowClose = false;
        public double energie_raport_lunar = 0;
        public double debit_raport_lunar = 0;
        public bool mail_trimis = false;
        void Aplicatie_Raportare_Balkani_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.F4) _allowClose = true;
        }

        void Aplicatie_Raportare_Balkani_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_allowClose && e.CloseReason == CloseReason.UserClosing)
            {
                notifyIcon1.Visible = true;
                this.Hide();
                e.Cancel = true;
            }
        }

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
        public System.Drawing.Size Panel_Old_Size;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public ObservableCollection<ObservableValue> ChartValues_Cuntu_Grup_1 = new ObservableCollection<ObservableValue>();
        public ObservableCollection<ObservableValue> ChartValues_Cuntu_Grup_2 = new ObservableCollection<ObservableValue>();
        public ObservableCollection<ISeries> seriesCollection = new ObservableCollection<ISeries>();
        int minut_scris = System.DateTime.Now.Minute;

        ///////////////Cuntu///////////////////
        Plc PLC_Cuntu_Grup_1 = new Plc(CpuType.S71200, "192.168.103.20", 0, 1);
        Plc PLC_Cuntu_Grup_2 = new Plc(CpuType.S71200, "192.168.103.21", 0, 1);

        ///////////////Craiu 1///////////////////
        Plc PLC_Craiu_1_Grup_1 = new Plc(CpuType.S71200, "192.168.107.20", 0, 1);
        Plc PLC_Craiu_1_Grup_2 = new Plc(CpuType.S71200, "192.168.107.21", 0, 1);

        ///////////////Craiu 2///////////////////
        Plc PLC_Craiu_2_Grup_1 = new Plc(CpuType.S71200, "192.168.105.20", 0, 1);
        Plc PLC_Craiu_2_Grup_2 = new Plc(CpuType.S71200, "192.168.105.21", 0, 1);

        ///////////// Sebesel 1////////////////
        Plc PLC_Sebesel_1_Grup_1 = new Plc(CpuType.S71200, "192.168.3.21", 0, 1);
        Plc PLC_Sebesel_1_Grup_2 = new Plc(CpuType.S71200, "192.168.3.20", 0, 1);

        ///////////// Sebesel 2////////////////
        Plc PLC_Sebesel_2_Grup_1 = new Plc(CpuType.S71200, "192.168.102.20", 0, 1);
        Plc PLC_Sebesel_2_Grup_2 = new Plc(CpuType.S71200, "192.168.102.21", 0, 1);

        ///////////// Cornereva////////////////
        Plc PLC_Cornereva = new Plc(CpuType.S71200, "172.16.11.200", 0, 1);




        public Aplicatie_Raportare_Balkani()
        {


            InitializeComponent();
            Old_Region = Region;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            Panel_Nav.Height = Btn_Dashboard.Height;
            Panel_Nav.Top = Btn_Dashboard.Top;



            lbltitle.Text = "Dashboard";
            this.Panel_Form_Loader.Controls.Clear();
            Frm_Dashboard Frm_Printer_Vrb = new Frm_Dashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            Frm_Printer_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.Panel_Form_Loader.Controls.Add(Frm_Printer_Vrb);
            Frm_Printer_Vrb.Show();
            Btn_Dashboard.BackColor = System.Drawing.Color.FromArgb(35, 65, 82);
            timer_timp.Start();
            timer_connect.Start();



            lblAppVersion.Text = Assembly.GetEntryAssembly().GetName().Version.ToString();
        }


        private void Btn_Settings_Click(object sender, EventArgs e)
        {

            Panel_Nav.Height = Btn_Settings.Height;
            Panel_Nav.Top = Btn_Settings.Top;


            Reset_Btn_BackColor();
            lbltitle.Text = "Settings";
            this.Panel_Form_Loader.Controls.Clear();
            Frm_Settings Frm_Settings_Vrb = new Frm_Settings() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            Frm_Settings_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.Panel_Form_Loader.Controls.Add(Frm_Settings_Vrb);
            Frm_Settings_Vrb.Show();
            Btn_Settings.BackColor = System.Drawing.Color.FromArgb(35, 65, 82);

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Dashboard_Click(object sender, EventArgs e)
        {

            Panel_Nav.Height = Btn_Dashboard.Height;
            Panel_Nav.Top = Btn_Dashboard.Top;
            Panel_Nav.Left = Btn_Dashboard.Left;

            Reset_Btn_BackColor();
            lbltitle.Text = "Dashboard";
            this.Panel_Form_Loader.Controls.Clear();
            Frm_Dashboard Frm_Dashboard_Vrb = new Frm_Dashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            Frm_Dashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.Panel_Form_Loader.Controls.Add(Frm_Dashboard_Vrb);
            Frm_Dashboard_Vrb.Show();
            Btn_Dashboard.BackColor = System.Drawing.Color.FromArgb(35, 65, 82);
        }


        private void Btn_Scanner_Click(object sender, EventArgs e)
        {
            Panel_Nav.Height = Btn_Scanner.Height;
            Panel_Nav.Top = Btn_Scanner.Top;

            Reset_Btn_BackColor();
            lbltitle.Text = "Prognoza";
            this.Panel_Form_Loader.Controls.Clear();
            Frm_Prognoza Frm_Scanner_Vrb = new Frm_Prognoza() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            Frm_Scanner_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.Panel_Form_Loader.Controls.Add(Frm_Scanner_Vrb);
            Frm_Scanner_Vrb.Show();
            Btn_Scanner.BackColor = System.Drawing.Color.FromArgb(35, 65, 82);
        }

        private void Btn_Printer_Click(object sender, EventArgs e)
        {

            Panel_Nav.Height = Btn_Printer.Height;
            Panel_Nav.Top = Btn_Printer.Top;


            Reset_Btn_BackColor();
            lbltitle.Text = "Grafice";
            this.Panel_Form_Loader.Controls.Clear();
            Frm_Grafice Frm_Printer_Vrb = new Frm_Grafice() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            Frm_Printer_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.Panel_Form_Loader.Controls.Add(Frm_Printer_Vrb);
            Frm_Printer_Vrb.Show();
            Btn_Printer.BackColor = System.Drawing.Color.FromArgb(35, 65, 82);
        }


        private void Reset_Btn_BackColor()
        {
            Btn_Dashboard.BackColor = System.Drawing.Color.FromArgb(8, 35, 50);
            Btn_Scanner.BackColor = System.Drawing.Color.FromArgb(8, 35, 50);
            Btn_Printer.BackColor = System.Drawing.Color.FromArgb(8, 35, 50);
            Btn_Settings.BackColor = System.Drawing.Color.FromArgb(8, 35, 50);
        }
        private void Btn_Dashboard_Leave(object sender, EventArgs e)
        {
            Btn_Dashboard.BackColor = System.Drawing.Color.FromArgb(8, 35, 50);
        }

        private void Btn_Scanner_Leave(object sender, EventArgs e)
        {
            Btn_Scanner.BackColor = System.Drawing.Color.FromArgb(8, 35, 50);
        }

        private void Btn_Printer_Leave(object sender, EventArgs e)
        {
            Btn_Printer.BackColor = System.Drawing.Color.FromArgb(8, 35, 50);
        }

        private void Btn_Settings_Leave(object sender, EventArgs e)
        {
            Btn_Settings.BackColor = System.Drawing.Color.FromArgb(8, 35, 50);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = true;
            this.Hide();
            //System.Windows.Forms.Application.Exit();

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

        private async void Conectare_PLC(Plc PLC)
        {
            bool Start_Conectare_PLC = false;
            var ping = new Ping();
            var reply = ping.Send(PLC.IP.ToString(), 5000);
            try
            {
                if (reply.Status == IPStatus.Success && !PLC.IsConnected && Start_Conectare_PLC == false)
                {
                    Start_Conectare_PLC = true;
                    await PLC.OpenAsync();
                    Start_Conectare_PLC = false;
                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }

        private void timer_connect_Tick(object sender, EventArgs e)
        {


            Task.Run(() => Conectare_PLC(PLC_Cuntu_Grup_1));
            Task.Run(() => Conectare_PLC(PLC_Cuntu_Grup_2));

            Task.Run(() => Conectare_PLC(PLC_Craiu_1_Grup_1));
            Task.Run(() => Conectare_PLC(PLC_Craiu_1_Grup_2));

            Task.Run(() => Conectare_PLC(PLC_Craiu_2_Grup_1));
            Task.Run(() => Conectare_PLC(PLC_Craiu_2_Grup_2));

            Task.Run(() => Conectare_PLC(PLC_Sebesel_1_Grup_1));
            Task.Run(() => Conectare_PLC(PLC_Sebesel_1_Grup_2));

            Task.Run(() => Conectare_PLC(PLC_Sebesel_2_Grup_1));
            Task.Run(() => Conectare_PLC(PLC_Sebesel_2_Grup_2));

            Task.Run(() => Conectare_PLC(PLC_Cornereva));

        }
        private async void timer_timp_Tick(object sender, EventArgs e)
        {
            lbl_time.Text = DateTime.Now.ToString();

            if (!mail_trimis && DateTime.Now.Day == 1 && DateTime.Now.Hour == 0 && DateTime.Now.Minute == 0)
            {
                Printare_Si_Trimitere_Raport_Lunar();
                mail_trimis = true;
            }
            else if (!mail_trimis && DateTime.Now.Hour == 8 && DateTime.Now.Minute == 5)
            {
                Printare_Si_Trimitere_Raport_Zilnic();
                mail_trimis = true;
            }
            else if (mail_trimis && DateTime.Now.Hour != 0 && DateTime.Now.Hour != 8)
            {
                mail_trimis = false;
            }



            try
            {


                Verificare_Conexiuni();

                if (minut_scris != System.DateTime.Now.Minute && (System.DateTime.Now.Minute == 0 || System.DateTime.Now.Minute == 15 || System.DateTime.Now.Minute == 30 || System.DateTime.Now.Minute == 45))
                {
                    minut_scris = System.DateTime.Now.Minute;

                    Task.Run(async () => Preluare_Si_Scriere_Date_PLC(PLC_Cuntu_Grup_1, "Cuntu_Grup_1"));
                    Task.Run(async () => Preluare_Si_Scriere_Date_PLC(PLC_Cuntu_Grup_2, "Cuntu_Grup_2"));

                    Task.Run(async () => Preluare_Si_Scriere_Date_PLC(PLC_Craiu_1_Grup_1, "Craiu_1_Grup_1"));
                    Task.Run(async () => Preluare_Si_Scriere_Date_PLC(PLC_Craiu_1_Grup_2, "Craiu_1_Grup_2"));

                    Task.Run(async () => Preluare_Si_Scriere_Date_PLC(PLC_Craiu_2_Grup_1, "Craiu_2_Grup_1"));
                    Task.Run(async () => Preluare_Si_Scriere_Date_PLC(PLC_Craiu_2_Grup_2, "Craiu_2_Grup_2"));

                    Task.Run(async () => Preluare_Si_Scriere_Date_PLC(PLC_Sebesel_1_Grup_1, "Sebesel_1_Grup_1"));
                    Task.Run(async () => Preluare_Si_Scriere_Date_PLC(PLC_Sebesel_1_Grup_2, "Sebesel_1_Grup_2"));

                    Task.Run(async () => Preluare_Si_Scriere_Date_PLC(PLC_Sebesel_2_Grup_1, "Sebesel_2_Grup_1"));
                    Task.Run(async () => Preluare_Si_Scriere_Date_PLC(PLC_Sebesel_2_Grup_2, "Sebesel_2_Grup_2"));

                    Task.Run(async () => Preluare_Si_Scriere_Date_PLC(PLC_Cornereva, "Cornereva"));
                }



            }
            catch
            {
                //MessageBox.Show("Error Connecting to the PLC!");
            }
        }

        private void Aplicatie_Scanare_Load(object sender, EventArgs e)
        {

        }

        private void Btn_Maximize_Click(object sender, EventArgs e)
        {

            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                Region = Old_Region;
                Panel_Old_Size = Panel_Form_Loader.Size;
                Panel_Form_Loader.Size = new System.Drawing.Size(this.Size.Width - 186, this.Size.Height - 150);

            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
                Btn_Close_App.Location.Offset(-500, 0);
                Panel_Form_Loader.Size = Panel_Old_Size;
            }
        }

        private void AdaugaIntrari(System.String Comentariu, System.String Nume_PLC)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("ConnStr")))
            {
                try
                {
                    connection.Open();
                    var cmd = connection.CreateCommand();

                    //SqlCommand cmd = new SqlCommand(" UPDATE Linia_1  SET Nume_Reteta = 'Modificat'; ");
                    cmd.CommandText = $"Insert INTO {Nume_PLC} VALUES ({Comentariu});";
                    cmd.CommandTimeout = 15;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    connection.Close();


                }

                catch (Exception ex)
                {
                    //MessageBox.Show("Error:" + ex.Message);
                }


            }
        }
        private async void Preluare_Si_Scriere_Date_PLC(Plc PLC, System.String Nume_PLC)
        {
            string Putere = "0";
            string Energie = "0";
            string Presiune_Aductiune = "0";
            string Presiune_GUP = "0";
            string Pozitie_Injector_1 = "0";
            string Pozitie_Injector_2 = "0";
            string Vibratii = "0";
            string Debit_Turbinat = "0";
            string Total_Turbinat = "0";
            string Umiditate_Meteo = "0";
            string Temperatura_Meteo = "0";
            string Precipitatii_Meteo = "0";

            if (PLC.IsConnected)
            {
                try
                {
                    var Putere_PLC = await PLC.ReadAsync(DataType.DataBlock, 8000, 0, VarType.Real, 1);
                    var Presiune_Aductiune_PLC = await PLC.ReadAsync(DataType.DataBlock, 8000, 4, VarType.Real, 1);
                    var Presiune_GUP_PLC = await PLC.ReadAsync(DataType.DataBlock, 8000, 8, VarType.Real, 1);
                    var Pozitie_Injector_1_PLC = await PLC.ReadAsync(DataType.DataBlock, 8000, 18, VarType.Real, 1);
                    var Pozitie_Injector_2_PLC = await PLC.ReadAsync(DataType.DataBlock, 8000, 22, VarType.Real, 1);
                    var Vibratii_PLC = await PLC.ReadAsync(DataType.DataBlock, 8000, 36, VarType.Real, 1);
                    var Energie_PLC = await PLC.ReadAsync(DataType.DataBlock, 8000, 40, VarType.LReal, 1);
                    var Debit_Turbinat_PLC = await PLC.ReadAsync(DataType.DataBlock, 8000, 48, VarType.Real, 1);
                    var Total_Turbinat_PLC = await PLC.ReadAsync(DataType.DataBlock, 8000, 52, VarType.LReal, 1);
                    var Umiditate_Meteo_PLC = await PLC.ReadAsync(DataType.DataBlock, 8000, 60, VarType.Real, 1);
                    var Temperatura_Meteo_PLC = await PLC.ReadAsync(DataType.DataBlock, 8000, 72, VarType.Real, 1);
                    var Precipitatii_Meteo_PLC = await PLC.ReadAsync(DataType.DataBlock, 8000, 86, VarType.Real, 1);

                    Putere = Putere_PLC.ToString();
                    Energie = Energie_PLC.ToString();
                    Presiune_Aductiune = Presiune_Aductiune_PLC.ToString();
                    Presiune_GUP = Presiune_GUP_PLC.ToString();
                    Pozitie_Injector_1 = Pozitie_Injector_1_PLC.ToString();
                    Pozitie_Injector_2 = Pozitie_Injector_2_PLC.ToString();
                    Vibratii = Vibratii_PLC.ToString();
                    Debit_Turbinat = Debit_Turbinat_PLC.ToString();
                    Total_Turbinat = Total_Turbinat_PLC.ToString();
                    Umiditate_Meteo = Umiditate_Meteo_PLC.ToString();
                    Temperatura_Meteo = Temperatura_Meteo_PLC.ToString();
                    Precipitatii_Meteo = Precipitatii_Meteo_PLC.ToString();


                }
                catch (Exception ex)
                {
                    // MessageBox.Show("Error: " + ex.ToString());
                }

            }

            string Data = $"{System.DateTime.Now.Day.ToString("D2")}-{System.DateTime.Now.Month.ToString("D2")}-{System.DateTime.Now.Date.ToString("yy")}";

            string Timp = $"{System.DateTime.Now.Hour.ToString("D2")} : {System.DateTime.Now.Minute.ToString("D2")} : 00";



            AdaugaIntrari($"convert(datetime,'{Data} {Timp}',5)"
                + ","
                + "Round(" + Putere + ",2)"
                + ","
                + "Round(" + Energie + ",2)"
                + ","
                + "Round(" + Presiune_Aductiune + ",2)"
                + ","
                + "Round(" + Presiune_GUP + ",2)"
                + ","
                + "Round(" + Pozitie_Injector_1 + ",2)"
                + ","
                + "Round(" + Pozitie_Injector_2 + ",2)"
                + ","
                + "Round(" + Vibratii + ",2)"
                + ","
                + "Round(" + Debit_Turbinat + ",2)"
                + ","
                + "Round(" + Total_Turbinat + ",2)"
                + ","
                + "Round(" + Temperatura_Meteo + ",2)"
                + ","
                + "Round(" + Umiditate_Meteo + ",2)"
                + ","
                + "Round(" + Precipitatii_Meteo + ",2)"
                + ""
                ,
                Nume_PLC
                );
            if (Nume_PLC == "Cuntu_Grup_1")
            {
                if (ChartValues_Cuntu_Grup_1.Count == 96)
                {
                    ChartValues_Cuntu_Grup_1.RemoveAt(0);
                }

                ChartValues_Cuntu_Grup_1.Add(new(Convert.ToDouble(Putere)));
            }

            else if (Nume_PLC == "Cuntu_Grup_2")
            {
                if (ChartValues_Cuntu_Grup_2.Count == 50)
                {
                    ChartValues_Cuntu_Grup_2.RemoveAt(0);
                }

                ChartValues_Cuntu_Grup_2.Add(new(Convert.ToDouble(Putere)));
            }

        }
        private void Verificare_Conexiuni()
        {
            if (PLC_Cuntu_Grup_1.IsConnected)
            {
                Cuntu_Grup_1_pbTick.Visible = true;
                Cuntu_Grup_1_pbX.Visible = false;
            }
            else
            {
                Cuntu_Grup_1_pbTick.Visible = false;
                Cuntu_Grup_1_pbX.Visible = true;
            }

            if (PLC_Cuntu_Grup_2.IsConnected)
            {
                Cuntu_Grup_2_pbTick.Visible = true;
                Cuntu_Grup_2_pbX.Visible = false;
            }
            else
            {
                Cuntu_Grup_2_pbTick.Visible = false;
                Cuntu_Grup_2_pbX.Visible = true;
            }

            if (PLC_Craiu_1_Grup_1.IsConnected)
            {
                Craiu_1_Grup_1_pbTick.Visible = true;
                Craiu_1_Grup_1_pbX.Visible = false;
            }
            else
            {
                Craiu_1_Grup_1_pbTick.Visible = false;
                Craiu_1_Grup_1_pbX.Visible = true;
            }

            if (PLC_Craiu_1_Grup_2.IsConnected)
            {
                Craiu_1_Grup_2_pbTick.Visible = true;
                Craiu_1_Grup_2_pbX.Visible = false;
            }
            else
            {
                Craiu_1_Grup_2_pbTick.Visible = false;
                Craiu_1_Grup_2_pbX.Visible = true;
            }

            if (PLC_Craiu_2_Grup_1.IsConnected)
            {
                Craiu_2_Grup_1_pbTick.Visible = true;
                Craiu_2_Grup_1_pbX.Visible = false;
            }
            else
            {
                Craiu_2_Grup_1_pbTick.Visible = false;
                Craiu_2_Grup_1_pbX.Visible = true;
            }

            if (PLC_Craiu_2_Grup_2.IsConnected)
            {
                Craiu_2_Grup_2_pbTick.Visible = true;
                Craiu_2_Grup_2_pbX.Visible = false;
            }
            else
            {
                Craiu_2_Grup_2_pbTick.Visible = false;
                Craiu_2_Grup_2_pbX.Visible = true;
            }

            if (PLC_Sebesel_1_Grup_1.IsConnected)
            {
                Sebesel_1_Grup_1_pbTick.Visible = true;
                Sebesel_1_Grup_1_pbX.Visible = false;
            }
            else
            {
                Sebesel_1_Grup_1_pbTick.Visible = false;
                Sebesel_1_Grup_1_pbX.Visible = true;
            }

            if (PLC_Sebesel_1_Grup_2.IsConnected)
            {
                Sebesel_1_Grup_2_pbTick.Visible = true;
                Sebesel_1_Grup_2_pbX.Visible = false;
            }
            else
            {
                Sebesel_1_Grup_2_pbTick.Visible = false;
                Sebesel_1_Grup_2_pbX.Visible = true;
            }

            if (PLC_Sebesel_2_Grup_1.IsConnected)
            {
                Sebesel_2_Grup_1_pbTick.Visible = true;
                Sebesel_2_Grup_1_pbX.Visible = false;
            }
            else
            {
                Sebesel_2_Grup_1_pbTick.Visible = false;
                Sebesel_2_Grup_1_pbX.Visible = true;
            }

            if (PLC_Sebesel_2_Grup_2.IsConnected)
            {
                Sebesel_2_Grup_2_pbTick.Visible = true;
                Sebesel_2_Grup_2_pbX.Visible = false;
            }
            else
            {
                Sebesel_2_Grup_2_pbTick.Visible = false;
                Sebesel_2_Grup_2_pbX.Visible = true;
            }

            if (PLC_Cornereva.IsConnected)
            {
                Cornereva_pbTick.Visible = true;
                Cornereva_pbX.Visible = false;
            }
            else
            {
                Cornereva_pbTick.Visible = false;
                Cornereva_pbX.Visible = true;
            }

        }

        private void Aplicatie_Scanare_FormClosing(object sender, FormClosingEventArgs e)
        {
            PLC_Cuntu_Grup_1.Close();
            PLC_Cuntu_Grup_2.Close();
            PLC_Craiu_1_Grup_1.Close();
            PLC_Craiu_1_Grup_2.Close();
            PLC_Craiu_2_Grup_1.Close();
            PLC_Craiu_2_Grup_2.Close();
            PLC_Sebesel_1_Grup_1.Close();
            PLC_Sebesel_1_Grup_2.Close();
            PLC_Sebesel_2_Grup_1.Close();
            PLC_Sebesel_2_Grup_2.Close();
            PLC_Cornereva.Close();
        }

        private void Btn_Close_App_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Btn_Close_App_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(500);
                this.Hide();
            }

            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon1.Visible = false;
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            notifyIcon1.Visible = false;
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }


        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }


        private void Printare_Si_Trimitere_Raport_Lunar()
        {
            string subPath = @$"C:\Azel\Raportari\Rapoarte_Lunare";

            bool exists = System.IO.Directory.Exists(subPath);

            if (!exists)
                System.IO.Directory.CreateDirectory(subPath);



            using (StreamWriter file = File.CreateText(@$"C:\Azel\Raportari\Rapoarte_Lunare\Raport_Lunar_{DateTime.Now.AddMinutes(-1).ToString("yyyy_MMMM")}.csv"))
            {
                energie_raport_lunar = 0;
                debit_raport_lunar = 0;

                file.WriteLine("");
                file.WriteLine("MHC,Index Vechi Energie,Index Nou Energie,Energie Produsa,Index Vechi Debit,Index Nou Debit, Volum Apa Turbinat");

                file.WriteLine(GetDateLuna("Cuntu_Grup_1"));
                file.WriteLine(GetDateLuna("Cuntu_Grup_2"));
                file.WriteLine(GetDateLuna("Craiu_1_Grup_1"));
                file.WriteLine(GetDateLuna("Craiu_1_Grup_2"));
                file.WriteLine(GetDateLuna("Craiu_2_Grup_1"));
                file.WriteLine(GetDateLuna("Craiu_2_Grup_2"));
                file.WriteLine(GetDateLuna("Sebesel_1_Grup_1"));
                file.WriteLine(GetDateLuna("Sebesel_1_Grup_2"));
                file.WriteLine(GetDateLuna("Sebesel_2_Grup_1"));
                file.WriteLine(GetDateLuna("Sebesel_2_Grup_2"));
                file.WriteLine(GetDateLuna("Cornereva"));
                file.WriteLine("");

                file.WriteLine($",,,{Math.Round(energie_raport_lunar, 2)},,,{Math.Round(debit_raport_lunar, 2)}");
                file.WriteLine($",,,Energie Totala,,,Volum Total Turbinat");

            }

            ///////////////////////////////
            ///////TRIMITERE MAIL//////////
            ///////////////////////////////
            try
            {
                var smtpClient = new SmtpClient("mail.azel.ro")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("calin.rizoiu@azel.ro", "SHpQv5sMpx7k"),
                    EnableSsl = false,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("calin.rizoiu@azel.ro"),
                    Subject = @$"Raport_Lunar_{DateTime.Now.AddMinutes(-1).ToString("yyyy_MMMM")}",
                    Body = "Email Auto-Generat " +
                    "\n \n Azel Design Group SRL ",




                    // IsBodyHtml = true,
                };

                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(@$"C:\Azel\Raportari\Rapoarte_Lunare\Raport_Lunar_{DateTime.Now.AddMinutes(-1).ToString("yyyy_MMMM")}.csv");
                mailMessage.Attachments.Add(attachment);
                mailMessage.To.Add("crizoiu@yahoo.com");
                mailMessage.To.Add("stanfandrei@yahoo.com");
                //mailMessage.To.Add("office@azel.ro");

                smtpClient.Send(mailMessage);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private string GetDateLuna(string MHC)
        {
            double energie_totala = 0;
            double debit_total = 0;
            double index_initial_energie = 0;
            double index_final_energie = 0;
            double index_initial_debit = 0;
            double index_final_debit = 0;
            string rezultat = "";
            DataAccess db = new DataAccess();

            var inceputul_lunii = new DateTime(DateTime.Now.AddMinutes(-1).Year, DateTime.Now.AddMinutes(-1).Month, 1);
            var sfarsitul_lunii = inceputul_lunii.AddMonths(1).AddTicks(-1);
            var date_luna = db.GetDateToataZiua(inceputul_lunii, sfarsitul_lunii.AddDays(1).AddTicks(-1), "", MHC);
            if (date_luna.Any())
            {
                index_initial_energie = date_luna.Select(x => x.Energie).SkipWhile(x => x == 0).FirstOrDefault(0);
                index_final_energie = date_luna.Select(x => x.Energie).Reverse().SkipWhile(x => x == 0).FirstOrDefault(0);
                energie_totala = Math.Round((index_final_energie - index_initial_energie), 2);

                index_initial_debit = date_luna.Select(x => x.Debit_Turbinat_Total).SkipWhile(x => x == 0).FirstOrDefault(0);
                index_final_debit = date_luna.Select(x => x.Debit_Turbinat_Total).Reverse().SkipWhile(x => x == 0).FirstOrDefault(0);
                debit_total = Math.Round((index_final_debit - index_initial_debit), 2);
            }
            energie_raport_lunar = energie_raport_lunar + energie_totala;
            debit_raport_lunar = debit_raport_lunar + debit_total;

            rezultat = $"{MHC.Replace("_", " ")},{index_initial_energie},{index_final_energie},{energie_totala},{index_initial_debit},{index_final_debit},{debit_total}";
            return rezultat;

        }
        private void Printare_Si_Trimitere_Raport_Zilnic()
        {
            DataAccess db = new DataAccess();
            var date_raport = db.GetDateRaportZilnic();
            var date_raport_ziua_trecuta = db.GetDateRaportZilnicZiuaTrecuta();

            string subPath = @$"C:\Azel\Raportari\Rapoarte_Zilnice";

            bool exists = System.IO.Directory.Exists(subPath);

            if (!exists)
                System.IO.Directory.CreateDirectory(subPath);

            PdfWriter writer = new PdfWriter(@$"C:\Azel\Raportari\Rapoarte_Zilnice\Raport_{DateTime.Now.ToString("dd_MM_yy")}.pdf");
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);

            ImageData data = ImageDataFactory.Create(ImageToByte(Azel_Raportare_Balkani.Properties.Resources.LogoBalkan));
            iText.Layout.Element.Image image = new iText.Layout.Element.Image(data);
            image.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
            image.Scale(0.6f, 0.6f);
            document.Add(image);

            document.Add(new Paragraph(new Text("\n")));

            Paragraph header = new Paragraph($"Raport Zilnic Productie Balkani {DateTime.Now.ToString("dd.MM")}")
               .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
               .SetFontSize(20);

            document.Add(header);
            document.Add(new Paragraph(new Text("\n")));
            document.Add(new LineSeparator(new DottedLine()));
            document.Add(new Paragraph(new Text("\n")));
            // Table
            Table table = new Table(6, false).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);

            iText.Layout.Element.Cell cell11 = new iText.Layout.Element.Cell(1, 1)
               .SetBackgroundColor(ColorConstants.GRAY)
               .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
               .Add(new Paragraph("Grup"));
            iText.Layout.Element.Cell cell12 = new iText.Layout.Element.Cell(1, 1)
               .SetBackgroundColor(ColorConstants.GRAY)
               .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
               .Add(new Paragraph("Index Vechi [kWh]"));

            iText.Layout.Element.Cell cell13 = new iText.Layout.Element.Cell(1, 1)
                .SetBackgroundColor(ColorConstants.GRAY)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .Add(new Paragraph("Index Nou [kWh]"));
            iText.Layout.Element.Cell cell14 = new iText.Layout.Element.Cell(1, 1)
                .SetBackgroundColor(ColorConstants.GRAY)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .Add(new Paragraph("Energie Produsa [kWh]"));
            iText.Layout.Element.Cell cell15 = new iText.Layout.Element.Cell(1, 1)
                .SetBackgroundColor(ColorConstants.GRAY)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .Add(new Paragraph("Energie Produsa Per Centrala [kWh]"));
            iText.Layout.Element.Cell cell16 = new iText.Layout.Element.Cell(1, 1)
                .SetBackgroundColor(ColorConstants.GRAY)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .Add(new Paragraph($"Prognoza {DateTime.Now.AddDays(+1).ToString("dd.MM")} [kWh]"));


            table.AddCell(cell11);
            table.AddCell(cell12);
            table.AddCell(cell13);
            table.AddCell(cell14);
            table.AddCell(cell15);
            table.AddCell(cell16);

            var prognoza = GenerarePrognozaRaportZilnic();
            for (int i = 0; i < date_raport_ziua_trecuta.Count; i++)
            {
                iText.Layout.Element.Cell cellx1 = new iText.Layout.Element.Cell(1, 1)
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                    .Add(new Paragraph(date_raport_ziua_trecuta[i].Nume_Grup.Replace('_', ' ')));

                iText.Layout.Element.Cell cellx2 = new iText.Layout.Element.Cell(1, 1)
                   .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                   .Add(new Paragraph(date_raport_ziua_trecuta[i].Energie_Rotunjita.ToString()));

                table.AddCell(cellx1);
                table.AddCell(cellx2);

                iText.Layout.Element.Cell cellx3 = new iText.Layout.Element.Cell(1, 1)
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                    .Add(new Paragraph(date_raport[i].Energie_Rotunjita.ToString()));
                iText.Layout.Element.Cell cellx4 = new iText.Layout.Element.Cell(1, 1)
                   .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                   .Add(new Paragraph((date_raport[i].Energie_Rotunjita - date_raport_ziua_trecuta[i].Energie_Rotunjita).ToString()));
                table.AddCell(cellx3);
                table.AddCell(cellx4);

                if (i % 2 == 0 && i < date_raport_ziua_trecuta.Count - 1)
                {
                    iText.Layout.Element.Cell cellx5 = new iText.Layout.Element.Cell(2, 1)
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetVerticalAlignment(VerticalAlignment.MIDDLE)
                    .Add(new Paragraph((date_raport[i].Energie_Rotunjita - date_raport_ziua_trecuta[i].Energie_Rotunjita + date_raport[i + 1].Energie_Rotunjita - date_raport_ziua_trecuta[i + 1].Energie_Rotunjita).ToString()));

                    table.AddCell(cellx5);

                    iText.Layout.Element.Cell cellx6 = new iText.Layout.Element.Cell(2, 1)
                   .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetVerticalAlignment(VerticalAlignment.MIDDLE)
                   .Add(new Paragraph((prognoza[i / 2].Energie_Rotunjita).ToString()));

                    table.AddCell(cellx6);
                }
                else if (i % 2 == 0 && i == date_raport_ziua_trecuta.Count - 1)
                {
                    iText.Layout.Element.Cell cellx5 = new iText.Layout.Element.Cell(1, 1)
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                    .Add(new Paragraph((date_raport[i].Energie_Rotunjita - date_raport_ziua_trecuta[i].Energie_Rotunjita).ToString()));

                    table.AddCell(cellx5);

                    iText.Layout.Element.Cell cellx6 = new iText.Layout.Element.Cell(1, 1)
                  .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetVerticalAlignment(VerticalAlignment.MIDDLE)
                  .Add(new Paragraph((prognoza[i / 2].Energie_Rotunjita).ToString()));

                    table.AddCell(cellx6);
                }


            }
            for (int i = 0; i < date_raport.Count; i = i + 2)
            {


            }


            document.Add(table);
            document.Add(new Paragraph(new Text("\n")));

            document.Add(new Paragraph(new Text(" " +
                "Registered to the Commercial Registry under no.J 35 / 3152 / 2006" +
                "\r\nUnique code of registration : R 18737871")).SetFixedPosition(document.GetLeftMargin(), document.GetBottomMargin(), PageSize.A4.GetWidth()));
            document.Close();



            ///////////////////////////////
            ///////TRIMITERE MAIL//////////
            ///////////////////////////////
            try
            {
                var smtpClient = new SmtpClient("mail.azel.ro")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("calin.rizoiu@azel.ro", "SHpQv5sMpx7k"),
                    EnableSsl = false,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("calin.rizoiu@azel.ro"),
                    Subject = @$"Raport Zilnic {DateTime.Now.ToString("dd_MM_yy")}",
                    Body = "Email Auto-Generat " +
                    "\n \n Azel Design Group SRL ",




                    // IsBodyHtml = true,
                };

                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(@$"C:\Azel\Raportari\Rapoarte_Zilnice\Raport_{DateTime.Now.ToString("dd_MM_yy")}.pdf");
                mailMessage.Attachments.Add(attachment);
                mailMessage.To.Add("crizoiu@yahoo.com");
                mailMessage.To.Add("stanfandrei@yahoo.com");
                //mailMessage.To.Add("office@azel.ro");

                smtpClient.Send(mailMessage);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public static byte[] ImageToByte(System.Drawing.Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }
        private void OpenFolder(string path)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    ProcessStartInfo startinfo = new ProcessStartInfo
                    {
                        Arguments = path,
                        FileName = "explorer.exe"
                    };
                    Process.Start(startinfo);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }

        }
        private List<DateRaportZilnic> GenerarePrognozaRaportZilnic()
        {
            List<DateRaportZilnic> prognoza = new List<DateRaportZilnic>();
            bool Prima_Conditie_Selectata = false;
            string Conditii_Get_Date = "";
            try
            {

                DataAccess db = new DataAccess();
                date_energie_ieri.Clear();
                date_energie_alaltaieri.Clear();

                date_energie_ieri = db.GetDateEnergie(DateTime.Now.AddDays(-1), DateTime.Now.AddDays(0).AddTicks(-1));
                date_energie_alaltaieri = db.GetDateEnergie(DateTime.Now.AddDays(-2), DateTime.Now.AddDays(-1).AddTicks(-1));


                double suma_cuntu = (date_energie_ieri.Sum(x => x.Cuntu_Grup_1) + date_energie_ieri.Sum(x => x.Cuntu_Grup_2));
                double suma_cuntu_prev = (date_energie_alaltaieri.Sum(x => x.Cuntu_Grup_1) + date_energie_alaltaieri.Sum(x => x.Cuntu_Grup_2));

                double suma_craiu_1 = (date_energie_ieri.Sum(x => x.Craiu_1_Grup_1) + date_energie_ieri.Sum(x => x.Craiu_1_Grup_2));
                double suma_craiu_1_prev = (date_energie_alaltaieri.Sum(x => x.Craiu_1_Grup_1) + date_energie_alaltaieri.Sum(x => x.Craiu_1_Grup_2));

                double suma_craiu_2 = (date_energie_ieri.Sum(x => x.Craiu_2_Grup_1) + date_energie_ieri.Sum(x => x.Craiu_2_Grup_2));
                double suma_craiu_2_prev = (date_energie_alaltaieri.Sum(x => x.Craiu_2_Grup_1) + date_energie_alaltaieri.Sum(x => x.Craiu_2_Grup_2));

                double suma_sebesel_1 = (date_energie_ieri.Sum(x => x.Sebesel_1_Grup_1) + date_energie_ieri.Sum(x => x.Sebesel_1_Grup_2));
                double suma_sebesel_1_prev = (date_energie_alaltaieri.Sum(x => x.Sebesel_1_Grup_1) + date_energie_alaltaieri.Sum(x => x.Sebesel_1_Grup_2));


                double suma_sebesel_2 = (date_energie_ieri.Sum(x => x.Sebesel_2_Grup_1) + date_energie_ieri.Sum(x => x.Sebesel_2_Grup_2));
                double suma_sebesel_2_prev = (date_energie_alaltaieri.Sum(x => x.Sebesel_2_Grup_1) + date_energie_alaltaieri.Sum(x => x.Sebesel_2_Grup_2));


                double suma_cornereva = (date_energie_ieri.Sum(x => x.Cornereva));
                double suma_cornereva_prev = (date_energie_alaltaieri.Sum(x => x.Cornereva));


                double factor_corectie_cuntu = Math.Round(suma_cuntu / suma_cuntu_prev, 2);
                double factor_corectie_craiu_1 = Math.Round(suma_craiu_1 / suma_craiu_1_prev, 2);
                double factor_corectie_craiu_2 = Math.Round(suma_craiu_2 / suma_craiu_2_prev, 2);
                double factor_corectie_sebesel_1 = Math.Round(suma_sebesel_1 / suma_sebesel_1_prev, 2);
                double factor_corectie_sebesel_2 = Math.Round(suma_sebesel_2 / suma_sebesel_2_prev, 2);
                double factor_corectie_cornereva = Math.Round(suma_cornereva / suma_cornereva_prev, 2);


                if (factor_corectie_cuntu < 0.8 || Double.IsNaN(factor_corectie_cuntu)) factor_corectie_cuntu = 0.8;
                if (factor_corectie_cuntu > 1.2) factor_corectie_cuntu = 1.2;
                if (factor_corectie_craiu_1 < 0.8 || Double.IsNaN(factor_corectie_craiu_1)) factor_corectie_craiu_1 = 0.8;
                if (factor_corectie_craiu_1 > 1.2) factor_corectie_craiu_1 = 1.2;
                if (factor_corectie_craiu_2 < 0.8 || Double.IsNaN(factor_corectie_craiu_2)) factor_corectie_craiu_2 = 0.8;
                if (factor_corectie_craiu_2 > 1.2) factor_corectie_craiu_2 = 1.2;
                if (factor_corectie_sebesel_1 < 0.8 || Double.IsNaN(factor_corectie_sebesel_1)) factor_corectie_sebesel_1 = 0.8;
                if (factor_corectie_sebesel_1 > 1.2) factor_corectie_sebesel_1 = 1.2;
                if (factor_corectie_sebesel_2 < 0.8 || Double.IsNaN(factor_corectie_sebesel_2)) factor_corectie_sebesel_2 = 0.8;
                if (factor_corectie_sebesel_2 > 1.2) factor_corectie_sebesel_2 = 1.2;
                if (factor_corectie_cornereva < 0.8 || Double.IsNaN(factor_corectie_cornereva)) factor_corectie_cornereva = 0.8;
                if (factor_corectie_cornereva > 1.2) factor_corectie_cornereva = 1.2;







                prognoza.Add(new DateRaportZilnic { Nume_Grup = "Cuntu", Energie = Math.Round(suma_cuntu * factor_corectie_cuntu, 2) });
                prognoza.Add(new DateRaportZilnic { Nume_Grup = "Craiu_1", Energie = Math.Round(suma_craiu_1 * factor_corectie_craiu_1, 2) });
                prognoza.Add(new DateRaportZilnic { Nume_Grup = "Craiu_2", Energie = Math.Round(suma_craiu_2 * factor_corectie_craiu_2, 2) });
                prognoza.Add(new DateRaportZilnic { Nume_Grup = "Sebesel_1", Energie = Math.Round(suma_sebesel_1 * factor_corectie_sebesel_1, 2) });
                prognoza.Add(new DateRaportZilnic { Nume_Grup = "Sebesel_2", Energie = Math.Round(suma_sebesel_2 * factor_corectie_sebesel_2, 2) });
                prognoza.Add(new DateRaportZilnic { Nume_Grup = "Cornereva", Energie = Math.Round(suma_cornereva * factor_corectie_cornereva, 2) });

                return prognoza;






            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                Printare_Si_Trimitere_Raport_Zilnic();
                OpenFolder(@$"C:\Azel\Raportari\Rapoarte_Zilnice");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
    }
}
