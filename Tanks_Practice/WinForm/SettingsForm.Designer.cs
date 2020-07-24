namespace WinForm
{
    partial class SettingsForm
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
            this.widthLbl = new System.Windows.Forms.Label();
            this.widthTB = new System.Windows.Forms.TrackBar();
            this.heightTB = new System.Windows.Forms.TrackBar();
            this.heightLbl = new System.Windows.Forms.Label();
            this.tanksCountTB = new System.Windows.Forms.TrackBar();
            this.tanksCountLbl = new System.Windows.Forms.Label();
            this.appleCountTB = new System.Windows.Forms.TrackBar();
            this.appleCountLbl = new System.Windows.Forms.Label();
            this.speedTB = new System.Windows.Forms.TrackBar();
            this.speedLbl = new System.Windows.Forms.Label();
            this.okBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.widthTB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightTB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tanksCountTB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appleCountTB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedTB)).BeginInit();
            this.SuspendLayout();
            // 
            // widthLbl
            // 
            this.widthLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.widthLbl.Location = new System.Drawing.Point(12, 9);
            this.widthLbl.Name = "widthLbl";
            this.widthLbl.Size = new System.Drawing.Size(209, 23);
            this.widthLbl.TabIndex = 0;
            this.widthLbl.Text = "Ширина игрового поля";
            this.widthLbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // widthTB
            // 
            this.widthTB.AutoSize = false;
            this.widthTB.LargeChange = 66;
            this.widthTB.Location = new System.Drawing.Point(12, 35);
            this.widthTB.Maximum = 1254;
            this.widthTB.Minimum = 430;
            this.widthTB.Name = "widthTB";
            this.widthTB.Size = new System.Drawing.Size(209, 45);
            this.widthTB.SmallChange = 33;
            this.widthTB.TabIndex = 2;
            this.widthTB.Value = 1254;
            // 
            // heightTB
            // 
            this.heightTB.AutoSize = false;
            this.heightTB.LargeChange = 66;
            this.heightTB.Location = new System.Drawing.Point(227, 35);
            this.heightTB.Maximum = 528;
            this.heightTB.Minimum = 430;
            this.heightTB.Name = "heightTB";
            this.heightTB.Size = new System.Drawing.Size(209, 45);
            this.heightTB.SmallChange = 33;
            this.heightTB.TabIndex = 4;
            this.heightTB.Value = 528;
            // 
            // heightLbl
            // 
            this.heightLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.heightLbl.Location = new System.Drawing.Point(227, 9);
            this.heightLbl.Name = "heightLbl";
            this.heightLbl.Size = new System.Drawing.Size(209, 23);
            this.heightLbl.TabIndex = 3;
            this.heightLbl.Text = "Высота игрового поля";
            this.heightLbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tanksCountTB
            // 
            this.tanksCountTB.AutoSize = false;
            this.tanksCountTB.LargeChange = 2;
            this.tanksCountTB.Location = new System.Drawing.Point(12, 122);
            this.tanksCountTB.Minimum = 1;
            this.tanksCountTB.Name = "tanksCountTB";
            this.tanksCountTB.Size = new System.Drawing.Size(209, 45);
            this.tanksCountTB.TabIndex = 6;
            this.tanksCountTB.Value = 5;
            // 
            // tanksCountLbl
            // 
            this.tanksCountLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tanksCountLbl.Location = new System.Drawing.Point(12, 96);
            this.tanksCountLbl.Name = "tanksCountLbl";
            this.tanksCountLbl.Size = new System.Drawing.Size(209, 23);
            this.tanksCountLbl.TabIndex = 5;
            this.tanksCountLbl.Text = "Количество танков";
            this.tanksCountLbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // appleCountTB
            // 
            this.appleCountTB.AutoSize = false;
            this.appleCountTB.LargeChange = 2;
            this.appleCountTB.Location = new System.Drawing.Point(227, 122);
            this.appleCountTB.Minimum = 1;
            this.appleCountTB.Name = "appleCountTB";
            this.appleCountTB.Size = new System.Drawing.Size(209, 45);
            this.appleCountTB.TabIndex = 8;
            this.appleCountTB.Value = 5;
            // 
            // appleCountLbl
            // 
            this.appleCountLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.appleCountLbl.Location = new System.Drawing.Point(227, 96);
            this.appleCountLbl.Name = "appleCountLbl";
            this.appleCountLbl.Size = new System.Drawing.Size(209, 23);
            this.appleCountLbl.TabIndex = 7;
            this.appleCountLbl.Text = "Количество яблок";
            this.appleCountLbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // speedTB
            // 
            this.speedTB.AutoSize = false;
            this.speedTB.Location = new System.Drawing.Point(12, 209);
            this.speedTB.Maximum = 20;
            this.speedTB.Minimum = 5;
            this.speedTB.Name = "speedTB";
            this.speedTB.Size = new System.Drawing.Size(209, 45);
            this.speedTB.TabIndex = 10;
            this.speedTB.Value = 5;
            // 
            // speedLbl
            // 
            this.speedLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.speedLbl.Location = new System.Drawing.Point(12, 183);
            this.speedLbl.Name = "speedLbl";
            this.speedLbl.Size = new System.Drawing.Size(209, 23);
            this.speedLbl.TabIndex = 9;
            this.speedLbl.Text = "Скорость передвижения";
            this.speedLbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(260, 202);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(132, 32);
            this.okBtn.TabIndex = 11;
            this.okBtn.Text = "Ok";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 273);
            this.ControlBox = false;
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.speedTB);
            this.Controls.Add(this.speedLbl);
            this.Controls.Add(this.appleCountTB);
            this.Controls.Add(this.appleCountLbl);
            this.Controls.Add(this.tanksCountTB);
            this.Controls.Add(this.tanksCountLbl);
            this.Controls.Add(this.heightTB);
            this.Controls.Add(this.heightLbl);
            this.Controls.Add(this.widthTB);
            this.Controls.Add(this.widthLbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.widthTB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightTB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tanksCountTB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appleCountTB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedTB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label widthLbl;
        private System.Windows.Forms.TrackBar widthTB;
        private System.Windows.Forms.TrackBar heightTB;
        private System.Windows.Forms.Label heightLbl;
        private System.Windows.Forms.TrackBar tanksCountTB;
        private System.Windows.Forms.Label tanksCountLbl;
        private System.Windows.Forms.TrackBar appleCountTB;
        private System.Windows.Forms.Label appleCountLbl;
        private System.Windows.Forms.TrackBar speedTB;
        private System.Windows.Forms.Label speedLbl;
        private System.Windows.Forms.Button okBtn;
    }
}