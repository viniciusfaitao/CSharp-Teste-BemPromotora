ALTER PROCEDURE [dbo].[quantidadeCidades]

AS
BEGIN
	
	SELECT 
		UF,
		COUNT(UF) AS Quantidade
	FROM
		Cidades

	GROUP BY UF;
END
GO