namespace Poker
{
    partial class 
        GrudithPoker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GrudithPoker));
            this.BlindTimer = new System.Windows.Forms.Timer(this.components);
            this.timer = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.currentBlind = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nextBlind = new System.Windows.Forms.Label();
            this.PauseButton = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.ResetBox = new System.Windows.Forms.TextBox();
            this.NextButton = new System.Windows.Forms.Button();
            this.PrevButton = new System.Windows.Forms.Button();
            this.CheckTimer = new System.Windows.Forms.Timer(this.components);
            this.Blinds_Panel = new System.Windows.Forms.Panel();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.EighthAnte = new System.Windows.Forms.TextBox();
            this.EighthBig = new System.Windows.Forms.TextBox();
            this.EighthSmall = new System.Windows.Forms.TextBox();
            this.SeventhAnte = new System.Windows.Forms.TextBox();
            this.SeventhBig = new System.Windows.Forms.TextBox();
            this.SeventhSmall = new System.Windows.Forms.TextBox();
            this.SixthAnte = new System.Windows.Forms.TextBox();
            this.SixthBig = new System.Windows.Forms.TextBox();
            this.SixthSmall = new System.Windows.Forms.TextBox();
            this.FifthAnte = new System.Windows.Forms.TextBox();
            this.FifthBig = new System.Windows.Forms.TextBox();
            this.FifthSmall = new System.Windows.Forms.TextBox();
            this.FourthAnte = new System.Windows.Forms.TextBox();
            this.FourthBig = new System.Windows.Forms.TextBox();
            this.FourthSmall = new System.Windows.Forms.TextBox();
            this.ThirdAnte = new System.Windows.Forms.TextBox();
            this.ThirdBig = new System.Windows.Forms.TextBox();
            this.ThirdSmall = new System.Windows.Forms.TextBox();
            this.SecondAnte = new System.Windows.Forms.TextBox();
            this.SecondBig = new System.Windows.Forms.TextBox();
            this.SecondSmall = new System.Windows.Forms.TextBox();
            this.FirstAnte = new System.Windows.Forms.TextBox();
            this.FirstBig = new System.Windows.Forms.TextBox();
            this.FirstSmall = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.EighthLevel = new System.Windows.Forms.Label();
            this.SeventhLevel = new System.Windows.Forms.Label();
            this.SixthLevel = new System.Windows.Forms.Label();
            this.FifthLevel = new System.Windows.Forms.Label();
            this.FourthLevel = new System.Windows.Forms.Label();
            this.ThirdLevel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.BlindTime_Input = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.LevelCount = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SecondLevel = new System.Windows.Forms.Label();
            this.FirstLevel = new System.Windows.Forms.Label();
            this.DoneButton = new System.Windows.Forms.Button();
            this.Edit_Blinds = new System.Windows.Forms.Button();
            this.AnteLabel = new System.Windows.Forms.Label();
            this.AnteDisplay = new System.Windows.Forms.Label();
            this.Blinds_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BlindTime_Input)).BeginInit();
            this.SuspendLayout();
            // 
            // BlindTimer
            // 
            this.BlindTimer.Interval = 1000;
            this.BlindTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer
            // 
            this.timer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.timer.AutoSize = true;
            this.timer.BackColor = System.Drawing.Color.Transparent;
            this.timer.Font = new System.Drawing.Font("Microsoft Sans Serif", 170F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timer.ForeColor = System.Drawing.Color.Gold;
            this.timer.Location = new System.Drawing.Point(29, 95);
            this.timer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.timer.Name = "timer";
            this.timer.Size = new System.Drawing.Size(675, 257);
            this.timer.TabIndex = 0;
            this.timer.Text = "00:00";
            this.timer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StartButton
            // 
            this.StartButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.StartButton.BackColor = System.Drawing.Color.Crimson;
            this.StartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartButton.ForeColor = System.Drawing.Color.LavenderBlush;
            this.StartButton.Location = new System.Drawing.Point(289, 50);
            this.StartButton.Margin = new System.Windows.Forms.Padding(2);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(130, 55);
            this.StartButton.TabIndex = 1;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Cornsilk;
            this.label1.Location = new System.Drawing.Point(171, 371);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 36);
            this.label1.TabIndex = 2;
            this.label1.Text = "Current Blinds:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currentBlind
            // 
            this.currentBlind.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.currentBlind.BackColor = System.Drawing.Color.Transparent;
            this.currentBlind.Font = new System.Drawing.Font("Microsoft Sans Serif", 75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentBlind.ForeColor = System.Drawing.Color.Aqua;
            this.currentBlind.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.currentBlind.Location = new System.Drawing.Point(46, 407);
            this.currentBlind.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.currentBlind.Name = "currentBlind";
            this.currentBlind.Size = new System.Drawing.Size(478, 162);
            this.currentBlind.TabIndex = 3;
            this.currentBlind.Text = "0/0";
            this.currentBlind.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Cornsilk;
            this.label2.Location = new System.Drawing.Point(290, 592);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "Next Blinds:";
            // 
            // nextBlind
            // 
            this.nextBlind.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nextBlind.BackColor = System.Drawing.Color.Transparent;
            this.nextBlind.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextBlind.ForeColor = System.Drawing.Color.Aqua;
            this.nextBlind.Location = new System.Drawing.Point(266, 623);
            this.nextBlind.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.nextBlind.Name = "nextBlind";
            this.nextBlind.Size = new System.Drawing.Size(184, 47);
            this.nextBlind.TabIndex = 5;
            this.nextBlind.Text = "0/0";
            this.nextBlind.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PauseButton
            // 
            this.PauseButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PauseButton.BackColor = System.Drawing.Color.DarkGreen;
            this.PauseButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PauseButton.BackgroundImage")));
            this.PauseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PauseButton.Location = new System.Drawing.Point(308, 24);
            this.PauseButton.Margin = new System.Windows.Forms.Padding(2);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(92, 84);
            this.PauseButton.TabIndex = 6;
            this.PauseButton.UseVisualStyleBackColor = false;
            this.PauseButton.Visible = false;
            this.PauseButton.Click += new System.EventHandler(this.Pause_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ResetButton.BackColor = System.Drawing.Color.Aqua;
            this.ResetButton.Enabled = false;
            this.ResetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResetButton.ForeColor = System.Drawing.Color.Blue;
            this.ResetButton.Location = new System.Drawing.Point(16, 643);
            this.ResetButton.Margin = new System.Windows.Forms.Padding(2);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(65, 26);
            this.ResetButton.TabIndex = 7;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = false;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // ResetBox
            // 
            this.ResetBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ResetBox.BackColor = System.Drawing.SystemColors.GrayText;
            this.ResetBox.ForeColor = System.Drawing.Color.Aqua;
            this.ResetBox.Location = new System.Drawing.Point(86, 647);
            this.ResetBox.Margin = new System.Windows.Forms.Padding(2);
            this.ResetBox.Name = "ResetBox";
            this.ResetBox.Size = new System.Drawing.Size(72, 20);
            this.ResetBox.TabIndex = 8;
            this.ResetBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ResetBox.TextChanged += new System.EventHandler(this.ResetBox_TextChanged);
            // 
            // NextButton
            // 
            this.NextButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NextButton.BackColor = System.Drawing.Color.Aqua;
            this.NextButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NextButton.ForeColor = System.Drawing.Color.Blue;
            this.NextButton.Location = new System.Drawing.Point(644, 643);
            this.NextButton.Margin = new System.Windows.Forms.Padding(2);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(51, 25);
            this.NextButton.TabIndex = 9;
            this.NextButton.Text = "Next";
            this.NextButton.UseVisualStyleBackColor = false;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // PrevButton
            // 
            this.PrevButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PrevButton.BackColor = System.Drawing.Color.Aqua;
            this.PrevButton.Enabled = false;
            this.PrevButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrevButton.ForeColor = System.Drawing.Color.Blue;
            this.PrevButton.Location = new System.Drawing.Point(577, 643);
            this.PrevButton.Margin = new System.Windows.Forms.Padding(2);
            this.PrevButton.Name = "PrevButton";
            this.PrevButton.Size = new System.Drawing.Size(51, 25);
            this.PrevButton.TabIndex = 10;
            this.PrevButton.Text = "Prev";
            this.PrevButton.UseVisualStyleBackColor = false;
            this.PrevButton.Click += new System.EventHandler(this.PrevButton_Click);
            // 
            // CheckTimer
            // 
            this.CheckTimer.Interval = 1000;
            this.CheckTimer.Tick += new System.EventHandler(this.CheckTimer_Tick);
            // 
            // Blinds_Panel
            // 
            this.Blinds_Panel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Blinds_Panel.BackgroundImage")));
            this.Blinds_Panel.Controls.Add(this.UpdateButton);
            this.Blinds_Panel.Controls.Add(this.EighthAnte);
            this.Blinds_Panel.Controls.Add(this.EighthBig);
            this.Blinds_Panel.Controls.Add(this.EighthSmall);
            this.Blinds_Panel.Controls.Add(this.SeventhAnte);
            this.Blinds_Panel.Controls.Add(this.SeventhBig);
            this.Blinds_Panel.Controls.Add(this.SeventhSmall);
            this.Blinds_Panel.Controls.Add(this.SixthAnte);
            this.Blinds_Panel.Controls.Add(this.SixthBig);
            this.Blinds_Panel.Controls.Add(this.SixthSmall);
            this.Blinds_Panel.Controls.Add(this.FifthAnte);
            this.Blinds_Panel.Controls.Add(this.FifthBig);
            this.Blinds_Panel.Controls.Add(this.FifthSmall);
            this.Blinds_Panel.Controls.Add(this.FourthAnte);
            this.Blinds_Panel.Controls.Add(this.FourthBig);
            this.Blinds_Panel.Controls.Add(this.FourthSmall);
            this.Blinds_Panel.Controls.Add(this.ThirdAnte);
            this.Blinds_Panel.Controls.Add(this.ThirdBig);
            this.Blinds_Panel.Controls.Add(this.ThirdSmall);
            this.Blinds_Panel.Controls.Add(this.SecondAnte);
            this.Blinds_Panel.Controls.Add(this.SecondBig);
            this.Blinds_Panel.Controls.Add(this.SecondSmall);
            this.Blinds_Panel.Controls.Add(this.FirstAnte);
            this.Blinds_Panel.Controls.Add(this.FirstBig);
            this.Blinds_Panel.Controls.Add(this.FirstSmall);
            this.Blinds_Panel.Controls.Add(this.label16);
            this.Blinds_Panel.Controls.Add(this.label15);
            this.Blinds_Panel.Controls.Add(this.label14);
            this.Blinds_Panel.Controls.Add(this.EighthLevel);
            this.Blinds_Panel.Controls.Add(this.SeventhLevel);
            this.Blinds_Panel.Controls.Add(this.SixthLevel);
            this.Blinds_Panel.Controls.Add(this.FifthLevel);
            this.Blinds_Panel.Controls.Add(this.FourthLevel);
            this.Blinds_Panel.Controls.Add(this.ThirdLevel);
            this.Blinds_Panel.Controls.Add(this.label7);
            this.Blinds_Panel.Controls.Add(this.BlindTime_Input);
            this.Blinds_Panel.Controls.Add(this.label6);
            this.Blinds_Panel.Controls.Add(this.LevelCount);
            this.Blinds_Panel.Controls.Add(this.label5);
            this.Blinds_Panel.Controls.Add(this.SecondLevel);
            this.Blinds_Panel.Controls.Add(this.FirstLevel);
            this.Blinds_Panel.Controls.Add(this.DoneButton);
            this.Blinds_Panel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Blinds_Panel.ForeColor = System.Drawing.Color.Cornsilk;
            this.Blinds_Panel.Location = new System.Drawing.Point(11, 11);
            this.Blinds_Panel.Margin = new System.Windows.Forms.Padding(2);
            this.Blinds_Panel.Name = "Blinds_Panel";
            this.Blinds_Panel.Size = new System.Drawing.Size(703, 674);
            this.Blinds_Panel.TabIndex = 11;
            // 
            // UpdateButton
            // 
            this.UpdateButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.UpdateButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.UpdateButton.Location = new System.Drawing.Point(301, 630);
            this.UpdateButton.Margin = new System.Windows.Forms.Padding(2);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(110, 40);
            this.UpdateButton.TabIndex = 41;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = false;
            this.UpdateButton.Visible = false;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // EighthAnte
            // 
            this.EighthAnte.BackColor = System.Drawing.SystemColors.GrayText;
            this.EighthAnte.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EighthAnte.ForeColor = System.Drawing.Color.Aqua;
            this.EighthAnte.Location = new System.Drawing.Point(496, 558);
            this.EighthAnte.Name = "EighthAnte";
            this.EighthAnte.Size = new System.Drawing.Size(60, 30);
            this.EighthAnte.TabIndex = 40;
            this.EighthAnte.Text = "0";
            this.EighthAnte.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.EighthAnte.Visible = false;
            // 
            // EighthBig
            // 
            this.EighthBig.BackColor = System.Drawing.SystemColors.GrayText;
            this.EighthBig.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EighthBig.ForeColor = System.Drawing.Color.Aqua;
            this.EighthBig.Location = new System.Drawing.Point(325, 559);
            this.EighthBig.Name = "EighthBig";
            this.EighthBig.Size = new System.Drawing.Size(60, 30);
            this.EighthBig.TabIndex = 39;
            this.EighthBig.Text = "0";
            this.EighthBig.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.EighthBig.Visible = false;
            // 
            // EighthSmall
            // 
            this.EighthSmall.BackColor = System.Drawing.SystemColors.GrayText;
            this.EighthSmall.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EighthSmall.ForeColor = System.Drawing.Color.Aqua;
            this.EighthSmall.Location = new System.Drawing.Point(154, 558);
            this.EighthSmall.Name = "EighthSmall";
            this.EighthSmall.Size = new System.Drawing.Size(60, 30);
            this.EighthSmall.TabIndex = 38;
            this.EighthSmall.Text = "0";
            this.EighthSmall.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.EighthSmall.Visible = false;
            // 
            // SeventhAnte
            // 
            this.SeventhAnte.BackColor = System.Drawing.SystemColors.GrayText;
            this.SeventhAnte.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SeventhAnte.ForeColor = System.Drawing.Color.Aqua;
            this.SeventhAnte.Location = new System.Drawing.Point(496, 499);
            this.SeventhAnte.Name = "SeventhAnte";
            this.SeventhAnte.Size = new System.Drawing.Size(60, 30);
            this.SeventhAnte.TabIndex = 37;
            this.SeventhAnte.Text = "0";
            this.SeventhAnte.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SeventhAnte.Visible = false;
            // 
            // SeventhBig
            // 
            this.SeventhBig.BackColor = System.Drawing.SystemColors.GrayText;
            this.SeventhBig.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SeventhBig.ForeColor = System.Drawing.Color.Aqua;
            this.SeventhBig.Location = new System.Drawing.Point(325, 499);
            this.SeventhBig.Name = "SeventhBig";
            this.SeventhBig.Size = new System.Drawing.Size(60, 30);
            this.SeventhBig.TabIndex = 36;
            this.SeventhBig.Text = "0";
            this.SeventhBig.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SeventhBig.Visible = false;
            // 
            // SeventhSmall
            // 
            this.SeventhSmall.BackColor = System.Drawing.SystemColors.GrayText;
            this.SeventhSmall.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SeventhSmall.ForeColor = System.Drawing.Color.Aqua;
            this.SeventhSmall.Location = new System.Drawing.Point(154, 499);
            this.SeventhSmall.Name = "SeventhSmall";
            this.SeventhSmall.Size = new System.Drawing.Size(60, 30);
            this.SeventhSmall.TabIndex = 35;
            this.SeventhSmall.Text = "0";
            this.SeventhSmall.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SeventhSmall.Visible = false;
            // 
            // SixthAnte
            // 
            this.SixthAnte.BackColor = System.Drawing.SystemColors.GrayText;
            this.SixthAnte.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SixthAnte.ForeColor = System.Drawing.Color.Aqua;
            this.SixthAnte.Location = new System.Drawing.Point(497, 439);
            this.SixthAnte.Name = "SixthAnte";
            this.SixthAnte.Size = new System.Drawing.Size(60, 30);
            this.SixthAnte.TabIndex = 34;
            this.SixthAnte.Text = "0";
            this.SixthAnte.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SixthAnte.Visible = false;
            // 
            // SixthBig
            // 
            this.SixthBig.BackColor = System.Drawing.SystemColors.GrayText;
            this.SixthBig.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SixthBig.ForeColor = System.Drawing.Color.Aqua;
            this.SixthBig.Location = new System.Drawing.Point(325, 439);
            this.SixthBig.Name = "SixthBig";
            this.SixthBig.Size = new System.Drawing.Size(60, 30);
            this.SixthBig.TabIndex = 33;
            this.SixthBig.Text = "0";
            this.SixthBig.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SixthBig.Visible = false;
            // 
            // SixthSmall
            // 
            this.SixthSmall.BackColor = System.Drawing.SystemColors.GrayText;
            this.SixthSmall.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SixthSmall.ForeColor = System.Drawing.Color.Aqua;
            this.SixthSmall.Location = new System.Drawing.Point(154, 439);
            this.SixthSmall.Name = "SixthSmall";
            this.SixthSmall.Size = new System.Drawing.Size(60, 30);
            this.SixthSmall.TabIndex = 32;
            this.SixthSmall.Text = "0";
            this.SixthSmall.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SixthSmall.Visible = false;
            // 
            // FifthAnte
            // 
            this.FifthAnte.BackColor = System.Drawing.SystemColors.GrayText;
            this.FifthAnte.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FifthAnte.ForeColor = System.Drawing.Color.Aqua;
            this.FifthAnte.Location = new System.Drawing.Point(497, 380);
            this.FifthAnte.Name = "FifthAnte";
            this.FifthAnte.Size = new System.Drawing.Size(60, 30);
            this.FifthAnte.TabIndex = 31;
            this.FifthAnte.Text = "0";
            this.FifthAnte.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.FifthAnte.Visible = false;
            // 
            // FifthBig
            // 
            this.FifthBig.BackColor = System.Drawing.SystemColors.GrayText;
            this.FifthBig.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FifthBig.ForeColor = System.Drawing.Color.Aqua;
            this.FifthBig.Location = new System.Drawing.Point(325, 380);
            this.FifthBig.Name = "FifthBig";
            this.FifthBig.Size = new System.Drawing.Size(60, 30);
            this.FifthBig.TabIndex = 30;
            this.FifthBig.Text = "0";
            this.FifthBig.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.FifthBig.Visible = false;
            // 
            // FifthSmall
            // 
            this.FifthSmall.BackColor = System.Drawing.SystemColors.GrayText;
            this.FifthSmall.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FifthSmall.ForeColor = System.Drawing.Color.Aqua;
            this.FifthSmall.Location = new System.Drawing.Point(154, 379);
            this.FifthSmall.Name = "FifthSmall";
            this.FifthSmall.Size = new System.Drawing.Size(60, 30);
            this.FifthSmall.TabIndex = 29;
            this.FifthSmall.Text = "0";
            this.FifthSmall.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.FifthSmall.Visible = false;
            // 
            // FourthAnte
            // 
            this.FourthAnte.BackColor = System.Drawing.SystemColors.GrayText;
            this.FourthAnte.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FourthAnte.ForeColor = System.Drawing.Color.Aqua;
            this.FourthAnte.Location = new System.Drawing.Point(497, 318);
            this.FourthAnte.Name = "FourthAnte";
            this.FourthAnte.Size = new System.Drawing.Size(60, 30);
            this.FourthAnte.TabIndex = 28;
            this.FourthAnte.Text = "0";
            this.FourthAnte.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.FourthAnte.Visible = false;
            // 
            // FourthBig
            // 
            this.FourthBig.BackColor = System.Drawing.SystemColors.GrayText;
            this.FourthBig.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FourthBig.ForeColor = System.Drawing.Color.Aqua;
            this.FourthBig.Location = new System.Drawing.Point(325, 318);
            this.FourthBig.Name = "FourthBig";
            this.FourthBig.Size = new System.Drawing.Size(60, 30);
            this.FourthBig.TabIndex = 27;
            this.FourthBig.Text = "0";
            this.FourthBig.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.FourthBig.Visible = false;
            // 
            // FourthSmall
            // 
            this.FourthSmall.BackColor = System.Drawing.SystemColors.GrayText;
            this.FourthSmall.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FourthSmall.ForeColor = System.Drawing.Color.Aqua;
            this.FourthSmall.Location = new System.Drawing.Point(154, 318);
            this.FourthSmall.Name = "FourthSmall";
            this.FourthSmall.Size = new System.Drawing.Size(60, 30);
            this.FourthSmall.TabIndex = 26;
            this.FourthSmall.Text = "0";
            this.FourthSmall.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.FourthSmall.Visible = false;
            // 
            // ThirdAnte
            // 
            this.ThirdAnte.BackColor = System.Drawing.SystemColors.GrayText;
            this.ThirdAnte.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThirdAnte.ForeColor = System.Drawing.Color.Aqua;
            this.ThirdAnte.Location = new System.Drawing.Point(496, 258);
            this.ThirdAnte.Name = "ThirdAnte";
            this.ThirdAnte.Size = new System.Drawing.Size(60, 30);
            this.ThirdAnte.TabIndex = 25;
            this.ThirdAnte.Text = "0";
            this.ThirdAnte.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ThirdAnte.Visible = false;
            // 
            // ThirdBig
            // 
            this.ThirdBig.BackColor = System.Drawing.SystemColors.GrayText;
            this.ThirdBig.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThirdBig.ForeColor = System.Drawing.Color.Aqua;
            this.ThirdBig.Location = new System.Drawing.Point(324, 258);
            this.ThirdBig.Name = "ThirdBig";
            this.ThirdBig.Size = new System.Drawing.Size(60, 30);
            this.ThirdBig.TabIndex = 24;
            this.ThirdBig.Text = "0";
            this.ThirdBig.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ThirdBig.Visible = false;
            // 
            // ThirdSmall
            // 
            this.ThirdSmall.BackColor = System.Drawing.SystemColors.GrayText;
            this.ThirdSmall.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThirdSmall.ForeColor = System.Drawing.Color.Aqua;
            this.ThirdSmall.Location = new System.Drawing.Point(154, 258);
            this.ThirdSmall.Name = "ThirdSmall";
            this.ThirdSmall.Size = new System.Drawing.Size(60, 30);
            this.ThirdSmall.TabIndex = 23;
            this.ThirdSmall.Text = "0";
            this.ThirdSmall.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ThirdSmall.Visible = false;
            // 
            // SecondAnte
            // 
            this.SecondAnte.BackColor = System.Drawing.SystemColors.GrayText;
            this.SecondAnte.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SecondAnte.ForeColor = System.Drawing.Color.Aqua;
            this.SecondAnte.Location = new System.Drawing.Point(497, 197);
            this.SecondAnte.Name = "SecondAnte";
            this.SecondAnte.Size = new System.Drawing.Size(60, 30);
            this.SecondAnte.TabIndex = 22;
            this.SecondAnte.Text = "0";
            this.SecondAnte.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SecondAnte.Visible = false;
            // 
            // SecondBig
            // 
            this.SecondBig.BackColor = System.Drawing.SystemColors.GrayText;
            this.SecondBig.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SecondBig.ForeColor = System.Drawing.Color.Aqua;
            this.SecondBig.Location = new System.Drawing.Point(324, 197);
            this.SecondBig.Name = "SecondBig";
            this.SecondBig.Size = new System.Drawing.Size(60, 30);
            this.SecondBig.TabIndex = 21;
            this.SecondBig.Text = "0";
            this.SecondBig.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SecondBig.Visible = false;
            // 
            // SecondSmall
            // 
            this.SecondSmall.BackColor = System.Drawing.SystemColors.GrayText;
            this.SecondSmall.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SecondSmall.ForeColor = System.Drawing.Color.Aqua;
            this.SecondSmall.Location = new System.Drawing.Point(154, 197);
            this.SecondSmall.Name = "SecondSmall";
            this.SecondSmall.Size = new System.Drawing.Size(60, 30);
            this.SecondSmall.TabIndex = 20;
            this.SecondSmall.Text = "0";
            this.SecondSmall.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SecondSmall.Visible = false;
            // 
            // FirstAnte
            // 
            this.FirstAnte.BackColor = System.Drawing.SystemColors.GrayText;
            this.FirstAnte.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FirstAnte.ForeColor = System.Drawing.Color.Aqua;
            this.FirstAnte.Location = new System.Drawing.Point(496, 137);
            this.FirstAnte.Name = "FirstAnte";
            this.FirstAnte.Size = new System.Drawing.Size(60, 30);
            this.FirstAnte.TabIndex = 19;
            this.FirstAnte.Text = "0";
            this.FirstAnte.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.FirstAnte.Visible = false;
            // 
            // FirstBig
            // 
            this.FirstBig.BackColor = System.Drawing.SystemColors.GrayText;
            this.FirstBig.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FirstBig.ForeColor = System.Drawing.Color.Aqua;
            this.FirstBig.Location = new System.Drawing.Point(324, 136);
            this.FirstBig.Name = "FirstBig";
            this.FirstBig.Size = new System.Drawing.Size(60, 30);
            this.FirstBig.TabIndex = 18;
            this.FirstBig.Text = "0";
            this.FirstBig.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.FirstBig.Visible = false;
            // 
            // FirstSmall
            // 
            this.FirstSmall.BackColor = System.Drawing.SystemColors.GrayText;
            this.FirstSmall.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FirstSmall.ForeColor = System.Drawing.Color.Aqua;
            this.FirstSmall.Location = new System.Drawing.Point(154, 137);
            this.FirstSmall.Name = "FirstSmall";
            this.FirstSmall.Size = new System.Drawing.Size(60, 30);
            this.FirstSmall.TabIndex = 17;
            this.FirstSmall.Text = "0";
            this.FirstSmall.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.FirstSmall.Visible = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Cornsilk;
            this.label16.Location = new System.Drawing.Point(499, 85);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 25);
            this.label16.TabIndex = 16;
            this.label16.Text = "Ante";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Cornsilk;
            this.label15.Location = new System.Drawing.Point(314, 85);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(88, 25);
            this.label15.TabIndex = 15;
            this.label15.Text = "Big Blind";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Cornsilk;
            this.label14.Location = new System.Drawing.Point(129, 85);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(109, 25);
            this.label14.TabIndex = 14;
            this.label14.Text = "Small Blind";
            // 
            // EighthLevel
            // 
            this.EighthLevel.AutoSize = true;
            this.EighthLevel.BackColor = System.Drawing.Color.Transparent;
            this.EighthLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EighthLevel.ForeColor = System.Drawing.Color.Cornsilk;
            this.EighthLevel.Location = new System.Drawing.Point(83, 561);
            this.EighthLevel.Name = "EighthLevel";
            this.EighthLevel.Size = new System.Drawing.Size(29, 25);
            this.EighthLevel.TabIndex = 13;
            this.EighthLevel.Text = "8:";
            this.EighthLevel.Visible = false;
            // 
            // SeventhLevel
            // 
            this.SeventhLevel.AutoSize = true;
            this.SeventhLevel.BackColor = System.Drawing.Color.Transparent;
            this.SeventhLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SeventhLevel.ForeColor = System.Drawing.Color.Cornsilk;
            this.SeventhLevel.Location = new System.Drawing.Point(83, 502);
            this.SeventhLevel.Name = "SeventhLevel";
            this.SeventhLevel.Size = new System.Drawing.Size(29, 25);
            this.SeventhLevel.TabIndex = 12;
            this.SeventhLevel.Text = "7:";
            this.SeventhLevel.Visible = false;
            // 
            // SixthLevel
            // 
            this.SixthLevel.AutoSize = true;
            this.SixthLevel.BackColor = System.Drawing.Color.Transparent;
            this.SixthLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SixthLevel.ForeColor = System.Drawing.Color.Cornsilk;
            this.SixthLevel.Location = new System.Drawing.Point(83, 442);
            this.SixthLevel.Name = "SixthLevel";
            this.SixthLevel.Size = new System.Drawing.Size(29, 25);
            this.SixthLevel.TabIndex = 11;
            this.SixthLevel.Text = "6:";
            this.SixthLevel.Visible = false;
            // 
            // FifthLevel
            // 
            this.FifthLevel.AutoSize = true;
            this.FifthLevel.BackColor = System.Drawing.Color.Transparent;
            this.FifthLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FifthLevel.ForeColor = System.Drawing.Color.Cornsilk;
            this.FifthLevel.Location = new System.Drawing.Point(83, 382);
            this.FifthLevel.Name = "FifthLevel";
            this.FifthLevel.Size = new System.Drawing.Size(29, 25);
            this.FifthLevel.TabIndex = 10;
            this.FifthLevel.Text = "5:";
            this.FifthLevel.Visible = false;
            // 
            // FourthLevel
            // 
            this.FourthLevel.AutoSize = true;
            this.FourthLevel.BackColor = System.Drawing.Color.Transparent;
            this.FourthLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FourthLevel.ForeColor = System.Drawing.Color.Cornsilk;
            this.FourthLevel.Location = new System.Drawing.Point(83, 321);
            this.FourthLevel.Name = "FourthLevel";
            this.FourthLevel.Size = new System.Drawing.Size(29, 25);
            this.FourthLevel.TabIndex = 9;
            this.FourthLevel.Text = "4:";
            this.FourthLevel.Visible = false;
            // 
            // ThirdLevel
            // 
            this.ThirdLevel.AutoSize = true;
            this.ThirdLevel.BackColor = System.Drawing.Color.Transparent;
            this.ThirdLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThirdLevel.ForeColor = System.Drawing.Color.Cornsilk;
            this.ThirdLevel.Location = new System.Drawing.Point(83, 261);
            this.ThirdLevel.Name = "ThirdLevel";
            this.ThirdLevel.Size = new System.Drawing.Size(29, 25);
            this.ThirdLevel.TabIndex = 8;
            this.ThirdLevel.Text = "3:";
            this.ThirdLevel.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Cornsilk;
            this.label7.Location = new System.Drawing.Point(560, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 25);
            this.label7.TabIndex = 7;
            this.label7.Text = "Minutes";
            // 
            // BlindTime_Input
            // 
            this.BlindTime_Input.BackColor = System.Drawing.SystemColors.GrayText;
            this.BlindTime_Input.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BlindTime_Input.ForeColor = System.Drawing.Color.Aqua;
            this.BlindTime_Input.Location = new System.Drawing.Point(501, 27);
            this.BlindTime_Input.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.BlindTime_Input.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.BlindTime_Input.Name = "BlindTime_Input";
            this.BlindTime_Input.Size = new System.Drawing.Size(55, 30);
            this.BlindTime_Input.TabIndex = 6;
            this.BlindTime_Input.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Cornsilk;
            this.label6.Location = new System.Drawing.Point(353, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "Time Per Level:";
            // 
            // LevelCount
            // 
            this.LevelCount.BackColor = System.Drawing.SystemColors.GrayText;
            this.LevelCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LevelCount.ForeColor = System.Drawing.Color.Aqua;
            this.LevelCount.FormattingEnabled = true;
            this.LevelCount.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.LevelCount.Location = new System.Drawing.Point(157, 27);
            this.LevelCount.MaxLength = 1;
            this.LevelCount.Name = "LevelCount";
            this.LevelCount.Size = new System.Drawing.Size(47, 33);
            this.LevelCount.TabIndex = 4;
            this.LevelCount.SelectedIndexChanged += new System.EventHandler(this.LevelCount_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Cornsilk;
            this.label5.Location = new System.Drawing.Point(83, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 25);
            this.label5.TabIndex = 3;
            this.label5.Text = "Levels:";
            // 
            // SecondLevel
            // 
            this.SecondLevel.AutoSize = true;
            this.SecondLevel.BackColor = System.Drawing.Color.Transparent;
            this.SecondLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SecondLevel.ForeColor = System.Drawing.Color.Cornsilk;
            this.SecondLevel.Location = new System.Drawing.Point(83, 200);
            this.SecondLevel.Name = "SecondLevel";
            this.SecondLevel.Size = new System.Drawing.Size(29, 25);
            this.SecondLevel.TabIndex = 2;
            this.SecondLevel.Text = "2:";
            this.SecondLevel.Visible = false;
            // 
            // FirstLevel
            // 
            this.FirstLevel.AutoSize = true;
            this.FirstLevel.BackColor = System.Drawing.Color.Transparent;
            this.FirstLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FirstLevel.ForeColor = System.Drawing.Color.Cornsilk;
            this.FirstLevel.Location = new System.Drawing.Point(83, 140);
            this.FirstLevel.Name = "FirstLevel";
            this.FirstLevel.Size = new System.Drawing.Size(29, 25);
            this.FirstLevel.TabIndex = 1;
            this.FirstLevel.Text = "1:";
            this.FirstLevel.Visible = false;
            // 
            // DoneButton
            // 
            this.DoneButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.DoneButton.Enabled = false;
            this.DoneButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.DoneButton.Location = new System.Drawing.Point(300, 632);
            this.DoneButton.Margin = new System.Windows.Forms.Padding(2);
            this.DoneButton.Name = "DoneButton";
            this.DoneButton.Size = new System.Drawing.Size(110, 40);
            this.DoneButton.TabIndex = 0;
            this.DoneButton.Text = "Done";
            this.DoneButton.UseVisualStyleBackColor = false;
            this.DoneButton.Click += new System.EventHandler(this.DoneButton_Click);
            // 
            // Edit_Blinds
            // 
            this.Edit_Blinds.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Edit_Blinds.Enabled = false;
            this.Edit_Blinds.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Edit_Blinds.Location = new System.Drawing.Point(615, 24);
            this.Edit_Blinds.Margin = new System.Windows.Forms.Padding(0);
            this.Edit_Blinds.Name = "Edit_Blinds";
            this.Edit_Blinds.Size = new System.Drawing.Size(72, 28);
            this.Edit_Blinds.TabIndex = 12;
            this.Edit_Blinds.Text = "Edit Blinds";
            this.Edit_Blinds.UseVisualStyleBackColor = false;
            this.Edit_Blinds.Click += new System.EventHandler(this.Edit_Blinds_Click);
            // 
            // AnteLabel
            // 
            this.AnteLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AnteLabel.AutoSize = true;
            this.AnteLabel.BackColor = System.Drawing.Color.Transparent;
            this.AnteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AnteLabel.ForeColor = System.Drawing.Color.Cornsilk;
            this.AnteLabel.Location = new System.Drawing.Point(587, 407);
            this.AnteLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AnteLabel.Name = "AnteLabel";
            this.AnteLabel.Size = new System.Drawing.Size(67, 29);
            this.AnteLabel.TabIndex = 13;
            this.AnteLabel.Text = "Ante:";
            // 
            // AnteDisplay
            // 
            this.AnteDisplay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AnteDisplay.BackColor = System.Drawing.Color.Transparent;
            this.AnteDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AnteDisplay.ForeColor = System.Drawing.Color.Aqua;
            this.AnteDisplay.Location = new System.Drawing.Point(552, 459);
            this.AnteDisplay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AnteDisplay.Name = "AnteDisplay";
            this.AnteDisplay.Size = new System.Drawing.Size(132, 47);
            this.AnteDisplay.TabIndex = 14;
            this.AnteDisplay.Text = "0";
            this.AnteDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GrudithPoker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(721, 730);
            this.Controls.Add(this.Blinds_Panel);
            this.Controls.Add(this.PrevButton);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.ResetBox);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.PauseButton);
            this.Controls.Add(this.nextBlind);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.timer);
            this.Controls.Add(this.currentBlind);
            this.Controls.Add(this.Edit_Blinds);
            this.Controls.Add(this.AnteLabel);
            this.Controls.Add(this.AnteDisplay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "GrudithPoker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Grudith Poker";
            this.Blinds_Panel.ResumeLayout(false);
            this.Blinds_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BlindTime_Input)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer BlindTimer;
        private System.Windows.Forms.Label timer;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label currentBlind;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label nextBlind;
        private System.Windows.Forms.Button PauseButton;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.TextBox ResetBox;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Button PrevButton;
        private System.Windows.Forms.Timer CheckTimer;
        private System.Windows.Forms.Panel Blinds_Panel;
        private System.Windows.Forms.Button Edit_Blinds;
        private System.Windows.Forms.Button DoneButton;
        private System.Windows.Forms.ComboBox LevelCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label SecondLevel;
        private System.Windows.Forms.Label FirstLevel;
        private System.Windows.Forms.TextBox EighthAnte;
        private System.Windows.Forms.TextBox EighthBig;
        private System.Windows.Forms.TextBox EighthSmall;
        private System.Windows.Forms.TextBox SeventhAnte;
        private System.Windows.Forms.TextBox SeventhBig;
        private System.Windows.Forms.TextBox SeventhSmall;
        private System.Windows.Forms.TextBox SixthAnte;
        private System.Windows.Forms.TextBox SixthBig;
        private System.Windows.Forms.TextBox SixthSmall;
        private System.Windows.Forms.TextBox FifthAnte;
        private System.Windows.Forms.TextBox FifthBig;
        private System.Windows.Forms.TextBox FifthSmall;
        private System.Windows.Forms.TextBox FourthAnte;
        private System.Windows.Forms.TextBox FourthBig;
        private System.Windows.Forms.TextBox FourthSmall;
        private System.Windows.Forms.TextBox ThirdAnte;
        private System.Windows.Forms.TextBox ThirdBig;
        private System.Windows.Forms.TextBox ThirdSmall;
        private System.Windows.Forms.TextBox SecondAnte;
        private System.Windows.Forms.TextBox SecondBig;
        private System.Windows.Forms.TextBox SecondSmall;
        private System.Windows.Forms.TextBox FirstAnte;
        private System.Windows.Forms.TextBox FirstBig;
        private System.Windows.Forms.TextBox FirstSmall;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label EighthLevel;
        private System.Windows.Forms.Label SeventhLevel;
        private System.Windows.Forms.Label SixthLevel;
        private System.Windows.Forms.Label FifthLevel;
        private System.Windows.Forms.Label FourthLevel;
        private System.Windows.Forms.Label ThirdLevel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown BlindTime_Input;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label AnteLabel;
        private System.Windows.Forms.Label AnteDisplay;
        private System.Windows.Forms.Button UpdateButton;
    }
}

