namespace NetWorkSniffer
{
    partial class Form3
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportAsTXTFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportAsExcelFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopMonitorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(51, 114);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.Size = new System.Drawing.Size(1561, 591);
            this.dataGridView1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToolStripMenuItem,
            this.stopMonitorToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1774, 32);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportAsTXTFileToolStripMenuItem,
            this.exportAsExcelFileToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(82, 28);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // exportAsTXTFileToolStripMenuItem
            // 
            this.exportAsTXTFileToolStripMenuItem.Name = "exportAsTXTFileToolStripMenuItem";
            this.exportAsTXTFileToolStripMenuItem.Size = new System.Drawing.Size(272, 34);
            this.exportAsTXTFileToolStripMenuItem.Text = "Export as TXT File";
            this.exportAsTXTFileToolStripMenuItem.Click += new System.EventHandler(this.exportAsTXTFileToolStripMenuItem_Click);
            // 
            // exportAsExcelFileToolStripMenuItem
            // 
            this.exportAsExcelFileToolStripMenuItem.Name = "exportAsExcelFileToolStripMenuItem";
            this.exportAsExcelFileToolStripMenuItem.Size = new System.Drawing.Size(272, 34);
            this.exportAsExcelFileToolStripMenuItem.Text = "Export as Excel File";
            this.exportAsExcelFileToolStripMenuItem.Click += new System.EventHandler(this.exportAsExcelFileToolStripMenuItem_Click);
            // 
            // stopMonitorToolStripMenuItem
            // 
            this.stopMonitorToolStripMenuItem.Name = "stopMonitorToolStripMenuItem";
            this.stopMonitorToolStripMenuItem.Size = new System.Drawing.Size(136, 28);
            this.stopMonitorToolStripMenuItem.Text = "StopMonitor";
            this.stopMonitorToolStripMenuItem.Click += new System.EventHandler(this.stopMonitorToolStripMenuItem_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1774, 761);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportAsTXTFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportAsExcelFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopMonitorToolStripMenuItem;
    }
}