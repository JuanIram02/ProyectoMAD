Use DB_MAD
Go

IF OBJECT_ID('sp_GestionNominas') IS NOT NULL
BEGIN
    DROP PROCEDURE sp_GestionNominas;
END;
Go

CREATE PROCEDURE sp_GestionNominas
(
	@Op							CHAR(1),
    @IDNomina					INT = NULL, 
	@FolioFiscal				VARCHAR(32) = NULL,
	@Empleado					INT = NULL,
	@Departamento				INT = NULL,
	@Puesto						INT = NULL,
	@RFCEmpresa					VARCHAR(16) = NULL,
	@Fecha						DATE = NULL,
	@SueldoBruto				FLOAT = NULL,
	@SueldoNeto					FLOAT = NULL

)
AS
BEGIN

   DECLARE @Hoy DATETIME;
   SET @Hoy = GETDATE();

   IF @Op = 'I' --insert 
   Begin
   INSERT INTO Nominas(FolioFiscal, Empleado, Departamento, Puesto, RFCEmpresa, Fecha, SueldoBruto, SueldoNeto)
               VALUES(@FolioFiscal, @Empleado, @Departamento, @Puesto, @RFCempresa, @Fecha, @SueldoBruto, @SueldoNeto);
   END

   IF @Op = 'U' --update
   BEGIN
      UPDATE Nominas 
         SET 
			 FolioFiscal = ISNULL(@FolioFiscal, FolioFiscal), 
			 Empleado = ISNULL(@Empleado, Empleado), 
			 Departamento = ISNULL(@Departamento, Departamento), 
			 Puesto = ISNULL(@Puesto, Puesto), 
			 RFCempresa = ISNULL(@RFCempresa, RFCempresa), 
			 Fecha = ISNULL(@Fecha, Fecha), 
			 SueldoBruto = ISNULL(@SueldoBruto, SueldoBruto), 
			 SueldoNeto = ISNULL(@SueldoNeto, SueldoNeto)
	           
		 WHERE IDNomina = @IDNomina
   END

   IF @Op = 'D' --delete
   BEGIN
       DELETE FROM Nominas 
	       WHERE IDNomina = @IDNomina
   END

   IF @Op = 'S' --select individual
   BEGIN
       SELECT IDNomina, FolioFiscal, Empleado, Departamento, Puesto, RFCempresa, Fecha, SueldoBruto, SueldoNeto
			FROM Nominas WHERE IDNomina = @IDNomina
   END

   IF @Op = 'T' --select todos
   BEGIN
      SELECT IDNomina, FolioFiscal, Empleado, Departamento, Puesto, RFCempresa, Fecha, SueldoBruto, SueldoNeto
			FROM Nominas 
   END

   IF @Op = 'M' --sig id
   BEGIN
        SELECT MAX(IDNomina) + 1 FROM Nominas
   END

   IF @Op = 'V' --vista
   BEGIN
		SELECT ID, Fecha, Nombre, Departamento, Puesto, [Folio fiscal], Sueldo 
			FROM vw_Nominas
   END

END;
Go