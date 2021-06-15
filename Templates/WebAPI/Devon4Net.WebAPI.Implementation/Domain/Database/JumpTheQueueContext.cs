using Devon4Net.WebAPI.Implementation.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Devon4Net.WebAPI.Implementation.Domain.Database
{
    public class JumpTheQueueContext : DbContext
    {

        public JumpTheQueueContext(DbContextOptions<JumpTheQueueContext> options) : base(options)
        {

        }

        /// <summary>
        /// Dbset
        /// </summary>
        public virtual DbSet<Visitor> Visitors { get; set; }
        public virtual DbSet<AccessCode> AccessCodes { get; set; }
        public virtual DbSet<DailyQueue> DailyQueues{ get; set; }
        /// <summary>
        /// Any extra configuration should be here
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer()
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
            .Entity<Visitor>(entity =>
            {
                entity.Property(e => e.Name).IsRequired().HasMaxLength(255);  
            })
            .Entity<Visitor>()
            .HasOne(a => a.AccessCode)
            .WithOne(b=> b.Visitor)
            .HasForeignKey<AccessCode>(b => b.VisitorId);

            modelBuilder
            .Entity<DailyQueue>()
            .HasMany(a => a.AccessCodes)
            .WithOne(b => b.DailyQueue);
        }
    }
}

