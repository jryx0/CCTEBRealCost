using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CCTEB.Real.Cost.Services
{
    interface IServices<T>
    {

    }

    public abstract class Services<T> :IDisposable, IServices<T> where T : class
    {
        

        public DbContext _dbContext { set; get; }

        /// <summary>
        /// 查询
        /// </summary>
        /// <returns>返回DBSet</returns>
        public virtual DbSet<T> Query()
        {
            return _dbContext.Set<T>();
        }

        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="predict">条件</param>
        /// <returns></returns>
        public virtual IQueryable<T> QueryBy (Expression<Func<T, bool>> predict)
        {
            return Query().Where(predict);
        }        
        

        /// <summary>
        /// 获取全部子节点和子节点的子节点
        /// </summary>
        /// <param name="include">子节点</param>
        /// <param name="predict">条件</param>
        /// <returns></returns>
        protected virtual IQueryable<T> QueryByWithDescendants(Expression<Func<T, List<T>>> include, Expression<Func<T, bool>> predict)
        {
            return QueryBy(predict).Include(include);
        }

        
        public virtual void SaveChanges()
        {
            _dbContext?.SaveChanges();
        }

        //public static Hashtable GetInstance()
        //{
        //    // 当第一个线程运行到这里时，此时会对locker对象 "加锁"，
        //    // 当第二个线程运行该方法时，首先检测到locker对象为"加锁"状态，该线程就会挂起等待第一个线程解锁
        //    // lock语句运行完之后（即线程运行完之后）会对该对象"解锁"
        //    // 双重锁定只需要一句判断就可以了
        //    if (cacheData == null)
        //    {
        //        lock (cacheData)
        //        {
        //            // 如果类的实例不存在则创建，否则直接返回
        //            if (cacheData == null)
        //            {
        //                cacheData = new Hashtable();
        //            }
        //        }
        //    }
        //    return cacheData;
        //}


        #region IDisposable Support
        private bool disposedValue = false; // 要检测冗余调用

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                    // TODO: 释放托管状态(托管对象)。
                }

                // TODO: 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
                // TODO: 将大型字段设置为 null。

                disposedValue = true;
            }
        }

        // TODO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
        // ~BaseItemServices() {
        //   // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
        //   Dispose(false);
        // }

        // 添加此代码以正确实现可处置模式。
        public void Dispose()
        {
            // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果在以上内容中替代了终结器，则取消注释以下行。
            // GC.SuppressFinalize(this);
        }
        #endregion      

    }

}
