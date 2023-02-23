namespace WindowsFormsApp7
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cbRMA = new System.Windows.Forms.CheckBox();
            this.cbManCity = new System.Windows.Forms.CheckBox();
            this.cbPSG = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(211, 98);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 26);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(356, 98);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(245, 273);
            this.textBox1.TabIndex = 1;
            // 
            // cbRMA
            // 
            this.cbRMA.AutoSize = true;
            this.cbRMA.Location = new System.Drawing.Point(644, 135);
            this.cbRMA.Name = "cbRMA";
            this.cbRMA.Size = new System.Drawing.Size(83, 17);
            this.cbRMA.TabIndex = 2;
            this.cbRMA.Text = "Real Madrid";
            this.cbRMA.UseVisualStyleBackColor = true;
            // 
            // cbManCity
            // 
            this.cbManCity.AutoSize = true;
            this.cbManCity.Location = new System.Drawing.Point(644, 170);
            this.cbManCity.Name = "cbManCity";
            this.cbManCity.Size = new System.Drawing.Size(102, 17);
            this.cbManCity.TabIndex = 3;
            this.cbManCity.Text = "Manchester City";
            this.cbManCity.UseVisualStyleBackColor = true;
            // 
            // cbPSG
            // 
            this.cbPSG.AutoSize = true;
            this.cbPSG.Location = new System.Drawing.Point(644, 208);
            this.cbPSG.Name = "cbPSG";
            this.cbPSG.Size = new System.Drawing.Size(48, 17);
            this.cbPSG.TabIndex = 4;
            this.cbPSG.Text = "PSG";
            this.cbPSG.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cbPSG);
            this.Controls.Add(this.cbManCity);
            this.Controls.Add(this.cbRMA);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox cbRMA;
        private System.Windows.Forms.CheckBox cbManCity;
        private System.Windows.Forms.CheckBox cbPSG;
    }
}

