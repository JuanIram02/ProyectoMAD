Use DB_MAD
Go

IF OBJECT_ID('sp_GestionDeducciones') IS NOT NULL
BEGIN
    DROP PROCEDURE sp_GestionDeducciones;
END;
Go

CREATE PROCEDURE sp_GestionDeducciones
(
	@Op							CHAR(1),
	@IDDeduccion				INT = NULL,
	@Porcentaje					FLOAT = NULL,
	@Cantidad					FLOAT = NULL,
	@Descripcion				VARCHAR(30) = NULL

)
AS
BEGIN

   IF @Op = 'I' --insert
   Begin
   INSERT INTO Deducciones(Porcentaje, Cantidad, Descripcion)
               VALUES(@Porcentaje, @Cantidad, @Descripcion);
   END

   IF @Op = 'U' --update
   BEGIN
      UPDATE Deducciones 
         SET 
			   Porcentaje = ISNULL(@Porcentaje, Porcentaje),
			   Cantidad = ISNULL(@Cantidad, Cantidad),
			   Descripcion = ISNULL(@Descripcion, Descripcion)
		 WHERE IDDeduccion = @IDDeduccion
   END

   IF @Op = 'D' --delete
   BEGIN
       DELETE FROM Deducciones 
	       WHERE IDDeduccion = @IDDeduccion;	

   END

   IF @Op = 'S' --select individual
   BEGIN
       SELECT IDDeduccion, Porcentaje, Cantidad, Descripcion
			FROM Deducciones WHERE IDDeduccion = @IDDeduccion
   END

   IF @Op = 'T' --select todos
   BEGIN
       SELECT IDDeduccion, Porcentaje, Cantidad, Descripcion
			FROM Deducciones 
   END

   IF @Op = 'V' --vista todos
   BEGIN
       SELECT ID, Porcentaje, Cantidad, Descripcion
			FROM vw_Deducciones 
   END

   IF @Op = 'M' --max id
   BEGIN
       SELECT MAX(IDDeduccion)
			FROM Deducciones
   END

END;
Go