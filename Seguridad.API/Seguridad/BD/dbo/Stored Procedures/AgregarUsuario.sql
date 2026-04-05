
CREATE PROCEDURE AgregarUsuario
	-- Add the parameters for the stored procedure here
@NombreUsuario VARCHAR(MAX),
@PasswordHash VARCHAR(MAX),
@CorreoElectronico VARCHAR(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @Id AS uniqueidentifier =NEWID();
	BEGIN TRAN

    -- Insert statements for procedure here
	INSERT INTO Usuarios
			(Id,
			 NombreUsuario,
			 PasswordHash,
			 CorreoElectronico)
			 VALUES
			 (@Id,
			 @NombreUsuario,
			 @PasswordHash,
			 @CorreoElectronico)
	SELECT @Id

	INSERT INTO PerfilesxUsuario
			(IdUsuario,
			IdPerfil)
			VALUES
			(@Id,
			2)

			COMMIT TRAN
END