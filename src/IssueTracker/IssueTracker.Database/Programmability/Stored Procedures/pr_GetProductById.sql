CREATE PROCEDURE [dbo].[pr_GetProductById]
	@ProductId UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;
	SELECT TOP(1) p.ProductId, p.ProductName, t.TeamId, t.TeamName
	FROM tb_Products p
	INNER JOIN tb_Teams t ON p.TeamId = t.TeamId
	WHERE ProductId = @ProductId; 
END