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
    public partial class AccountEdit : Form
    {
        public delegate void ExitHandler(object sender, System.EventArgs e);
        public event ExitHandler exitHander;
 
        public AccountEdit()
        {
            InitializeComponent();            
        }

        protected override void OnLoad(EventArgs e)
        {
            InitControl();
            base.OnLoad(e);
        }

        private void button2_Click(object sender, EventArgs e)
        {            
            exitHander?.Invoke(this, e);
        }

        public void InitControl ()
        {
            using (Services.BaseTypeServices bts = new Services.BaseTypeServices())
            {
                var bi = bts.QueryByWithDescendants(x => x.Enable && (x.BaseTypeName == "公司部门" ||  x.BaseTypeName == "政府部门" || x.BaseTypeName == "科目类型"));

                //责任部门
                var com = bi.Where(x => x.BaseTypeName == "公司部门").FirstOrDefault();
                cmbResponsibleBy.DataSource = com?.HaveItem.Where(x => x.Enable).OrderBy(x => x.ItemOrder).ToList();
                cmbResponsibleBy.ValueMember = "Id";
                cmbResponsibleBy.DisplayMember = "ItemName";

                if (com != null)
                {
                    //协助部门
                    //checkcombobox
                    cmbAssistBy.DisplayMember = "NameConcatenated";
                    cmbAssistBy.ValueMember = "Selected";
                    cmbAssistBy.DisplayMemberSingleItem = "Name";
                    cmbAssistBy.DataBindings.DefaultDataSourceUpdateMode
                            = DataSourceUpdateMode.OnPropertyChanged;
                    //DropdownList 数据源放在后面
                    cmbAssistBy.DataSource = new PresentationControls.ListSelectionWrapper<Models.TypeItem>(com?.HaveItem, "ItemName");

                    //.Where(x => x.Enable).OrderBy(x => x.ItemOrder)
                }

                //政府部门
                com = bi.Where(x => x.BaseTypeName == "政府部门").FirstOrDefault();
                cmbChargeBy.DataSource = com?.HaveItem.Where(x => x.Enable).OrderBy(x => x.ItemOrder).ToList();
                cmbChargeBy.ValueMember = "Id";
                cmbChargeBy.DisplayMember = "ItemName";
                
                //类型
                com = bi.Where(x => x.BaseTypeName == "科目类型").FirstOrDefault();
                cmbAccType.DataSource = com?.HaveItem.Where(x => x.Enable).OrderBy(x => x.ItemOrder).ToList();
                cmbAccType.ValueMember = "Id";
                cmbAccType.DisplayMember = "ItemName";
            } 
        }

        public void InitData(object sender, EventArgs e)
        {
            var d = (EventData)e;

            if (d.showType != this.GetType())
                return;

            var acc = (Models.Accounts)d.para;

            tbAccountName.Text = acc.Name;
            tbAccID.Text = acc.AccountId;
            tbAccLevel.Text = acc.Level.ToString();

            if (acc.ResponsibleBy != null)
                cmbResponsibleBy.Text = acc.ResponsibleBy.Department.ItemName;

            if (acc.AssistBy !=null && acc.AssistBy.Count != 0)
                acc.AssistBy.ForEach(x => cmbAssistBy.Text += x.Department.ItemName);
            else cmbAssistBy.Text = "";

            if (acc.ResponsibleBy == null)
                cmbResponsibleBy.SelectedIndex = -1;
            else cmbResponsibleBy.Text = acc.ResponsibleBy.Department.ItemName;



            if (d.para.GetType() == typeof(Models.Accounts))
            {
                cmbAccType.SelectedIndex = 0;

                lbChargingDept.Visible = false;
                tbPricingComent.Visible = false;
                cmbChargeBy.Visible = false;
                lbChargingComment.Visible = false;
            }
            else
            {
                cmbAccType.SelectedIndex = 1;

                var chargingby = ((Models.ExpenseAccounts)acc).ChargingBy;
                if (chargingby == null)
                    cmbChargeBy.SelectedIndex = -1;
                else cmbChargeBy.Text = chargingby.Department.ItemName;

                lbChargingDept.Visible = true;
                tbPricingComent.Visible = true;
                cmbChargeBy.Visible = true;
                lbChargingComment.Visible = true;
            }
        }

        private void cmbResponseBy_Click(object sender, EventArgs e)
        {           
            if (!((ComboBox)sender).Focused)
                ((ComboBox)sender).Focus();
        }

        private void cmbAccType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var com = (ComboBox)sender;

            if(String.Equals(com.Text, "成本"))
            {
                lbChargingDept.Visible = false;
                tbPricingComent.Visible = false;
                cmbChargeBy.Visible = false;
                lbChargingComment.Visible = false;
            }
            else
            {
                lbChargingDept.Visible = true;
                tbPricingComent.Visible = true;
                cmbChargeBy.Visible = true;
                lbChargingComment.Visible = true;
            }

        }
    }
}
