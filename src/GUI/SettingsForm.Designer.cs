namespace FireSafety
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.tcSettings = new System.Windows.Forms.TabControl();
            this.tpCommon = new System.Windows.Forms.TabPage();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblConnectionString = new System.Windows.Forms.Label();
            this.tbConnectionString = new System.Windows.Forms.TextBox();
            this.tpShortcuts = new System.Windows.Forms.TabPage();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnDefault = new System.Windows.Forms.Button();
            this.dgvShortcuts = new System.Windows.Forms.DataGridView();
            this.dgvtbcPerformer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvtbcCommand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvtbcShortcut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tcSettings.SuspendLayout();
            this.tpCommon.SuspendLayout();
            this.tpShortcuts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShortcuts)).BeginInit();
            this.SuspendLayout();
            // 
            // tcSettings
            // 
            this.tcSettings.Controls.Add(this.tpCommon);
            this.tcSettings.Controls.Add(this.tpShortcuts);
            this.tcSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcSettings.Location = new System.Drawing.Point(0, 0);
            this.tcSettings.Name = "tcSettings";
            this.tcSettings.SelectedIndex = 0;
            this.tcSettings.Size = new System.Drawing.Size(734, 662);
            this.tcSettings.TabIndex = 0;
            // 
            // tpCommon
            // 
            this.tpCommon.Controls.Add(this.btnLogin);
            this.tpCommon.Controls.Add(this.btnTestConnection);
            this.tpCommon.Controls.Add(this.tbUser);
            this.tpCommon.Controls.Add(this.lblUser);
            this.tpCommon.Controls.Add(this.lblConnectionString);
            this.tpCommon.Controls.Add(this.tbConnectionString);
            this.tpCommon.Location = new System.Drawing.Point(4, 22);
            this.tpCommon.Name = "tpCommon";
            this.tpCommon.Padding = new System.Windows.Forms.Padding(3);
            this.tpCommon.Size = new System.Drawing.Size(726, 636);
            this.tpCommon.TabIndex = 0;
            this.tpCommon.Text = "Общие";
            this.tpCommon.UseVisualStyleBackColor = true;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(618, 17);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(100, 23);
            this.btnLogin.TabIndex = 11;
            this.btnLogin.Text = "Войти";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Location = new System.Drawing.Point(462, 17);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(150, 23);
            this.btnTestConnection.TabIndex = 9;
            this.btnTestConnection.Text = "Проверить соединение";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // tbUser
            // 
            this.tbUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbUser.Location = new System.Drawing.Point(8, 58);
            this.tbUser.Name = "tbUser";
            this.tbUser.ReadOnly = true;
            this.tbUser.Size = new System.Drawing.Size(710, 20);
            this.tbUser.TabIndex = 4;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(8, 42);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(103, 13);
            this.lblUser.TabIndex = 3;
            this.lblUser.Text = "Имя пользователя";
            // 
            // lblConnectionString
            // 
            this.lblConnectionString.AutoSize = true;
            this.lblConnectionString.Location = new System.Drawing.Point(8, 3);
            this.lblConnectionString.Name = "lblConnectionString";
            this.lblConnectionString.Size = new System.Drawing.Size(189, 13);
            this.lblConnectionString.TabIndex = 1;
            this.lblConnectionString.Text = "Строка подключения к базе данных";
            // 
            // tbConnectionString
            // 
            this.tbConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbConnectionString.Location = new System.Drawing.Point(8, 19);
            this.tbConnectionString.Name = "tbConnectionString";
            this.tbConnectionString.ReadOnly = true;
            this.tbConnectionString.Size = new System.Drawing.Size(448, 20);
            this.tbConnectionString.TabIndex = 0;
            // 
            // tpShortcuts
            // 
            this.tpShortcuts.Controls.Add(this.lblDescription);
            this.tpShortcuts.Controls.Add(this.btnDefault);
            this.tpShortcuts.Controls.Add(this.dgvShortcuts);
            this.tpShortcuts.Location = new System.Drawing.Point(4, 22);
            this.tpShortcuts.Name = "tpShortcuts";
            this.tpShortcuts.Padding = new System.Windows.Forms.Padding(3);
            this.tpShortcuts.Size = new System.Drawing.Size(726, 636);
            this.tpShortcuts.TabIndex = 1;
            this.tpShortcuts.Text = "Горячие клавиши";
            this.tpShortcuts.UseVisualStyleBackColor = true;
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescription.Location = new System.Drawing.Point(434, 6);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(286, 559);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = resources.GetString("lblDescription.Text");
            // 
            // btnDefault
            // 
            this.btnDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDefault.Location = new System.Drawing.Point(434, 607);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(284, 23);
            this.btnDefault.TabIndex = 1;
            this.btnDefault.Text = "Восстановить по умолчанию";
            this.btnDefault.UseVisualStyleBackColor = true;
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // dgvShortcuts
            // 
            this.dgvShortcuts.AllowUserToAddRows = false;
            this.dgvShortcuts.AllowUserToDeleteRows = false;
            this.dgvShortcuts.AllowUserToResizeColumns = false;
            this.dgvShortcuts.AllowUserToResizeRows = false;
            this.dgvShortcuts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvShortcuts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShortcuts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvtbcPerformer,
            this.dgvtbcCommand,
            this.dgvtbcShortcut});
            this.dgvShortcuts.Location = new System.Drawing.Point(8, 6);
            this.dgvShortcuts.MultiSelect = false;
            this.dgvShortcuts.Name = "dgvShortcuts";
            this.dgvShortcuts.ReadOnly = true;
            this.dgvShortcuts.RowHeadersVisible = false;
            this.dgvShortcuts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvShortcuts.ShowCellErrors = false;
            this.dgvShortcuts.ShowCellToolTips = false;
            this.dgvShortcuts.ShowEditingIcon = false;
            this.dgvShortcuts.ShowRowErrors = false;
            this.dgvShortcuts.Size = new System.Drawing.Size(420, 622);
            this.dgvShortcuts.TabIndex = 0;
            this.dgvShortcuts.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvShortcuts_KeyDown);
            // 
            // dgvtbcPerformer
            // 
            this.dgvtbcPerformer.HeaderText = "Исполнитель";
            this.dgvtbcPerformer.Name = "dgvtbcPerformer";
            this.dgvtbcPerformer.ReadOnly = true;
            this.dgvtbcPerformer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvtbcPerformer.Width = 120;
            // 
            // dgvtbcCommand
            // 
            this.dgvtbcCommand.HeaderText = "Команда";
            this.dgvtbcCommand.Name = "dgvtbcCommand";
            this.dgvtbcCommand.ReadOnly = true;
            this.dgvtbcCommand.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvtbcCommand.Width = 120;
            // 
            // dgvtbcShortcut
            // 
            this.dgvtbcShortcut.HeaderText = "Горячая клавиша";
            this.dgvtbcShortcut.Name = "dgvtbcShortcut";
            this.dgvtbcShortcut.ReadOnly = true;
            this.dgvtbcShortcut.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvtbcShortcut.Width = 120;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 662);
            this.Controls.Add(this.tcSettings);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 500);
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки";
            this.tcSettings.ResumeLayout(false);
            this.tpCommon.ResumeLayout(false);
            this.tpCommon.PerformLayout();
            this.tpShortcuts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShortcuts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcSettings;
        private System.Windows.Forms.TabPage tpCommon;
        private System.Windows.Forms.TabPage tpShortcuts;
        private System.Windows.Forms.Button btnDefault;
        public System.Windows.Forms.DataGridView dgvShortcuts;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblConnectionString;
        private System.Windows.Forms.Label lblUser;
        public System.Windows.Forms.TextBox tbConnectionString;
        public System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtbcPerformer;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtbcCommand;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtbcShortcut;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnTestConnection;
    }
}