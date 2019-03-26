namespace hotel
{
    partial class MainForm
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
            this.addButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.choosePersonBox = new System.Windows.Forms.ListBox();
            this.infoBox = new System.Windows.Forms.RichTextBox();
            this.resultSort = new System.Windows.Forms.RichTextBox();
            this.sortButton = new System.Windows.Forms.Button();
            this.sortBy = new System.Windows.Forms.DomainUpDown();
            this.SuspendLayout();
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.Beige;
            this.addButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addButton.Location = new System.Drawing.Point(12, 53);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(268, 23);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // editButton
            // 
            this.editButton.BackColor = System.Drawing.Color.Beige;
            this.editButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.editButton.Location = new System.Drawing.Point(286, 53);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(268, 23);
            this.editButton.TabIndex = 1;
            this.editButton.Text = "Изменить";
            this.editButton.UseVisualStyleBackColor = false;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Постоялец";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(283, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Информация";
            // 
            // choosePersonBox
            // 
            this.choosePersonBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.choosePersonBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.choosePersonBox.FormattingEnabled = true;
            this.choosePersonBox.ItemHeight = 16;
            this.choosePersonBox.Location = new System.Drawing.Point(15, 112);
            this.choosePersonBox.Name = "choosePersonBox";
            this.choosePersonBox.Size = new System.Drawing.Size(265, 180);
            this.choosePersonBox.TabIndex = 4;
            this.choosePersonBox.SelectedIndexChanged += new System.EventHandler(this.choosePersonBox_SelectedIndexChanged);
            this.choosePersonBox.SelectedValueChanged += new System.EventHandler(this.choosePersonBox_SelectedIndexChanged);
            // 
            // infoBox
            // 
            this.infoBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.infoBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.infoBox.Location = new System.Drawing.Point(286, 112);
            this.infoBox.Name = "infoBox";
            this.infoBox.ReadOnly = true;
            this.infoBox.Size = new System.Drawing.Size(267, 186);
            this.infoBox.TabIndex = 5;
            this.infoBox.Text = "";
            // 
            // resultSort
            // 
            this.resultSort.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.resultSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resultSort.Location = new System.Drawing.Point(12, 326);
            this.resultSort.Name = "resultSort";
            this.resultSort.ReadOnly = true;
            this.resultSort.Size = new System.Drawing.Size(530, 186);
            this.resultSort.TabIndex = 6;
            this.resultSort.Text = "";
            // 
            // sortButton
            // 
            this.sortButton.BackColor = System.Drawing.Color.Beige;
            this.sortButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sortButton.Location = new System.Drawing.Point(12, 518);
            this.sortButton.Name = "sortButton";
            this.sortButton.Size = new System.Drawing.Size(268, 23);
            this.sortButton.TabIndex = 7;
            this.sortButton.Text = "Сортировать по";
            this.sortButton.UseVisualStyleBackColor = false;
            this.sortButton.Click += new System.EventHandler(this.sortButton_Click);
            // 
            // sortBy
            // 
            this.sortBy.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.sortBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sortBy.Location = new System.Drawing.Point(286, 521);
            this.sortBy.Name = "sortBy";
            this.sortBy.ReadOnly = true;
            this.sortBy.Size = new System.Drawing.Size(256, 22);
            this.sortBy.TabIndex = 8;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.ClientSize = new System.Drawing.Size(565, 564);
            this.Controls.Add(this.sortBy);
            this.Controls.Add(this.sortButton);
            this.Controls.Add(this.resultSort);
            this.Controls.Add(this.infoBox);
            this.Controls.Add(this.choosePersonBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.addButton);
            this.Name = "MainForm";
            this.Text = "Гостиница. Королёва Мария. ИЭ-65-16. Задача 20";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox choosePersonBox;
        private System.Windows.Forms.RichTextBox infoBox;
        private System.Windows.Forms.RichTextBox resultSort;
        private System.Windows.Forms.Button sortButton;
        private System.Windows.Forms.DomainUpDown sortBy;
    }
}

