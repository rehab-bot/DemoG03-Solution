using DemoG03.DataAccess.Models.Departments;
using DemoG03.DataAccess.Models.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DemoG03.DataAccess.Repositories.Generics
{
   public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        void Add(TEntity entity);
        IEnumerable<TEntity> GetAll(bool WithTracking = false);
        IEnumerable<TResult> GetAll<TResult>(Expression<Func<TEntity, TResult>>selector);  
        TEntity? GetById(int id);
        void Delete(TEntity entity);
        void Update(TEntity entity);
      


    }
}

