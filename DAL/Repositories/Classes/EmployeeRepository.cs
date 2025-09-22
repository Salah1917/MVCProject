using DAL.Data.Contexts;
using DAL.Models.DepartmentModule;
using DAL.Models.EmployeeModule;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Classes
{
    public class EmployeeRepository(ApplicationDbContext dbContext) : GenericRepository<Employee>(dbContext), IEmployeeRepository
    {
        private readonly ApplicationDbContext Context = dbContext;
    }
}
