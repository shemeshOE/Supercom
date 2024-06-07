using Microsoft.EntityFrameworkCore;
using Supercom__Backend.Enums;

namespace Supercom__Backend.Model
{
    public class SupercomDbContext:DbContext
    {
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public SupercomDbContext(DbContextOptions<SupercomDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>()
                .Property(e => e.Status)
                .HasDefaultValue(TicketStatus.Open);

            modelBuilder.Entity<Ticket>()
                .HasMany(p => p.Comments)
                .WithOne(c => c.Ticket)
                .HasForeignKey(c => c.TicketId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public override int SaveChanges()
        {
            UpdateTimestamps();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateTimestamps();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateTimestamps()
        {
            var currentTime = DateTime.UtcNow;

            foreach (var entry in ChangeTracker.Entries<DatedEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property(e => e.CreatedAt).CurrentValue = currentTime;
                    entry.Property(e => e.UpdatedAt).CurrentValue = currentTime;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Property(e => e.UpdatedAt).CurrentValue = currentTime;
                }
            }
        }
    }
}
