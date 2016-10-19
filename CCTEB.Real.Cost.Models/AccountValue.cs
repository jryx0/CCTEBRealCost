using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCTEB.Real.Cost.Models
{
    public class AccountValue
    {
        public int Id { set; get; }

        public float RelativeArea { set; get; } //相对面积
        public float ChargeStandard { set; get; } //取费标准
        public float TotalCost { set; get; } //成本总额


        public float CostOfUnitForSaleArea { set; get; }//单位成本（可售面积）
        public float CostOfUnitForTotalArea { set; get; }  //单位成本（总建面）

        public float CostRatio { set; get; }//成本占比

        public String Spec { set; get; } //测算说明
    }
}
