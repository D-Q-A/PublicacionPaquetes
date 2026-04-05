CREATE PROCEDURE AgregarVehiculo

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
    INSERT INTO [dbo].[Vehiculo]
               ([Id]
               ,[IdModelo]
               ,[Placa]
               ,[Color]
               ,[Anio]
               ,[Precio]
               ,[CorreoPropietario]
               ,[TelefonoPropietario])
         VALUES
               (@Id
    ,@IdModelo
    ,@Placa
    ,@Color
    ,@Anio
    ,@Precio
    ,@CorreoPropietario
    ,@TelefonoPropietario)
    SELECT @Id
COMMIT TRANSACTION
END