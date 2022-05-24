
use DB_MAD;
Go

--Deducciones

IF OBJECT_ID('vw_Deducciones') IS NOT NULL
   DROP VIEW vw_Deducciones

Go

CREATE VIEW vw_Deducciones AS 
	SELECT IDDeduccion as ID, Porcentaje, Cantidad, Descripcion
			FROM Deducciones 
Go

--Percepciones

IF OBJECT_ID('vw_Percepciones') IS NOT NULL
   DROP VIEW vw_Percepciones

Go

CREATE VIEW vw_Percepciones AS 
	SELECT IDPercepcion as ID, Porcentaje, Cantidad, Descripcion
			FROM Percepciones 
Go

--Departamentos

IF OBJECT_ID('vw_Departamentos') IS NOT NULL
   DROP VIEW vw_Departamentos

Go

CREATE VIEW vw_Departamentos AS 
	SELECT IDDepartamento as ID, Nombre, SueldoBase as 'Sueldo por dia'
			FROM Departamentos WHERE Estatus = 1
Go

--Puestos

IF OBJECT_ID('vw_Puestos') IS NOT NULL
   DROP VIEW vw_Puestos

Go

CREATE VIEW vw_Puestos AS 
	SELECT IDPuesto as ID, Nombre, NivelSalarial as 'Nivel Salarial'
			FROM Puestos WHERE Estatus = 1
Go

--Puestos

IF OBJECT_ID('vw_Empleados') IS NOT NULL
   DROP VIEW vw_Empleados

Go

CREATE VIEW vw_Empleados AS 

	SELECT E.NumeroEmpleado as 'Numero de Empleado', CAST(E.Nombres + ' ' + E.ApPaterno + ' ' + E.ApMaterno as varchar) as Nombre, D.Nombre as Departamento, P.Nombre as Puesto, E.RFC, E.FechaInicio as 'Fecha de inicio'
		FROM Empleados E 
			INNER JOIN Departamentos D
			ON E.Departamento = D.IDDepartamento
			INNER JOIN Puestos P 
			ON E.Puesto = P.IDPuesto
		WHERE E.Estatus = 1;	
Go

--Nominas

IF OBJECT_ID('vw_Nominas') IS NOT NULL
   DROP VIEW vw_Nominas

Go

CREATE VIEW vw_Nominas AS 
	SELECT N.IDNomina as ID, N.Fecha, CAST(E.Nombres + ' ' + E.ApPaterno + ' ' + E.ApMaterno as varchar) as Nombre, D.Nombre as Departamento, P.Nombre as Puesto, N.FolioFiscal as 'Folio fiscal', CONVERT(VARCHAR,CAST(N.SueldoNeto AS MONEY),1) as 'Sueldo'
		FROM Nominas N
			INNER JOIN Empleados E
			ON N.Empleado = E.NumeroEmpleado
			INNER JOIN Departamentos D
			ON N.Departamento = D.IDDepartamento
			INNER JOIN Puestos P 
			ON N.Puesto = P.IDPuesto

Go

--Reporte general de Nomina

IF OBJECT_ID('vw_ReporteNomina') IS NOT NULL
   DROP VIEW vw_Nominas

Go

CREATE VIEW vw_Nominas AS 
	SELECT N.IDNomina as ID, N.Fecha, CAST(E.Nombres + ' ' + E.ApPaterno + ' ' + E.ApMaterno as varchar) as Nombre, D.Nombre as Departamento, P.Nombre as Puesto, N.FolioFiscal as 'Folio fiscal', CONVERT(VARCHAR,CAST(N.SueldoNeto AS MONEY),1) as 'Sueldo'
		FROM Nominas N
			INNER JOIN Empleados E
			ON N.Empleado = E.NumeroEmpleado
			INNER JOIN Departamentos D
			ON N.Departamento = D.IDDepartamento
			INNER JOIN Puestos P 
			ON N.Puesto = P.IDPuesto

Go