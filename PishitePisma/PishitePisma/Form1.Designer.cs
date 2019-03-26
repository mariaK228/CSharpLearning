namespace PishitePisma
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.InputInputbox = new System.Windows.Forms.RichTextBox();
            this.MessageDisplay = new System.Windows.Forms.RichTextBox();
            this.SendMessage = new System.Windows.Forms.Button();
            this.UserIP = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // InputInputbox
            // 
            this.InputInputbox.Location = new System.Drawing.Point(32, 379);
            this.InputInputbox.Name = "InputInputbox";
            this.InputInputbox.Size = new System.Drawing.Size(291, 49);
            this.InputInputbox.TabIndex = 0;
            this.InputInputbox.Text = "";
            // 
            // MessageDisplay
            // 
            this.MessageDisplay.Location = new System.Drawing.Point(32, 42);
            this.MessageDisplay.Name = "MessageDisplay";
            this.MessageDisplay.Size = new System.Drawing.Size(291, 303);
            this.MessageDisplay.TabIndex = 1;
            this.MessageDisplay.Text = "";
            // 
            // SendMessage
            // 
            this.SendMessage.Location = new System.Drawing.Point(135, 434);
            this.SendMessage.Name = "SendMessage";
            this.SendMessage.Size = new System.Drawing.Size(75, 23);
            this.SendMessage.TabIndex = 2;
            this.SendMessage.Text = "Отправить";
            this.SendMessage.UseVisualStyleBackColor = true;
            this.SendMessage.Click += new System.EventHandler(this.SendMessage_Click);
            // 
            // UserIP
            // 
            this.UserIP.Location = new System.Drawing.Point(32, 16);
            this.UserIP.Name = "UserIP";
            this.UserIP.Size = new System.Drawing.Size(291, 20);
            this.UserIP.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 461);
            this.Controls.Add(this.UserIP);
            this.Controls.Add(this.SendMessage);
            this.Controls.Add(this.MessageDisplay);
            this.Controls.Add(this.InputInputbox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox InputInputbox;
        private System.Windows.Forms.RichTextBox MessageDisplay;
        private System.Windows.Forms.Button SendMessage;
        private System.Windows.Forms.TextBox UserIP;
    }
}

