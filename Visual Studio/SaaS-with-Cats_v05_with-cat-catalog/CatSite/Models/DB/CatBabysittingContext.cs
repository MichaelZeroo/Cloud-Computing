using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CatSite.Models.DB
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
        public virtual DbSet<Member> Member { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cat>(entity =>
            {
                entity.Property(e => e.Condition).HasMaxLength(50);

                entity.Property(e => e.NameOfCat).HasMaxLength(50);

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Cat)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cat_Member");
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(80);

                entity.Property(e => e.FirstNames).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(256);

                entity.Property(e => e.Phone).HasMaxLength(50);
            });
        }
    }
}
