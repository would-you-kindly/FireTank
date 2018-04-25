namespace FireSafety
{
    partial class FireSafetyForm
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAlgorithmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAlgorithmAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openAlgorithmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCommandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveCommandsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forwardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backwardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forward45CWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forward45CCWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backward45CWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backward45CCWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotate45CWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotate45CCWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotate90CWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotate90CCWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shootCommandsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pressureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noneToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.turretCommandsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotate45CWToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rotate45CCWToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rotate90CWToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rotate90CCWToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.upToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shootToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.noneToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.reorderingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveActionUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveActionDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteActionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.algorithmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.executeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.layoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.algorithmsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.algorithmToolStripMenuItem,
            this.windowToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(284, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAlgorithmToolStripMenuItem,
            this.saveAlgorithmAsToolStripMenuItem,
            this.openAlgorithmToolStripMenuItem,
            this.openMapToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveAlgorithmToolStripMenuItem
            // 
            this.saveAlgorithmToolStripMenuItem.Name = "saveAlgorithmToolStripMenuItem";
            this.saveAlgorithmToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveAlgorithmToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.saveAlgorithmToolStripMenuItem.Text = "Save algorithm";
            this.saveAlgorithmToolStripMenuItem.Click += new System.EventHandler(this.saveAlgorithmToolStripMenuItem_Click);
            // 
            // saveAlgorithmAsToolStripMenuItem
            // 
            this.saveAlgorithmAsToolStripMenuItem.Name = "saveAlgorithmAsToolStripMenuItem";
            this.saveAlgorithmAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAlgorithmAsToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.saveAlgorithmAsToolStripMenuItem.Text = "Save algorithm as...";
            this.saveAlgorithmAsToolStripMenuItem.Click += new System.EventHandler(this.saveAlgorithmAsToolStripMenuItem_Click);
            // 
            // openAlgorithmToolStripMenuItem
            // 
            this.openAlgorithmToolStripMenuItem.Name = "openAlgorithmToolStripMenuItem";
            this.openAlgorithmToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openAlgorithmToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.openAlgorithmToolStripMenuItem.Text = "Open algorithm";
            this.openAlgorithmToolStripMenuItem.Click += new System.EventHandler(this.openAlgorithmToolStripMenuItem_Click);
            // 
            // openMapToolStripMenuItem
            // 
            this.openMapToolStripMenuItem.Name = "openMapToolStripMenuItem";
            this.openMapToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.O)));
            this.openMapToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.openMapToolStripMenuItem.Text = "Open map";
            this.openMapToolStripMenuItem.Click += new System.EventHandler(this.openMapToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCommandToolStripMenuItem,
            this.reorderingToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // addCommandToolStripMenuItem
            // 
            this.addCommandToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moveCommandsToolStripMenuItem,
            this.shootCommandsToolStripMenuItem,
            this.turretCommandsToolStripMenuItem});
            this.addCommandToolStripMenuItem.Name = "addCommandToolStripMenuItem";
            this.addCommandToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.addCommandToolStripMenuItem.Text = "Commands";
            // 
            // moveCommandsToolStripMenuItem
            // 
            this.moveCommandsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.forwardToolStripMenuItem,
            this.backwardToolStripMenuItem,
            this.forward45CWToolStripMenuItem,
            this.forward45CCWToolStripMenuItem,
            this.backward45CWToolStripMenuItem,
            this.backward45CCWToolStripMenuItem,
            this.rotate45CWToolStripMenuItem,
            this.rotate45CCWToolStripMenuItem,
            this.rotate90CWToolStripMenuItem,
            this.rotate90CCWToolStripMenuItem,
            this.noneToolStripMenuItem});
            this.moveCommandsToolStripMenuItem.Name = "moveCommandsToolStripMenuItem";
            this.moveCommandsToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.moveCommandsToolStripMenuItem.Text = "Move";
            // 
            // forwardToolStripMenuItem
            // 
            this.forwardToolStripMenuItem.Name = "forwardToolStripMenuItem";
            this.forwardToolStripMenuItem.ShortcutKeyDisplayString = "F";
            this.forwardToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
            this.forwardToolStripMenuItem.Text = "Forward";
            this.forwardToolStripMenuItem.Click += new System.EventHandler(this.forwardToolStripMenuItem_Click);
            // 
            // backwardToolStripMenuItem
            // 
            this.backwardToolStripMenuItem.Name = "backwardToolStripMenuItem";
            this.backwardToolStripMenuItem.ShortcutKeyDisplayString = "B";
            this.backwardToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
            this.backwardToolStripMenuItem.Text = "Backward";
            this.backwardToolStripMenuItem.Click += new System.EventHandler(this.backwardToolStripMenuItem_Click);
            // 
            // forward45CWToolStripMenuItem
            // 
            this.forward45CWToolStripMenuItem.Name = "forward45CWToolStripMenuItem";
            this.forward45CWToolStripMenuItem.ShortcutKeyDisplayString = "NumPad 9";
            this.forward45CWToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
            this.forward45CWToolStripMenuItem.Text = "Forward 45 CW";
            this.forward45CWToolStripMenuItem.Click += new System.EventHandler(this.forward45CWToolStripMenuItem_Click);
            // 
            // forward45CCWToolStripMenuItem
            // 
            this.forward45CCWToolStripMenuItem.Name = "forward45CCWToolStripMenuItem";
            this.forward45CCWToolStripMenuItem.ShortcutKeyDisplayString = "NumPad 7";
            this.forward45CCWToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
            this.forward45CCWToolStripMenuItem.Text = "Forward 45 CCW";
            this.forward45CCWToolStripMenuItem.Click += new System.EventHandler(this.forward45CCWToolStripMenuItem_Click);
            // 
            // backward45CWToolStripMenuItem
            // 
            this.backward45CWToolStripMenuItem.Name = "backward45CWToolStripMenuItem";
            this.backward45CWToolStripMenuItem.ShortcutKeyDisplayString = "NumPad 1";
            this.backward45CWToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
            this.backward45CWToolStripMenuItem.Text = "Backward 45 CW";
            this.backward45CWToolStripMenuItem.Click += new System.EventHandler(this.backward45CWToolStripMenuItem_Click);
            // 
            // backward45CCWToolStripMenuItem
            // 
            this.backward45CCWToolStripMenuItem.Name = "backward45CCWToolStripMenuItem";
            this.backward45CCWToolStripMenuItem.ShortcutKeyDisplayString = "NumPad 3";
            this.backward45CCWToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
            this.backward45CCWToolStripMenuItem.Text = "Backward 45 CCW";
            this.backward45CCWToolStripMenuItem.Click += new System.EventHandler(this.backward45CCWToolStripMenuItem_Click);
            // 
            // rotate45CWToolStripMenuItem
            // 
            this.rotate45CWToolStripMenuItem.Name = "rotate45CWToolStripMenuItem";
            this.rotate45CWToolStripMenuItem.ShortcutKeyDisplayString = "NumPad 8";
            this.rotate45CWToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
            this.rotate45CWToolStripMenuItem.Text = "Rotate 45 CW";
            this.rotate45CWToolStripMenuItem.Click += new System.EventHandler(this.rotate45CWToolStripMenuItem_Click);
            // 
            // rotate45CCWToolStripMenuItem
            // 
            this.rotate45CCWToolStripMenuItem.Name = "rotate45CCWToolStripMenuItem";
            this.rotate45CCWToolStripMenuItem.ShortcutKeyDisplayString = "NumPad 2";
            this.rotate45CCWToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
            this.rotate45CCWToolStripMenuItem.Text = "Rotate 45 CCW";
            this.rotate45CCWToolStripMenuItem.Click += new System.EventHandler(this.rotate45CCWToolStripMenuItem_Click);
            // 
            // rotate90CWToolStripMenuItem
            // 
            this.rotate90CWToolStripMenuItem.Name = "rotate90CWToolStripMenuItem";
            this.rotate90CWToolStripMenuItem.ShortcutKeyDisplayString = "NumPad 8 (Hold)";
            this.rotate90CWToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
            this.rotate90CWToolStripMenuItem.Text = "Rotate 90 CW";
            this.rotate90CWToolStripMenuItem.Click += new System.EventHandler(this.rotate90CWToolStripMenuItem_Click);
            // 
            // rotate90CCWToolStripMenuItem
            // 
            this.rotate90CCWToolStripMenuItem.Name = "rotate90CCWToolStripMenuItem";
            this.rotate90CCWToolStripMenuItem.ShortcutKeyDisplayString = "NumPad 2 (Hold)";
            this.rotate90CCWToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
            this.rotate90CCWToolStripMenuItem.Text = "Rotate 90 CCW";
            this.rotate90CCWToolStripMenuItem.Click += new System.EventHandler(this.rotate90CCWToolStripMenuItem_Click);
            // 
            // noneToolStripMenuItem
            // 
            this.noneToolStripMenuItem.Name = "noneToolStripMenuItem";
            this.noneToolStripMenuItem.ShortcutKeyDisplayString = "N";
            this.noneToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
            this.noneToolStripMenuItem.Text = "None";
            this.noneToolStripMenuItem.Click += new System.EventHandler(this.noneMoveToolStripMenuItem_Click);
            // 
            // shootCommandsToolStripMenuItem
            // 
            this.shootCommandsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pressureToolStripMenuItem,
            this.noneToolStripMenuItem1});
            this.shootCommandsToolStripMenuItem.Name = "shootCommandsToolStripMenuItem";
            this.shootCommandsToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.shootCommandsToolStripMenuItem.Text = "Shoot";
            // 
            // pressureToolStripMenuItem
            // 
            this.pressureToolStripMenuItem.Name = "pressureToolStripMenuItem";
            this.pressureToolStripMenuItem.ShortcutKeyDisplayString = "P";
            this.pressureToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.pressureToolStripMenuItem.Text = "Pressure";
            this.pressureToolStripMenuItem.Click += new System.EventHandler(this.pressureToolStripMenuItem_Click);
            // 
            // noneToolStripMenuItem1
            // 
            this.noneToolStripMenuItem1.Name = "noneToolStripMenuItem1";
            this.noneToolStripMenuItem1.ShortcutKeyDisplayString = "N";
            this.noneToolStripMenuItem1.Size = new System.Drawing.Size(132, 22);
            this.noneToolStripMenuItem1.Text = "None";
            this.noneToolStripMenuItem1.Click += new System.EventHandler(this.noneShootToolStripMenuItem_Click);
            // 
            // turretCommandsToolStripMenuItem
            // 
            this.turretCommandsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rotate45CWToolStripMenuItem1,
            this.rotate45CCWToolStripMenuItem1,
            this.rotate90CWToolStripMenuItem1,
            this.rotate90CCWToolStripMenuItem1,
            this.upToolStripMenuItem,
            this.downToolStripMenuItem,
            this.shootToolStripMenuItem1,
            this.noneToolStripMenuItem2});
            this.turretCommandsToolStripMenuItem.Name = "turretCommandsToolStripMenuItem";
            this.turretCommandsToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.turretCommandsToolStripMenuItem.Text = "Turret";
            // 
            // rotate45CWToolStripMenuItem1
            // 
            this.rotate45CWToolStripMenuItem1.Name = "rotate45CWToolStripMenuItem1";
            this.rotate45CWToolStripMenuItem1.ShortcutKeyDisplayString = "NumPad 6";
            this.rotate45CWToolStripMenuItem1.Size = new System.Drawing.Size(253, 22);
            this.rotate45CWToolStripMenuItem1.Text = "Rotate 45 CW";
            this.rotate45CWToolStripMenuItem1.Click += new System.EventHandler(this.rotate45CWToolStripMenuItem1_Click);
            // 
            // rotate45CCWToolStripMenuItem1
            // 
            this.rotate45CCWToolStripMenuItem1.Name = "rotate45CCWToolStripMenuItem1";
            this.rotate45CCWToolStripMenuItem1.ShortcutKeyDisplayString = "NumPad 4";
            this.rotate45CCWToolStripMenuItem1.Size = new System.Drawing.Size(253, 22);
            this.rotate45CCWToolStripMenuItem1.Text = "Rotate 45 CCW";
            this.rotate45CCWToolStripMenuItem1.Click += new System.EventHandler(this.rotate45CCWToolStripMenuItem1_Click);
            // 
            // rotate90CWToolStripMenuItem1
            // 
            this.rotate90CWToolStripMenuItem1.Name = "rotate90CWToolStripMenuItem1";
            this.rotate90CWToolStripMenuItem1.ShortcutKeyDisplayString = "NumPad 6 (Hold)";
            this.rotate90CWToolStripMenuItem1.Size = new System.Drawing.Size(253, 22);
            this.rotate90CWToolStripMenuItem1.Text = "Rotate 90 CW";
            this.rotate90CWToolStripMenuItem1.Click += new System.EventHandler(this.rotate90CWToolStripMenuItem1_Click);
            // 
            // rotate90CCWToolStripMenuItem1
            // 
            this.rotate90CCWToolStripMenuItem1.Name = "rotate90CCWToolStripMenuItem1";
            this.rotate90CCWToolStripMenuItem1.ShortcutKeyDisplayString = "NumPad 4 (Hold)";
            this.rotate90CCWToolStripMenuItem1.Size = new System.Drawing.Size(253, 22);
            this.rotate90CCWToolStripMenuItem1.Text = "Rotate 90 CCW";
            this.rotate90CCWToolStripMenuItem1.Click += new System.EventHandler(this.rotate90CCWToolStripMenuItem1_Click);
            // 
            // upToolStripMenuItem
            // 
            this.upToolStripMenuItem.Name = "upToolStripMenuItem";
            this.upToolStripMenuItem.ShortcutKeyDisplayString = "U";
            this.upToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
            this.upToolStripMenuItem.Text = "Up";
            this.upToolStripMenuItem.Click += new System.EventHandler(this.upToolStripMenuItem_Click);
            // 
            // downToolStripMenuItem
            // 
            this.downToolStripMenuItem.Name = "downToolStripMenuItem";
            this.downToolStripMenuItem.ShortcutKeyDisplayString = "D";
            this.downToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
            this.downToolStripMenuItem.Text = "Down";
            this.downToolStripMenuItem.Click += new System.EventHandler(this.downToolStripMenuItem_Click);
            // 
            // shootToolStripMenuItem1
            // 
            this.shootToolStripMenuItem1.Name = "shootToolStripMenuItem1";
            this.shootToolStripMenuItem1.ShortcutKeyDisplayString = "S";
            this.shootToolStripMenuItem1.Size = new System.Drawing.Size(253, 22);
            this.shootToolStripMenuItem1.Text = "Shoot";
            this.shootToolStripMenuItem1.Click += new System.EventHandler(this.shootToolStripMenuItem1_Click);
            // 
            // noneToolStripMenuItem2
            // 
            this.noneToolStripMenuItem2.Name = "noneToolStripMenuItem2";
            this.noneToolStripMenuItem2.ShortcutKeyDisplayString = "N";
            this.noneToolStripMenuItem2.Size = new System.Drawing.Size(253, 22);
            this.noneToolStripMenuItem2.Text = "None";
            this.noneToolStripMenuItem2.Click += new System.EventHandler(this.noneTurretToolStripMenuItem_Click);
            // 
            // reorderingToolStripMenuItem
            // 
            this.reorderingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moveActionUpToolStripMenuItem,
            this.moveActionDownToolStripMenuItem,
            this.deleteActionToolStripMenuItem});
            this.reorderingToolStripMenuItem.Name = "reorderingToolStripMenuItem";
            this.reorderingToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.reorderingToolStripMenuItem.Text = "Reordering";
            // 
            // moveActionUpToolStripMenuItem
            // 
            this.moveActionUpToolStripMenuItem.Name = "moveActionUpToolStripMenuItem";
            this.moveActionUpToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.moveActionUpToolStripMenuItem.Text = "Move action up";
            // 
            // moveActionDownToolStripMenuItem
            // 
            this.moveActionDownToolStripMenuItem.Name = "moveActionDownToolStripMenuItem";
            this.moveActionDownToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.moveActionDownToolStripMenuItem.Text = "Move action down";
            // 
            // deleteActionToolStripMenuItem
            // 
            this.deleteActionToolStripMenuItem.Name = "deleteActionToolStripMenuItem";
            this.deleteActionToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.deleteActionToolStripMenuItem.Text = "Delete action";
            // 
            // algorithmToolStripMenuItem
            // 
            this.algorithmToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.executeToolStripMenuItem,
            this.reloadToolStripMenuItem,
            this.stepToolStripMenuItem,
            this.clearToolStripMenuItem});
            this.algorithmToolStripMenuItem.Name = "algorithmToolStripMenuItem";
            this.algorithmToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.algorithmToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.algorithmToolStripMenuItem.Text = "Algorithm";
            // 
            // executeToolStripMenuItem
            // 
            this.executeToolStripMenuItem.Name = "executeToolStripMenuItem";
            this.executeToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.executeToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.executeToolStripMenuItem.Text = "Run";
            this.executeToolStripMenuItem.Click += new System.EventHandler(this.runToolStripMenuItem_Click);
            // 
            // reloadToolStripMenuItem
            // 
            this.reloadToolStripMenuItem.Name = "reloadToolStripMenuItem";
            this.reloadToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.reloadToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.reloadToolStripMenuItem.Text = "Reload";
            this.reloadToolStripMenuItem.Click += new System.EventHandler(this.reloadToolStripMenuItem_Click);
            // 
            // stepToolStripMenuItem
            // 
            this.stepToolStripMenuItem.Name = "stepToolStripMenuItem";
            this.stepToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.stepToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.stepToolStripMenuItem.Text = "Step";
            this.stepToolStripMenuItem.Click += new System.EventHandler(this.stepToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.layoutToolStripMenuItem,
            this.algorithmsToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.windowToolStripMenuItem.Text = "Window";
            // 
            // layoutToolStripMenuItem
            // 
            this.layoutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smartToolStripMenuItem,
            this.horizontalToolStripMenuItem,
            this.verticalToolStripMenuItem});
            this.layoutToolStripMenuItem.Name = "layoutToolStripMenuItem";
            this.layoutToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.layoutToolStripMenuItem.Text = "Layout";
            // 
            // smartToolStripMenuItem
            // 
            this.smartToolStripMenuItem.Name = "smartToolStripMenuItem";
            this.smartToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.smartToolStripMenuItem.Text = "Smart";
            this.smartToolStripMenuItem.Click += new System.EventHandler(this.smartToolStripMenuItem_Click);
            // 
            // horizontalToolStripMenuItem
            // 
            this.horizontalToolStripMenuItem.Name = "horizontalToolStripMenuItem";
            this.horizontalToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.horizontalToolStripMenuItem.Text = "Horizontal";
            this.horizontalToolStripMenuItem.Click += new System.EventHandler(this.horizontalToolStripMenuItem_Click);
            // 
            // verticalToolStripMenuItem
            // 
            this.verticalToolStripMenuItem.Name = "verticalToolStripMenuItem";
            this.verticalToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.verticalToolStripMenuItem.Text = "Vertical";
            this.verticalToolStripMenuItem.Click += new System.EventHandler(this.verticalToolStripMenuItem_Click);
            // 
            // algorithmsToolStripMenuItem
            // 
            this.algorithmsToolStripMenuItem.Name = "algorithmsToolStripMenuItem";
            this.algorithmsToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.algorithmsToolStripMenuItem.Text = "Algorithms";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.documentationToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // documentationToolStripMenuItem
            // 
            this.documentationToolStripMenuItem.Name = "documentationToolStripMenuItem";
            this.documentationToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.documentationToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.documentationToolStripMenuItem.Text = "Documentation";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // FireSafetyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FireSafetyForm";
            this.Text = "Fire Tank";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FireSafetyForm_FormClosed);
            this.Load += new System.EventHandler(this.FireSafetyForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem algorithmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem executeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem layoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAlgorithmAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openAlgorithmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stepToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem documentationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem horizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAlgorithmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem algorithmsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addCommandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveCommandsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forwardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shootCommandsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem turretCommandsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reorderingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveActionUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveActionDownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteActionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backwardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotate45CWToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotate45CCWToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotate90CWToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotate90CCWToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pressureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noneToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem rotate45CWToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem rotate45CCWToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem rotate90CWToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem rotate90CCWToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem upToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noneToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem forward45CWToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forward45CCWToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backward45CWToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backward45CCWToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shootToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
    }
}