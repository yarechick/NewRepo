USE BDKrispy
GO



--INSERT INTO cat.EstatusOrden(nombre,descipcion,activo)VALUES('Pagada','Orden Pagada',1)

INSERT INTO cat.MetodoPago(nombre,descripcion,activo)VALUES('Efectivo','Metodo de Pago Efectivo',1)
INSERT INTO cat.MetodoPago(nombre,descripcion,activo)VALUES('Tarjeta Credito','Metodo de Pago Tarjeta',1)
INSERT INTO cat.MetodoPago(nombre,descripcion,activo)VALUES('Tarjeta Debito','Metodo de Pago Tarjeta',1)

--INSERT INTO cat.Sucursal(nombre,direccion,cp,numeroTelefono,correoElectronico,activo)VALUES('Sucursal 1','S/D','01120','5522554448','wdwer@prueba.com',1)
--INSERT INTO cat.Sucursal(nombre,direccion,cp,numeroTelefono,correoElectronico,activo)VALUES('Sucursal 2','S/D','04011','5522554448','wdwer@prueba.com',1)

INSERT INTO cat.TipoProducto(nombre,descripcion,activo)VALUES('Basico','Producto basico',1)
INSERT INTO cat.TipoProducto(nombre,descripcion,activo)VALUES('Nuevo','Producto nuevo',1)
INSERT INTO cat.TipoProducto(nombre,descripcion,activo)VALUES('Premium','Producto premium',1)

INSERT INTO usr.Rol(nombre,fechaModificacion,activo) VALUES('Administrador',getdate(),1)
INSERT INTO usr.Rol(nombre,fechaModificacion,activo) VALUES('Vendedor',getdate(),1)


INSERT INTO usr.Usuario(usuarioId,nombreUsuario,rolId,contrasenaHash,nombre,apellidoPaterno,apellidoMaterno,nomberoTelefono,correoElectronico,bloqueoFin,bloqueoHabilitado,accesoFalloConteo,fechaModificacion,activo)
VALUES (NEWID(),'Admin',1,'81dc9bdb52d04dc20036dbd8313ed055','Admin','Principal','','5588774455','sfsdfds@prueba.com',getdate(),0,0,getdate(),1)

INSERT INTO cat.Cliente(nombre,apellidoPaterno,descuento,numeroTelefono,correoElectronico,activo)VALUES('Génerico','',0,'5599885566','sdsfds@prueba.com',1)
INSERT INTO cat.Cliente(nombre,apellidoPaterno,descuento,numeroTelefono,correoElectronico,activo)VALUES('Carlo','Loza',0,'5599885566','sdsfds@prueba.com',1)

INSERT INTO cat.Producto(nombre,descripcion,precio,tipoProductoId,disponible,activo)VALUES('producto 1','Sin descripcion',5.90,1,1,1)
INSERT INTO cat.Producto(nombre,descripcion,precio,tipoProductoId,disponible,activo)VALUES('producto 2','Sin descripcion',6.56,1,1,1)
INSERT INTO cat.Producto(nombre,descripcion,precio,tipoProductoId,disponible,activo)VALUES('producto 3','Sin descripcion',9.90,1,1,1)
INSERT INTO cat.Producto(nombre,descripcion,precio,tipoProductoId,disponible,activo)VALUES('producto 4','Sin descripcion',5.99,1,1,1)
INSERT INTO cat.Producto(nombre,descripcion,precio,tipoProductoId,disponible,activo)VALUES('producto 5','Sin descripcion',5.78,1,1,1)
INSERT INTO cat.Producto(nombre,descripcion,precio,tipoProductoId,disponible,activo)VALUES('producto 6','Sin descripcion',8.90,1,1,1)
INSERT INTO cat.Producto(nombre,descripcion,precio,tipoProductoId,disponible,activo)VALUES('producto 7','Sin descripcion',6.50,1,1,1)
INSERT INTO cat.Producto(nombre,descripcion,precio,tipoProductoId,disponible,activo)VALUES('producto 8','Sin descripcion',5.90,1,1,1)
INSERT INTO cat.Producto(nombre,descripcion,precio,tipoProductoId,disponible,activo)VALUES('producto 9','Sin descripcion',10.00,1,1,1)
INSERT INTO cat.Producto(nombre,descripcion,precio,tipoProductoId,disponible,activo)VALUES('producto 10','Sin descripcion',34.50,1,1,1)



--INSERT INTO trn.Orden
--(fechaOrden
--,usuarioId
--,clienteId
--,sucursalId
--,subTotal
--,impuesto
--,descuento
--,total
--,metodoPagoId
--,estatusOrdenId)
--VALUES
--(getdate()
--,'6400F8DD-6CC4-4FAA-946D-C7044EABA7BD'
--,1
--,1
--,5.90
--,0.16
--,0
--,(5.90 *0.16) +5.90 +0
--,1
--,1)

--INSERT INTO trn.DetalleOrden
--(ordenId
--,productoId
--,cantidad
--,precioUnitario
--,subTotal
--)
--VALUES
--(2
--,1
--,1
--,5.90
--,5.90
--)
--GO

GO


