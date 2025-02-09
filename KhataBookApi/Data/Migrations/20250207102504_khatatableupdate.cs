using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KhataBookApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class khatatableupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "Users",
                newName: "Lastname");

            migrationBuilder.AddColumn<string>(
                name: "Firstname",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "userid",
                table: "Khata",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Firstname",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "userid",
                table: "Khata");

            migrationBuilder.RenameColumn(
                name: "Lastname",
                table: "Users",
                newName: "name");
        }
    }
}
