﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using backend.Context;

namespace backend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210305182355_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("backend.Models.Categories", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EntryDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("backend.Models.Employers", b =>
                {
                    b.Property<int>("EmployerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("CellPhone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EntryDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("JobRol")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Salary")
                        .HasColumnType("TEXT");

                    b.Property<string>("SocialId")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("UsersUserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("EmployerId");

                    b.HasIndex("UsersUserId");

                    b.ToTable("Employers");
                });

            modelBuilder.Entity("backend.Models.Products", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("BuyPrince")
                        .HasColumnType("TEXT");

                    b.Property<int?>("CategoriesCategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EntryDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProductBrand")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("QuantityInStock")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("SalePrice")
                        .HasColumnType("TEXT");

                    b.Property<int?>("SuppliersSuplierId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("UsersUserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("supplierId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoriesCategoryId");

                    b.HasIndex("SuppliersSuplierId");

                    b.HasIndex("UsersUserId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("backend.Models.Sales", b =>
                {
                    b.Property<int>("SalesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ActualDate")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Discount")
                        .HasColumnType("TEXT");

                    b.Property<int>("EmployerId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("EmployersEmployerId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("ITBIS")
                        .HasColumnType("REAL");

                    b.Property<decimal>("SubTotal")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Total")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("UsersUserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("SalesId");

                    b.HasIndex("EmployersEmployerId");

                    b.HasIndex("UsersUserId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("backend.Models.SalesDetails", b =>
                {
                    b.Property<int>("SalesDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SaleId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("SalesId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("SalesDetailsId");

                    b.HasIndex("SalesId");

                    b.ToTable("SalesDetails");
                });

            modelBuilder.Entity("backend.Models.Shops", b =>
                {
                    b.Property<int>("ShopId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Discount")
                        .HasColumnType("TEXT");

                    b.Property<double>("ITBIS")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("ShopDate")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("SubTotal")
                        .HasColumnType("TEXT");

                    b.Property<int>("SupplierId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("SuppliersSuplierId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Total")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("UsersUserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ShopId");

                    b.HasIndex("SuppliersSuplierId");

                    b.HasIndex("UsersUserId");

                    b.ToTable("Shops");
                });

            modelBuilder.Entity("backend.Models.ShopsDetails", b =>
                {
                    b.Property<int>("ShopDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ShopId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("ShopDetailId");

                    b.HasIndex("ShopId");

                    b.ToTable("ShopsDetails");
                });

            modelBuilder.Entity("backend.Models.Suppliers", b =>
                {
                    b.Property<int>("SuplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CellPhone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EntryDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.Property<string>("SuplierLastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SuplierName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("UsersUserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("SuplierId");

                    b.HasIndex("UsersUserId");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("backend.Models.Users", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CellPhoneNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EntryDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.Property<string>("SexType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SocialId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserRol")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("backend.Models.Categories", b =>
                {
                    b.HasOne("backend.Models.Users", "User")
                        .WithMany("Categories")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("backend.Models.Employers", b =>
                {
                    b.HasOne("backend.Models.Users", "Users")
                        .WithMany("Employers")
                        .HasForeignKey("UsersUserId");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("backend.Models.Products", b =>
                {
                    b.HasOne("backend.Models.Categories", "Categories")
                        .WithMany("Products")
                        .HasForeignKey("CategoriesCategoryId");

                    b.HasOne("backend.Models.Suppliers", "Suppliers")
                        .WithMany("Products")
                        .HasForeignKey("SuppliersSuplierId");

                    b.HasOne("backend.Models.Users", "Users")
                        .WithMany("Products")
                        .HasForeignKey("UsersUserId");

                    b.Navigation("Categories");

                    b.Navigation("Suppliers");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("backend.Models.Sales", b =>
                {
                    b.HasOne("backend.Models.Employers", "Employers")
                        .WithMany("Sales")
                        .HasForeignKey("EmployersEmployerId");

                    b.HasOne("backend.Models.Users", "Users")
                        .WithMany("Sales")
                        .HasForeignKey("UsersUserId");

                    b.Navigation("Employers");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("backend.Models.SalesDetails", b =>
                {
                    b.HasOne("backend.Models.Sales", null)
                        .WithMany("SalesDetails")
                        .HasForeignKey("SalesId");
                });

            modelBuilder.Entity("backend.Models.Shops", b =>
                {
                    b.HasOne("backend.Models.Suppliers", "Suppliers")
                        .WithMany("Shops")
                        .HasForeignKey("SuppliersSuplierId");

                    b.HasOne("backend.Models.Users", "Users")
                        .WithMany("Shops")
                        .HasForeignKey("UsersUserId");

                    b.Navigation("Suppliers");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("backend.Models.ShopsDetails", b =>
                {
                    b.HasOne("backend.Models.Shops", null)
                        .WithMany("ShopsDetails")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("backend.Models.Suppliers", b =>
                {
                    b.HasOne("backend.Models.Users", "Users")
                        .WithMany("Supliers")
                        .HasForeignKey("UsersUserId");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("backend.Models.Categories", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("backend.Models.Employers", b =>
                {
                    b.Navigation("Sales");
                });

            modelBuilder.Entity("backend.Models.Sales", b =>
                {
                    b.Navigation("SalesDetails");
                });

            modelBuilder.Entity("backend.Models.Shops", b =>
                {
                    b.Navigation("ShopsDetails");
                });

            modelBuilder.Entity("backend.Models.Suppliers", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("Shops");
                });

            modelBuilder.Entity("backend.Models.Users", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("Employers");

                    b.Navigation("Products");

                    b.Navigation("Sales");

                    b.Navigation("Shops");

                    b.Navigation("Supliers");
                });
#pragma warning restore 612, 618
        }
    }
}