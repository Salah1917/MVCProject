using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data.Configurations
{
    public class BaseEntityConfigurations<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(D => D.CreatedAt).HasDefaultValueSql("getdate()");
            
            builder.Property(D => D.LastModifiedAt).HasComputedColumnSql("getdate()");
        }
    }
}
