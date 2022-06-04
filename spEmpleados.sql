Use DB_MAD
Go

IF OBJECT_ID('sp_GestionEmpleados') IS NOT NULL
BEGIN
    DROP PROCEDURE sp_GestionEmpleados;
END;
Go

CREATE PROCEDURE sp_GestionEmpleados
(
	@Op							CHAR(1),
    @NumeroEmpleado				INTEGER = NULL, 
	@CURP						VARCHAR(18) = NULL,
	@NSS						VARCHAR(11) = NULL,
	@RFC						VARCHAR(16) = NULL,
	@NombreU					VARCHAR(30) = NULL,
	@Contraseña					VARCHAR(10) = NULL,
	@TipoUsuario				BIT = NULL,
	@Estatus					BIT = NULL,
	@Email						VARCHAR(30) = NULL,
	@Telefono                   INT = NULL,
	@Domicilio					INT = NULL,
	@FechaInicio				DATE = NULL,
	@FechaNacimiento			DATE = NULL,
	@Nombres					VARCHAR(50) = NULL,
	@ApPaterno					VARCHAR(30) = NULL,
	@ApMaterno                  VARCHAR(30) = NULL,
	@Departamento				INT = NULL,
	@Puesto						INT = NULL

)
AS
BEGIN

   DECLARE @Hoy DATETIME;
   SET @Hoy = GETDATE();

   IF @Op = 'I' --insert
   Begin
   INSERT INTO Empleados(CURP, NSS, RFC, NombreU, Contraseña, TipoUsuario, Estatus, Email, Telefono, Domicilio, FechaInicio, FechaNacimiento, Nombres, ApPaterno, ApMaterno, Departamento, Puesto)
               VALUES(@CURP, @NSS, @RFC, @NombreU, @Contraseña, @TipoUsuario, @Estatus, @Email, @Telefono, @Domicilio, @Hoy, @FechaNacimiento, @Nombres, @ApPaterno, @ApMaterno, @Departamento, @Puesto);
   END

   IF @Op = 'U' --update
   BEGIN
      UPDATE Empleados 
         SET 
	           CURP =  ISNULL(@CURP, CURP),
		       NSS = ISNULL(@NSS, NSS),
		       RFC = ISNULL(@RFC, RFC),
		       NombreU = ISNULL(@NombreU, NombreU),
		       Contraseña = ISNULL(@Contraseña, Contraseña),
		       TipoUsuario = ISNULL(@TipoUsuario, TipoUsuario),
		       Estatus = ISNULL(@Estatus, Estatus),
			   Email = ISNULL(@Email, Email),
			   Telefono = ISNULL(@Telefono, Telefono),
			   Domicilio = ISNULL(@Domicilio, Domicilio),
			   FechaInicio = ISNULL(@FechaInicio, FechaInicio),
			   FechaNacimiento = ISNULL(@FechaNacimiento, FechaNacimiento),
			   Nombres = ISNULL(@Nombres, Nombres),
			   ApPaterno = ISNULL(@ApPaterno, ApPaterno),
			   ApMaterno = ISNULL(@ApMaterno, ApMaterno),
			   Departamento = ISNULL(@Departamento, Departamento),
			   Puesto = ISNULL(@Puesto, Puesto)
		 WHERE NumeroEmpleado = @NumeroEmpleado
   END

   IF @Op = 'D' --delete
   BEGIN
       DELETE FROM Empleados 
	       WHERE NumeroEmpleado = @NumeroEmpleado;
   END

   IF @Op = 'B' --baja lógica
   BEGIN
      UPDATE Empleados 
         SET 
	           Estatus = 0
		 WHERE NumeroEmpleado = @NumeroEmpleado
   END

   IF @Op = 'S' --select individual
   BEGIN
       SELECT NumeroEmpleado, CURP, NSS, RFC, NombreU, Contraseña, TipoUsuario, Estatus, Email, Telefono, Domicilio, FechaInicio, FechaNacimiento, Nombres, ApPaterno, ApMaterno, Departamento, Puesto 
			FROM Empleados WHERE NumeroEmpleado = @NumeroEmpleado
   END

   IF @Op = 'T' --select todos
   BEGIN
       SELECT NumeroEmpleado, CURP, NSS, RFC, NombreU, Contraseña, TipoUsuario, Estatus, Email, Telefono, Domicilio, FechaInicio, FechaNacimiento, Nombres, ApPaterno, ApMaterno, Departamento, Puesto 
			FROM Empleados 
   END

   IF @Op = 'L' --buscar por curp
   BEGIN
       SELECT NumeroEmpleado, CURP, NSS, RFC, NombreU, Contraseña, TipoUsuario, Estatus, Email, Telefono, Domicilio, FechaInicio, FechaNacimiento, Nombres, ApPaterno, ApMaterno, Departamento, Puesto 
			FROM Empleados WHERE CURP LIKE @CURP AND Estatus LIKE 1
   END

   IF @Op = 'P' --buscar por curp
   BEGIN
       SELECT NumeroEmpleado, CURP, NSS, RFC, NombreU, Contraseña, TipoUsuario, Estatus, Email, Telefono, Domicilio, FechaInicio, FechaNacimiento, Nombres, ApPaterno, ApMaterno, Departamento, Puesto 
			FROM Empleados WHERE RFC LIKE @RFC AND Estatus LIKE 1
   END

   IF @Op = 'N' --buscar por contraseña y nombre
   BEGIN
       SELECT NumeroEmpleado, CURP, NSS, RFC, NombreU, Contraseña, TipoUsuario, Estatus, Email, Telefono, Domicilio, FechaInicio, FechaNacimiento, Nombres, ApPaterno, ApMaterno, Departamento, Puesto 
			FROM Empleados WHERE NombreU LIKE @NombreU AND Contraseña LIKE @Contraseña AND Estatus LIKE 1
   END

   IF @Op = 'M' --buscar por nombre
   BEGIN
       SELECT NumeroEmpleado, CURP, NSS, RFC, NombreU, Contraseña, TipoUsuario, Estatus, Email, Telefono, Domicilio, FechaInicio, FechaNacimiento, Nombres, ApPaterno, ApMaterno, Departamento, Puesto 
			FROM Empleados WHERE NombreU LIKE @NombreU AND Estatus LIKE 1
   END

   IF @Op = 'X' --select solo a los activos
   BEGIN
       SELECT NumeroEmpleado, CURP, NSS, RFC, NombreU, Contraseña, TipoUsuario, Estatus, Email, Telefono, Domicilio, FechaInicio, FechaNacimiento, Nombres, ApPaterno, ApMaterno, Departamento, Puesto 
			FROM Empleados WHERE Estatus LIKE 1
   END

   IF @Op = 'V' --vista todos
   BEGIN
       SELECT [Numero de Empleado], Nombre, Departamento, Puesto, RFC, [Fecha de inicio]
			FROM vw_Empleados 
   END

   IF @Op = 'W' --vista numero empleado
   BEGIN
       SELECT [Numero de Empleado], Nombre, Departamento, Puesto, RFC, [Fecha de inicio]
			FROM vw_Empleados WHERE [Numero de Empleado] = @NumeroEmpleado
   END

   IF @Op = 'Y' --vista nombre
   BEGIN
       SELECT [Numero de Empleado], Nombre, Departamento, Puesto, RFC, [Fecha de inicio]
			FROM vw_Empleados WHERE Nombre LIKE '%' + @Nombres + '%'
   END

   IF @Op = 'F' --despues de una fecha
   BEGIN
      SELECT NumeroEmpleado, CURP, NSS, RFC, NombreU, Contraseña, TipoUsuario, Estatus, Email, Telefono, Domicilio, FechaInicio, FechaNacimiento, Nombres, ApPaterno, ApMaterno, Departamento, Puesto 
			FROM Empleados WHERE Estatus LIKE 1 AND FechaInicio >= @FechaNacimiento
   END

   IF @Op = 'G' --antes de una fecha
   BEGIN
      SELECT NumeroEmpleado, CURP, NSS, RFC, NombreU, Contraseña, TipoUsuario, Estatus, Email, Telefono, Domicilio, FechaInicio, FechaNacimiento, Nombres, ApPaterno, ApMaterno, Departamento, Puesto 
			FROM Empleados WHERE Estatus LIKE 1 AND FechaInicio <= @FechaNacimiento
   END

END;
Go