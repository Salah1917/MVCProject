using DAL.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class DepartmentRepository(ApplicationDbContext dbContext) : IDepartmentRepository
    {
        private readonly ApplicationDbContext Context = dbContext;

        #region Retrieve

        public Department? GetById(int id)
        {
            return Context.Departments.Find(id);
        }

        public IEnumerable<Department> GetAll(bool WithTracking = false)
        {
            return WithTracking ? Context.Departments.ToList() :
                Context.Departments.AsNoTracking().ToList();
        }

        #endregion

        #region Add

        public int Add(Department department)
        {
            Context.Departments.Add(department);
            return Context.SaveChanges();
        }

        #endregion

        #region Update

        public int Update(Department department)
        {
            Context.Departments.Update(department);
            return Context.SaveChanges();
        }

        #endregion

        #region Delete

        public int Delete(Department department)
        {
            Context.Departments.Remove(department);
            return Context.SaveChanges();
        }

        #endregion
    }
}
