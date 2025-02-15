using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KhataBookApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class cartablecolumnaddedforimageurl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "imageURL",
                table: "Cars",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imageURL",
                table: "Cars");
        }
    }
}
