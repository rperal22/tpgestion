USE GD1C2017;
GO

/*CREATE SCHEMA SQLGROUP*/
GRANT CONTROL ON SCHEMA	:: SQLGROUP TO gd
GO

IF(OBJECT_ID('SQLGROUP.crear_tablas') IS NOT NULL)
	DROP PROCEDURE SQLGROUP.crear_tablas
GO
/*--Procedure que crea las tabla------*/
CREATE PROCEDURE SQLGROUP.crear_tablas 
AS
BEGIN

	IF OBJECT_ID('SQLGROUP.Chofer_Turno') IS NOT NULL
		DROP TABLE SQLGROUP.Chofer_Turno
	IF OBJECT_ID('SQLGROUP.Auto_Turno') IS NOT NULL
		DROP TABLE SQLGROUP.Auto_Turno
	IF OBJECT_ID('SQLGROUP.Usuarios_Rol') IS NOT NULL
		DROP TABLE SQLGROUP.Usuarios_Rol
	IF OBJECT_ID('SQLGROUP.Factura_Viaje') IS NOT NULL
		DROP TABLE SQLGROUP.Factura_Viaje
	IF OBJECT_ID('SQLGROUP.Viajes') IS NOT NULL
		DROP TABLE SQLGROUP.Viajes
	IF OBJECT_ID('SQLGROUP.Facturas') IS NOT NULL
		DROP TABLE SQLGROUP.Facturas
	IF OBJECT_ID('SQLGROUP.Usuarios') IS NOT NULL
		DROP TABLE SQLGROUP.Usuarios
	IF OBJECT_ID('SQLGROUP.Rol_Funcionalidad') IS NOT NULL
		DROP TABLE SQLGROUP.Rol_Funcionalidad
	IF OBJECT_ID('SQLGROUP.Roles') IS NOT NULL
		DROP TABLE SQLGROUP.Roles
	IF OBJECT_ID('SQLGROUP.Funcionalidades') IS NOT NULL
		DROP TABLE SQLGROUP.Funcionalidades
	IF OBJECT_ID('SQLGROUP.Rendiciones') IS NOT NULL
		DROP TABLE SQLGROUP.Rendiciones
	IF OBJECT_ID('SQLGROUP.Turno') IS NOT NULL
		DROP TABLE SQLGROUP.Turno
	IF OBJECT_ID('SQLGROUP.Automoviles') IS NOT NULL
		DROP TABLE SQLGROUP.Automoviles
	IF OBJECT_ID('SQLGROUP.Choferes') IS NOT NULL
		DROP TABLE SQLGROUP.Choferes
	IF OBJECT_ID('SQLGROUP.Administradores') IS NOT NULL
		DROP TABLE SQLGROUP.Administradores
	IF OBJECT_ID('SQLGROUP.Clientes') IS NOT NULL
		DROP TABLE SQLGROUP.Clientes

	
	 
	CREATE TABLE SQLGROUP.Administradores (
		Admin_Id INTEGER IDENTITY(1,1) PRIMARY KEY,
		Admin_Dni NUMERIC(18,0) UNIQUE,
		Admin_Nombre VARCHAR(255) NOT NULL,
		Admin_Apellido VARCHAR(255) NOT NULL,
		Admin_Telefono NUMERIC(18,0) NOT NULL,
		Admin_Direccion VARCHAR(255) NOT NULL,
		Admin_Mail VARCHAR(255) NOT NULL
	);

	CREATE TABLE SQLGROUP.Choferes (
		Chofer_Id INTEGER IDENTITY(1,1) PRIMARY KEY,
		Chofer_Nombre VARCHAR(255) NOT NULL,
		Chofer_Apellido VARCHAR(255) NOT NULL,
		Chofer_Direccion VARCHAR(255) NOT NULL,
		Chofer_Dni NUMERIC(18,0) UNIQUE NOT NULL,
		Chofer_Telefono NUMERIC(18,0) NOT NULL,
		Chofer_Mail VARCHAR(50),
		Chofer_Fecha_Nac DATETIME NOT NULL
	);

	CREATE TABLE SQLGROUP.Clientes (
		Cliente_Id INTEGER IDENTITY(1,1) PRIMARY KEY,
		Cliente_Dni NUMERIC(18,0) NOT NULL UNIQUE,
		Cliente_Nombre VARCHAR(255) NOT NULL,
		Cliente_Apellido VARCHAR(255) NOT NULL,
		Cliente_Telefono NUMERIC(18,0) NOT NULL,
		Cliente_Direccion VARCHAR(255) NOT NULL,
		Cliente_Mail VARCHAR(255),
		Cliente_Fecha_Nac DATETIME NOT NULL,
		Cliente_Estado VARCHAR(20) NOT NULL DEFAULT 'Habilitado'
	);


	CREATE TABLE SQLGROUP.Automoviles (
		Auto_Patente VARCHAR(10) PRIMARY KEY,
		Auto_Marca VARCHAR(255) NOT NULL,
		Auto_Modelo VARCHAR(255) NOT NULL,
		Auto_Licencia VARCHAR(26),
		Auto_Rodado VARCHAR(10),
		Auto_Estado VARCHAR(20) DEFAULT 'Habilitado',
		Auto_Chofer INTEGER
	);

	CREATE TABLE SQLGROUP.Viajes (
		Viaje_Id INTEGER IDENTITY(1,1) PRIMARY KEY,
		Viaje_Cant_Kilometros NUMERIC(18,0) NOT NULL,
		Viaje_Fecha DATETIME NOT NULL,
		Viaje_Fecha_INIC DATETIME NOT NULL,
		Viaje_Fecha_Fin DATETIME NOT NULL,
		Viaje_Chofer_Id INTEGER NOT NULL,
		Viaje_Auto_Patente VARCHAR(10) NOT NULL,
		Viaje_Turno_Id INTEGER NOT NULL,
		Viaje_Cliente_Id INTEGER NOT NULL
	);

	CREATE TABLE SQLGROUP.Rendiciones (
		Rendicion_Nro NUMERIC(18,0) PRIMARY KEY,
		Rendicion_Fecha DATETIME NOT NULL,
		Rendicion_Importe NUMERIC(18,2) NOT NULL,
		Rendicion_Chofer_Id INTEGER NOT NULL,
		Rendicion_Turno_Id INTEGER NOT NULL
	);

	CREATE TABLE SQLGROUP.Turno (
		Turno_Id INTEGER IDENTITY(1,1) PRIMARY KEY,
		Turno_Hora_Inicio NUMERIC(18,0),
		Turno_Hora_Fin NUMERIC(18,0),
		Turno_Descripcion VARCHAR(255),
		Turno_Valor_Kilometro NUMERIC(18,2),
		Turno_Precio_Base NUMERIC(18,2),
		Turno_Estado VARCHAR(20) DEFAULT 'Habilitado'
	);

	CREATE TABLE SQLGROUP.Facturas (
		Factura_Nro NUMERIC(18,0) PRIMARY KEY,
		Factura_Fecha_Inicio DATETIME NOT NULL,
		Factura_Fecha_Fin DATETIME NOT NULL,
		Factura_Fecha DATETIME NOT NULL,
		Factura_Total NUMERIC(18,2) NOT NULL,
		Factua_Nro_Viajes NUMERIC(18,2) NOT NULL,
		Factura_Cliente_Id INTEGER NOT NULL
	);

	CREATE TABLE SQLGROUP.Roles (
		Rol_Nombre VARCHAR(30) PRIMARY KEY,
		Rol_Descripcion VARCHAR(255) NOT NULL,
		Rol_Estado VARCHAR(20) NOT NULL DEFAULT 'Habilitado'
	);

	CREATE TABLE SQLGROUP.Funcionalidades (
		Func_Nombre VARCHAR(30) PRIMARY KEY,
		Func_Descripcion VARCHAR(255) DEFAULT 'No hay descripcion'
	);

	CREATE TABLE SQLGROUP.Usuarios (
		Usuario_Id VARCHAR(255) PRIMARY KEY,
		Usuario_Password VARCHAR(64) NOT NULL,
		Usuario_DNI NUMERIC(18,0) UNIQUE NOT NULL,
		Usuario_Intentos INTEGER NOT NULL DEFAULT 0,
		Usuario_Estado VARCHAR(20) NOT NULL DEFAULT 'Habilitado'
	);

	CREATE TABLE SQLGROUP.Rol_Funcionalidad(
		RF_Rol_Nombre VARCHAR(30),
		RF_Func_Nombre VARCHAR(30),
		CONSTRAINT pk_rolxfuncionalidad PRIMARY KEY(RF_Rol_Nombre,RF_Func_Nombre)
	);

	CREATE TABLE SQLGROUP.Usuarios_Rol (
		UR_Rol_Nombre VARCHAR(30),
		UR_Usuario_Id VARCHAR(255),
		CONSTRAINT pk_usuarioxrol PRIMARY KEY(UR_Rol_Nombre,UR_Usuario_Id)
	);

	CREATE TABLE SQLGROUP.Factura_Viaje (
		Fv_Viaje_Id INTEGER,
		Fv_Factura_Nro NUMERIC(18,0),
		CONSTRAINT pk_facturaxviaje PRIMARY KEY(Fv_Viaje_Id,Fv_Factura_Nro) 
	);

	CREATE TABLE SQLGROUP.Chofer_Turno (
		Ct_Chofer_Id INTEGER,
		Ct_Turno_Id INTEGER,
		CONSTRAINT pk_choferxturno PRIMARY KEY (Ct_Chofer_Id,Ct_Turno_Id)
	);

	CREATE TABLE SQLGROUP.Auto_Turno (
		AT_Auto_Patente VARCHAR(10),
		AT_Turno_Id INTEGER,
		CONSTRAINT pk_autoxturno PRIMARY KEY (AT_Auto_Patente,AT_Turno_ID)
	);

	/*----Aca crear foreign keys------*/
	ALTER TABLE SQLGROUP.Automoviles ADD
	CONSTRAINT fk_automovil_chofer FOREIGN KEY (Auto_Chofer) REFERENCES SQLGROUP.Choferes(Chofer_Id)
	ON DELETE NO ACTION ON UPDATE CASCADE;

	ALTER TABLE SQLGROUP.Viajes ADD
	CONSTRAINT fk_viajes_chofer FOREIGN KEY (Viaje_Chofer_Id) REFERENCES SQLGROUP.Choferes(Chofer_Id)
	ON DELETE NO ACTION ON UPDATE CASCADE,
	CONSTRAINT fk_viajes_automovil FOREIGN KEY (Viaje_Auto_Patente) REFERENCES SQLGROUP.Automoviles(Auto_Patente)
	ON DELETE NO ACTION ON UPDATE NO ACTION,
	CONSTRAINT fk_viajes_turno FOREIGN KEY (Viaje_Turno_Id) REFERENCES SQLGROUP.Turno(Turno_Id)
	ON DELETE NO ACTION ON UPDATE CASCADE,
	CONSTRAINT fk_viajes_cliente FOREIGN KEY (Viaje_Cliente_Id) REFERENCES SQLGROUP.Clientes(Cliente_Id)
	ON DELETE NO ACTION ON UPDATE CASCADE;

	ALTER TABLE SQLGROUP.Rendiciones ADD
	CONSTRAINT fk_rendiciones_chofer FOREIGN KEY (Rendicion_Chofer_Id) REFERENCES SQLGROUP.Choferes(Chofer_Id)
	ON DELETE NO ACTION ON UPDATE CASCADE,
	CONSTRAINT fk_rendiciones_turno FOREIGN KEY (Rendicion_Turno_Id) REFERENCES SQLGROUP.Turno(Turno_Id)
	ON DELETE NO ACTION ON UPDATE CASCADE;

	ALTER TABLE SQLGROUP.Facturas ADD
	CONSTRAINT fk_factura_cliente FOREIGN KEY (Factura_Cliente_Id) REFERENCES SQLGROUP.Clientes(Cliente_Id)
	ON DELETE NO ACTION ON UPDATE CASCADE;

	ALTER TABLE SQLGROUP.Rol_Funcionalidad ADD
	CONSTRAINT fk_rolfuncionalidad_rol FOREIGN KEY (RF_Rol_Nombre) REFERENCES SQLGROUP.Roles(Rol_Nombre)
	ON DELETE NO ACTION ON UPDATE CASCADE,
	CONSTRAINT fk_rolfuncionalidad_func FOREIGN KEY (RF_Func_Nombre) REFERENCES SQLGROUP.Funcionalidades(Func_Nombre)
	ON DELETE NO ACTION ON UPDATE CASCADE;

	ALTER TABLE SQLGROUP.Usuarios_Rol ADD
	CONSTRAINT fk_usuariorol_rol FOREIGN KEY (UR_Rol_Nombre) REFERENCES SQLGROUP.Roles(Rol_Nombre)
	ON DELETE NO ACTION ON UPDATE CASCADE,
	CONSTRAINT fk_usuariorol_usuario FOREIGN KEY (UR_Usuario_Id) REFERENCES SQLGROUP.Usuarios(Usuario_Id)
	ON DELETE NO ACTION ON UPDATE CASCADE;

	ALTER TABLE SQLGROUP.Factura_Viaje ADD
	CONSTRAINT fk_facturaviaje_viaje FOREIGN KEY (Fv_Viaje_Id) REFERENCES SQLGROUP.Viajes(Viaje_Id)
	ON DELETE NO ACTION ON UPDATE CASCADE,
	CONSTRAINT fk_facturaviaje_factura FOREIGN KEY (Fv_Factura_Nro) REFERENCES SQLGROUP.Facturas(Factura_Nro)
	ON DELETE NO ACTION ON UPDATE NO ACTION;

	ALTER TABLE SQLGROUP.Chofer_Turno ADD
	CONSTRAINT fk_choferturno_chofer FOREIGN KEY (Ct_Chofer_Id) REFERENCES SQLGROUP.Choferes(Chofer_Id)
	ON DELETE NO ACTION ON UPDATE CASCADE,
	CONSTRAINT fk_choferturno_turno FOREIGN KEY (Ct_Turno_Id) REFERENCES SQLGROUP.Turno(Turno_Id)
	ON DELETE NO ACTION ON UPDATE NO ACTION;

	ALTER TABLE SQLGROUP.Auto_Turno ADD
	CONSTRAINT fk_autoturno_auto FOREIGN KEY (AT_Auto_Patente) REFERENCES SQLGROUP.Automoviles(Auto_Patente)
	ON DELETE NO ACTION ON UPDATE CASCADE,
	CONSTRAINT fk_autoturno_turno FOREIGN KEY (At_Turno_Id) REFERENCES SQLGROUP.Turno(Turno_Id)
	ON DELETE NO ACTION ON UPDATE NO ACTION;


	/*--------------------------------*/
