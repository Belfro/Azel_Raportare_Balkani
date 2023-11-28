namespace Azel_Raportare_Balkani
{
    partial class Frm_Dashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Dashboard));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            pictureBox2 = new PictureBox();
            dataGridView1 = new DataGridView();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            newCalendar1 = new NewCalendar();
            Search = new Button();
            label2 = new Label();
            cbZonaSelectie = new ComboBox();
            btnPrintCSV = new Button();
            tbEnergie_Produsa = new TextBox();
            lblEnergie_Produsa = new Label();
            lblApa_Consumata = new Label();
            tbApa_Consumata = new TextBox();
            lblPutere_Medie = new Label();
            tbPutereMedie = new TextBox();
            rbPutere = new RadioButton();
            rbEnergie = new RadioButton();
            rbDefault = new RadioButton();
            cbEnergieOra = new CheckBox();
            dateTimePicker1 = new DateTimePicker();
            Btn_Print_Raport_Lunar = new Button();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            Data = new DataGridViewTextBoxColumn();
            Timp = new DataGridViewTextBoxColumn();
            Putere = new DataGridViewTextBoxColumn();
            Energie = new DataGridViewTextBoxColumn();
            Presiune_Aductiune = new DataGridViewTextBoxColumn();
            Presiune_GUP = new DataGridViewTextBoxColumn();
            Pozitie_Injector_1 = new DataGridViewTextBoxColumn();
            Pozitie_Injector_2 = new DataGridViewTextBoxColumn();
            Vibratii_Generator = new DataGridViewTextBoxColumn();
            Debit_Instantaneu = new DataGridViewTextBoxColumn();
            Debit_Turbinat_Total = new DataGridViewTextBoxColumn();
            Meteo_Temperatura = new DataGridViewTextBoxColumn();
            Meteo_Umiditate = new DataGridViewTextBoxColumn();
            Meteo_Precipitatii = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(1177, 583);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(101, 90);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 34;
            pictureBox2.TabStop = false;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.FromArgb(8, 35, 50);
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Data, Timp, Putere, Energie, Presiune_Aductiune, Presiune_GUP, Pozitie_Injector_1, Pozitie_Injector_2, Vibratii_Generator, Debit_Instantaneu, Debit_Turbinat_Total, Meteo_Temperatura, Meteo_Umiditate, Meteo_Precipitatii });
            dataGridView1.GridColor = SystemColors.ControlLight;
            dataGridView1.Location = new Point(9, 12);
            dataGridView1.Margin = new Padding(0);
            dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(1269, 414);
            dataGridView1.TabIndex = 35;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            // 
            // newCalendar1
            // 
            newCalendar1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            newCalendar1.BackColor = Color.FromArgb(8, 35, 50);
            newCalendar1.FirstDayOfWeek = Day.Monday;
            newCalendar1.Font = new Font("Nirmala UI", 8F, FontStyle.Bold, GraphicsUnit.Point);
            newCalendar1.ForeColor = Color.White;
            newCalendar1.Location = new Point(13, 20);
            newCalendar1.Margin = new Padding(0);
            newCalendar1.MaxSelectionCount = 365;
            newCalendar1.Name = "newCalendar1";
            newCalendar1.TabIndex = 37;
            newCalendar1.TitleBackColor = Color.White;
            newCalendar1.TitleForeColor = Color.FromArgb(8, 35, 50);
            newCalendar1.TrailingForeColor = Color.LightGray;
            newCalendar1.DateChanged += newCalendar1_DateChanged;
            // 
            // Search
            // 
            Search.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Search.BackColor = Color.FromArgb(8, 35, 50);
            Search.FlatAppearance.BorderColor = Color.White;
            Search.FlatStyle = FlatStyle.Flat;
            Search.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            Search.ForeColor = Color.White;
            Search.Location = new Point(13, 190);
            Search.Name = "Search";
            Search.Size = new Size(213, 50);
            Search.TabIndex = 38;
            Search.Text = "Search";
            Search.UseVisualStyleBackColor = false;
            Search.Click += Search_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(249, 39);
            label2.Name = "label2";
            label2.Size = new Size(63, 20);
            label2.TabIndex = 42;
            label2.Text = "Locatie:";
            label2.Click += label2_Click;
            // 
            // cbZonaSelectie
            // 
            cbZonaSelectie.FormattingEnabled = true;
            cbZonaSelectie.Items.AddRange(new object[] { "Cuntu Grup 1", "Cuntu Grup 2", "Craiu 1 Grup 1", "Craiu 1 Grup 2", "Craiu 2 Grup 1", "Craiu 2 Grup 2", "Sebesel 1 Grup 1", "Sebesel 1 Grup 2", "Sebesel 2 Grup 1", "Sebesel 2 Grup 2", "Cornereva" });
            cbZonaSelectie.Location = new Point(318, 38);
            cbZonaSelectie.Name = "cbZonaSelectie";
            cbZonaSelectie.Size = new Size(163, 25);
            cbZonaSelectie.TabIndex = 43;
            cbZonaSelectie.SelectedIndexChanged += cbZonaSelectie_SelectedIndexChanged;
            // 
            // btnPrintCSV
            // 
            btnPrintCSV.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPrintCSV.BackColor = Color.FromArgb(8, 35, 50);
            btnPrintCSV.FlatAppearance.BorderColor = Color.White;
            btnPrintCSV.FlatStyle = FlatStyle.Flat;
            btnPrintCSV.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnPrintCSV.ForeColor = Color.White;
            btnPrintCSV.Location = new Point(262, 178);
            btnPrintCSV.Name = "btnPrintCSV";
            btnPrintCSV.Size = new Size(129, 50);
            btnPrintCSV.TabIndex = 46;
            btnPrintCSV.Text = "Print\r\nCSV";
            btnPrintCSV.UseVisualStyleBackColor = false;
            btnPrintCSV.Visible = false;
            btnPrintCSV.Click += btnPrintCSV_Click;
            // 
            // tbEnergie_Produsa
            // 
            tbEnergie_Produsa.Location = new Point(505, 65);
            tbEnergie_Produsa.Name = "tbEnergie_Produsa";
            tbEnergie_Produsa.Size = new Size(174, 25);
            tbEnergie_Produsa.TabIndex = 47;
            // 
            // lblEnergie_Produsa
            // 
            lblEnergie_Produsa.AutoSize = true;
            lblEnergie_Produsa.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblEnergie_Produsa.ForeColor = Color.White;
            lblEnergie_Produsa.Location = new Point(512, 42);
            lblEnergie_Produsa.Name = "lblEnergie_Produsa";
            lblEnergie_Produsa.Size = new Size(161, 20);
            lblEnergie_Produsa.TabIndex = 48;
            lblEnergie_Produsa.Text = "Total Energie Produsa";
            // 
            // lblApa_Consumata
            // 
            lblApa_Consumata.AutoSize = true;
            lblApa_Consumata.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblApa_Consumata.ForeColor = Color.White;
            lblApa_Consumata.Location = new Point(498, 104);
            lblApa_Consumata.Name = "lblApa_Consumata";
            lblApa_Consumata.Size = new Size(188, 20);
            lblApa_Consumata.TabIndex = 50;
            lblApa_Consumata.Text = "Cantitate Apa Consumata";
            // 
            // tbApa_Consumata
            // 
            tbApa_Consumata.Location = new Point(505, 127);
            tbApa_Consumata.Name = "tbApa_Consumata";
            tbApa_Consumata.Size = new Size(174, 25);
            tbApa_Consumata.TabIndex = 49;
            // 
            // lblPutere_Medie
            // 
            lblPutere_Medie.AutoSize = true;
            lblPutere_Medie.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblPutere_Medie.ForeColor = Color.White;
            lblPutere_Medie.Location = new Point(498, 169);
            lblPutere_Medie.Name = "lblPutere_Medie";
            lblPutere_Medie.Size = new Size(189, 20);
            lblPutere_Medie.TabIndex = 52;
            lblPutere_Medie.Text = "Putere Medie Functionare";
            // 
            // tbPutereMedie
            // 
            tbPutereMedie.Location = new Point(505, 192);
            tbPutereMedie.Name = "tbPutereMedie";
            tbPutereMedie.Size = new Size(174, 25);
            tbPutereMedie.TabIndex = 51;
            // 
            // rbPutere
            // 
            rbPutere.AutoSize = true;
            rbPutere.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            rbPutere.Location = new Point(249, 99);
            rbPutere.Name = "rbPutere";
            rbPutere.Size = new Size(73, 24);
            rbPutere.TabIndex = 54;
            rbPutere.Text = "Putere";
            rbPutere.UseVisualStyleBackColor = true;
            rbPutere.CheckedChanged += rbPutere_CheckedChanged;
            // 
            // rbEnergie
            // 
            rbEnergie.AutoSize = true;
            rbEnergie.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            rbEnergie.Location = new Point(249, 123);
            rbEnergie.Name = "rbEnergie";
            rbEnergie.Size = new Size(79, 24);
            rbEnergie.TabIndex = 55;
            rbEnergie.Text = "Energie";
            rbEnergie.UseVisualStyleBackColor = true;
            rbEnergie.CheckedChanged += rbEnergie_CheckedChanged;
            // 
            // rbDefault
            // 
            rbDefault.AutoSize = true;
            rbDefault.Checked = true;
            rbDefault.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            rbDefault.Location = new Point(249, 78);
            rbDefault.Name = "rbDefault";
            rbDefault.Size = new Size(79, 24);
            rbDefault.TabIndex = 56;
            rbDefault.TabStop = true;
            rbDefault.Text = "Default";
            rbDefault.UseVisualStyleBackColor = true;
            rbDefault.CheckedChanged += rbDefault_CheckedChanged;
            // 
            // cbEnergieOra
            // 
            cbEnergieOra.AutoSize = true;
            cbEnergieOra.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            cbEnergieOra.Location = new Point(348, 126);
            cbEnergieOra.Name = "cbEnergieOra";
            cbEnergieOra.Size = new Size(112, 24);
            cbEnergieOra.TabIndex = 57;
            cbEnergieOra.Text = "Energie/Ora";
            cbEnergieOra.UseVisualStyleBackColor = true;
            cbEnergieOra.Visible = false;
            cbEnergieOra.CheckedChanged += cbEnergieOra_CheckedChanged;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "MMMM yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(21, 32);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.ShowUpDown = true;
            dateTimePicker1.Size = new Size(200, 25);
            dateTimePicker1.TabIndex = 58;
            // 
            // Btn_Print_Raport_Lunar
            // 
            Btn_Print_Raport_Lunar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Btn_Print_Raport_Lunar.BackColor = Color.FromArgb(8, 35, 50);
            Btn_Print_Raport_Lunar.FlatAppearance.BorderColor = Color.White;
            Btn_Print_Raport_Lunar.FlatStyle = FlatStyle.Flat;
            Btn_Print_Raport_Lunar.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            Btn_Print_Raport_Lunar.ForeColor = Color.White;
            Btn_Print_Raport_Lunar.Location = new Point(21, 71);
            Btn_Print_Raport_Lunar.Name = "Btn_Print_Raport_Lunar";
            Btn_Print_Raport_Lunar.Size = new Size(200, 50);
            Btn_Print_Raport_Lunar.TabIndex = 59;
            Btn_Print_Raport_Lunar.Text = "Print\r\nRaport Lunar";
            Btn_Print_Raport_Lunar.UseVisualStyleBackColor = false;
            Btn_Print_Raport_Lunar.Click += Btn_Print_Raport_Lunar_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dateTimePicker1);
            groupBox1.Controls.Add(Btn_Print_Raport_Lunar);
            groupBox1.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.Location = new Point(825, 489);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(237, 147);
            groupBox1.TabIndex = 60;
            groupBox1.TabStop = false;
            groupBox1.Text = "Raport Lunar Energie/Debite";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(newCalendar1);
            groupBox2.Controls.Add(Search);
            groupBox2.Controls.Add(cbEnergieOra);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(rbDefault);
            groupBox2.Controls.Add(cbZonaSelectie);
            groupBox2.Controls.Add(rbEnergie);
            groupBox2.Controls.Add(btnPrintCSV);
            groupBox2.Controls.Add(rbPutere);
            groupBox2.Controls.Add(tbEnergie_Produsa);
            groupBox2.Controls.Add(lblPutere_Medie);
            groupBox2.Controls.Add(lblEnergie_Produsa);
            groupBox2.Controls.Add(tbPutereMedie);
            groupBox2.Controls.Add(tbApa_Consumata);
            groupBox2.Controls.Add(lblApa_Consumata);
            groupBox2.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox2.Location = new Point(12, 429);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(700, 240);
            groupBox2.TabIndex = 61;
            groupBox2.TabStop = false;
            groupBox2.Text = "Raport Selectie";
            // 
            // Data
            // 
            Data.FillWeight = 80F;
            Data.HeaderText = "Data";
            Data.Name = "Data";
            // 
            // Timp
            // 
            Timp.FillWeight = 80F;
            Timp.HeaderText = "Timp";
            Timp.Name = "Timp";
            // 
            // Putere
            // 
            Putere.HeaderText = "Putere [kW]";
            Putere.Name = "Putere";
            // 
            // Energie
            // 
            Energie.HeaderText = "Energie [kWh]";
            Energie.Name = "Energie";
            // 
            // Presiune_Aductiune
            // 
            Presiune_Aductiune.HeaderText = "Presiune Aductiune";
            Presiune_Aductiune.Name = "Presiune_Aductiune";
            // 
            // Presiune_GUP
            // 
            Presiune_GUP.HeaderText = "Presiune GUP";
            Presiune_GUP.Name = "Presiune_GUP";
            // 
            // Pozitie_Injector_1
            // 
            Pozitie_Injector_1.HeaderText = "Pozitie Injector 1 [%]";
            Pozitie_Injector_1.Name = "Pozitie_Injector_1";
            // 
            // Pozitie_Injector_2
            // 
            Pozitie_Injector_2.HeaderText = "Pozitie Injector 2 [%]";
            Pozitie_Injector_2.Name = "Pozitie_Injector_2";
            // 
            // Vibratii_Generator
            // 
            Vibratii_Generator.HeaderText = "Vibratii Generator";
            Vibratii_Generator.Name = "Vibratii_Generator";
            // 
            // Debit_Instantaneu
            // 
            Debit_Instantaneu.HeaderText = "Debit Instantaneu";
            Debit_Instantaneu.Name = "Debit_Instantaneu";
            // 
            // Debit_Turbinat_Total
            // 
            Debit_Turbinat_Total.HeaderText = "Debit Turbinat Total [1000 x m³]";
            Debit_Turbinat_Total.Name = "Debit_Turbinat_Total";
            // 
            // Meteo_Temperatura
            // 
            Meteo_Temperatura.HeaderText = "Temperatura Meteo [°C]";
            Meteo_Temperatura.Name = "Meteo_Temperatura";
            // 
            // Meteo_Umiditate
            // 
            Meteo_Umiditate.HeaderText = "Umiditate Meteo";
            Meteo_Umiditate.Name = "Meteo_Umiditate";
            // 
            // Meteo_Precipitatii
            // 
            Meteo_Precipitatii.HeaderText = "Precipitatii Meteo";
            Meteo_Precipitatii.Name = "Meteo_Precipitatii";
            // 
            // Frm_Dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(35, 65, 82);
            ClientSize = new Size(1290, 674);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(dataGridView1);
            Controls.Add(pictureBox2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Frm_Dashboard";
            FormClosing += Frm_Dashboard_FormClosing;
            Load += Frm_Dashboard_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }


        #endregion
        private PictureBox pictureBox2;
        private DataGridView dataGridView1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private NewCalendar newCalendar1;
        private Button Search;
        private Label label2;
        private ComboBox cbZonaSelectie;
        private Button btnPrintCSV;
        private TextBox tbEnergie_Produsa;
        private Label lblEnergie_Produsa;
        private Label lblApa_Consumata;
        private TextBox tbApa_Consumata;
        private Label lblPutere_Medie;
        private TextBox tbPutereMedie;
        private RadioButton rbPutere;
        private RadioButton rbEnergie;
        private RadioButton rbDefault;
        private CheckBox cbEnergieOra;
        private DateTimePicker dateTimePicker1;
        private Button Btn_Print_Raport_Lunar;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private DataGridViewTextBoxColumn Data;
        private DataGridViewTextBoxColumn Timp;
        private DataGridViewTextBoxColumn Putere;
        private DataGridViewTextBoxColumn Energie;
        private DataGridViewTextBoxColumn Presiune_Aductiune;
        private DataGridViewTextBoxColumn Presiune_GUP;
        private DataGridViewTextBoxColumn Pozitie_Injector_1;
        private DataGridViewTextBoxColumn Pozitie_Injector_2;
        private DataGridViewTextBoxColumn Vibratii_Generator;
        private DataGridViewTextBoxColumn Debit_Instantaneu;
        private DataGridViewTextBoxColumn Debit_Turbinat_Total;
        private DataGridViewTextBoxColumn Meteo_Temperatura;
        private DataGridViewTextBoxColumn Meteo_Umiditate;
        private DataGridViewTextBoxColumn Meteo_Precipitatii;
    }

}

