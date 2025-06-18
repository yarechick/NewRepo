using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Krispy.AccessData.Migrations
{
    /// <inheritdoc />
    public partial class crea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "cat");

            migrationBuilder.EnsureSchema(
                name: "trn");

            migrationBuilder.EnsureSchema(
                name: "usr");

            migrationBuilder.CreateTable(
                name: "Cliente",
                schema: "cat",
                columns: table => new
                {
                    clienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    apellidoPaterno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descuento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    numeroTelefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    correoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.clienteId);
                });

            migrationBuilder.CreateTable(
                name: "EstatusOrden",
                schema: "cat",
                columns: table => new
                {
                    estatusOrdenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    descipcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstatusOrden", x => x.estatusOrdenId);
                });

            migrationBuilder.CreateTable(
                name: "MetodoPago",
                schema: "cat",
                columns: table => new
                {
                    metodoPagoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetodoPago", x => x.metodoPagoId);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                schema: "usr",
                columns: table => new
                {
                    rolId = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    fechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.rolId);
                });

            migrationBuilder.CreateTable(
                name: "Sucursal",
                schema: "cat",
                columns: table => new
                {
                    sucursalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numeroTelefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    correoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sucursal", x => x.sucursalId);
                });

            migrationBuilder.CreateTable(
                name: "TipoProducto",
                schema: "cat",
                columns: table => new
                {
                    tipoProductoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoProducto", x => x.tipoProductoId);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                schema: "usr",
                columns: table => new
                {
                    usuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombreUsuario = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    rolId = table.Column<short>(type: "smallint", nullable: false),
                    contrasenaHash = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apellidoPaterno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apellidoMaterno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nomberoTelefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    correoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bloqueoFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    bloqueoHabilitado = table.Column<bool>(type: "bit", nullable: false),
                    accesoFalloConteo = table.Column<int>(type: "int", nullable: false),
                    fechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.usuarioId);
                    table.ForeignKey(
                        name: "FK_Usuario_Rol_rolId",
                        column: x => x.rolId,
                        principalSchema: "usr",
                        principalTable: "Rol",
                        principalColumn: "rolId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                schema: "cat",
                columns: table => new
                {
                    productoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    tipoProductoId = table.Column<int>(type: "int", nullable: false),
                    disponible = table.Column<bool>(type: "bit", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.productoId);
                    table.ForeignKey(
                        name: "FK_Producto_TipoProducto_tipoProductoId",
                        column: x => x.tipoProductoId,
                        principalSchema: "cat",
                        principalTable: "TipoProducto",
                        principalColumn: "tipoProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orden",
                schema: "trn",
                columns: table => new
                {
                    ordenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fechaOrden = table.Column<DateTime>(type: "datetime2", nullable: false),
                    usuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    clienteId = table.Column<int>(type: "int", nullable: false),
                    sucursalId = table.Column<int>(type: "int", nullable: false),
                    subTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    impuesto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    descuento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    metodoPagoId = table.Column<int>(type: "int", nullable: false),
                    estatusOrdenId = table.Column<int>(type: "int", nullable: false),
                    creadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modificadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orden", x => x.ordenId);
                    table.ForeignKey(
                        name: "FK_Orden_Cliente_clienteId",
                        column: x => x.clienteId,
                        principalSchema: "cat",
                        principalTable: "Cliente",
                        principalColumn: "clienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orden_EstatusOrden_estatusOrdenId",
                        column: x => x.estatusOrdenId,
                        principalSchema: "cat",
                        principalTable: "EstatusOrden",
                        principalColumn: "estatusOrdenId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orden_MetodoPago_metodoPagoId",
                        column: x => x.metodoPagoId,
                        principalSchema: "cat",
                        principalTable: "MetodoPago",
                        principalColumn: "metodoPagoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orden_Sucursal_sucursalId",
                        column: x => x.sucursalId,
                        principalSchema: "cat",
                        principalTable: "Sucursal",
                        principalColumn: "sucursalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orden_Usuario_usuarioId",
                        column: x => x.usuarioId,
                        principalSchema: "usr",
                        principalTable: "Usuario",
                        principalColumn: "usuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleOrden",
                schema: "trn",
                columns: table => new
                {
                    detalleOrdenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ordenId = table.Column<int>(type: "int", nullable: false),
                    productoId = table.Column<int>(type: "int", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    precioUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    subTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleOrden", x => x.detalleOrdenId);
                    table.ForeignKey(
                        name: "FK_DetalleOrden_Orden_ordenId",
                        column: x => x.ordenId,
                        principalSchema: "trn",
                        principalTable: "Orden",
                        principalColumn: "ordenId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleOrden_Producto_productoId",
                        column: x => x.productoId,
                        principalSchema: "cat",
                        principalTable: "Producto",
                        principalColumn: "productoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleOrden_ordenId",
                schema: "trn",
                table: "DetalleOrden",
                column: "ordenId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleOrden_productoId",
                schema: "trn",
                table: "DetalleOrden",
                column: "productoId");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_clienteId",
                schema: "trn",
                table: "Orden",
                column: "clienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_estatusOrdenId",
                schema: "trn",
                table: "Orden",
                column: "estatusOrdenId");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_metodoPagoId",
                schema: "trn",
                table: "Orden",
                column: "metodoPagoId");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_sucursalId",
                schema: "trn",
                table: "Orden",
                column: "sucursalId");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_usuarioId",
                schema: "trn",
                table: "Orden",
                column: "usuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_tipoProductoId",
                schema: "cat",
                table: "Producto",
                column: "tipoProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_nombreUsuario",
                schema: "usr",
                table: "Usuario",
                column: "nombreUsuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_rolId",
                schema: "usr",
                table: "Usuario",
                column: "rolId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleOrden",
                schema: "trn");

            migrationBuilder.DropTable(
                name: "Orden",
                schema: "trn");

            migrationBuilder.DropTable(
                name: "Producto",
                schema: "cat");

            migrationBuilder.DropTable(
                name: "Cliente",
                schema: "cat");

            migrationBuilder.DropTable(
                name: "EstatusOrden",
                schema: "cat");

            migrationBuilder.DropTable(
                name: "MetodoPago",
                schema: "cat");

            migrationBuilder.DropTable(
                name: "Sucursal",
                schema: "cat");

            migrationBuilder.DropTable(
                name: "Usuario",
                schema: "usr");

            migrationBuilder.DropTable(
                name: "TipoProducto",
                schema: "cat");

            migrationBuilder.DropTable(
                name: "Rol",
                schema: "usr");
        }
    }
}
