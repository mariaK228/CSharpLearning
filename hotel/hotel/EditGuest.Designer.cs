﻿namespace hotel
{
    partial class EditGuest
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
            this.AddButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dishBox = new System.Windows.Forms.DomainUpDown();
            this.roomBox = new System.Windows.Forms.DomainUpDown();
            this.surnameBox = new System.Windows.Forms.DomainUpDown();
            this.SuspendLayout();
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(139, 161);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 13;
            this.AddButton.Text = "Изменить";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Блюдо на завтрак";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Номер";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Фамилия";
            // 
            // dishBox
            // 
            this.dishBox.Location = new System.Drawing.Point(107, 135);
            this.dishBox.Name = "dishBox";
            this.dishBox.Size = new System.Drawing.Size(213, 20);
            this.dishBox.TabIndex = 9;
            // 
            // roomBox
            // 
            this.roomBox.Location = new System.Drawing.Point(107, 109);
            this.roomBox.Name = "roomBox";
            this.roomBox.Size = new System.Drawing.Size(213, 20);
            this.roomBox.TabIndex = 8;
            // 
            // surnameBox
            // 
            this.surnameBox.Location = new System.Drawing.Point(107, 83);
            this.surnameBox.Name = "surnameBox";
            this.surnameBox.Size = new System.Drawing.Size(213, 20);
            this.surnameBox.TabIndex = 14;
            // 
            // EditGuest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 261);
            this.Controls.Add(this.surnameBox);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dishBox);
            this.Controls.Add(this.roomBox);
            this.Name = "EditGuest";
            this.Text = "EditGuest";
            this.Load += new System.EventHandler(this.EditGuest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DomainUpDown dishBox;
        private System.Windows.Forms.DomainUpDown roomBox;
        private System.Windows.Forms.DomainUpDown surnameBox;
    }
}