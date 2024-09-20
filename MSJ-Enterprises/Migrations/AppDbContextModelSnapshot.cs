﻿// <auto-generated />
using MSJ_Enterprises.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MSJ_Enterprises.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MSJ_Enterprises.Models.Bank", b =>
                {
                    b.Property<int>("Tid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Tid"));

                    b.Property<string>("ChqNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Credit")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Debit")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Tid");

                    b.HasIndex("CustomerId");

                    b.ToTable("bank");
                });

            modelBuilder.Entity("MSJ_Enterprises.Models.Customers", b =>
                {
                    b.Property<int>("Cid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Cid"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opening_Date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Cid");

                    b.ToTable("customers");
                });

            modelBuilder.Entity("MSJ_Enterprises.Models.Item", b =>
                {
                    b.Property<int>("Iid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Iid"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pack")
                        .HasColumnType("int");

                    b.Property<int>("Purchase_Rate")
                        .HasColumnType("int");

                    b.Property<int>("Sale_Rate")
                        .HasColumnType("int");

                    b.HasKey("Iid");

                    b.ToTable("items");
                });

            modelBuilder.Entity("MSJ_Enterprises.Models.Login", b =>
                {
                    b.Property<int>("uid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("uid"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("uid");

                    b.ToTable("login");

                    b.HasData(
                        new
                        {
                            uid = 1,
                            Email = "muhammadsaadjunejo@gmail.com",
                            Name = "Muhammad-Saad",
                            Password = "saadjunejo",
                            Role = "Admin"
                        });
                });

            modelBuilder.Entity("MSJ_Enterprises.Models.PurchaseInvoice", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CustomerId");

                    b.ToTable("PurchaseInvoice");
                });

            modelBuilder.Entity("MSJ_Enterprises.Models.PurchaseItem", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.Property<int>("ItemID")
                        .HasColumnType("int");

                    b.Property<int>("Qty")
                        .HasColumnType("int");

                    b.Property<int>("Rate")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ItemID");

                    b.ToTable("PurchaseItem");
                });

            modelBuilder.Entity("MSJ_Enterprises.Models.SaleInvoice", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CustomerId");

                    b.ToTable("invoices");
                });

            modelBuilder.Entity("MSJ_Enterprises.Models.SaleItem", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.Property<int>("ItemID")
                        .HasColumnType("int");

                    b.Property<int>("Qty")
                        .HasColumnType("int");

                    b.Property<int>("Rate")
                        .HasColumnType("int");

                    b.Property<int>("saleinvoiceID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ItemID");

                    b.HasIndex("saleinvoiceID");

                    b.ToTable("saleItems");
                });

            modelBuilder.Entity("MSJ_Enterprises.Models.Bank", b =>
                {
                    b.HasOne("MSJ_Enterprises.Models.Customers", "Customers")
                        .WithMany("Bank")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customers");
                });

            modelBuilder.Entity("MSJ_Enterprises.Models.PurchaseInvoice", b =>
                {
                    b.HasOne("MSJ_Enterprises.Models.Customers", "Customers")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customers");
                });

            modelBuilder.Entity("MSJ_Enterprises.Models.PurchaseItem", b =>
                {
                    b.HasOne("MSJ_Enterprises.Models.PurchaseInvoice", "PurchaseInvoice")
                        .WithMany("PurchaseItems")
                        .HasForeignKey("ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MSJ_Enterprises.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("PurchaseInvoice");
                });

            modelBuilder.Entity("MSJ_Enterprises.Models.SaleInvoice", b =>
                {
                    b.HasOne("MSJ_Enterprises.Models.Customers", "Customers")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customers");
                });

            modelBuilder.Entity("MSJ_Enterprises.Models.SaleItem", b =>
                {
                    b.HasOne("MSJ_Enterprises.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MSJ_Enterprises.Models.SaleInvoice", "SaleInvoice")
                        .WithMany("SaleItems")
                        .HasForeignKey("saleinvoiceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("SaleInvoice");
                });

            modelBuilder.Entity("MSJ_Enterprises.Models.Customers", b =>
                {
                    b.Navigation("Bank");
                });

            modelBuilder.Entity("MSJ_Enterprises.Models.PurchaseInvoice", b =>
                {
                    b.Navigation("PurchaseItems");
                });

            modelBuilder.Entity("MSJ_Enterprises.Models.SaleInvoice", b =>
                {
                    b.Navigation("SaleItems");
                });
#pragma warning restore 612, 618
        }
    }
}
