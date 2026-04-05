CREATE PROCEDURE ObtenerVehiculos
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
SELECT        Vehiculo.Id, Modelos.Nombre AS Modelo, Vehiculo.IdModelo, Vehiculo.Placa, Vehiculo.Color, Marcas.Nombre AS Marca, Vehiculo.Anio, Vehiculo.Precio, Vehiculo.CorreoPropietario, Vehiculo.TelefonoPropietario
FROM            Vehiculo INNER JOIN
                         Modelos ON Vehiculo.IdModelo = Modelos.Id INNER JOIN
                         Marcas ON Modelos.IdMarca = Marcas.Id
END