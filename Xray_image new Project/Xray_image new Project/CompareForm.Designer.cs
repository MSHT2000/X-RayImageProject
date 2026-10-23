namespace Xray_image_new_Project
{
    partial class CompareForm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.Compare_Button = new System.Windows.Forms.Button();
            this.Rest_Images_Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(36, 46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 256);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.Location = new System.Drawing.Point(445, 46);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(256, 256);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // Compare_Button
            // 
            this.Compare_Button.BackColor = System.Drawing.SystemColors.Info;
            this.Compare_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Compare_Button.Location = new System.Drawing.Point(36, 393);
            this.Compare_Button.Name = "Compare_Button";
            this.Compare_Button.Size = new System.Drawing.Size(226, 55);
            this.Compare_Button.TabIndex = 3;
            this.Compare_Button.Text = "Compare";
            this.Compare_Button.UseVisualStyleBackColor = false;
            this.Compare_Button.Click += new System.EventHandler(this.Compare_Button_Click);
            // 
            // Rest_Images_Button
            // 
            this.Rest_Images_Button.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.Rest_Images_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Rest_Images_Button.Location = new System.Drawing.Point(445, 393);
            this.Rest_Images_Button.Name = "Rest_Images_Button";
            this.Rest_Images_Button.Size = new System.Drawing.Size(226, 55);
            this.Rest_Images_Button.TabIndex = 4;
            this.Rest_Images_Button.Text = "Rest Images";
            this.Rest_Images_Button.UseVisualStyleBackColor = false;
            this.Rest_Images_Button.Click += new System.EventHandler(this.Rest_Images_Button_Click);
            // 
            // CompareForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(857, 498);
            this.Controls.Add(this.Rest_Images_Button);
            this.Controls.Add(this.Compare_Button);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "CompareForm";
            this.Text = "CompareForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button Compare_Button;
        private System.Windows.Forms.Button Rest_Images_Button;
    }
}