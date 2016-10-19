
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CCTEB.Real.Cost.UI.WinForms.BaseItem
{
    public partial class BaseItemSetting : Form
    {
        private int maxtypeid = 0;
        private int maxitemid = 0;
        private Control SourceControl;

        public BaseItemSetting()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            initGridView();

            this.Cursor = Cursors.Arrow;
            base.OnLoad(e);
        }

        public void initGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;

            using (var db = new Repository.SqliteDbContext())
            {
                var _BaseTypes = db.Set<Models.BaseType>();
                var dl = from bt in _BaseTypes.ToList()
                         orderby bt.TypeOrder
                         select new
                         {
                             basetypeid = bt.Id,
                             项目名称 = bt.BaseTypeName,
                             备注 = bt.Comment,
                             顺序 = bt.TypeOrder,
                             状态 = bt.Enable,
                             创建人 = bt.Creator,
                             创建时间 = bt.CreateDate,
                             修改人 = bt.Modifier,
                             修改时间 = bt.ModifyDate
                         };

                if(dl != null && dl.Count() > 0)
                    maxtypeid = dl.Max(x => x.basetypeid);

                var il = from i in _BaseTypes.SelectMany(x => x.HaveItem).ToList()
                         orderby i.ItemOrder
                         select new
                         {
                             ItemId = i.Id,
                             ParentId = i.ItemParent.Id,
                             值名称 = i.ItemName,
                             值 = i.ItemValue,
                             值类型 = i.ItemValueType,
                             备注 = i.Comment,
                             顺序 = i.ItemOrder,
                             状态 = i.Enable,
                             创建人 = i.Creator,
                             创建时间 = i.CreateDate,
                             修改人 = i.Modifier,
                             修改时间 = i.ModifyDate
                         };

                if(il != null && il.Count() > 0)
                    maxitemid = il.Max(x => x.ItemId);

                var tblDataSet = new DataSet();
                var tblBaseType = dl.CopyToDataTable();
                tblBaseType.TableName = "BaseType";
                var tblItemType = il.CopyToDataTable();
                tblItemType.TableName = "ItemType";

                tblDataSet.Tables.Add(tblBaseType);
                tblDataSet.Tables.Add(tblItemType);

                tblDataSet.Relations.Add("BaseItemRelation",
                    tblBaseType.Columns["basetypeid"], tblItemType.Columns["ParentId"]);


                BindingSource bsBaseType = new BindingSource();
                bsBaseType.DataSource = tblDataSet;
                bsBaseType.DataMember = "BaseType";
            

                BindingSource bsItemType = new BindingSource();
                bsItemType.DataSource = bsBaseType;
                bsItemType.DataMember = "BaseItemRelation";
                

                dataGridView1.DataSource = bsBaseType;
                dataGridView1.Columns[0].Visible = false;

                dataGridView2.DataSource = bsItemType;
                dataGridView2.Columns[0].Visible = false;
                dataGridView2.Columns[1].Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var dlg = new BaseTypeDetails();

            if(dlg.ShowDialog() == DialogResult.OK)
            {
                using (var db = new Repository.SqliteDbContext())
                {
                    db.Set<Models.BaseType>().Add(dlg.basetype);
                    db.SaveChanges();
                }

                initGridView();
            }
        }

        //处理右键菜单
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var dg = (DataGridView)sender;

            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >=0)
                {
                    //若行已是选中状态就不再进行设置
                    if (dg.Rows[e.RowIndex].Selected == false)
                    {
                        dg.ClearSelection();
                        dg.Rows[e.RowIndex].Selected = true;
                    }
                    //只选中一行时设置活动单元格
                    if (dg.SelectedRows.Count == 1)
                    {
                        dg.CurrentCell = dg.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    }

                    contextMenuStrip1.Tag = dg;
                    //弹出操作菜单
                    contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
                     
                }
            }
        }
          

        //gridview1 项目删除
        private void Del_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dg = contextMenuStrip1.Tag as  DataGridView;
            if (dg == null) return;

            String WarnningString = "将删除项目和所有类型";
            if (dg.Name == "dataGridView2")
                WarnningString = "将删除类型";

            if (MessageBox.Show(WarnningString, "删除警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
                    Tools.DataGridViewTools.DelGridData(dg);
        }

        //保存按钮
        private void button3_Click(object sender, EventArgs e)
        {
            //SavaGridData(dataGridView1); 

            ChangeGridData();
        }

        //保存数据
        public void ChangeGridData( )
        {
            var ds = (DataSet)((BindingSource)(dataGridView1.DataSource)).DataSource;
            var bdt = ds.Tables["BaseType"];
            var idt = ds.Tables["ItemType"];
            var idts = ds.Relations[0];

            /**
             *  删除              修改              新增
             * 1.删除子表       1.修改子表       1.新增主表
             * 2.删除主表       2.修改主表       2.新增子表
             */
            using (var db = new Repository.SqliteDbContext())
            {
                onDataDelete(db, bdt, idt);
                onDataModify(db, bdt, idt);
                onDataAdd(db, bdt, idt, idts);
                db.SaveChanges();
            }
            ds.AcceptChanges();
        }


        private void onDataDelete(Repository.SqliteDbContext db, DataTable btDT, DataTable itDT)
        {
            //删除子表

            var itDTc = itDT.GetChanges(DataRowState.Deleted);
            if (itDTc != null)
            {
                var items = db.Set<Models.TypeItem>();
                foreach (System.Data.DataRow r in itDTc.Rows)
                {
                    int? changeid = r.Field<int>(0, DataRowVersion.Original);
                    var i = items.ToList().Find(x => x.Id == changeid);

                    items.Attach(i);
                    items.Remove(i);
                }
            }

            //删主表
            var btDTc = btDT.GetChanges(DataRowState.Deleted);
            if(btDTc != null)
            {
                var types = db.Set<Models.BaseType>();
                foreach (System.Data.DataRow r in btDTc.Rows)
                {
                    int? changeid = r.Field<int>(0, DataRowVersion.Original);
                    #region 删除
                    //删除明细
                    var _base = types.Include(b => b.HaveItem)
                                          .Where(x => x.Id == changeid)
                                          .ToList().FirstOrDefault();

                    if (_base != null && _base.HaveItem != null)
                    {
                        db.RemoveRange(_base.HaveItem);
                    }

                    if(db.ChangeTracker != null)
                    {
                        var a = db.ChangeTracker.Entries<Models.BaseType>()
                             .Where(x => x.Entity.Id == changeid).FirstOrDefault().Entity;

                        types.Attach(a);
                        types.Remove(a);
                    }
                    #endregion
                }
            }
        }

        private void onDataModify(Repository.SqliteDbContext db, DataTable btDT, DataTable itDT)
        {
            //修改子表
            var itDTc = itDT.GetChanges(DataRowState.Modified);
            if (itDTc != null)
            {
                var items = db.Set<Models.TypeItem>();
                foreach (System.Data.DataRow r in itDTc.Rows)
                {
                    int? changeid = r.Field<int>(0, DataRowVersion.Original);
                    var i = items.ToList().Find(x => x.Id == changeid);

                    var changeitem = items.Attach(i);
                    changeitem.Entity.ItemName = r.Field<String>(2);
                    changeitem.Entity.ItemValue = r.Field<String>(3);
                    changeitem.Entity.ItemValueType = r.Field<String>(4);
                    changeitem.Entity.Comment = r.Field<String>(5);
                    changeitem.Entity.ItemOrder = r.Field<int>(6);
                    changeitem.Entity.Enable = DBNull.Value.Equals(r[7]) ? false : r.Field<Boolean>(7);
                    changeitem.Entity.Modifier = r.Field<String>(10);
                    changeitem.Entity.ModifyDate = DBNull.Value.Equals(r[11]) ? System.DateTime.Now : r.Field<DateTime>(11);
                }
            }

            //修改主表
            var btDTc = btDT.GetChanges(DataRowState.Modified);
            if (btDTc != null)
            {
                var types = db.Set<Models.BaseType>();
                foreach (System.Data.DataRow r in itDTc.Rows)
                {
                    int? changeid = r.Field<int>(0, DataRowVersion.Original);
                    var i = types.ToList().Find(x => x.Id == changeid);

                    var b = db.Attach(i);
                    b.Entity.BaseTypeName = r.Field<String>(1);
                    b.Entity.Comment = r.Field<String>(2);
                    b.Entity.TypeOrder = r.Field<int>(3);
                    b.Entity.Enable = DBNull.Value.Equals(r[4]) ? false : r.Field<Boolean>(4);
                    b.Entity.Modifier = r.Field<String>(7);
                    b.Entity.ModifyDate = DBNull.Value.Equals(r[8]) ? System.DateTime.Now : r.Field<DateTime>(8);
                }
            }
        }

        private void onDataAdd(Repository.SqliteDbContext db, DataTable btDT, DataTable itDT, DataRelation drc)
        {
            //新增主表
            // var btDTc = btDT.GetChanges(DataRowState.Added);
            var btDTc = drc.ParentTable;//.GetChanges(DataRowState.Added);
            if (btDTc != null)
            {
                var types = db.Set<Models.BaseType>();
                foreach (System.Data.DataRow r in btDTc.Rows)
                {
                    if (r.RowState != DataRowState.Added) continue;

                    var newbasetype = new Models.BaseType();
                    newbasetype.BaseTypeName = r.Field<String>(1);
                    newbasetype.Comment = r.Field<String>(2);
                    newbasetype.TypeOrder = DBNull.Value.Equals(r[3]) ? 0 : r.Field<int>(3);
                    newbasetype.Enable = DBNull.Value.Equals(r[4]) ? false : r.Field<Boolean>(4);
                    newbasetype.Creator = r.Field<String>(5);
                    newbasetype.CreateDate = DBNull.Value.Equals(r[6]) ? System.DateTime.Now : r.Field<DateTime>(6);
                    newbasetype.Modifier = r.Field<String>(7);
                    newbasetype.ModifyDate = DBNull.Value.Equals(r[8]) ? System.DateTime.Now : r.Field<DateTime>(8);
                    

                    var childrows = r.GetChildRows("BaseItemRelation");
                    foreach(DataRow cr in childrows)
                    {
                        var newitem = new Models.TypeItem();
                        newitem.ItemName = cr.Field<String>(2);
                        newitem.ItemValue = cr.Field<String>(3);
                        newitem.ItemValueType = cr.Field<String>(4);
                        newitem.Comment = cr.Field<String>(5);
                        newitem.ItemOrder = DBNull.Value.Equals(cr[6]) ? 0 : cr.Field<int>(6);
                        newitem.Enable = DBNull.Value.Equals(cr[7]) ? false : cr.Field<Boolean>(7);
                        newitem.Creator = cr.Field<String>(8);
                        newitem.CreateDate = DBNull.Value.Equals(cr[9]) ? System.DateTime.Now : cr.Field<DateTime>(9);
                        newitem.Modifier = cr.Field<String>(10);
                        newitem.ModifyDate = DBNull.Value.Equals(cr[11]) ? System.DateTime.Now : cr.Field<DateTime>(11);
                        if (newbasetype.HaveItem == null)
                            newbasetype.HaveItem = new List<Models.TypeItem>();

                        newbasetype.HaveItem.Add(newitem);
                    }

                    types.Add(newbasetype);
                }
                         
            }


            //新增子表
            var itDTc = itDT.GetChanges(DataRowState.Added);
            if (itDTc != null)
            {
                var items = db.Set<Models.TypeItem>();
                foreach (System.Data.DataRow r in itDTc.Rows)
                {
                    if(DBNull.Value.Equals(r[1])) continue;

                    int basetypeid = r.Field<int>(1);
                    var b = db.Set<Models.BaseType>()
                             .Include(i => i.HaveItem)
                             .Where(x => x.Id == basetypeid)
                             .FirstOrDefault();

                    if (b != null)
                    {
                        var newitem = new Models.TypeItem();
                        newitem.ItemName = r.Field<String>(2);
                        newitem.ItemValue = r.Field<String>(3);
                        newitem.ItemValueType = r.Field<String>(4);
                        newitem.Comment = r.Field<String>(5);
                        newitem.ItemOrder = DBNull.Value.Equals(r[6]) ? 0 : r.Field<int>(6);
                        newitem.Enable = DBNull.Value.Equals(r[7]) ? false : r.Field<Boolean>(7);
                        newitem.Creator = r.Field<String>(8);
                        newitem.CreateDate = DBNull.Value.Equals(r[9]) ? System.DateTime.Now : r.Field<DateTime>(9);
                        newitem.Modifier = r.Field<String>(10);
                        newitem.ModifyDate = DBNull.Value.Equals(r[11]) ? System.DateTime.Now : r.Field<DateTime>(11);

                        b.HaveItem.Add(newitem);
                    }
                }
            }

        }

        //private void ChangeItemType(DataTable dt)
        //{            
        //    var cdt = dt.GetChanges();
        //    if (cdt == null) return;

        //    this.Cursor = Cursors.WaitCursor;
        //    using (var db = new Repository.SqliteDbContext())
        //    {
        //        var items = db.Set<Models.TypeItem>();
        //        foreach (System.Data.DataRow r in cdt.Rows)
        //        {                    
        //            if (r.RowState == DataRowState.Deleted)
        //            {
        //                int? changeid = r.Field<int>(0, DataRowVersion.Original);
        //                var i = items.ToList().Find(x => x.Id == changeid);

        //                items.Attach(i);
        //                items.Remove(i);
        //            }
        //            else if (r.RowState == DataRowState.Modified)
        //            {
        //                int? changeid = r.Field<int>(0, DataRowVersion.Original);
        //                var i = items.ToList().Find(x => x.Id == changeid);

        //                var changeitem = items.Attach(i);
        //                changeitem.Entity.ItemName = r.Field<String>(2);
        //                changeitem.Entity.ItemValue = r.Field<String>(3);                        
        //                changeitem.Entity. ItemValueType = r.Field<String>(4);
        //                changeitem.Entity.Comment = r.Field<String>(5);
        //                changeitem.Entity.ItemOrder = r.Field<int>(6);
        //                changeitem.Entity.Enable = DBNull.Value.Equals(r[7]) ? false : r.Field<Boolean>(7);
        //                changeitem.Entity.Modifier = r.Field<String>(10);
        //                changeitem.Entity.ModifyDate = DBNull.Value.Equals(r[11]) ? System.DateTime.Now : r.Field<DateTime>(11);
        //            }
        //            else if (r.RowState == DataRowState.Added)
        //            {
        //                int? basetypeid = r.Field<int>(1, DataRowVersion.Current);
        //                var b = db.Set<Models.BaseType>()
        //                         .Include(i => i.HaveItem) 
        //                         .Where(x => x.Id == basetypeid)                                 
        //                         .FirstOrDefault();
                                               
        //                if (b != null)
        //                {
        //                    var newitem = new Models.TypeItem();
        //                    newitem.ItemName = r.Field<String>(2);
        //                    newitem.ItemValue = r.Field<String>(3);
        //                    newitem.ItemValueType = r.Field<String>(4);
        //                    newitem.Comment = r.Field<String>(5);
        //                    newitem.ItemOrder = DBNull.Value.Equals(r[6]) ? 0 : r.Field<int>(6);
        //                    newitem.Enable = DBNull.Value.Equals(r[7]) ? false : r.Field<Boolean>(7);
        //                    newitem.Creator = r.Field<String>(8);
        //                    newitem.CreateDate = DBNull.Value.Equals(r[9]) ? System.DateTime.Now : r.Field<DateTime>(9);
        //                    newitem.Modifier = r.Field<String>(10);
        //                    newitem.ModifyDate = DBNull.Value.Equals(r[11]) ? System.DateTime.Now : r.Field<DateTime>(11);


        //                    //b = db.Set<Models.BaseType>().Include(i => i.HaveItem)
        //                    //                   .Where(x => x.BaseTypeID == bt.BaseTypeID)
        //                    //                   .ToList().FirstOrDefault();


        //                    b.HaveItem.Add(newitem);
        //                }
        //            }
        //        }
        //        db.SaveChanges();
        //    }
        //    this.Cursor = Cursors.Arrow;
        //}

        //private void ChangeBaseType(DataTable dt)
        //{            
        //    var cdt = dt.GetChanges();
        //    if (cdt == null) return;

        //    this.Cursor = Cursors.WaitCursor;
        //    using (var db = new Repository.SqliteDbContext())
        //    {
                
        //        var basetypes = db.Set<Models.BaseType>();
        //        foreach (System.Data.DataRow r in cdt.Rows)
        //        {

        //            if (r.RowState == DataRowState.Deleted)
        //            {
        //                int? changeid = r.Field<int>(0, DataRowVersion.Original);
        //                var i = basetypes.ToList().Find(x => x.Id == changeid);
        //                basetypes.Attach(i);
        //                basetypes.Remove(i);
        //            }
        //            else if (r.RowState == DataRowState.Modified)
        //            {
        //                int? changeid = r.Field<int>(0, DataRowVersion.Original);
        //                var i = basetypes.ToList().Find(x => x.Id == changeid);

        //                var b = db.Attach(i);
        //                b.Entity.BaseTypeName = r.Field<String>(1);
        //                b.Entity.Comment = r.Field<String>(2);
        //                b.Entity.TypeOrder = r.Field<int>(3);
        //                b.Entity.Enable = DBNull.Value.Equals(r[4]) ? false : r.Field<Boolean>(4);
        //                b.Entity.Modifier = r.Field<String>(7);
        //                b.Entity.ModifyDate = DBNull.Value.Equals(r[8]) ? System.DateTime.Now : r.Field<DateTime>(8);
        //            }
        //            else if (r.RowState == DataRowState.Added)
        //            {
        //                var newbasetype = new Models.BaseType();

        //                newbasetype.BaseTypeName = r.Field<String>(1);
        //                newbasetype.Comment = r.Field<String>(2);
        //                newbasetype.TypeOrder = DBNull.Value.Equals(r[3]) ? 0 : r.Field<int>(3);
        //                newbasetype.Enable = DBNull.Value.Equals(r[4]) ? false : r.Field<Boolean>(4);
        //                newbasetype.Creator = r.Field<String>(5);
        //                newbasetype.CreateDate = DBNull.Value.Equals(r[6]) ? System.DateTime.Now : r.Field<DateTime>(6);
        //                newbasetype.Modifier = r.Field<String>(7);
        //                newbasetype.ModifyDate = DBNull.Value.Equals(r[8]) ? System.DateTime.Now : r.Field<DateTime>(8);

        //                basetypes.Add(newbasetype);
        //            }
        //        }
        //        db.SaveChanges();
        //    }
        //    this.Cursor = Cursors.Arrow;
        //}

        ////保存方法
        //public   void SavaGridData(DataGridView dg)
        //{
        //    DataSet ds = (DataSet)((BindingSource)(dg.DataSource)).DataSource;

        //    DataTable dtb = ds.Tables["BaseType"];
        //    DataTable dti = ds.Tables["ItemType"];

        //    DataTable cdt =  dtb.GetChanges();///dt 就是datagridview.datasouce

        //    if (cdt == null)
        //        return;

        //    this.Cursor = Cursors.WaitCursor;
        //    using (var db = new Repository.SqliteDbContext())
        //    {
        //        var basetype = db.Set<Models.BaseType>();
        //        foreach (System.Data.DataRow r in cdt.Rows)
        //        {
        //            Models.BaseType bt = new Models.BaseType();
        //            if (r.RowState == DataRowState.Deleted)
        //            {
        //                bt.Id = r.Field<int>(0, DataRowVersion.Original);
        //                #region 删除
        //                // //删除明细
        //                // var _base = basetype.Include(b => b.HaveItem)
        //                //                       .Where(x => x.BaseTypeID == bt.BaseTypeID)
        //                //                       .ToList().FirstOrDefault();    

        //                // if (_base.HaveItem != null)
        //                // {
        //                //     db.RemoveRange(_base.HaveItem);
        //                // }

        //                //var a = db.ChangeTracker.Entries<Models.BaseType>()
        //                //     .Where(x => x.Entity.BaseTypeID == bt.BaseTypeID).FirstOrDefault().Entity;

        //                // basetype.Attach(a);
        //                // basetype.Remove(a);
        //                #endregion
        //            }
        //            else if (r.RowState == DataRowState.Modified)
        //            {                        
        //                bt.Id = r.Field<int>(0);

        //                var b = db.Attach(bt);
        //                b.Entity.BaseTypeName = r.Field<String>(1);  
        //                b.Entity.Comment = r.Field<String>(2) ;
        //                b.Entity.Enable = r.Field<Boolean>(3) ;                        
        //                b.Entity.Creator = r.Field<String>(4);
        //                b.Entity.CreateDate = DBNull.Value.Equals(r[5]) ? System.DateTime.Now : r.Field<DateTime>(5);

        //            }
        //            else if (r.RowState == DataRowState.Added)
        //            { 
        //                bt.BaseTypeName = r.Field<String>(1);
        //                bt.Comment = r.Field<String>(2);                        
        //                bt.Enable = DBNull.Value.Equals(r[3]) ? false : r.Field <Boolean>(3) ;                        
        //                bt.Creator = r.Field<String>(4);
        //                bt.CreateDate = DBNull.Value.Equals(r[5]) ? System.DateTime.Now  :  r.Field<DateTime>(5);

        //                basetype.Add(bt);
        //            }
        //        }
        //        db.SaveChanges();
        //    }

        //    dtb.AcceptChanges();
        //    dti.AcceptChanges();
        //    this.Cursor = Cursors.Arrow;
        //}

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            var dg = (DataGridView)sender;

            if (e.RowIndex < 0 || e.RowIndex >= dg.Rows.Count || e.ColumnIndex < 0 || e.ColumnIndex >= dg.Columns.Count)
                return;

            MessageBox.Show("格式错误 row = " + e.RowIndex.ToString() + "col = " + e.ColumnIndex.ToString());

            //dg.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Red;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var dg = (DataGridView)sender;


            dg.CurrentRow.Cells[0].Value = ++maxtypeid;

        }
    }
    
}
