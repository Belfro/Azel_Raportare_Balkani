namespace Aplicatie_Scanner
{
    partial class Frm_Settings
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
            this.Btn_Add_Furnizor = new System.Windows.Forms.Button();
            this.tbFurnizori = new System.Windows.Forms.TextBox();
            this.dataGridViewFurnizori = new System.Windows.Forms.DataGridView();
            this.Nume_Furnizor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnDeleteFurnizor = new System.Windows.Forms.Button();
            this.btnDeleteCalitate = new System.Windows.Forms.Button();
            this.dataGridViewCalitate = new System.Windows.Forms.DataGridView();
            this.Calitate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbCalitate = new System.Windows.Forms.TextBox();
            this.Btn_Add_Calitate = new System.Windows.Forms.Button();
            this.btnDeleteLungime = new System.Windows.Forms.Button();
            this.dataGridViewLungime = new System.Windows.Forms.DataGridView();
            this.Lungime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbLungimi = new System.Windows.Forms.TextBox();
            this.Btn_Add_Lungimi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFurnizori)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCalitate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLungime)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_Add_Furnizor
            // 
            this.Btn_Add_Furnizor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Add_Furnizor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(100)))));
            this.Btn_Add_Furnizor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Add_Furnizor.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Btn_Add_Furnizor.ForeColor = System.Drawing.Color.Black;
            this.Btn_Add_Furnizor.Location = new System.Drawing.Point(199, 55);
            this.Btn_Add_Furnizor.Margin = new System.Windows.Forms.Padding(0);
            this.Btn_Add_Furnizor.Name = "Btn_Add_Furnizor";
            this.Btn_Add_Furnizor.Size = new System.Drawing.Size(77, 29);
            this.Btn_Add_Furnizor.TabIndex = 36;
            this.Btn_Add_Furnizor.Text = "Add";
            this.Btn_Add_Furnizor.UseVisualStyleBackColor = false;
            this.Btn_Add_Furnizor.Click += new System.EventHandler(this.Btn_Add_Furnizor_Click);
            // 
            // tbFurnizori
            // 
            this.tbFurnizori.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFurnizori.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbFurnizori.Location = new System.Drawing.Point(22, 55);
            this.tbFurnizori.Margin = new System.Windows.Forms.Padding(0);
            this.tbFurnizori.Name = "tbFurnizori";
            this.tbFurnizori.Size = new System.Drawing.Size(177, 29);
            this.tbFurnizori.TabIndex = 46;
            // 
            // dataGridViewFurnizori
            // 
            this.dataGridViewFurnizori.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(100)))));
            this.dataGridViewFurnizori.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFurnizori.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nume_Furnizor});
            this.dataGridViewFurnizori.Location = new System.Drawing.Point(22, 87);
            this.dataGridViewFurnizori.Name = "dataGridViewFurnizori";
            this.dataGridViewFurnizori.RowTemplate.Height = 25;
            this.dataGridViewFurnizori.Size = new System.Drawing.Size(254, 379);
            this.dataGridViewFurnizori.TabIndex = 47;
            this.dataGridViewFurnizori.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Nume_Furnizor
            // 
            this.Nume_Furnizor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nume_Furnizor.HeaderText = "Nume_Furnizor";
            this.Nume_Furnizor.Name = "Nume_Furnizor";
            // 
            // timer1
            // 
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnDeleteFurnizor
            // 
            this.btnDeleteFurnizor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteFurnizor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(100)))));
            this.btnDeleteFurnizor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteFurnizor.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDeleteFurnizor.ForeColor = System.Drawing.Color.Red;
            this.btnDeleteFurnizor.Location = new System.Drawing.Point(196, 469);
            this.btnDeleteFurnizor.Margin = new System.Windows.Forms.Padding(0);
            this.btnDeleteFurnizor.Name = "btnDeleteFurnizor";
            this.btnDeleteFurnizor.Size = new System.Drawing.Size(80, 29);
            this.btnDeleteFurnizor.TabIndex = 48;
            this.btnDeleteFurnizor.Text = "Delete";
            this.btnDeleteFurnizor.UseVisualStyleBackColor = false;
            this.btnDeleteFurnizor.Click += new System.EventHandler(this.btnDeleteFurnizor_Click);
            // 
            // btnDeleteCalitate
            // 
            this.btnDeleteCalitate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteCalitate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(100)))));
            this.btnDeleteCalitate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteCalitate.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDeleteCalitate.ForeColor = System.Drawing.Color.Red;
            this.btnDeleteCalitate.Location = new System.Drawing.Point(462, 469);
            this.btnDeleteCalitate.Margin = new System.Windows.Forms.Padding(0);
            this.btnDeleteCalitate.Name = "btnDeleteCalitate";
            this.btnDeleteCalitate.Size = new System.Drawing.Size(80, 29);
            this.btnDeleteCalitate.TabIndex = 52;
            this.btnDeleteCalitate.Text = "Delete";
            this.btnDeleteCalitate.UseVisualStyleBackColor = false;
            this.btnDeleteCalitate.Click += new System.EventHandler(this.btnDeleteCalitate_Click);
            // 
            // dataGridViewCalitate
            // 
            this.dataGridViewCalitate.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(100)))));
            this.dataGridViewCalitate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCalitate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Calitate});
            this.dataGridViewCalitate.Location = new System.Drawing.Point(288, 88);
            this.dataGridViewCalitate.Name = "dataGridViewCalitate";
            this.dataGridViewCalitate.RowTemplate.Height = 25;
            this.dataGridViewCalitate.Size = new System.Drawing.Size(254, 379);
            this.dataGridViewCalitate.TabIndex = 51;
            this.dataGridViewCalitate.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCalitate_CellContentClick);
            // 
            // Calitate
            // 
            this.Calitate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Calitate.HeaderText = "Calitate";
            this.Calitate.Name = "Calitate";
            // 
            // tbCalitate
            // 
            this.tbCalitate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCalitate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbCalitate.Location = new System.Drawing.Point(288, 55);
            this.tbCalitate.Margin = new System.Windows.Forms.Padding(0);
            this.tbCalitate.Name = "tbCalitate";
            this.tbCalitate.Size = new System.Drawing.Size(177, 29);
            this.tbCalitate.TabIndex = 50;
            // 
            // Btn_Add_Calitate
            // 
            this.Btn_Add_Calitate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Add_Calitate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(100)))));
            this.Btn_Add_Calitate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Add_Calitate.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Btn_Add_Calitate.ForeColor = System.Drawing.Color.Black;
            this.Btn_Add_Calitate.Location = new System.Drawing.Point(465, 55);
            this.Btn_Add_Calitate.Margin = new System.Windows.Forms.Padding(0);
            this.Btn_Add_Calitate.Name = "Btn_Add_Calitate";
            this.Btn_Add_Calitate.Size = new System.Drawing.Size(77, 29);
            this.Btn_Add_Calitate.TabIndex = 49;
            this.Btn_Add_Calitate.Text = "Add";
            this.Btn_Add_Calitate.UseVisualStyleBackColor = false;
            this.Btn_Add_Calitate.Click += new System.EventHandler(this.Btn_Add_Calitate_Click);
            // 
            // btnDeleteLungime
            // 
            this.btnDeleteLungime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteLungime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(100)))));
            this.btnDeleteLungime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteLungime.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDeleteLungime.ForeColor = System.Drawing.Color.Red;
            this.btnDeleteLungime.Location = new System.Drawing.Point(727, 468);
            this.btnDeleteLungime.Margin = new System.Windows.Forms.Padding(0);
            this.btnDeleteLungime.Name = "btnDeleteLungime";
            this.btnDeleteLungime.Size = new System.Drawing.Size(80, 29);
            this.btnDeleteLungime.TabIndex = 56;
            this.btnDeleteLungime.Text = "Delete";
            this.btnDeleteLungime.UseVisualStyleBackColor = false;
            this.btnDeleteLungime.Click += new System.EventHandler(this.btnDeleteLungime_Click);
            // 
            // dataGridViewLungime
            // 
            this.dataGridViewLungime.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(100)))));
            this.dataGridViewLungime.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLungime.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Lungime});
            this.dataGridViewLungime.Location = new System.Drawing.Point(553, 87);
            this.dataGridViewLungime.Name = "dataGridViewLungime";
            this.dataGridViewLungime.RowTemplate.Height = 25;
            this.dataGridViewLungime.Size = new System.Drawing.Size(254, 379);
            this.dataGridViewLungime.TabIndex = 55;
            // 
            // Lungime
            // 
            this.Lungime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Lungime.HeaderText = "Lungime";
            this.Lungime.Name = "Lungime";
            // 
            // tbLungimi
            // 
            this.tbLungimi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLungimi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbLungimi.Location = new System.Drawing.Point(553, 54);
            this.tbLungimi.Margin = new System.Windows.Forms.Padding(0);
            this.tbLungimi.Name = "tbLungimi";
            this.tbLungimi.Size = new System.Drawing.Size(177, 29);
            this.tbLungimi.TabIndex = 54;
            // 
            // Btn_Add_Lungimi
            // 
            this.Btn_Add_Lungimi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Add_Lungimi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(100)))));
            this.Btn_Add_Lungimi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Add_Lungimi.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Btn_Add_Lungimi.ForeColor = System.Drawing.Color.Black;
            this.Btn_Add_Lungimi.Location = new System.Drawing.Point(730, 54);
            this.Btn_Add_Lungimi.Margin = new System.Windows.Forms.Padding(0);
            this.Btn_Add_Lungimi.Name = "Btn_Add_Lungimi";
            this.Btn_Add_Lungimi.Size = new System.Drawing.Size(77, 29);
            this.Btn_Add_Lungimi.TabIndex = 53;
            this.Btn_Add_Lungimi.Text = "Add";
            this.Btn_Add_Lungimi.UseVisualStyleBackColor = false;
            this.Btn_Add_Lungimi.Click += new System.EventHandler(this.Btn_Add_Lungimi_Click);
            // 
            // Frm_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(867, 574);
            this.Controls.Add(this.btnDeleteLungime);
            this.Controls.Add(this.dataGridViewLungime);
            this.Controls.Add(this.tbLungimi);
            this.Controls.Add(this.Btn_Add_Lungimi);
            this.Controls.Add(this.btnDeleteCalitate);
            this.Controls.Add(this.dataGridViewCalitate);
            this.Controls.Add(this.tbCalitate);
            this.Controls.Add(this.Btn_Add_Calitate);
            this.Controls.Add(this.btnDeleteFurnizor);
            this.Controls.Add(this.dataGridViewFurnizori);
            this.Controls.Add(this.tbFurnizori);
            this.Controls.Add(this.Btn_Add_Furnizor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_Settings";
            this.Text = "Frm_Settings";
            this.Load += new System.EventHandler(this.Frm_Settings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFurnizori)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCalitate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLungime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button Btn_Add_Furnizor;
        private TextBox tbFurnizori;
        private DataGridView dataGridViewFurnizori;
        private DataGridViewTextBoxColumn Nume_Furnizor;
        private System.Windows.Forms.Timer timer1;
        private Button btnDeleteFurnizor;
        private Button btnDeleteCalitate;
        private DataGridView dataGridViewCalitate;
        private TextBox tbCalitate;
        private Button Btn_Add_Calitate;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private Button btnDeleteLungime;
        private DataGridView dataGridViewLungime;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private TextBox tbLungimi;
        private Button Btn_Add_Lungimi;
        private DataGridViewTextBoxColumn Calitate;
        private DataGridViewTextBoxColumn Lungime;
    }
}