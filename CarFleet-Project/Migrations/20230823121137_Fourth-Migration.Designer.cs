﻿// <auto-generated />
using CarFleet_Project.Models.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarFleet_Project.Migrations
{
    [DbContext(typeof(VehicleContext))]
    [Migration("20230823121137_Fourth-Migration")]
    partial class FourthMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CarFleet_Project.Models.Filter", b =>
                {
                    b.Property<int>("filterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("filterId"));

                    b.Property<string>("filterName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("filterId");

                    b.ToTable("Filters");
                });

            modelBuilder.Entity("CarFleet_Project.Models.Sorting", b =>
                {
                    b.Property<int>("sortingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("sortingId"));

                    b.Property<string>("sortingName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("sortingId");

                    b.ToTable("Sortings");
                });

            modelBuilder.Entity("CarFleet_Project.Models.Vehicle", b =>
                {
                    b.Property<int>("vehicleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("vehicleId"));

                    b.Property<string>("brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("carBodyType")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("doorsAmount")
                        .IsRequired()
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("fuelType")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("mileage")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("model")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("yearOfProduction")
                        .IsRequired()
                        .HasColumnType("nvarchar(4)");

                    b.HasKey("vehicleId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("CarFleet_Project.Models.VehicleEquipment", b =>
                {
                    b.Property<int>("elementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("elementId"));

                    b.Property<string>("elementName")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("elementId");

                    b.ToTable("VehiclesEquipment");
                });

            modelBuilder.Entity("VehicleVehicleEquipment", b =>
                {
                    b.Property<int>("equipmentelementId")
                        .HasColumnType("int");

                    b.Property<int>("vehiclesvehicleId")
                        .HasColumnType("int");

                    b.HasKey("equipmentelementId", "vehiclesvehicleId");

                    b.HasIndex("vehiclesvehicleId");

                    b.ToTable("VehicleVehicleEquipment");
                });

            modelBuilder.Entity("VehicleVehicleEquipment", b =>
                {
                    b.HasOne("CarFleet_Project.Models.VehicleEquipment", null)
                        .WithMany()
                        .HasForeignKey("equipmentelementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarFleet_Project.Models.Vehicle", null)
                        .WithMany()
                        .HasForeignKey("vehiclesvehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
