Use DB_MAD
Go

IF OBJECT_ID('sp_GestionTelefonos') IS NOT NULL
BEGIN
    DROP PROCEDURE sp_GestionTelefonos;
END;
Go

CREATE PROCEDURE sp_GestionTelefonos
(
	@Op							CHAR(1),
	@IDTelefonos				INT = NULL,
	@Telefono1					VARCHAR(10) = NULL, 
	@Telefono2					VARCHAR(10) = NULL, 
	@Telefono3					VARCHAR(10) = NULL 
)
AS
BEGIN

   IF @Op = 'I' --insert
   Begin
   INSERT INTO Telefonos(Telefono1, Telefono2, Telefono3)
               VALUES(@Telefono1, @Telefono2, @Telefono3);
   END

   IF @Op = 'U' --update
   BEGIN
      UPDATE Telefonos 
         SET 
			   Telefono1 = ISNULL(@Telefono1, Telefono1),
			   Telefono2 = ISNULL(@Telefono2, Telefono2),
			   Telefono3 = ISNULL(@Telefono3, Telefono3)
		 WHERE IDTelefonos = @IDTelefonos;
   END

   IF @Op = 'D' --delete
   BEGIN
       DELETE FROM Telefonos 
	       WHERE IDTelefonos = @IDTelefonos;
   END

   IF @Op = 'S' --select individual
   BEGIN
       SELECT IDTelefonos, Telefono1, Telefono2, Telefono3
			FROM Telefonos WHERE IDTelefonos = @IDTelefonos;
   END

   IF @Op = 'T' --select todos
   BEGIN
        SELECT IDTelefonos, Telefono1, Telefono2, Telefono3
			FROM Telefonos
   END

   IF @Op = 'M' --max id
   BEGIN
        SELECT MAX(IDTelefonos) FROM Telefonos
   END

END;
Go

