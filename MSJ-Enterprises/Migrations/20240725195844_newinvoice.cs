using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MSJ_Enterprises.Migrations
{
    /// <inheritdoc />
    public partial class newinvoice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleInvoice_customers_CustomerId",
                table: "SaleInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleItem_SaleInvoice_ID",
                table: "SaleItem");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleItem_items_ItemID",
                table: "SaleItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SaleItem",
                table: "SaleItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SaleInvoice",
                table: "SaleInvoice");

            migrationBuilder.RenameTable(
                name: "SaleItem",
                newName: "saleItems");

            migrationBuilder.RenameTable(
                name: "SaleInvoice",
                newName: "invoices");

            migrationBuilder.RenameIndex(
                name: "IX_SaleItem_ItemID",
                table: "saleItems",
                newName: "IX_saleItems_ItemID");

            migrationBuilder.RenameIndex(
                name: "IX_SaleInvoice_CustomerId",
                table: "invoices",
                newName: "IX_invoices_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_saleItems",
                table: "saleItems",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_invoices",
                table: "invoices",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_invoices_customers_CustomerId",
                table: "invoices",
                column: "CustomerId",
                principalTable: "customers",
                principalColumn: "Cid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_saleItems_invoices_ID",
                table: "saleItems",
                column: "ID",
                principalTable: "invoices",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_saleItems_items_ItemID",
                table: "saleItems",
                column: "ItemID",
                principalTable: "items",
                principalColumn: "Iid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_invoices_customers_CustomerId",
                table: "invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_saleItems_invoices_ID",
                table: "saleItems");

            migrationBuilder.DropForeignKey(
                name: "FK_saleItems_items_ItemID",
                table: "saleItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_saleItems",
                table: "saleItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_invoices",
                table: "invoices");

            migrationBuilder.RenameTable(
                name: "saleItems",
                newName: "SaleItem");

            migrationBuilder.RenameTable(
                name: "invoices",
                newName: "SaleInvoice");

            migrationBuilder.RenameIndex(
                name: "IX_saleItems_ItemID",
                table: "SaleItem",
                newName: "IX_SaleItem_ItemID");

            migrationBuilder.RenameIndex(
                name: "IX_invoices_CustomerId",
                table: "SaleInvoice",
                newName: "IX_SaleInvoice_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SaleItem",
                table: "SaleItem",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SaleInvoice",
                table: "SaleInvoice",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleInvoice_customers_CustomerId",
                table: "SaleInvoice",
                column: "CustomerId",
                principalTable: "customers",
                principalColumn: "Cid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleItem_SaleInvoice_ID",
                table: "SaleItem",
                column: "ID",
                principalTable: "SaleInvoice",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleItem_items_ItemID",
                table: "SaleItem",
                column: "ItemID",
                principalTable: "items",
                principalColumn: "Iid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
