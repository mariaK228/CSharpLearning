namespace MinecraftHernya
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
            this.owX = new System.Windows.Forms.TextBox();
            this.owY = new System.Windows.Forms.TextBox();
            this.owZ = new System.Windows.Forms.TextBox();
            this.hellX = new System.Windows.Forms.TextBox();
            this.hellY = new System.Windows.Forms.TextBox();
            this.hellZ = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // owX
            // 
            this.owX.Location = new System.Drawing.Point(53, 119);
            this.owX.Name = "owX";
            this.owX.Size = new System.Drawing.Size(100, 20);
            this.owX.TabIndex = 0;
            // 
            // owY
            // 
            this.owY.Location = new System.Drawing.Point(171, 122);
            this.owY.Name = "owY";
            this.owY.Size = new System.Drawing.Size(100, 20);
            this.owY.TabIndex = 1;
            // 
            // owZ
            // 
            this.owZ.Location = new System.Drawing.Point(294, 122);
            this.owZ.Name = "owZ";
            this.owZ.Size = new System.Drawing.Size(100, 20);
            this.owZ.TabIndex = 2;
            // 
            // hellX
            // 
            this.hellX.Location = new System.Drawing.Point(53, 206);
            this.hellX.Name = "hellX";
            this.hellX.Size = new System.Drawing.Size(100, 20);
            this.hellX.TabIndex = 3;
            // 
            // hellY
            // 
            this.hellY.Location = new System.Drawing.Point(171, 206);
            this.hellY.Name = "hellY";
            this.hellY.Size = new System.Drawing.Size(100, 20);
            this.hellY.TabIndex = 4;
            // 
            // hellZ
            // 
            this.hellZ.Location = new System.Drawing.Point(294, 206);
            this.hellZ.Name = "hellZ";
            this.hellZ.Size = new System.Drawing.Size(100, 20);
            this.hellZ.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(47, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 31);
            this.label1.TabIndex = 6;
            this.label1.Text = "Our world";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(47, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 31);
            this.label2.TabIndex = 7;
            this.label2.Text = "Hell";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(428, 104);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 49);
            this.button1.TabIndex = 8;
            this.button1.Text = "Convert to HELL";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(428, 188);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(141, 54);
            this.button2.TabIndex = 9;
            this.button2.Text = "Convert to OUR WORLD";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(644, 329);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hellZ);
            this.Controls.Add(this.hellY);
            this.Controls.Add(this.hellX);
            this.Controls.Add(this.owZ);
            this.Controls.Add(this.owY);
            this.Controls.Add(this.owX);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox owX;
        private System.Windows.Forms.TextBox owY;
        private System.Windows.Forms.TextBox owZ;
        private System.Windows.Forms.TextBox hellX;
        private System.Windows.Forms.TextBox hellY;
        private System.Windows.Forms.TextBox hellZ;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

