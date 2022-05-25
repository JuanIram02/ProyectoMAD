Use DB_MAD
Go

IF OBJECT_ID('sp_Reportes') IS NOT NULL
BEGIN
    DROP PROCEDURE sp_Reportes;
END;
Go

CREATE PROCEDURE sp_Reportes
(
	@Op							CHAR(1),
    @Fecha						DATE

)
AS
BEGIN

IF @Op = 'G' --select fecha
   BEGIN
        SELECT Departamento, Puesto, Nombre, [Fecha de Inicio], Edad, [Sueldo Diario]
			FROM vw_ReporteGeneralNomina WHERE [Fecha de Inicio] <= @Fecha
   END

END
GO