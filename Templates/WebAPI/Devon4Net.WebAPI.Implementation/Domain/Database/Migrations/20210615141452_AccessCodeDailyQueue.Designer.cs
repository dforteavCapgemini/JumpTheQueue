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
    [Migration("20210615141452_AccessCodeDailyQueue")]
    partial class AccessCodeDailyQueue
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
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DailyQueueId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Endtime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("TicketNumber")
                        .HasColumnType("int");

                    b.Property<int>("VisitorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DailyQueueId");

                    b.HasIndex("VisitorId")
                        .IsUnique();

                    b.ToTable("AccessCodes");
                });

            modelBuilder.Entity("Devon4Net.WebAPI.Implementation.Domain.Entities.DailyQueue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("AttentionTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("CurrentNumber")
                        .HasColumnType("int");

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("MinAttentionTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DailyQueues");
                });

            modelBuilder.Entity("Devon4Net.WebAPI.Implementation.Domain.Entities.Visitor", b =>
                {
                    b.Property<int>("Id")
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

                    b.HasKey("Id");

                    b.ToTable("Visitors");
                });

            modelBuilder.Entity("Devon4Net.WebAPI.Implementation.Domain.Entities.AccessCode", b =>
                {
                    b.HasOne("Devon4Net.WebAPI.Implementation.Domain.Entities.DailyQueue", "DailyQueue")
                        .WithMany("AccessCodes")
                        .HasForeignKey("DailyQueueId");

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
