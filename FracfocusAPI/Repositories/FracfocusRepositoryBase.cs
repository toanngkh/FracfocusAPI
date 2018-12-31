using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FracfocusAPI.Interfaces;
using FracfocusAPI.Models;

namespace FracfocusAPI.Repositories
{
    public abstract class FracfocusRepositoryBase<T>: IFracfocusBase<T> where T:class
    {
        protected FracfocusDBContext FracfocusDBContext { get; set; }

        public FracfocusRepositoryBase(FracfocusDBContext fracfocusDBContext)
        {
            this.FracfocusDBContext = fracfocusDBContext;
        }

        public IEnumerable<T> FindAll()
        {
            return this.FracfocusDBContext.Set<T>().Take(2000);
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.FracfocusDBContext.Set<T>().Where(expression);
        }
    }
}
