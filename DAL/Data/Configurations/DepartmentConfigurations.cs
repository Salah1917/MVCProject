using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models.DepartmentModule;

namespace DAL.Data.Configurations
{
    public class DepartmentConfigurations : BaseEntityConfigurations<Department> , IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(D => D.Id).UseIdentityColumn(1, 1); //Already done but just for fun
            
            builder.Property(D => D.Name).HasColumnType("varchar(20)");
            
            builder.Property(D => D.Code).HasColumnType("varchar(20)");

            base.Configure(builder);

        }
    }
}
