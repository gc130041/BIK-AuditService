using Microsoft.EntityFrameworkCore;
using BIK.AuditService.Domain.Entities;

namespace BIK.AuditService.Infrastructure.Data
{
    public class AuditDbContext : DbContext
    {
        public AuditDbContext(DbContextOptions<AuditDbContext> options) : base(options) { }

        public DbSet<AuditLog> AuditLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AuditLog>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.ActionType).IsRequired().HasColumnType("varchar(50)");
                entity.Property(e => e.Severity).IsRequired().HasColumnType("varchar(20)");
                entity.Property(e => e.UserId).HasColumnType("varchar(24)");
                entity.Property(e => e.SourceIpAddress).HasColumnType("varchar(45)");
            });
        }
    }
}