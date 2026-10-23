namespace Xray_image_new_Project
{
    partial class FilterForm
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.Search_Button = new System.Windows.Forms.Button();
            this.Size_radio_Button = new System.Windows.Forms.RadioButton();
            this.Date_radio_Button = new System.Windows.Forms.RadioButton();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.SizeTextBox = new System.Windows.Forms.TextBox();
            this.SizeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 22);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1027, 427);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // Search_Button
            // 
            this.Search_Button.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.Search_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Search_Button.Location = new System.Drawing.Point(1100, 37);
            this.Search_Button.Name = "Search_Button";
            this.Search_Button.Size = new System.Drawing.Size(226, 55);
            this.Search_Button.TabIndex = 14;
            this.Search_Button.Text = "Search";
            this.Search_Button.UseVisualStyleBackColor = false;
            this.Search_Button.Click += new System.EventHandler(this.Search_Button_Click);
            // 
            // Size_radio_Button
            // 
            this.Size_radio_Button.AutoSize = true;
            this.Size_radio_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Size_radio_Button.Location = new System.Drawing.Point(614, 518);
            this.Size_radio_Button.Name = "Size_radio_Button";
            this.Size_radio_Button.Size = new System.Drawing.Size(107, 29);
            this.Size_radio_Button.TabIndex = 19;
            this.Size_radio_Button.TabStop = true;
            this.Size_radio_Button.Text = "By Size";
            this.Size_radio_Button.UseVisualStyleBackColor = true;
            this.Size_radio_Button.CheckedChanged += new System.EventHandler(this.Size_radio_Button_CheckedChanged);
            // 
            // Date_radio_Button
            // 
            this.Date_radio_Button.AutoSize = true;
            this.Date_radio_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Date_radio_Button.Location = new System.Drawing.Point(893, 518);
            this.Date_radio_Button.Name = "Date_radio_Button";
            this.Date_radio_Button.Size = new System.Drawing.Size(109, 29);
            this.Date_radio_Button.TabIndex = 20;
            this.Date_radio_Button.TabStop = true;
            this.Date_radio_Button.Text = "By Date";
            this.Date_radio_Button.UseVisualStyleBackColor = true;
            this.Date_radio_Button.CheckedChanged += new System.EventHandler(this.Date_radio_Button_CheckedChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(832, 639);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(261, 27);
            this.dateTimePicker1.TabIndex = 21;
            this.dateTimePicker1.Visible = false;
            // 
            // SizeTextBox
            // 
            this.SizeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SizeTextBox.Location = new System.Drawing.Point(605, 634);
            this.SizeTextBox.Name = "SizeTextBox";
            this.SizeTextBox.Size = new System.Drawing.Size(87, 38);
            this.SizeTextBox.TabIndex = 23;
            this.SizeTextBox.Visible = false;
            // 
            // SizeLabel
            // 
            this.SizeLabel.AutoSize = true;
            this.SizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.SizeLabel.Location = new System.Drawing.Point(525, 641);
            this.SizeLabel.Name = "SizeLabel";
            this.SizeLabel.Size = new System.Drawing.Size(62, 25);
            this.SizeLabel.TabIndex = 24;
            this.SizeLabel.Text = "Size :";
            this.SizeLabel.Visible = false;
            // 
            // FilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1354, 792);
            this.Controls.Add(this.SizeLabel);
            this.Controls.Add(this.SizeTextBox);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.Date_radio_Button);
            this.Controls.Add(this.Size_radio_Button);
            this.Controls.Add(this.Search_Button);
            this.Controls.Add(this.listView1);
            this.Name = "FilterForm";
            this.Text = "FilterForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button Search_Button;
        private System.Windows.Forms.RadioButton Size_radio_Button;
        private System.Windows.Forms.RadioButton Date_radio_Button;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox SizeTextBox;
        private System.Windows.Forms.Label SizeLabel;
    }
}