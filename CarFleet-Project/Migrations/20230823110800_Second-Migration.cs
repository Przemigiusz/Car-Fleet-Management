using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarFleet_Project.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehiclesEquipment",
                columns: table => new
                {
                    elementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    elementName = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiclesEquipment", x => x.elementId);
                });

            migrationBuilder.CreateTable(
                name: "VehicleVehicleEquipment",
                columns: table => new
                {
                    equipmentelementId = table.Column<int>(type: "int", nullable: false),
                    vehiclesvehicleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleVehicleEquipment", x => new { x.equipmentelementId, x.vehiclesvehicleId });
                    table.ForeignKey(
                        name: "FK_VehicleVehicleEquipment_VehiclesEquipment_equipmentelementId",
                        column: x => x.equipmentelementId,
                        principalTable: "VehiclesEquipment",
                        principalColumn: "elementId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleVehicleEquipment_Vehicles_vehiclesvehicleId",
                        column: x => x.vehiclesvehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "vehicleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleVehicleEquipment_vehiclesvehicleId",
                table: "VehicleVehicleEquipment",
                column: "vehiclesvehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleVehicleEquipment");

            migrationBuilder.DropTable(
                name: "VehiclesEquipment");
        }
    }
}
