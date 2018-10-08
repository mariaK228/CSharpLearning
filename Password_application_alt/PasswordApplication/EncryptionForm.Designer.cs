namespace PasswordApplication
{
    partial class EncryptionForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.passwordText = new System.Windows.Forms.TextBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Введите пароль";
            // 
            // passwordText
            // 
            this.passwordText.Location = new System.Drawing.Point(12, 30);
            this.passwordText.Name = "passwordText";
<<<<<<< HEAD
<<<<<<< HEAD
            this.passwordText.PasswordChar = '*';
=======
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
=======
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
            this.passwordText.Size = new System.Drawing.Size(425, 20);
            this.passwordText.TabIndex = 2;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(235, 56);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(202, 23);
            this.CancelButton.TabIndex = 3;
            this.CancelButton.Text = "Отмена";
            this.CancelButton.UseVisualStyleBackColor = true;
<<<<<<< HEAD
<<<<<<< HEAD
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
=======
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
=======
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(12, 56);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(202, 23);
            this.OkButton.TabIndex = 4;
            this.OkButton.Text = "Ок";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // EncryptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 103);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.passwordText);
            this.Controls.Add(this.label1);
            this.Name = "EncryptionForm";
            this.Text = "EncryptionForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox passwordText;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OkButton;
    }
}