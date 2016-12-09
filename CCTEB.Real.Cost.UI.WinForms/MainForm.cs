using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CCTEB.Real.Cost.UI.WinForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }              

        private void button3_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            new BaseItem.BaseItemSetting().ShowDialog();
            this.Cursor = Cursors.Arrow;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            new Accounts.AccountsMgr().ShowDialog();
            this.Cursor = Cursors.Arrow;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var db = new  Repository.SqliteDbContext())
            {
                Models.Accounts Root = new Models.Accounts();

                Root.AccountName = "成本科目清单";
                Root.AccountLevel = 0;
                Root.Level = 0;
                Root.Name = "根节点";
                Root.Order = 0;

                Root.Child = new List<Models.Tree>();
                Models.ExpenseAccounts ea = new Models.ExpenseAccounts();
                ea.Name = "费用1";
                ea.PricingComent = "输入收费说明";
                ea.Level = 1;                 
                ea.Order = 0;
                Root.Child.Add(ea);

                ea.Child = new List<Models.Tree>();
                Models.Accounts ac = new Models.Accounts();
                ac.Name = "费用1-科目1";
                ac.AccountName = "科目";
                ac.Level = 2;
                ac.Order = 0;
                ea.Child.Add(ac);

                var _account = db.Set<Models.Accounts>();
                _account.Add(Root);

                db.SaveChanges();
            }
        }
    }
}