END
GO

IF(OBJECT_ID('SQLGROUP.migrar_choferes') IS NOT NULL)
	DROP PROCEDURE SQLGROUP.migrar_choferes
GO

CREATE PROCEDURE SQLGROUP.migrar_choferes
AS
BEGIN
	INSERT INTO SQLGROUP.Choferes (Chofer_Nombre,Chofer_Apellido,Chofer_Direccion,Chofer_Dni,Chofer_Telefono,Chofer_Mail,Chofer_Fecha_Nac)
	SELECT m.Chofer_Nombre,m.Chofer_Apellido,m.Chofer_Direccion,m.Chofer_Dni,m.Chofer_Telefono,m.Chofer_Mail,m.Chofer_Fecha_Nac
	FROM gd_esquema.Maestra as m
	GROUP BY m.Chofer_Nombre,m.Chofer_Apellido,m.Chofer_Direccion,m.Chofer_Dni,m.Chofer_Telefono,m.Chofer_Mail,m.Chofer_Fecha_Nac
END
GO

IF(OBJECT_ID('SQLGROUP.migrar_automoviles') IS NOT NULL)
	DROP PROCEDURE SQLGROUP.migrar_automoviles
GO

CREATE PROCEDURE SQLGROUP.migrar_automoviles
AS
BEGIN
	INSERT INTO SQLGROUP.Automoviles (Auto_Marca,Auto_Modelo,Auto_Patente,Auto_Licencia,Auto_Rodado,Auto_Chofer)
	SELECT m.Auto_Marca, m.Auto_Modelo, m.Auto_Patente, m.Auto_Licencia, m.Auto_Rodado, (SELECT c.Chofer_Id FROM SQLGROUP.Choferes as c WHERE c.Chofer_Dni = m.Chofer_Dni)
	FROM gd_esquema.Maestra as m
	GROUP BY m.Auto_Marca, m.Auto_Modelo, m.Auto_Patente, m.Auto_Licencia, m.Auto_Rodado,m.Chofer_Dni
