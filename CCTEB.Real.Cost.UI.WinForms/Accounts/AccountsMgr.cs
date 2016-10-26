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

        public event EventHandler SendMsgEvent;

        public AccountsMgr()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            BuidAccountsTreeView();

            



            this.Cursor = Cursors.Arrow;
            base.OnLoad(e);
        }

        private void InsertAccountDetails()
        {
            //嵌入窗体
            _accEditCtrl = new AccountEdit();
            _accEditCtrl.FormBorderStyle = FormBorderStyle.None;
            _accEditCtrl.TopLevel = false;
            _accEditCtrl.Dock = DockStyle.Fill;
            _accEditCtrl.Visible = true;

            //处理退出事件
            _accEditCtrl.exitHander += close;
            splitContainer1.Panel2.Controls.Add(_accEditCtrl);

            SendMsgEvent += new EventHandler(_accEditCtrl.InitData);
        }
        private void InsertAccountList()
        {
            _accListCtrl = new AccountList();

            _accListCtrl.FormBorderStyle = FormBorderStyle.None;
            _accListCtrl.TopLevel = false;
            _accListCtrl.Dock = DockStyle.Fill;
            _accListCtrl.Visible = true;


            //处理退出事件
            _accListCtrl.exitHander += close;
            splitContainer1.Panel2.Controls.Add(_accListCtrl);
            SendMsgEvent += new EventHandler(_accListCtrl.InitData);
        }





        private void close(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }


        



        #region TreeView
        private void BuidAccountsTreeView()
        {
            using (Services.AccountBOCServices abs = new Services.AccountBOCServices())
            {
                var tree = abs.QueryByWithDescendants();
                // var tree = abs.QueryByWithDescendants(x => x.Parent == null ).ToList();

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

                    contextMenuStrip1.Show(tn, e.X, e.Y);
                }
                else if (e.Button == MouseButtons.Left)
                {
                    EventData d = new EventData();
                    if (e.Node == null)
                        return;

                    var t = (Models.Tree)e.Node.Tag;
                    if (t == null || t.Child == null || t.Child.Count == 0)
                    {//add  AccountEdit
                        splitContainer1.Panel2.Controls.Remove(_accListCtrl);
                        var index = splitContainer1.Panel2.Controls.GetChildIndex(_accEditCtrl, false);
                        if(index == -1)
                            InsertAccountDetails();

                        d.para = e.Node.Tag;
                        d.showType = _accEditCtrl.GetType();
                        SendMsgEvent(this, d);
                    }
                    else
                    {//delete 
                        splitContainer1.Panel2.Controls.Remove(_accEditCtrl);

                        var index = splitContainer1.Panel2.Controls.GetChildIndex(_accListCtrl, false);
                        if (index == -1)
                            InsertAccountList();

                        d.showType = _accListCtrl.GetType();
                        SendMsgEvent(this, d);
                    }
                    

                  
                }
            }
        }

        

        #endregion
    }

    internal class EventData : EventArgs
    {
        public Type showType;
        public object para;
    }

}
