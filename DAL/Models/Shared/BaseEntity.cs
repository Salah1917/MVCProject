using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Shared
{
    public class BaseEntity
    {
        public int Id { get; set; } //Primary Key For All Tables

        public int CreatedBy { get; set; } //UserId

        public DateTime? CreatedAt { get; set; } //Timestamp

        public int LastModifiedBy { get; set; } //UserId

        public DateTime? LastModifiedAt { get; set; } //Timestamp

        public bool IsDeleted { get; set; } //Soft Delete
    }
}
