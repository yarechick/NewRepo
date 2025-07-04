﻿// <auto-generated />
using System;
using Krispy.AccessData.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Krispy.AccessData.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Krispy.Models.Model.Catalogs.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("clienteId")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteId"));

                    b.Property<bool>("Activo")
                        .HasColumnType("bit")
                        .HasColumnName("activo")
                        .HasColumnOrder(6);

                    b.Property<string>("ApellidoPaterno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("apellidoPaterno")
                        .HasColumnOrder(2);

                    b.Property<string>("CorreoElectronico")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("correoElectronico")
                        .HasColumnOrder(5);

                    b.Property<decimal>("Descuento")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("descuento")
                        .HasColumnOrder(3);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("nombre")
                        .HasColumnOrder(1);

                    b.Property<string>("NumeroTelefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("numeroTelefono")
                        .HasColumnOrder(4);

                    b.HasKey("ClienteId");

                    b.ToTable("Cliente", "cat");
                });

            modelBuilder.Entity("Krispy.Models.Model.Catalogs.EstatusOrden", b =>
                {
                    b.Property<int>("EstatusOrdenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("estatusOrdenId")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EstatusOrdenId"));

                    b.Property<bool>("Activo")
                        .HasColumnType("bit")
                        .HasColumnName("activo")
                        .HasColumnOrder(3);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("descipcion")
                        .HasColumnOrder(2);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("nombre")
                        .HasColumnOrder(1);

                    b.HasKey("EstatusOrdenId");

                    b.ToTable("EstatusOrden", "cat");
                });

            modelBuilder.Entity("Krispy.Models.Model.Catalogs.MetodoPago", b =>
                {
                    b.Property<int>("MetodoPagoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("metodoPagoId")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MetodoPagoId"));

                    b.Property<bool>("Activo")
                        .HasColumnType("bit")
                        .HasColumnName("activo")
                        .HasColumnOrder(3);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("descripcion")
                        .HasColumnOrder(2);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("nombre")
                        .HasColumnOrder(1);

                    b.HasKey("MetodoPagoId");

                    b.ToTable("MetodoPago", "cat");
                });

            modelBuilder.Entity("Krispy.Models.Model.Catalogs.Producto", b =>
                {
                    b.Property<int>("ProductoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("productoId")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductoId"));

                    b.Property<bool>("Activo")
                        .HasColumnType("bit")
                        .HasColumnName("activo")
                        .HasColumnOrder(6);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("descripcion")
                        .HasColumnOrder(2);

                    b.Property<bool>("Disponible")
                        .HasColumnType("bit")
                        .HasColumnName("disponible")
                        .HasColumnOrder(5);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("nombre")
                        .HasColumnOrder(1);

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("precio")
                        .HasColumnOrder(3);

                    b.Property<int>("TipoProductoId")
                        .HasColumnType("int")
                        .HasColumnName("tipoProductoId")
                        .HasColumnOrder(4);

                    b.HasKey("ProductoId");

                    b.HasIndex("TipoProductoId");

                    b.ToTable("Producto", "cat");
                });

            modelBuilder.Entity("Krispy.Models.Model.Catalogs.Sucursal", b =>
                {
                    b.Property<int>("SucursalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("sucursalId")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SucursalId"));

                    b.Property<bool>("Activo")
                        .HasColumnType("bit")
                        .HasColumnName("activo")
                        .HasColumnOrder(6);

                    b.Property<string>("CorreoElectronico")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("correoElectronico")
                        .HasColumnOrder(5);

                    b.Property<string>("Cp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("cp")
                        .HasColumnOrder(3);

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("direccion")
                        .HasColumnOrder(2);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("nombre")
                        .HasColumnOrder(1);

                    b.Property<string>("NumeroTelefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("numeroTelefono")
                        .HasColumnOrder(4);

                    b.HasKey("SucursalId");

                    b.ToTable("Sucursal", "cat");
                });

            modelBuilder.Entity("Krispy.Models.Model.Catalogs.TipoProducto", b =>
                {
                    b.Property<int>("TipoProductoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("tipoProductoId")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TipoProductoId"));

                    b.Property<bool>("Activo")
                        .HasColumnType("bit")
                        .HasColumnName("activo")
                        .HasColumnOrder(3);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("descripcion")
                        .HasColumnOrder(2);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("nombre")
                        .HasColumnOrder(1);

                    b.HasKey("TipoProductoId");

                    b.ToTable("TipoProducto", "cat");
                });

            modelBuilder.Entity("Krispy.Models.Model.Transactional.DetalleOrden", b =>
                {
                    b.Property<int>("DetalleOrdenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("detalleOrdenId")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DetalleOrdenId"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int")
                        .HasColumnName("cantidad")
                        .HasColumnOrder(3);

                    b.Property<int>("OrdenId")
                        .HasColumnType("int")
                        .HasColumnName("ordenId")
                        .HasColumnOrder(1);

                    b.Property<decimal>("PrecioUnitario")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("precioUnitario")
                        .HasColumnOrder(4);

                    b.Property<int>("ProductoId")
                        .HasColumnType("int")
                        .HasColumnName("productoId")
                        .HasColumnOrder(2);

                    b.Property<decimal>("SubTotal")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("subTotal")
                        .HasColumnOrder(5);

                    b.HasKey("DetalleOrdenId");

                    b.HasIndex("OrdenId");

                    b.HasIndex("ProductoId");

                    b.ToTable("DetalleOrden", "trn");
                });

            modelBuilder.Entity("Krispy.Models.Model.Transactional.Orden", b =>
                {
                    b.Property<int>("OrdenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ordenId")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrdenId"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int")
                        .HasColumnName("clienteId")
                        .HasColumnOrder(3);

                    b.Property<string>("CreadoPor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("creadoPor");

                    b.Property<decimal>("Descuento")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("descuento")
                        .HasColumnOrder(7);

                    b.Property<int>("EstatusOrdenId")
                        .HasColumnType("int")
                        .HasColumnName("estatusOrdenId")
                        .HasColumnOrder(10);

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2")
                        .HasColumnName("fechaCreacion");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("datetime2")
                        .HasColumnName("fechaModificacion");

                    b.Property<DateTime>("FechaOrden")
                        .HasColumnType("datetime2")
                        .HasColumnName("fechaOrden")
                        .HasColumnOrder(1);

                    b.Property<decimal>("Impuesto")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("impuesto")
                        .HasColumnOrder(6);

                    b.Property<int>("MetodoPagoId")
                        .HasColumnType("int")
                        .HasColumnName("metodoPagoId")
                        .HasColumnOrder(9);

                    b.Property<string>("ModificadoPor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("modificadoPor");

                    b.Property<decimal>("SubTotal")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("subTotal")
                        .HasColumnOrder(5);

                    b.Property<int>("SucursalId")
                        .HasColumnType("int")
                        .HasColumnName("sucursalId")
                        .HasColumnOrder(4);

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("total")
                        .HasColumnOrder(8);

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("usuarioId")
                        .HasColumnOrder(2);

                    b.HasKey("OrdenId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("EstatusOrdenId");

                    b.HasIndex("MetodoPagoId");

                    b.HasIndex("SucursalId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Orden", "trn");
                });

            modelBuilder.Entity("Krispy.Models.Model.Users.Rol", b =>
                {
                    b.Property<short>("RolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasColumnName("rolId")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("RolId"));

                    b.Property<bool>("Activo")
                        .HasColumnType("bit")
                        .HasColumnName("activo")
                        .HasColumnOrder(3);

                    b.Property<DateTime>("FechaModificacion")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("fechaModificacion")
                        .HasColumnOrder(2);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("nombre")
                        .HasColumnOrder(1);

                    b.HasKey("RolId");

                    b.ToTable("Rol", "usr");
                });

            modelBuilder.Entity("Krispy.Models.Model.Users.Usuario", b =>
                {
                    b.Property<Guid>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("usuarioId")
                        .HasColumnOrder(0);

                    b.Property<int>("AccesoFalloConteo")
                        .HasColumnType("int")
                        .HasColumnName("accesoFalloConteo")
                        .HasColumnOrder(11);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit")
                        .HasColumnName("activo")
                        .HasColumnOrder(13);

                    b.Property<string>("ApellidoMaterno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("apellidoMaterno")
                        .HasColumnOrder(6);

                    b.Property<string>("ApellidoPaterno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("apellidoPaterno")
                        .HasColumnOrder(5);

                    b.Property<DateTime>("BloqueoFin")
                        .HasColumnType("datetime2")
                        .HasColumnName("bloqueoFin")
                        .HasColumnOrder(9);

                    b.Property<bool>("BloqueoHabilitado")
                        .HasColumnType("bit")
                        .HasColumnName("bloqueoHabilitado")
                        .HasColumnOrder(10);

                    b.Property<string>("ContrasenaHash")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("contrasenaHash")
                        .HasColumnOrder(3);

                    b.Property<string>("CorreoElectronico")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("correoElectronico")
                        .HasColumnOrder(8);

                    b.Property<DateTime>("FechaModificacion")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("fechaModificacion")
                        .HasColumnOrder(12);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nombre")
                        .HasColumnOrder(4);

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("nombreUsuario")
                        .HasColumnOrder(1);

                    b.Property<string>("NumeroTelefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nomberoTelefono")
                        .HasColumnOrder(7);

                    b.Property<short>("RolId")
                        .HasColumnType("smallint")
                        .HasColumnName("rolId")
                        .HasColumnOrder(2);

                    b.HasKey("UsuarioId");

                    b.HasIndex("NombreUsuario")
                        .IsUnique();

                    b.HasIndex("RolId");

                    b.ToTable("Usuario", "usr");
                });

            modelBuilder.Entity("Krispy.Models.Model.Catalogs.Producto", b =>
                {
                    b.HasOne("Krispy.Models.Model.Catalogs.TipoProducto", "TipoProducto")
                        .WithMany("Productos")
                        .HasForeignKey("TipoProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoProducto");
                });

            modelBuilder.Entity("Krispy.Models.Model.Transactional.DetalleOrden", b =>
                {
                    b.HasOne("Krispy.Models.Model.Transactional.Orden", "Orden")
                        .WithMany("DetalleOrden")
                        .HasForeignKey("OrdenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Krispy.Models.Model.Catalogs.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Orden");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("Krispy.Models.Model.Transactional.Orden", b =>
                {
                    b.HasOne("Krispy.Models.Model.Catalogs.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Krispy.Models.Model.Catalogs.EstatusOrden", "EstatusOrden")
                        .WithMany("Ordenes")
                        .HasForeignKey("EstatusOrdenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Krispy.Models.Model.Catalogs.MetodoPago", "MetodoPago")
                        .WithMany("Ordenes")
                        .HasForeignKey("MetodoPagoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Krispy.Models.Model.Catalogs.Sucursal", "Sucursal")
                        .WithMany()
                        .HasForeignKey("SucursalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Krispy.Models.Model.Users.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("EstatusOrden");

                    b.Navigation("MetodoPago");

                    b.Navigation("Sucursal");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Krispy.Models.Model.Users.Usuario", b =>
                {
                    b.HasOne("Krispy.Models.Model.Users.Rol", "Rol")
                        .WithMany()
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("Krispy.Models.Model.Catalogs.EstatusOrden", b =>
                {
                    b.Navigation("Ordenes");
                });

            modelBuilder.Entity("Krispy.Models.Model.Catalogs.MetodoPago", b =>
                {
                    b.Navigation("Ordenes");
                });

            modelBuilder.Entity("Krispy.Models.Model.Catalogs.TipoProducto", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("Krispy.Models.Model.Transactional.Orden", b =>
                {
                    b.Navigation("DetalleOrden");
                });
#pragma warning restore 612, 618
        }
    }
}
