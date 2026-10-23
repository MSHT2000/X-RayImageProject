namespace Xray_image_new_Project
{
    partial class CommentForm
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
            this.Submit_Button = new System.Windows.Forms.Button();
            this.Done_Button = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(55, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 256);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown_1);
            // 
            // Submit_Button
            // 
            this.Submit_Button.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.Submit_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Submit_Button.Location = new System.Drawing.Point(482, 35);
            this.Submit_Button.Name = "Submit_Button";
            this.Submit_Button.Size = new System.Drawing.Size(226, 55);
            this.Submit_Button.TabIndex = 13;
            this.Submit_Button.Text = "Submit";
            this.Submit_Button.UseVisualStyleBackColor = false;
            this.Submit_Button.Click += new System.EventHandler(this.Submit_Button_Click);
            // 
            // Done_Button
            // 
            this.Done_Button.BackColor = System.Drawing.SystemColors.Info;
            this.Done_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Done_Button.Location = new System.Drawing.Point(482, 115);
            this.Done_Button.Name = "Done_Button";
            this.Done_Button.Size = new System.Drawing.Size(226, 55);
            this.Done_Button.TabIndex = 14;
            this.Done_Button.Text = "Done";
            this.Done_Button.UseVisualStyleBackColor = false;
            this.Done_Button.Click += new System.EventHandler(this.Done_Button_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBox1.Location = new System.Drawing.Point(482, 210);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(226, 81);
            this.textBox1.TabIndex = 15;
            this.textBox1.Text = "Add Comment Here";
            // 
            // CommentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(796, 364);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Done_Button);
            this.Controls.Add(this.Submit_Button);
            this.Controls.Add(this.pictureBox1);
            this.Name = "CommentForm";
            this.Text = "CommentForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Submit_Button;
        private System.Windows.Forms.Button Done_Button;
        private System.Windows.Forms.TextBox textBox1;
    }
}