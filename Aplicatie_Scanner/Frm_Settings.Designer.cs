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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Nume_Furnizor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnDeleteFurnizor = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_Add_Furnizor
            // 
            this.Btn_Add_Furnizor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Add_Furnizor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(100)))));
            this.Btn_Add_Furnizor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Add_Furnizor.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Btn_Add_Furnizor.ForeColor = System.Drawing.Color.Black;
            this.Btn_Add_Furnizor.Location = new System.Drawing.Point(203, 53);
            this.Btn_Add_Furnizor.Margin = new System.Windows.Forms.Padding(0);
            this.Btn_Add_Furnizor.Name = "Btn_Add_Furnizor";
            this.Btn_Add_Furnizor.Size = new System.Drawing.Size(95, 29);
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
            this.tbFurnizori.Location = new System.Drawing.Point(22, 53);
            this.tbFurnizori.Margin = new System.Windows.Forms.Padding(0);
            this.tbFurnizori.Name = "tbFurnizori";
            this.tbFurnizori.Size = new System.Drawing.Size(172, 29);
            this.tbFurnizori.TabIndex = 46;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(100)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nume_Furnizor});
            this.dataGridView1.Location = new System.Drawing.Point(22, 86);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(273, 379);
            this.dataGridView1.TabIndex = 47;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
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
            this.btnDeleteFurnizor.Location = new System.Drawing.Point(298, 414);
            this.btnDeleteFurnizor.Margin = new System.Windows.Forms.Padding(0);
            this.btnDeleteFurnizor.Name = "btnDeleteFurnizor";
            this.btnDeleteFurnizor.Size = new System.Drawing.Size(95, 51);
            this.btnDeleteFurnizor.TabIndex = 48;
            this.btnDeleteFurnizor.Text = "Delete";
            this.btnDeleteFurnizor.UseVisualStyleBackColor = false;
            this.btnDeleteFurnizor.Click += new System.EventHandler(this.btnDeleteFurnizor_Click);
            // 
            // Frm_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(733, 477);
            this.Controls.Add(this.btnDeleteFurnizor);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.tbFurnizori);
            this.Controls.Add(this.Btn_Add_Furnizor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_Settings";
            this.Text = "Frm_Settings";
            this.Load += new System.EventHandler(this.Frm_Settings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button Btn_Add_Furnizor;
        private TextBox tbFurnizori;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Nume_Furnizor;
        private System.Windows.Forms.Timer timer1;
        private Button btnDeleteFurnizor;
    }
}