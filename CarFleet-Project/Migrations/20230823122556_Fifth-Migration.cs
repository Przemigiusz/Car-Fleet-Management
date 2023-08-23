using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarFleet_Project.Migrations
{
    /// <inheritdoc />
    public partial class FifthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleVehicleEquipment");

            migrationBuilder.RenameColumn(
                name: "sortingName",
                table: "Sortings",
                newName: "typeName");

            migrationBuilder.RenameColumn(
                name: "sortingId",
                table: "Sortings",
                newName: "typeId");

            migrationBuilder.RenameColumn(
                name: "filterName",
                table: "Filters",
                newName: "priceName");

            migrationBuilder.RenameColumn(
                name: "filterId",
                table: "Filters",
                newName: "priceId");

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
                        name: "FK_EquipmentElementVehicle_VehiclesEquipment_equipmentelementId",
                        column: x => x.equipmentelementId,
                        principalTable: "VehiclesEquipment",
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

            migrationBuilder.RenameColumn(
                name: "typeName",
                table: "Sortings",
                newName: "sortingName");

            migrationBuilder.RenameColumn(
                name: "typeId",
                table: "Sortings",
                newName: "sortingId");

            migrationBuilder.RenameColumn(
                name: "priceName",
                table: "Filters",
                newName: "filterName");

            migrationBuilder.RenameColumn(
                name: "priceId",
                table: "Filters",
                newName: "filterId");

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
    }
}
