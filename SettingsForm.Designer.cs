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
            this.tbUser = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.btnChangeConnectionString = new System.Windows.Forms.Button();
            this.lblConnectionString = new System.Windows.Forms.Label();
            this.tbConnectionString = new System.Windows.Forms.TextBox();
            this.tpShortcuts = new System.Windows.Forms.TabPage();
            this.lblTimeToHold = new System.Windows.Forms.Label();
            this.nudTimeToHold = new System.Windows.Forms.NumericUpDown();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnDefault = new System.Windows.Forms.Button();
            this.dgvShortcuts = new System.Windows.Forms.DataGridView();
            this.dgvtbcPerformer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvtbcCommand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvtbcShortcut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblFPS = new System.Windows.Forms.Label();
            this.nudFPS = new System.Windows.Forms.NumericUpDown();
            this.gbOpenMode = new System.Windows.Forms.GroupBox();
            this.rbtnOpenModeFromFiles = new System.Windows.Forms.RadioButton();
            this.rbtnOpenModeFromDataBase = new System.Windows.Forms.RadioButton();
            this.tcSettings.SuspendLayout();
            this.tpCommon.SuspendLayout();
            this.tpShortcuts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeToHold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShortcuts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFPS)).BeginInit();
            this.gbOpenMode.SuspendLayout();
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
            this.tcSettings.Size = new System.Drawing.Size(584, 462);
            this.tcSettings.TabIndex = 0;
            // 
            // tpCommon
            // 
            this.tpCommon.Controls.Add(this.gbOpenMode);
            this.tpCommon.Controls.Add(this.nudFPS);
            this.tpCommon.Controls.Add(this.lblFPS);
            this.tpCommon.Controls.Add(this.tbUser);
            this.tpCommon.Controls.Add(this.lblUser);
            this.tpCommon.Controls.Add(this.btnChangeConnectionString);
            this.tpCommon.Controls.Add(this.lblConnectionString);
            this.tpCommon.Controls.Add(this.tbConnectionString);
            this.tpCommon.Location = new System.Drawing.Point(4, 22);
            this.tpCommon.Name = "tpCommon";
            this.tpCommon.Padding = new System.Windows.Forms.Padding(3);
            this.tpCommon.Size = new System.Drawing.Size(576, 436);
            this.tpCommon.TabIndex = 0;
            this.tpCommon.Text = "Common";
            this.tpCommon.UseVisualStyleBackColor = true;
            // 
            // tbUser
            // 
            this.tbUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbUser.Location = new System.Drawing.Point(8, 58);
            this.tbUser.Name = "tbUser";
            this.tbUser.ReadOnly = true;
            this.tbUser.Size = new System.Drawing.Size(560, 20);
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
            // btnChangeConnectionString
            // 
            this.btnChangeConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChangeConnectionString.Location = new System.Drawing.Point(493, 17);
            this.btnChangeConnectionString.Name = "btnChangeConnectionString";
            this.btnChangeConnectionString.Size = new System.Drawing.Size(75, 23);
            this.btnChangeConnectionString.TabIndex = 2;
            this.btnChangeConnectionString.Text = "Изменить";
            this.btnChangeConnectionString.UseVisualStyleBackColor = true;
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
            this.tbConnectionString.Size = new System.Drawing.Size(479, 20);
            this.tbConnectionString.TabIndex = 0;
            // 
            // tpShortcuts
            // 
            this.tpShortcuts.Controls.Add(this.lblTimeToHold);
            this.tpShortcuts.Controls.Add(this.nudTimeToHold);
            this.tpShortcuts.Controls.Add(this.lblDescription);
            this.tpShortcuts.Controls.Add(this.btnDefault);
            this.tpShortcuts.Controls.Add(this.dgvShortcuts);
            this.tpShortcuts.Location = new System.Drawing.Point(4, 22);
            this.tpShortcuts.Name = "tpShortcuts";
            this.tpShortcuts.Padding = new System.Windows.Forms.Padding(3);
            this.tpShortcuts.Size = new System.Drawing.Size(576, 436);
            this.tpShortcuts.TabIndex = 1;
            this.tpShortcuts.Text = "Shortcuts";
            this.tpShortcuts.UseVisualStyleBackColor = true;
            // 
            // lblTimeToHold
            // 
            this.lblTimeToHold.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTimeToHold.AutoSize = true;
            this.lblTimeToHold.Location = new System.Drawing.Point(367, 365);
            this.lblTimeToHold.Name = "lblTimeToHold";
            this.lblTimeToHold.Size = new System.Drawing.Size(145, 13);
            this.lblTimeToHold.TabIndex = 4;
            this.lblTimeToHold.Text = "Время удержания клавиши";
            // 
            // nudTimeToHold
            // 
            this.nudTimeToHold.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nudTimeToHold.Location = new System.Drawing.Point(370, 381);
            this.nudTimeToHold.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudTimeToHold.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudTimeToHold.Name = "nudTimeToHold";
            this.nudTimeToHold.Size = new System.Drawing.Size(200, 20);
            this.nudTimeToHold.TabIndex = 3;
            this.nudTimeToHold.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescription.Location = new System.Drawing.Point(370, 6);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(200, 359);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = resources.GetString("lblDescription.Text");
            // 
            // btnDefault
            // 
            this.btnDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDefault.Location = new System.Drawing.Point(370, 407);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(200, 23);
            this.btnDefault.TabIndex = 1;
            this.btnDefault.Text = "Default";
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
            this.dgvShortcuts.Size = new System.Drawing.Size(353, 422);
            this.dgvShortcuts.TabIndex = 0;
            this.dgvShortcuts.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvShortcuts_KeyDown);
            // 
            // dgvtbcPerformer
            // 
            this.dgvtbcPerformer.HeaderText = "Performer";
            this.dgvtbcPerformer.Name = "dgvtbcPerformer";
            this.dgvtbcPerformer.ReadOnly = true;
            this.dgvtbcPerformer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgvtbcCommand
            // 
            this.dgvtbcCommand.HeaderText = "Command";
            this.dgvtbcCommand.Name = "dgvtbcCommand";
            this.dgvtbcCommand.ReadOnly = true;
            this.dgvtbcCommand.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgvtbcShortcut
            // 
            this.dgvtbcShortcut.HeaderText = "Shortcut";
            this.dgvtbcShortcut.Name = "dgvtbcShortcut";
            this.dgvtbcShortcut.ReadOnly = true;
            this.dgvtbcShortcut.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // lblFPS
            // 
            this.lblFPS.AutoSize = true;
            this.lblFPS.Location = new System.Drawing.Point(8, 81);
            this.lblFPS.Name = "lblFPS";
            this.lblFPS.Size = new System.Drawing.Size(329, 13);
            this.lblFPS.TabIndex = 5;
            this.lblFPS.Text = "Количество кадров в секунду во время выполнения алгоритма";
            // 
            // nudFPS
            // 
            this.nudFPS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudFPS.Location = new System.Drawing.Point(8, 97);
            this.nudFPS.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudFPS.Name = "nudFPS";
            this.nudFPS.Size = new System.Drawing.Size(560, 20);
            this.nudFPS.TabIndex = 6;
            this.nudFPS.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // gbOpenMode
            // 
            this.gbOpenMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbOpenMode.Controls.Add(this.rbtnOpenModeFromDataBase);
            this.gbOpenMode.Controls.Add(this.rbtnOpenModeFromFiles);
            this.gbOpenMode.Location = new System.Drawing.Point(8, 123);
            this.gbOpenMode.Name = "gbOpenMode";
            this.gbOpenMode.Size = new System.Drawing.Size(560, 66);
            this.gbOpenMode.TabIndex = 8;
            this.gbOpenMode.TabStop = false;
            this.gbOpenMode.Text = "Режим открытия карт и алгоритмов";
            // 
            // rbtnOpenModeFromFiles
            // 
            this.rbtnOpenModeFromFiles.AutoSize = true;
            this.rbtnOpenModeFromFiles.Location = new System.Drawing.Point(6, 19);
            this.rbtnOpenModeFromFiles.Name = "rbtnOpenModeFromFiles";
            this.rbtnOpenModeFromFiles.Size = new System.Drawing.Size(80, 17);
            this.rbtnOpenModeFromFiles.TabIndex = 0;
            this.rbtnOpenModeFromFiles.TabStop = true;
            this.rbtnOpenModeFromFiles.Text = "Из файлов";
            this.rbtnOpenModeFromFiles.UseVisualStyleBackColor = true;
            // 
            // rbtnOpenModeFromDataBase
            // 
            this.rbtnOpenModeFromDataBase.AutoSize = true;
            this.rbtnOpenModeFromDataBase.Location = new System.Drawing.Point(6, 42);
            this.rbtnOpenModeFromDataBase.Name = "rbtnOpenModeFromDataBase";
            this.rbtnOpenModeFromDataBase.Size = new System.Drawing.Size(108, 17);
            this.rbtnOpenModeFromDataBase.TabIndex = 0;
            this.rbtnOpenModeFromDataBase.TabStop = true;
            this.rbtnOpenModeFromDataBase.Text = "Из базы данных";
            this.rbtnOpenModeFromDataBase.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 462);
            this.Controls.Add(this.tcSettings);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 500);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.tcSettings.ResumeLayout(false);
            this.tpCommon.ResumeLayout(false);
            this.tpCommon.PerformLayout();
            this.tpShortcuts.ResumeLayout(false);
            this.tpShortcuts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeToHold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShortcuts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFPS)).EndInit();
            this.gbOpenMode.ResumeLayout(false);
            this.gbOpenMode.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcSettings;
        private System.Windows.Forms.TabPage tpCommon;
        private System.Windows.Forms.TabPage tpShortcuts;
        private System.Windows.Forms.Button btnDefault;
        public System.Windows.Forms.DataGridView dgvShortcuts;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtbcPerformer;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtbcCommand;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtbcShortcut;
        private System.Windows.Forms.Label lblDescription;
        public System.Windows.Forms.NumericUpDown nudTimeToHold;
        private System.Windows.Forms.Label lblTimeToHold;
        private System.Windows.Forms.Button btnChangeConnectionString;
        private System.Windows.Forms.Label lblConnectionString;
        private System.Windows.Forms.Label lblUser;
        public System.Windows.Forms.TextBox tbConnectionString;
        public System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.GroupBox gbOpenMode;
        private System.Windows.Forms.RadioButton rbtnOpenModeFromDataBase;
        private System.Windows.Forms.RadioButton rbtnOpenModeFromFiles;
        private System.Windows.Forms.NumericUpDown nudFPS;
        private System.Windows.Forms.Label lblFPS;
    }
}