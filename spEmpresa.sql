Use DB_MAD
Go

IF OBJECT_ID('sp_GestionEmpresa') IS NOT NULL
BEGIN
    DROP PROCEDURE sp_GestionEmpresa;
END;
Go

CREATE PROCEDURE sp_GestionEmpresa
(
	@Op							CHAR(1),
	@RFC						VARCHAR(16) = NULL,
	@RazonSocial				VARCHAR(30) = NULL, 
	@RegistroPatronal			VARCHAR(30) = NULL, 
	@Fecha_Inicio				DATE = NULL,
	@Domicilio					INT = NULL,
	@Telefono					INT = NULL,
	@Email						VARCHAR(30)
)
AS
BEGIN

   IF @Op = 'I' --insert
   Begin
   INSERT INTO Empresa(RFC, RazonSocial, RegistroPatronal, Fecha_Inicio, Domicilio, Telefono, Email)
               VALUES(@RFC, @RazonSocial, @RegistroPatronal, @Fecha_Inicio, @Domicilio, @Telefono, @Email);
   END

   IF @Op = 'U' --update
   BEGIN
      UPDATE Empresa 
         SET 
			   RazonSocial = ISNULL(@RazonSocial, RazonSocial),
			   RegistroPatronal = ISNULL(@RegistroPatronal, RegistroPatronal),
			   Fecha_Inicio = ISNULL(@Fecha_Inicio, Fecha_Inicio),
			   Domicilio = ISNULL(@Domicilio, Domicilio),
			   Telefono = ISNULL(@Telefono, Telefono),
			   Email = ISNULL(@Email, Email)
		 WHERE RFC = @RFC;
   END

   IF @Op = 'D' --delete
   BEGIN
       DELETE Empresa 	     
   END

   IF @Op = 'T' --select 
   BEGIN
       SELECT RFC, RazonSocial, RegistroPatronal, Fecha_Inicio, Domicilio, Telefono, Email
			FROM Empresa 
   END

END;
Go
