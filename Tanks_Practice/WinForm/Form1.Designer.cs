namespace WinForm
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.newGameTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.reportTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.exitTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.scoreTSL = new System.Windows.Forms.ToolStripLabel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameTSMI,
            this.settingsTSMI,
            this.reportTSMI,
            this.exitTSMI});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(430, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // newGameTSMI
            // 
            this.newGameTSMI.Name = "newGameTSMI";
            this.newGameTSMI.Size = new System.Drawing.Size(74, 20);
            this.newGameTSMI.Text = "NewGame";
            this.newGameTSMI.Click += new System.EventHandler(this.newGameTSMI_Click);
            // 
            // settingsTSMI
            // 
            this.settingsTSMI.Name = "settingsTSMI";
            this.settingsTSMI.Size = new System.Drawing.Size(61, 20);
            this.settingsTSMI.Text = "Settings";
            this.settingsTSMI.Click += new System.EventHandler(this.settingsTSMI_Click);
            // 
            // reportTSMI
            // 
            this.reportTSMI.Name = "reportTSMI";
            this.reportTSMI.Size = new System.Drawing.Size(54, 20);
            this.reportTSMI.Text = "Report";
            this.reportTSMI.Click += new System.EventHandler(this.reportTSMI_Click);
            // 
            // exitTSMI
            // 
            this.exitTSMI.Name = "exitTSMI";
            this.exitTSMI.Size = new System.Drawing.Size(38, 20);
            this.exitTSMI.Text = "Exit";
            this.exitTSMI.Click += new System.EventHandler(this.exitTSMI_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.Location = new System.Drawing.Point(0, 27);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(430, 430);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel,
            this.scoreTSL});
            this.toolStrip1.Location = new System.Drawing.Point(0, 460);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(430, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip";
            // 
            // toolStripLabel
            // 
            this.toolStripLabel.Name = "toolStripLabel";
            this.toolStripLabel.Size = new System.Drawing.Size(39, 22);
            this.toolStripLabel.Text = "Score:";
            // 
            // scoreTSL
            // 
            this.scoreTSL.Name = "scoreTSL";
            this.scoreTSL.Size = new System.Drawing.Size(13, 22);
            this.scoreTSL.Text = "0";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 25;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 485);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tanks";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem newGameTSMI;
        private System.Windows.Forms.ToolStripMenuItem settingsTSMI;
        private System.Windows.Forms.ToolStripMenuItem exitTSMI;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel;
        private System.Windows.Forms.ToolStripLabel scoreTSL;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolStripMenuItem reportTSMI;
    }
}

