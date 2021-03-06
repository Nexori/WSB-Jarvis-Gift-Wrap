namespace WSB_Jarvis_Gift_Wrap
{
    partial class MainForm
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
            this.b_Start = new System.Windows.Forms.Button();
            this.b_Reset_Viz = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.b_GeneratePts = new System.Windows.Forms.Button();
            this.e_pointsCount = new System.Windows.Forms.NumericUpDown();
            this.b_Restart = new System.Windows.Forms.Button();
            this.b_createPoint = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.e_pCreate_X = new System.Windows.Forms.NumericUpDown();
            this.e_pCreate_Y = new System.Windows.Forms.NumericUpDown();
            this.txt_solutionDescription = new System.Windows.Forms.TextBox();
            this.chk_drawCoords = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_pointsCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_pCreate_X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_pCreate_Y)).BeginInit();
            this.SuspendLayout();
            // 
            // b_Start
            // 
            this.b_Start.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.b_Start.Location = new System.Drawing.Point(933, 12);
            this.b_Start.Name = "b_Start";
            this.b_Start.Size = new System.Drawing.Size(148, 30);
            this.b_Start.TabIndex = 1;
            this.b_Start.Text = "Uruchom";
            this.b_Start.UseVisualStyleBackColor = true;
            this.b_Start.Click += new System.EventHandler(this.b_Start_Click);
            // 
            // b_Reset_Viz
            // 
            this.b_Reset_Viz.Enabled = false;
            this.b_Reset_Viz.Location = new System.Drawing.Point(933, 83);
            this.b_Reset_Viz.Name = "b_Reset_Viz";
            this.b_Reset_Viz.Size = new System.Drawing.Size(148, 29);
            this.b_Reset_Viz.TabIndex = 2;
            this.b_Reset_Viz.Text = "Wizualizuj od nowa";
            this.b_Reset_Viz.UseVisualStyleBackColor = true;
            this.b_Reset_Viz.Visible = false;
            this.b_Reset_Viz.Click += new System.EventHandler(this.b_Reset_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.Black;
            this.pictureBox.Location = new System.Drawing.Point(13, 13);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(914, 595);
            this.pictureBox.TabIndex = 3;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_Click);
            // 
            // b_GeneratePts
            // 
            this.b_GeneratePts.Location = new System.Drawing.Point(933, 380);
            this.b_GeneratePts.Name = "b_GeneratePts";
            this.b_GeneratePts.Size = new System.Drawing.Size(148, 28);
            this.b_GeneratePts.TabIndex = 7;
            this.b_GeneratePts.Text = "Generuj punkty";
            this.b_GeneratePts.UseVisualStyleBackColor = true;
            this.b_GeneratePts.Click += new System.EventHandler(this.b_GeneratePts_Click);
            // 
            // e_pointsCount
            // 
            this.e_pointsCount.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.e_pointsCount.Location = new System.Drawing.Point(933, 415);
            this.e_pointsCount.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.e_pointsCount.Name = "e_pointsCount";
            this.e_pointsCount.Size = new System.Drawing.Size(148, 20);
            this.e_pointsCount.TabIndex = 10;
            this.e_pointsCount.ThousandsSeparator = true;
            this.e_pointsCount.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // b_Restart
            // 
            this.b_Restart.ForeColor = System.Drawing.Color.Red;
            this.b_Restart.Location = new System.Drawing.Point(933, 48);
            this.b_Restart.Name = "b_Restart";
            this.b_Restart.Size = new System.Drawing.Size(148, 29);
            this.b_Restart.TabIndex = 11;
            this.b_Restart.Text = "Restart";
            this.b_Restart.UseVisualStyleBackColor = true;
            this.b_Restart.Click += new System.EventHandler(this.b_Wipe_Click);
            // 
            // b_createPoint
            // 
            this.b_createPoint.Location = new System.Drawing.Point(933, 585);
            this.b_createPoint.Name = "b_createPoint";
            this.b_createPoint.Size = new System.Drawing.Size(148, 23);
            this.b_createPoint.TabIndex = 19;
            this.b_createPoint.Text = "Utwórz punkt";
            this.b_createPoint.UseVisualStyleBackColor = true;
            this.b_createPoint.Click += new System.EventHandler(this.b_createPoint_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(933, 530);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 26);
            this.label3.TabIndex = 20;
            this.label3.Text = "Utwórz punkt na podanych \r\nwspółrzędnych:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(933, 562);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "X:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1009, 562);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Y:";
            // 
            // e_pCreate_X
            // 
            this.e_pCreate_X.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.e_pCreate_X.Location = new System.Drawing.Point(948, 559);
            this.e_pCreate_X.Maximum = new decimal(new int[] {
            914,
            0,
            0,
            0});
            this.e_pCreate_X.Name = "e_pCreate_X";
            this.e_pCreate_X.Size = new System.Drawing.Size(58, 20);
            this.e_pCreate_X.TabIndex = 24;
            this.e_pCreate_X.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // e_pCreate_Y
            // 
            this.e_pCreate_Y.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.e_pCreate_Y.Location = new System.Drawing.Point(1023, 559);
            this.e_pCreate_Y.Maximum = new decimal(new int[] {
            595,
            0,
            0,
            0});
            this.e_pCreate_Y.Name = "e_pCreate_Y";
            this.e_pCreate_Y.Size = new System.Drawing.Size(58, 20);
            this.e_pCreate_Y.TabIndex = 25;
            this.e_pCreate_Y.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // txt_solutionDescription
            // 
            this.txt_solutionDescription.Location = new System.Drawing.Point(933, 83);
            this.txt_solutionDescription.MinimumSize = new System.Drawing.Size(4, 20);
            this.txt_solutionDescription.Multiline = true;
            this.txt_solutionDescription.Name = "txt_solutionDescription";
            this.txt_solutionDescription.ReadOnly = true;
            this.txt_solutionDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_solutionDescription.Size = new System.Drawing.Size(148, 220);
            this.txt_solutionDescription.TabIndex = 26;
            // 
            // chk_drawCoords
            // 
            this.chk_drawCoords.AutoSize = true;
            this.chk_drawCoords.Checked = true;
            this.chk_drawCoords.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_drawCoords.Location = new System.Drawing.Point(933, 444);
            this.chk_drawCoords.Name = "chk_drawCoords";
            this.chk_drawCoords.Size = new System.Drawing.Size(116, 17);
            this.chk_drawCoords.TabIndex = 27;
            this.chk_drawCoords.Text = "Rysuj współrzędne";
            this.chk_drawCoords.UseMnemonic = false;
            this.chk_drawCoords.UseVisualStyleBackColor = true;
            this.chk_drawCoords.CheckedChanged += new System.EventHandler(this.chk_drawCoords_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 621);
            this.Controls.Add(this.chk_drawCoords);
            this.Controls.Add(this.txt_solutionDescription);
            this.Controls.Add(this.e_pCreate_Y);
            this.Controls.Add(this.e_pCreate_X);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.b_createPoint);
            this.Controls.Add(this.b_Restart);
            this.Controls.Add(this.e_pointsCount);
            this.Controls.Add(this.b_GeneratePts);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.b_Reset_Viz);
            this.Controls.Add(this.b_Start);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Wizualizacja algorytmu otoczki wypukłej";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_pointsCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_pCreate_X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_pCreate_Y)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button b_Start;
        private System.Windows.Forms.Button b_Reset_Viz;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button b_GeneratePts;
        private System.Windows.Forms.NumericUpDown e_pointsCount;
        private System.Windows.Forms.Button b_Restart;
        private System.Windows.Forms.Button b_createPoint;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown e_pCreate_X;
        private System.Windows.Forms.NumericUpDown e_pCreate_Y;
        private System.Windows.Forms.TextBox txt_solutionDescription;
        private System.Windows.Forms.CheckBox chk_drawCoords;
    }
}

