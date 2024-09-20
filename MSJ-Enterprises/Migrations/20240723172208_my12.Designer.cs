﻿// <auto-generated />
using MSJ_Enterprises.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MSJ_Enterprises.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240723172208_my12")]
    partial class my12
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("uid");

                    b.ToTable("login");

                    b.HasData(
                        new
                        {
                            uid = 1,
                            Email = "muhammadsaadjunejo@gmail.com",
                            Password = "saadjunejo"
                        });
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

            modelBuilder.Entity("MSJ_Enterprises.Models.Customers", b =>
                {
                    b.Navigation("Bank");
                });
#pragma warning restore 612, 618
        }
    }
}
