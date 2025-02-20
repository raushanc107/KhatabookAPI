using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KhataBookApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class booking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    userid = table.Column<int>(type: "INTEGER", nullable: false),
                    carid = table.Column<int>(type: "INTEGER", nullable: false),
                    cityid = table.Column<int>(type: "INTEGER", nullable: false),
                    subscriptiontenure = table.Column<int>(type: "INTEGER", nullable: false),
                    monthlyFees = table.Column<double>(type: "REAL", nullable: false),
                    taxPercentage = table.Column<int>(type: "INTEGER", nullable: false),
                    taxAmount = table.Column<double>(type: "REAL", nullable: false),
                    bookingCharge = table.Column<double>(type: "REAL", nullable: false),
                    processingFees = table.Column<double>(type: "REAL", nullable: false),
                    depositAmount = table.Column<double>(type: "REAL", nullable: false),
                    totalPayableAmount = table.Column<double>(type: "REAL", nullable: false),
                    cretedon = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updatedon = table.Column<DateTime>(type: "TEXT", nullable: true),
                    isActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    isDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");
        }
    }
}
