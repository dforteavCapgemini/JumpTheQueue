using Devon4Net.WebAPI.Implementation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

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
          
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Visitor
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
            #endregion

            #region VisitorSeed
            modelBuilder.Entity<Visitor>().HasData(
                new Visitor { VisitorId = -1, Username = "mike@mail.com",    Name = "test", Password = "123456789", PhoneNumber = "0", AcceptedCommercial = false, AcceptedTerms = true, UserType = true },
                new Visitor { VisitorId = 1, Username = "peter@mail.com",   Name = "test", Password = "123456789", PhoneNumber = "1", AcceptedCommercial = true, AcceptedTerms = true, UserType = false },
                new Visitor { VisitorId = 2, Username = "pablo@mail.com",   Name = "test", Password = "123456789", PhoneNumber = "0", AcceptedCommercial = true, AcceptedTerms = true, UserType = false },
                new Visitor { VisitorId = 3, Username = "test1@mail.com",   Name = "test", Password = "123456789", PhoneNumber = "0", AcceptedCommercial = true, AcceptedTerms = true, UserType = false },
                new Visitor { VisitorId = 4, Username = "test2@mail.com",   Name = "test", Password = "123456789", PhoneNumber = "1", AcceptedCommercial = true, AcceptedTerms = true, UserType = false },
                new Visitor { VisitorId = 5, Username = "test3@mail.com",   Name = "test", Password = "123456789", PhoneNumber = "0", AcceptedCommercial = true, AcceptedTerms = true, UserType = false },
                new Visitor { VisitorId = 6, Username = "test4@mail.com",   Name = "test", Password = "123456789", PhoneNumber = "0", AcceptedCommercial = true, AcceptedTerms = true, UserType = false },
                new Visitor { VisitorId = 7, Username = "test5@mail.com",   Name = "test", Password = "123456789", PhoneNumber = "1", AcceptedCommercial = true, AcceptedTerms = true, UserType = false },
                new Visitor { VisitorId = 8, Username = "test6@mail.com",   Name = "test", Password = "123456789", PhoneNumber = "0", AcceptedCommercial = true, AcceptedTerms = true, UserType = false },
                new Visitor { VisitorId = 9, Username = "test7@mail.com",   Name = "test", Password = "123456789", PhoneNumber = "0", AcceptedCommercial = true, AcceptedTerms = true, UserType = false });

            #endregion 

            modelBuilder.Entity<DailyQueue>().HasData(
                new DailyQueue {DailyQueueId = 1, Name = "Day2", Logo = "C:/logos/Day1Logo.png", CurrentNumber = 1, MinAttentionTime = new DateTime(1970,01,01,0,1,0), Active = true ,   Customers = 9 }
                );

            #region AccessCodeSeed
            modelBuilder.Entity<AccessCode>().HasData(
                new AccessCode { AccessCodeId = 1, TicketNumber = 1, CreationTime = DateTime.Now, StartTime = DateTime.Now,                         VisitorId = 1, DailyQueueId = 1 },
                new AccessCode { AccessCodeId = 2, TicketNumber = 2, CreationTime = DateTime.Now, StartTime = new DateTime(2008, 01, 01, 0, 1, 01), VisitorId = 2, DailyQueueId = 1 },
                new AccessCode { AccessCodeId = 3, TicketNumber = 3, CreationTime = DateTime.Now, StartTime = new DateTime(2008, 01, 01, 0, 1, 01), VisitorId = 3, DailyQueueId = 1 },
                new AccessCode { AccessCodeId = 4, TicketNumber = 4, CreationTime = DateTime.Now, StartTime = new DateTime(2008, 01, 01, 0, 1, 01), VisitorId = 4, DailyQueueId = 1 },
                new AccessCode { AccessCodeId = 5, TicketNumber = 5, CreationTime = DateTime.Now, StartTime = new DateTime(2008, 01, 01, 0, 1, 01), VisitorId = 5, DailyQueueId = 1 },
                new AccessCode { AccessCodeId = 6, TicketNumber = 6, CreationTime = DateTime.Now, StartTime = new DateTime(2008, 01, 01, 0, 1, 01), VisitorId = 6, DailyQueueId = 1 },
                new AccessCode { AccessCodeId = 7, TicketNumber = 7, CreationTime = DateTime.Now, StartTime = new DateTime(2008, 01, 01, 0, 1, 01), VisitorId = 7, DailyQueueId = 1 },
                new AccessCode { AccessCodeId = 8, TicketNumber = 8, CreationTime = DateTime.Now, StartTime = new DateTime(2008, 01, 01, 0, 1, 01), VisitorId = 8, DailyQueueId = 1 },
                new AccessCode { AccessCodeId = 9, TicketNumber = 9, CreationTime = DateTime.Now, StartTime = new DateTime(2008, 01, 01, 0, 1, 01), VisitorId = 9, DailyQueueId = 1 });
            #endregion
        }
    }
}

