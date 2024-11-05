namespace NetWorkSniffer
{
    partial class Form4
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.aNDSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aNDNotSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oRSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oRNotSellectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportAsTXTFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportAsExcelFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportAsPcapFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip2;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(33, 131);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.Size = new System.Drawing.Size(1439, 419);
            this.dataGridView1.TabIndex = 0;
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
            this.treeView1.Location = new System.Drawing.Point(34, 556);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(716, 340);
            this.treeView1.TabIndex = 1;
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 24;
            this.listBox1.Location = new System.Drawing.Point(756, 556);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(716, 340);
            this.listBox1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(1324, 49);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 51);
            this.button1.TabIndex = 3;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.ForeColor = System.Drawing.Color.Black;
            this.textBox1.Location = new System.Drawing.Point(34, 59);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1271, 35);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aNDSelectedToolStripMenuItem,
            this.aNDNotSelectedToolStripMenuItem,
            this.oRSelectedToolStripMenuItem,
            this.oRNotSellectedToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowCheckMargin = true;
            this.contextMenuStrip1.ShowImageMargin = false;
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
            // oRNotSellectedToolStripMenuItem
            // 
            this.oRNotSellectedToolStripMenuItem.Name = "oRNotSellectedToolStripMenuItem";
            this.oRNotSellectedToolStripMenuItem.Size = new System.Drawing.Size(232, 30);
            this.oRNotSellectedToolStripMenuItem.Text = "OR not sellected";
            this.oRNotSellectedToolStripMenuItem.Click += new System.EventHandler(this.oRNotSellectedToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1514, 32);
            this.menuStrip1.TabIndex = 7;
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
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1514, 920);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.dataGridView1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form4";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aNDSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aNDNotSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oRSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oRNotSellectedToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem selectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notSelectedToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportAsTXTFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportAsExcelFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportAsPcapFileToolStripMenuItem;
    }
}