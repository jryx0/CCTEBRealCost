﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CCTEB.Real.Cost.Models;

namespace CCTEB.Real.Cost.Services
{
    public class AccountBOCServices : Services<Models.Tree> 
    {
        public AccountBOCServices()
        {
            _dbContext = new Repository.SqliteDbContext();
        }
        
        /// <summary>
        /// 获取所有子节点
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public virtual IQueryable<Models.Tree> QueryChild(Models.Tree node)
        {  
            return QueryBy(x => x.Id == node.Id) ;
        }             

        /// <summary>
        /// 按 predict 获取树
        /// 
        /// </summary>
        /// <param name="predict"></param>
        /// <returns></returns>
        public virtual IQueryable<Models.Tree> QueryByWithDescendants(Expression<Func<Models.Tree, bool>> predict)
        {           
            var ieTree = base.QueryByWithDescendants(x => x.Child, x => predict.Compile().Invoke(x) || x.Parent.Id == x.Id);
            return ieTree;
        }

        /// <summary>
        /// 获取整个树
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<Models.Tree> QueryByWithDescendants()
        {
            return QueryByWithDescendants(x => x.Parent == null);
           
        }

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


    public class AccountServices : Services<Models.Accounts> 
    {
        public AccountServices()
        {
            _dbContext = new Repository.SqliteDbContext();
        }


        public override IQueryable<Accounts> QueryBy(Expression<Func<Accounts, bool>> predict)
        {
            return base.QueryBy(predict).Include(x => x.Child).Include(x => x.AssistBy);
        }


        public IQueryable<Accounts> QueryByWithDescendants(Expression<Func<Accounts, bool>> predict)
        {
            return base.QueryBy(x => predict.Compile().Invoke(x) || x.Parent.Id == x.Id).Include(x => x.Child).Include(x => x.AssistBy);

        }

        public IQueryable<Accounts> QueryByWithDescendants()
        {
            return this.QueryByWithDescendants(x => x.Parent == null);

        }

    }
}
