using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class _111 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    idCategory = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.idCategory);
                });

            migrationBuilder.CreateTable(
                name: "clientGroups",
                columns: table => new
                {
                    idClientGroup = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientGroups", x => x.idClientGroup);
                });

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
                name: "employees",
                columns: table => new
                {
                    idEmployee = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fullName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.idEmployee);
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
                name: "promotions",
                columns: table => new
                {
                    idPromotion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    discount = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_promotions", x => x.idPromotion);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    idRole = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.idRole);
                });

            migrationBuilder.CreateTable(
                name: "roomTypes",
                columns: table => new
                {
                    idRoomType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roomTypes", x => x.idRoomType);
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
                name: "users",
                columns: table => new
                {
                    idUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    firstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    middleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    login = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    idRole = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.idUser);
                    table.ForeignKey(
                        name: "FK_users_roles_idRole",
                        column: x => x.idRole,
                        principalTable: "roles",
                        principalColumn: "idRole",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "services",
                columns: table => new
                {
                    idService = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    idCategory = table.Column<int>(type: "int", nullable: false),
                    idEmployee = table.Column<int>(type: "int", nullable: false),
                    idRoom = table.Column<int>(type: "int", nullable: false),
                    idPromotion = table.Column<int>(type: "int", nullable: true),
                    duration = table.Column<int>(type: "int", nullable: false),
                    idClientGroup = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_services", x => x.idService);
                    table.ForeignKey(
                        name: "FK_services_categories_idCategory",
                        column: x => x.idCategory,
                        principalTable: "categories",
                        principalColumn: "idCategory",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_services_clientGroups_idClientGroup",
                        column: x => x.idClientGroup,
                        principalTable: "clientGroups",
                        principalColumn: "idClientGroup");
                    table.ForeignKey(
                        name: "FK_services_employees_idEmployee",
                        column: x => x.idEmployee,
                        principalTable: "employees",
                        principalColumn: "idEmployee",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_services_promotions_idPromotion",
                        column: x => x.idPromotion,
                        principalTable: "promotions",
                        principalColumn: "idPromotion");
                    table.ForeignKey(
                        name: "FK_services_roomTypes_idRoom",
                        column: x => x.idRoom,
                        principalTable: "roomTypes",
                        principalColumn: "idRoomType",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    idProduct = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idCategory = table.Column<int>(type: "int", nullable: false),
                    idFirm = table.Column<int>(type: "int", nullable: false),
                    idSupplier = table.Column<int>(type: "int", nullable: false),
                    idMaterial = table.Column<int>(type: "int", nullable: false),
                    idCountryManufacturer = table.Column<int>(type: "int", nullable: false),
                    productName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_services_idCategory",
                table: "services",
                column: "idCategory");

            migrationBuilder.CreateIndex(
                name: "IX_services_idClientGroup",
                table: "services",
                column: "idClientGroup");

            migrationBuilder.CreateIndex(
                name: "IX_services_idEmployee",
                table: "services",
                column: "idEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_services_idPromotion",
                table: "services",
                column: "idPromotion");

            migrationBuilder.CreateIndex(
                name: "IX_services_idRoom",
                table: "services",
                column: "idRoom");

            migrationBuilder.CreateIndex(
                name: "IX_users_idRole",
                table: "users",
                column: "idRole");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "services");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "country_Manufacturers");

            migrationBuilder.DropTable(
                name: "firms");

            migrationBuilder.DropTable(
                name: "materials");

            migrationBuilder.DropTable(
                name: "suppliers");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "clientGroups");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "promotions");

            migrationBuilder.DropTable(
                name: "roomTypes");

            migrationBuilder.DropTable(
                name: "roles");
        }
    }
}
