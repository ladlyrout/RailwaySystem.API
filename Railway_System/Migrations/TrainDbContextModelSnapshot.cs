﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RailwaySystem.API.Data;

namespace RailwaySystem.API.Migrations
{
    [DbContext(typeof(TrainDbContext))]
    partial class TrainDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RailwaySystem.API.Models.BankCred", b =>
                {
                    b.Property<int>("BankCredId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BankName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<int?>("UserId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("BankCredId");

                    b.HasIndex("UserId");

                    b.ToTable("bankCred");
                });

            modelBuilder.Entity("RailwaySystem.API.Models.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Classes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("PassengerId")
                        .HasColumnType("int");

                    b.Property<int>("SeatNum")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TrainId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<decimal>("fare")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("BookingId");

                    b.HasIndex("TrainId");

                    b.ToTable("bookings");
                });

            modelBuilder.Entity("RailwaySystem.API.Models.Passenger", b =>
                {
                    b.Property<int>("PassengerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Class")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("gender")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PassengerId");

                    b.ToTable("passenger");
                });

            modelBuilder.Entity("RailwaySystem.API.Models.Quota", b =>
                {
                    b.Property<int>("QuotaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Percentage")
                        .HasColumnType("int");

                    b.Property<string>("SeatId")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<string>("type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QuotaId");

                    b.ToTable("quotas");
                });

            modelBuilder.Entity("RailwaySystem.API.Models.Seat", b =>
                {
                    b.Property<int>("SeatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FirstAC")
                        .HasColumnType("int");

                    b.Property<int>("SecondAC")
                        .HasColumnType("int");

                    b.Property<int>("Sleeper")
                        .HasColumnType("int");

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.Property<int>("TrainId")
                        .HasColumnType("int");

                    b.HasKey("SeatId");

                    b.HasIndex("TrainId");

                    b.ToTable("seat");
                });

            modelBuilder.Entity("RailwaySystem.API.Models.Tickets", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookingId")
                        .HasColumnType("int");

                    b.Property<int>("PassengerId")
                        .HasColumnType("int");

                    b.Property<int>("TrainId")
                        .HasColumnType("int");

                    b.Property<int?>("TransactionId")
                        .HasColumnType("int");

                    b.HasKey("TicketId");

                    b.HasIndex("TransactionId");

                    b.ToTable("tickets");
                });

            modelBuilder.Entity("RailwaySystem.API.Models.Train", b =>
                {
                    b.Property<int>("TrainId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ArrivalDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ArrivalStation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ArrivalTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DepartureStation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartureTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(25)");

                    b.Property<double>("distance")
                        .HasColumnType("float");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("TrainId");

                    b.ToTable("trains");
                });

            modelBuilder.Entity("RailwaySystem.API.Models.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BookingId")
                        .HasColumnType("int");

                    b.Property<decimal>("Fare")
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("TransactionStatus")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.HasKey("TransactionId");

                    b.HasIndex("BookingId");

                    b.ToTable("transaction");
                });

            modelBuilder.Entity("RailwaySystem.API.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Mobile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(25)");

                    b.Property<string>("Role")
                        .HasColumnType("varchar(15)");

                    b.HasKey("UserId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("RailwaySystem.API.Models.BankCred", b =>
                {
                    b.HasOne("RailwaySystem.API.Models.User", null)
                        .WithMany("bankCreds")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RailwaySystem.API.Models.Booking", b =>
                {
                    b.HasOne("RailwaySystem.API.Models.Train", null)
                        .WithMany("bookings")
                        .HasForeignKey("TrainId");
                });

            modelBuilder.Entity("RailwaySystem.API.Models.Seat", b =>
                {
                    b.HasOne("RailwaySystem.API.Models.Train", null)
                        .WithMany("seats")
                        .HasForeignKey("TrainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RailwaySystem.API.Models.Tickets", b =>
                {
                    b.HasOne("RailwaySystem.API.Models.Transaction", null)
                        .WithMany("tickets")
                        .HasForeignKey("TransactionId");
                });

            modelBuilder.Entity("RailwaySystem.API.Models.Transaction", b =>
                {
                    b.HasOne("RailwaySystem.API.Models.Booking", null)
                        .WithMany("transactions")
                        .HasForeignKey("BookingId");
                });

            modelBuilder.Entity("RailwaySystem.API.Models.Booking", b =>
                {
                    b.Navigation("transactions");
                });

            modelBuilder.Entity("RailwaySystem.API.Models.Train", b =>
                {
                    b.Navigation("bookings");

                    b.Navigation("seats");
                });

            modelBuilder.Entity("RailwaySystem.API.Models.Transaction", b =>
                {
                    b.Navigation("tickets");
                });

            modelBuilder.Entity("RailwaySystem.API.Models.User", b =>
                {
                    b.Navigation("bankCreds");
                });
#pragma warning restore 612, 618
        }
    }
}
