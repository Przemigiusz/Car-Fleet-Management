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
    [DbContext(typeof(CarFleetContext))]
    [Migration("20230908114706_First-Migration")]
    partial class FirstMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CarFleet_Project.Models.Tables.Brand", b =>
                {
                    b.Property<int>("brandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("brandId"));

                    b.Property<string>("brandName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("brandId");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("CarFleet_Project.Models.Tables.Carbody", b =>
                {
                    b.Property<int>("carbodyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("carbodyId"));

                    b.Property<string>("carbodyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("carbodyId");

                    b.ToTable("Carbodies");
                });

            modelBuilder.Entity("CarFleet_Project.Models.Tables.EquipmentElement", b =>
                {
                    b.Property<int>("elementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("elementId"));

                    b.Property<string>("elementName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("elementId");

                    b.ToTable("EquipmentElements");
                });

            modelBuilder.Entity("CarFleet_Project.Models.Tables.Fuel", b =>
                {
                    b.Property<int>("fuelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("fuelId"));

                    b.Property<string>("fuelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("fuelId");

                    b.ToTable("Fuels");
                });

            modelBuilder.Entity("CarFleet_Project.Models.Tables.Model", b =>
                {
                    b.Property<int>("modelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("modelId"));

                    b.Property<int>("brandId")
                        .HasColumnType("int");

                    b.Property<string>("modelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("modelId");

                    b.HasIndex("brandId");

                    b.ToTable("Models");
                });

            modelBuilder.Entity("CarFleet_Project.Models.Tables.PriceRange", b =>
                {
                    b.Property<int>("priceRangeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("priceRangeId"));

                    b.Property<string>("priceRangeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("priceRangeId");

                    b.ToTable("PriceRanges");
                });

            modelBuilder.Entity("CarFleet_Project.Models.Tables.SortingType", b =>
                {
                    b.Property<int>("typeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("typeId"));

                    b.Property<string>("typeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("typeId");

                    b.ToTable("SortingTypes");
                });

            modelBuilder.Entity("CarFleet_Project.Models.Tables.TransmissionType", b =>
                {
                    b.Property<int>("typeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("typeId"));

                    b.Property<string>("typeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("typeId");

                    b.ToTable("TransmissionTypes");
                });

            modelBuilder.Entity("CarFleet_Project.Models.Tables.Vehicle", b =>
                {
                    b.Property<int>("vehicleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("vehicleId"));

                    b.Property<int>("brandId")
                        .HasColumnType("int");

                    b.Property<int>("carbodyId")
                        .HasColumnType("int");

                    b.Property<string>("mileage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("modelId")
                        .HasColumnType("int");

                    b.Property<int>("transmissionTypeId")
                        .HasColumnType("int");

                    b.Property<int>("yearId")
                        .HasColumnType("int");

                    b.HasKey("vehicleId");

                    b.HasIndex("brandId");

                    b.HasIndex("carbodyId");

                    b.HasIndex("modelId");

                    b.HasIndex("transmissionTypeId");

                    b.HasIndex("yearId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("CarFleet_Project.Models.Tables.VehicleImage", b =>
                {
                    b.Property<int>("imageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("imageId"));

                    b.Property<byte[]>("image")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("imageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imageType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("vehicleId")
                        .HasColumnType("int");

                    b.HasKey("imageId");

                    b.HasIndex("vehicleId");

                    b.ToTable("VehicleImages");
                });

            modelBuilder.Entity("CarFleet_Project.Models.Tables.YearOfProduction", b =>
                {
                    b.Property<int>("yearId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("yearId"));

                    b.Property<string>("year")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("yearId");

                    b.ToTable("Years");
                });

            modelBuilder.Entity("EquipmentElementVehicle", b =>
                {
                    b.Property<int>("equipmentelementId")
                        .HasColumnType("int");

                    b.Property<int>("vehiclesvehicleId")
                        .HasColumnType("int");

                    b.HasKey("equipmentelementId", "vehiclesvehicleId");

                    b.HasIndex("vehiclesvehicleId");

                    b.ToTable("EquipmentElementVehicle");
                });

            modelBuilder.Entity("FuelVehicle", b =>
                {
                    b.Property<int>("fuelsfuelId")
                        .HasColumnType("int");

                    b.Property<int>("vehiclesvehicleId")
                        .HasColumnType("int");

                    b.HasKey("fuelsfuelId", "vehiclesvehicleId");

                    b.HasIndex("vehiclesvehicleId");

                    b.ToTable("FuelVehicle");
                });

            modelBuilder.Entity("CarFleet_Project.Models.Tables.Model", b =>
                {
                    b.HasOne("CarFleet_Project.Models.Tables.Brand", "brand")
                        .WithMany("models")
                        .HasForeignKey("brandId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("brand");
                });

            modelBuilder.Entity("CarFleet_Project.Models.Tables.Vehicle", b =>
                {
                    b.HasOne("CarFleet_Project.Models.Tables.Brand", "brand")
                        .WithMany("vehicles")
                        .HasForeignKey("brandId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CarFleet_Project.Models.Tables.Carbody", "carbody")
                        .WithMany("vehicles")
                        .HasForeignKey("carbodyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CarFleet_Project.Models.Tables.Model", "model")
                        .WithMany("vehicles")
                        .HasForeignKey("modelId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CarFleet_Project.Models.Tables.TransmissionType", "transmissionType")
                        .WithMany("vehicles")
                        .HasForeignKey("transmissionTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CarFleet_Project.Models.Tables.YearOfProduction", "yearOfProduction")
                        .WithMany("vehicles")
                        .HasForeignKey("yearId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("brand");

                    b.Navigation("carbody");

                    b.Navigation("model");

                    b.Navigation("transmissionType");

                    b.Navigation("yearOfProduction");
                });

            modelBuilder.Entity("CarFleet_Project.Models.Tables.VehicleImage", b =>
                {
                    b.HasOne("CarFleet_Project.Models.Tables.Vehicle", "vehicle")
                        .WithMany("vehicleImages")
                        .HasForeignKey("vehicleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("vehicle");
                });

            modelBuilder.Entity("EquipmentElementVehicle", b =>
                {
                    b.HasOne("CarFleet_Project.Models.Tables.EquipmentElement", null)
                        .WithMany()
                        .HasForeignKey("equipmentelementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarFleet_Project.Models.Tables.Vehicle", null)
                        .WithMany()
                        .HasForeignKey("vehiclesvehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FuelVehicle", b =>
                {
                    b.HasOne("CarFleet_Project.Models.Tables.Fuel", null)
                        .WithMany()
                        .HasForeignKey("fuelsfuelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarFleet_Project.Models.Tables.Vehicle", null)
                        .WithMany()
                        .HasForeignKey("vehiclesvehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CarFleet_Project.Models.Tables.Brand", b =>
                {
                    b.Navigation("models");

                    b.Navigation("vehicles");
                });

            modelBuilder.Entity("CarFleet_Project.Models.Tables.Carbody", b =>
                {
                    b.Navigation("vehicles");
                });

            modelBuilder.Entity("CarFleet_Project.Models.Tables.Model", b =>
                {
                    b.Navigation("vehicles");
                });

            modelBuilder.Entity("CarFleet_Project.Models.Tables.TransmissionType", b =>
                {
                    b.Navigation("vehicles");
                });

            modelBuilder.Entity("CarFleet_Project.Models.Tables.Vehicle", b =>
                {
                    b.Navigation("vehicleImages");
                });

            modelBuilder.Entity("CarFleet_Project.Models.Tables.YearOfProduction", b =>
                {
                    b.Navigation("vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}
