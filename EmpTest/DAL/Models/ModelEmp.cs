using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAL.Models
{
    public partial class ModelEmp : DbContext
    {
        public ModelEmp()
            : base("name=ModelEmp")
        {
        }

        public virtual DbSet<EMPLOYEE> EMPLOYEEs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.EMP_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.EMP_DESCRIPTION)
                .IsUnicode(false);
        }
    }
}
