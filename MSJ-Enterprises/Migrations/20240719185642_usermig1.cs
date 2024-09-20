using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MSJ_Enterprises.Migrations
{
    /// <inheritdoc />
    public partial class usermig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.CreateTable(
                name: "login",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_login", x => x.uid);
                });

            migrationBuilder.InsertData(
                table: "login",
                columns: new[] { "uid", "Email", "Password" },
                values: new object[] { 1, "muhammadsaadjunejo@gmail.com", "saadjunejo" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "login");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.uid);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "uid", "Email", "Password" },
                values: new object[] { 1, "muhammadsaadjunejo@gmail.com", "saadjunejo" });
        }
    }
}
