using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarFleet_Project.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigrationVC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EquipmentElements",
                columns: table => new
                {
                    elementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    elementName = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentElements", x => x.elementId);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    vehicleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    brand = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    model = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    yearOfProduction = table.Column<string>(type: "nvarchar(4)", nullable: false),
                    mileage = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    fuelType = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    doorsAmount = table.Column<string>(type: "nvarchar(2)", nullable: false),
                    carBodyType = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.vehicleId);
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

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentElementVehicle_vehiclesvehicleId",
                table: "EquipmentElementVehicle",
                column: "vehiclesvehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipmentElementVehicle");

            migrationBuilder.DropTable(
                name: "EquipmentElements");

            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
