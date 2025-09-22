using BLL.DTO.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDTO> GetAllEmployees(bool WithTracking);

        EmployeeDetailsDTO? GetByEmployeeId(int id);

        int CreateEmployee(CreatedEmployeeDTO createdEmployeeDTO);

        int UpdateEmployee(UpdatedEmployeeDTO updatedEmployeeDTO);

        bool DeleteEmployee(int id);
    }
}
