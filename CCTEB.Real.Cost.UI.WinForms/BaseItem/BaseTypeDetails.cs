using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CCTEB.Real.Cost.UI.WinForms.BaseItem
{
    public partial class BaseTypeDetails : Form
    {
        public Models.BaseType basetype {get;set;}
         
        public BaseTypeDetails()
        {
            InitializeComponent();

            basetype = new Models.BaseType();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            basetype.BaseTypeName = tbName.Text;


            int order = 0;
            int.TryParse(tbOrder.Text, out order);
            basetype.TypeOrder = order;

            basetype.Comment = tbComment.Text;

            basetype.Enable = cbStatus.SelectedIndex == 0 ? true : false;

            this.DialogResult = DialogResult.OK;
        }
    }
}
