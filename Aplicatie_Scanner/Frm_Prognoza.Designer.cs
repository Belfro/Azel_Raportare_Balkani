namespace Azel_Raportare_Balkani
{
    partial class Frm_Prognoza
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Prognoza));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            pictureBox2 = new PictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            dataGridView1 = new DataGridView();
            Data = new DataGridViewTextBoxColumn();
            Timp = new DataGridViewTextBoxColumn();
            Cuntu_Grup_1 = new DataGridViewTextBoxColumn();
            Cuntu_Grup_2 = new DataGridViewTextBoxColumn();
            Craiu_1_Grup_1 = new DataGridViewTextBoxColumn();
            Craiu_1_Grup_2 = new DataGridViewTextBoxColumn();
            Craiu_2_Grup_1 = new DataGridViewTextBoxColumn();
            Craiu_2_Grup_2 = new DataGridViewTextBoxColumn();
            Sebesel_1_Grup_1 = new DataGridViewTextBoxColumn();
            Sebesel_1_Grup_2 = new DataGridViewTextBoxColumn();
            Sebesel_2_Grup_1 = new DataGridViewTextBoxColumn();
            Sebesel_2_Grup_2 = new DataGridViewTextBoxColumn();
            Cornereva = new DataGridViewTextBoxColumn();
            Total = new DataGridViewTextBoxColumn();
            dataGridView2 = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn9 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn11 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn13 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn14 = new DataGridViewTextBoxColumn();
            BtnSearch = new Button();
            newCalendar1 = new NewCalendar();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
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
            pictureBox2.TabIndex = 35;
            pictureBox2.TabStop = false;
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
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
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Data, Timp, Cuntu_Grup_1, Cuntu_Grup_2, Craiu_1_Grup_1, Craiu_1_Grup_2, Craiu_2_Grup_1, Craiu_2_Grup_2, Sebesel_1_Grup_1, Sebesel_1_Grup_2, Sebesel_2_Grup_1, Sebesel_2_Grup_2, Cornereva, Total });
            dataGridView1.GridColor = SystemColors.ControlLight;
            dataGridView1.Location = new Point(6, 9);
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
            dataGridView1.Size = new Size(637, 413);
            dataGridView1.TabIndex = 36;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Data
            // 
            Data.FillWeight = 130F;
            Data.HeaderText = "Data";
            Data.Name = "Data";
            // 
            // Timp
            // 
            Timp.FillWeight = 130F;
            Timp.HeaderText = "Timp";
            Timp.Name = "Timp";
            // 
            // Cuntu_Grup_1
            // 
            Cuntu_Grup_1.HeaderText = "Cuntu Grup 1";
            Cuntu_Grup_1.Name = "Cuntu_Grup_1";
            // 
            // Cuntu_Grup_2
            // 
            Cuntu_Grup_2.HeaderText = "Cuntu Grup 2";
            Cuntu_Grup_2.Name = "Cuntu_Grup_2";
            // 
            // Craiu_1_Grup_1
            // 
            Craiu_1_Grup_1.HeaderText = "Craiu 1 Grup 1";
            Craiu_1_Grup_1.Name = "Craiu_1_Grup_1";
            // 
            // Craiu_1_Grup_2
            // 
            Craiu_1_Grup_2.HeaderText = "Craiu 1 Grup 2";
            Craiu_1_Grup_2.Name = "Craiu_1_Grup_2";
            // 
            // Craiu_2_Grup_1
            // 
            Craiu_2_Grup_1.HeaderText = "Craiu 2 Grup 1";
            Craiu_2_Grup_1.Name = "Craiu_2_Grup_1";
            // 
            // Craiu_2_Grup_2
            // 
            Craiu_2_Grup_2.HeaderText = "Craiu 2 Grup 2";
            Craiu_2_Grup_2.Name = "Craiu_2_Grup_2";
            // 
            // Sebesel_1_Grup_1
            // 
            Sebesel_1_Grup_1.HeaderText = "Sebesel 1 Grup 1";
            Sebesel_1_Grup_1.Name = "Sebesel_1_Grup_1";
            // 
            // Sebesel_1_Grup_2
            // 
            Sebesel_1_Grup_2.HeaderText = "Sebesel 1 Grup 2";
            Sebesel_1_Grup_2.Name = "Sebesel_1_Grup_2";
            // 
            // Sebesel_2_Grup_1
            // 
            Sebesel_2_Grup_1.HeaderText = "Sebesel 2 Grup 1";
            Sebesel_2_Grup_1.Name = "Sebesel_2_Grup_1";
            // 
            // Sebesel_2_Grup_2
            // 
            Sebesel_2_Grup_2.HeaderText = "Sebesel 2 Grup 1";
            Sebesel_2_Grup_2.Name = "Sebesel_2_Grup_2";
            // 
            // Cornereva
            // 
            Cornereva.HeaderText = "Cornereva";
            Cornereva.Name = "Cornereva";
            // 
            // Total
            // 
            Total.HeaderText = "Total";
            Total.Name = "Total";
            // 
            // dataGridView2
            // 
            dataGridView2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.BackgroundColor = Color.FromArgb(8, 35, 50);
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn7, dataGridViewTextBoxColumn9, dataGridViewTextBoxColumn11, dataGridViewTextBoxColumn13, dataGridViewTextBoxColumn14 });
            dataGridView2.GridColor = SystemColors.ControlLight;
            dataGridView2.Location = new Point(648, 9);
            dataGridView2.Margin = new Padding(0);
            dataGridView2.Name = "dataGridView2";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dataGridView2.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridView2.RowTemplate.Height = 25;
            dataGridView2.Size = new Size(637, 413);
            dataGridView2.TabIndex = 37;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.FillWeight = 130F;
            dataGridViewTextBoxColumn1.HeaderText = "Data";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.FillWeight = 130F;
            dataGridViewTextBoxColumn2.HeaderText = "Timp";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Cuntu";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "Craiu 1";
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewTextBoxColumn7.HeaderText = "Craiu 2";
            dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn9
            // 
            dataGridViewTextBoxColumn9.HeaderText = "Sebesel 1";
            dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn11
            // 
            dataGridViewTextBoxColumn11.HeaderText = "Sebesel 2";
            dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // dataGridViewTextBoxColumn13
            // 
            dataGridViewTextBoxColumn13.HeaderText = "Cornereva";
            dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            // 
            // dataGridViewTextBoxColumn14
            // 
            dataGridViewTextBoxColumn14.HeaderText = "Total";
            dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            // 
            // BtnSearch
            // 
            BtnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnSearch.BackColor = Color.FromArgb(8, 35, 50);
            BtnSearch.FlatAppearance.BorderColor = Color.White;
            BtnSearch.FlatStyle = FlatStyle.Flat;
            BtnSearch.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            BtnSearch.ForeColor = Color.White;
            BtnSearch.Location = new Point(539, 615);
            BtnSearch.Name = "BtnSearch";
            BtnSearch.Size = new Size(213, 50);
            BtnSearch.TabIndex = 40;
            BtnSearch.Text = "Search";
            BtnSearch.UseVisualStyleBackColor = false;
            BtnSearch.Click += BtnSearch_Click;
            // 
            // newCalendar1
            // 
            newCalendar1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            newCalendar1.BackColor = Color.FromArgb(8, 35, 50);
            newCalendar1.FirstDayOfWeek = Day.Monday;
            newCalendar1.Font = new Font("Nirmala UI", 8F, FontStyle.Bold, GraphicsUnit.Point);
            newCalendar1.ForeColor = Color.White;
            newCalendar1.Location = new Point(539, 452);
            newCalendar1.Margin = new Padding(0);
            newCalendar1.MaxSelectionCount = 365;
            newCalendar1.Name = "newCalendar1";
            newCalendar1.TabIndex = 41;
            newCalendar1.TitleBackColor = Color.White;
            newCalendar1.TitleForeColor = Color.FromArgb(8, 35, 50);
            newCalendar1.TrailingForeColor = Color.LightGray;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(105, 422);
            label1.Name = "label1";
            label1.Size = new Size(238, 37);
            label1.TabIndex = 42;
            label1.Text = "Ziua Precedenta: ";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(825, 422);
            label2.Name = "label2";
            label2.Size = new Size(233, 37);
            label2.TabIndex = 43;
            label2.Text = "Ziua Urmatoare: ";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Frm_Prognoza
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(35, 65, 82);
            ClientSize = new Size(1290, 674);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(newCalendar1);
            Controls.Add(BtnSearch);
            Controls.Add(dataGridView2);
            Controls.Add(dataGridView1);
            Controls.Add(pictureBox2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Frm_Prognoza";
            Text = "Frm_Scanner";
            FormClosing += Frm_Scanner_FormClosing;
            Load += Frm_Scanner_Load;
            Leave += Frm_Scanner_Leave;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox2;
        private System.Windows.Forms.Timer timer1;
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private Button BtnSearch;
        private NewCalendar newCalendar1;
        private Label label1;
        private Label label2;
        private DataGridViewTextBoxColumn Data;
        private DataGridViewTextBoxColumn Timp;
        private DataGridViewTextBoxColumn Cuntu_Grup_1;
        private DataGridViewTextBoxColumn Cuntu_Grup_2;
        private DataGridViewTextBoxColumn Craiu_1_Grup_1;
        private DataGridViewTextBoxColumn Craiu_1_Grup_2;
        private DataGridViewTextBoxColumn Craiu_2_Grup_1;
        private DataGridViewTextBoxColumn Craiu_2_Grup_2;
        private DataGridViewTextBoxColumn Sebesel_1_Grup_1;
        private DataGridViewTextBoxColumn Sebesel_1_Grup_2;
        private DataGridViewTextBoxColumn Sebesel_2_Grup_1;
        private DataGridViewTextBoxColumn Sebesel_2_Grup_2;
        private DataGridViewTextBoxColumn Cornereva;
        private DataGridViewTextBoxColumn Total;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
    }
}