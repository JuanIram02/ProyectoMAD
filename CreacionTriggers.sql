USE DB_MAD;
Go

--Insert nomina

IF OBJECT_ID ('trg_Nomina') IS NOT NULL
	DROP TRIGGER trg_Nomina;
Go

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
Go

--Delete deduccion

IF OBJECT_ID ('trg_Deduccion') IS NOT NULL
	DROP TRIGGER trg_Deduccion;
Go

CREATE TRIGGER trg_Deduccion
	ON Deducciones
	INSTEAD OF DELETE
AS
BEGIN

DECLARE @IDDeduccion AS INT;

SELECT @IDDeduccion = IDDeduccion FROM inserted;

DELETE FROM ListaDeducciones WHERE Deduccion = @IDDeduccion;

DELETE FROM Deducciones WHERE IDDeduccion = @IDDeduccion;

END;
Go

--Delete percepcion

IF OBJECT_ID ('trg_Percepcion') IS NOT NULL
	DROP TRIGGER trg_Percepcion;
Go

CREATE TRIGGER trg_Percepcion
	ON Percepciones
	INSTEAD OF DELETE
AS
BEGIN

DECLARE @IDPercepcion AS INT;

SELECT @IDPercepcion = @IDPercepcion FROM inserted;

DELETE FROM ListaPercepciones WHERE Percepcion = @IDPercepcion;

DELETE FROM Percepciones WHERE IDPercepcion = @IDPercepcion;

END;
Go