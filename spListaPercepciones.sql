Use DB_MAD
Go

IF OBJECT_ID('sp_GestionListaPercepciones') IS NOT NULL
BEGIN
    DROP PROCEDURE sp_GestionListaPercepciones;
END;
Go

CREATE PROCEDURE sp_GestionListaPercepciones
(
	@Op								CHAR(1),
	@IDListaP						INT = NULL,
	@Empleado						INT = NULL,
	@Percepcion						INT = NULL,
	@Fecha							DATE = NULL,
	@FechaAux						DATE = NULL, 
	@Cantidad						FLOAT = NULL, 
	@Nomina							INT = NULL
)
AS
BEGIN

   IF @Op = 'I' --insert
   Begin
   INSERT INTO ListaPercepciones(Empleado, Percepcion, Fecha, Cantidad)
               VALUES(@Empleado, @Percepcion, @Fecha, @Cantidad);
   END

   IF @Op = 'U' --update
   BEGIN
      UPDATE ListaPercepciones 
         SET 
			   Empleado = ISNULL(@Empleado, Empleado),
			   Percepcion = ISNULL(@Percepcion, Percepcion),
			   Fecha = ISNULL(@Fecha, Fecha),
			   Cantidad = ISNULL(@Cantidad, Cantidad),
			   Nomina = ISNULL(@Nomina, Nomina)
		 WHERE IDListaP = @IDListaP;
   END

   IF @Op = 'D' --delete
   BEGIN
       DELETE FROM ListaPercepciones 
	       WHERE IDListaP = @IDListaP;
   END

   IF @Op = 'S' --select individual
   BEGIN
       SELECT IDListaP, Empleado, Percepcion, Fecha, Cantidad, Nomina
			FROM ListaPercepciones WHERE IDListaP = @IDListaP;
   END

   IF @Op = 'T' --select todos
   BEGIN
        SELECT IDListaP, Empleado, Percepcion, Fecha, Cantidad, Nomina
			FROM ListaPercepciones
   END

    IF @Op = 'F' --select fecha
   BEGIN
        SELECT IDListaP, Empleado, Percepcion, Fecha, Cantidad, Nomina
			FROM ListaPercepciones WHERE Empleado LIKE @Empleado AND Fecha >= @Fecha AND Fecha <= @FechaAux
   END

   IF @Op = 'N'
   BEGIN
		SELECT IDListaP, Empleado, Percepcion, Fecha, Cantidad
			FROM ListaPercepciones WHERE Nomina Like @Nomina
   END

END;
Go