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
            this.addButton.Location = new System.Drawing.Point(12, 53);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(268, 23);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(286, 53);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(268, 23);
            this.editButton.TabIndex = 1;
            this.editButton.Text = "Изменить";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Постоялец";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(283, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Информация";
            // 
            // choosePersonBox
            // 
            this.choosePersonBox.FormattingEnabled = true;
            this.choosePersonBox.Location = new System.Drawing.Point(15, 112);
            this.choosePersonBox.Name = "choosePersonBox";
            this.choosePersonBox.Size = new System.Drawing.Size(265, 186);
            this.choosePersonBox.TabIndex = 4;
            this.choosePersonBox.SelectedIndexChanged += new System.EventHandler(this.choosePersonBox_SelectedIndexChanged);
            this.choosePersonBox.SelectedValueChanged += new System.EventHandler(this.choosePersonBox_SelectedIndexChanged);
            // 
            // infoBox
            // 
            this.infoBox.Location = new System.Drawing.Point(286, 112);
            this.infoBox.Name = "infoBox";
            this.infoBox.Size = new System.Drawing.Size(267, 186);
            this.infoBox.TabIndex = 5;
            this.infoBox.Text = "";
            // 
            // resultSort
            // 
            this.resultSort.Location = new System.Drawing.Point(12, 326);
            this.resultSort.Name = "resultSort";
            this.resultSort.Size = new System.Drawing.Size(530, 186);
            this.resultSort.TabIndex = 6;
            this.resultSort.Text = "";
            // 
            // sortButton
            // 
            this.sortButton.Location = new System.Drawing.Point(12, 518);
            this.sortButton.Name = "sortButton";
            this.sortButton.Size = new System.Drawing.Size(268, 23);
            this.sortButton.TabIndex = 7;
            this.sortButton.Text = "Сортировать по";
            this.sortButton.UseVisualStyleBackColor = true;
            // 
            // sortBy
            // 
            this.sortBy.Location = new System.Drawing.Point(286, 521);
            this.sortBy.Name = "sortBy";
            this.sortBy.Size = new System.Drawing.Size(256, 20);
            this.sortBy.TabIndex = 8;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
            this.Text = "MainForm";
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