END
GO

IF(OBJECT_ID('SQLGROUP.migrar_clientes') IS NOT NULL)
	DROP PROCEDURE SQLGROUP.migrar_clientes
GO

CREATE PROCEDURE SQLGROUP.migrar_clientes
AS
BEGIN
	INSERT INTO SQLGROUP.Clientes (Cliente_Nombre,Cliente_Apellido,Cliente_Dni,Cliente_Telefono,Cliente_Direccion,Cliente_Mail,Cliente_Fecha_Nac)
	SELECT m.Cliente_Nombre, m.Cliente_Apellido, m.Cliente_Dni, m.Cliente_Telefono,m.Cliente_Direccion, m.Cliente_Mail, m.Cliente_Fecha_Nac
	FROM gd_esquema.Maestra as m
	GROUP BY m.Cliente_Nombre, m.Cliente_Apellido, m.Cliente_Dni, m.Cliente_Telefono, m.Cliente_Mail, m.Cliente_Fecha_Nac,m.Cliente_Direccion
END
GO

IF(OBJECT_ID('SQLGROUP.crear_administradores') IS NOT NULL)
	DROP PROCEDURE SQLGROUP.crear_administradores
GO

CREATE PROCEDURE SQLGROUP.crear_administradores
AS
BEGIN
	INSERT INTO SQLGROUP.Administradores (Admin_Dni,Admin_Nombre,Admin_Apellido,Admin_Telefono,Admin_Direccion,Admin_Mail)
	VALUES(1569877,'admin','admin',1512345678,'admin','admin@admin.com')
