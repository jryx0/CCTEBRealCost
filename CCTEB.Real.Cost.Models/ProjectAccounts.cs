using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCTEB.Real.Cost.Models
{
    public class ProjectAccounts : IRowVersion 
    {
        public int ID { set; get; }

        public Tree Account { set; get; }        
        public AccountValue EstimatedCost { set; get; }
        public AccountValue ActualCost { set; get; }

        public int RowVersion { get; set; }
    }
}
