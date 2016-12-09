using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CCTEB.Real.Cost.UI.WinForms.Accounts
{
    public partial class AccountsMgr : Form
    {
        private AccountEdit _accEditCtrl;
        private AccountList _accListCtrl;

        private ShowMode _currentMode = ShowMode.DetailMode;
        public event EventHandler SendMsgEvent;
        public event EventHandler NotifyChange;

        private List<Models.Tree> ModifyAccount = new List<Models.Tree>();

        #region Init and Form
        public AccountsMgr()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            BuidAccountsTreeView();
            treeView1.NodeMouseClick += treeView1_NodeMouseClick;
            this.Cursor = Cursors.Arrow;
            base.OnLoad(e);
        }

        private void InsertAccountDetails()
        {//嵌入窗体
            if (_accEditCtrl == null)
            {   //第一次嵌入                
                _accEditCtrl = new AccountEdit();
                _accEditCtrl.FormBorderStyle = FormBorderStyle.None;
                _accEditCtrl.TopLevel = false;
                _accEditCtrl.Dock = DockStyle.Fill;
                _accEditCtrl.Visible = true;

                //处理退出事件
                _accEditCtrl.exitHander += close;
                //处理保存事件
                _accEditCtrl.saveHander += SaveChanges;

                _accEditCtrl.modifyHander += _accEditCtrl_modifyHander;

                SendMsgEvent += new EventHandler(_accEditCtrl.InitData);

                NotifyChange += new EventHandler(_accEditCtrl.DataChanged);
            }
          

            splitContainer1.Panel2.Controls.Add(_accEditCtrl);

        }

        private void InsertAccountList()
        {//嵌入窗体            
            if (_accListCtrl == null)
            {//第一次嵌入
                _accListCtrl = new AccountList();
                _accListCtrl.FormBorderStyle = FormBorderStyle.None;
                _accListCtrl.TopLevel = false;
                _accListCtrl.Dock = DockStyle.Fill;
                _accListCtrl.Visible = true;

                //处理退出事件
                _accListCtrl.exitHander += close;
                //处理保存时间
                _accListCtrl.saveHander += SaveChanges;
                SendMsgEvent += new EventHandler(_accListCtrl.InitData);
            }

            splitContainer1.Panel2.Controls.Add(_accListCtrl);

        }

        private void close(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void SwitchControl(TreeNode node)
        {
            EventData d = new EventData();

            if (_currentMode == ShowMode.DetailMode)
            {  //Show Detail
                var index = splitContainer1.Panel2.Controls.GetChildIndex(_accEditCtrl, false);
                if (index == -1)
                {
                    splitContainer1.Panel2.Controls.Remove(_accListCtrl); //Remove gridview if exist
                    InsertAccountDetails();
                }

                GetAccountData(_accEditCtrl?.GetData());

                d.para = node.Tag;
                d.showType = _accEditCtrl.GetType();
                SendMsgEvent(this, d);
            }
            else
            {//Show gridview 
                var index = splitContainer1.Panel2.Controls.GetChildIndex(_accListCtrl, false);
                if (index == -1)
                {
                    splitContainer1.Panel2.Controls.Remove(_accEditCtrl);
                    InsertAccountList();
                }
                d.showType = _accListCtrl.GetType();
                SendMsgEvent(this, d);
            }
        }


        #endregion


        private void SaveChanges(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(AccountEdit))
            {                
                GetAccountData(_accEditCtrl?.GetData());
                if (ModifyAccount.Count == 0)
                    return;

                using (var abs = new Services.AccountServices())
                {
                    var bt = abs.Query();

                    foreach(var a in ModifyAccount)
                    {
                        switch (a.ModifyStauts)
                        {
                            case 1:// modify   
                                var acc = abs.QueryBy(x => x.Id == a.Id).FirstOrDefault();
                                if (acc != null)
                                {
                                    // acc.AssistBy?.Clear();

                                    //var changedacc = bt.Attach(acc);

                                    //changedacc.Entity.AssistBy.Clear();
                                    //changedacc.Entity.CopyNodeValue(a);

                                    //acc.AssistBy.Clear();
                                    acc.CopyNodeValue(a);
                                }
                                break;
                            case 2://new
                                if(a.Parent != null)
                                {
                                    var pEntity = bt.Where(x => x.Id == a.Parent.Id).FirstOrDefault();

                                    var p = bt.Attach(pEntity);
                                    if (p.Entity.Child == null)
                                        p.Entity.Child = new List<Models.Tree>();
                                    p.Entity.Child.Add(a);
                                }
                                else
                                    bt.Add((Models.Accounts)a);
                                break;
                            case 3://delete
                                var delacc = abs.QueryByWithDescendants(x => x.Id == a.Id).FirstOrDefault();
                                // DeleteData(bt, delacc);

                                if (delacc != null)
                                {
                                    bt.Attach(delacc);
                                    bt.Remove(delacc);
                                }
                                break;
                        }

                        a.ModifyStauts = 0;
                    }
                    
                    ModifyAccount.Clear();
                    abs.SaveChanges();
                }
            }
            else MessageBox.Show("Save List");
        }
        private void DeleteData(DbSet<Models.Tree> dbset,Models.Tree t)
        {
            if (t == null)
                return;
            else
            {
                if (t.Child == null || t.Child.Count == 0)
                {
                    dbset.Attach(t);
                    dbset.Remove(t);

                   // t = null;
                }
                else foreach (var c in t.Child)
                    { 
                        DeleteData(dbset, c);
                    }
            }
        }
        private void GetAccountData(Models.Tree t)
        {
            if (t != null)
                if (t.ModifyStauts != 0) //modify,new,delete
                {
                    var val = ModifyAccount.Where(x => x.Id == t.Id).FirstOrDefault();

                    if (val == null)
                        ModifyAccount.Add(t);
                    else val = t;
                }
        }


        #region TreeView
        private void BuidAccountsTreeView()
        {
            using (Services.AccountServices abs = new Services.AccountServices())
            {
                var tree = abs.QueryByWithDescendants();
                //var tree = abs.QueryByWithDescendants(x => x.Parent == null ).ToList();

                foreach (var t in tree.ToList())
                {
                    treeView1.Nodes.Add(CreateTreeView(t));
                }
            }
        }
        private TreeNode CreateTreeView(Models.Tree _acc)
        {
            if (_acc == null)
                return null;

            TreeNode tn = new TreeNode();
            tn.Text = _acc.Name;
            tn.Tag = _acc;
            _acc.ModifyStauts = 0; 

            if (_acc.Child == null || _acc.Child.Count == 0)
                return tn;

            foreach (var a in _acc.Child)
            {
                tn.Nodes.Add(CreateTreeView(a));
            }

            return tn;
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var tn = (TreeView)sender;
            var info = tn.HitTest(e.X, e.Y);

            if (info.Location == TreeViewHitTestLocations.Label)
            {
                if (e.Button == MouseButtons.Right)
                {

                    if (e.Node.IsSelected == false)
                        tn.SelectedNode = e.Node;

                    //成本下只能创建成本
                    if (e.Node.Tag.GetType() == typeof(Models.Accounts))
                    {
                        contextMenuStrip1.Items[0].Enabled = true;
                        contextMenuStrip1.Items[1].Enabled = false;
                    }
                    else if (e.Node.Tag.GetType() == typeof(Models.ExpenseAccounts))
                    {//费用下只能创建费用
                        contextMenuStrip1.Items[0].Enabled = false;
                        contextMenuStrip1.Items[1].Enabled = true;
                    }

                    contextMenuStrip1.Items[2].Enabled = true;
                    contextMenuStrip1.Show(tn, e.X, e.Y);
                }
                else
                if (e.Button == MouseButtons.Left)
                {
                    //EventData d = new EventData();
                    //if (e.Node == null)
                    //    return;
                    //SwitchControl(e.Node);
                   //var t = (Models.Tree)e.Node.Tag;

                    //if (_currentMode == ShowMode.DetailMode)
                    //{  //Show Detail
                    //    var index = splitContainer1.Panel2.Controls.GetChildIndex(_accEditCtrl, false);
                    //    if (index == -1)
                    //    {
                    //        splitContainer1.Panel2.Controls.Remove(_accListCtrl); //Remove gridview if exist
                    //        InsertAccountDetails();
                    //    }

                    //    GetAccountData(_accEditCtrl?.GetData());

                    //    d.para = e.Node.Tag;
                    //    d.showType = _accEditCtrl.GetType();
                    //    SendMsgEvent(this, d);
                    //}
                    //else
                    //{//Show gridview 
                    //    var index = splitContainer1.Panel2.Controls.GetChildIndex(_accListCtrl, false);
                    //    if (index == -1)
                    //    {
                    //        splitContainer1.Panel2.Controls.Remove(_accEditCtrl);
                    //        InsertAccountList();
                    //    }
                    //    d.showType = _accListCtrl.GetType();
                    //    SendMsgEvent(this, d);
                    //}
                }
            }
        }

        private void treeView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var tn = (TreeView)sender;
                var info = tn.HitTest(e.X, e.Y);
                if (info.Node == null)
                {
                    contextMenuStrip1.Items[0].Enabled = true;
                    contextMenuStrip1.Items[1].Enabled = true;
                    contextMenuStrip1.Items[2].Enabled = false;
                    contextMenuStrip1.Show(tn, e.X, e.Y);
                }
            }
        }

        private void treeView1_Leave(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                ////让选中项背景色呈现红色
                //treeView1.SelectedNode.BackColor = treeView1.SelectedNode.BackColor == Color.Red ? Color.White : Color.Red;
                ////前景色为白色
                //treeView1.SelectedNode.ForeColor = treeView1.SelectedNode.ForeColor == Color.White ? Color.Black : Color.White;

                //让选中项背景色呈现红色
                treeView1.SelectedNode.BackColor = Color.Red;
                //前景色为白色
                treeView1.SelectedNode.ForeColor = Color.White;
            }

        }

        private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                //将上一个选中的节点背景色还原（原先没有颜色）
                treeView1.SelectedNode.BackColor = Color.Empty;
                //还原前景色
                treeView1.SelectedNode.ForeColor = Color.Black;
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SwitchControl(e.Node);
        }

        private void treeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            
            ((Models.Accounts)(e.Node.Tag)).AccountName = e.Label == null? "新科目" : e.Label;
            ((Models.Accounts)(e.Node.Tag)).Name = e.Label == null ? "新科目" : e.Label;

            EventData d = new EventData();
            d.para = e.Node.Tag;
            d.showType = _currentMode == ShowMode.DetailMode ? _accEditCtrl.GetType() : _accListCtrl.GetType();
            SendMsgEvent(this, d);

            NotifyChange(this, d);
        }

        private void treeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.treeView1.LabelEdit = true;
            if (this.treeView1.SelectedNode.IsEditing == false)
                this.treeView1.SelectedNode.BeginEdit();
        }
        /// <summary>
        /// syc accountname and node text
        /// </summary>
        private void _accEditCtrl_modifyHander(object sender, object e)
        {
            var node = this.treeView1.SelectedNode;
            if(node != null)
            {
                //node.Tag
                node.Text = e.ToString();
            }
        }
        #endregion

        #region Menu
        private void List_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentMode == ShowMode.DetailMode)
                _currentMode = ShowMode.ListMode;
            else if (_currentMode == ShowMode.ListMode)
                _currentMode = ShowMode.DetailMode;

            var m = (ToolStripMenuItem)sender;
            m.Checked = !m.Checked;
        }

        private void NewAccount(TreeNode node, Models.Tree t)
        {
            TreeNode tn = new TreeNode();
            tn.Text = t.Name;

            if (t.GetType() == typeof(Models.Accounts))
                tn.Tag = new Models.Accounts();//Activator.CreateInstance(t.GetType());//根据t的类型创建实例
            else tn.Tag = new Models.ExpenseAccounts();

            ((Models.Accounts)tn.Tag).ModifyStauts = 2; //new 
            ((Models.Accounts)tn.Tag).Name = t.Name;
            ((Models.Accounts)tn.Tag).AccountName = t.Name;

            if (node != null)
            {
                //add in a node
                node.Nodes.Add(tn);
                if (node.Tag != null)
                {
                    var a = (Models.Tree)node.Tag;
                    t.Level = a.Level + 1;
                }

                var parentNode = (Models.Accounts)node.Tag;
                if (parentNode.Child == null)
                    parentNode.Child = new List<Models.Tree>();
                parentNode.Child.Add((Models.Accounts)tn.Tag);

                ((Models.Accounts)tn.Tag).Parent = parentNode;

                if(parentNode.ModifyStauts != 2) //new 
                     ModifyAccount.Add((Models.Accounts)tn.Tag);
            }
            else
            {
                treeView1.Nodes.Add(tn);
                t.Level = 1;

                ModifyAccount.Add((Models.Accounts)tn.Tag);
            }

            this.treeView1.SelectedNode = tn;
            this.treeView1.LabelEdit = true;
            if (this.treeView1.SelectedNode.IsEditing == false)
                this.treeView1.SelectedNode.BeginEdit();
        }

        private void AddCost_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var m = ((ToolStripMenuItem)sender).GetCurrentParent();
            if (m != null)
            {
                var info = treeView1.HitTest(treeView1.PointToClient(m.PointToScreen(new Point(0, 0))));

                NewAccount(info.Node, new Models.Accounts {Name = "新成本科目" });
            }
        }

        private void AddExpense_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var m = ((ToolStripMenuItem)sender).GetCurrentParent();
            if (m != null)
            {
                var info = treeView1.HitTest(treeView1.PointToClient(m.PointToScreen(new Point(0, 0))));

                NewAccount(info.Node, new Models.ExpenseAccounts { Name = "新费用科目" });
                
            }
        }

        private void DelAccount_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var m = ((ToolStripMenuItem)sender).GetCurrentParent();
            if (m != null)
            {
                var info = treeView1.HitTest(treeView1.PointToClient(m.PointToScreen(new Point(0, 0))));
                treeView1.Nodes.Remove(info.Node);


                Models.Tree t = (Models.Tree)info.Node.Tag;
                t.ModifyStauts = 3; //delete
                ModifyAccount.Add(t);
            }
        }
        #endregion
    }

    internal enum ShowMode
    {
        DetailMode,
        ListMode
    }

    internal class EventData : EventArgs
    {
        public Type showType;
        public object para;
    }

}