END
GO

IF(OBJECT_ID('SQLGROUP.crear_roles') IS NOT NULL)
	DROP PROCEDURE SQLGROUP.crear_roles
GO

CREATE PROCEDURE SQLGROUP.crear_roles
AS
BEGIN
	INSERT INTO SQLGROUP.Roles
	VALUES ('Administrador','Rol administrativo del sistema');
	INSERT INTO SQLGROUP.Roles
	VALUES ('Cliente','Rol cliente del sistema');
	INSERT INTO SQLGROUP.Roles
	VALUES ('Chofer','Rol chofer del sistema');
END
GO

IF(OBJECT_ID('SQLGROUP.crear_usuarios') IS NOT NULL)
	DROP PROCEDURE SQLGROUP.crear_usuarios
GO

/*Usuario: Nombre Password: Nombre, Falta hacer el trigger que cifra las pass*/
CREATE PROCEDURE SQLGROUP.crear_usuarios
AS
BEGIN
	INSERT INTO SQLGROUP.Usuarios (Usuario_Id, SQLGROUP.cifrado_claves(Usuario_Password),Usuario_DNI) -- se agrega funcion de cifrado de claves
	SELECT Chofer_Nombre + '_' + Chofer_Apellido,Chofer_Nombre,Chofer_Dni 
	FROM SQLGROUP.Choferes

	INSERT INTO SQLGROUP.Usuarios (Usuario_Id, SQLGROUP.cifrado_claves(Usuario_Password),Usuario_DNI)
	SELECT Cliente_Nombre + '_' + Cliente_Apellido,Cliente_Nombre,Cliente_Dni
	FROM SQLGROUP.Clientes,SQLGROUP.Usuarios
	WHERE Cliente_Dni != Usuario_DNI
	GROUP BY Cliente_Nombre,Cliente_Nombre,Cliente_Dni,Cliente_Apellido

