IF OBJECT_ID('Domicilios') IS NOT NULL
   DROP TABLE Domicilios

CREATE TABLE Domicilios(
IDDomicilio					INT IDENTITY(0,1) NOT NULL,
Calle						VARCHAR(30) NOT NULL,
Numero						VARCHAR(5) NOT NULL,
Apartamento					VARCHAR(5) NOT NULL,
CodigoPostal				VARCHAR(5) NOT NULL,
Ciudad						VARCHAR(30) NOT NULL,
Pais						VARCHAR(30) NOT NULL,

CONSTRAINT PK_Domicilios
	Primary Key(IDDomicilio)
);

IF OBJECT_ID('Telefonos') IS NOT NULL
   DROP TABLE Telefonos

CREATE TABLE Telefonos(
IDTelefonos					INT IDENTITY(0,1) NOT NULL,
Telefono1					VARCHAR(10) NOT NULL,
Telefono2					VARCHAR(10),
Telefono3					VARCHAR(10),

CONSTRAINT PK_Telefonos
	Primary Key(IDTelefonos)

);

IF OBJECT_ID('Empresa') IS NOT NULL
   DROP TABLE Empresa

CREATE TABLE Empresa(
RFC						VARCHAR(16) NOT NULL,
RazonSocial				VARCHAR(30) NOT NULL,
RegistroPatronal	    VARCHAR(30) NOT NULL,
Fecha_Inicio			DATE NOT NULL,
Domicilio				INT NOT NULL,
Telefono				INT NOT NULL, 

CONSTRAINT PK_Empresa
	Primary Key(RFC),

CONSTRAINT FK_Empresa_Domicilio
	Foreign Key(Domicilio)
	References Domicilios(IDDomicilio),

CONSTRAINT FK_Empresa_Telefono
	Foreign Key(Telefono)
	References Telefonos(IDTelefonos)

);

IF OBJECT_ID('Departamentos') IS NOT NULL
   DROP TABLE Departamentos

CREATE TABLE Departamentos(
IDDepartamento				INT IDENTITY(0,1) NOT NULL,
Nombre						VARCHAR(10) NOT NULL,
SueldoBase					FLOAT NOT NULL,
Estatus						BIT,

CONSTRAINT PK_Departamentos
	Primary Key(IDDepartamento)

);

IF OBJECT_ID('Puestos') IS NOT NULL
   DROP TABLE Puestos

CREATE TABLE Puestos(
IDPuesto					INT IDENTITY(0,1) NOT NULL,
Nombre						VARCHAR(10) NOT NULL,
NivelSalarial				FLOAT NOT NULL,
Estatus						BIT,

CONSTRAINT PK_Puestos
	Primary Key(IDPuesto)

);

IF OBJECT_ID('Deducciones') IS NOT NULL
   DROP TABLE Deducciones

CREATE TABLE Deducciones(
IDDeduccion					INT IDENTITY(0,1) NOT NULL,
Porcentaje					FLOAT,
Cantidad					FLOAT,
Descripcion					VARCHAR(30) NOT NULL,

CONSTRAINT PK_Deducciones
	Primary Key(IDDeduccion)

);

IF OBJECT_ID('Percepciones') IS NOT NULL
   DROP TABLE Percepciones

CREATE TABLE Percepciones(
IDPercepcion				INT IDENTITY(0,1) NOT NULL,
Porcentaje					FLOAT,
Cantidad					FLOAT,
Descripcion					VARCHAR(30) NOT NULL,

CONSTRAINT PK_Percepcion
	Primary Key(IDPercepcion)

);

IF OBJECT_ID('Percepciones') IS NOT NULL
   DROP TABLE Percepciones

CREATE TABLE Percepciones(
IDPercepcion				INT IDENTITY(0,1) NOT NULL,
Porcentaje					FLOAT,
Cantidad					FLOAT,
Descripcion					VARCHAR(30) NOT NULL,

CONSTRAINT PK_Percepcion
	Primary Key(IDPercepcion)

);

IF OBJECT_ID('Empleados') IS NOT NULL
   DROP TABLE Empleados

