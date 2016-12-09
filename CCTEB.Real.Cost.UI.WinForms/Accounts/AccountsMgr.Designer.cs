namespace CCTEB.Real.Cost.UI.WinForms.Accounts
{
    partial class AccountsMgr
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddCost_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddExpense_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DelAccount_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.List_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            this.splitContainer1.Size = new System.Drawing.Size(897, 500);
            this.splitContainer1.SplitterDistance = 277;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(277, 500);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeView1_AfterLabelEdit);
            this.treeView1.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeSelect);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.Leave += new System.EventHandler(this.treeView1_Leave);
            this.treeView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseDoubleClick);
            this.treeView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseUp);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddCost_ToolStripMenuItem,
            this.AddExpense_ToolStripMenuItem,
            this.DelAccount_ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.List_ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 98);
            // 
            // AddCost_ToolStripMenuItem
            // 
            this.AddCost_ToolStripMenuItem.Name = "AddCost_ToolStripMenuItem";
            this.AddCost_ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.AddCost_ToolStripMenuItem.Text = "添加成本";
            this.AddCost_ToolStripMenuItem.Click += new System.EventHandler(this.AddCost_ToolStripMenuItem_Click);
            // 
            // AddExpense_ToolStripMenuItem
            // 
            this.AddExpense_ToolStripMenuItem.Name = "AddExpense_ToolStripMenuItem";
            this.AddExpense_ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.AddExpense_ToolStripMenuItem.Text = "添加费用";
            this.AddExpense_ToolStripMenuItem.Click += new System.EventHandler(this.AddExpense_ToolStripMenuItem_Click);
            // 
            // DelAccount_ToolStripMenuItem
            // 
            this.DelAccount_ToolStripMenuItem.Name = "DelAccount_ToolStripMenuItem";
            this.DelAccount_ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.DelAccount_ToolStripMenuItem.Text = "删除";
            this.DelAccount_ToolStripMenuItem.Click += new System.EventHandler(this.DelAccount_ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(121, 6);
            // 
            // List_ToolStripMenuItem
            // 
            this.List_ToolStripMenuItem.Name = "List_ToolStripMenuItem";
            this.List_ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.List_ToolStripMenuItem.Text = "列表模式";
            this.List_ToolStripMenuItem.Click += new System.EventHandler(this.List_ToolStripMenuItem_Click);
            // 
            // AccountsMgr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 500);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AccountsMgr";
            this.Text = "Cost&Expense Setting";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem AddCost_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddExpense_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem DelAccount_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem List_ToolStripMenuItem;
    }
}