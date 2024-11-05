namespace NetWorkSniffer
{
    partial class Form2
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.aNDSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aNDNotSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oRSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oRNotSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportAsTXTFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportAsExcelFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportAsPcapFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopScanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(1569, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 58);
            this.button1.TabIndex = 1;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip2;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Location = new System.Drawing.Point(46, 103);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.Size = new System.Drawing.Size(1650, 400);
            this.dataGridView1.TabIndex = 3;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectedToolStripMenuItem,
            this.notSelectedToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(192, 64);
            // 
            // selectedToolStripMenuItem
            // 
            this.selectedToolStripMenuItem.Name = "selectedToolStripMenuItem";
            this.selectedToolStripMenuItem.Size = new System.Drawing.Size(191, 30);
            this.selectedToolStripMenuItem.Text = "Selected";
            this.selectedToolStripMenuItem.Click += new System.EventHandler(this.selectedToolStripMenuItem_Click);
            // 
            // notSelectedToolStripMenuItem
            // 
            this.notSelectedToolStripMenuItem.Name = "notSelectedToolStripMenuItem";
            this.notSelectedToolStripMenuItem.Size = new System.Drawing.Size(191, 30);
            this.notSelectedToolStripMenuItem.Text = "Not Selected";
            this.notSelectedToolStripMenuItem.Click += new System.EventHandler(this.notSelectedToolStripMenuItem_Click);
            // 
            // treeView1
            // 
            this.treeView1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView1.Location = new System.Drawing.Point(46, 545);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(889, 340);
            this.treeView1.TabIndex = 4;
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 24;
            this.listBox1.Location = new System.Drawing.Point(941, 545);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(755, 340);
            this.listBox1.TabIndex = 5;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aNDSelectedToolStripMenuItem,
            this.aNDNotSelectedToolStripMenuItem,
            this.oRSelectedToolStripMenuItem,
            this.oRNotSelectedToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(233, 124);
            // 
            // aNDSelectedToolStripMenuItem
            // 
            this.aNDSelectedToolStripMenuItem.Name = "aNDSelectedToolStripMenuItem";
            this.aNDSelectedToolStripMenuItem.Size = new System.Drawing.Size(232, 30);
            this.aNDSelectedToolStripMenuItem.Text = "AND selected";
            this.aNDSelectedToolStripMenuItem.Click += new System.EventHandler(this.aNDSelectedToolStripMenuItem_Click);
            // 
            // aNDNotSelectedToolStripMenuItem
            // 
            this.aNDNotSelectedToolStripMenuItem.Name = "aNDNotSelectedToolStripMenuItem";
            this.aNDNotSelectedToolStripMenuItem.Size = new System.Drawing.Size(232, 30);
            this.aNDNotSelectedToolStripMenuItem.Text = "AND not selected";
            this.aNDNotSelectedToolStripMenuItem.Click += new System.EventHandler(this.aNDNotSelectedToolStripMenuItem_Click);
            // 
            // oRSelectedToolStripMenuItem
            // 
            this.oRSelectedToolStripMenuItem.Name = "oRSelectedToolStripMenuItem";
            this.oRSelectedToolStripMenuItem.Size = new System.Drawing.Size(232, 30);
            this.oRSelectedToolStripMenuItem.Text = "OR selected";
            this.oRSelectedToolStripMenuItem.Click += new System.EventHandler(this.oRSelectedToolStripMenuItem_Click);
            // 
            // oRNotSelectedToolStripMenuItem
            // 
            this.oRNotSelectedToolStripMenuItem.Name = "oRNotSelectedToolStripMenuItem";
            this.oRNotSelectedToolStripMenuItem.Size = new System.Drawing.Size(232, 30);
            this.oRNotSelectedToolStripMenuItem.Text = "OR not selected";
            this.oRNotSelectedToolStripMenuItem.Click += new System.EventHandler(this.oRNotSelectedToolStripMenuItem_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(46, 42);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1359, 35);
            this.textBox1.TabIndex = 8;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.stopScanToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1773, 32);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(74, 28);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportAsTXTFileToolStripMenuItem,
            this.exportAsExcelFileToolStripMenuItem,
            this.exportAsPcapFileToolStripMenuItem});
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
            // exportAsPcapFileToolStripMenuItem
            // 
            this.exportAsPcapFileToolStripMenuItem.Name = "exportAsPcapFileToolStripMenuItem";
            this.exportAsPcapFileToolStripMenuItem.Size = new System.Drawing.Size(272, 34);
            this.exportAsPcapFileToolStripMenuItem.Text = "Export as Pcap File";
            this.exportAsPcapFileToolStripMenuItem.Click += new System.EventHandler(this.exportAsPcapFileToolStripMenuItem_Click);
            // 
            // stopScanToolStripMenuItem
            // 
            this.stopScanToolStripMenuItem.Name = "stopScanToolStripMenuItem";
            this.stopScanToolStripMenuItem.Size = new System.Drawing.Size(136, 28);
            this.stopScanToolStripMenuItem.Text = "StopMonitor";
            this.stopScanToolStripMenuItem.Click += new System.EventHandler(this.stopScanToolStripMenuItem_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1773, 916);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aNDSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aNDNotSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oRSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oRNotSelectedToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem selectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notSelectedToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportAsTXTFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportAsExcelFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportAsPcapFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopScanToolStripMenuItem;
    }
}