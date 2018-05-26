namespace FireSafety
{
    partial class OpenMapForm
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
            this.dgvMaps = new System.Windows.Forms.DataGridView();
            this.dgvtbcNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvtbcGuid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnOpenMap = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaps)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMaps
            // 
            this.dgvMaps.AllowUserToAddRows = false;
            this.dgvMaps.AllowUserToDeleteRows = false;
            this.dgvMaps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMaps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaps.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvtbcNumber,
            this.dgvtbcGuid});
            this.dgvMaps.Location = new System.Drawing.Point(12, 12);
            this.dgvMaps.MultiSelect = false;
            this.dgvMaps.Name = "dgvMaps";
            this.dgvMaps.ReadOnly = true;
            this.dgvMaps.RowHeadersVisible = false;
            this.dgvMaps.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMaps.ShowCellErrors = false;
            this.dgvMaps.ShowCellToolTips = false;
            this.dgvMaps.ShowEditingIcon = false;
            this.dgvMaps.ShowRowErrors = false;
            this.dgvMaps.Size = new System.Drawing.Size(260, 209);
            this.dgvMaps.TabIndex = 0;
            this.dgvMaps.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvMaps_CellMouseDoubleClick);
            // 
            // dgvtbcNumber
            // 
            this.dgvtbcNumber.HeaderText = "Number";
            this.dgvtbcNumber.Name = "dgvtbcNumber";
            this.dgvtbcNumber.ReadOnly = true;
            // 
            // dgvtbcGuid
            // 
            this.dgvtbcGuid.HeaderText = "Guid";
            this.dgvtbcGuid.Name = "dgvtbcGuid";
            this.dgvtbcGuid.ReadOnly = true;
            // 
            // btnOpenMap
            // 
            this.btnOpenMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenMap.Location = new System.Drawing.Point(197, 227);
            this.btnOpenMap.Name = "btnOpenMap";
            this.btnOpenMap.Size = new System.Drawing.Size(75, 23);
            this.btnOpenMap.TabIndex = 1;
            this.btnOpenMap.Text = "Open map";
            this.btnOpenMap.UseVisualStyleBackColor = true;
            this.btnOpenMap.Click += new System.EventHandler(this.btnOpenMap_Click);
            // 
            // OpenMapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnOpenMap);
            this.Controls.Add(this.dgvMaps);
            this.Name = "OpenMapForm";
            this.Text = "Открыть карту";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaps)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMaps;
        private System.Windows.Forms.Button btnOpenMap;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtbcNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtbcGuid;
    }
}