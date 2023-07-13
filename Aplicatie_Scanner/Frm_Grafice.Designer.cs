namespace Azel_Raportare_Balkani
{
    partial class Frm_Grafice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Grafice));
            timer1 = new System.Windows.Forms.Timer(components);
            pictureBox2 = new PictureBox();
            cartesianChart1 = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            Search = new Button();
            newCalendar1 = new NewCalendar();
            rbEnergie = new RadioButton();
            cbEnergieOra = new CheckBox();
            cbCuntu = new CheckBox();
            cbCraiu1 = new CheckBox();
            cbCraiu2 = new CheckBox();
            cbSebesel1 = new CheckBox();
            cbSebesel2 = new CheckBox();
            cbCornereva = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Interval = 3000;
            timer1.Tick += timer1_Tick;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(1177, 583);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(101, 90);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 37;
            pictureBox2.TabStop = false;
            // 
            // cartesianChart1
            // 
            cartesianChart1.Location = new Point(21, 12);
            cartesianChart1.Name = "cartesianChart1";
            cartesianChart1.Size = new Size(1257, 394);
            cartesianChart1.TabIndex = 38;
            // 
            // Search
            // 
            Search.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Search.BackColor = Color.FromArgb(8, 35, 50);
            Search.FlatAppearance.BorderColor = Color.White;
            Search.FlatStyle = FlatStyle.Flat;
            Search.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            Search.ForeColor = Color.White;
            Search.Location = new Point(41, 588);
            Search.Name = "Search";
            Search.Size = new Size(213, 50);
            Search.TabIndex = 47;
            Search.Text = "Search";
            Search.UseVisualStyleBackColor = false;
            Search.Click += Search_Click;
            // 
            // newCalendar1
            // 
            newCalendar1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            newCalendar1.BackColor = Color.FromArgb(8, 35, 50);
            newCalendar1.FirstDayOfWeek = Day.Monday;
            newCalendar1.Font = new Font("Nirmala UI", 8F, FontStyle.Bold, GraphicsUnit.Point);
            newCalendar1.ForeColor = Color.White;
            newCalendar1.Location = new Point(41, 425);
            newCalendar1.Margin = new Padding(0);
            newCalendar1.MaxSelectionCount = 365;
            newCalendar1.Name = "newCalendar1";
            newCalendar1.TabIndex = 46;
            newCalendar1.TitleBackColor = Color.White;
            newCalendar1.TitleForeColor = Color.FromArgb(8, 35, 50);
            newCalendar1.TrailingForeColor = Color.LightGray;
            // 
            // rbEnergie
            // 
            rbEnergie.AutoSize = true;
            rbEnergie.Checked = true;
            rbEnergie.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            rbEnergie.Location = new Point(302, 532);
            rbEnergie.Name = "rbEnergie";
            rbEnergie.Size = new Size(79, 24);
            rbEnergie.TabIndex = 59;
            rbEnergie.TabStop = true;
            rbEnergie.Text = "Energie";
            rbEnergie.UseVisualStyleBackColor = true;
            rbEnergie.CheckedChanged += rbEnergie_CheckedChanged;
            // 
            // cbEnergieOra
            // 
            cbEnergieOra.AutoSize = true;
            cbEnergieOra.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            cbEnergieOra.Location = new Point(401, 535);
            cbEnergieOra.Name = "cbEnergieOra";
            cbEnergieOra.Size = new Size(112, 24);
            cbEnergieOra.TabIndex = 60;
            cbEnergieOra.Text = "Energie/Ora";
            cbEnergieOra.UseVisualStyleBackColor = true;
            // 
            // cbCuntu
            // 
            cbCuntu.AutoSize = true;
            cbCuntu.Checked = true;
            cbCuntu.CheckState = CheckState.Checked;
            cbCuntu.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            cbCuntu.Location = new Point(734, 464);
            cbCuntu.Name = "cbCuntu";
            cbCuntu.Size = new Size(70, 24);
            cbCuntu.TabIndex = 62;
            cbCuntu.Text = "Cuntu";
            cbCuntu.UseVisualStyleBackColor = true;
            cbCuntu.CheckedChanged += cbCuntu_CheckedChanged;
            // 
            // cbCraiu1
            // 
            cbCraiu1.AutoSize = true;
            cbCraiu1.Checked = true;
            cbCraiu1.CheckState = CheckState.Checked;
            cbCraiu1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            cbCraiu1.Location = new Point(734, 494);
            cbCraiu1.Name = "cbCraiu1";
            cbCraiu1.Size = new Size(77, 24);
            cbCraiu1.TabIndex = 63;
            cbCraiu1.Text = "Craiu 1";
            cbCraiu1.UseVisualStyleBackColor = true;
            cbCraiu1.CheckedChanged += cbCraiu1_CheckedChanged;
            // 
            // cbCraiu2
            // 
            cbCraiu2.AutoSize = true;
            cbCraiu2.Checked = true;
            cbCraiu2.CheckState = CheckState.Checked;
            cbCraiu2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            cbCraiu2.Location = new Point(734, 524);
            cbCraiu2.Name = "cbCraiu2";
            cbCraiu2.Size = new Size(77, 24);
            cbCraiu2.TabIndex = 64;
            cbCraiu2.Text = "Craiu 2";
            cbCraiu2.UseVisualStyleBackColor = true;
            cbCraiu2.CheckedChanged += cbCraiu2_CheckedChanged;
            // 
            // cbSebesel1
            // 
            cbSebesel1.AutoSize = true;
            cbSebesel1.Checked = true;
            cbSebesel1.CheckState = CheckState.Checked;
            cbSebesel1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            cbSebesel1.Location = new Point(823, 466);
            cbSebesel1.Name = "cbSebesel1";
            cbSebesel1.Size = new Size(93, 24);
            cbSebesel1.TabIndex = 65;
            cbSebesel1.Text = "Sebesel 1";
            cbSebesel1.UseVisualStyleBackColor = true;
            cbSebesel1.CheckedChanged += cbSebesel1_CheckedChanged;
            // 
            // cbSebesel2
            // 
            cbSebesel2.AutoSize = true;
            cbSebesel2.Checked = true;
            cbSebesel2.CheckState = CheckState.Checked;
            cbSebesel2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            cbSebesel2.Location = new Point(823, 496);
            cbSebesel2.Name = "cbSebesel2";
            cbSebesel2.Size = new Size(93, 24);
            cbSebesel2.TabIndex = 66;
            cbSebesel2.Text = "Sebesel 2";
            cbSebesel2.UseVisualStyleBackColor = true;
            cbSebesel2.CheckedChanged += cbSebesel2_CheckedChanged;
            // 
            // cbCornereva
            // 
            cbCornereva.AutoSize = true;
            cbCornereva.Checked = true;
            cbCornereva.CheckState = CheckState.Checked;
            cbCornereva.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            cbCornereva.Location = new Point(823, 524);
            cbCornereva.Name = "cbCornereva";
            cbCornereva.Size = new Size(99, 24);
            cbCornereva.TabIndex = 67;
            cbCornereva.Text = "Cornereva";
            cbCornereva.UseVisualStyleBackColor = true;
            cbCornereva.CheckedChanged += cbCornereva_CheckedChanged;
            // 
            // Frm_Grafice
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(35, 65, 82);
            ClientSize = new Size(1290, 674);
            Controls.Add(cbCornereva);
            Controls.Add(cbSebesel2);
            Controls.Add(cbSebesel1);
            Controls.Add(cbCraiu2);
            Controls.Add(cbCraiu1);
            Controls.Add(cbCuntu);
            Controls.Add(cbEnergieOra);
            Controls.Add(rbEnergie);
            Controls.Add(Search);
            Controls.Add(newCalendar1);
            Controls.Add(cartesianChart1);
            Controls.Add(pictureBox2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Frm_Grafice";
            Text = "Frm_Printer";
            Load += Frm_Grafice_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private TextBox tbNrReceptieCurenta;
        private Label label1;
        private PictureBox pictureBox2;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart cartesianChart1;
        private Button Search;
        private NewCalendar newCalendar1;
        private RadioButton rbEnergie;
        private CheckBox cbEnergieOra;
        private CheckBox cbCuntu;
        private CheckBox cbCraiu1;
        private CheckBox cbCraiu2;
        private CheckBox cbSebesel1;
        private CheckBox cbSebesel2;
        private CheckBox cbCornereva;
    }
}