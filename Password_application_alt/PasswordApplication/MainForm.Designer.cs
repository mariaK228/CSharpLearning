namespace PasswordApplication
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.logInButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.currentUsernameLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.accountsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.changeUserItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addUserItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allUsersItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitItem = new System.Windows.Forms.ToolStripMenuItem();
<<<<<<< HEAD
<<<<<<< HEAD
            this.AboutProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
=======

            this.AboutProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();

>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
=======

            this.AboutProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();

>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // logInButton
            // 
            this.logInButton.Location = new System.Drawing.Point(13, 268);
            this.logInButton.Name = "logInButton";
            this.logInButton.Size = new System.Drawing.Size(285, 23);
            this.logInButton.TabIndex = 0;
            this.logInButton.Text = "Войти в аккаунт";
            this.logInButton.UseVisualStyleBackColor = true;
            this.logInButton.Click += new System.EventHandler(this.logInButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentUsernameLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 294);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(310, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // currentUsernameLabel
            // 
            this.currentUsernameLabel.Name = "currentUsernameLabel";
            this.currentUsernameLabel.Size = new System.Drawing.Size(72, 17);
            this.currentUsernameLabel.Text = "Вошел как: ";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountsMenu,
<<<<<<< HEAD
<<<<<<< HEAD
            this.AboutProgramToolStripMenuItem});
=======

            this.AboutProgramToolStripMenuItem});

>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
=======

            this.AboutProgramToolStripMenuItem});

>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(310, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // accountsMenu
            // 
            this.accountsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeUserItem,
            this.addUserItem,
            this.allUsersItem,
            this.changePasswordItem,
            this.quitItem});
            this.accountsMenu.Name = "accountsMenu";
            this.accountsMenu.Size = new System.Drawing.Size(72, 20);
            this.accountsMenu.Text = "Аккаунты";
            // 
            // changeUserItem
            // 
            this.changeUserItem.Enabled = false;
            this.changeUserItem.Name = "changeUserItem";
            this.changeUserItem.Size = new System.Drawing.Size(204, 22);
            this.changeUserItem.Text = "Сменить пользователя";
            this.changeUserItem.Click += new System.EventHandler(this.changeUserItem_Click);
            // 
            // addUserItem
            // 
            this.addUserItem.Enabled = false;
            this.addUserItem.Name = "addUserItem";
            this.addUserItem.Size = new System.Drawing.Size(204, 22);
            this.addUserItem.Text = "Добавить пользователя";
            this.addUserItem.Click += new System.EventHandler(this.addUserItem_Click);
            // 
            // allUsersItem
            // 
            this.allUsersItem.Enabled = false;
            this.allUsersItem.Name = "allUsersItem";
            this.allUsersItem.Size = new System.Drawing.Size(204, 22);
            this.allUsersItem.Text = "Все пользователи";
            this.allUsersItem.Click += new System.EventHandler(this.allUsersItem_Click);
            // 
            // changePasswordItem
            // 
            this.changePasswordItem.Enabled = false;
            this.changePasswordItem.Name = "changePasswordItem";
            this.changePasswordItem.Size = new System.Drawing.Size(204, 22);
            this.changePasswordItem.Text = "Сменить пароль";
            this.changePasswordItem.Click += new System.EventHandler(this.changePasswordItem_Click);
            // 
            // quitItem
            // 
            this.quitItem.Name = "quitItem";
            this.quitItem.Size = new System.Drawing.Size(204, 22);
            this.quitItem.Text = "Выход ";
<<<<<<< HEAD
<<<<<<< HEAD
            this.quitItem.Click += new System.EventHandler(this.quitItem_Click);
            // 
=======
            // 

>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
=======
            // 

>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
            // AboutProgramToolStripMenuItem
            // 
            this.AboutProgramToolStripMenuItem.Name = "AboutProgramToolStripMenuItem";
            this.AboutProgramToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.AboutProgramToolStripMenuItem.Text = "О программе";
            this.AboutProgramToolStripMenuItem.Click += new System.EventHandler(this.AboutProgramToolStripMenuItem_Click);
<<<<<<< HEAD
<<<<<<< HEAD
=======

>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
=======

>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 316);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.logInButton);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
<<<<<<< HEAD
<<<<<<< HEAD
            this.Text = "Лабораторная работа";
=======
            this.Text = "Password application";
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
=======
            this.Text = "Password application";
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

<<<<<<< HEAD
<<<<<<< HEAD
=======
        private System.Windows.Forms.Button logInButton;
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
=======
        private System.Windows.Forms.Button logInButton;
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel currentUsernameLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem accountsMenu;
        private System.Windows.Forms.ToolStripMenuItem changeUserItem;
        private System.Windows.Forms.ToolStripMenuItem addUserItem;
        private System.Windows.Forms.ToolStripMenuItem allUsersItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordItem;
<<<<<<< HEAD
<<<<<<< HEAD
        private System.Windows.Forms.ToolStripMenuItem AboutProgramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitItem;
        public System.Windows.Forms.Button logInButton;
=======
=======
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da

        private System.Windows.Forms.ToolStripMenuItem AboutProgramToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem quitItem;
<<<<<<< HEAD
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
=======
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
    }
}

