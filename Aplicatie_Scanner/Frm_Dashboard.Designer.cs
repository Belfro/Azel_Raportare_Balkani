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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Timp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantitate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.newCalendar1 = new Aplicatie_Scanner.NewCalendar();
            this.Search = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Data,
            this.Timp,
            this.Barcode,
            this.Cantitate});
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView1.Location = new System.Drawing.Point(9, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(467, 472);
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
            // Barcode
            // 
            this.Barcode.HeaderText = "Furnizor";
            this.Barcode.Name = "Barcode";
            // 
            // Cantitate
            // 
            this.Cantitate.HeaderText = "Calitate";
            this.Cantitate.Name = "Cantitate";
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
            this.newCalendar1.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.newCalendar1.Location = new System.Drawing.Point(476, 12);
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
            this.Search.Location = new System.Drawing.Point(476, 208);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(234, 50);
            this.Search.TabIndex = 38;
            this.Search.Text = "Search";
            this.Search.UseVisualStyleBackColor = false;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // Frm_Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(740, 516);
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

        }


        #endregion
        private PictureBox pictureBox2;
        private DataGridView dataGridView1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private NewCalendar newCalendar1;
        private Button Search;
        private DataGridViewTextBoxColumn Data;
        private DataGridViewTextBoxColumn Timp;
        private DataGridViewTextBoxColumn Barcode;
        private DataGridViewTextBoxColumn Cantitate;
    }
            
}
    
