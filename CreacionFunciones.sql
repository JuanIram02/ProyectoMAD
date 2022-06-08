USE DB_MAD;
Go

--Cuenta empleados por departamento

IF OBJECT_ID('cuentaD') IS NOT NULL
   DROP FUNCTION cuentaD

Go

CREATE FUNCTION cuentaD(@departamento INT, @Fecha DATE) 
	RETURNS INT AS
BEGIN

	DECLARE @numEmpleados INT;

		SELECT @numEmpleados = COUNT(*)
		FROM Empleados				
		WHERE Departamento = @Departamento AND FechaInicio <= @Fecha
		GROUP BY Departamento
	
		IF @numEmpleados IS NULL
			set @numEmpleados =  0		

	RETURN @numEmpleados

END;
Go

--Cuenta empleados por departamento y puesto

IF OBJECT_ID('cuentaDP') IS NOT NULL
   DROP FUNCTION cuentaDP

Go

CREATE FUNCTION cuentaDP(@departamento INT, @puesto INT, @Fecha DATE) 
	RETURNS INT AS
BEGIN

	DECLARE @numEmpleados INT;

		SELECT @numEmpleados = COUNT(*)
		FROM Empleados		
		WHERE Departamento = @Departamento AND Puesto = @Puesto AND FechaInicio <= @Fecha
		GROUP BY Departamento
	
		IF @numEmpleados IS NULL
			set @numEmpleados =  0		

	RETURN @numEmpleados

END;
Go