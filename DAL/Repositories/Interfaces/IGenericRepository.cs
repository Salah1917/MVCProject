using DAL.Models.DepartmentModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        int Add(TEntity Entity);
        int Delete(TEntity Entity);
        IEnumerable<TEntity> GetAll(bool WithTracking = false);
        TEntity? GetById(int id);
        int Update(TEntity Entity);
    }
}
