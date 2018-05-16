namespace FireSafety
{
    partial class AlgorithmForm
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
            this.cbMove = new System.Windows.Forms.ComboBox();
            this.cbCharge = new System.Windows.Forms.ComboBox();
            this.cbTurret = new System.Windows.Forms.ComboBox();
            this.dgvAlgorithm = new System.Windows.Forms.DataGridView();
            this.gbControls = new System.Windows.Forms.GroupBox();
            this.btnClearAlgorithm = new System.Windows.Forms.Button();
            this.btnDeleteAction = new System.Windows.Forms.Button();
            this.lblTurretCommands = new System.Windows.Forms.Label();
            this.lblChargeCommands = new System.Windows.Forms.Label();
            this.lblMoveCommands = new System.Windows.Forms.Label();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MoveCommands = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShootCommands = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TurretCommands = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chbBlocked = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlgorithm)).BeginInit();
            this.gbControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbMove
            // 
            this.cbMove.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMove.FormattingEnabled = true;
            this.cbMove.Items.AddRange(new object[] {
            "Вперед",
            "Назад",
            "45° по ч.с.",
            "45° пр. ч.с.",
            "90° по ч.с.",
            "90° пр. ч.с.",
            "Вперед 45° по ч.с.",
            "Вперед 45° пр. ч.с.",
            "Назад 45° по ч.с.",
            "Назад 45° пр. ч.с.",
            "Бездействие"});
            this.cbMove.Location = new System.Drawing.Point(6, 32);
            this.cbMove.Name = "cbMove";
            this.cbMove.Size = new System.Drawing.Size(112, 21);
            this.cbMove.TabIndex = 2;
            this.cbMove.SelectedIndexChanged += new System.EventHandler(this.cbShootCommandsCommands_SelectedIndexChanged);
            // 
            // cbCharge
            // 
            this.cbCharge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCharge.FormattingEnabled = true;
            this.cbCharge.Items.AddRange(new object[] {
            "Давление +1",
            "Давление +2",
            "Зарядить",
            "Пополнить запас",
            "Бездействие"});
            this.cbCharge.Location = new System.Drawing.Point(124, 32);
            this.cbCharge.Name = "cbCharge";
            this.cbCharge.Size = new System.Drawing.Size(112, 21);
            this.cbCharge.TabIndex = 2;
            this.cbCharge.SelectedIndexChanged += new System.EventHandler(this.cbShoot_SelectedIndexChanged);
            // 
            // cbTurret
            // 
            this.cbTurret.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTurret.FormattingEnabled = true;
            this.cbTurret.Items.AddRange(new object[] {
            "45° по ч.с.",
            "45° пр. ч.с.",
            "90° по ч.с.",
            "90° пр. ч.с.",
            "Поднять",
            "Опустить",
            "Выстрелить",
            "Бездействие"});
            this.cbTurret.Location = new System.Drawing.Point(242, 32);
            this.cbTurret.Name = "cbTurret";
            this.cbTurret.Size = new System.Drawing.Size(112, 21);
            this.cbTurret.TabIndex = 2;
            this.cbTurret.SelectedIndexChanged += new System.EventHandler(this.cbTurret_SelectedIndexChanged);
            // 
            // dgvAlgorithm
            // 
            this.dgvAlgorithm.AllowUserToAddRows = false;
            this.dgvAlgorithm.AllowUserToDeleteRows = false;
            this.dgvAlgorithm.AllowUserToResizeColumns = false;
            this.dgvAlgorithm.AllowUserToResizeRows = false;
            this.dgvAlgorithm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAlgorithm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlgorithm.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Number,
            this.MoveCommands,
            this.ShootCommands,
            this.TurretCommands});
            this.dgvAlgorithm.EnableHeadersVisualStyles = false;
            this.dgvAlgorithm.Location = new System.Drawing.Point(12, 12);
            this.dgvAlgorithm.MultiSelect = false;
            this.dgvAlgorithm.Name = "dgvAlgorithm";
            this.dgvAlgorithm.ReadOnly = true;
            this.dgvAlgorithm.RowHeadersVisible = false;
            this.dgvAlgorithm.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAlgorithm.Size = new System.Drawing.Size(360, 294);
            this.dgvAlgorithm.TabIndex = 6;
            this.dgvAlgorithm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvAlgorithm_KeyDown);
            this.dgvAlgorithm.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvAlgorithm_KeyUp);
            // 
            // gbControls
            // 
            this.gbControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbControls.Controls.Add(this.chbBlocked);
            this.gbControls.Controls.Add(this.btnClearAlgorithm);
            this.gbControls.Controls.Add(this.btnDeleteAction);
            this.gbControls.Controls.Add(this.lblTurretCommands);
            this.gbControls.Controls.Add(this.lblChargeCommands);
            this.gbControls.Controls.Add(this.lblMoveCommands);
            this.gbControls.Controls.Add(this.cbTurret);
            this.gbControls.Controls.Add(this.cbCharge);
            this.gbControls.Controls.Add(this.cbMove);
            this.gbControls.Location = new System.Drawing.Point(12, 312);
            this.gbControls.Name = "gbControls";
            this.gbControls.Size = new System.Drawing.Size(360, 88);
            this.gbControls.TabIndex = 8;
            this.gbControls.TabStop = false;
            // 
            // btnClearAlgorithm
            // 
            this.btnClearAlgorithm.Location = new System.Drawing.Point(242, 59);
            this.btnClearAlgorithm.Name = "btnClearAlgorithm";
            this.btnClearAlgorithm.Size = new System.Drawing.Size(112, 23);
            this.btnClearAlgorithm.TabIndex = 6;
            this.btnClearAlgorithm.Text = "Очистить";
            this.btnClearAlgorithm.UseVisualStyleBackColor = true;
            this.btnClearAlgorithm.Click += new System.EventHandler(this.btnClearAlgorithm_Click);
            // 
            // btnDeleteAction
            // 
            this.btnDeleteAction.Location = new System.Drawing.Point(6, 59);
            this.btnDeleteAction.Name = "btnDeleteAction";
            this.btnDeleteAction.Size = new System.Drawing.Size(112, 23);
            this.btnDeleteAction.TabIndex = 6;
            this.btnDeleteAction.Text = "Удалить строку";
            this.btnDeleteAction.UseVisualStyleBackColor = true;
            this.btnDeleteAction.Click += new System.EventHandler(this.btnDeleteAction_Click);
            // 
            // lblTurretCommands
            // 
            this.lblTurretCommands.AutoSize = true;
            this.lblTurretCommands.Location = new System.Drawing.Point(239, 16);
            this.lblTurretCommands.Name = "lblTurretCommands";
            this.lblTurretCommands.Size = new System.Drawing.Size(40, 13);
            this.lblTurretCommands.TabIndex = 4;
            this.lblTurretCommands.Text = "Башня";
            // 
            // lblChargeCommands
            // 
            this.lblChargeCommands.AutoSize = true;
            this.lblChargeCommands.Location = new System.Drawing.Point(121, 16);
            this.lblChargeCommands.Name = "lblChargeCommands";
            this.lblChargeCommands.Size = new System.Drawing.Size(67, 13);
            this.lblChargeCommands.TabIndex = 3;
            this.lblChargeCommands.Text = "Подготовка";
            // 
            // lblMoveCommands
            // 
            this.lblMoveCommands.AutoSize = true;
            this.lblMoveCommands.Location = new System.Drawing.Point(3, 16);
            this.lblMoveCommands.Name = "lblMoveCommands";
            this.lblMoveCommands.Size = new System.Drawing.Size(83, 13);
            this.lblMoveCommands.TabIndex = 0;
            this.lblMoveCommands.Text = "Передвижение";
            // 
            // Number
            // 
            this.Number.HeaderText = "№";
            this.Number.Name = "Number";
            this.Number.ReadOnly = true;
            this.Number.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Number.Width = 25;
            // 
            // MoveCommands
            // 
            this.MoveCommands.HeaderText = "Передвижение";
            this.MoveCommands.Name = "MoveCommands";
            this.MoveCommands.ReadOnly = true;
            this.MoveCommands.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ShootCommands
            // 
            this.ShootCommands.HeaderText = "Подготовка";
            this.ShootCommands.Name = "ShootCommands";
            this.ShootCommands.ReadOnly = true;
            this.ShootCommands.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TurretCommands
            // 
            this.TurretCommands.HeaderText = "Башня";
            this.TurretCommands.Name = "TurretCommands";
            this.TurretCommands.ReadOnly = true;
            this.TurretCommands.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // chbBlocked
            // 
            this.chbBlocked.AutoSize = true;
            this.chbBlocked.Location = new System.Drawing.Point(124, 63);
            this.chbBlocked.Name = "chbBlocked";
            this.chbBlocked.Size = new System.Drawing.Size(105, 17);
            this.chbBlocked.TabIndex = 7;
            this.chbBlocked.Text = "Заблокировано";
            this.chbBlocked.UseVisualStyleBackColor = true;
            this.chbBlocked.CheckedChanged += new System.EventHandler(this.chbBlocked_CheckedChanged);
            // 
            // AlgorithmForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 412);
            this.Controls.Add(this.gbControls);
            this.Controls.Add(this.dgvAlgorithm);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 280);
            this.Name = "AlgorithmForm";
            this.Tag = "Algorithm";
            this.Text = "Algorithm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AlgorithmForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlgorithm)).EndInit();
            this.gbControls.ResumeLayout(false);
            this.gbControls.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.ComboBox cbMove;
        public System.Windows.Forms.ComboBox cbCharge;
        public System.Windows.Forms.ComboBox cbTurret;
        public System.Windows.Forms.DataGridView dgvAlgorithm;
        private System.Windows.Forms.GroupBox gbControls;
        private System.Windows.Forms.Label lblTurretCommands;
        private System.Windows.Forms.Label lblChargeCommands;
        private System.Windows.Forms.Label lblMoveCommands;
        private System.Windows.Forms.Button btnClearAlgorithm;
        private System.Windows.Forms.Button btnDeleteAction;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn MoveCommands;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShootCommands;
        private System.Windows.Forms.DataGridViewTextBoxColumn TurretCommands;
        private System.Windows.Forms.CheckBox chbBlocked;
    }
}