using BLL.DTO.Employee;
using BLL.Services.Interfaces;
using DAL.Repositories.Classes;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Classes
{
    public class EmployeeService(IEmployeeRepository employeeRepository) : IEmployeeService
    {
        private readonly IEmployeeRepository EmployeeRepository = employeeRepository;

        #region Retrieve
        public IEnumerable<EmployeeDTO> GetAllEmployees(bool WithTracking)
        {
            var Employees = EmployeeRepository.GetAll(WithTracking);
            var EmployeeDto = Employees.Select(Employee => new EmployeeDTO()
            {
                Id = Employee.Id,
                Name = Employee.Name,
                Age = Employee.Age,
                Email = Employee.Email,
                IsActive = Employee.IsActive,
                Salary = Employee.Salary,
                EmployeeType = Employee.EmployeeType.ToString()
            });

            return EmployeeDto;
        }

        public EmployeeDetailsDTO? GetByEmployeeId(int id)
        {
            var Employee = EmployeeRepository.GetById(id);

            return Employee is null ? null : new EmployeeDetailsDTO()
            {
                Id = Employee.Id,
                Name = Employee.Name,
                Age = Employee.Age,
                Email = Employee.Email,
                IsActive = Employee.IsActive,
                Salary = Employee.Salary,
                EmployeeType = Employee.EmployeeType.ToString(),
                HiringDate = DateOnly.FromDateTime(Employee.HiringDate),
                PhoneNumber = Employee.PhoneNumber,
                Gender = Employee.Gender.ToString(),
                CreatedBy = 1,
                CreatedOn = Employee.CreatedAt,
                LastModifiedBy = 1,
                LastModifiedOn = Employee.LastModifiedAt
            };
        } 
        #endregion

        public int CreateEmployee(CreatedEmployeeDTO createdEmployeeDTO)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        

        public int UpdateEmployee(UpdatedEmployeeDTO updatedEmployeeDTO)
        {
            throw new NotImplementedException();
        }
    }
}
