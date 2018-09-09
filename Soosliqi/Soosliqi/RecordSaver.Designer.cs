namespace Soosliqi
{
    partial class RecordSaver
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
            this.gamerName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.top10 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // gamerName
            // 
            this.gamerName.Location = new System.Drawing.Point(57, 72);
            this.gamerName.Name = "gamerName";
            this.gamerName.Size = new System.Drawing.Size(207, 20);
            this.gamerName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Имя ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(57, 126);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(207, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // top10
            // 
            this.top10.Location = new System.Drawing.Point(57, 186);
            this.top10.Name = "top10";
            this.top10.Size = new System.Drawing.Size(207, 250);
            this.top10.TabIndex = 3;
            this.top10.Text = "";
            // 
            // RecordSaver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 468);
            this.Controls.Add(this.top10);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gamerName);
            this.Name = "RecordSaver";
            this.Text = "RecordSaver";
            this.Load += new System.EventHandler(this.RecordSaver_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox gamerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox top10;
    }
}