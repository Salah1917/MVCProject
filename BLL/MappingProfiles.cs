using AutoMapper;
using BLL.DTO.Employee;
using DAL.Models.EmployeeModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Employee, EmployeeDTO>();
            
            CreateMap<Employee, EmployeeDetailsDTO>()
                .ForMember(dest => dest.CreatedOn, options => options.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.LastModifiedOn, options => options.MapFrom(src => src.LastModifiedAt));

            CreateMap<CreatedEmployeeDTO, Employee>();

            CreateMap<UpdatedEmployeeDTO, Employee>();

        }
    }
}
