Use DB_MAD
Go

IF OBJECT_ID('sp_GestionPercepciones') IS NOT NULL
BEGIN
    DROP PROCEDURE sp_GestionPercepciones;
END;
Go

CREATE PROCEDURE sp_GestionPercepciones
(
	@Op							CHAR(1),
	@IDPercepcion				INT = NULL,
	@Porcentaje					FLOAT = NULL,
	@Cantidad					FLOAT = NULL,
	@Descripcion				VARCHAR(10) = NULL

)
AS
BEGIN

   IF @Op = 'I' --insert
   Begin
   INSERT INTO Percepciones(Porcentaje, Cantidad, Descripcion)
               VALUES(@Porcentaje, @Cantidad, @Descripcion);
   END

   IF @Op = 'U' --update
   BEGIN
      UPDATE Percepciones 
         SET 
			   Porcentaje = ISNULL(@Porcentaje, Porcentaje),
			   Cantidad = ISNULL(@Cantidad, Cantidad),
			   Descripcion = ISNULL(@Descripcion, Descripcion)
		 WHERE IDPercepcion = @IDPercepcion
   END

   IF @Op = 'D' --delete
   BEGIN
       DELETE FROM Percepciones 
	       WHERE IDPercepcion = @IDPercepcion;
   END

   IF @Op = 'S' --select individual
   BEGIN
       SELECT IDPercepcion, Porcentaje, Cantidad, Descripcion
			FROM Percepciones WHERE IDPercepcion = @IDPercepcion
   END

   IF @Op = 'T' --select todos
   BEGIN
       SELECT IDPercepcion, Porcentaje, Cantidad, Descripcion
			FROM Percepciones 
   END

   IF @Op = 'V' --vista todos
   BEGIN
       SELECT ID, Porcentaje, Cantidad, Descripcion
			FROM vw_Percepciones 
   END

   IF @Op = 'M' --max id
   BEGIN
       SELECT MAX(IDPercepcion)
			FROM Percepciones
   END

END;
Go
