using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCTEB.Real.Cost.Models
{    
     
    public abstract class Tree : IRowVersion
    {
        public int Id { set; get; }
        public String Name { set; get; }
         
        public virtual Tree Parent { set; get; }
        public virtual List<Tree> Child{set; get;}

        public int Order { set; get; }
        public int Level { set; get; }

        public int RowVersion { get; set; }
      
    }
}
