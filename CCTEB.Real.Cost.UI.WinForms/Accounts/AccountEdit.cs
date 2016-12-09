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

        public delegate void ModifytHandler(object sender, object e);
        public event ModifytHandler modifyHander;

        public event EventHandler saveHander;

        private Models.Accounts _currentAccount;
        private bool isfinshInitdata;


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
            this.Cursor = Cursors.WaitCursor;
            using (Services.BaseTypeServices bts = new Services.BaseTypeServices())
            {
              //  var bi = bts.QueryByWithDescendants(x => x.Enable && (x.BaseTypeName == "公司部门" ||  x.BaseTypeName == "政府部门" || x.BaseTypeName == "科目类型"));

                //责任部门
                var com = bts.Department;//bi.Where(x => x.BaseTypeName == "公司部门").FirstOrDefault();
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

                //收费单位
                com = bts.ChargeBy;// bi.Where(x => x.BaseTypeName == "收费单位").FirstOrDefault();
                cmbChargeBy.DataSource = com?.HaveItem.Where(x => x.Enable).OrderBy(x => x.ItemOrder).ToList();
                cmbChargeBy.ValueMember = "Id";
                cmbChargeBy.DisplayMember = "ItemName";
                
             
            }
            this.Cursor = Cursors.Arrow;
        }

        public void InitData(object sender, EventArgs e)
        {//d.para 不能为空

            isfinshInitdata = true;

            var d = (EventData)e;
            var acc = (Models.Accounts)d.para;
            if (acc == null)
            {
                Clear();
                isfinshInitdata = false;
                return;
            }

            _currentAccount = acc;
            if (d.showType != this.GetType()) return;

            tbAccountName.Text = acc.Name;
            tbAccID.Text = acc.AccountId;
            tbAccLevel.Text = acc.Level.ToString();

            tbFinanceID.Text = acc.FinanceAccountId?.ToString();
            tbFinanceLevel.Text = acc.FinanceLevel.ToString();
            tbFinanceName.Text = acc.FinanceName;

            tbCommet.Text = acc.Comment;
            tbLabel.Text = acc.Label;

            lbAccID.Text = "科目编码";
            lbAccName.Text = "科目名称";
            lbLevel.Text = "科目级别";

            //初始化，  ResposibleByID 不存在显示为空
            cmbResponsibleBy.SelectedValue = acc.ResposibleByID;

            //清空cmbAssistby
            cmbAssistBy.CheckBoxItems.ForEach(x => x.Checked = false);
            if (acc.AssistBy != null && acc.AssistBy.Count != 0)
                acc.AssistBy.ForEach(x =>
                    {
                        foreach (var c in cmbAssistBy.CheckBoxItems)
                        {
                            var items = ((PresentationControls.ObjectSelectionWrapper<Models.TypeItem>)(c.ComboBoxItem));
                            if (items.Item.Id == x.DeptID)
                            {
                                c.Checked = true;
                                break;
                            }
                        }
                    }
                );
           

      

            if (d.para.GetType() == typeof(Models.Accounts))
            {        

                lbChargingDept.Visible = false;
                tbPricingComent.Visible = false;
                cmbChargeBy.Visible = false;
                lbChargingComment.Visible = false;
                cbIsCharging.Visible = false;
            }
            else
            {
                var a = (Models.ExpenseAccounts)acc;

                cbIsCharging.Checked = a.IsCharged == 1 ? true : false;

              
                cmbChargeBy.SelectedValue = a.ChargingByID;

                tbPricingComent.Text = a.PricingComent;

                lbChargingDept.Visible = true;
                tbPricingComent.Visible = true;
                cmbChargeBy.Visible = true;
                lbChargingComment.Visible = true;
                cbIsCharging.Visible = true;

                lbAccID.Text = "费用编码";
                lbAccName.Text = "费用名称";
                lbLevel.Text = "费用级别";
            }

            isfinshInitdata = false;
        }

        public void DataChanged(object sender, EventArgs e)
        {
            if (!isfinshInitdata && _currentAccount != null)
                if (_currentAccount.ModifyStauts == 0)
                    _currentAccount.ModifyStauts = 1; //1 for modify
        }

        public Models.Tree GetData()
        {//更新node

            if (_currentAccount == null) return null; 

            using (var bts = new Services.BaseTypeServices())
            {
                int i = 0;
                int.TryParse(tbAccLevel.Text, out i);
                _currentAccount.AccountLevel = i;
                _currentAccount.Name = tbAccountName.Text;
                _currentAccount.AccountId = tbAccID.Text;

                int.TryParse(tbFinanceLevel.Text, out i);
                _currentAccount.FinanceLevel = i;
                _currentAccount.FinanceAccountId = tbFinanceID.Text;
                _currentAccount.FinanceName = tbFinanceName.Text;

                _currentAccount.Comment = tbCommet.Text;
                _currentAccount.Label = tbLabel.Text;

                if (cmbResponsibleBy.SelectedIndex != -1)
                {
                    _currentAccount.ResposibleByID = (int)cmbResponsibleBy.SelectedValue;

                    //using (Services.TypeItemServices tis = new Services.TypeItemServices())
                    //{
                    //    var ds = tis.Query().Find(cmbResponsibleBy.SelectedValue);

                    //    //_currentAccount.ResponsibleBy = ds;
                    //    //var ds = tis.Query();
                    //    //var itementity = ds.Attach((Models.TypeItem)(cmbResponsibleBy.SelectedItem));

                    //    //_currentAccount.ResponsibleBy = itementity?.Entity;
                    //}
                }

                if (_currentAccount.AssistBy == null)
                            _currentAccount.AssistBy = new List<Models.AccountDepartment>();
                        else _currentAccount.AssistBy.Clear();

                foreach (var c in cmbAssistBy.CheckBoxItems)
                {//checkbox
                    if (c.Checked)
                    {
                        var items = (PresentationControls.ObjectSelectionWrapper<Models.TypeItem>)(c.ComboBoxItem);

                        if (items == null || items.Item == null) continue;
                        
                        var ad = new Models.AccountDepartment();
                        ad.Account = _currentAccount;
                        ad.AccountID = _currentAccount.Id;

                        ad.DeptID = items.Item.Id;
                        
                        _currentAccount.AssistBy.Add(ad);                        
                    }
                }

                if (_currentAccount.GetType() == typeof(Models.ExpenseAccounts))
                {//费用
                    if (cmbChargeBy.SelectedIndex != -1)
                    {
                        ((Models.ExpenseAccounts)_currentAccount).ChargingByID = ((Models.TypeItem)(cmbChargeBy.SelectedItem)).Id;

                        ////if (((Models.ExpenseAccounts)_currentAccount).ChargingBy == null)
                        ////    ((Models.ExpenseAccounts)_currentAccount).ChargingBy = new Models.AccountDepartment();

                        //((Models.ExpenseAccounts)_currentAccount).ChargingBy = (Models.TypeItem)(cmbChargeBy.SelectedItem) ;
                        //// ((Models.ExpenseAccounts)_currentAccount).ChargingBy.Account = _currentAccount;
                        ((Models.ExpenseAccounts)_currentAccount).PricingComent = tbPricingComent.Text;
                        ((Models.ExpenseAccounts)_currentAccount).IsCharged = cbIsCharging.Checked == true ? 1 : 0;
                    }
                }
            }

            return _currentAccount;
        }

        public void Clear()
        {
            tbAccountName.Text = "";
            tbAccID.Text = "";
            tbAccLevel.Text = "";
            tbCommet.Text = "";
            tbPricingComent.Text = "";
            tbLabel.Text = "";

            cmbResponsibleBy.SelectedIndex = -1;
            //cmbAccType.SelectedIndex = -1;
            cmbChargeBy.SelectedIndex = -1;
            cmbAssistBy.SelectedIndex = -1;
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

        private void button1_Click(object sender, EventArgs e)
        {
            saveHander?.Invoke(this, e);
        }

        private void AccountValue_Changed(object sender, EventArgs e)
        {

            DataChanged(sender, e);

            //if (!isfinshInitdata && _currentAccount != null)
            //    if(_currentAccount.ModifyStauts == 0)
            //        _currentAccount.ModifyStauts = 1; //1 for modify
        }

        private void AccountValue_NameChanged(object sender, EventArgs e)
        {
            AccountValue_Changed(sender, e);
            if (!isfinshInitdata)
                modifyHander?.Invoke(this, tbAccountName.Text);
        }
    }
}
