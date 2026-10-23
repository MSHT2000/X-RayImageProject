namespace X_ray_project
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
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.open_image = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.HeatMap = new System.Windows.Forms.Button();
            this.Save_image = new System.Windows.Forms.Button();
            this.HotMap = new System.Windows.Forms.Button();
            this.CoolMap = new System.Windows.Forms.Button();
            this.SpringMap = new System.Windows.Forms.Button();
            this.JetMap = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.comapre_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.classification = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pictureBox3.Location = new System.Drawing.Point(12, 61);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(500, 500);
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            this.pictureBox3.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_DrawRectangel);
            this.pictureBox3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox3_MouseDown);
            this.pictureBox3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox3_MouseMove);
            this.pictureBox3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox3_MouseUp);
            // 
            // open_image
            // 
            this.open_image.BackColor = System.Drawing.SystemColors.Info;
            this.open_image.Location = new System.Drawing.Point(1192, 23);
            this.open_image.Name = "open_image";
            this.open_image.Size = new System.Drawing.Size(129, 49);
            this.open_image.TabIndex = 1;
            this.open_image.Text = "open image";
            this.open_image.UseVisualStyleBackColor = false;
            this.open_image.Click += new System.EventHandler(this.open_image_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pictureBox4.Location = new System.Drawing.Point(536, 61);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(500, 500);
            this.pictureBox4.TabIndex = 2;
            this.pictureBox4.TabStop = false;
            // 
            // HeatMap
            // 
            this.HeatMap.BackColor = System.Drawing.SystemColors.Info;
            this.HeatMap.Location = new System.Drawing.Point(1192, 100);
            this.HeatMap.Name = "HeatMap";
            this.HeatMap.Size = new System.Drawing.Size(129, 52);
            this.HeatMap.TabIndex = 4;
            this.HeatMap.Text = "HeatMap";
            this.HeatMap.UseVisualStyleBackColor = false;
            this.HeatMap.Click += new System.EventHandler(this.HeatMap_Button);
            // 
            // Save_image
            // 
            this.Save_image.BackColor = System.Drawing.SystemColors.Info;
            this.Save_image.Location = new System.Drawing.Point(1192, 495);
            this.Save_image.Name = "Save_image";
            this.Save_image.Size = new System.Drawing.Size(129, 66);
            this.Save_image.TabIndex = 7;
            this.Save_image.Text = "save image";
            this.Save_image.UseVisualStyleBackColor = false;
            this.Save_image.Click += new System.EventHandler(this.Save_image_Click);
            // 
            // HotMap
            // 
            this.HotMap.BackColor = System.Drawing.SystemColors.Info;
            this.HotMap.Location = new System.Drawing.Point(1192, 181);
            this.HotMap.Name = "HotMap";
            this.HotMap.Size = new System.Drawing.Size(129, 49);
            this.HotMap.TabIndex = 8;
            this.HotMap.Text = "HotMap";
            this.HotMap.UseVisualStyleBackColor = false;
            this.HotMap.Click += new System.EventHandler(this.HotMap_Button);
            // 
            // CoolMap
            // 
            this.CoolMap.BackColor = System.Drawing.SystemColors.Info;
            this.CoolMap.Location = new System.Drawing.Point(1192, 265);
            this.CoolMap.Name = "CoolMap";
            this.CoolMap.Size = new System.Drawing.Size(129, 49);
            this.CoolMap.TabIndex = 9;
            this.CoolMap.Text = "CoolMap";
            this.CoolMap.UseVisualStyleBackColor = false;
            this.CoolMap.Click += new System.EventHandler(this.CoolMap_Button);
            // 
            // SpringMap
            // 
            this.SpringMap.BackColor = System.Drawing.SystemColors.Info;
            this.SpringMap.Location = new System.Drawing.Point(1192, 345);
            this.SpringMap.Name = "SpringMap";
            this.SpringMap.Size = new System.Drawing.Size(129, 49);
            this.SpringMap.TabIndex = 10;
            this.SpringMap.Text = "SpringMap";
            this.SpringMap.UseVisualStyleBackColor = false;
            this.SpringMap.Click += new System.EventHandler(this.SpringMap_Button);
            // 
            // JetMap
            // 
            this.JetMap.BackColor = System.Drawing.SystemColors.Info;
            this.JetMap.Location = new System.Drawing.Point(1192, 420);
            this.JetMap.Name = "JetMap";
            this.JetMap.Size = new System.Drawing.Size(129, 49);
            this.JetMap.TabIndex = 11;
            this.JetMap.Text = "JetMap";
            this.JetMap.UseVisualStyleBackColor = false;
            this.JetMap.Click += new System.EventHandler(this.JetMap_Button);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Info;
            this.button1.Location = new System.Drawing.Point(988, 613);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 49);
            this.button1.TabIndex = 14;
            this.button1.Text = "RGB Button";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.RGB_Button);
            // 
            // comapre_button
            // 
            this.comapre_button.Location = new System.Drawing.Point(1155, 613);
            this.comapre_button.Name = "comapre_button";
            this.comapre_button.Size = new System.Drawing.Size(170, 47);
            this.comapre_button.TabIndex = 15;
            this.comapre_button.Text = "compare";
            this.comapre_button.UseVisualStyleBackColor = true;
            this.comapre_button.Click += new System.EventHandler(this.Comapre_Button);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Desktop;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Location = new System.Drawing.Point(21, 613);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 27);
            this.label1.TabIndex = 16;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // classification
            // 
            this.classification.Location = new System.Drawing.Point(754, 616);
            this.classification.Name = "classification";
            this.classification.Size = new System.Drawing.Size(171, 46);
            this.classification.TabIndex = 17;
            this.classification.Text = "classification";
            this.classification.UseVisualStyleBackColor = true;
            this.classification.Click += new System.EventHandler(this.classification_Click);
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1375, 693);
            this.Controls.Add(this.classification);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comapre_button);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.JetMap);
            this.Controls.Add(this.SpringMap);
            this.Controls.Add(this.CoolMap);
            this.Controls.Add(this.HotMap);
            this.Controls.Add(this.Save_image);
            this.Controls.Add(this.HeatMap);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.open_image);
            this.Controls.Add(this.pictureBox3);
            this.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button open_image;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button HeatMap;
        private System.Windows.Forms.Button Save_image;
        private System.Windows.Forms.Button HotMap;
        private System.Windows.Forms.Button CoolMap;
        private System.Windows.Forms.Button SpringMap;
        private System.Windows.Forms.Button JetMap;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button comapre_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button classification;
    }
}

