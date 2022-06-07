USE DB_MAD;
Go

--Cuenta empleados por departamento y puesto

IF OBJECT_ID('cuentaDP') IS NOT NULL
   DROP FUNCTION cuentaDP

Go

CREATE FUNCTION cuentaDP(@departamento INT, @puesto INT) 
	RETURNS INT AS
BEGIN
	DECLARE @numEmpleados INT;

	SELECT @numEmpleados = COUNT(*)
		FROM Empleados		
		WHERE @departamento = Departamento 
		GROUP BY Departamento
	
	IF @numEmpleados IS NULL
		set @numEmpleados =  0
	
	RETURN @numEmpleados

END;
Go