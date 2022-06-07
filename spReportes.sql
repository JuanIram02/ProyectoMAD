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
    @Fecha						DATE = NULL,
	@Aux						INT = NULL,
	@Departamento				INT = NULL,
	@Puesto						INT = NULL

)
AS
BEGIN

IF @Op = 'G' --General de Nomina
   BEGIN
        SELECT Departamento, Puesto, Nombre, [Fecha de Inicio], Edad, [Sueldo Diario]
			FROM vw_ReporteGeneralNomina WHERE [Fecha de Inicio] <= @Fecha ORDER BY Departamento
   END

IF @Op = 'H' --General de Nomina
   BEGIN

		IF @Aux IS NULL --Todos los departamentos
		BEGIN

			SELECT D.Nombre as Departamento, dbo.cuentaD(D.IDDepartamento) as 'Numero de Empleados'
				FROM Departamentos D
				ORDER BY Departamento

		END

		IF @Aux = 0 -- 1 departamento
		BEGIN

			SELECT D.Nombre as Departamento, dbo.cuentaD(D.IDDepartamento) as 'Numero de Empleados'
				FROM Departamentos D
				WHERE IDDepartamento = @Departamento
				ORDER BY Departamento

		END

		IF @Aux = 1 -- Todos los departamentos y puestos
		BEGIN

			SELECT D.Nombre as Departamento, P.Nombre as Puesto, dbo.cuentaDP(D.IDDepartamento, P.IDPuesto) as 'Numero de Empleados'
			FROM Departamentos D
				FULL JOIN Empleados E
				ON D.IDDepartamento = E.Departamento
				INNER JOIN Puestos P
				ON E.Puesto = P.IDPuesto

					
		END

		IF @Aux = 2 -- Todos los departamentos y 1 puesto
		BEGIN

			SELECT D.Nombre as Departamento, P.Nombre as Puesto, dbo.cuentaDP(D.IDDepartamento, P.IDPuesto) as 'Numero de Empleados'
			FROM Departamentos D
				FULL JOIN Empleados E
				ON D.IDDepartamento = E.Departamento
				INNER JOIN Puestos P
				ON E.Puesto = P.IDPuesto
			WHERE P.IDPuesto = @Puesto
					
		END

		IF @Aux = 3 -- 1 departamento y 1 puesto
		BEGIN

			SELECT D.Nombre as Departamento, P.Nombre as Puesto, dbo.cuentaDP(D.IDDepartamento, P.IDPuesto) as 'Numero de Empleados'
			FROM Departamentos D
				FULL JOIN Empleados E
				ON D.IDDepartamento = E.Departamento
				INNER JOIN Puestos P
				ON E.Puesto = P.IDPuesto
			WHERE D.IDDepartamento = @Departamento AND P.IDPuesto = @Puesto
					
		END

   END

END
GO
