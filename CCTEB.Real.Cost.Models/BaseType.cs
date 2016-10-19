using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCTEB.Real.Cost.Models
{
    public class BaseType :  IRowVersion 
    {
        [Key]
        public int Id { get; set; }

        [StringLength(30)]
        [Display(Name = "项目名称")]
        public string BaseTypeName { get; set; }
        public int TypeOrder { get; set; }

        [StringLength(50)]
        public string Comment { get; set; }
        public bool Enable { get; set; }

        [StringLength(30)]
        public string Creator { get; set; }
        public DateTime CreateDate { get; set; }

        [StringLength(30)]
        public string Modifier { get; set; }
        public DateTime ModifyDate
        {
            get;
            set;
        }

        public int RowVersion { get; set; }


        public virtual List<TypeItem> HaveItem { get; set; }

      //  public int Test { set; get; }
    }

    public class TypeItem :  IRowVersion  
    {
        [Key]
        public int Id { get; set; }
        public BaseType ItemParent { get; set; }

        [StringLength(30)]
        public string ItemName { get; set; }

        [StringLength(30)]
        public string ItemValue { get; set; }

        [StringLength(30)]
        public string ItemValueType { get; set; }
        public int ItemOrder { get; set; }
        public bool Enable { get; set; }

        public string Creator { get; set; }
        public DateTime CreateDate { get; set; }

        [StringLength(30)]
        public string Modifier { get; set; }
        public DateTime ModifyDate { get; set; }

        [StringLength(30)]
        public string Comment { get; set; }

        public int RowVersion { get; set; }
    }
}
