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
            this.lbMoveCommands = new System.Windows.Forms.ListBox();
            this.lbShootCommands = new System.Windows.Forms.ListBox();
            this.lbTurretCommands = new System.Windows.Forms.ListBox();
            this.cbShoot = new System.Windows.Forms.ComboBox();
            this.cbTurret = new System.Windows.Forms.ComboBox();
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
            this.cbMove.Location = new System.Drawing.Point(12, 217);
            this.cbMove.Name = "cbMove";
            this.cbMove.Size = new System.Drawing.Size(121, 21);
            this.cbMove.TabIndex = 2;
            this.cbMove.SelectedIndexChanged += new System.EventHandler(this.cbShootCommandsCommands_SelectedIndexChanged);
            // 
            // lbMoveCommands
            // 
            this.lbMoveCommands.FormattingEnabled = true;
            this.lbMoveCommands.Location = new System.Drawing.Point(12, 12);
            this.lbMoveCommands.Name = "lbMoveCommands";
            this.lbMoveCommands.Size = new System.Drawing.Size(120, 199);
            this.lbMoveCommands.TabIndex = 5;
            // 
            // lbShootCommands
            // 
            this.lbShootCommands.FormattingEnabled = true;
            this.lbShootCommands.Location = new System.Drawing.Point(138, 12);
            this.lbShootCommands.Name = "lbShootCommands";
            this.lbShootCommands.Size = new System.Drawing.Size(120, 199);
            this.lbShootCommands.TabIndex = 5;
            // 
            // lbTurretCommands
            // 
            this.lbTurretCommands.FormattingEnabled = true;
            this.lbTurretCommands.Location = new System.Drawing.Point(264, 12);
            this.lbTurretCommands.Name = "lbTurretCommands";
            this.lbTurretCommands.Size = new System.Drawing.Size(120, 199);
            this.lbTurretCommands.TabIndex = 5;
            // 
            // cbShoot
            // 
            this.cbShoot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbShoot.FormattingEnabled = true;
            this.cbShoot.Items.AddRange(new object[] {
            "Increase water pressure",
            "Shoot",
            "None"});
            this.cbShoot.Location = new System.Drawing.Point(138, 217);
            this.cbShoot.Name = "cbShoot";
            this.cbShoot.Size = new System.Drawing.Size(121, 21);
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
            this.cbTurret.Location = new System.Drawing.Point(264, 217);
            this.cbTurret.Name = "cbTurret";
            this.cbTurret.Size = new System.Drawing.Size(121, 21);
            this.cbTurret.TabIndex = 2;
            this.cbTurret.SelectedIndexChanged += new System.EventHandler(this.cbTurret_SelectedIndexChanged);
            // 
            // AlgorithmForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 462);
            this.Controls.Add(this.lbTurretCommands);
            this.Controls.Add(this.lbShootCommands);
            this.Controls.Add(this.lbMoveCommands);
            this.Controls.Add(this.cbTurret);
            this.Controls.Add(this.cbShoot);
            this.Controls.Add(this.cbMove);
            this.Name = "AlgorithmForm";
            this.Tag = "Algorithm";
            this.Text = "Algorithm";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cbMove;
        public System.Windows.Forms.ListBox lbMoveCommands;
        public System.Windows.Forms.ListBox lbShootCommands;
        public System.Windows.Forms.ListBox lbTurretCommands;
        private System.Windows.Forms.ComboBox cbShoot;
        private System.Windows.Forms.ComboBox cbTurret;
    }
}