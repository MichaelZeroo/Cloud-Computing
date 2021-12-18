using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Hub01.Models.DB
{
    public partial class CDQ3_Michael_D1Context : DbContext
    {
        public CDQ3_Michael_D1Context()
        {
        }

        public CDQ3_Michael_D1Context(DbContextOptions<CDQ3_Michael_D1Context> options)
            : base(options)
        {
        }

        // Unable to generate entity type for table 'dbo.Member'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=citizen.manukautech.info,6303;Database=CDQ3_Michael_D1;UID=CDQ3_Michael;PWD=fBit$80726;Encrypt=true;TrustServerCertificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {}
    }
}
