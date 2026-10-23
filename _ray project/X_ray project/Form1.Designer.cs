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
            this.input_Image_label = new System.Windows.Forms.Label();
            this.output_image_label = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox3.Location = new System.Drawing.Point(64, 85);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(522, 354);
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
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
            this.pictureBox4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox4.Location = new System.Drawing.Point(622, 85);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(522, 354);
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
            this.Save_image.Location = new System.Drawing.Point(1192, 497);
            this.Save_image.Name = "Save_image";
            this.Save_image.Size = new System.Drawing.Size(129, 49);
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
            // input_Image_label
            // 
            this.input_Image_label.AutoSize = true;
            this.input_Image_label.BackColor = System.Drawing.SystemColors.Desktop;
            this.input_Image_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.input_Image_label.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.input_Image_label.Font = new System.Drawing.Font("Gadugi", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.input_Image_label.Location = new System.Drawing.Point(223, 23);
            this.input_Image_label.Name = "input_Image_label";
            this.input_Image_label.Size = new System.Drawing.Size(212, 42);
            this.input_Image_label.TabIndex = 12;
            this.input_Image_label.Text = "Input_Image";
            // 
            // output_image_label
            // 
            this.output_image_label.AutoSize = true;
            this.output_image_label.BackColor = System.Drawing.SystemColors.Desktop;
            this.output_image_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.output_image_label.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.output_image_label.Font = new System.Drawing.Font("Gadugi", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.output_image_label.Location = new System.Drawing.Point(772, 20);
            this.output_image_label.Name = "output_image_label";
            this.output_image_label.Size = new System.Drawing.Size(240, 42);
            this.output_image_label.TabIndex = 13;
            this.output_image_label.Text = "OutPut_Image";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Info;
            this.button1.Location = new System.Drawing.Point(1042, 497);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 49);
            this.button1.TabIndex = 14;
            this.button1.Text = "RGB Button";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1337, 585);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.output_image_label);
            this.Controls.Add(this.input_Image_label);
            this.Controls.Add(this.JetMap);
            this.Controls.Add(this.SpringMap);
            this.Controls.Add(this.CoolMap);
            this.Controls.Add(this.HotMap);
            this.Controls.Add(this.Save_image);
            this.Controls.Add(this.HeatMap);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.open_image);
            this.Controls.Add(this.pictureBox3);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
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
        private System.Windows.Forms.Label input_Image_label;
        private System.Windows.Forms.Label output_image_label;
        private System.Windows.Forms.Button button1;
    }
}

