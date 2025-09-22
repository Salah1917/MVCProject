using BLL.DTO.Department;

namespace BLL.Services.Interfaces
{
    public interface IDepartmentService
    {
        int AddDepartment(CreatedDepartmentDTO createdDepartment);
        bool DeleteDepartment(int id);
        IEnumerable<DepartmentsDTO> GetAllDepartments();
        DepartmentDetailsDTO? GetDepartmentByID(int id);
        int UpdateDepartment(UpdatedDepartmentDTO updatedDepartment);
    }
}