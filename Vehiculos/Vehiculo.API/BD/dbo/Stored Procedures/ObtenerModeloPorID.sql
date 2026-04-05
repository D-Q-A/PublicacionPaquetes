CREATE PROCEDURE ObtenerModeloPorID
	@Id uniqueidentifier

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
SELECT        Modelos.Id, Marcas.Nombre AS Marca, Modelos.Nombre
FROM            Modelos INNER JOIN
                         Marcas ON Modelos.IdMarca = Marcas.Id
WHERE		  Modelos.IdMarca = @Id 
           
END