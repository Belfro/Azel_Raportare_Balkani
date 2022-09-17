namespace Aplicatie_Scanner
{
    partial class Frm_Scanner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Scanner));
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.cboDevice = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbGUIDScanat = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Btn_Disconnect = new System.Windows.Forms.Button();
            this.lblDiametruNet = new System.Windows.Forms.Label();
            this.lblLungime = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbNrReceptie = new System.Windows.Forms.TextBox();
            this.lblNrReceptie = new System.Windows.Forms.Label();
            this.tbNrBucati = new System.Windows.Forms.TextBox();
            this.lblNrBucati = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCalitate = new System.Windows.Forms.Label();
            this.lblDiametru = new System.Windows.Forms.Label();
            this.tbDiametruBrut = new System.Windows.Forms.TextBox();
            this.tbNrAviz = new System.Windows.Forms.TextBox();
            this.lblNrAviz = new System.Windows.Forms.Label();
            this.lblFurnizor = new System.Windows.Forms.Label();
            this.tbLungime = new System.Windows.Forms.TextBox();
            this.tbFurnizor = new System.Windows.Forms.TextBox();
            this.tbCalitate = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(627, 425);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(101, 90);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 35;
            this.pictureBox2.TabStop = false;
            // 
            // cboDevice
            // 
            this.cboDevice.Location = new System.Drawing.Point(28, 78);
            this.cboDevice.Name = "cboDevice";
            this.cboDevice.Size = new System.Drawing.Size(327, 23);
            this.cboDevice.TabIndex = 36;
            this.cboDevice.SelectedIndexChanged += new System.EventHandler(this.cboDevice_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(100)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.button1.Location = new System.Drawing.Point(552, 77);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 58);
            this.button1.TabIndex = 37;
            this.button1.Text = "Pornire\r\nCamera";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Trigger_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(100)))));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(28, 105);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(327, 320);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 38;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // tbGUIDScanat
            // 
            this.tbGUIDScanat.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbGUIDScanat.Location = new System.Drawing.Point(28, 429);
            this.tbGUIDScanat.Name = "tbGUIDScanat";
            this.tbGUIDScanat.Size = new System.Drawing.Size(327, 24);
            this.tbGUIDScanat.TabIndex = 39;
            this.tbGUIDScanat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Btn_Disconnect
            // 
            this.Btn_Disconnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Disconnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(100)))));
            this.Btn_Disconnect.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Btn_Disconnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Disconnect.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Btn_Disconnect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Btn_Disconnect.Location = new System.Drawing.Point(552, 141);
            this.Btn_Disconnect.Name = "Btn_Disconnect";
            this.Btn_Disconnect.Size = new System.Drawing.Size(125, 58);
            this.Btn_Disconnect.TabIndex = 40;
            this.Btn_Disconnect.Text = "Deconectare";
            this.Btn_Disconnect.UseVisualStyleBackColor = false;
            this.Btn_Disconnect.Click += new System.EventHandler(this.Btn_Disconnect_Click);
            // 
            // lblDiametruNet
            // 
            this.lblDiametruNet.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDiametruNet.AutoSize = true;
            this.lblDiametruNet.Cursor = System.Windows.Forms.Cursors.No;
            this.lblDiametruNet.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDiametruNet.ForeColor = System.Drawing.Color.White;
            this.lblDiametruNet.Location = new System.Drawing.Point(539, 388);
            this.lblDiametruNet.Name = "lblDiametruNet";
            this.lblDiametruNet.Size = new System.Drawing.Size(38, 17);
            this.lblDiametruNet.TabIndex = 80;
            this.lblDiametruNet.Text = "Net: ";
            // 
            // lblLungime
            // 
            this.lblLungime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblLungime.AutoSize = true;
            this.lblLungime.Cursor = System.Windows.Forms.Cursors.No;
            this.lblLungime.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblLungime.ForeColor = System.Drawing.Color.White;
            this.lblLungime.Location = new System.Drawing.Point(363, 328);
            this.lblLungime.Name = "lblLungime";
            this.lblLungime.Size = new System.Drawing.Size(62, 17);
            this.lblLungime.TabIndex = 79;
            this.lblLungime.Text = "Lungime";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.No;
            this.label4.Font = new System.Drawing.Font("Nirmala UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(369, 289);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 30);
            this.label4.TabIndex = 77;
            this.label4.Text = "Date Receptie";
            // 
            // tbNrReceptie
            // 
            this.tbNrReceptie.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbNrReceptie.Location = new System.Drawing.Point(362, 212);
            this.tbNrReceptie.Name = "tbNrReceptie";
            this.tbNrReceptie.Size = new System.Drawing.Size(172, 23);
            this.tbNrReceptie.TabIndex = 76;
            // 
            // lblNrReceptie
            // 
            this.lblNrReceptie.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNrReceptie.AutoSize = true;
            this.lblNrReceptie.Cursor = System.Windows.Forms.Cursors.No;
            this.lblNrReceptie.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNrReceptie.ForeColor = System.Drawing.Color.White;
            this.lblNrReceptie.Location = new System.Drawing.Point(362, 195);
            this.lblNrReceptie.Name = "lblNrReceptie";
            this.lblNrReceptie.Size = new System.Drawing.Size(106, 17);
            this.lblNrReceptie.TabIndex = 75;
            this.lblNrReceptie.Text = "Numar Receptie";
            // 
            // tbNrBucati
            // 
            this.tbNrBucati.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbNrBucati.Location = new System.Drawing.Point(362, 169);
            this.tbNrBucati.Name = "tbNrBucati";
            this.tbNrBucati.Size = new System.Drawing.Size(172, 23);
            this.tbNrBucati.TabIndex = 74;
            // 
            // lblNrBucati
            // 
            this.lblNrBucati.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNrBucati.AutoSize = true;
            this.lblNrBucati.Cursor = System.Windows.Forms.Cursors.No;
            this.lblNrBucati.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNrBucati.ForeColor = System.Drawing.Color.White;
            this.lblNrBucati.Location = new System.Drawing.Point(362, 152);
            this.lblNrBucati.Name = "lblNrBucati";
            this.lblNrBucati.Size = new System.Drawing.Size(92, 17);
            this.lblNrBucati.TabIndex = 73;
            this.lblNrBucati.Text = "Numar Bucati";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.No;
            this.label3.Font = new System.Drawing.Font("Nirmala UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(366, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 30);
            this.label3.TabIndex = 72;
            this.label3.Text = "Date Generale";
            // 
            // lblCalitate
            // 
            this.lblCalitate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCalitate.AutoSize = true;
            this.lblCalitate.Cursor = System.Windows.Forms.Cursors.No;
            this.lblCalitate.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCalitate.ForeColor = System.Drawing.Color.White;
            this.lblCalitate.Location = new System.Drawing.Point(363, 413);
            this.lblCalitate.Name = "lblCalitate";
            this.lblCalitate.Size = new System.Drawing.Size(55, 17);
            this.lblCalitate.TabIndex = 71;
            this.lblCalitate.Text = "Calitate";
            // 
            // lblDiametru
            // 
            this.lblDiametru.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDiametru.AutoSize = true;
            this.lblDiametru.Cursor = System.Windows.Forms.Cursors.No;
            this.lblDiametru.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDiametru.ForeColor = System.Drawing.Color.White;
            this.lblDiametru.Location = new System.Drawing.Point(362, 371);
            this.lblDiametru.Name = "lblDiametru";
            this.lblDiametru.Size = new System.Drawing.Size(96, 17);
            this.lblDiametru.TabIndex = 69;
            this.lblDiametru.Text = "Diametru Brut";
            // 
            // tbDiametruBrut
            // 
            this.tbDiametruBrut.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbDiametruBrut.Location = new System.Drawing.Point(361, 387);
            this.tbDiametruBrut.Name = "tbDiametruBrut";
            this.tbDiametruBrut.Size = new System.Drawing.Size(172, 23);
            this.tbDiametruBrut.TabIndex = 68;
            // 
            // tbNrAviz
            // 
            this.tbNrAviz.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbNrAviz.Location = new System.Drawing.Point(362, 124);
            this.tbNrAviz.Name = "tbNrAviz";
            this.tbNrAviz.Size = new System.Drawing.Size(172, 23);
            this.tbNrAviz.TabIndex = 67;
            // 
            // lblNrAviz
            // 
            this.lblNrAviz.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNrAviz.AutoSize = true;
            this.lblNrAviz.Cursor = System.Windows.Forms.Cursors.No;
            this.lblNrAviz.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNrAviz.ForeColor = System.Drawing.Color.White;
            this.lblNrAviz.Location = new System.Drawing.Point(362, 107);
            this.lblNrAviz.Name = "lblNrAviz";
            this.lblNrAviz.Size = new System.Drawing.Size(80, 17);
            this.lblNrAviz.TabIndex = 66;
            this.lblNrAviz.Text = "Numar Aviz";
            // 
            // lblFurnizor
            // 
            this.lblFurnizor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFurnizor.AutoSize = true;
            this.lblFurnizor.Cursor = System.Windows.Forms.Cursors.No;
            this.lblFurnizor.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblFurnizor.ForeColor = System.Drawing.Color.White;
            this.lblFurnizor.Location = new System.Drawing.Point(362, 61);
            this.lblFurnizor.Name = "lblFurnizor";
            this.lblFurnizor.Size = new System.Drawing.Size(59, 17);
            this.lblFurnizor.TabIndex = 65;
            this.lblFurnizor.Text = "Furnizor";
            // 
            // tbLungime
            // 
            this.tbLungime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbLungime.Location = new System.Drawing.Point(361, 345);
            this.tbLungime.Name = "tbLungime";
            this.tbLungime.Size = new System.Drawing.Size(172, 23);
            this.tbLungime.TabIndex = 81;
            // 
            // tbFurnizor
            // 
            this.tbFurnizor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbFurnizor.Location = new System.Drawing.Point(361, 81);
            this.tbFurnizor.Name = "tbFurnizor";
            this.tbFurnizor.Size = new System.Drawing.Size(172, 23);
            this.tbFurnizor.TabIndex = 82;
            // 
            // tbCalitate
            // 
            this.tbCalitate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbCalitate.Location = new System.Drawing.Point(361, 430);
            this.tbCalitate.Name = "tbCalitate";
            this.tbCalitate.Size = new System.Drawing.Size(172, 23);
            this.tbCalitate.TabIndex = 83;
            // 
            // Frm_Scanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(740, 516);
            this.Controls.Add(this.tbCalitate);
            this.Controls.Add(this.tbFurnizor);
            this.Controls.Add(this.tbLungime);
            this.Controls.Add(this.lblDiametruNet);
            this.Controls.Add(this.lblLungime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbNrReceptie);
            this.Controls.Add(this.lblNrReceptie);
            this.Controls.Add(this.tbNrBucati);
            this.Controls.Add(this.lblNrBucati);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblCalitate);
            this.Controls.Add(this.lblDiametru);
            this.Controls.Add(this.tbDiametruBrut);
            this.Controls.Add(this.tbNrAviz);
            this.Controls.Add(this.lblNrAviz);
            this.Controls.Add(this.lblFurnizor);
            this.Controls.Add(this.Btn_Disconnect);
            this.Controls.Add(this.cboDevice);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tbGUIDScanat);
            this.Controls.Add(this.pictureBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_Scanner";
            this.Text = "Frm_Scanner";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Scanner_FormClosing);
            this.Load += new System.EventHandler(this.Frm_Scanner_Load);
            this.Leave += new System.EventHandler(this.Frm_Scanner_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox2;
        private ComboBox cboDevice;
        private Button button1;
        private PictureBox pictureBox1;
        private TextBox tbGUIDScanat;
        private System.Windows.Forms.Timer timer1;
        private Button Btn_Disconnect;
        private Label lblDiametruNet;
        private Label lblLungime;
        private Label label4;
        private TextBox tbNrReceptie;
        private Label lblNrReceptie;
        private TextBox tbNrBucati;
        private Label lblNrBucati;
        private Label label3;
        private Label lblCalitate;
        private Label lblDiametru;
        private TextBox tbDiametruBrut;
        private TextBox tbNrAviz;
        private Label lblNrAviz;
        private Label lblFurnizor;
        private TextBox tbLungime;
        private TextBox tbFurnizor;
        private TextBox tbCalitate;
    }
}