END
GO

IF(OBJECT_ID('SQLGROUP.migrar_turnos') IS NOT NULL)
	DROP PROCEDURE SQLGROUP.migrar_turnos
GO

CREATE PROCEDURE SQLGROUP.migrar_turnos
AS
BEGIN
	INSERT INTO SQLGROUP.Turno (Turno_Hora_Inicio,Turno_Hora_Fin,Turno_Descripcion,Turno_Valor_Kilometro, Turno_Precio_Base)
	SELECT m.Turno_Hora_Inicio, m.Turno_Hora_Fin, m.Turno_Descripcion, m.Turno_Valor_Kilometro, m.Turno_Precio_Base
	FROM gd_esquema.Maestra as m
	GROUP BY m.Turno_Hora_Inicio, m.Turno_Hora_Fin, m.Turno_Descripcion, m.Turno_Valor_Kilometro, m.Turno_Precio_Base
END
GO

IF(OBJECT_ID('SQLGROUP.migrar_choferesxturno') IS NOT NULL) 
	DROP PROCEDURE SQLGROUP.migrar_choferesxturno
GO

CREATE PROCEDURE SQLGROUP.migrar_choferesxturno
AS
BEGIN
	INSERT SQLGROUP.Chofer_Turno
	SELECT Chofer_Id, Turno_Id
	FROM gd_esquema.Maestra as m, SQLGROUP.Choferes as c, SQLGROUP.Turno as t
	WHERE m.Chofer_Dni = c.Chofer_Dni AND  t.Turno_Hora_Inicio = m.Turno_Hora_Inicio AND t.Turno_Hora_Fin = m.Turno_Hora_Fin
	GROUP BY Chofer_Id, Turno_Id
END
GO

IF (OBJECT_ID('SQLGROUP.migrar_autoxturno') IS NOT NULL)
	DROP PROCEDURE SQLGROUP.migrar_autoxturno
GO

CREATE PROCEDURE SQLGROUP.migrar_autoxturno
AS
BEGIN
	INSERT SQLGROUP.Auto_Turno
	SELECT Auto_Patente, Turno_Id
	FROM gd_esquema.Maestra as m, SQLGROUP.Turno as t
	WHERE t.Turno_Hora_Inicio = m.Turno_Hora_Inicio AND t.Turno_Hora_Fin = m.Turno_Hora_Fin
	GROUP BY m.Auto_Patente, t.Turno_Id
END
GO

IF (OBJECT_ID('SQLGROUP.migrar_viajes') IS NOT NULL)
	DROP PROCEDURE SQLGROUP.migrar_viajes
GO

