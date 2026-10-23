namespace Xray_image_new_Project
{
    partial class ColorMapForm
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
            this.HeatMap_Button = new System.Windows.Forms.Button();
            this.JetMap_Button = new System.Windows.Forms.Button();
            this.CoolMap_Button = new System.Windows.Forms.Button();
            this.SpringMap_Button = new System.Windows.Forms.Button();
            this.HotMap_Button = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Done_Button = new System.Windows.Forms.Button();
            this.RectangelRadio_Button = new System.Windows.Forms.RadioButton();
            this.PenRadio_Button = new System.Windows.Forms.RadioButton();
            this.CircleRadio_Button = new System.Windows.Forms.RadioButton();
            this.Erase_Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // HeatMap_Button
            // 
            this.HeatMap_Button.BackColor = System.Drawing.SystemColors.Info;
            this.HeatMap_Button.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.HeatMap_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.HeatMap_Button.Location = new System.Drawing.Point(693, 24);
            this.HeatMap_Button.Name = "HeatMap_Button";
            this.HeatMap_Button.Size = new System.Drawing.Size(226, 55);
            this.HeatMap_Button.TabIndex = 0;
            this.HeatMap_Button.Text = "HeatMap";
            this.HeatMap_Button.UseVisualStyleBackColor = false;
            this.HeatMap_Button.Click += new System.EventHandler(this.HeatMap_Button_Click);
            // 
            // JetMap_Button
            // 
            this.JetMap_Button.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.JetMap_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.JetMap_Button.Location = new System.Drawing.Point(693, 99);
            this.JetMap_Button.Name = "JetMap_Button";
            this.JetMap_Button.Size = new System.Drawing.Size(226, 55);
            this.JetMap_Button.TabIndex = 1;
            this.JetMap_Button.Text = "JetMap";
            this.JetMap_Button.UseVisualStyleBackColor = false;
            this.JetMap_Button.Click += new System.EventHandler(this.JetMap_Button_Click);
            // 
            // CoolMap_Button
            // 
            this.CoolMap_Button.BackColor = System.Drawing.SystemColors.Info;
            this.CoolMap_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.CoolMap_Button.Location = new System.Drawing.Point(450, 99);
            this.CoolMap_Button.Name = "CoolMap_Button";
            this.CoolMap_Button.Size = new System.Drawing.Size(226, 55);
            this.CoolMap_Button.TabIndex = 2;
            this.CoolMap_Button.Text = "CoolMap";
            this.CoolMap_Button.UseVisualStyleBackColor = false;
            this.CoolMap_Button.Click += new System.EventHandler(this.CoolMap_Button_Click);
            // 
            // SpringMap_Button
            // 
            this.SpringMap_Button.BackColor = System.Drawing.SystemColors.Info;
            this.SpringMap_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.SpringMap_Button.Location = new System.Drawing.Point(693, 175);
            this.SpringMap_Button.Name = "SpringMap_Button";
            this.SpringMap_Button.Size = new System.Drawing.Size(226, 55);
            this.SpringMap_Button.TabIndex = 3;
            this.SpringMap_Button.Text = "SpringMap";
            this.SpringMap_Button.UseVisualStyleBackColor = false;
            this.SpringMap_Button.Click += new System.EventHandler(this.SpringMap_Button_Click);
            // 
            // HotMap_Button
            // 
            this.HotMap_Button.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.HotMap_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.HotMap_Button.Location = new System.Drawing.Point(450, 24);
            this.HotMap_Button.Name = "HotMap_Button";
            this.HotMap_Button.Size = new System.Drawing.Size(226, 55);
            this.HotMap_Button.TabIndex = 4;
            this.HotMap_Button.Text = "HotMap";
            this.HotMap_Button.UseVisualStyleBackColor = false;
            this.HotMap_Button.Click += new System.EventHandler(this.HotMap_Button_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox1.Location = new System.Drawing.Point(28, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 256);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.DoubleClick += new System.EventHandler(this.Save_Button_Click);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // Done_Button
            // 
            this.Done_Button.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.Done_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Done_Button.Location = new System.Drawing.Point(450, 175);
            this.Done_Button.Name = "Done_Button";
            this.Done_Button.Size = new System.Drawing.Size(226, 55);
            this.Done_Button.TabIndex = 9;
            this.Done_Button.Text = "Done";
            this.Done_Button.UseVisualStyleBackColor = false;
            this.Done_Button.Click += new System.EventHandler(this.Done_Button_Click);
            // 
            // RectangelRadio_Button
            // 
            this.RectangelRadio_Button.AutoSize = true;
            this.RectangelRadio_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RectangelRadio_Button.Location = new System.Drawing.Point(460, 382);
            this.RectangelRadio_Button.Name = "RectangelRadio_Button";
            this.RectangelRadio_Button.Size = new System.Drawing.Size(105, 24);
            this.RectangelRadio_Button.TabIndex = 10;
            this.RectangelRadio_Button.Text = "Rectangel";
            this.RectangelRadio_Button.UseVisualStyleBackColor = true;
            // 
            // PenRadio_Button
            // 
            this.PenRadio_Button.AutoSize = true;
            this.PenRadio_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PenRadio_Button.Location = new System.Drawing.Point(824, 382);
            this.PenRadio_Button.Name = "PenRadio_Button";
            this.PenRadio_Button.Size = new System.Drawing.Size(59, 24);
            this.PenRadio_Button.TabIndex = 11;
            this.PenRadio_Button.Text = "Pen";
            this.PenRadio_Button.UseVisualStyleBackColor = true;
            // 
            // CircleRadio_Button
            // 
            this.CircleRadio_Button.AutoSize = true;
            this.CircleRadio_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CircleRadio_Button.Location = new System.Drawing.Point(653, 382);
            this.CircleRadio_Button.Name = "CircleRadio_Button";
            this.CircleRadio_Button.Size = new System.Drawing.Size(74, 24);
            this.CircleRadio_Button.TabIndex = 12;
            this.CircleRadio_Button.Text = "Circle";
            this.CircleRadio_Button.UseVisualStyleBackColor = true;
            // 
            // Erase_Button
            // 
            this.Erase_Button.BackColor = System.Drawing.SystemColors.Info;
            this.Erase_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Erase_Button.Location = new System.Drawing.Point(575, 263);
            this.Erase_Button.Name = "Erase_Button";
            this.Erase_Button.Size = new System.Drawing.Size(226, 55);
            this.Erase_Button.TabIndex = 13;
            this.Erase_Button.Text = "Erase";
            this.Erase_Button.UseVisualStyleBackColor = false;
            this.Erase_Button.Click += new System.EventHandler(this.Erase_Button_Click);
            // 
            // ColorMapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(944, 564);
            this.Controls.Add(this.Erase_Button);
            this.Controls.Add(this.CircleRadio_Button);
            this.Controls.Add(this.PenRadio_Button);
            this.Controls.Add(this.RectangelRadio_Button);
            this.Controls.Add(this.Done_Button);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.HotMap_Button);
            this.Controls.Add(this.SpringMap_Button);
            this.Controls.Add(this.CoolMap_Button);
            this.Controls.Add(this.JetMap_Button);
            this.Controls.Add(this.HeatMap_Button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "ColorMapForm";
            this.Text = "ColorMapForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button HeatMap_Button;
        private System.Windows.Forms.Button JetMap_Button;
        private System.Windows.Forms.Button CoolMap_Button;
        private System.Windows.Forms.Button SpringMap_Button;
        private System.Windows.Forms.Button HotMap_Button;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Done_Button;
        private System.Windows.Forms.RadioButton RectangelRadio_Button;
        private System.Windows.Forms.RadioButton PenRadio_Button;
        private System.Windows.Forms.RadioButton CircleRadio_Button;
        private System.Windows.Forms.Button Erase_Button;
    }
}