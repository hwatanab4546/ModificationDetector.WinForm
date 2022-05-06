namespace ModificationDetector.WinForm.Sample
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRestore = new System.Windows.Forms.Button();
            this.modificationDetectingCheckBox1 = new ModificationDetector.WinForm.ModificationDetectingCheckBox();
            this.modificationDetectingComboBox1 = new ModificationDetector.WinForm.ModificationDetectingComboBox();
            this.modificationDetectingTextBox5 = new ModificationDetector.WinForm.ModificationDetectingTextBox();
            this.modificationDetectingTextBox4 = new ModificationDetector.WinForm.ModificationDetectingTextBox();
            this.modificationDetectingTextBox3 = new ModificationDetector.WinForm.ModificationDetectingTextBox();
            this.modificationDetectingTextBox2 = new ModificationDetector.WinForm.ModificationDetectingTextBox();
            this.modificationDetectingTextBox1 = new ModificationDetector.WinForm.ModificationDetectingTextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(585, 12);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(75, 23);
            this.btnRestore.TabIndex = 5;
            this.btnRestore.Text = "Restore";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // modificationDetectingCheckBox1
            // 
            this.modificationDetectingCheckBox1.AutoSize = true;
            this.modificationDetectingCheckBox1.Location = new System.Drawing.Point(134, 257);
            this.modificationDetectingCheckBox1.Name = "modificationDetectingCheckBox1";
            this.modificationDetectingCheckBox1.Size = new System.Drawing.Size(193, 16);
            this.modificationDetectingCheckBox1.TabIndex = 7;
            this.modificationDetectingCheckBox1.Text = "modificationDetectingCheckBox1";
            this.modificationDetectingCheckBox1.UseVisualStyleBackColor = true;
            // 
            // modificationDetectingComboBox1
            // 
            this.modificationDetectingComboBox1.FormattingEnabled = true;
            this.modificationDetectingComboBox1.Location = new System.Drawing.Point(134, 203);
            this.modificationDetectingComboBox1.Name = "modificationDetectingComboBox1";
            this.modificationDetectingComboBox1.Size = new System.Drawing.Size(188, 20);
            this.modificationDetectingComboBox1.TabIndex = 6;
            // 
            // modificationDetectingTextBox5
            // 
            this.modificationDetectingTextBox5.Location = new System.Drawing.Point(134, 178);
            this.modificationDetectingTextBox5.Name = "modificationDetectingTextBox5";
            this.modificationDetectingTextBox5.Size = new System.Drawing.Size(188, 19);
            this.modificationDetectingTextBox5.TabIndex = 4;
            // 
            // modificationDetectingTextBox4
            // 
            this.modificationDetectingTextBox4.Location = new System.Drawing.Point(134, 153);
            this.modificationDetectingTextBox4.Name = "modificationDetectingTextBox4";
            this.modificationDetectingTextBox4.Size = new System.Drawing.Size(188, 19);
            this.modificationDetectingTextBox4.TabIndex = 3;
            // 
            // modificationDetectingTextBox3
            // 
            this.modificationDetectingTextBox3.Location = new System.Drawing.Point(134, 128);
            this.modificationDetectingTextBox3.Name = "modificationDetectingTextBox3";
            this.modificationDetectingTextBox3.Size = new System.Drawing.Size(188, 19);
            this.modificationDetectingTextBox3.TabIndex = 2;
            // 
            // modificationDetectingTextBox2
            // 
            this.modificationDetectingTextBox2.Location = new System.Drawing.Point(134, 103);
            this.modificationDetectingTextBox2.Name = "modificationDetectingTextBox2";
            this.modificationDetectingTextBox2.Size = new System.Drawing.Size(188, 19);
            this.modificationDetectingTextBox2.TabIndex = 1;
            // 
            // modificationDetectingTextBox1
            // 
            this.modificationDetectingTextBox1.Location = new System.Drawing.Point(134, 78);
            this.modificationDetectingTextBox1.Name = "modificationDetectingTextBox1";
            this.modificationDetectingTextBox1.Size = new System.Drawing.Size(188, 19);
            this.modificationDetectingTextBox1.TabIndex = 0;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(342, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 8;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnRestart
            // 
            this.btnRestart.Location = new System.Drawing.Point(423, 12);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(75, 23);
            this.btnRestart.TabIndex = 9;
            this.btnRestart.Text = "Restart";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(504, 12);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 10;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatus.Location = new System.Drawing.Point(450, 56);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(100, 23);
            this.lblStatus.TabIndex = 11;
            this.lblStatus.Text = "label1";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.modificationDetectingCheckBox1);
            this.Controls.Add(this.modificationDetectingComboBox1);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.modificationDetectingTextBox5);
            this.Controls.Add(this.modificationDetectingTextBox4);
            this.Controls.Add(this.modificationDetectingTextBox3);
            this.Controls.Add(this.modificationDetectingTextBox2);
            this.Controls.Add(this.modificationDetectingTextBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ModificationDetectingTextBox modificationDetectingTextBox1;
        private ModificationDetectingTextBox modificationDetectingTextBox2;
        private ModificationDetectingTextBox modificationDetectingTextBox3;
        private ModificationDetectingTextBox modificationDetectingTextBox4;
        private ModificationDetectingTextBox modificationDetectingTextBox5;
        private System.Windows.Forms.Button btnRestore;
        private ModificationDetectingComboBox modificationDetectingComboBox1;
        private ModificationDetectingCheckBox modificationDetectingCheckBox1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblStatus;
    }
}

