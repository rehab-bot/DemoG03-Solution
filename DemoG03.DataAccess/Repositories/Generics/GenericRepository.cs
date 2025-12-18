using DemoG03.DataAccess.Data.Contexts;
using DemoG03.DataAccess.Models.Departments;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DemoG03.DataAccess.Repositories.Generics
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ApplicationDBContext _DbContext;

        public GenericRepository(ApplicationDBContext dbContext)
        {
            _DbContext = dbContext;
        }


        //CRUD Operations
        public IEnumerable<TEntity> GetAll(bool WithTracking = false)
        {
            if (WithTracking)
            {
                return _DbContext.Set<TEntity>().Where(T => T.IsDeleted != true).ToList();
            }
            else
            {
                return _DbContext.Set<TEntity>().Where(T => T.IsDeleted != true).AsNoTracking().ToList();

            }

        }
        public TEntity? GetById(int id)
        {
            var entity = _DbContext.Set<TEntity>().Find(id);
            return entity;
        }
        public int Add(TEntity entity)
        {
            _DbContext.Set<TEntity>().Add(entity);
            return _DbContext.SaveChanges();
        }
        public int Update(TEntity entity)
        {
            _DbContext.Update(entity);
            return _DbContext.SaveChanges();
        }
        public int Delete(TEntity entity)
        {
            _DbContext.Set<TEntity>().Remove(entity);
            return _DbContext.SaveChanges();
        }

        public IEnumerable<TResult> GetAll<TResult>(Expression<Func<TEntity, TResult>> selector)
        {
            return _DbContext.Set<TEntity>().Where(E => E.IsDeleted != true).Select(selector).ToList();
        }


    }
}
 