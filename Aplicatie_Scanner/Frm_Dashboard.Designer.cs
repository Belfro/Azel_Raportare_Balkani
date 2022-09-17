namespace Aplicatie_Scanner
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Timp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Locatie_Actuala = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Furnizor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numar_Aviz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numar_Bucati = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numar_Receptie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lungime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Diametru = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Calitate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.newCalendar1 = new Aplicatie_Scanner.NewCalendar();
            this.Search = new System.Windows.Forms.Button();
            this.checkBoxFurnizor = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbFurnizor = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbZonaSelectie = new System.Windows.Forms.ComboBox();
            this.cbCalitate = new System.Windows.Forms.ComboBox();
            this.checkBoxCalitate = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(677, 425);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(101, 90);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 34;
            this.pictureBox2.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Data,
            this.Timp,
            this.Locatie_Actuala,
            this.Furnizor,
            this.Numar_Aviz,
            this.Numar_Bucati,
            this.Numar_Receptie,
            this.Lungime,
            this.Diametru,
            this.Calitate});
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView1.Location = new System.Drawing.Point(9, 12);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(745, 278);
            this.dataGridView1.TabIndex = 35;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Data
            // 
            this.Data.FillWeight = 80F;
            this.Data.HeaderText = "Data";
            this.Data.Name = "Data";
            // 
            // Timp
            // 
            this.Timp.FillWeight = 80F;
            this.Timp.HeaderText = "Timp";
            this.Timp.Name = "Timp";
            // 
            // Locatie_Actuala
            // 
            this.Locatie_Actuala.HeaderText = "Locatie Actuala";
            this.Locatie_Actuala.Name = "Locatie_Actuala";
            // 
            // Furnizor
            // 
            this.Furnizor.HeaderText = "Furnizor";
            this.Furnizor.Name = "Furnizor";
            // 
            // Numar_Aviz
            // 
            this.Numar_Aviz.HeaderText = "Numar Aviz";
            this.Numar_Aviz.Name = "Numar_Aviz";
            // 
            // Numar_Bucati
            // 
            this.Numar_Bucati.FillWeight = 40F;
            this.Numar_Bucati.HeaderText = "Numar Bucati";
            this.Numar_Bucati.Name = "Numar_Bucati";
            // 
            // Numar_Receptie
            // 
            this.Numar_Receptie.HeaderText = "Numar Receptie";
            this.Numar_Receptie.Name = "Numar_Receptie";
            // 
            // Lungime
            // 
            this.Lungime.FillWeight = 40F;
            this.Lungime.HeaderText = "Lungime";
            this.Lungime.Name = "Lungime";
            // 
            // Diametru
            // 
            this.Diametru.FillWeight = 40F;
            this.Diametru.HeaderText = "Diametru";
            this.Diametru.Name = "Diametru";
            // 
            // Calitate
            // 
            this.Calitate.HeaderText = "Calitate";
            this.Calitate.Name = "Calitate";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // newCalendar1
            // 
            this.newCalendar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.newCalendar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(100)))));
            this.newCalendar1.FirstDayOfWeek = System.Windows.Forms.Day.Monday;
            this.newCalendar1.Font = new System.Drawing.Font("Nirmala UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.newCalendar1.Location = new System.Drawing.Point(9, 290);
            this.newCalendar1.Margin = new System.Windows.Forms.Padding(0);
            this.newCalendar1.MaxSelectionCount = 365;
            this.newCalendar1.Name = "newCalendar1";
            this.newCalendar1.TabIndex = 37;
            this.newCalendar1.TitleBackColor = System.Drawing.Color.White;
            // 
            // Search
            // 
            this.Search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Search.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(100)))));
            this.Search.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Search.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Search.ForeColor = System.Drawing.Color.White;
            this.Search.Location = new System.Drawing.Point(9, 453);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(213, 50);
            this.Search.TabIndex = 38;
            this.Search.Text = "Search";
            this.Search.UseVisualStyleBackColor = false;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // checkBoxFurnizor
            // 
            this.checkBoxFurnizor.AutoSize = true;
            this.checkBoxFurnizor.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxFurnizor.ForeColor = System.Drawing.Color.White;
            this.checkBoxFurnizor.Location = new System.Drawing.Point(248, 359);
            this.checkBoxFurnizor.Name = "checkBoxFurnizor";
            this.checkBoxFurnizor.Size = new System.Drawing.Size(81, 24);
            this.checkBoxFurnizor.TabIndex = 39;
            this.checkBoxFurnizor.Text = "Furnizor";
            this.checkBoxFurnizor.UseVisualStyleBackColor = true;
            this.checkBoxFurnizor.CheckedChanged += new System.EventHandler(this.checkBoxFurnizor_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(242, 336);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 20);
            this.label1.TabIndex = 40;
            this.label1.Text = "Cautare Dupa:";
            // 
            // cbFurnizor
            // 
            this.cbFurnizor.FormattingEnabled = true;
            this.cbFurnizor.Location = new System.Drawing.Point(335, 360);
            this.cbFurnizor.Name = "cbFurnizor";
            this.cbFurnizor.Size = new System.Drawing.Size(139, 23);
            this.cbFurnizor.TabIndex = 41;
            this.cbFurnizor.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(242, 304);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 20);
            this.label2.TabIndex = 42;
            this.label2.Text = "Locatie:";
            // 
            // cbZonaSelectie
            // 
            this.cbZonaSelectie.FormattingEnabled = true;
            this.cbZonaSelectie.Items.AddRange(new object[] {
            "Etichete Generate",
            "Linie Productie 1",
            "Linie Productie 2",
            "Linie Productie 3"});
            this.cbZonaSelectie.Location = new System.Drawing.Point(311, 303);
            this.cbZonaSelectie.Name = "cbZonaSelectie";
            this.cbZonaSelectie.Size = new System.Drawing.Size(163, 23);
            this.cbZonaSelectie.TabIndex = 43;
            // 
            // cbCalitate
            // 
            this.cbCalitate.FormattingEnabled = true;
            this.cbCalitate.Location = new System.Drawing.Point(335, 390);
            this.cbCalitate.Name = "cbCalitate";
            this.cbCalitate.Size = new System.Drawing.Size(139, 23);
            this.cbCalitate.TabIndex = 45;
            this.cbCalitate.Visible = false;
            // 
            // checkBoxCalitate
            // 
            this.checkBoxCalitate.AutoSize = true;
            this.checkBoxCalitate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxCalitate.ForeColor = System.Drawing.Color.White;
            this.checkBoxCalitate.Location = new System.Drawing.Point(248, 389);
            this.checkBoxCalitate.Name = "checkBoxCalitate";
            this.checkBoxCalitate.Size = new System.Drawing.Size(79, 24);
            this.checkBoxCalitate.TabIndex = 44;
            this.checkBoxCalitate.Text = "Calitate";
            this.checkBoxCalitate.UseVisualStyleBackColor = true;
            this.checkBoxCalitate.CheckedChanged += new System.EventHandler(this.checkBoxCalitate_CheckedChanged);
            // 
            // Frm_Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(790, 516);
            this.Controls.Add(this.cbCalitate);
            this.Controls.Add(this.checkBoxCalitate);
            this.Controls.Add(this.cbZonaSelectie);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbFurnizor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBoxFurnizor);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.newCalendar1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pictureBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_Dashboard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Dashboard_FormClosing);
            this.Load += new System.EventHandler(this.Frm_Dashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private PictureBox pictureBox2;
        private DataGridView dataGridView1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private NewCalendar newCalendar1;
        private Button Search;
        private CheckBox checkBoxFurnizor;
        private Label label1;
        private ComboBox cbFurnizor;
        private DataGridViewTextBoxColumn Data;
        private DataGridViewTextBoxColumn Timp;
        private DataGridViewTextBoxColumn Locatie_Actuala;
        private DataGridViewTextBoxColumn Furnizor;
        private DataGridViewTextBoxColumn Numar_Aviz;
        private DataGridViewTextBoxColumn Numar_Bucati;
        private DataGridViewTextBoxColumn Numar_Receptie;
        private DataGridViewTextBoxColumn Lungime;
        private DataGridViewTextBoxColumn Diametru;
        private DataGridViewTextBoxColumn Calitate;
        private Label label2;
        private ComboBox cbZonaSelectie;
        private ComboBox cbCalitate;
        private CheckBox checkBoxCalitate;
    }
            
}
    
