﻿// <auto-generated />
using System;
using Devon4Net.WebAPI.Implementation.Domain.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Devon4Net.WebAPI.Implementation.Domain.Database.Migrations
{
    [DbContext(typeof(JumpTheQueueContext))]
    [Migration("20210616074531_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Devon4Net.WebAPI.Implementation.Domain.Entities.AccessCode", b =>
                {
                    b.Property<int>("AccessCodeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("DailyQueueId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Endtime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("TicketNumber")
                        .HasColumnType("int");

                    b.Property<int>("VisitorId")
                        .HasColumnType("int");

                    b.HasKey("AccessCodeId");

                    b.HasIndex("DailyQueueId");

                    b.HasIndex("VisitorId")
                        .IsUnique();

                    b.ToTable("AccessCodes");

                    b.HasData(
                        new
                        {
                            AccessCodeId = 1,
                            CreationTime = new DateTime(2021, 6, 16, 9, 45, 30, 653, DateTimeKind.Local).AddTicks(1584),
                            DailyQueueId = 1,
                            Endtime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartTime = new DateTime(2021, 6, 16, 9, 45, 30, 653, DateTimeKind.Local).AddTicks(1947),
                            TicketNumber = 1,
                            VisitorId = 1
                        },
                        new
                        {
                            AccessCodeId = 2,
                            CreationTime = new DateTime(2021, 6, 16, 9, 45, 30, 653, DateTimeKind.Local).AddTicks(2750),
                            DailyQueueId = 1,
                            Endtime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartTime = new DateTime(2008, 1, 1, 0, 1, 1, 0, DateTimeKind.Unspecified),
                            TicketNumber = 2,
                            VisitorId = 2
                        },
                        new
                        {
                            AccessCodeId = 3,
                            CreationTime = new DateTime(2021, 6, 16, 9, 45, 30, 653, DateTimeKind.Local).AddTicks(2800),
                            DailyQueueId = 1,
                            Endtime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartTime = new DateTime(2008, 1, 1, 0, 1, 1, 0, DateTimeKind.Unspecified),
                            TicketNumber = 3,
                            VisitorId = 3
                        },
                        new
                        {
                            AccessCodeId = 4,
                            CreationTime = new DateTime(2021, 6, 16, 9, 45, 30, 653, DateTimeKind.Local).AddTicks(2850),
                            DailyQueueId = 1,
                            Endtime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartTime = new DateTime(2008, 1, 1, 0, 1, 1, 0, DateTimeKind.Unspecified),
                            TicketNumber = 4,
                            VisitorId = 4
                        },
                        new
                        {
                            AccessCodeId = 5,
                            CreationTime = new DateTime(2021, 6, 16, 9, 45, 30, 653, DateTimeKind.Local).AddTicks(2855),
                            DailyQueueId = 1,
                            Endtime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartTime = new DateTime(2008, 1, 1, 0, 1, 1, 0, DateTimeKind.Unspecified),
                            TicketNumber = 5,
                            VisitorId = 5
                        },
                        new
                        {
                            AccessCodeId = 6,
                            CreationTime = new DateTime(2021, 6, 16, 9, 45, 30, 653, DateTimeKind.Local).AddTicks(2860),
                            DailyQueueId = 1,
                            Endtime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartTime = new DateTime(2008, 1, 1, 0, 1, 1, 0, DateTimeKind.Unspecified),
                            TicketNumber = 6,
                            VisitorId = 6
                        },
                        new
                        {
                            AccessCodeId = 7,
                            CreationTime = new DateTime(2021, 6, 16, 9, 45, 30, 653, DateTimeKind.Local).AddTicks(2864),
                            DailyQueueId = 1,
                            Endtime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartTime = new DateTime(2008, 1, 1, 0, 1, 1, 0, DateTimeKind.Unspecified),
                            TicketNumber = 7,
                            VisitorId = 7
                        },
                        new
                        {
                            AccessCodeId = 8,
                            CreationTime = new DateTime(2021, 6, 16, 9, 45, 30, 653, DateTimeKind.Local).AddTicks(2868),
                            DailyQueueId = 1,
                            Endtime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartTime = new DateTime(2008, 1, 1, 0, 1, 1, 0, DateTimeKind.Unspecified),
                            TicketNumber = 8,
                            VisitorId = 8
                        },
                        new
                        {
                            AccessCodeId = 9,
                            CreationTime = new DateTime(2021, 6, 16, 9, 45, 30, 653, DateTimeKind.Local).AddTicks(2872),
                            DailyQueueId = 1,
                            Endtime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartTime = new DateTime(2008, 1, 1, 0, 1, 1, 0, DateTimeKind.Unspecified),
                            TicketNumber = 9,
                            VisitorId = 9
                        });
                });

            modelBuilder.Entity("Devon4Net.WebAPI.Implementation.Domain.Entities.DailyQueue", b =>
                {
                    b.Property<int>("DailyQueueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("AttentionTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("CurrentNumber")
                        .HasColumnType("int");

                    b.Property<int>("Customers")
                        .HasColumnType("int");

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("MinAttentionTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DailyQueueId");

                    b.ToTable("DailyQueues");

                    b.HasData(
                        new
                        {
                            DailyQueueId = 1,
                            Active = true,
                            AttentionTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CurrentNumber = 1,
                            Customers = 9,
                            Logo = "C:/logos/Day1Logo.png",
                            MinAttentionTime = new DateTime(1970, 1, 1, 0, 1, 0, 0, DateTimeKind.Unspecified),
                            Name = "Day2"
                        });
                });

            modelBuilder.Entity("Devon4Net.WebAPI.Implementation.Domain.Entities.Visitor", b =>
                {
                    b.Property<int>("VisitorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AcceptedCommercial")
                        .HasColumnType("bit");

                    b.Property<bool>("AcceptedTerms")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("UserType")
                        .HasColumnType("bit");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VisitorId");

                    b.ToTable("Visitors");

                    b.HasData(
                        new
                        {
                            VisitorId = -1,
                            AcceptedCommercial = false,
                            AcceptedTerms = true,
                            Name = "test",
                            Password = "123456789",
                            PhoneNumber = "0",
                            UserType = true,
                            Username = "mike@mail.com"
                        },
                        new
                        {
                            VisitorId = 1,
                            AcceptedCommercial = true,
                            AcceptedTerms = true,
                            Name = "test",
                            Password = "123456789",
                            PhoneNumber = "1",
                            UserType = false,
                            Username = "peter@mail.com"
                        },
                        new
                        {
                            VisitorId = 2,
                            AcceptedCommercial = true,
                            AcceptedTerms = true,
                            Name = "test",
                            Password = "123456789",
                            PhoneNumber = "0",
                            UserType = false,
                            Username = "pablo@mail.com"
                        },
                        new
                        {
                            VisitorId = 3,
                            AcceptedCommercial = true,
                            AcceptedTerms = true,
                            Name = "test",
                            Password = "123456789",
                            PhoneNumber = "0",
                            UserType = false,
                            Username = "test1@mail.com"
                        },
                        new
                        {
                            VisitorId = 4,
                            AcceptedCommercial = true,
                            AcceptedTerms = true,
                            Name = "test",
                            Password = "123456789",
                            PhoneNumber = "1",
                            UserType = false,
                            Username = "test2@mail.com"
                        },
                        new
                        {
                            VisitorId = 5,
                            AcceptedCommercial = true,
                            AcceptedTerms = true,
                            Name = "test",
                            Password = "123456789",
                            PhoneNumber = "0",
                            UserType = false,
                            Username = "test3@mail.com"
                        },
                        new
                        {
                            VisitorId = 6,
                            AcceptedCommercial = true,
                            AcceptedTerms = true,
                            Name = "test",
                            Password = "123456789",
                            PhoneNumber = "0",
                            UserType = false,
                            Username = "test4@mail.com"
                        },
                        new
                        {
                            VisitorId = 7,
                            AcceptedCommercial = true,
                            AcceptedTerms = true,
                            Name = "test",
                            Password = "123456789",
                            PhoneNumber = "1",
                            UserType = false,
                            Username = "test5@mail.com"
                        },
                        new
                        {
                            VisitorId = 8,
                            AcceptedCommercial = true,
                            AcceptedTerms = true,
                            Name = "test",
                            Password = "123456789",
                            PhoneNumber = "0",
                            UserType = false,
                            Username = "test6@mail.com"
                        },
                        new
                        {
                            VisitorId = 9,
                            AcceptedCommercial = true,
                            AcceptedTerms = true,
                            Name = "test",
                            Password = "123456789",
                            PhoneNumber = "0",
                            UserType = false,
                            Username = "test7@mail.com"
                        });
                });

            modelBuilder.Entity("Devon4Net.WebAPI.Implementation.Domain.Entities.AccessCode", b =>
                {
                    b.HasOne("Devon4Net.WebAPI.Implementation.Domain.Entities.DailyQueue", "DailyQueue")
                        .WithMany("AccessCodes")
                        .HasForeignKey("DailyQueueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Devon4Net.WebAPI.Implementation.Domain.Entities.Visitor", "Visitor")
                        .WithOne("AccessCode")
                        .HasForeignKey("Devon4Net.WebAPI.Implementation.Domain.Entities.AccessCode", "VisitorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
