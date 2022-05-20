namespace WSB_Jarvis_Gift_Wrap
{
    partial class Form1
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
            this.chk_step_by_step = new System.Windows.Forms.CheckBox();
            this.b_Start = new System.Windows.Forms.Button();
            this.b_Reset = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.slidebar_sim_speed = new System.Windows.Forms.TrackBar();
            this.chk_speed_ctrl = new System.Windows.Forms.CheckBox();
            this.b_NextStep = new System.Windows.Forms.Button();
            this.b_GeneratePts = new System.Windows.Forms.Button();
            this.chk_manual_pts_placement = new System.Windows.Forms.CheckBox();
            this.numEntry_pts_cnt = new System.Windows.Forms.NumericUpDown();
            this.b_Wipe = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_timeTaken = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slidebar_sim_speed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEntry_pts_cnt)).BeginInit();
            this.SuspendLayout();
            // 
            // chk_step_by_step
            // 
            this.chk_step_by_step.AutoSize = true;
            this.chk_step_by_step.Location = new System.Drawing.Point(933, 306);
            this.chk_step_by_step.Name = "chk_step_by_step";
            this.chk_step_by_step.Size = new System.Drawing.Size(119, 17);
            this.chk_step_by_step.TabIndex = 0;
            this.chk_step_by_step.Text = "Enable step-by-step";
            this.chk_step_by_step.UseVisualStyleBackColor = true;
            this.chk_step_by_step.CheckedChanged += new System.EventHandler(this.chk_step_by_step_CheckedChanged);
            // 
            // b_Start
            // 
            this.b_Start.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.b_Start.Location = new System.Drawing.Point(933, 12);
            this.b_Start.Name = "b_Start";
            this.b_Start.Size = new System.Drawing.Size(148, 30);
            this.b_Start.TabIndex = 1;
            this.b_Start.Text = "Start";
            this.b_Start.UseVisualStyleBackColor = true;
            this.b_Start.Click += new System.EventHandler(this.b_Start_Click);
            // 
            // b_Reset
            // 
            this.b_Reset.Location = new System.Drawing.Point(933, 48);
            this.b_Reset.Name = "b_Reset";
            this.b_Reset.Size = new System.Drawing.Size(148, 29);
            this.b_Reset.TabIndex = 2;
            this.b_Reset.Text = "Reset vizualization";
            this.b_Reset.UseVisualStyleBackColor = true;
            this.b_Reset.Click += new System.EventHandler(this.b_Reset_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(914, 595);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // slidebar_sim_speed
            // 
            this.slidebar_sim_speed.Location = new System.Drawing.Point(933, 387);
            this.slidebar_sim_speed.Maximum = 20;
            this.slidebar_sim_speed.Name = "slidebar_sim_speed";
            this.slidebar_sim_speed.Size = new System.Drawing.Size(148, 45);
            this.slidebar_sim_speed.TabIndex = 4;
            this.slidebar_sim_speed.Scroll += new System.EventHandler(this.slidebar_sim_speed_Scroll);
            // 
            // chk_speed_ctrl
            // 
            this.chk_speed_ctrl.AutoSize = true;
            this.chk_speed_ctrl.Location = new System.Drawing.Point(933, 364);
            this.chk_speed_ctrl.Name = "chk_speed_ctrl";
            this.chk_speed_ctrl.Size = new System.Drawing.Size(126, 17);
            this.chk_speed_ctrl.TabIndex = 5;
            this.chk_speed_ctrl.Text = "Enable speed control";
            this.chk_speed_ctrl.UseVisualStyleBackColor = true;
            this.chk_speed_ctrl.CheckedChanged += new System.EventHandler(this.chk_speed_ctrl_CheckedChanged);
            // 
            // b_NextStep
            // 
            this.b_NextStep.Location = new System.Drawing.Point(933, 329);
            this.b_NextStep.Name = "b_NextStep";
            this.b_NextStep.Size = new System.Drawing.Size(148, 29);
            this.b_NextStep.TabIndex = 6;
            this.b_NextStep.Text = "Next Step";
            this.b_NextStep.UseVisualStyleBackColor = true;
            this.b_NextStep.Click += new System.EventHandler(this.b_NextStep_Click);
            // 
            // b_GeneratePts
            // 
            this.b_GeneratePts.Location = new System.Drawing.Point(933, 163);
            this.b_GeneratePts.Name = "b_GeneratePts";
            this.b_GeneratePts.Size = new System.Drawing.Size(148, 29);
            this.b_GeneratePts.TabIndex = 7;
            this.b_GeneratePts.Text = "Generate points";
            this.b_GeneratePts.UseVisualStyleBackColor = true;
            this.b_GeneratePts.Click += new System.EventHandler(this.b_GeneratePts_Click);
            // 
            // chk_manual_pts_placement
            // 
            this.chk_manual_pts_placement.AutoSize = true;
            this.chk_manual_pts_placement.Location = new System.Drawing.Point(933, 224);
            this.chk_manual_pts_placement.Name = "chk_manual_pts_placement";
            this.chk_manual_pts_placement.Size = new System.Drawing.Size(148, 17);
            this.chk_manual_pts_placement.TabIndex = 8;
            this.chk_manual_pts_placement.Text = "Enable manual placement";
            this.chk_manual_pts_placement.UseVisualStyleBackColor = true;
            this.chk_manual_pts_placement.CheckedChanged += new System.EventHandler(this.chk_manual_pts_placement_CheckedChanged);
            // 
            // numEntry_pts_cnt
            // 
            this.numEntry_pts_cnt.Location = new System.Drawing.Point(933, 198);
            this.numEntry_pts_cnt.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numEntry_pts_cnt.Name = "numEntry_pts_cnt";
            this.numEntry_pts_cnt.Size = new System.Drawing.Size(148, 20);
            this.numEntry_pts_cnt.TabIndex = 10;
            this.numEntry_pts_cnt.UseWaitCursor = true;
            this.numEntry_pts_cnt.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numEntry_pts_cnt.ValueChanged += new System.EventHandler(this.numEntry_pts_cnt_ValueChanged);
            // 
            // b_Wipe
            // 
            this.b_Wipe.ForeColor = System.Drawing.Color.Red;
            this.b_Wipe.Location = new System.Drawing.Point(933, 83);
            this.b_Wipe.Name = "b_Wipe";
            this.b_Wipe.Size = new System.Drawing.Size(148, 29);
            this.b_Wipe.TabIndex = 11;
            this.b_Wipe.Text = "Wipe the grid";
            this.b_Wipe.UseVisualStyleBackColor = true;
            this.b_Wipe.Click += new System.EventHandler(this.b_Wipe_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(930, 419);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Slow";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1054, 419);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Fast";
            // 
            // label_timeTaken
            // 
            this.label_timeTaken.AutoSize = true;
            this.label_timeTaken.Location = new System.Drawing.Point(933, 595);
            this.label_timeTaken.Name = "label_timeTaken";
            this.label_timeTaken.Size = new System.Drawing.Size(63, 13);
            this.label_timeTaken.TabIndex = 14;
            this.label_timeTaken.Text = "Time taken:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 620);
            this.Controls.Add(this.label_timeTaken);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.b_Wipe);
            this.Controls.Add(this.numEntry_pts_cnt);
            this.Controls.Add(this.chk_manual_pts_placement);
            this.Controls.Add(this.b_GeneratePts);
            this.Controls.Add(this.b_NextStep);
            this.Controls.Add(this.chk_speed_ctrl);
            this.Controls.Add(this.slidebar_sim_speed);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.b_Reset);
            this.Controls.Add(this.b_Start);
            this.Controls.Add(this.chk_step_by_step);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Jarvis gift wrap algorithm vizualization";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slidebar_sim_speed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEntry_pts_cnt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chk_step_by_step;
        private System.Windows.Forms.Button b_Start;
        private System.Windows.Forms.Button b_Reset;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TrackBar slidebar_sim_speed;
        private System.Windows.Forms.CheckBox chk_speed_ctrl;
        private System.Windows.Forms.Button b_NextStep;
        private System.Windows.Forms.Button b_GeneratePts;
        private System.Windows.Forms.CheckBox chk_manual_pts_placement;
        private System.Windows.Forms.NumericUpDown numEntry_pts_cnt;
        private System.Windows.Forms.Button b_Wipe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_timeTaken;
    }
}

