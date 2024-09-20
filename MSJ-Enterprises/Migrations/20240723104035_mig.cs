using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MSJ_Enterprises.Migrations
{
    /// <inheritdoc />
    public partial class mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "customers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PartyName",
                table: "bank",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_customers_Name",
                table: "customers",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_bank_PartyName",
                table: "bank",
                column: "PartyName");

            migrationBuilder.AddForeignKey(
                name: "FK_bank_customers_PartyName",
                table: "bank",
                column: "PartyName",
                principalTable: "customers",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bank_customers_PartyName",
                table: "bank");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_customers_Name",
                table: "customers");

            migrationBuilder.DropIndex(
                name: "IX_bank_PartyName",
                table: "bank");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "customers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "PartyName",
                table: "bank",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
