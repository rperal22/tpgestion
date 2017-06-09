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
	IF OBJECT_ID('SQLGROUP.Rendicion_Viaje') IS NOT NULL
		DROP TABLE SQLGROUP.Rendicion_Viaje
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
		Chofer_Fecha_Nac DATETIME NOT NULL,
		Chofer_Estado VARCHAR(20) NOT NULL DEFAULT 'Habilitado'
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
		Viaje_Cant_Kilometros NUMERIC(18,2) NOT NULL,
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

	CREATE TABLE SQLGROUP.Rendicion_Viaje (
		Rv_Viaje_Id INTEGER,
		Rv_Rendicion_Nro NUMERIC(18,0),
		Rv_Importe NUMERIC(18,2),
		CONSTRAINT pk_rendicionxviaje PRIMARY KEY(Rv_Viaje_Id,Rv_Rendicion_Nro) 
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

	ALTER TABLE SQLGROUP.Auto_Turno ADD
	CONSTRAINT fk_autoturno_auto FOREIGN KEY (AT_Auto_Patente) REFERENCES SQLGROUP.Automoviles(Auto_Patente)
	ON DELETE NO ACTION ON UPDATE CASCADE,
	CONSTRAINT fk_autoturno_turno FOREIGN KEY (At_Turno_Id) REFERENCES SQLGROUP.Turno(Turno_Id)
	ON DELETE NO ACTION ON UPDATE NO ACTION;

	ALTER TABLE SQLGROUP.Rendicion_Viaje ADD
	CONSTRAINT fk_rendicionviaje_viaje FOREIGN KEY (Rv_Viaje_Id) REFERENCES SQLGROUP.Viajes(Viaje_Id)
	ON DELETE NO ACTION ON UPDATE CASCADE,
	CONSTRAINT fk_rendicionviaje_rendicion FOREIGN KEY (Rv_Rendicion_Nro) REFERENCES SQLGROUP.Rendiciones(Rendicion_Nro)
	ON DELETE NO ACTION ON UPDATE NO ACTION;

	/*--------------------------------*/
END
GO

--Ejecuto procedure que crea las tablas
BEGIN
	EXEC SQLGROUP.crear_tablas;
END
GO

/*Creacion de funciones-------------------------------------------------------------------------------------------------------*/
--Funciones usadas por triggers, procedures, migraciones, aplicacion, etc
IF (OBJECT_ID('SQLGROUP.entreFechasNoCuentaMinutosSegundo') IS NOT NULL)
	DROP FUNCTION SQLGROUP.entreFechasNoCuentaMinutosSegundo
GO
/*Esta funcion chequea que una fecha este entre dos fechas sin contar minutos ni segundos*/
CREATE FUNCTION SQLGROUP.entreFechasNoCuentaMinutosSegundo (@fechamin DATETIME, @fechamax DATETIME, @fechaentre DATETIME)
RETURNS int
BEGIN
	IF(YEAR(@fechaentre) >= YEAR(@fechamin) AND YEAR(@fechaentre) <= YEAR(@fechamax) AND MONTH(@fechaentre) >= MONTH(@fechamin) AND MONTH(@fechaentre) <= MONTH(@fechamax))
	BEGIN
		IF(MONTH(@fechaentre) = MONTH(@fechamax) AND DAY(@fechaentre) <= DAY(@fechamax))
		BEGIN
			RETURN 1;
		END
		IF(MONTH(@fechaentre) = MONTH(@fechamin) AND DAY(@fechaentre) >= DAY(@fechamin))
		BEGIN
			RETURN 1;
		END
	END
	ELSE 
	BEGIN
		RETURN 0;
	END
	RETURN 0;
END
GO

If (OBJECT_ID('SQLGROUP.cifrado_claves') IS NOT NULL)
	DROP FUNCTION SQLGROUP.cifrado_claves
GO
/*Esta funcion al recibir un VARCHAR lo devuelve cifrado*/
CREATE FUNCTION SQLGROUP.cifrado_claves(@password VARCHAR(64))
RETURNS VARCHAR(64)
AS
BEGIN
	RETURN CONVERT(CHAR(64),HASHBYTES('SHA2_256',@password),1);
END
GO

/*----------------------------------------------------------------------------------------------------------------------------*/

/*Creacion de triggers-------------------------------------------------------------------------------------------------------*/
/*Creamos triggers sobre tablas anteriorermente creadas*/
IF (OBJECT_ID('SQLGROUP.insert_password_cifrado') IS NOT NULL)
	DROP TRIGGER SQLGROUP.insert_password_cifrado;
GO

/*Trigger que cifra la clave cada vez q se inserta un nuevo usuario
Utiliza function SQLGROUP.cifrado_claves*/
CREATE TRIGGER SQLGROUP.insert_password_cifrado
ON SQLGROUP.Usuarios INSTEAD OF INSERT
AS 
BEGIN
	INSERT INTO SQLGROUP.Usuarios (Usuario_Id,Usuario_DNI,Usuario_Password,Usuario_Intentos, Usuario_Estado)
	SELECT i.Usuario_Id, i.Usuario_DNI,SQLGROUP.cifrado_claves(i.Usuario_Password), i.Usuario_Intentos,i.Usuario_Estado
	FROM inserted as i
END
GO

IF (OBJECT_ID('SQLGROUP.controlarAutosHabilitadosxChofer') IS NOT NULL)
	DROP TRIGGER SQLGROUP.controlarAutosHabilitadosxChofer;
GO
/*Este trigger controla que un chofer solo pueda tener un auto habilitado*/
CREATE TRIGGER SQLGROUP.controlarAutosHabilitadosxChofer
ON SQLGROUP.Automoviles AFTER INSERT , UPDATE
AS 
BEGIN
	IF((SELECT TOP 1 COUNT(*)
	FROM SQLGROUP.Automoviles
	WHERE Auto_Estado = 'Habilitado'
	GROUP BY Auto_Chofer
	ORDER BY 1 DESC)>1) 
	BEGIN
		RAISERROR('El chofer ya tiene mas de un auto habilitado', 16,1);
		ROLLBACK;
	END
END
GO
/*
IF(OBJECT_ID('SQLGROUP.integridadViajes') IS NOT NULL)
	DROP TRIGGER SQLGROUP.integridadViajes
GO
/*Este trigger se ocupa que no se registren viajes en el 
mismo horario con el mismo auto o con el mismo cliente*/
CREATE TRIGGER SQLGROUP.integridadViajes 
ON SQLGROUP.Viajes AFTER INSERT
AS
BEGIN
	IF((SELECT COUNT(*)
	FROM inserted as i, SQLGROUP.Viajes as v
	WHERE i.Viaje_Auto_Patente = v.Viaje_Auto_Patente 
	AND  ((i.Viaje_Fecha_INIC >= v.Viaje_Fecha_INIC AND i.Viaje_Fecha_INIC <= v.Viaje_Fecha_Fin)
	OR (i.Viaje_Fecha_Fin >= v.Viaje_Fecha_INIC AND i.Viaje_Fecha_Fin <= v.Viaje_Fecha_Fin)))>1)
	BEGIN
		ROLLBACK;
		RAISERROR('El auto ya tiene un viaje en este horario', 16,1);
	END
	IF((SELECT COUNT(*)
	FROM inserted as i, SQLGROUP.Viajes as v
	WHERE i.Viaje_Cliente_Id = v.Viaje_Cliente_Id
	AND  ((i.Viaje_Fecha_INIC >= v.Viaje_Fecha_INIC AND i.Viaje_Fecha_INIC <= v.Viaje_Fecha_Fin)
	OR (i.Viaje_Fecha_Fin >= v.Viaje_Fecha_INIC AND i.Viaje_Fecha_Fin <= v.Viaje_Fecha_Fin)))>1)
	BEGIN
		ROLLBACK;
		RAISERROR('El cliente ya tiene un viaje en esta fecha.', 16,1);
	END
END
GO
*/
IF(OBJECT_ID('SQLGROUP.integridadFacturas') IS NOT NULL)
	DROP TRIGGER SQLGROUP.integridadFacturas
GO
/*Esto se ocupa de que no se guarden facturas con fechas superpuestas
o iguales*/
CREATE TRIGGER SQLGROUP.integridadFacturas 
ON SQLGROUP.Facturas INSTEAD OF INSERT
AS
BEGIN
	IF((SELECT COUNT(*)
		FROM inserted as i, Facturas as f
		WHERE i.Factura_Cliente_Id = f.Factura_Cliente_Id 
			AND (SQLGROUP.entreFechasNoCuentaMinutosSegundo(f.Factura_Fecha_Inicio,f.Factura_Fecha_Fin,i.Factura_Fecha_Inicio) = 1 
			OR  SQLGROUP.entreFechasNoCuentaMinutosSegundo(f.Factura_Fecha_Inicio,f.Factura_Fecha_Fin,i.Factura_Fecha_Fin) = 1)) != 0)
	BEGIN
		RAISERROR('Ya hay una factura en esas fechas', 16,1);
	END
	ELSE
	BEGIN
		INSERT INTO Facturas
		SELECT *
		FROM inserted
	END
END
GO
/*------------------------------------------------------------------------------------------------------------------------------------------*/


/*Creacion de procedures de migraciones-----------------------------------------------------------------------------------------------------*/
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
	INSERT INTO SQLGROUP.Roles (Rol_Nombre,Rol_Descripcion)
	VALUES ('Administrador','Rol administrativo del sistema');
	INSERT INTO SQLGROUP.Roles (Rol_Nombre,Rol_Descripcion)
	VALUES ('Cliente','Rol cliente del sistema');
	INSERT INTO SQLGROUP.Roles (Rol_Nombre,Rol_Descripcion)
	VALUES ('Chofer','Rol chofer del sistema');
END
GO

IF(OBJECT_ID('SQLGROUP.crear_funciones') IS NOT NULL)
	DROP PROCEDURE SQLGROUP.crear_funciones
GO

CREATE PROCEDURE SQLGROUP.crear_funciones
AS
BEGIN
	/*NO ESTA COMPLETO!! // Pongo unas para testear*/
	/*Creo una y se la asigno a sus correspondiente roles*/

	INSERT INTO SQLGROUP.Funcionalidades (Func_Nombre)
	VALUES ('ABM de Cliente');

	INSERT INTO SQLGROUP.Rol_Funcionalidad (RF_Func_Nombre,RF_Rol_Nombre)
	VALUES ('ABM de Cliente','Administrador')

	INSERT INTO SQLGROUP.Funcionalidades (Func_Nombre)
	VALUES ('ABM Automoviles');

	INSERT INTO SQLGROUP.Rol_Funcionalidad (RF_Func_Nombre,RF_Rol_Nombre)
	VALUES ('ABM Automoviles','Administrador')

	INSERT INTO SQLGROUP.Funcionalidades (Func_Nombre)
	VALUES ('ABM Turno');

	INSERT INTO SQLGROUP.Rol_Funcionalidad (RF_Func_Nombre,RF_Rol_Nombre)
	VALUES ('ABM Turno','Administrador')

	INSERT INTO SQLGROUP.Funcionalidades (Func_Nombre)
	VALUES ('ABM Rol');

	INSERT INTO SQLGROUP.Rol_Funcionalidad (RF_Func_Nombre,RF_Rol_Nombre)
	VALUES ('ABM Rol','Administrador')

	INSERT INTO SQLGROUP.Funcionalidades (Func_Nombre)
	VALUES ('ABM de Choferes');

	INSERT INTO SQLGROUP.Rol_Funcionalidad (RF_Func_Nombre,RF_Rol_Nombre)
	VALUES ('ABM de Choferes','Administrador')

	INSERT INTO SQLGROUP.Funcionalidades (Func_Nombre)
	VALUES ('ABM de Clientes');

	INSERT INTO SQLGROUP.Rol_Funcionalidad (RF_Func_Nombre,RF_Rol_Nombre)
	VALUES ('ABM de Clientes','Administrador')

	INSERT INTO SQLGROUP.Funcionalidades (Func_Nombre)
	VALUES ('Registrar Viaje');

	INSERT INTO SQLGROUP.Rol_Funcionalidad (RF_Func_Nombre,RF_Rol_Nombre)
	VALUES ('Registrar Viaje','Administrador')

	INSERT INTO SQLGROUP.Funcionalidades (Func_Nombre)
	VALUES ('Rendir Viajes');

	INSERT INTO SQLGROUP.Rol_Funcionalidad (RF_Func_Nombre,RF_Rol_Nombre)
	VALUES ('Rendir Viajes','Administrador')

	INSERT INTO SQLGROUP.Funcionalidades (Func_Nombre)
	VALUES ('Facturar');

	INSERT INTO SQLGROUP.Rol_Funcionalidad (RF_Func_Nombre,RF_Rol_Nombre)
	VALUES ('Facturar','Administrador')

	INSERT INTO SQLGROUP.Funcionalidades (Func_Nombre)
	VALUES ('Ver estadisticas');

	INSERT INTO SQLGROUP.Rol_Funcionalidad (RF_Func_Nombre,RF_Rol_Nombre)
	VALUES ('Ver estadisticas','Administrador')
END
GO

IF(OBJECT_ID('SQLGROUP.crear_usuarios') IS NOT NULL)
	DROP PROCEDURE SQLGROUP.crear_usuarios
GO

CREATE PROCEDURE SQLGROUP.crear_usuarios
AS
BEGIN
	INSERT INTO SQLGROUP.Usuarios (Usuario_Id,Usuario_Password,Usuario_DNI) -- se agrega funcion de cifrado de claves
	SELECT Chofer_Nombre + '_' + Chofer_Apellido,Chofer_Nombre,Chofer_Dni 
	FROM SQLGROUP.Choferes

	INSERT INTO SQLGROUP.Usuarios (Usuario_Id,Usuario_Password,Usuario_DNI)
	SELECT Cliente_Nombre + '_' + Cliente_Apellido,Cliente_Nombre,Cliente_Dni
	FROM SQLGROUP.Clientes
	WHERE Cliente_Dni NOT IN (SELECT Usuario_DNI FROM Usuarios)
	GROUP BY Cliente_Nombre,Cliente_Nombre,Cliente_Dni,Cliente_Apellido

	INSERT INTO SQLGROUP.Usuarios (Usuario_Id,Usuario_Password,Usuario_DNI)
	VALUES ('admin','w23e',12345678)

END
GO

IF(OBJECT_ID('SQLGROUP.migrar_rolesxusuario') IS NOT NULL)
	DROP PROCEDURE SQLGROUP.migrar_rolesxusuario
GO

CREATE PROCEDURE SQLGROUP.migrar_rolesxusuario
AS
BEGIN
	INSERT INTO SQLGROUP.Usuarios_Rol (UR_Usuario_Id,UR_Rol_Nombre)
	SELECT u.Usuario_Id, 'Chofer'
	FROM SQLGROUP.Choferes as c, SQLGROUP.Usuarios as u
	WHERE c.Chofer_Dni = u.Usuario_DNI

	INSERT INTO SQLGROUP.Usuarios_Rol (UR_Usuario_Id,UR_Rol_Nombre)
	SELECT Usuario_Id, 'Cliente'
	FROM SQLGROUP.Clientes, SQLGROUP.Usuarios
	WHERE Cliente_Dni = Usuario_DNI

	INSERT INTO SQLGROUP.Usuarios_Rol (UR_Usuario_Id,UR_Rol_Nombre)
	VALUES ('admin','Administrador')
	/*Le pongo todos los roles a admin para testear nomas*/
	INSERT INTO SQLGROUP.Usuarios_Rol (UR_Usuario_Id,UR_Rol_Nombre)
	VALUES ('admin','Chofer')
	INSERT INTO SQLGROUP.Usuarios_Rol (UR_Usuario_Id,UR_Rol_Nombre)
	VALUES ('admin','Cliente')
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

	CLOSE viajes_cursor;
	DEALLOCATE viajes_cursor;
END
GO

IF (OBJECT_ID('SQLGROUP.migrar_factura') IS NOT NULL)
	DROP PROCEDURE SQLGROUP.migrar_factura
GO

CREATE PROCEDURE SQLGROUP.migrar_factura 
AS
BEGIN
	DECLARE facturas CURSOR FOR
	SELECT m.Factura_Nro, m.Factura_Fecha,  m.Factura_Fecha_Inicio, m.Factura_Fecha_Fin, c.Cliente_Id
	FROM gd_esquema.Maestra as m, SQLGROUP.Clientes AS c 
	WHERE Factura_Nro IS NOT NULL AND c.Cliente_Dni = m.Cliente_Dni
	GROUP BY m.Factura_Nro, m.Factura_Fecha, m.Factura_Fecha_Fin, m.Factura_Fecha_Inicio, c.Cliente_Id

	DECLARE @nrofact NUMERIC(18,0),@fnfact DATETIME, @fifact DATETIME, @fffact DATETIME, @clienteid INT;
	DECLARE @cantidadViajes INT, @valorTotal NUMERIC(18,2);

	OPEN facturas;
	FETCH NEXT FROM facturas INTO @nrofact, @fnfact, @fifact, @fffact, @clienteid;


	WHILE @@FETCH_STATUS = 0
	BEGIN
		SELECT @cantidadViajes = COUNT(*), @valorTotal = ISNULL(SUM(t.Turno_Precio_Base + t.Turno_Valor_Kilometro*v.Viaje_Cant_Kilometros),0)
		FROM SQLGROUP.Viajes as v, SQLGROUP.Turno as t
		WHERE SQLGROUP.entreFechasNoCuentaMinutosSegundo(@fifact,@fffact,Viaje_Fecha) = 1 AND v.Viaje_Cliente_Id = @clienteid AND t.Turno_Id = v.Viaje_Turno_Id;

		INSERT INTO Facturas (Factura_Nro, Factura_Fecha, Factura_Fecha_Inicio, Factura_Fecha_Fin, Factura_Total, Factua_Nro_Viajes, Factura_Cliente_Id)
		VALUES (@nrofact, @fnfact, @fifact, @fnfact, @valorTotal, @cantidadViajes, @clienteid)

		FETCH NEXT FROM facturas INTO @nrofact, @fnfact, @fifact, @fffact, @clienteid;
	END
	CLOSE facturas;
	DEALLOCATE facturas;


END
GO

IF (OBJECT_ID('SQLGROUP.migrar_viajes_factura') IS NOT NULL)
	DROP PROCEDURE SQLGROUP.migrar_viajes_factura
GO

CREATE PROCEDURE SQLGROUP.migrar_viajes_factura 
AS
BEGIN
	INSERT INTO SQLGROUP.Factura_Viaje (Fv_Factura_Nro, Fv_Viaje_Id)
	SELECT Factura_Nro, Viaje_Id
	FROM SQLGROUP.Facturas, SQLGROUP.Viajes
	WHERE SQLGROUP.entreFechasNoCuentaMinutosSegundo(Factura_Fecha_Inicio,Factura_Fecha_Fin,Viaje_Fecha) = 1 AND Viaje_Cliente_Id = Factura_Cliente_Id
END
GO

IF (OBJECT_ID('SQLGROUP.migrar_rendiciones') IS NOT NULL)
	DROP PROCEDURE SQLGROUP.migrar_rendiciones
GO

CREATE PROCEDURE SQLGROUP.migrar_rendiciones 
AS
BEGIN
	INSERT INTO Rendiciones (Rendicion_Nro, Rendicion_Fecha, Rendicion_Importe, Rendicion_Chofer_Id, Rendicion_Turno_Id)
	SELECT m.Rendicion_Nro, Rendicion_Fecha, SUM(Rendicion_Importe), c.Chofer_Id, t.Turno_Id
	FROM gd_esquema.Maestra as m, SQLGROUP.Choferes as c, SQLGROUP.Turno as t
	WHERE m.Rendicion_Nro IS NOT NULL AND c.Chofer_Dni = m.Chofer_Dni AND t.Turno_Hora_Inicio = m.Turno_Hora_Inicio AND t.Turno_Hora_Fin = m.Turno_Hora_Fin
	GROUP BY m.Rendicion_Nro, Rendicion_Fecha, c.Chofer_Id, t.Turno_Id
END
GO

IF (OBJECT_ID('SQLGROUP.migrar_rendicionesxviajes') IS NOT NULL)
	DROP PROCEDURE SQLGROUP.migrar_rendicionesxviajes
GO

CREATE PROCEDURE SQLGROUP.migrar_rendicionesxviajes
AS
BEGIN
	INSERT INTO SQLGROUP.Rendicion_Viaje (Rv_Rendicion_Nro, Rv_Importe, Rv_Viaje_Id)
	SELECT m.Rendicion_Nro, m.Rendicion_Importe, v.Viaje_Id
	FROM gd_esquema.Maestra as m, SQLGROUP.Viajes as v, SQLGROUP.Choferes as c, SQLGROUP.Clientes as cli
	WHERE m.Viaje_Fecha = v.Viaje_Fecha AND m.Chofer_Dni = c.Chofer_Dni AND v.Viaje_Chofer_Id = c.Chofer_Id AND m.Rendicion_Nro IS NOT NULL AND cli.Cliente_Dni = m.Cliente_Dni AND v.Viaje_Cliente_Id = cli.Cliente_Id AND m.Viaje_Cant_Kilometros = v.Viaje_Cant_Kilometros
	GROUP BY m.Rendicion_Nro, m.Rendicion_Importe, v.Viaje_Id
END
GO

/*-----Aca se ejecutan todos los procedures de migracion de arriba------*/
BEGIN
	EXEC SQLGROUP.crear_roles;
	EXEC SQLGROUP.migrar_turnos;
	EXEC SQLGROUP.crear_administradores;
	EXEC SQLGROUP.migrar_choferes;
	EXEC SQLGROUP.migrar_clientes;
	EXEC SQLGROUP.crear_usuarios;
	EXEC SQLGROUP.migrar_rolesxusuario;
	EXEC SQLGROUP.crear_funciones;
	EXEC SQLGROUP.migrar_automoviles;	
	EXEC SQLGROUP.migrar_autoxturno;
	EXEC SQLGROUP.migrar_viajes;
	EXEC SQLGROUP.migrar_factura 
	EXEC SQLGROUP.migrar_viajes_factura;
	EXEC SQLGROUP.migrar_rendiciones;
	EXEC SQLGROUP.migrar_rendicionesxviajes;
END
GO
/*------------------------------------------------------------------------------------------------------------------------------------------*/

/*Procedures que usamos en la aplicacion----------------------------------------------------------------------------------------------------*/


If (OBJECT_ID('SQLGROUP.login') IS NOT NULL)
	DROP PROCEDURE SQLGROUP.login
GO

CREATE PROCEDURE SQLGROUP.login @usuario varchar(20), @password varchar(64), @resultado int OUTPUT
AS
BEGIN
	
	/*
	0 -> Usuario Deshabilitado
	1 -> Password ok
	2 -> Password no ok
	3 -> User not found
	*/

	SET @resultado = ISNULL((SELECT 
								CASE 
								WHEN Usuario_Intentos = 3 THEN 0
								WHEN (SQLGROUP.cifrado_claves(@password) = Usuario_Password) THEN 1
								ELSE 2
								END
							FROM SQLGROUP.Usuarios
							WHERE Usuario_Id = @usuario),3)
	/*Si la passwrod no es correcta aumento la antidad de intentos*/
	IF(@resultado = 2) 
	BEGIN
		UPDATE SQLGROUP.Usuarios SET Usuario_Intentos= Usuario_Intentos + 1 WHERE Usuario_Id=@usuario; 
	END
	/*Si la loguea bien reinicio la cant de intentos, si esta deshabilitado no loguea ni reinicio cant de intentos*/
	IF (@resultado = 1)
	BEGIN
		UPDATE SQLGROUP.Usuarios SET Usuario_Intentos = 0 WHERE Usuario_Id = @usuario
	END
END
GO 

/* ----------- STORED PRUCEDURE ALTA USUARIOS ----------------------- */
IF(OBJECT_ID('SQLGROUP.crearUsuario') IS NOT NULL)
	DROP PROCEDURE SQLGROUP.crearUsuario
GO

CREATE PROCEDURE SQLGROUP.crearUsuario @username varchar(20), @password varchar(64), @dni int ,@flagRolChofer int, @flagRolCliente int, @resultado int OUTPUT
AS
BEGIN
	IF EXISTS (SELECT Usuario_Id FROM SQLGROUP.Usuarios WHERE Usuario_Id = @username)
	BEGIN
	SET @resultado = 0
	END
ELSE
	BEGIN
	INSERT INTO SQLGROUP.Usuarios (Usuario_Id,Usuario_Password,Usuario_DNI)
	VALUES (@username , @password, @dni)
	IF (@flagRolChofer = 1)
		BEGIN
		INSERT INTO SQLGROUP.Usuarios_Rol (UR_Usuario_Id,UR_Rol_Nombre)
		VALUES (@username, 'Chofer')
		END
	IF (@flagRolCliente = 1)
		BEGIN
		INSERT INTO SQLGROUP.Usuarios_Rol (UR_Usuario_Id,UR_Rol_Nombre)
		VALUES (@username, 'Cliente')
		END	
	SET @resultado = 1
	END
END	
GO

/* ----------- STORED PRUCEDURE ALTA TURNOS ----------------------- */
IF(OBJECT_ID('SQLGROUP.crearTurno') IS NOT NULL)
	DROP PROCEDURE SQLGROUP.crearTurno
GO

CREATE PROCEDURE SQLGROUP.crearTurno @t_hi NUMERIC(18,0), @t_hf NUMERIC(18,0), @t_desc VARCHAR(255), @t_vk NUMERIC(18,2), @t_pb NUMERIC(18,2), @t_estado VARCHAR(20)
AS
BEGIN
	IF (@t_estado = 'Habilitado' AND (SELECT COUNT(*)
		FROM Turno
		WHERE Turno_Estado = 'Habilitado' AND (Turno_Hora_Inicio < @t_hi AND Turno_Hora_Fin > @t_hi) OR  (Turno_Hora_Inicio < @t_hf AND Turno_Hora_Fin > @t_hf)) > 0)
	BEGIN
		RAISERROR('Ya hay un turno habilitado en esos horarios', 16,1);
	END
	ELSE IF (@t_hf < @t_hi)
	BEGIN
		RAISERROR('La hora final no puede ser menor que la hora inicial', 16,1);
	END
	ELSE 
	BEGIN
		INSERT INTO Turno (Turno_Hora_Inicio, Turno_Hora_Fin, Turno_Descripcion, Turno_Valor_Kilometro, Turno_Precio_Base, Turno_Estado)
		VALUES (@t_hi,@t_hf,@t_desc,@t_vk,@t_pb, @t_estado)
	END
END
GO

IF(OBJECT_ID('SQLGROUP.updatearTurno') IS NOT NULL)
	DROP PROCEDURE SQLGROUP.updatearTurno
GO

CREATE PROCEDURE SQLGROUP.updatearTurno @t_id INT, @t_hi NUMERIC(18,0), @t_hf NUMERIC(18,0), @t_desc VARCHAR(255), @t_vk NUMERIC(18,2), @t_pb NUMERIC(18,2), @t_estado VARCHAR(20)
AS
BEGIN
	IF (@t_estado = 'Habilitado' AND (SELECT COUNT(*)
		FROM Turno
		WHERE Turno_Estado = 'Habilitado' AND (Turno_Hora_Inicio < @t_hi AND Turno_Hora_Fin > @t_hi) OR  (Turno_Hora_Inicio < @t_hf AND Turno_Hora_Fin > @t_hf)) > 0)
	BEGIN
		RAISERROR('Ya hay un turno habilitado en esos horarios', 16,1);
	END
	ELSE IF (@t_hf < @t_hi)
	BEGIN
		RAISERROR('La hora final no puede ser menor que la hora inicial', 16,1);
	END
	ELSE 
	BEGIN
		UPDATE Turno SET Turno_Descripcion = @t_desc, Turno_Hora_Inicio = @t_hi, Turno_Hora_Fin = @t_hf, Turno_Precio_Base = @t_pb,
						Turno_Valor_Kilometro = @t_vk, Turno_Estado = @t_estado
						WHERE Turno_Id = @t_id
	END
END
GO

IF(OBJECT_ID('SQLGROUP.facturar') IS NOT NULL)
	DROP PROCEDURE SQLGROUP.facturar;
GO

CREATE PROCEDURE SQLGROUP.facturar @fechaInicio DATETIME, @fechaFin DATETIME, @clienteId INT, @fechaFacturar DATETIME
AS
BEGIN
	DECLARE @cantidadViajes INT, @valorTotal NUMERIC(18,2), @facturaNro NUMERIC(18,0);
	SET @facturaNro = (SELECT MAX(Factura_Nro)+1 FROM Facturas);

	SELECT @cantidadViajes = COUNT(*), @valorTotal = ISNULL(SUM(t.Turno_Precio_Base + t.Turno_Valor_Kilometro*v.Viaje_Cant_Kilometros),0)
	FROM SQLGROUP.Viajes as v, SQLGROUP.Turno as t
	WHERE SQLGROUP.entreFechasNoCuentaMinutosSegundo(@fechaInicio,@fechaFin,Viaje_Fecha) = 1 AND v.Viaje_Cliente_Id = @clienteid AND t.Turno_Id = v.Viaje_Turno_Id;

	INSERT INTO Facturas (Factura_Nro, Factura_Fecha, Factura_Fecha_Inicio, Factura_Fecha_Fin, Factura_Total, Factua_Nro_Viajes, Factura_Cliente_Id)
	VALUES (@facturaNro, @fechaFacturar, @fechaInicio, @fechaFin, @valorTotal, @cantidadViajes, @clienteid)


	INSERT INTO SQLGROUP.Factura_Viaje (Fv_Factura_Nro, Fv_Viaje_Id)
	SELECT Factura_Nro, Viaje_Id
	FROM SQLGROUP.Facturas, SQLGROUP.Viajes
	WHERE SQLGROUP.entreFechasNoCuentaMinutosSegundo(Factura_Fecha_Inicio,Factura_Fecha_Fin,Viaje_Fecha) = 1 AND Viaje_Cliente_Id = Factura_Cliente_Id AND Factura_Nro = @facturaNro
END

IF(OBJECT_ID('SQLGROUP.rendirViajes') IS NOT NULL)
	DROP PROCEDURE SQLGROUP.rendirViajes;
GO

CREATE PROCEDURE SQLGROUP.rendirViajes @fecha DATETIME, @importe NUMERIC(18,2), @choferId INT, @turnoId INT, @porcentaje NUMERIC(18,2)
AS
BEGIN
	DECLARE @rendicionNro NUMERIC(18,0);
	SET @rendicionNro = (SELECT MAX(Rendicion_Nro)+1 FROM Rendiciones);	
	INSERT INTO SQLGROUP.Rendiciones (Rendicion_Nro, Rendicion_Fecha, Rendicion_Importe, Rendicion_Chofer_Id, Rendicion_Turno_Id)
	VALUES(@rendicionNro,@fecha,@importe,@choferId, @turnoId);

	INSERT INTO SQLGROUP.Rendicion_Viaje (Rv_Rendicion_Nro, Rv_Importe, Rv_Viaje_Id)
	SELECT @rendicionNro, (v.Viaje_Cant_Kilometros*t.Turno_Valor_Kilometro+t.Turno_Precio_Base)*@porcentaje, v.Viaje_Id
	FROM SQLGROUP.Viajes as v, SQLGROUP.Turno as t
	WHERE t.Turno_Id = @turnoId AND @choferId = v.Viaje_Chofer_Id AND DAY(@fecha) = DAY(Viaje_Fecha_INIC) AND MONTH(@fecha) = MONTH(Viaje_Fecha_INIC) AND YEAR(@fecha) = YEAR(Viaje_Fecha_INIC)
END

/*------------------------------------------------------------------------------------------------------------------------------------------*/