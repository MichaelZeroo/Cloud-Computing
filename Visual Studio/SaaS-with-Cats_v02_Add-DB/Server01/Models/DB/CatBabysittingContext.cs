using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Server01.Models.DB
{
    public partial class CatBabysittingContext : DbContext
    {
        public CatBabysittingContext()
        {
        }

        public CatBabysittingContext(DbContextOptions<CatBabysittingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cat> Cat { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cat>(entity =>
            {
                entity.Property(e => e.Condition).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(80);

                entity.Property(e => e.NameOfCat).HasMaxLength(50);
            });
        }
    }
}
