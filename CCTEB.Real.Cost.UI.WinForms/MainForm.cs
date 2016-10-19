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

        private void button1_Click(object sender, EventArgs e)
        {

            using (var db = new Repository.SqliteDbContext())
            {

                var basetype = db.Set<Models.BaseType>();

                basetype.Add(new Models.BaseType { BaseTypeName="test", CreateDate = System.DateTime.Now });

                var flag = db.SaveChanges();

                MessageBox.Show("the flag is :" + flag.ToString());

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ////创建数据库
            using (var db = new Repository.SqliteDbContext())
            {
               // db.Database.EnsureDeleted();

               // bool flag = db.Database.EnsureCreated();
               // MessageBox.Show(flag.ToString());                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            new BaseItem.BaseItemSetting().ShowDialog();
            this.Cursor = Cursors.Arrow;
        }
    }
}
