




namespace Aplicatie_Scanner
{
    partial class Aplicatie_Scanare 
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Aplicatie_Scanare));
            this.panel1 = new System.Windows.Forms.Panel();
            this.Panel_Nav = new System.Windows.Forms.Panel();
            this.Btn_Settings = new System.Windows.Forms.Button();
            this.Btn_Printer = new System.Windows.Forms.Button();
            this.Btn_Scanner = new System.Windows.Forms.Button();
            this.Btn_Dashboard = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbl_time = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Panel_Form_Loader = new System.Windows.Forms.Panel();
            this.Btn_Close_App = new System.Windows.Forms.Button();
            this.Btn_Minimize = new System.Windows.Forms.Button();
            this.lbltitle = new System.Windows.Forms.Label();
            this.timer_timp = new System.Windows.Forms.Timer(this.components);
            this.Btn_Maximize = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.panel1.Controls.Add(this.Panel_Nav);
            this.panel1.Controls.Add(this.Btn_Settings);
            this.panel1.Controls.Add(this.Btn_Printer);
            this.panel1.Controls.Add(this.Btn_Scanner);
            this.panel1.Controls.Add(this.Btn_Dashboard);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(186, 577);
            this.panel1.TabIndex = 7;
            // 
            // Panel_Nav
            // 
            this.Panel_Nav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(149)))));
            this.Panel_Nav.Location = new System.Drawing.Point(0, 192);
            this.Panel_Nav.Name = "Panel_Nav";
            this.Panel_Nav.Size = new System.Drawing.Size(3, 100);
            this.Panel_Nav.TabIndex = 10;
            // 
            // Btn_Settings
            // 
            this.Btn_Settings.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Btn_Settings.FlatAppearance.BorderSize = 0;
            this.Btn_Settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Settings.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Btn_Settings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.Btn_Settings.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Settings.Image")));
            this.Btn_Settings.Location = new System.Drawing.Point(0, 535);
            this.Btn_Settings.Name = "Btn_Settings";
            this.Btn_Settings.Size = new System.Drawing.Size(186, 42);
            this.Btn_Settings.TabIndex = 9;
            this.Btn_Settings.Text = "Settings";
            this.Btn_Settings.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.Btn_Settings.UseVisualStyleBackColor = true;
            this.Btn_Settings.Click += new System.EventHandler(this.Btn_Settings_Click);
            this.Btn_Settings.Leave += new System.EventHandler(this.Btn_Settings_Leave);
            // 
            // Btn_Printer
            // 
            this.Btn_Printer.Dock = System.Windows.Forms.DockStyle.Top;
            this.Btn_Printer.FlatAppearance.BorderSize = 0;
            this.Btn_Printer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Printer.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Btn_Printer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.Btn_Printer.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Printer.Image")));
            this.Btn_Printer.Location = new System.Drawing.Point(0, 228);
            this.Btn_Printer.Name = "Btn_Printer";
            this.Btn_Printer.Size = new System.Drawing.Size(186, 42);
            this.Btn_Printer.TabIndex = 9;
            this.Btn_Printer.Text = "    Printer";
            this.Btn_Printer.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.Btn_Printer.UseVisualStyleBackColor = true;
            this.Btn_Printer.Click += new System.EventHandler(this.Btn_Printer_Click);
            this.Btn_Printer.Leave += new System.EventHandler(this.Btn_Printer_Leave);
            // 
            // Btn_Scanner
            // 
            this.Btn_Scanner.Dock = System.Windows.Forms.DockStyle.Top;
            this.Btn_Scanner.FlatAppearance.BorderSize = 0;
            this.Btn_Scanner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Scanner.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Btn_Scanner.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.Btn_Scanner.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Scanner.Image")));
            this.Btn_Scanner.Location = new System.Drawing.Point(0, 186);
            this.Btn_Scanner.Name = "Btn_Scanner";
            this.Btn_Scanner.Size = new System.Drawing.Size(186, 42);
            this.Btn_Scanner.TabIndex = 9;
            this.Btn_Scanner.Text = "   Scanner";
            this.Btn_Scanner.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.Btn_Scanner.UseVisualStyleBackColor = true;
            this.Btn_Scanner.Click += new System.EventHandler(this.Btn_Scanner_Click);
            this.Btn_Scanner.Leave += new System.EventHandler(this.Btn_Scanner_Leave);
            // 
            // Btn_Dashboard
            // 
            this.Btn_Dashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.Btn_Dashboard.FlatAppearance.BorderSize = 0;
            this.Btn_Dashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Dashboard.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Btn_Dashboard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.Btn_Dashboard.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Dashboard.Image")));
            this.Btn_Dashboard.Location = new System.Drawing.Point(0, 144);
            this.Btn_Dashboard.Name = "Btn_Dashboard";
            this.Btn_Dashboard.Size = new System.Drawing.Size(186, 42);
            this.Btn_Dashboard.TabIndex = 9;
            this.Btn_Dashboard.Text = "Overview";
            this.Btn_Dashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.Btn_Dashboard.UseVisualStyleBackColor = true;
            this.Btn_Dashboard.Click += new System.EventHandler(this.Btn_Dashboard_Click);
            this.Btn_Dashboard.Leave += new System.EventHandler(this.Btn_Dashboard_Leave);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.lbl_time);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(186, 144);
            this.panel2.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(185, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(765, 78);
            this.panel3.TabIndex = 16;
            // 
            // lbl_time
            // 
            this.lbl_time.AutoSize = true;
            this.lbl_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_time.ForeColor = System.Drawing.Color.DarkGray;
            this.lbl_time.Location = new System.Drawing.Point(3, 9);
            this.lbl_time.Name = "lbl_time";
            this.lbl_time.Size = new System.Drawing.Size(84, 20);
            this.lbl_time.TabIndex = 1;
            this.lbl_time.Text = "Time Left";
            this.lbl_time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_time.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label1.Location = new System.Drawing.Point(21, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "AZEL Database \r\nManagement Studio";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Panel_Form_Loader
            // 
            this.Panel_Form_Loader.Location = new System.Drawing.Point(185, 61);
            this.Panel_Form_Loader.Name = "Panel_Form_Loader";
            this.Panel_Form_Loader.Size = new System.Drawing.Size(740, 516);
            this.Panel_Form_Loader.TabIndex = 15;
            // 
            // Btn_Close_App
            // 
            this.Btn_Close_App.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Close_App.FlatAppearance.BorderSize = 0;
            this.Btn_Close_App.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Close_App.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Btn_Close_App.ForeColor = System.Drawing.Color.White;
            this.Btn_Close_App.Location = new System.Drawing.Point(896, 23);
            this.Btn_Close_App.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Btn_Close_App.Name = "Btn_Close_App";
            this.Btn_Close_App.Size = new System.Drawing.Size(29, 29);
            this.Btn_Close_App.TabIndex = 13;
            this.Btn_Close_App.Text = "X";
            this.Btn_Close_App.UseVisualStyleBackColor = true;
            this.Btn_Close_App.Click += new System.EventHandler(this.button3_Click);
            // 
            // Btn_Minimize
            // 
            this.Btn_Minimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Minimize.FlatAppearance.BorderSize = 0;
            this.Btn_Minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Minimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Btn_Minimize.ForeColor = System.Drawing.Color.White;
            this.Btn_Minimize.Location = new System.Drawing.Point(831, 20);
            this.Btn_Minimize.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Btn_Minimize.Name = "Btn_Minimize";
            this.Btn_Minimize.Size = new System.Drawing.Size(29, 29);
            this.Btn_Minimize.TabIndex = 14;
            this.Btn_Minimize.Text = "_";
            this.Btn_Minimize.UseVisualStyleBackColor = true;
            this.Btn_Minimize.Click += new System.EventHandler(this.Btn_Minimize_Click);
            // 
            // lbltitle
            // 
            this.lbltitle.AutoSize = true;
            this.lbltitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbltitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.lbltitle.Location = new System.Drawing.Point(204, 16);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(211, 42);
            this.lbltitle.TabIndex = 19;
            this.lbltitle.Text = "Dashboard";
            this.lbltitle.Click += new System.EventHandler(this.lbltitle_Click);
            // 
            // timer_timp
            // 
            this.timer_timp.Tick += new System.EventHandler(this.timer_timp_Tick);
            // 
            // Btn_Maximize
            // 
            this.Btn_Maximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Maximize.FlatAppearance.BorderSize = 0;
            this.Btn_Maximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Maximize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Btn_Maximize.ForeColor = System.Drawing.Color.White;
            this.Btn_Maximize.Location = new System.Drawing.Point(863, 23);
            this.Btn_Maximize.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Btn_Maximize.Name = "Btn_Maximize";
            this.Btn_Maximize.Size = new System.Drawing.Size(29, 29);
            this.Btn_Maximize.TabIndex = 20;
            this.Btn_Maximize.Text = "🗖";
            this.Btn_Maximize.UseVisualStyleBackColor = true;
            this.Btn_Maximize.Click += new System.EventHandler(this.Btn_Maximize_Click);
            // 
            // Aplicatie_Scanare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(951, 577);
            this.Controls.Add(this.Btn_Maximize);
            this.Controls.Add(this.lbltitle);
            this.Controls.Add(this.Panel_Form_Loader);
            this.Controls.Add(this.Btn_Minimize);
            this.Controls.Add(this.Btn_Close_App);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Aplicatie_Scanare";
            this.Text = "Scanare Azel";
            this.Load += new System.EventHandler(this.Aplicatie_Scanare_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Aplicatie_Scanare_MouseDown);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Panel panel1;
        private Button Btn_Settings;
        private Button Btn_Printer;
        private Button Btn_Scanner;
        private Button Btn_Dashboard;
        private Panel panel2;
        private Label lbl_time;
        private Label label1;
        private Panel Panel_Nav;
        private Button Btn_Close_App;
        private Button Btn_Minimize;
        private Panel Panel_Form_Loader;
        private Label lbltitle;
        private System.Windows.Forms.Timer timer_timp;
        private Button Btn_Maximize;
        private Panel panel3;
    }
}