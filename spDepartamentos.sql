Use DB_MAD
Go

IF OBJECT_ID('sp_GestionDepartamentos') IS NOT NULL
BEGIN
    DROP PROCEDURE sp_GestionDepartamentos;
END;
Go

CREATE PROCEDURE sp_GestionDepartamentos
(
	@Op							CHAR(1),
	@IDDepartamento				INT = NULL,
	@Nombre						VARCHAR(10) = NULL, 
	@SueldoBase					FLOAT = NULL,
	@Estatus					BIT = NULL

)
AS
BEGIN

   IF @Op = 'I' --insert
   Begin
   INSERT INTO Departamentos(Nombre, SueldoBase, Estatus)
               VALUES(@Nombre, @SueldoBase, 1);
   END

   IF @Op = 'U' --update
   BEGIN
      UPDATE Departamentos 
         SET 
			   Nombre = ISNULL(@Nombre, Nombre),
			   SueldoBase = ISNULL(@SueldoBase, SueldoBase),
			   Estatus = ISNULL(@Estatus, Estatus)
		 WHERE IDDepartamento = @IDDepartamento
   END

   IF @Op = 'D' --delete
   BEGIN
       DELETE FROM Departamentos 
	       WHERE IDDepartamento = @IDDepartamento;
   END

   IF @Op = 'B' --baja lógica
   BEGIN
      UPDATE Departamentos 
         SET 
	           Estatus = 0
		 WHERE IDDepartamento = @IDDepartamento
   END

   IF @Op = 'S' --select individual
   BEGIN
       SELECT IDDepartamento, Nombre, SueldoBase, Estatus
			FROM Departamentos WHERE IDDepartamento = @IDDepartamento
   END

   IF @Op = 'T' --select todos
   BEGIN
       SELECT IDDepartamento, Nombre, SueldoBase, Estatus
			FROM Departamentos 
   END

   IF @Op = 'X' --select solo a los activos
   BEGIN
       SELECT IDDepartamento, Nombre, SueldoBase
			FROM Departamentos WHERE Estatus LIKE 1;
   END

   IF @Op = 'F' --por su nombre
   BEGIN
       SELECT IDDepartamento, Nombre, SueldoBase
			FROM Departamentos WHERE Nombre LIKE @Nombre;
   END

   IF @Op = 'V' --vista todos
   BEGIN
       SELECT ID, Nombre, [Sueldo por dia]
			FROM vw_Departamentos 
   END

END;
Go


