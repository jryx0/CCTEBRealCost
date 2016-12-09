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
        public virtual List<Tree> Child { set; get; }

        public int Order { set; get; }
        public int Level { set; get; }

        public int RowVersion { get; set; }


        /// <summary>
        /// 0: Value not Changed;
        /// 1: Modify value;
        /// 2: New Node;
        /// 3: Delete Node
        /// </summary>
        public int ModifyStauts;

        /// <summary>
        /// Copy node value and not change the node relation(the Id ,Parent and child are not change).
        /// </summary>
        /// <param name="t">Value to copy</param>
        public virtual void CopyNodeValue(Tree t)
        {
            if (t == null) return;

            this.Name = t.Name;
            this.Order = t.Order;
            this.Level = t.Level;
            
        }
    }
}
