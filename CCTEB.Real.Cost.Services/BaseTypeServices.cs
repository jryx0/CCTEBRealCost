using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCTEB.Real.Cost.Models;
using System.Linq.Expressions;

namespace CCTEB.Real.Cost.Services
{
    public class BaseTypeServices : Services<BaseType>   
    {
        #region 缓存
        private static BaseType _dept = new BaseType();
        public BaseType Department
        {           
            get
            {
                _dept = getSingleton(_dept, x => x.BaseTypeName == "公司部门");
                return _dept;
            }
        }

        private static BaseType _chargeby = new BaseType(); 
        public BaseType ChargeBy 
        {
            get
            {   
                _chargeby =  getSingleton(_chargeby, x => x.BaseTypeName == "收费单位");
                return _chargeby;
            }
        }

        private static BaseType _accountType = new BaseType(); 
        public BaseType AccountType
        {
            get
            {
                _accountType = getSingleton(_accountType, x => x.BaseTypeName == "科目");
                return _accountType;
            }
        }

        private BaseType getSingleton(BaseType b, Expression<Func<Models.BaseType, bool>> predict)
        {
            if (b == null)
                b = new BaseType();
                       
            if (b.HaveItem == null)
            {
                lock (b)
                {
                    if (b.HaveItem == null)
                        return QueryByWithDescendants(predict).FirstOrDefault();
                }
            }

            return b;
        }
        #endregion

        public BaseTypeServices()
        {
            _dbContext = new Repository.SqliteDbContext();   
        }

        public IQueryable<BaseType> QueryByWithDescendants(Expression<Func<Models.BaseType, bool>> predict)
        {
            return QueryBy(predict).Include(x => x.HaveItem).OrderBy(x => x.TypeOrder);
        }
        
    }


    public class TypeItemServices : Services<TypeItem> 
    {
        public TypeItemServices()
        {
            _dbContext = new Repository.SqliteDbContext();
        }


       

    }
}
