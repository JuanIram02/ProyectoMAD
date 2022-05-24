Use DB_MAD
Go

IF OBJECT_ID('sp_GestionDomicilios') IS NOT NULL
BEGIN
    DROP PROCEDURE sp_GestionDomicilios;
END;
Go

CREATE PROCEDURE sp_GestionDomicilios
(
	@Op							CHAR(1),
	@IDDomicilio				INT = NULL,
	@Calle						VARCHAR(30) = NULL, 
	@Numero						VARCHAR(5) = NULL, 
	@Apartamento				VARCHAR(5) = NULL,
	@CodigoPostal				VARCHAR(5) = NULL,
	@Ciudad						VARCHAR(30) = NULL,
	@Pais						VARCHAR(30) = NULL
)
AS
BEGIN

   IF @Op = 'I' --insert
   Begin
   INSERT INTO Domicilios(Calle, Numero, Apartamento, CodigoPostal, Ciudad, Pais)
               VALUES(@Calle, @Numero, @Apartamento, @CodigoPostal, @Ciudad, @Pais);
   END

   IF @Op = 'U' --update
   BEGIN
      UPDATE Domicilios 
         SET 
			   Calle = ISNULL(@Calle, Calle),
			   Numero = ISNULL(@Numero, Numero),
			   Apartamento = ISNULL(@Apartamento, Apartamento),
			   CodigoPostal = ISNULL(@CodigoPostal, CodigoPostal),
			   Ciudad = ISNULL(@Ciudad, Ciudad),
			   Pais = ISNULL(@Pais, Pais)
		 WHERE IDDomicilio = @IDDomicilio;
   END

   IF @Op = 'D' --delete
   BEGIN
       DELETE FROM Domicilios 
	       WHERE IDDomicilio = @IDDomicilio;
   END

   IF @Op = 'S' --select individual
   BEGIN
       SELECT IDDomicilio, Calle, Numero, Apartamento, CodigoPostal, Ciudad, Pais
			FROM Domicilios WHERE IDDomicilio = @IDDomicilio
   END

   IF @Op = 'T' --select todos
   BEGIN
       SELECT IDDomicilio, Calle, Numero, Apartamento, CodigoPostal, Ciudad, Pais
			FROM Domicilios 
   END

    IF @Op = 'M' --max id
   BEGIN
        SELECT MAX(IDDomicilio) FROM Domicilios
   END

END;

GO


