using BLL.DTO;
using BLL.Factories;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class DepartmentService(IDepartmentRepository _departmentRepository) : IDepartmentService
    {
        private IDepartmentRepository departmentRepository = _departmentRepository;

        #region Retrieve

        public IEnumerable<DepartmentsDTO> GetAllDepartments()
        {
            var departments = departmentRepository.GetAll();

            return departments.Select(D => D.ToDepartmentDTO());
        }

        public DepartmentDetailsDTO? GetDepartmentByID(int id)
        {
            var department = departmentRepository.GetById(id);

            return department is null ? null : department.ToDepartmentDetailsDTO();
        }

        #endregion

        #region Create

        public int AddDepartment(CreatedDepartmentDTO createdDepartment)
        {
            var department = createdDepartment.ToEntity();
            return departmentRepository.Add(department);

        }

        #endregion

        #region Update

        public int UpdateDepartment(UpdatedDepartmentDTO updatedDepartment)
        {
            var department = updatedDepartment.ToEntity();

            return departmentRepository.Update(department);
        }

        #endregion

        #region Delete

        public bool DeleteDepartment(int id)
        {
            var department = departmentRepository.GetById(id);
            if (department is null) return false;

            int result = departmentRepository.Delete(department);
            return result > 0 ? true : false;
        }

        #endregion
    }
}
