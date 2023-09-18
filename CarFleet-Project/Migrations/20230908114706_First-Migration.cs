using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarFleet_Project.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    brandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    brandName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.brandId);
                });

            migrationBuilder.CreateTable(
                name: "Carbodies",
                columns: table => new
                {
                    carbodyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    carbodyName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carbodies", x => x.carbodyId);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentElements",
                columns: table => new
                {
                    elementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    elementName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentElements", x => x.elementId);
                });

            migrationBuilder.CreateTable(
                name: "Fuels",
                columns: table => new
                {
                    fuelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fuelName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fuels", x => x.fuelId);
                });

            migrationBuilder.CreateTable(
                name: "PriceRanges",
                columns: table => new
                {
                    priceRangeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    priceRangeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceRanges", x => x.priceRangeId);
                });

            migrationBuilder.CreateTable(
                name: "SortingTypes",
                columns: table => new
                {
                    typeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    typeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SortingTypes", x => x.typeId);
                });

            migrationBuilder.CreateTable(
                name: "TransmissionTypes",
                columns: table => new
                {
                    typeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    typeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransmissionTypes", x => x.typeId);
                });

            migrationBuilder.CreateTable(
                name: "Years",
                columns: table => new
                {
                    yearId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    year = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Years", x => x.yearId);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    modelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    modelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    brandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.modelId);
                    table.ForeignKey(
                        name: "FK_Models_Brands_brandId",
                        column: x => x.brandId,
                        principalTable: "Brands",
                        principalColumn: "brandId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    vehicleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    brandId = table.Column<int>(type: "int", nullable: false),
                    modelId = table.Column<int>(type: "int", nullable: false),
                    carbodyId = table.Column<int>(type: "int", nullable: false),
                    yearId = table.Column<int>(type: "int", nullable: false),
                    transmissionTypeId = table.Column<int>(type: "int", nullable: false),
                    mileage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.vehicleId);
                    table.ForeignKey(
                        name: "FK_Vehicles_Brands_brandId",
                        column: x => x.brandId,
                        principalTable: "Brands",
                        principalColumn: "brandId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehicles_Carbodies_carbodyId",
                        column: x => x.carbodyId,
                        principalTable: "Carbodies",
                        principalColumn: "carbodyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehicles_Models_modelId",
                        column: x => x.modelId,
                        principalTable: "Models",
                        principalColumn: "modelId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehicles_TransmissionTypes_transmissionTypeId",
                        column: x => x.transmissionTypeId,
                        principalTable: "TransmissionTypes",
                        principalColumn: "typeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehicles_Years_yearId",
                        column: x => x.yearId,
                        principalTable: "Years",
                        principalColumn: "yearId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentElementVehicle",
                columns: table => new
                {
                    equipmentelementId = table.Column<int>(type: "int", nullable: false),
                    vehiclesvehicleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentElementVehicle", x => new { x.equipmentelementId, x.vehiclesvehicleId });
                    table.ForeignKey(
                        name: "FK_EquipmentElementVehicle_EquipmentElements_equipmentelementId",
                        column: x => x.equipmentelementId,
                        principalTable: "EquipmentElements",
                        principalColumn: "elementId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipmentElementVehicle_Vehicles_vehiclesvehicleId",
                        column: x => x.vehiclesvehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "vehicleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FuelVehicle",
                columns: table => new
                {
                    fuelsfuelId = table.Column<int>(type: "int", nullable: false),
                    vehiclesvehicleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelVehicle", x => new { x.fuelsfuelId, x.vehiclesvehicleId });
                    table.ForeignKey(
                        name: "FK_FuelVehicle_Fuels_fuelsfuelId",
                        column: x => x.fuelsfuelId,
                        principalTable: "Fuels",
                        principalColumn: "fuelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FuelVehicle_Vehicles_vehiclesvehicleId",
                        column: x => x.vehiclesvehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "vehicleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleImages",
                columns: table => new
                {
                    imageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    imageType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    imageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    vehicleId = table.Column<int>(type: "int", nullable: false),
                    image = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleImages", x => x.imageId);
                    table.ForeignKey(
                        name: "FK_VehicleImages_Vehicles_vehicleId",
                        column: x => x.vehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "vehicleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentElementVehicle_vehiclesvehicleId",
                table: "EquipmentElementVehicle",
                column: "vehiclesvehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_FuelVehicle_vehiclesvehicleId",
                table: "FuelVehicle",
                column: "vehiclesvehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_brandId",
                table: "Models",
                column: "brandId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleImages_vehicleId",
                table: "VehicleImages",
                column: "vehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_brandId",
                table: "Vehicles",
                column: "brandId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_carbodyId",
                table: "Vehicles",
                column: "carbodyId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_modelId",
                table: "Vehicles",
                column: "modelId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_transmissionTypeId",
                table: "Vehicles",
                column: "transmissionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_yearId",
                table: "Vehicles",
                column: "yearId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipmentElementVehicle");

            migrationBuilder.DropTable(
                name: "FuelVehicle");

            migrationBuilder.DropTable(
                name: "PriceRanges");

            migrationBuilder.DropTable(
                name: "SortingTypes");

            migrationBuilder.DropTable(
                name: "VehicleImages");

            migrationBuilder.DropTable(
                name: "EquipmentElements");

            migrationBuilder.DropTable(
                name: "Fuels");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Carbodies");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "TransmissionTypes");

            migrationBuilder.DropTable(
                name: "Years");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
