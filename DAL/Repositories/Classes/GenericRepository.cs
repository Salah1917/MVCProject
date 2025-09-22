using DAL.Data.Contexts;
using DAL.Models.DepartmentModule;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Classes
{
    public class GenericRepository<TEntity>(ApplicationDbContext dbContext) : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ApplicationDbContext Context = dbContext;


        #region Retrieve

        public TEntity? GetById(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll(bool WithTracking = false)
        {
            return WithTracking ? Context.Set<TEntity>().ToList() :
                Context.Set<TEntity>().AsNoTracking().ToList();
        }

        #endregion

        #region Add

        public int Add(TEntity Entity)
        {
            Context.Set<TEntity>().Add(Entity);
            return Context.SaveChanges();
        }

        #endregion

        #region Update

        public int Update(TEntity Entity)
        {
            Context.Set<TEntity>().Update(Entity);
            return Context.SaveChanges();
        }

        #endregion

        #region Delete

        public int Delete(TEntity Entity)
        {
            Context.Set<TEntity>().Remove(Entity);
            return Context.SaveChanges();
        }

        #endregion
    }
}
