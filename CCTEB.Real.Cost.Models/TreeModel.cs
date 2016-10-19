using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCTEB.Real.Cost.Models
{    
    [Table("Root")]
    public abstract class Tree : IRowVersion
    {
        public Int64 Id { set; get; }
        public String Name { set; get; }

         
        public virtual Tree Parent { set; get; }
        public virtual ICollection<Tree> Child{set; get;}

        public int Order { set; get; }
        public int Level { set; get; }

        public int RowVersion { get; set; }
    }
}
