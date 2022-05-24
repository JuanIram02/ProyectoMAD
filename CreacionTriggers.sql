USE DB_MAD;
Go

--insert nomina

IF OBJECT_ID ('trg_Nomina') IS NOT NULL
	DROP TRIGGER trg_Nomina;
GO

CREATE TRIGGER trg_Nomina
	ON Nominas
	AFTER INSERT
AS
BEGIN

DECLARE @IDNomina AS INT;
DECLARE @Empleado AS INT;
DECLARE @Fecha AS DATE;
DECLARE @FechaAux AS DATE;
DECLARE @FechaNom AS DATE;

SELECT @IDNomina = IDNomina FROM inserted;
SELECT @Empleado = Empleado FROM inserted;
SELECT @FechaNom = Fecha FROM inserted;

SELECT @Fecha = DATEFROMPARTS(YEAR(@FechaNom), MONTH(@FechaNom), 1);
SELECT @FechaAUX = DATEFROMPARTS(YEAR(@FechaNom), MONTH(@FechaNom), DAY(EOMONTH(@FechaNom)));

UPDATE ListaPercepciones SET Nomina = @IDNomina WHERE Empleado LIKE @Empleado AND Fecha >= @Fecha AND Fecha <= @FechaAux

UPDATE ListaDeducciones SET Nomina = @IDNomina WHERE Empleado LIKE @Empleado AND Fecha >= @Fecha AND Fecha <= @FechaAux

END;