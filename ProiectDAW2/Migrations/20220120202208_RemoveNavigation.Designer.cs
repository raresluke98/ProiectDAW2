// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProiectDAW2.Models;

namespace ProiectDAW2.Migrations
{
    [DbContext(typeof(BicycleDbContext))]
    [Migration("20220120202208_RemoveNavigation")]
    partial class RemoveNavigation
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

                    b.ToTable("Services");
                });
#pragma warning restore 612, 618
        }
    }
}
