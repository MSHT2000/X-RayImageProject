namespace Xray_image_new_Project
{
    partial class CompressForm
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
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Done_Button = new System.Windows.Forms.Button();
            this.Create_Zip_Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBar1
            // 
            this.trackBar1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.trackBar1.LargeChange = 0;
            this.trackBar1.Location = new System.Drawing.Point(58, 407);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.trackBar1.RightToLeftLayout = true;
            this.trackBar1.Size = new System.Drawing.Size(533, 56);
            this.trackBar1.TabIndex = 2;
            this.trackBar1.Value = 100;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 16.2F);
            this.label1.Location = new System.Drawing.Point(643, 407);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 39);
            this.label1.TabIndex = 3;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.Location = new System.Drawing.Point(195, 60);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(256, 256);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 16.2F);
            this.label2.Location = new System.Drawing.Point(198, 498);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(220, 39);
            this.label2.TabIndex = 4;
            this.label2.Text = "Size newImage:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 16.2F);
            this.label3.Location = new System.Drawing.Point(442, 498);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 39);
            this.label3.TabIndex = 5;
            // 
            // Done_Button
            // 
            this.Done_Button.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.Done_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Done_Button.Location = new System.Drawing.Point(602, 40);
            this.Done_Button.Name = "Done_Button";
            this.Done_Button.Size = new System.Drawing.Size(226, 55);
            this.Done_Button.TabIndex = 12;
            this.Done_Button.Text = "Done";
            this.Done_Button.UseVisualStyleBackColor = false;
            this.Done_Button.Click += new System.EventHandler(this.Done_Button_Click);
            // 
            // Create_Zip_Button
            // 
            this.Create_Zip_Button.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.Create_Zip_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Create_Zip_Button.Location = new System.Drawing.Point(602, 125);
            this.Create_Zip_Button.Name = "Create_Zip_Button";
            this.Create_Zip_Button.Size = new System.Drawing.Size(226, 55);
            this.Create_Zip_Button.TabIndex = 13;
            this.Create_Zip_Button.Text = "Export as Zip";
            this.Create_Zip_Button.UseVisualStyleBackColor = false;
            this.Create_Zip_Button.Click += new System.EventHandler(this.Create_Zip_Button_Click);
            // 
            // CompressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(856, 592);
            this.Controls.Add(this.Create_Zip_Button);
            this.Controls.Add(this.Done_Button);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.pictureBox2);
            this.Name = "CompressForm";
            this.Text = "CompressForm";
            this.Load += new System.EventHandler(this.CompressForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Done_Button;
        private System.Windows.Forms.Button Create_Zip_Button;
    }
}