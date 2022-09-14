using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace OnTapDe3_2.Models
{
    public partial class DeDB : DbContext
    {
        public DeDB()
            : base("name=DeDB")
        {
        }

        public virtual DbSet<Hang> Hangs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hang>()
                .Property(e => e.Mahang)
                .IsFixedLength();
        }
    }
}
