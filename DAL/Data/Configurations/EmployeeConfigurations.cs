using DAL.Models.EmployeeModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data.Configurations
{
    public class EmployeeConfigurations : BaseEntityConfigurations<Employee> , IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(E => E.Name).HasColumnType("varchar(50)");
            
            builder.Property(E => E.Address).HasColumnType("varchar(50)");
            
            builder.Property(E => E.Salary).HasColumnType("decimal(10,2)");
            
            builder.Property(E => E.Gender)
                .HasConversion((EmployeeGender) => EmployeeGender.ToString()
                ,(gender) => (Gender)Enum.Parse(typeof(Gender), gender) );

            builder.Property(E => E.EmployeeType)
                .HasConversion((EmployeeType) => EmployeeType.ToString()
                ,(Type) => (EmployeeTypes)Enum.Parse(typeof(EmployeeTypes), Type) );

            base.Configure(builder);
        }
    }
}
