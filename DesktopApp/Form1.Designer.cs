namespace DesktopApp
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
            this.clickbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // clickbtn
            // 
            this.clickbtn.Location = new System.Drawing.Point(225, 191);
            this.clickbtn.Name = "clickbtn";
            this.clickbtn.Size = new System.Drawing.Size(317, 66);
            this.clickbtn.TabIndex = 0;
            this.clickbtn.Text = "Clickez moi";
            this.clickbtn.UseVisualStyleBackColor = true;
            this.clickbtn.Click += new System.EventHandler(this.clickbtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 379);
            this.Controls.Add(this.clickbtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button clickbtn;
    }
}

