namespace Xray_image_new_Project
{
    partial class RecordAudio
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
            this.label1 = new System.Windows.Forms.Label();
            this.Record_Button = new System.Windows.Forms.Button();
            this.Stop_Button = new System.Windows.Forms.Button();
            this.labelTimer = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Compress_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(459, 71);
            this.label1.TabIndex = 0;
            this.label1.Text = "Audio Recorder";
            // 
            // Record_Button
            // 
            this.Record_Button.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.Record_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Record_Button.Location = new System.Drawing.Point(159, 280);
            this.Record_Button.Name = "Record_Button";
            this.Record_Button.Size = new System.Drawing.Size(226, 55);
            this.Record_Button.TabIndex = 1;
            this.Record_Button.Text = "Record";
            this.Record_Button.UseVisualStyleBackColor = false;
            this.Record_Button.Click += new System.EventHandler(this.Record_Button_Click);
            // 
            // Stop_Button
            // 
            this.Stop_Button.BackColor = System.Drawing.SystemColors.Info;
            this.Stop_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Stop_Button.Location = new System.Drawing.Point(159, 355);
            this.Stop_Button.Name = "Stop_Button";
            this.Stop_Button.Size = new System.Drawing.Size(226, 55);
            this.Stop_Button.TabIndex = 2;
            this.Stop_Button.Text = "Stop";
            this.Stop_Button.UseVisualStyleBackColor = false;
            this.Stop_Button.Click += new System.EventHandler(this.Stop_Button_Click);
            // 
            // labelTimer
            // 
            this.labelTimer.AutoSize = true;
            this.labelTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTimer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.labelTimer.Location = new System.Drawing.Point(165, 165);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Size = new System.Drawing.Size(213, 54);
            this.labelTimer.TabIndex = 3;
            this.labelTimer.Text = "00:00:00";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Compress_Button
            // 
            this.Compress_Button.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.Compress_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Compress_Button.Location = new System.Drawing.Point(159, 431);
            this.Compress_Button.Name = "Compress_Button";
            this.Compress_Button.Size = new System.Drawing.Size(226, 55);
            this.Compress_Button.TabIndex = 4;
            this.Compress_Button.Text = "Compress";
            this.Compress_Button.UseVisualStyleBackColor = false;
            this.Compress_Button.Click += new System.EventHandler(this.Compress_Button_Click);
            // 
            // RecordAudio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(561, 530);
            this.Controls.Add(this.Compress_Button);
            this.Controls.Add(this.labelTimer);
            this.Controls.Add(this.Stop_Button);
            this.Controls.Add(this.Record_Button);
            this.Controls.Add(this.label1);
            this.Name = "RecordAudio";
            this.Text = "RecordAudio";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Record_Button;
        private System.Windows.Forms.Button Stop_Button;
        private System.Windows.Forms.Label labelTimer;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button Compress_Button;
    }
}