using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCTEB.Real.Cost.Models
{
     
    public class Accounts :Tree
    {
        public String AccountId { set; get; } //科目编码
        public int AccountName { set; get; } //科目名称
        public int AccountLevel { set; get; } //科目级别

        public String FinanceAccountId { set; get; } //财务科目编码
        public int FinanceName { set; get; } //财务科目名称
        public int FinanceLevel { set; get; } //财务科目级别

        public String Comment { set; get; } //备注
        public String Label { set; get; } //标签 ， 逗号分隔

   
        public List<AccountDepartment> ResponsibleBy { set; get; } //责任部门
        public List<AccountDepartment> AssistBy { set; get; } //协助部门

        public String Title { set; get; }


        public AccountValue CostOfPredict { set; get; }
        public AccountValue CostOfActual { set; get; }
    }

    
    public class ExpenseAccounts : Accounts
    {         
        public String PricingComent { set; get; } //收费说明，包含单价、单位等
        public List<AccountDepartment> ChargingBy { set; get; } //收费部门
        public int IsCharged { set; get; } //是否收费
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
        public Accounts Account { set; get; }        
        public TypeItem Department { set; get; }

        public DepartmentType DepType {set; get;}
    }
}
