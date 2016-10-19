using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCTEB.Real.Cost.Models
{
    
    public class Projects
    {
        public int Id { set; get; }

        public String ProjectName { set; get; }
        public String ProjectShortName { set; get; }

        public DateTime StartTime { set; get; }
        public DateTime FinishTime { set; get; }

        public float TotalBuildingArea { set; get; }
        public float TotalAreaForSales { set; get; }
        public TypeItem ProjectType { set; get; }

        public Tree ProjectAccount { set; get; }
    }
}
