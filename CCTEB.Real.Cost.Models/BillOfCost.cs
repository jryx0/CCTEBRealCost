using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCTEB.Real.Cost.Models
{
    public class Accounts : Tree
    {
        public String AccountId { set; get; } //科目编码
        public String AccountName { set; get; } //科目名称
        public int AccountLevel { set; get; } //科目级别

        public String FinanceAccountId { set; get; } //财务科目编码
        public String FinanceName { set; get; } //财务科目名称
        public int FinanceLevel { set; get; } //财务科目级别

        public String Comment { set; get; } //备注
        public String Label { set; get; } //标签 ， 逗号分隔
      
     
        public int ResposibleByID { set; get; }//责任部门 itemtype id    
        public List<AccountDepartment> AssistBy { set; get; }   
   
        public String Title { set; get; }

        public override void CopyNodeValue(Tree t)
        {
            if (t.GetType() != this.GetType()) return;

            var acc = (Accounts)t;

            this.AccountId = acc.AccountId;
            this.AccountName = acc.AccountName;
            this.AccountLevel = acc.AccountLevel;
            this.FinanceAccountId = acc.FinanceAccountId;
            this.FinanceName = acc.FinanceName;
            this.FinanceLevel = acc.FinanceLevel;

            this.Comment = acc.Comment;
            this.Label = acc.Label;

            //this.ResponsibleBy = acc.ResponsibleBy;
            this.ResposibleByID = acc.ResposibleByID;


            if (acc.AssistBy == null)
            {
                this.AssistBy?.Clear();
                this.AssistBy = null;
            }
            else
            {

                if (this.AssistBy == null)
                    this.AssistBy = new List<AccountDepartment>();
                else
                    this.AssistBy.Clear();

                this.AssistBy.AddRange(acc.AssistBy);

                //foreach (AccountDepartment ad in this.AssistBy)
                //{
                //    var asby = this.AssistBy.Find(y => y.Id == ad.Id);

                    
                //    if (asby == null)
                //    { 
                //        this.AssistBy.Add(ad);
                //    }
                //    else
                //    {
                //        asby.AccountID = ad.AccountID;
                //        asby.DeptID = ad.DeptID;
                //    }
                //}               
            }

            this.Title = acc.Title;
            base.CopyNodeValue(t);
        }
    }
        
    public class ExpenseAccounts : Accounts
    {         
        public String PricingComent { set; get; } //收费说明，包含单价、单位等
        public int ChargingByID { set; get; }
    
        public int IsCharged { set; get; } //是否收费
        public override void CopyNodeValue(Tree t)
        {
            if (t.GetType() != this.GetType()) return;

            var exp = (ExpenseAccounts)t;
            this.PricingComent = exp.PricingComent;
            //this.ChargingBy = exp.ChargingBy;

            this.ChargingByID = exp.ChargingByID;
            this.IsCharged = exp.IsCharged;

            base.CopyNodeValue(t);
        }
    }

    public enum DepartmentType
    {
        Response,
        Assist,
        Charging
    }

    public class AccountDepartment
    {
        public int Id { set; get; }

        public int AccountID { set; get; }
        public Accounts Account { set; get; }

        public int DeptID { set; get; }
      //  public TypeItem Dept { set; get; }

    }
}
