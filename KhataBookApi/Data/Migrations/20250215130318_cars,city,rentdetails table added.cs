using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KhataBookApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class carscityrentdetailstableadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    carName = table.Column<string>(type: "TEXT", nullable: false),
                    fuelType = table.Column<string>(type: "TEXT", nullable: false),
                    TransmissionType = table.Column<string>(type: "TEXT", nullable: false),
                    isHybrid = table.Column<bool>(type: "INTEGER", nullable: false),
                    isNew = table.Column<bool>(type: "INTEGER", nullable: false),
                    Segments = table.Column<string>(type: "TEXT", nullable: false),
                    brand = table.Column<string>(type: "TEXT", nullable: false),
                    cretedon = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updatedon = table.Column<DateTime>(type: "TEXT", nullable: true),
                    isActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    isDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    cityname = table.Column<string>(type: "TEXT", nullable: false),
                    cretedon = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updatedon = table.Column<DateTime>(type: "TEXT", nullable: true),
                    isActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    isDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "RentDetails",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    carid = table.Column<int>(type: "INTEGER", nullable: false),
                    cityId = table.Column<string>(type: "TEXT", nullable: false),
                    amount = table.Column<double>(type: "REAL", nullable: false),
                    tax = table.Column<double>(type: "REAL", nullable: false),
                    discount = table.Column<double>(type: "REAL", nullable: false),
                    availablein = table.Column<int>(type: "INTEGER", nullable: false),
                    cretedon = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updatedon = table.Column<DateTime>(type: "TEXT", nullable: true),
                    isActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    isDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentDetails", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "RentDetails");
        }
    }
}
