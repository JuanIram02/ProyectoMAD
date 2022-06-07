Use DB_MAD
Go

IF OBJECT_ID('sp_GestionPuestos') IS NOT NULL
BEGIN
    DROP PROCEDURE sp_GestionPuestos;
END;
Go

CREATE PROCEDURE sp_GestionPuestos
(
	@Op							CHAR(1),
	@IDPuesto					INT = NULL,
	@Nombre						VARCHAR(10) = NULL, 
	@NivelSalarial				FLOAT = NULL,
	@Estatus					BIT = NULL

)
AS
BEGIN

   IF @Op = 'I' --insert
   Begin
   INSERT INTO Puestos(Nombre, NivelSalarial, Estatus)
               VALUES(@Nombre, @NivelSalarial, 1);
   END

   IF @Op = 'U' --update
   BEGIN
      UPDATE Puestos 
         SET 
			   Nombre = ISNULL(@Nombre, Nombre),
			   NivelSalarial = ISNULL(@NivelSalarial, NivelSalarial),
			   Estatus = ISNULL(@Estatus, Estatus)
		 WHERE IDPuesto = @IDPuesto
   END

   IF @Op = 'D' --delete
   BEGIN
       DELETE FROM Puestos 
	       WHERE IDPuesto = @IDPuesto;
   END

   IF @Op = 'B' --baja lógica
   BEGIN
      UPDATE Puestos 
         SET 
	           Estatus = 0
		 WHERE IDPuesto = @IDPuesto
   END

   IF @Op = 'S' --select individual
   BEGIN
       SELECT IDPuesto, Nombre, NivelSalarial, Estatus
			FROM Puestos WHERE IDPuesto = @IDPuesto
   END

   IF @Op = 'T' --select todos
   BEGIN
       SELECT IDPuesto, Nombre, NivelSalarial, Estatus
			FROM Puestos 
   END

   IF @Op = 'X' --select solo a los activos
   BEGIN
       SELECT IDPuesto, Nombre, NivelSalarial
			FROM Puestos WHERE Estatus LIKE 1;
   END

   IF @Op = 'F' --por su nombre
   BEGIN
       SELECT IDPuesto, Nombre, NivelSalarial
			FROM Puestos WHERE Nombre LIKE @Nombre;
   END

   IF @Op = 'V' --vista todos
   BEGIN
       SELECT ID, Nombre, [Nivel Salarial]
			FROM vw_Puestos 
   END

END;
Go