using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CCTEB.Real.Cost.Tools
{
    public class DataGridViewTools
    {
        //公共删除方法
        public static void DelGridData(DataGridView dg)
        {
            foreach (DataGridViewRow r in dg.SelectedRows)
            {
                dg.Rows.Remove(r);
            }
        }

        //公共保存方法
        public static void SavaGridData(DataGridView dg)
        {
            DataTable cdt = ((DataTable)(dg.DataSource)).GetChanges();///dt 就是datagridview.datasouce

            if (cdt == null)
                return;

            foreach ( DataGridViewRow r in cdt.Rows)
            { 
                if (cdt.Rows[r.Index].RowState == DataRowState.Deleted)
                {
                     
                }
                else if (cdt.Rows[r.Index].RowState == DataRowState.Modified)
                {

                }
                else if (cdt.Rows[r.Index].RowState == DataRowState.Added)
                {

                } 
            }

            ((DataTable)(dg.DataSource)).AcceptChanges();
        }
    }
}
