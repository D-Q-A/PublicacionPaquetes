
CREATE PROCEDURE ObtenerPerfilesxUsuario 
	-- Add the parameters for the stored procedure here
	@NombreUsuario VARCHAR(MAX),
	@CorreoElectronico VARCHAR(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Perfiles.Id, Perfiles.Nombre
	FROM   Perfiles INNER JOIN
					PerfilesxUsuario ON Perfiles.Id = PerfilesxUsuario.IdPerfil INNER JOIN
					Usuarios ON PerfilesxUsuario.IdUsuario = Usuarios.Id
	WHERE  (Usuarios.NombreUsuario = @NombreUsuario) OR (Usuarios.CorreoElectronico = @CorreoElectronico)
END