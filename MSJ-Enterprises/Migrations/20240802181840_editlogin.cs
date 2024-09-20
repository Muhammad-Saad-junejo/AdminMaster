using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MSJ_Enterprises.Migrations
{
    /// <inheritdoc />
    public partial class editlogin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "login",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "login",
                keyColumn: "uid",
                keyValue: 1,
                column: "Name",
                value: "Muhammad-Saad");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "login");
        }
    }
}
