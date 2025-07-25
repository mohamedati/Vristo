﻿// <auto-generated />
using System;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250712203649_handleDates")]
    partial class handleDates
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<int>("CartID")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RefreshTokenExpiredAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("CartID")
                        .IsUnique();

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("DeletedBy");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("Cart", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.CartProduct", b =>
                {
                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("CartID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ProductID", "CartID");

                    b.HasIndex("CartID");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("DeletedBy");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("CartProduct", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("DeletedBy");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.OrderProduct", b =>
                {
                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("DeletedBy");

                    b.HasIndex("ProductId");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("OrderProduct", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ArDescription")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("ArName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ArTitle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EnDescription")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("EnName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("EnTitle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("UsersNotified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.HasKey("Id");

                    b.HasIndex("CategoryID");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("DeletedBy");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ArDescription")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("ArName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EnDescription")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("EnName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("DeletedBy");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("ProductCategory", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.WishList", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CustomerID")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("CustomerID");

                    b.HasIndex("DeletedBy");

                    b.HasIndex("ProductID");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("WishList", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.ApplicationUser", b =>
                {
                    b.HasOne("Domain.Entities.Cart", "Cart")
                        .WithOne("ApplicationUser")
                        .HasForeignKey("Domain.Entities.ApplicationUser", "CartID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Cart_User");

                    b.Navigation("Cart");
                });

            modelBuilder.Entity("Domain.Entities.Cart", b =>
                {
                    b.HasOne("Domain.Entities.ApplicationUser", "Creator")
                        .WithMany("CartsCreatedBy")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("Fk_Cart_CreateBy");

                    b.HasOne("Domain.Entities.ApplicationUser", "Deleter")
                        .WithMany("CartsDeletedBy")
                        .HasForeignKey("DeletedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("Fk_Cart_DeletedBy");

                    b.HasOne("Domain.Entities.ApplicationUser", "Updater")
                        .WithMany("CartsUpdatedBy")
                        .HasForeignKey("UpdatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("Fk_Cart_UpdatedBy");

                    b.Navigation("Creator");

                    b.Navigation("Deleter");

                    b.Navigation("Updater");
                });

            modelBuilder.Entity("Domain.Entities.CartProduct", b =>
                {
                    b.HasOne("Domain.Entities.Cart", "Cart")
                        .WithMany("cartProducts")
                        .HasForeignKey("CartID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Cart_cartProducts");

                    b.HasOne("Domain.Entities.ApplicationUser", "Creator")
                        .WithMany("CartProductsCreatedBy")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("Fk_cartProducts_CreateBy");

                    b.HasOne("Domain.Entities.ApplicationUser", "Deleter")
                        .WithMany("CartProductsDeletedBy")
                        .HasForeignKey("DeletedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("Fk_cartProducts_DeletedBy");

                    b.HasOne("Domain.Entities.Product", "Product")
                        .WithMany("CartProducts")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Product_cartProducts");

                    b.HasOne("Domain.Entities.ApplicationUser", "Updater")
                        .WithMany("CartProductsUpdatedBy")
                        .HasForeignKey("UpdatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("Fk_cartProducts_UpdatedBy");

                    b.Navigation("Cart");

                    b.Navigation("Creator");

                    b.Navigation("Deleter");

                    b.Navigation("Product");

                    b.Navigation("Updater");
                });

            modelBuilder.Entity("Domain.Entities.Order", b =>
                {
                    b.HasOne("Domain.Entities.ApplicationUser", "Creator")
                        .WithMany("OrderCreatedBy")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("Fk_Order_CreateBy");

                    b.HasOne("Domain.Entities.ApplicationUser", "Deleter")
                        .WithMany("OrderDeletedBy")
                        .HasForeignKey("DeletedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("Fk_Order_DeletedBy");

                    b.HasOne("Domain.Entities.ApplicationUser", "Updater")
                        .WithMany("OrderUpdatedBy")
                        .HasForeignKey("UpdatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("Fk_Order_UpdatedBy");

                    b.Navigation("Creator");

                    b.Navigation("Deleter");

                    b.Navigation("Updater");
                });

            modelBuilder.Entity("Domain.Entities.OrderProduct", b =>
                {
                    b.HasOne("Domain.Entities.ApplicationUser", "Creator")
                        .WithMany("OrderProductsCreatedBy")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("Fk_OrderProduct_CreateBy");

                    b.HasOne("Domain.Entities.ApplicationUser", "Deleter")
                        .WithMany("OrderProductsDeletedBy")
                        .HasForeignKey("DeletedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("Fk_OrderProduct_DeletedBy");

                    b.HasOne("Domain.Entities.Order", "Order")
                        .WithMany("OrderProducts")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Order_OrderProducts");

                    b.HasOne("Domain.Entities.Product", "Product")
                        .WithMany("OrderProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Product_OrderProducts");

                    b.HasOne("Domain.Entities.ApplicationUser", "Updater")
                        .WithMany("OrderProductsUpdatedBy")
                        .HasForeignKey("UpdatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("Fk_OrderProduct_UpdatedBy");

                    b.Navigation("Creator");

                    b.Navigation("Deleter");

                    b.Navigation("Order");

                    b.Navigation("Product");

                    b.Navigation("Updater");
                });

            modelBuilder.Entity("Domain.Entities.Product", b =>
                {
                    b.HasOne("Domain.Entities.ProductCategory", "Category")
                        .WithMany("Product")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("Fk_Product_Category");

                    b.HasOne("Domain.Entities.ApplicationUser", "Creator")
                        .WithMany("ProductsCreatedBy")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("Fk_Product_CreatedBy");

                    b.HasOne("Domain.Entities.ApplicationUser", "Deleter")
                        .WithMany("ProductsDeletedBy")
                        .HasForeignKey("DeletedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("Fk_Product_DeletedBy");

                    b.HasOne("Domain.Entities.ApplicationUser", "Updater")
                        .WithMany("ProductsUpdatedBy")
                        .HasForeignKey("UpdatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("Fk_Product_UpdatedBy");

                    b.Navigation("Category");

                    b.Navigation("Creator");

                    b.Navigation("Deleter");

                    b.Navigation("Updater");
                });

            modelBuilder.Entity("Domain.Entities.ProductCategory", b =>
                {
                    b.HasOne("Domain.Entities.ApplicationUser", "Creator")
                        .WithMany("ProductCategoriesCreatedBy")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("Fk_ProductCategory_CreateBy");

                    b.HasOne("Domain.Entities.ApplicationUser", "Deleter")
                        .WithMany("ProductCategoriesDeletedBy")
                        .HasForeignKey("DeletedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("Fk_ProductCategories_DeletedBy");

                    b.HasOne("Domain.Entities.ApplicationUser", "Updater")
                        .WithMany("ProductCategoriesUpdatedBy")
                        .HasForeignKey("UpdatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("Fk_ProductCategories_UpdatedBy");

                    b.Navigation("Creator");

                    b.Navigation("Deleter");

                    b.Navigation("Updater");
                });

            modelBuilder.Entity("Domain.Entities.WishList", b =>
                {
                    b.HasOne("Domain.Entities.ApplicationUser", "Creator")
                        .WithMany("WishListCreatedBy")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("Fk_WishList_CreateBy");

                    b.HasOne("Domain.Entities.ApplicationUser", "User")
                        .WithMany("Wishes")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_WishList_Customer");

                    b.HasOne("Domain.Entities.ApplicationUser", "Deleter")
                        .WithMany("WishListDeletedBy")
                        .HasForeignKey("DeletedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("Fk_WishList_DeletedBy");

                    b.HasOne("Domain.Entities.Product", "Product")
                        .WithMany("Wishes")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_WishList_Product");

                    b.HasOne("Domain.Entities.ApplicationUser", "Updater")
                        .WithMany("WishListUpdatedBy")
                        .HasForeignKey("UpdatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("Fk_WishList_UpdatedBy");

                    b.Navigation("Creator");

                    b.Navigation("Deleter");

                    b.Navigation("Product");

                    b.Navigation("Updater");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.ApplicationUser", b =>
                {
                    b.Navigation("CartProductsCreatedBy");

                    b.Navigation("CartProductsDeletedBy");

                    b.Navigation("CartProductsUpdatedBy");

                    b.Navigation("CartsCreatedBy");

                    b.Navigation("CartsDeletedBy");

                    b.Navigation("CartsUpdatedBy");

                    b.Navigation("OrderCreatedBy");

                    b.Navigation("OrderDeletedBy");

                    b.Navigation("OrderProductsCreatedBy");

                    b.Navigation("OrderProductsDeletedBy");

                    b.Navigation("OrderProductsUpdatedBy");

                    b.Navigation("OrderUpdatedBy");

                    b.Navigation("ProductCategoriesCreatedBy");

                    b.Navigation("ProductCategoriesDeletedBy");

                    b.Navigation("ProductCategoriesUpdatedBy");

                    b.Navigation("ProductsCreatedBy");

                    b.Navigation("ProductsDeletedBy");

                    b.Navigation("ProductsUpdatedBy");

                    b.Navigation("WishListCreatedBy");

                    b.Navigation("WishListDeletedBy");

                    b.Navigation("WishListUpdatedBy");

                    b.Navigation("Wishes");
                });

            modelBuilder.Entity("Domain.Entities.Cart", b =>
                {
                    b.Navigation("ApplicationUser")
                        .IsRequired();

                    b.Navigation("cartProducts");
                });

            modelBuilder.Entity("Domain.Entities.Order", b =>
                {
                    b.Navigation("OrderProducts");
                });

            modelBuilder.Entity("Domain.Entities.Product", b =>
                {
                    b.Navigation("CartProducts");

                    b.Navigation("OrderProducts");

                    b.Navigation("Wishes");
                });

            modelBuilder.Entity("Domain.Entities.ProductCategory", b =>
                {
                    b.Navigation("Product");
                });
#pragma warning restore 612, 618
        }
    }
}
