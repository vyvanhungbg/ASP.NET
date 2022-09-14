using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace CodeBai9.Models
{
    public partial class TinTucDB : DbContext
    {
        public TinTucDB()
            : base("name=TinTucDB")
        {
        }

        public virtual DbSet<Theloaitin> Theloaitins { get; set; }
        public virtual DbSet<Tintuc> Tintucs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
