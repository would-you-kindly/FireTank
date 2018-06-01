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
            this.components = new System.ComponentModel.Container();
            this.cbMove = new System.Windows.Forms.ComboBox();
            this.cbCharge = new System.Windows.Forms.ComboBox();
            this.cbTurret = new System.Windows.Forms.ComboBox();
            this.dgvAlgorithm = new System.Windows.Forms.DataGridView();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MoveCommands = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShootCommands = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TurretCommands = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvtbcPlanItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbControls = new System.Windows.Forms.GroupBox();
            this.btnInsertAction = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblMaxPressure = new System.Windows.Forms.Label();
            this.lblPressureSlash = new System.Windows.Forms.Label();
            this.lblMaxCapacity = new System.Windows.Forms.Label();
            this.lblCapacitySlash = new System.Windows.Forms.Label();
            this.pbReady = new System.Windows.Forms.PictureBox();
            this.pbUp = new System.Windows.Forms.PictureBox();
            this.pbDown = new System.Windows.Forms.PictureBox();
            this.lblPressure = new System.Windows.Forms.Label();
            this.pbPressure = new System.Windows.Forms.PictureBox();
            this.lblCapacity = new System.Windows.Forms.Label();
            this.pbCapacity = new System.Windows.Forms.PictureBox();
            this.chbBlocked = new System.Windows.Forms.CheckBox();
            this.btnClearAlgorithm = new System.Windows.Forms.Button();
            this.btnDeleteAction = new System.Windows.Forms.Button();
            this.lblTurretCommands = new System.Windows.Forms.Label();
            this.lblChargeCommands = new System.Windows.Forms.Label();
            this.lblMoveCommands = new System.Windows.Forms.Label();
            this.pbUnready = new System.Windows.Forms.PictureBox();
            this.ttipDeleteAction = new System.Windows.Forms.ToolTip(this.components);
            this.ttipBlock = new System.Windows.Forms.ToolTip(this.components);
            this.ttipClearTankAlgorithm = new System.Windows.Forms.ToolTip(this.components);
            this.ttipIndicators = new System.Windows.Forms.ToolTip(this.components);
            this.ttipInsertAction = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlgorithm)).BeginInit();
            this.gbControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbReady)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPressure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCapacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnready)).BeginInit();
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
            this.cbMove.SelectedIndexChanged += new System.EventHandler(this.cbMove_SelectedIndexChanged);
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
            this.cbCharge.SelectedIndexChanged += new System.EventHandler(this.cbCharge_SelectedIndexChanged);
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
            this.dgvAlgorithm.AllowDrop = true;
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
            this.TurretCommands,
            this.dgvtbcPlanItem});
            this.dgvAlgorithm.EnableHeadersVisualStyles = false;
            this.dgvAlgorithm.Location = new System.Drawing.Point(12, 12);
            this.dgvAlgorithm.MultiSelect = false;
            this.dgvAlgorithm.Name = "dgvAlgorithm";
            this.dgvAlgorithm.RowHeadersVisible = false;
            this.dgvAlgorithm.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAlgorithm.Size = new System.Drawing.Size(360, 294);
            this.dgvAlgorithm.TabIndex = 6;
            this.dgvAlgorithm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvAlgorithm_KeyDown);
            this.dgvAlgorithm.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvAlgorithm_KeyUp);
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
            this.MoveCommands.HeaderText = "Водитель";
            this.MoveCommands.Name = "MoveCommands";
            this.MoveCommands.ReadOnly = true;
            this.MoveCommands.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MoveCommands.Width = 105;
            // 
            // ShootCommands
            // 
            this.ShootCommands.HeaderText = "Заряжающий";
            this.ShootCommands.Name = "ShootCommands";
            this.ShootCommands.ReadOnly = true;
            this.ShootCommands.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TurretCommands
            // 
            this.TurretCommands.HeaderText = "Наводчик";
            this.TurretCommands.Name = "TurretCommands";
            this.TurretCommands.ReadOnly = true;
            this.TurretCommands.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TurretCommands.Width = 85;
            // 
            // dgvtbcPlanItem
            // 
            this.dgvtbcPlanItem.HeaderText = "П.";
            this.dgvtbcPlanItem.Name = "dgvtbcPlanItem";
            this.dgvtbcPlanItem.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvtbcPlanItem.Width = 25;
            // 
            // gbControls
            // 
            this.gbControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbControls.Controls.Add(this.btnInsertAction);
            this.gbControls.Controls.Add(this.button1);
            this.gbControls.Controls.Add(this.lblMaxPressure);
            this.gbControls.Controls.Add(this.lblPressureSlash);
            this.gbControls.Controls.Add(this.lblMaxCapacity);
            this.gbControls.Controls.Add(this.lblCapacitySlash);
            this.gbControls.Controls.Add(this.pbReady);
            this.gbControls.Controls.Add(this.pbUp);
            this.gbControls.Controls.Add(this.pbDown);
            this.gbControls.Controls.Add(this.lblPressure);
            this.gbControls.Controls.Add(this.pbPressure);
            this.gbControls.Controls.Add(this.lblCapacity);
            this.gbControls.Controls.Add(this.pbCapacity);
            this.gbControls.Controls.Add(this.chbBlocked);
            this.gbControls.Controls.Add(this.btnClearAlgorithm);
            this.gbControls.Controls.Add(this.btnDeleteAction);
            this.gbControls.Controls.Add(this.lblTurretCommands);
            this.gbControls.Controls.Add(this.lblChargeCommands);
            this.gbControls.Controls.Add(this.lblMoveCommands);
            this.gbControls.Controls.Add(this.cbTurret);
            this.gbControls.Controls.Add(this.cbCharge);
            this.gbControls.Controls.Add(this.cbMove);
            this.gbControls.Controls.Add(this.pbUnready);
            this.gbControls.Location = new System.Drawing.Point(12, 312);
            this.gbControls.Name = "gbControls";
            this.gbControls.Size = new System.Drawing.Size(360, 88);
            this.gbControls.TabIndex = 8;
            this.gbControls.TabStop = false;
            // 
            // btnInsertAction
            // 
            this.btnInsertAction.BackgroundImage = global::FireSafety.Properties.Resources.InsertAction;
            this.btnInsertAction.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnInsertAction.Location = new System.Drawing.Point(244, 59);
            this.btnInsertAction.Name = "btnInsertAction";
            this.btnInsertAction.Size = new System.Drawing.Size(23, 23);
            this.btnInsertAction.TabIndex = 21;
            this.ttipInsertAction.SetToolTip(this.btnInsertAction, "Вставить строку");
            this.btnInsertAction.UseVisualStyleBackColor = true;
            this.btnInsertAction.Click += new System.EventHandler(this.btnInsertAction_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(209, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(24, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblMaxPressure
            // 
            this.lblMaxPressure.AutoSize = true;
            this.lblMaxPressure.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblMaxPressure.Location = new System.Drawing.Point(136, 62);
            this.lblMaxPressure.Name = "lblMaxPressure";
            this.lblMaxPressure.Size = new System.Drawing.Size(18, 20);
            this.lblMaxPressure.TabIndex = 19;
            this.lblMaxPressure.Text = "0";
            // 
            // lblPressureSlash
            // 
            this.lblPressureSlash.AutoSize = true;
            this.lblPressureSlash.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPressureSlash.Location = new System.Drawing.Point(126, 62);
            this.lblPressureSlash.Name = "lblPressureSlash";
            this.lblPressureSlash.Size = new System.Drawing.Size(13, 20);
            this.lblPressureSlash.TabIndex = 18;
            this.lblPressureSlash.Text = "/";
            // 
            // lblMaxCapacity
            // 
            this.lblMaxCapacity.AutoSize = true;
            this.lblMaxCapacity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblMaxCapacity.Location = new System.Drawing.Point(59, 62);
            this.lblMaxCapacity.Name = "lblMaxCapacity";
            this.lblMaxCapacity.Size = new System.Drawing.Size(18, 20);
            this.lblMaxCapacity.TabIndex = 17;
            this.lblMaxCapacity.Text = "0";
            // 
            // lblCapacitySlash
            // 
            this.lblCapacitySlash.AutoSize = true;
            this.lblCapacitySlash.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCapacitySlash.Location = new System.Drawing.Point(49, 62);
            this.lblCapacitySlash.Name = "lblCapacitySlash";
            this.lblCapacitySlash.Size = new System.Drawing.Size(13, 20);
            this.lblCapacitySlash.TabIndex = 16;
            this.lblCapacitySlash.Text = "/";
            // 
            // pbReady
            // 
            this.pbReady.BackgroundImage = global::FireSafety.Properties.Resources.Charged;
            this.pbReady.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbReady.Location = new System.Drawing.Point(189, 59);
            this.pbReady.Name = "pbReady";
            this.pbReady.Size = new System.Drawing.Size(23, 23);
            this.pbReady.TabIndex = 14;
            this.pbReady.TabStop = false;
            this.ttipIndicators.SetToolTip(this.pbReady, "Пушка заряжена");
            this.pbReady.Visible = false;
            // 
            // pbUp
            // 
            this.pbUp.BackgroundImage = global::FireSafety.Properties.Resources.Up;
            this.pbUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbUp.Location = new System.Drawing.Point(160, 59);
            this.pbUp.Name = "pbUp";
            this.pbUp.Size = new System.Drawing.Size(23, 23);
            this.pbUp.TabIndex = 13;
            this.pbUp.TabStop = false;
            this.ttipIndicators.SetToolTip(this.pbUp, "Пушка поднята");
            this.pbUp.Visible = false;
            // 
            // pbDown
            // 
            this.pbDown.BackgroundImage = global::FireSafety.Properties.Resources.Down;
            this.pbDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbDown.Location = new System.Drawing.Point(160, 59);
            this.pbDown.Name = "pbDown";
            this.pbDown.Size = new System.Drawing.Size(23, 23);
            this.pbDown.TabIndex = 12;
            this.pbDown.TabStop = false;
            this.ttipIndicators.SetToolTip(this.pbDown, "Пушка опущена");
            // 
            // lblPressure
            // 
            this.lblPressure.AutoSize = true;
            this.lblPressure.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPressure.Location = new System.Drawing.Point(112, 62);
            this.lblPressure.Name = "lblPressure";
            this.lblPressure.Size = new System.Drawing.Size(18, 20);
            this.lblPressure.TabIndex = 11;
            this.lblPressure.Text = "0";
            // 
            // pbPressure
            // 
            this.pbPressure.BackgroundImage = global::FireSafety.Properties.Resources.Pressure;
            this.pbPressure.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbPressure.Location = new System.Drawing.Point(83, 59);
            this.pbPressure.Name = "pbPressure";
            this.pbPressure.Size = new System.Drawing.Size(23, 23);
            this.pbPressure.TabIndex = 10;
            this.pbPressure.TabStop = false;
            this.ttipIndicators.SetToolTip(this.pbPressure, "Давление воды");
            // 
            // lblCapacity
            // 
            this.lblCapacity.AutoSize = true;
            this.lblCapacity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCapacity.Location = new System.Drawing.Point(35, 62);
            this.lblCapacity.Name = "lblCapacity";
            this.lblCapacity.Size = new System.Drawing.Size(18, 20);
            this.lblCapacity.TabIndex = 9;
            this.lblCapacity.Text = "0";
            // 
            // pbCapacity
            // 
            this.pbCapacity.BackgroundImage = global::FireSafety.Properties.Resources.Water;
            this.pbCapacity.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbCapacity.Location = new System.Drawing.Point(6, 59);
            this.pbCapacity.Name = "pbCapacity";
            this.pbCapacity.Size = new System.Drawing.Size(23, 23);
            this.pbCapacity.TabIndex = 8;
            this.pbCapacity.TabStop = false;
            this.ttipIndicators.SetToolTip(this.pbCapacity, "Запасы воды");
            // 
            // chbBlocked
            // 
            this.chbBlocked.Appearance = System.Windows.Forms.Appearance.Button;
            this.chbBlocked.BackgroundImage = global::FireSafety.Properties.Resources.Unblock;
            this.chbBlocked.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chbBlocked.Location = new System.Drawing.Point(273, 59);
            this.chbBlocked.Name = "chbBlocked";
            this.chbBlocked.Size = new System.Drawing.Size(23, 23);
            this.chbBlocked.TabIndex = 7;
            this.ttipBlock.SetToolTip(this.chbBlocked, "Заблокировать выполнение");
            this.chbBlocked.UseVisualStyleBackColor = true;
            this.chbBlocked.CheckedChanged += new System.EventHandler(this.chbBlocked_CheckedChanged);
            // 
            // btnClearAlgorithm
            // 
            this.btnClearAlgorithm.BackgroundImage = global::FireSafety.Properties.Resources.ClearAlgorithm;
            this.btnClearAlgorithm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClearAlgorithm.Location = new System.Drawing.Point(331, 59);
            this.btnClearAlgorithm.Name = "btnClearAlgorithm";
            this.btnClearAlgorithm.Size = new System.Drawing.Size(23, 23);
            this.btnClearAlgorithm.TabIndex = 6;
            this.ttipClearTankAlgorithm.SetToolTip(this.btnClearAlgorithm, "Очистить алгоритм танка");
            this.btnClearAlgorithm.UseVisualStyleBackColor = true;
            this.btnClearAlgorithm.Click += new System.EventHandler(this.btnClearAlgorithm_Click);
            // 
            // btnDeleteAction
            // 
            this.btnDeleteAction.BackgroundImage = global::FireSafety.Properties.Resources.DeleteAction1;
            this.btnDeleteAction.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDeleteAction.Location = new System.Drawing.Point(302, 59);
            this.btnDeleteAction.Name = "btnDeleteAction";
            this.btnDeleteAction.Size = new System.Drawing.Size(23, 23);
            this.btnDeleteAction.TabIndex = 6;
            this.ttipDeleteAction.SetToolTip(this.btnDeleteAction, "Удалить строку");
            this.btnDeleteAction.UseVisualStyleBackColor = true;
            this.btnDeleteAction.Click += new System.EventHandler(this.btnDeleteAction_Click);
            // 
            // lblTurretCommands
            // 
            this.lblTurretCommands.AutoSize = true;
            this.lblTurretCommands.Location = new System.Drawing.Point(239, 16);
            this.lblTurretCommands.Name = "lblTurretCommands";
            this.lblTurretCommands.Size = new System.Drawing.Size(56, 13);
            this.lblTurretCommands.TabIndex = 4;
            this.lblTurretCommands.Text = "Наводчик";
            // 
            // lblChargeCommands
            // 
            this.lblChargeCommands.AutoSize = true;
            this.lblChargeCommands.Location = new System.Drawing.Point(121, 16);
            this.lblChargeCommands.Name = "lblChargeCommands";
            this.lblChargeCommands.Size = new System.Drawing.Size(75, 13);
            this.lblChargeCommands.TabIndex = 3;
            this.lblChargeCommands.Text = "Заряжающий";
            // 
            // lblMoveCommands
            // 
            this.lblMoveCommands.AutoSize = true;
            this.lblMoveCommands.Location = new System.Drawing.Point(3, 16);
            this.lblMoveCommands.Name = "lblMoveCommands";
            this.lblMoveCommands.Size = new System.Drawing.Size(55, 13);
            this.lblMoveCommands.TabIndex = 0;
            this.lblMoveCommands.Text = "Водитель";
            // 
            // pbUnready
            // 
            this.pbUnready.BackgroundImage = global::FireSafety.Properties.Resources.Uncharged;
            this.pbUnready.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbUnready.Location = new System.Drawing.Point(189, 59);
            this.pbUnready.Name = "pbUnready";
            this.pbUnready.Size = new System.Drawing.Size(23, 23);
            this.pbUnready.TabIndex = 15;
            this.pbUnready.TabStop = false;
            this.ttipIndicators.SetToolTip(this.pbUnready, "Пушка не заряжена");
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
            this.ttipDeleteAction.SetToolTip(this, "Удалить строку");
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AlgorithmForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlgorithm)).EndInit();
            this.gbControls.ResumeLayout(false);
            this.gbControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbReady)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPressure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCapacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnready)).EndInit();
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
        private System.Windows.Forms.CheckBox chbBlocked;
        private System.Windows.Forms.ToolTip ttipBlock;
        private System.Windows.Forms.ToolTip ttipClearTankAlgorithm;
        private System.Windows.Forms.ToolTip ttipDeleteAction;
        private System.Windows.Forms.PictureBox pbCapacity;
        private System.Windows.Forms.PictureBox pbPressure;
        public System.Windows.Forms.Label lblPressure;
        public System.Windows.Forms.Label lblCapacity;
        public System.Windows.Forms.PictureBox pbDown;
        public System.Windows.Forms.PictureBox pbUp;
        public System.Windows.Forms.PictureBox pbUnready;
        public System.Windows.Forms.PictureBox pbReady;
        public System.Windows.Forms.Label lblMaxPressure;
        private System.Windows.Forms.Label lblPressureSlash;
        public System.Windows.Forms.Label lblMaxCapacity;
        private System.Windows.Forms.Label lblCapacitySlash;
        private System.Windows.Forms.ToolTip ttipIndicators;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn MoveCommands;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShootCommands;
        private System.Windows.Forms.DataGridViewTextBoxColumn TurretCommands;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtbcPlanItem;
        private System.Windows.Forms.Button btnInsertAction;
        private System.Windows.Forms.ToolTip ttipInsertAction;
    }
}