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
    public partial class AccountList : Form
    {
        public delegate void ExitHandler(object sender, System.EventArgs e);
        public event ExitHandler exitHander;

        public event EventHandler saveHander;

        public AccountList()
        {
            InitializeComponent();
        }

        public void InitData(object sender, EventArgs e)
        {
            var d = (EventData)e;
            if (d.showType != this.GetType())
                return;


            MessageBox.Show("OK");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            exitHander?.Invoke(this, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveHander?.Invoke(this, e);
        }
    }
}