CREATE PROCEDURE SQLGROUP.migrar_viajes
AS
BEGIN
	DECLARE viajes_cursor CURSOR FOR
	SELECT Chofer_Id,Viaje_Fecha,Viaje_Cant_Kilometros,Auto_Patente,Cliente_Id, Turno_Id
	FROM gd_esquema.Maestra as m, SQLGROUP.Turno as t, SQLGROUP.Clientes as cl, SQLGROUP.Choferes as ch
	WHERE t.Turno_Hora_Fin = m.Turno_Hora_Fin AND t.Turno_Hora_Inicio = m.Turno_Hora_Inicio AND ch.Chofer_Dni = m.Chofer_Dni AND m.Cliente_Dni = cl.Cliente_Dni
	GROUP BY Chofer_Id,Viaje_Fecha,Viaje_Cant_Kilometros,Auto_Patente,Cliente_Id, Turno_Id
	ORDER BY m.Auto_Patente, m.Viaje_Fecha

	/*Variable para el cursor*/
	DECLARE @chofer_id NUMERIC(18,0), @viaje_fecha DATETIME, @viaje_cant_kilometros NUMERIC(18,0), @auto_patente VARCHAR(10), @cliente_id NUMERIC(18,0), @turno_id INTEGER;
	/*Extras var*/
	DECLARE @ultimo_horario DATETIME,@last_patente VARCHAR(10), @last_fecha DATETIME, @cantidad_iguales INTEGER;

	OPEN viajes_cursor;
	FETCH NEXT FROM viajes_cursor INTO @chofer_id, @viaje_fecha,@viaje_cant_kilometros, @auto_patente, @cliente_id, @turno_id;

	/*Este tarda 20 segundos se puede ya que saco el cursor ordenado si no no se podria
	Comparo con el resultado anterior de patente y fecha y si son iguales pongo hora inicio la hora terminacion del otro y le agrego dos minutos
	algo parecido a la otra opcion*/
	WHILE @@FETCH_STATUS = 0
	BEGIN
		IF(@last_fecha = @viaje_fecha AND @last_patente = @auto_patente)
		BEGIN
			SET @cantidad_iguales = @cantidad_iguales + 1;
		END
		ELSE
		BEGIN
			SET @cantidad_iguales = 0;
		END
		
		INSERT INTO Viajes (Viaje_Cant_Kilometros,Viaje_Fecha,Viaje_Fecha_INIC,Viaje_Fecha_Fin,Viaje_Chofer_Id,Viaje_Auto_Patente,Viaje_Turno_Id,Viaje_Cliente_Id)
		VALUES (@viaje_cant_kilometros,@viaje_fecha,DATEADD(minute,@cantidad_iguales*2,@viaje_fecha), DATEADD(minute,@cantidad_iguales*2+2,@viaje_fecha),@chofer_id,@auto_patente,@turno_id,@cliente_id)
		
		SET @last_patente = @auto_patente;
		SET @last_fecha = @viaje_fecha;
		
		FETCH NEXT FROM viajes_cursor INTO @chofer_id, @viaje_fecha,@viaje_cant_kilometros, @auto_patente, @cliente_id, @turno_id;
	END

	/* Esto tarda 5 minutos hay q mejorarlo, lo que debe tardar es q siempre busca en la tabla por cada uno, arriba se cambia
	WHILE @@FETCH_STATUS = 0
	BEGIN
		SELECT @ultimo_horario = MAX(Viaje_Fecha_Fin) FROM Viajes WHERE Viaje_Auto_Patente = @auto_patente AND Viaje_Fecha = @viaje_fecha
		IF(@ultimo_horario IS NOT NULL)
		BEGIN
			/*Si entra aca es xq un auto ya tuvo un viaje, entonces agarro el horario de finalizacion y lo pongo como heca de inicio y le agrego dos minutos y le pongo como fechs de finalizacion*/
			INSERT INTO Viajes (Viaje_Cant_Kilometros,Viaje_Fecha,Viaje_Fecha_INIC,Viaje_Fecha_Fin,Viaje_Chofer_Id,Viaje_Auto_Patente,Viaje_Turno_Id,Viaje_Cliente_Id)
			VALUES (@viaje_cant_kilometros,@viaje_fecha,@ultimo_horario, DATEADD(minute,2,@ultimo_horario),@chofer_id,@auto_patente,@turno_id,@cliente_id)
		END
		ELSE
		BEGIN
			INSERT INTO Viajes (Viaje_Cant_Kilometros,Viaje_Fecha,Viaje_Fecha_INIC,Viaje_Fecha_Fin,Viaje_Chofer_Id,Viaje_Auto_Patente,Viaje_Turno_Id,Viaje_Cliente_Id)
			VALUES (@viaje_cant_kilometros, @viaje_fecha, @viaje_fecha, DATEADD(MINUTE,2,@viaje_fecha),@chofer_id,@auto_patente,@turno_id,@cliente_id)
		END
		FETCH NEXT FROM viajes_cursor INTO @chofer_id, @viaje_fecha,@viaje_cant_kilometros, @auto_patente, @cliente_id, @turno_id;
	END*/
	CLOSE viajes_cursor;
	DEALLOCATE viajes_cursor;
