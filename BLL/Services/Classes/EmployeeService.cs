using AutoMapper;
using BLL.DTO.Employee;
using BLL.Services.Interfaces;
using DAL.Models.EmployeeModule;
using DAL.Repositories.Classes;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Classes
{
    public class EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper) : IEmployeeService
    {
        #region Properties
		
        private readonly IEmployeeRepository EmployeeRepository = employeeRepository;
        private readonly IMapper _mapper = mapper;

        #endregion
        
        #region Create

        public int CreateEmployee(CreatedEmployeeDTO createdEmployeeDTO)
        {
            var Employee = _mapper.Map<CreatedEmployeeDTO, Employee>(createdEmployeeDTO);

            return EmployeeRepository.Add(Employee);
        }

        #endregion

        #region Retrieve
        public IEnumerable<EmployeeDTO> GetAllEmployees(bool WithTracking = false)
        {
            var Employees = EmployeeRepository.GetAll(WithTracking);
            //want to turn Employee -> EmployeeDTO
            var EmployeesDto = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDTO>>(Employees);

            return EmployeesDto;
        }

        public EmployeeDetailsDTO? GetByEmployeeId(int id)
        {
            var Employee = EmployeeRepository.GetById(id);
            //var EmployeeDetailsDto = _mapper.Map<Employee, EmployeeDetailsDTO>(Employee);
            //return EmployeeDetailsDto;

            //want to turn Employee -> EmployeeDetailsDTO
            return Employee is null ? null : _mapper.Map<Employee, EmployeeDetailsDTO>(Employee);
        }
        #endregion

        #region Update

        public int UpdateEmployee(UpdatedEmployeeDTO updatedEmployeeDTO)
        {

            var Employee = _mapper.Map<UpdatedEmployeeDTO, Employee>(updatedEmployeeDTO);

            return EmployeeRepository.Update(Employee);
        }

        #endregion

        #region Delete

        public bool DeleteEmployee(int id)
        {
            var Employee = EmployeeRepository.GetById(id);
            if (Employee is null)
                return false;

            Employee.IsDeleted = true;

            return EmployeeRepository.Update(Employee) > 0 ? true : false;

        }

        //public bool DeleteEmployeeById(int id)
        //{
        //    var Employee = EmployeeRepository.GetById(id);
        //    if (Employee is null)
        //        return false;

        //    return EmployeeRepository.Delete(Employee) > 0 ? true : false;

        //}

        #endregion
    }
}
