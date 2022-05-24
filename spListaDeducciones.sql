Use DB_MAD
Go

IF OBJECT_ID('sp_GestionListaDeducciones') IS NOT NULL
BEGIN
    DROP PROCEDURE sp_GestionListaDeducciones;
END;
Go

CREATE PROCEDURE sp_GestionListaDeducciones
(
	@Op								CHAR(1),
	@IDListaD						INT = NULL,
	@Empleado						INT = NULL,
	@Deduccion						INT = NULL,
	@Fecha							DATE = NULL,
	@FechaAux						DATE = NULL,  
	@Cantidad						FLOAT = NULL, 
	@Nomina							INT = NULL 
)
AS
BEGIN

   IF @Op = 'I' --insert
   Begin
   INSERT INTO ListaDeducciones(Empleado, Deduccion, Fecha, Cantidad, Nomina)
               VALUES(@Empleado, @Deduccion, @Fecha, @Cantidad, @Nomina);
   END

   IF @Op = 'U' --update
   BEGIN
      UPDATE ListaDeducciones 
         SET 
			   Empleado = ISNULL(@Empleado, Empleado),
			   Deduccion = ISNULL(Deduccion, Deduccion),
			   Fecha = ISNULL(@Fecha, Fecha),
			   Cantidad = ISNULL(@Cantidad, Cantidad),
			   Nomina = ISNULL(@Nomina, Nomina)
		 WHERE IDListaD = @IDListaD;
   END

   IF @Op = 'D' --delete
   BEGIN
       DELETE FROM ListaDeducciones 
	       WHERE IDListaD = @IDListaD;
   END

   IF @Op = 'S' --select individual
   BEGIN
       SELECT IDListaD, Empleado, Deduccion, Fecha, Cantidad, Nomina
			FROM ListaDeducciones WHERE IDListaD = @IDListaD;
   END

   IF @Op = 'T' --select todos
   BEGIN
        SELECT IDListaD, Empleado, Deduccion, Fecha, Cantidad, Nomina
			FROM ListaDeducciones
   END

   IF @Op = 'F' --select fecha
   BEGIN
        SELECT IDListaD, Empleado, Deduccion, Fecha, Cantidad, Nomina
			FROM ListaDeducciones WHERE Empleado LIKE @Empleado AND Fecha >= @Fecha AND Fecha <= @FechaAux
   END

END;
Go