END
GO

/*ESTAN MAL XQ HAY Q MIGRAR VIAJES BIEN, HAY Q INVENTARLES BIEN EL TEMA DE HORA INICIO Y FIN

IF (OBJECT_ID('SQLGROUP.migrar_viajes') IS NOT NULL)
	DROP PROCEDURE SQLGROUP.migrar_viajes
GO

CREATE PROCEDURE SQLGROUP.migrar_viajes
AS
BEGIN
	INSERT SQLGROUP.viajes (Viaje_Cant_Kilometros, Viaje_Fecha, Viaje_Fecha_Inic, Viaje_Fecha_Fin, Viaje_Chofer_Id, Viaje_Auto_Patente, Viaje_Cliente_Id, Viaje_Turno_Id)
	SELECT Viaje_Cant_Kilometros, Viaje_Fecha, Viaje_Fecha, Viaje_Fecha, c.Chofer_Id, Auto_Patente, cli.Cliente_Id, t.Turno_Id
	FROM gd_esquema.Maestra as m, SQLGROUP.Choferes as c, SQLGROUP.Clientes as cli, SQLGROUP.Turno as t
	WHERE m.Chofer_Dni = c.Chofer_Dni AND m.Cliente_Dni = cli.Cliente_Dni AND t.Turno_Hora_Inicio = m.Turno_Hora_Inicio AND t.Turno_Hora_Fin = m.Turno_Hora_Fin
	GROUP BY Viaje_Cant_Kilometros, Viaje_Fecha, c.Chofer_Id, Auto_Patente, cli.Cliente_Id, t.Turno_Id
END
GO

If (OBJECT_ID('SQLGROUP.migrar_facturas') IS NOT NULL)
	DROP PROCEDURE SQLGROUP.migrar_facturas
GO

CREATE PROCEDURE SQLGROUP.migrar_facturas
AS
BEGIN
	INSERT SQLGROUP.Facturas
	SELECT m.Factura_Nro, m.Factura_Fecha_Inicio, m.Factura_Fecha_Fin, m.Factura_Fecha, 
						(SELECT SUM(m2.Viaje_Cant_Kilometros * m2.Turno_Valor_Kilometro) + SUM(m2.Turno_Precio_Base) 
						FROM gd_esquema.Maestra as m2 WHERE m2.Factura_Nro = m.Factura_Nro),COUNT(*), cli.Cliente_Id
	FROM gd_esquema.Maestra as m, SQLGROUP.Clientes as cli
	WHERE m.Factura_Nro IS NOT NULL AND m.Cliente_Dni = cli.Cliente_Dni
	GROUP BY m.Factura_Nro, m.Factura_Fecha_Inicio, m.Factura_Fecha_Fin, m.Factura_Fecha,cli.Cliente_Id

END
GO

IF (OBJECT_ID('SQLGROUP.migrar_viajesxfactura') IS NOT NULL)
	DROP PROCEDURE SQLGROUP.migrar_viajesxfactura
GO

CREATE PROCEDURE SQLGROUP.migrar_viajesxfactura
AS
BEGIN
	INSERT SQLGROUP.Factura_Viaje
	SELECT f.Factura_Nro, v.Viaje_Id
	FROM SQLGROUP.Facturas as f, SQLGROUP.Viajes as v, gd_esquema.Maestra as m
	WHERE m.Factura_Nro IS NOT NULL AND m.Auto_Patente = v.Viaje_Auto_Patente AND m.Viaje_Fecha = v.Viaje_Fecha 
	GROUP BY f.Factura_Nro, v.Viaje_Id
END
GO
*/

/*-----Aca se ejecutan todos los procedures de migracion de arriba------*/
BEGIN
	EXEC SQLGROUP.crear_tablas;
	EXEC SQLGROUP.crear_roles;
	EXEC SQLGROUP.migrar_turnos;
	EXEC SQLGROUP.crear_administradores;
	EXEC SQLGROUP.migrar_choferes;
	EXEC SQLGROUP.migrar_clientes;
	EXEC SQLGROUP.migrar_automoviles;
	EXEC SQLGROUP.crear_usuarios;
	EXEC SQLGROUP.migrar_choferesxturno;
	EXEC SQLGROUP.migrar_autoxturno;
	EXEC SQLGROUP.migrar_viajes;
	/*EXEC SQLGROUP.migrar_facturas;
	EXEC SQLGROUP.migrar_viajesxfactura;*/
