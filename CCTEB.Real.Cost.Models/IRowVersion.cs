using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCTEB.Real.Cost.Models
{
    public interface IRowVersion
    {
        int RowVersion { get; set; }
    }
}
