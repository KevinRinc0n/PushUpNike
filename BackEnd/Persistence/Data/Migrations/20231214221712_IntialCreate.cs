using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class IntialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoria", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "rol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rol", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Contraseña = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "producto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdProducto = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Titulo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Imagen = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdCategoriaFk = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_producto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_producto_categoria_IdCategoriaFk",
                        column: x => x.IdCategoriaFk,
                        principalTable: "categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "pedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FechaPedido = table.Column<DateOnly>(type: "date", nullable: false),
                    IdUsuarioFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pedido_user_IdUsuarioFk",
                        column: x => x.IdUsuarioFk,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "refreshToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdUserFk = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Expires = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Revoked = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_refreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_refreshToken_user_IdUserFk",
                        column: x => x.IdUserFk,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "usersRols",
                columns: table => new
                {
                    IdUsuarioFk = table.Column<int>(type: "int", nullable: false),
                    IdRolFk = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usersRols", x => new { x.IdUsuarioFk, x.IdRolFk });
                    table.ForeignKey(
                        name: "FK_usersRols_rol_IdRolFk",
                        column: x => x.IdRolFk,
                        principalTable: "rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_usersRols_user_IdUsuarioFk",
                        column: x => x.IdUsuarioFk,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "detallePedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdProductoFk = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    IdPedidoFk = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    SubTotal = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detallePedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_detallePedido_pedido_IdPedidoFk",
                        column: x => x.IdPedidoFk,
                        principalTable: "pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detallePedido_producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "producto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "categoria",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Abrigos" },
                    { 2, "Camisetas" },
                    { 3, "Pantalones" }
                });

            migrationBuilder.InsertData(
                table: "rol",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Administrador" },
                    { 2, "Empleado" }
                });

            migrationBuilder.InsertData(
                table: "producto",
                columns: new[] { "Id", "IdCategoriaFk", "IdProducto", "Imagen", "Precio", "Titulo" },
                values: new object[,]
                {
                    { 1, 1, "abrigo-01", "./img/abrigos/01.jpg", 1000.0, "Abrigo 01" },
                    { 2, 1, "abrigo-02", "./img/abrigos/02.jpg", 1000.0, "Abrigo 02" },
                    { 3, 1, "abrigo-03", "./img/abrigos/03.jpg", 1000.0, "Abrigo 03" },
                    { 4, 1, "abrigo-04", "./img/abrigos/04.jpg", 1000.0, "Abrigo 04" },
                    { 5, 1, "abrigo-05", "./img/abrigos/05.jpg", 1000.0, "Abrigo 05" },
                    { 6, 2, "camiseta-01", "./img/camisetas/01.jpg", 1000.0, "Camiseta 01" },
                    { 7, 2, "camiseta-02", "./img/camisetas/02.jpg", 1000.0, "Camiseta 02" },
                    { 8, 2, "camiseta-03", "./img/camisetas/03.jpg", 1000.0, "Camiseta 03" },
                    { 9, 2, "camiseta-04", "./img/camisetas/04.jpg", 1000.0, "Camiseta 04" },
                    { 10, 2, "camiseta-05", "./img/camisetas/05.jpg", 1000.0, "Camiseta 05" },
                    { 11, 2, "camiseta-06", "./img/camisetas/06.jpg", 1000.0, "Camiseta 06" },
                    { 12, 2, "camiseta-07", "./img/camisetas/07.jpg", 1000.0, "Camiseta 07" },
                    { 13, 2, "camiseta-08", "./img/camisetas/08.jpg", 1000.0, "Camiseta 08" },
                    { 14, 3, "pantalon-01", "./img/pantalones/01.jpg", 1000.0, "Pantalón 01" },
                    { 15, 3, "pantalon-02", "./img/pantalones/02.jpg", 1000.0, "Pantalón 02" },
                    { 16, 3, "pantalon-03", "./img/pantalones/03.jpg", 1000.0, "Pantalón 03" },
                    { 17, 3, "pantalon-04", "./img/pantalones/04.jpg", 1000.0, "Pantalón 04" },
                    { 18, 3, "pantalon-05", "./img/pantalones/05.jpg", 1000.0, "Pantalón 05" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_detallePedido_IdPedidoFk",
                table: "detallePedido",
                column: "IdPedidoFk");

            migrationBuilder.CreateIndex(
                name: "IX_detallePedido_ProductoId",
                table: "detallePedido",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_pedido_IdUsuarioFk",
                table: "pedido",
                column: "IdUsuarioFk");

            migrationBuilder.CreateIndex(
                name: "IX_producto_IdCategoriaFk",
                table: "producto",
                column: "IdCategoriaFk");

            migrationBuilder.CreateIndex(
                name: "IX_producto_IdProducto",
                table: "producto",
                column: "IdProducto",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_refreshToken_IdUserFk",
                table: "refreshToken",
                column: "IdUserFk");

            migrationBuilder.CreateIndex(
                name: "IX_usersRols_IdRolFk",
                table: "usersRols",
                column: "IdRolFk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detallePedido");

            migrationBuilder.DropTable(
                name: "refreshToken");

            migrationBuilder.DropTable(
                name: "usersRols");

            migrationBuilder.DropTable(
                name: "pedido");

            migrationBuilder.DropTable(
                name: "producto");

            migrationBuilder.DropTable(
                name: "rol");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "categoria");
        }
    }
}
