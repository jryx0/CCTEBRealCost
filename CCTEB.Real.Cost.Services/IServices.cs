using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
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

    public abstract class Services<T> : IServices<T> where T : class
    {
        protected DbContext _dbContext { set; get; }

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
        protected virtual IEnumerable<T> QueryByWithDescendants(Expression<Func<T, List<T>>> include, Expression<Func<T, bool>> predict)
        {
            return QueryBy(predict).Include(include);
        }
    }

}
