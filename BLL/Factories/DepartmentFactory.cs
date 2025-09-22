using BLL.DTO;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Factories
{
    public static class DepartmentFactory
    {
        public static DepartmentsDTO ToDepartmentDTO(this Department department)
        {
            return new DepartmentsDTO()
            {
                Id = department.Id,
                Name = department.Name,
                Code = department.Code,
                DateOfCreation = department.CreatedAt
            };
        }

        public static DepartmentDetailsDTO ToDepartmentDetailsDTO(this Department department)
        {
            return new DepartmentDetailsDTO()
            {
                Id = department.Id,
                Name = department.Name,
                Code = department.Code,
                Description = department.Description,
                CreatedBy = department.CreatedBy,
                DateOfCreation = department.CreatedAt,
                LastModifiedBy = department.LastModifiedBy,
                LastModifiedAt = department.LastModifiedAt,
                IsDeleted = department.IsDeleted
            };
        }

        public static Department ToEntity(this CreatedDepartmentDTO createdDepartment)
        {
            return new Department()
            {
                Name = createdDepartment.Name,
                Code = createdDepartment.Code,
                Description = createdDepartment.Description,
                CreatedAt = createdDepartment.DateOfCreation
            };
        }

        public static Department ToEntity(this UpdatedDepartmentDTO updatedDepartment)
        {
            return new Department()
            {
                Id = updatedDepartment.Id,
                Name = updatedDepartment.Name,
                Code = updatedDepartment.Code,
                Description = updatedDepartment.Description,
                CreatedAt = updatedDepartment.DateOfCreation
            };
        }


    }
}
