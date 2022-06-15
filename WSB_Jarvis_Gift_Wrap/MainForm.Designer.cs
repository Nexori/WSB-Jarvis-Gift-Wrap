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
            this.b_Reset = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.slidebar_anim_speed = new System.Windows.Forms.TrackBar();
            this.b_NextStep = new System.Windows.Forms.Button();
            this.b_GeneratePts = new System.Windows.Forms.Button();
            this.e_pointsCount = new System.Windows.Forms.NumericUpDown();
            this.b_Wipe = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lx = new System.Windows.Forms.Label();
            this.b_prevStep = new System.Windows.Forms.Button();
            this.ckh_vizualization = new System.Windows.Forms.CheckBox();
            this.b_createPoint = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label_timeTaken = new System.Windows.Forms.Label();
            this.e_pCreate_X = new System.Windows.Forms.NumericUpDown();
            this.e_pCreate_Y = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slidebar_anim_speed)).BeginInit();
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
            // b_Reset
            // 
            this.b_Reset.Location = new System.Drawing.Point(933, 65);
            this.b_Reset.Name = "b_Reset";
            this.b_Reset.Size = new System.Drawing.Size(148, 29);
            this.b_Reset.TabIndex = 2;
            this.b_Reset.Text = "Resetuj podgląd";
            this.b_Reset.UseVisualStyleBackColor = true;
            this.b_Reset.Click += new System.EventHandler(this.b_Reset_Click);
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
            // slidebar_anim_speed
            // 
            this.slidebar_anim_speed.Location = new System.Drawing.Point(933, 273);
            this.slidebar_anim_speed.Maximum = 20;
            this.slidebar_anim_speed.Name = "slidebar_anim_speed";
            this.slidebar_anim_speed.Size = new System.Drawing.Size(148, 45);
            this.slidebar_anim_speed.TabIndex = 5;
            this.slidebar_anim_speed.Value = 1;
            this.slidebar_anim_speed.ValueChanged += new System.EventHandler(this.slidebar_viz_speed);
            // 
            // b_NextStep
            // 
            this.b_NextStep.Location = new System.Drawing.Point(1008, 321);
            this.b_NextStep.Name = "b_NextStep";
            this.b_NextStep.Size = new System.Drawing.Size(73, 39);
            this.b_NextStep.TabIndex = 6;
            this.b_NextStep.Text = "Następny krok";
            this.b_NextStep.UseVisualStyleBackColor = true;
            this.b_NextStep.Click += new System.EventHandler(this.b_NextStep_Click);
            // 
            // b_GeneratePts
            // 
            this.b_GeneratePts.Location = new System.Drawing.Point(933, 163);
            this.b_GeneratePts.Name = "b_GeneratePts";
            this.b_GeneratePts.Size = new System.Drawing.Size(148, 29);
            this.b_GeneratePts.TabIndex = 7;
            this.b_GeneratePts.Text = "Generuj punkty";
            this.b_GeneratePts.UseVisualStyleBackColor = true;
            this.b_GeneratePts.Click += new System.EventHandler(this.b_GeneratePts_Click);
            // 
            // e_pointsCount
            // 
            this.e_pointsCount.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.e_pointsCount.Location = new System.Drawing.Point(933, 198);
            this.e_pointsCount.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.e_pointsCount.Name = "e_pointsCount";
            this.e_pointsCount.Size = new System.Drawing.Size(148, 20);
            this.e_pointsCount.TabIndex = 10;
            this.e_pointsCount.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // b_Wipe
            // 
            this.b_Wipe.ForeColor = System.Drawing.Color.Red;
            this.b_Wipe.Location = new System.Drawing.Point(933, 100);
            this.b_Wipe.Name = "b_Wipe";
            this.b_Wipe.Size = new System.Drawing.Size(148, 29);
            this.b_Wipe.TabIndex = 11;
            this.b_Wipe.Text = "Reset";
            this.b_Wipe.UseVisualStyleBackColor = true;
            this.b_Wipe.Click += new System.EventHandler(this.b_Wipe_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(930, 305);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Powoli";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1054, 305);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Szybko";
            // 
            // lx
            // 
            this.lx.AutoSize = true;
            this.lx.Location = new System.Drawing.Point(933, 45);
            this.lx.Name = "lx";
            this.lx.Size = new System.Drawing.Size(68, 13);
            this.lx.TabIndex = 14;
            this.lx.Text = "Obliczono w:";
            // 
            // b_prevStep
            // 
            this.b_prevStep.Location = new System.Drawing.Point(933, 321);
            this.b_prevStep.Name = "b_prevStep";
            this.b_prevStep.Size = new System.Drawing.Size(73, 39);
            this.b_prevStep.TabIndex = 15;
            this.b_prevStep.Text = "Poprzedni krok";
            this.b_prevStep.UseVisualStyleBackColor = true;
            this.b_prevStep.Click += new System.EventHandler(this.b_prevStep_Click);
            // 
            // ckh_vizualization
            // 
            this.ckh_vizualization.AutoSize = true;
            this.ckh_vizualization.Location = new System.Drawing.Point(933, 237);
            this.ckh_vizualization.Name = "ckh_vizualization";
            this.ckh_vizualization.Size = new System.Drawing.Size(102, 30);
            this.ckh_vizualization.TabIndex = 16;
            this.ckh_vizualization.Text = "Włącz podgląd \r\nkrok po kroku";
            this.ckh_vizualization.UseVisualStyleBackColor = true;
            this.ckh_vizualization.CheckedChanged += new System.EventHandler(this.chk_viz_enable);
            // 
            // b_createPoint
            // 
            this.b_createPoint.Location = new System.Drawing.Point(933, 436);
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
            this.label3.Location = new System.Drawing.Point(933, 381);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 26);
            this.label3.TabIndex = 20;
            this.label3.Text = "Utwórz punkt na podanych \r\nwspółrzędnych:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(933, 413);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "X:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1009, 413);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Y:";
            // 
            // label_timeTaken
            // 
            this.label_timeTaken.AutoSize = true;
            this.label_timeTaken.Location = new System.Drawing.Point(1000, 45);
            this.label_timeTaken.Name = "label_timeTaken";
            this.label_timeTaken.Size = new System.Drawing.Size(29, 13);
            this.label_timeTaken.TabIndex = 23;
            this.label_timeTaken.Text = "NaN";
            // 
            // e_pCreate_X
            // 
            this.e_pCreate_X.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.e_pCreate_X.Location = new System.Drawing.Point(948, 410);
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
            this.e_pCreate_Y.Location = new System.Drawing.Point(1023, 410);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 620);
            this.Controls.Add(this.e_pCreate_Y);
            this.Controls.Add(this.e_pCreate_X);
            this.Controls.Add(this.label_timeTaken);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.b_createPoint);
            this.Controls.Add(this.ckh_vizualization);
            this.Controls.Add(this.b_prevStep);
            this.Controls.Add(this.lx);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.b_Wipe);
            this.Controls.Add(this.e_pointsCount);
            this.Controls.Add(this.b_GeneratePts);
            this.Controls.Add(this.b_NextStep);
            this.Controls.Add(this.slidebar_anim_speed);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.b_Reset);
            this.Controls.Add(this.b_Start);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Wizualizacja algorytmu otoczki wypukłej";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slidebar_anim_speed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_pointsCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_pCreate_X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_pCreate_Y)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button b_Start;
        private System.Windows.Forms.Button b_Reset;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TrackBar slidebar_anim_speed;
        private System.Windows.Forms.Button b_NextStep;
        private System.Windows.Forms.Button b_GeneratePts;
        private System.Windows.Forms.NumericUpDown e_pointsCount;
        private System.Windows.Forms.Button b_Wipe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lx;
        private System.Windows.Forms.Button b_prevStep;
        private System.Windows.Forms.CheckBox ckh_vizualization;
        private System.Windows.Forms.Button b_createPoint;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_timeTaken;
        private System.Windows.Forms.NumericUpDown e_pCreate_X;
        private System.Windows.Forms.NumericUpDown e_pCreate_Y;
    }
}

