using DAL.Data.Contexts;
using DAL.Models;
using DAL.Models.DepartmentModule;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories.Classes
{
    public class DepartmentRepository(ApplicationDbContext dbContext) : GenericRepository<Department>(dbContext), IDepartmentRepository
    {
        private readonly ApplicationDbContext Context = dbContext;

    }
}
