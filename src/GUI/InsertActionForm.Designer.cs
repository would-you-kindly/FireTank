namespace FireSafety
{
    partial class InsertActionForm
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
            this.lblTurretCommands = new System.Windows.Forms.Label();
            this.lblChargeCommands = new System.Windows.Forms.Label();
            this.lblMoveCommands = new System.Windows.Forms.Label();
            this.cbTurret = new System.Windows.Forms.ComboBox();
            this.cbCharge = new System.Windows.Forms.ComboBox();
            this.cbMove = new System.Windows.Forms.ComboBox();
            this.btnInsert = new System.Windows.Forms.Button();
            this.cbNumber = new System.Windows.Forms.ComboBox();
            this.lblNumber = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTurretCommands
            // 
            this.lblTurretCommands.AutoSize = true;
            this.lblTurretCommands.Location = new System.Drawing.Point(301, 9);
            this.lblTurretCommands.Name = "lblTurretCommands";
            this.lblTurretCommands.Size = new System.Drawing.Size(56, 13);
            this.lblTurretCommands.TabIndex = 10;
            this.lblTurretCommands.Text = "Наводчик";
            // 
            // lblChargeCommands
            // 
            this.lblChargeCommands.AutoSize = true;
            this.lblChargeCommands.Location = new System.Drawing.Point(183, 9);
            this.lblChargeCommands.Name = "lblChargeCommands";
            this.lblChargeCommands.Size = new System.Drawing.Size(75, 13);
            this.lblChargeCommands.TabIndex = 9;
            this.lblChargeCommands.Text = "Заряжающий";
            // 
            // lblMoveCommands
            // 
            this.lblMoveCommands.AutoSize = true;
            this.lblMoveCommands.Location = new System.Drawing.Point(65, 9);
            this.lblMoveCommands.Name = "lblMoveCommands";
            this.lblMoveCommands.Size = new System.Drawing.Size(55, 13);
            this.lblMoveCommands.TabIndex = 5;
            this.lblMoveCommands.Text = "Водитель";
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
            this.cbTurret.Location = new System.Drawing.Point(304, 25);
            this.cbTurret.Name = "cbTurret";
            this.cbTurret.Size = new System.Drawing.Size(112, 21);
            this.cbTurret.TabIndex = 6;
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
            this.cbCharge.Location = new System.Drawing.Point(186, 25);
            this.cbCharge.Name = "cbCharge";
            this.cbCharge.Size = new System.Drawing.Size(112, 21);
            this.cbCharge.TabIndex = 7;
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
            this.cbMove.Location = new System.Drawing.Point(68, 25);
            this.cbMove.Name = "cbMove";
            this.cbMove.Size = new System.Drawing.Size(112, 21);
            this.cbMove.TabIndex = 8;
            // 
            // btnInsert
            // 
            this.btnInsert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInsert.Location = new System.Drawing.Point(341, 52);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 23);
            this.btnInsert.TabIndex = 11;
            this.btnInsert.Text = "OK";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // cbNumber
            // 
            this.cbNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNumber.FormattingEnabled = true;
            this.cbNumber.Location = new System.Drawing.Point(12, 25);
            this.cbNumber.Name = "cbNumber";
            this.cbNumber.Size = new System.Drawing.Size(50, 21);
            this.cbNumber.TabIndex = 12;
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Location = new System.Drawing.Point(12, 9);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(18, 13);
            this.lblNumber.TabIndex = 13;
            this.lblNumber.Text = "№";
            // 
            // InsertActionForm
            // 
            this.AcceptButton = this.btnInsert;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 87);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.cbNumber);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.lblTurretCommands);
            this.Controls.Add(this.lblChargeCommands);
            this.Controls.Add(this.lblMoveCommands);
            this.Controls.Add(this.cbTurret);
            this.Controls.Add(this.cbCharge);
            this.Controls.Add(this.cbMove);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(444, 125);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(444, 125);
            this.Name = "InsertActionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Вставить строку";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTurretCommands;
        private System.Windows.Forms.Label lblChargeCommands;
        private System.Windows.Forms.Label lblMoveCommands;
        public System.Windows.Forms.ComboBox cbTurret;
        public System.Windows.Forms.ComboBox cbCharge;
        public System.Windows.Forms.ComboBox cbMove;
        private System.Windows.Forms.Button btnInsert;
        public System.Windows.Forms.ComboBox cbNumber;
        private System.Windows.Forms.Label lblNumber;
    }
}