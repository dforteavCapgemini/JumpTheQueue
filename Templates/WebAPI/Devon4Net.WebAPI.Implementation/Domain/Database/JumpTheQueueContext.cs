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
            modelBuilder.Entity<Visitor>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });
        }
    }
}

