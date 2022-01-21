﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProiectDAW2.Models;

namespace ProiectDAW2.Migrations
{
    [DbContext(typeof(BicycleDbContext))]
    [Migration("20220121054241_AddedUsers")]
    partial class AddedUsers
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProiectDAW2.Models.Appointment", b =>
                {
                    b.Property<int>("AppointmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BicycleId")
                        .HasColumnType("int");

                    b.Property<int>("CompetitionId")
                        .HasColumnType("int");

                    b.HasKey("AppointmentId");

                    b.HasIndex("BicycleId");

                    b.HasIndex("CompetitionId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("ProiectDAW2.Models.Bicycle", b =>
                {
                    b.Property<int>("BicycleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FrameNumber")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("BicycleId");

                    b.ToTable("Bicycles");
                });

            modelBuilder.Entity("ProiectDAW2.Models.Competition", b =>
                {
                    b.Property<int>("CompetitionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompetitionName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Length")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Terrain")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CompetitionId");

                    b.ToTable("Competitions");
                });

            modelBuilder.Entity("ProiectDAW2.Models.Description", b =>
                {
                    b.Property<int>("DescriptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BicycleId")
                        .HasColumnType("int");

                    b.Property<string>("BicycleType")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Owner")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("WheelSize")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("DescriptionId");

                    b.HasIndex("BicycleId")
                        .IsUnique();

                    b.ToTable("Descriptions");
                });

            modelBuilder.Entity("ProiectDAW2.Models.Service", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AppointmentDate")
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("BicycleId")
                        .HasColumnType("int");

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<string>("Operation")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ServiceId");

                    b.HasIndex("BicycleId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("ProiectDAW2.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ProiectDAW2.Models.Appointment", b =>
                {
                    b.HasOne("ProiectDAW2.Models.Bicycle", "Bicycle")
                        .WithMany("Appointments")
                        .HasForeignKey("BicycleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProiectDAW2.Models.Competition", "Competition")
                        .WithMany("Appointments")
                        .HasForeignKey("CompetitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bicycle");

                    b.Navigation("Competition");
                });

            modelBuilder.Entity("ProiectDAW2.Models.Description", b =>
                {
                    b.HasOne("ProiectDAW2.Models.Bicycle", "Bicycle")
                        .WithOne("Description")
                        .HasForeignKey("ProiectDAW2.Models.Description", "BicycleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bicycle");
                });

            modelBuilder.Entity("ProiectDAW2.Models.Service", b =>
                {
                    b.HasOne("ProiectDAW2.Models.Bicycle", "Bicycle")
                        .WithMany("Services")
                        .HasForeignKey("BicycleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bicycle");
                });

            modelBuilder.Entity("ProiectDAW2.Models.Bicycle", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Description");

                    b.Navigation("Services");
                });

            modelBuilder.Entity("ProiectDAW2.Models.Competition", b =>
                {
                    b.Navigation("Appointments");
                });
#pragma warning restore 612, 618
        }
    }
}