CREATE TABLE Empleados(
NumeroEmpleado				INT IDENTITY(1000,1) NOT NULL,
CURP						VARCHAR(18) NOT NULL UNIQUE,
NSS							VARCHAR(11) NOT NULL,
RFC							VARCHAR(16) NOT NULL UNIQUE,
NombreU						VARCHAR(30) NOT NULL UNIQUE,
Contraseña					VARCHAR(10) NOT NULL,
TipoUsuario					BIT DEFAULT 0,
Estatus						BIT DEFAULT 1,
Email						VARCHAR(30) NOT NULL,
Telefono                    INT NOT NULL,
Domicilio					INT NOT NULL,
FechaInicio					DATE NOT NULL,
FechaNacimiento				DATE NOT NULL,
Nombres						VARCHAR(30) NOT NULL,
ApPaterno					VARCHAR(30) NOT NULL,
ApMaterno                   VARCHAR(30) NOT NULL,
Departamento				INT NOT NULL,
Puesto						INT NOT NULL,

CONSTRAINT PK_Empleado
	Primary Key(NumeroEmpleado),

CONSTRAINT FK_Empleado_Domicilio
	Foreign Key(Domicilio)
	References Domicilios(IDDomicilio),

CONSTRAINT FK_Empleado_Telefono
	Foreign Key(Telefono)
	References Telefonos(IDTelefonos),

CONSTRAINT FK_Empresa_Puesto
	Foreign Key(Puesto)
	References Puestos(IDPuesto),

CONSTRAINT FK_Empresa_Departamento
	Foreign Key(Departamento)
	References Departamentos(IDDepartamento)

);

IF OBJECT_ID('Nominas') IS NOT NULL
   DROP TABLE Nominas

CREATE TABLE Nominas(
IDNomina					INT IDENTITY(1000, 1)NOT NULL,
FolioFiscal					VARCHAR(32) NOT NULL,
Empleado					INT NOT NULL,
Puesto						INT NOT NULL,
Departamento				INT NOT NULL,
RFCEmpresa					VARCHAR(16) NOT NULL,
Fecha						DATE NOT NULL,
SueldoBruto					FLOAT NOT NULL,
SueldoNeto					FLOAT,

CONSTRAINT PK_Nomina
	Primary Key(IDNomina),

CONSTRAINT FK_Nomina_Departamento
	Foreign Key(Departamento)
	References Departamentos(IDDepartamento),

CONSTRAINT FK_Nomina_Puesto
	Foreign Key(Puesto)
	References Puestos(IDPuesto),

CONSTRAINT FK_Nomina_Empleado
	Foreign Key(Empleado)
	References Empleados(NumeroEmpleado),

CONSTRAINT FK_Nomina_Empresa
	Foreign Key(RFCEmpresa)
	References Empresa(RFC),

);

IF OBJECT_ID('ListaPercepciones') IS NOT NULL
   DROP TABLE ListaPercepciones

CREATE TABLE ListaPercepciones(
IDListaP					INT IDENTITY(0,1) NOT NULL,
Empleado					INT NOT NULL,
Percepcion					INT NOT NULL,
Fecha						DATE NOT NULL,
Cantidad					FLOAT NOT NULL,
Nomina						INT,

CONSTRAINT PK_ListaPercepciones
	Primary Key(IDListaP),

CONSTRAINT FK_ListaP_Empleado
	Foreign Key(Empleado)
	References Empleados(NumeroEmpleado),

CONSTRAINT FK_ListaP_Percepcion
	Foreign Key(Percepcion)
	References Percepciones(IDPercepcion),

CONSTRAINT FK_ListaP_Nomina
	Foreign Key(Nomina)
	References Nominas(IDNomina)

);

IF OBJECT_ID('ListaDeducciones') IS NOT NULL
   DROP TABLE ListaDeducciones

CREATE TABLE ListaDeducciones(
IDListaD					INT IDENTITY(0,1) NOT NULL,
Empleado					INT NOT NULL,
Deduccion					INT NOT NULL,
Fecha						DATE NOT NULL,
Cantidad					FLOAT NOT NULL,
Nomina						INT,

CONSTRAINT PK_ListaDeducciones
	Primary Key(IDListaD),

CONSTRAINT FK_ListaD_Empleado
	Foreign Key(Empleado)
	References Empleados(NumeroEmpleado),

CONSTRAINT FK_ListaD_Deduccion
	Foreign Key(Deduccion)
	References Deducciones(IDDeduccion),

CONSTRAINT FK_ListaD_Nomina
	Foreign Key(Nomina)
	References Nominas(IDNomina)

);

