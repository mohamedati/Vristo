using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CartID = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UpdatedAt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DeletedAt = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.Id);
                    table.ForeignKey(
                        name: "Fk_Cart_CreateBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "Fk_Cart_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "Fk_Cart_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UpdatedAt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DeletedAt = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "Fk_Order_CreateBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "Fk_Order_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "Fk_Order_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EnName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ArDescription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    EnDescription = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UpdatedAt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DeletedAt = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.Id);
                    table.ForeignKey(
                        name: "Fk_ProductCategories_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "Fk_ProductCategories_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "Fk_ProductCategory_CreateBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EnName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ArTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EnTitle = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ArDescription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    EnDescription = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UsersNotified = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UpdatedAt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DeletedAt = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "Fk_Product_Category",
                        column: x => x.CategoryID,
                        principalTable: "ProductCategory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "Fk_Product_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "Fk_Product_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "Fk_Product_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CartProduct",
                columns: table => new
                {
                    CartID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UpdatedAt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DeletedAt = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartProduct", x => new { x.ProductID, x.CartID });
                    table.ForeignKey(
                        name: "FK_Cart_cartProducts",
                        column: x => x.CartID,
                        principalTable: "Cart",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Product_cartProducts",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "Fk_cartProducts_CreateBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "Fk_cartProducts_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "Fk_cartProducts_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UpdatedAt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DeletedAt = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_Order_OrderProducts",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Product_OrderProducts",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "Fk_OrderProduct_CreateBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "Fk_OrderProduct_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "Fk_OrderProduct_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CartID",
                table: "AspNetUsers",
                column: "CartID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_CreatedBy",
                table: "Cart",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_DeletedBy",
                table: "Cart",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_UpdatedBy",
                table: "Cart",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_CartProduct_CartID",
                table: "CartProduct",
                column: "CartID");

            migrationBuilder.CreateIndex(
                name: "IX_CartProduct_CreatedBy",
                table: "CartProduct",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_CartProduct_DeletedBy",
                table: "CartProduct",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_CartProduct_UpdatedBy",
                table: "CartProduct",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CreatedBy",
                table: "Order",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Order_DeletedBy",
                table: "Order",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UpdatedBy",
                table: "Order",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_CreatedBy",
                table: "OrderProduct",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_DeletedBy",
                table: "OrderProduct",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_ProductId",
                table: "OrderProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_UpdatedBy",
                table: "OrderProduct",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryID",
                table: "Product",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CreatedBy",
                table: "Product",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Product_DeletedBy",
                table: "Product",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Product_UpdatedBy",
                table: "Product",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_CreatedBy",
                table: "ProductCategory",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_DeletedBy",
                table: "ProductCategory",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_UpdatedBy",
                table: "ProductCategory",
                column: "UpdatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_User",
                table: "AspNetUsers",
                column: "CartID",
                principalTable: "Cart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Fk_Cart_CreateBy",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "Fk_Cart_DeletedBy",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "Fk_Cart_UpdatedBy",
                table: "Cart");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CartProduct");

            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Cart");
        }
    }
}
