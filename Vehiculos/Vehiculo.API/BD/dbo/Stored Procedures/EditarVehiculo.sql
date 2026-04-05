CREATE PROCEDURE EditarVehiculo

@Id AS uniqueidentifier
,@IdModelo AS uniqueidentifier
,@Placa AS nvarchar(MAX)
,@Color AS nvarchar(MAX)
,@Anio AS int
,@Precio AS decimal(18,0)
,@CorreoPropietario AS nvarchar(MAX)
,@TelefonoPropietario AS nvarchar(MAX)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    BEGIN TRANSACTION
        UPDATE [dbo].[Vehiculo]
           SET [IdModelo] = @IdModelo
              ,[Placa] = @Placa
              ,[Color] = @Color
              ,[Anio] = @Anio
              ,[Precio] = @Precio
              ,[CorreoPropietario] = @CorreoPropietario
              ,[TelefonoPropietario] = @TelefonoPropietario
         WHERE Id = @Id
         SELECT @Id
 COMMIT TRANSACTION


END