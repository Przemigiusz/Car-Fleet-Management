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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
