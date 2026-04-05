
CREATE PROCEDURE ObtenerUsuario
	-- Add the parameters for the stored procedure here
	@NombreUsuario VARCHAR(MAX),
	@CorreoElectronico VARCHAR(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Id, NombreUsuario, PasswordHash, CorreoElectronico, FechaCreacion, FechaModifica, UsuarioCrea, UsuarioModifica
	FROM   Usuarios
	WHERE  (NombreUsuario = @NombreUsuario) OR (CorreoElectronico = @CorreoElectronico)
END