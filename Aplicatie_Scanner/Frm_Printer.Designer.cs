namespace Aplicatie_Scanner
{
    partial class Frm_Printer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Printer));
            this.button_print = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFurnizor = new System.Windows.Forms.ComboBox();
            this.lblFurnizor = new System.Windows.Forms.Label();
            this.PrinterCalendar = new Aplicatie_Scanner.NewCalendar();
            this.lblNrAviz = new System.Windows.Forms.Label();
            this.tbNrAviz = new System.Windows.Forms.TextBox();
            this.tbDiametruBrut = new System.Windows.Forms.TextBox();
            this.lblDiametru = new System.Windows.Forms.Label();
            this.lblCalitate = new System.Windows.Forms.Label();
            this.cbCalitate = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblPrinterDbError = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblLabelNrAviz = new System.Windows.Forms.Label();
            this.lblLabelNrBuc = new System.Windows.Forms.Label();
            this.lblLabelCalitate = new System.Windows.Forms.Label();
            this.lblLabelFurnizor = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbNrBucati = new System.Windows.Forms.TextBox();
            this.lblNrBucati = new System.Windows.Forms.Label();
            this.tbNrReceptie = new System.Windows.Forms.TextBox();
            this.lblNrReceptie = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblLungime = new System.Windows.Forms.Label();
            this.cbLungime = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_print
            // 
            this.button_print.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_print.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(100)))));
            this.button_print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_print.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button_print.ForeColor = System.Drawing.Color.Black;
            this.button_print.Location = new System.Drawing.Point(577, 304);
            this.button_print.Name = "button_print";
            this.button_print.Size = new System.Drawing.Size(142, 89);
            this.button_print.TabIndex = 35;
            this.button_print.Text = "Print";
            this.button_print.UseVisualStyleBackColor = false;
            this.button_print.Click += new System.EventHandler(this.button_print_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(0, 190);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(303, 199);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(677, 425);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(101, 90);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 37;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.No;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 30);
            this.label2.TabIndex = 39;
            this.label2.Text = "Current Label";
            // 
            // cbFurnizor
            // 
            this.cbFurnizor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbFurnizor.FormattingEnabled = true;
            this.cbFurnizor.Location = new System.Drawing.Point(318, 72);
            this.cbFurnizor.Name = "cbFurnizor";
            this.cbFurnizor.Size = new System.Drawing.Size(172, 23);
            this.cbFurnizor.TabIndex = 40;
            this.cbFurnizor.SelectionChangeCommitted += new System.EventHandler(this.cbFurnizor_SelectionChangeCommitted);
            // 
            // lblFurnizor
            // 
            this.lblFurnizor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFurnizor.AutoSize = true;
            this.lblFurnizor.Cursor = System.Windows.Forms.Cursors.No;
            this.lblFurnizor.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblFurnizor.ForeColor = System.Drawing.Color.White;
            this.lblFurnizor.Location = new System.Drawing.Point(318, 55);
            this.lblFurnizor.Name = "lblFurnizor";
            this.lblFurnizor.Size = new System.Drawing.Size(59, 17);
            this.lblFurnizor.TabIndex = 41;
            this.lblFurnizor.Text = "Furnizor";
            // 
            // PrinterCalendar
            // 
            this.PrinterCalendar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PrinterCalendar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(100)))));
            this.PrinterCalendar.FirstDayOfWeek = System.Windows.Forms.Day.Monday;
            this.PrinterCalendar.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PrinterCalendar.Location = new System.Drawing.Point(495, 46);
            this.PrinterCalendar.Name = "PrinterCalendar";
            this.PrinterCalendar.TabIndex = 42;
            this.PrinterCalendar.TitleBackColor = System.Drawing.Color.White;
            // 
            // lblNrAviz
            // 
            this.lblNrAviz.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNrAviz.AutoSize = true;
            this.lblNrAviz.Cursor = System.Windows.Forms.Cursors.No;
            this.lblNrAviz.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNrAviz.ForeColor = System.Drawing.Color.White;
            this.lblNrAviz.Location = new System.Drawing.Point(318, 101);
            this.lblNrAviz.Name = "lblNrAviz";
            this.lblNrAviz.Size = new System.Drawing.Size(80, 17);
            this.lblNrAviz.TabIndex = 44;
            this.lblNrAviz.Text = "Numar Aviz";
            // 
            // tbNrAviz
            // 
            this.tbNrAviz.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNrAviz.Location = new System.Drawing.Point(318, 118);
            this.tbNrAviz.Name = "tbNrAviz";
            this.tbNrAviz.Size = new System.Drawing.Size(172, 23);
            this.tbNrAviz.TabIndex = 45;
            // 
            // tbDiametruBrut
            // 
            this.tbDiametruBrut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDiametruBrut.Location = new System.Drawing.Point(317, 381);
            this.tbDiametruBrut.Name = "tbDiametruBrut";
            this.tbDiametruBrut.Size = new System.Drawing.Size(172, 23);
            this.tbDiametruBrut.TabIndex = 47;
            // 
            // lblDiametru
            // 
            this.lblDiametru.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDiametru.AutoSize = true;
            this.lblDiametru.Cursor = System.Windows.Forms.Cursors.No;
            this.lblDiametru.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDiametru.ForeColor = System.Drawing.Color.White;
            this.lblDiametru.Location = new System.Drawing.Point(318, 365);
            this.lblDiametru.Name = "lblDiametru";
            this.lblDiametru.Size = new System.Drawing.Size(96, 17);
            this.lblDiametru.TabIndex = 48;
            this.lblDiametru.Text = "Diametru Brut";
            // 
            // lblCalitate
            // 
            this.lblCalitate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCalitate.AutoSize = true;
            this.lblCalitate.Cursor = System.Windows.Forms.Cursors.No;
            this.lblCalitate.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCalitate.ForeColor = System.Drawing.Color.White;
            this.lblCalitate.Location = new System.Drawing.Point(319, 407);
            this.lblCalitate.Name = "lblCalitate";
            this.lblCalitate.Size = new System.Drawing.Size(55, 17);
            this.lblCalitate.TabIndex = 50;
            this.lblCalitate.Text = "Calitate";
            // 
            // cbCalitate
            // 
            this.cbCalitate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCalitate.FormattingEnabled = true;
            this.cbCalitate.Location = new System.Drawing.Point(317, 424);
            this.cbCalitate.Name = "cbCalitate";
            this.cbCalitate.Size = new System.Drawing.Size(172, 23);
            this.cbCalitate.TabIndex = 49;
            this.cbCalitate.SelectionChangeCommitted += new System.EventHandler(this.cbCalitate_SelectionChangeCommitted);
            // 
            // timer1
            // 
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblPrinterDbError
            // 
            this.lblPrinterDbError.AutoSize = true;
            this.lblPrinterDbError.Cursor = System.Windows.Forms.Cursors.No;
            this.lblPrinterDbError.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPrinterDbError.ForeColor = System.Drawing.Color.Red;
            this.lblPrinterDbError.Location = new System.Drawing.Point(15, 5);
            this.lblPrinterDbError.Name = "lblPrinterDbError";
            this.lblPrinterDbError.Size = new System.Drawing.Size(46, 17);
            this.lblPrinterDbError.TabIndex = 52;
            this.lblPrinterDbError.Text = "Error !";
            this.lblPrinterDbError.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblLabelNrAviz);
            this.panel1.Controls.Add(this.lblLabelNrBuc);
            this.panel1.Controls.Add(this.lblLabelCalitate);
            this.panel1.Controls.Add(this.lblLabelFurnizor);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(12, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(303, 389);
            this.panel1.TabIndex = 53;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.No;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(3, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 17);
            this.label1.TabIndex = 58;
            this.label1.Text = "Diametru :";
            // 
            // lblLabelNrAviz
            // 
            this.lblLabelNrAviz.AutoSize = true;
            this.lblLabelNrAviz.Cursor = System.Windows.Forms.Cursors.No;
            this.lblLabelNrAviz.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblLabelNrAviz.ForeColor = System.Drawing.Color.Black;
            this.lblLabelNrAviz.Location = new System.Drawing.Point(131, 167);
            this.lblLabelNrAviz.Name = "lblLabelNrAviz";
            this.lblLabelNrAviz.Size = new System.Drawing.Size(88, 17);
            this.lblLabelNrAviz.TabIndex = 57;
            this.lblLabelNrAviz.Text = "Numar Aviz :";
            this.lblLabelNrAviz.Click += new System.EventHandler(this.lblLabelNrAviz_Click);
            // 
            // lblLabelNrBuc
            // 
            this.lblLabelNrBuc.AutoSize = true;
            this.lblLabelNrBuc.Cursor = System.Windows.Forms.Cursors.No;
            this.lblLabelNrBuc.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblLabelNrBuc.ForeColor = System.Drawing.Color.Black;
            this.lblLabelNrBuc.Location = new System.Drawing.Point(3, 145);
            this.lblLabelNrBuc.Name = "lblLabelNrBuc";
            this.lblLabelNrBuc.Size = new System.Drawing.Size(73, 17);
            this.lblLabelNrBuc.TabIndex = 56;
            this.lblLabelNrBuc.Text = "Nr Bucati :";
            // 
            // lblLabelCalitate
            // 
            this.lblLabelCalitate.AutoSize = true;
            this.lblLabelCalitate.Cursor = System.Windows.Forms.Cursors.No;
            this.lblLabelCalitate.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblLabelCalitate.ForeColor = System.Drawing.Color.Black;
            this.lblLabelCalitate.Location = new System.Drawing.Point(3, 121);
            this.lblLabelCalitate.Name = "lblLabelCalitate";
            this.lblLabelCalitate.Size = new System.Drawing.Size(63, 17);
            this.lblLabelCalitate.TabIndex = 55;
            this.lblLabelCalitate.Text = "Calitate :";
            // 
            // lblLabelFurnizor
            // 
            this.lblLabelFurnizor.AutoSize = true;
            this.lblLabelFurnizor.Cursor = System.Windows.Forms.Cursors.No;
            this.lblLabelFurnizor.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblLabelFurnizor.ForeColor = System.Drawing.Color.Black;
            this.lblLabelFurnizor.Location = new System.Drawing.Point(3, 104);
            this.lblLabelFurnizor.Name = "lblLabelFurnizor";
            this.lblLabelFurnizor.Size = new System.Drawing.Size(67, 17);
            this.lblLabelFurnizor.TabIndex = 54;
            this.lblLabelFurnizor.Text = "Furnizor :";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.No;
            this.label3.Font = new System.Drawing.Font("Nirmala UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(322, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 30);
            this.label3.TabIndex = 54;
            this.label3.Text = "Date Generale";
            // 
            // tbNrBucati
            // 
            this.tbNrBucati.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNrBucati.Location = new System.Drawing.Point(318, 163);
            this.tbNrBucati.Name = "tbNrBucati";
            this.tbNrBucati.Size = new System.Drawing.Size(172, 23);
            this.tbNrBucati.TabIndex = 56;
            // 
            // lblNrBucati
            // 
            this.lblNrBucati.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNrBucati.AutoSize = true;
            this.lblNrBucati.Cursor = System.Windows.Forms.Cursors.No;
            this.lblNrBucati.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNrBucati.ForeColor = System.Drawing.Color.White;
            this.lblNrBucati.Location = new System.Drawing.Point(318, 146);
            this.lblNrBucati.Name = "lblNrBucati";
            this.lblNrBucati.Size = new System.Drawing.Size(92, 17);
            this.lblNrBucati.TabIndex = 55;
            this.lblNrBucati.Text = "Numar Bucati";
            // 
            // tbNrReceptie
            // 
            this.tbNrReceptie.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNrReceptie.Location = new System.Drawing.Point(318, 206);
            this.tbNrReceptie.Name = "tbNrReceptie";
            this.tbNrReceptie.Size = new System.Drawing.Size(172, 23);
            this.tbNrReceptie.TabIndex = 58;
            // 
            // lblNrReceptie
            // 
            this.lblNrReceptie.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNrReceptie.AutoSize = true;
            this.lblNrReceptie.Cursor = System.Windows.Forms.Cursors.No;
            this.lblNrReceptie.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNrReceptie.ForeColor = System.Drawing.Color.White;
            this.lblNrReceptie.Location = new System.Drawing.Point(318, 189);
            this.lblNrReceptie.Name = "lblNrReceptie";
            this.lblNrReceptie.Size = new System.Drawing.Size(106, 17);
            this.lblNrReceptie.TabIndex = 57;
            this.lblNrReceptie.Text = "Numar Receptie";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.No;
            this.label4.Font = new System.Drawing.Font("Nirmala UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(325, 283);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 30);
            this.label4.TabIndex = 59;
            this.label4.Text = "Date Receptie";
            // 
            // lblLungime
            // 
            this.lblLungime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLungime.AutoSize = true;
            this.lblLungime.Cursor = System.Windows.Forms.Cursors.No;
            this.lblLungime.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblLungime.ForeColor = System.Drawing.Color.White;
            this.lblLungime.Location = new System.Drawing.Point(319, 322);
            this.lblLungime.Name = "lblLungime";
            this.lblLungime.Size = new System.Drawing.Size(62, 17);
            this.lblLungime.TabIndex = 61;
            this.lblLungime.Text = "Lungime";
            // 
            // cbLungime
            // 
            this.cbLungime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbLungime.FormattingEnabled = true;
            this.cbLungime.Location = new System.Drawing.Point(317, 339);
            this.cbLungime.Name = "cbLungime";
            this.cbLungime.Size = new System.Drawing.Size(172, 23);
            this.cbLungime.TabIndex = 60;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Cursor = System.Windows.Forms.Cursors.No;
            this.label5.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(495, 382);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 17);
            this.label5.TabIndex = 63;
            this.label5.Text = "Net: ";
            // 
            // Frm_Printer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(790, 516);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblLungime);
            this.Controls.Add(this.cbLungime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbNrReceptie);
            this.Controls.Add(this.lblNrReceptie);
            this.Controls.Add(this.tbNrBucati);
            this.Controls.Add(this.lblNrBucati);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblPrinterDbError);
            this.Controls.Add(this.lblCalitate);
            this.Controls.Add(this.cbCalitate);
            this.Controls.Add(this.lblDiametru);
            this.Controls.Add(this.tbDiametruBrut);
            this.Controls.Add(this.tbNrAviz);
            this.Controls.Add(this.lblNrAviz);
            this.Controls.Add(this.PrinterCalendar);
            this.Controls.Add(this.lblFurnizor);
            this.Controls.Add(this.cbFurnizor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.button_print);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_Printer";
            this.Text = "Frm_Printer";
            this.Load += new System.EventHandler(this.Frm_Printer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button_print;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label label2;
        private ComboBox cbFurnizor;
        private Label lblFurnizor;
        private NewCalendar PrinterCalendar;
        private Label lblNrAviz;
        private TextBox tbNrAviz;
        private TextBox tbDiametruBrut;
        private Label lblDiametru;
        private Label lblCalitate;
        private ComboBox cbCalitate;
        private System.Windows.Forms.Timer timer1;
        private Label lblPrinterDbError;
        private Panel panel1;
        private Label lblLabelNrAviz;
        private Label lblLabelNrBuc;
        private Label lblLabelCalitate;
        private Label lblLabelFurnizor;
        private Label label1;
        private Label label3;
        private TextBox tbNrBucati;
        private Label lblNrBucati;
        private TextBox tbNrReceptie;
        private Label lblNrReceptie;
        private Label label4;
        private Label lblLungime;
        private ComboBox cbLungime;
        private Label label5;
    }
}