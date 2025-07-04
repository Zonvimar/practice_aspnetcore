﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class rm_liz_part : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "country_Manufacturers");

            migrationBuilder.DropTable(
                name: "firms");

            migrationBuilder.DropTable(
                name: "materials");

            migrationBuilder.DropTable(
                name: "suppliers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "country_Manufacturers",
                columns: table => new
                {
                    idCountryManufacturer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    countryManufacturer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_country_Manufacturers", x => x.idCountryManufacturer);
                });

            migrationBuilder.CreateTable(
                name: "firms",
                columns: table => new
                {
                    idFirm = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firm = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_firms", x => x.idFirm);
                });

            migrationBuilder.CreateTable(
                name: "materials",
                columns: table => new
                {
                    idMaterial = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    material = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_materials", x => x.idMaterial);
                });

            migrationBuilder.CreateTable(
                name: "suppliers",
                columns: table => new
                {
                    idSupplier = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    supplier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_suppliers", x => x.idSupplier);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    idProduct = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idCategory = table.Column<int>(type: "int", nullable: false),
                    idCountryManufacturer = table.Column<int>(type: "int", nullable: false),
                    idFirm = table.Column<int>(type: "int", nullable: false),
                    idMaterial = table.Column<int>(type: "int", nullable: false),
                    idSupplier = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    productName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.idProduct);
                    table.ForeignKey(
                        name: "FK_products_categories_idCategory",
                        column: x => x.idCategory,
                        principalTable: "categories",
                        principalColumn: "idCategory",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_products_country_Manufacturers_idCountryManufacturer",
                        column: x => x.idCountryManufacturer,
                        principalTable: "country_Manufacturers",
                        principalColumn: "idCountryManufacturer",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_products_firms_idFirm",
                        column: x => x.idFirm,
                        principalTable: "firms",
                        principalColumn: "idFirm",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_products_materials_idMaterial",
                        column: x => x.idMaterial,
                        principalTable: "materials",
                        principalColumn: "idMaterial",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_products_suppliers_idSupplier",
                        column: x => x.idSupplier,
                        principalTable: "suppliers",
                        principalColumn: "idSupplier",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_products_idCategory",
                table: "products",
                column: "idCategory");

            migrationBuilder.CreateIndex(
                name: "IX_products_idCountryManufacturer",
                table: "products",
                column: "idCountryManufacturer");

            migrationBuilder.CreateIndex(
                name: "IX_products_idFirm",
                table: "products",
                column: "idFirm");

            migrationBuilder.CreateIndex(
                name: "IX_products_idMaterial",
                table: "products",
                column: "idMaterial");

            migrationBuilder.CreateIndex(
                name: "IX_products_idSupplier",
                table: "products",
                column: "idSupplier");
        }
    }
}
