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
            this.cbShoot = new System.Windows.Forms.ComboBox();
            this.cbTurret = new System.Windows.Forms.ComboBox();
            this.dgvAlgorithm = new System.Windows.Forms.DataGridView();
            this.MoveCommands = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShootCommands = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TurretCommands = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbControls = new System.Windows.Forms.GroupBox();
            this.btnDeleteAction = new System.Windows.Forms.Button();
            this.btnMoveActionDown = new System.Windows.Forms.Button();
            this.btnMoveActionUp = new System.Windows.Forms.Button();
            this.rbtnInsertAfter = new System.Windows.Forms.RadioButton();
            this.rbtnInsertBefore = new System.Windows.Forms.RadioButton();
            this.rbtnChange = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlgorithm)).BeginInit();
            this.gbControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbMove
            // 
            this.cbMove.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMove.FormattingEnabled = true;
            this.cbMove.Items.AddRange(new object[] {
            "Forward",
            "Backward",
            "Rotate 90 CW",
            "Rotate 90 CCW",
            "Rotate 45 CW",
            "Rotate 45 CCW",
            "None"});
            this.cbMove.Location = new System.Drawing.Point(6, 19);
            this.cbMove.Name = "cbMove";
            this.cbMove.Size = new System.Drawing.Size(120, 21);
            this.cbMove.TabIndex = 2;
            this.cbMove.SelectedIndexChanged += new System.EventHandler(this.cbShootCommandsCommands_SelectedIndexChanged);
            // 
            // cbShoot
            // 
            this.cbShoot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbShoot.FormattingEnabled = true;
            this.cbShoot.Items.AddRange(new object[] {
            "Increase water pressure",
            "Shoot",
            "None"});
            this.cbShoot.Location = new System.Drawing.Point(132, 19);
            this.cbShoot.Name = "cbShoot";
            this.cbShoot.Size = new System.Drawing.Size(120, 21);
            this.cbShoot.TabIndex = 2;
            this.cbShoot.SelectedIndexChanged += new System.EventHandler(this.cbShoot_SelectedIndexChanged);
            // 
            // cbTurret
            // 
            this.cbTurret.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTurret.FormattingEnabled = true;
            this.cbTurret.Items.AddRange(new object[] {
            "Rotate 45 CW",
            "Rotate 45 CCW",
            "Rotate 90 CW",
            "Rotate 90 CCW",
            "Up",
            "Down",
            "None"});
            this.cbTurret.Location = new System.Drawing.Point(258, 19);
            this.cbTurret.Name = "cbTurret";
            this.cbTurret.Size = new System.Drawing.Size(120, 21);
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
            this.dgvAlgorithm.Size = new System.Drawing.Size(384, 249);
            this.dgvAlgorithm.TabIndex = 6;
            this.dgvAlgorithm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvAlgorithm_KeyPress);
            // 
            // MoveCommands
            // 
            this.MoveCommands.HeaderText = "Move";
            this.MoveCommands.Name = "MoveCommands";
            this.MoveCommands.ReadOnly = true;
            this.MoveCommands.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MoveCommands.Width = 115;
            // 
            // ShootCommands
            // 
            this.ShootCommands.HeaderText = "Shoot";
            this.ShootCommands.Name = "ShootCommands";
            this.ShootCommands.ReadOnly = true;
            this.ShootCommands.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ShootCommands.Width = 115;
            // 
            // TurretCommands
            // 
            this.TurretCommands.HeaderText = "Turret";
            this.TurretCommands.Name = "TurretCommands";
            this.TurretCommands.ReadOnly = true;
            this.TurretCommands.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TurretCommands.Width = 115;
            // 
            // gbControls
            // 
            this.gbControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbControls.Controls.Add(this.btnDeleteAction);
            this.gbControls.Controls.Add(this.btnMoveActionDown);
            this.gbControls.Controls.Add(this.btnMoveActionUp);
            this.gbControls.Controls.Add(this.rbtnInsertAfter);
            this.gbControls.Controls.Add(this.rbtnInsertBefore);
            this.gbControls.Controls.Add(this.rbtnChange);
            this.gbControls.Controls.Add(this.cbTurret);
            this.gbControls.Controls.Add(this.cbShoot);
            this.gbControls.Controls.Add(this.cbMove);
            this.gbControls.Location = new System.Drawing.Point(12, 267);
            this.gbControls.Name = "gbControls";
            this.gbControls.Size = new System.Drawing.Size(384, 133);
            this.gbControls.TabIndex = 8;
            this.gbControls.TabStop = false;
            // 
            // btnDeleteAction
            // 
            this.btnDeleteAction.Location = new System.Drawing.Point(258, 104);
            this.btnDeleteAction.Name = "btnDeleteAction";
            this.btnDeleteAction.Size = new System.Drawing.Size(120, 23);
            this.btnDeleteAction.TabIndex = 4;
            this.btnDeleteAction.Text = "Delete action";
            this.btnDeleteAction.UseVisualStyleBackColor = true;
            this.btnDeleteAction.Click += new System.EventHandler(this.btnDeleteAction_Click);
            // 
            // btnMoveActionDown
            // 
            this.btnMoveActionDown.Location = new System.Drawing.Point(258, 75);
            this.btnMoveActionDown.Name = "btnMoveActionDown";
            this.btnMoveActionDown.Size = new System.Drawing.Size(120, 23);
            this.btnMoveActionDown.TabIndex = 4;
            this.btnMoveActionDown.Text = "Move action down";
            this.btnMoveActionDown.UseVisualStyleBackColor = true;
            // 
            // btnMoveActionUp
            // 
            this.btnMoveActionUp.Location = new System.Drawing.Point(258, 46);
            this.btnMoveActionUp.Name = "btnMoveActionUp";
            this.btnMoveActionUp.Size = new System.Drawing.Size(120, 23);
            this.btnMoveActionUp.TabIndex = 4;
            this.btnMoveActionUp.Text = "Move action up";
            this.btnMoveActionUp.UseVisualStyleBackColor = true;
            // 
            // rbtnInsertAfter
            // 
            this.rbtnInsertAfter.AutoSize = true;
            this.rbtnInsertAfter.Location = new System.Drawing.Point(6, 92);
            this.rbtnInsertAfter.Name = "rbtnInsertAfter";
            this.rbtnInsertAfter.Size = new System.Drawing.Size(75, 17);
            this.rbtnInsertAfter.TabIndex = 3;
            this.rbtnInsertAfter.Text = "Insert after";
            this.rbtnInsertAfter.UseVisualStyleBackColor = true;
            // 
            // rbtnInsertBefore
            // 
            this.rbtnInsertBefore.AutoSize = true;
            this.rbtnInsertBefore.Location = new System.Drawing.Point(6, 69);
            this.rbtnInsertBefore.Name = "rbtnInsertBefore";
            this.rbtnInsertBefore.Size = new System.Drawing.Size(84, 17);
            this.rbtnInsertBefore.TabIndex = 3;
            this.rbtnInsertBefore.Text = "Insert before";
            this.rbtnInsertBefore.UseVisualStyleBackColor = true;
            // 
            // rbtnChange
            // 
            this.rbtnChange.AutoSize = true;
            this.rbtnChange.Checked = true;
            this.rbtnChange.Location = new System.Drawing.Point(6, 46);
            this.rbtnChange.Name = "rbtnChange";
            this.rbtnChange.Size = new System.Drawing.Size(62, 17);
            this.rbtnChange.TabIndex = 3;
            this.rbtnChange.TabStop = true;
            this.rbtnChange.Text = "Change";
            this.rbtnChange.UseVisualStyleBackColor = true;
            // 
            // AlgorithmForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 412);
            this.ControlBox = false;
            this.Controls.Add(this.gbControls);
            this.Controls.Add(this.dgvAlgorithm);
            this.MinimumSize = new System.Drawing.Size(424, 250);
            this.Name = "AlgorithmForm";
            this.Tag = "Algorithm";
            this.Text = "Algorithm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlgorithm)).EndInit();
            this.gbControls.ResumeLayout(false);
            this.gbControls.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cbMove;
        private System.Windows.Forms.ComboBox cbShoot;
        private System.Windows.Forms.ComboBox cbTurret;
        public System.Windows.Forms.DataGridView dgvAlgorithm;
        private System.Windows.Forms.DataGridViewTextBoxColumn MoveCommands;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShootCommands;
        private System.Windows.Forms.DataGridViewTextBoxColumn TurretCommands;
        private System.Windows.Forms.GroupBox gbControls;
        private System.Windows.Forms.Button btnDeleteAction;
        private System.Windows.Forms.Button btnMoveActionDown;
        private System.Windows.Forms.Button btnMoveActionUp;
        private System.Windows.Forms.RadioButton rbtnInsertAfter;
        private System.Windows.Forms.RadioButton rbtnInsertBefore;
        private System.Windows.Forms.RadioButton rbtnChange;
    }
}