END

/* --- Aca se crean los elementos de bases de datos que  resolveran las funcionalidades-----*/

/* ---------1) ABM de rol ----------------*/

/* ---------2) LOGIN ------------------------------------------------------------------------------------------------------*/

/* reinicia login tras un logueo correcto*/
CREATE PROCEDURE SQLGROUP.ReiniciarLogin
@NOMBRE VARCHAR(255)
AS
UPDATE SQLGROUP.Usuarios SET Usuario_Intentos = 0 WHERE Usuario_Id = @NOMBRE
GO

/* actualiza el contrador de logueo incorrecto*/
CREATE PROCEDURE SQLGROUP.ActualizarContador
@NOMBRE VARCHAR(255)
AS  
BEGIN
UPDATE SQLGROUP.Usuarios SET Usuario_Intentos= Usuario_Intentos + 1 WHERE Usuario_Id=@nombre; 
SELECT Usuario_Intentos FROM SQLGROUP.Usuarios WHERE Usuario_Id=@nombre
END
GO

/* deshabilitar un usuario por id */ 
CREATE PROCEDURE SQLGROUP.DeshabilitarUsuario
@ID_USER VARCHAR(255)
AS
BEGIN
UPDATE SQLGROUP.Usuarios SET Usuario_Estado='Deshabilitado' WHERE Usuario_Id= @ID_USER;
GO

---cargar roles no dados de baja
CREATE PROCEDURE SQLGROUP.CargarRoles
AS 
SELECT * FROM SQLGROUP.Roles WHERE Rol_Estado= 'Habilitado'
GO

--Funcion que recibe un varchar y lo devuelve cifrado
CREATE FUNCTION cifrado_claves(@password VARCHAR(64))
RETURNS VARCHAR(64)
AS
BEGIN
	RETURN CONVERT(CHAR(64),HASHBYTES('SHA2_256',@password),1);
END
GO
/* --------- STORED PROCEDURE LOGIN -----------------*/

CREATE PROCEDURE SQLGROUP.login @usuario varchar (20), @password varchar (64), @a int OUTPUT
AS
BEGIN
DECLARE @cant_fallos AS int

IF (EXISTS (SELECT 1 FROM SQLGROUP.Usuarios WHERE Usuario_Id = @usuario))
 BEGIN
 IF (SQLGROUP.cifrado_claves(@password) = (SELECT Usuario_Password FROM SQLGROUP.Usuarios WHERE Usuario_Id = @usuario))
  BEGIN
  UPDATE SQLGROUP.Usuarios SET Usuario_Intentos =0 WHERE Usuario_Id=@usuario
  IF ('Deshabilitado' = (SELECT Usuario_Estado FROM SQLGROUP.Usuarios WHERE Usuario_Id=@usuario))
   BEGIN
   SET @a=0 --usuario inhabilitado
   SELECT @a
   END
  ELSE
   BEGIN
   IF ('Habilitado' = (SELECT Usuario_Estado FROM SQLGROUP.Usuarios WHERE Usuario_Id = @usuario))
    BEGIN
    set @a = 3 --ingreso correcto
    SELECT @a
    --ELSE SELECCIONAR Y RETORNAR EL/LOS ROL/ES ASOCIADO AL USUARIO
    END
   ELSE
    --ESTADO =2
    BEGIN
    set @a = 5
    SELECT @a
    END 
   
   END
  END 
 ELSE 
 BEGIN
 SET @cant_fallos= (SELECT Usuario_Intentos FROM SQLGROUP.Usuarios WHERE Usuario_Id=@usuario)
 IF (@cant_fallos= 2)
 --TERCERA VEZ EN FALLAR
  BEGIN
  UPDATE SQLGROUP.Usuarios SET estado=0 WHERE Usuario_Id=@usuario
  SET @a=1 --la cantidad de fallos ha sido alcanzada
  SELECT @a
  END
 ELSE 
  BEGIN
  UPDATE SQLGROUP.Usuarios SET Usuario_Intentos = @cant_fallos + 1 WHERE usuario=@usuario
  SET @a=2 --contraseña incorrecta
  SELECT @a
  END
 END
END
ELSE
 BEGIN
 SET @a=4 --usuario inexistente
 SELECT @a
 END
END
GO 