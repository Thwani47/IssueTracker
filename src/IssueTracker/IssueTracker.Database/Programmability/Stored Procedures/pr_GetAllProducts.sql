CREATE PROCEDURE [dbo].[pr_GetAllProducts]
AS
	SELECT p.ProductId, p.ProductName, t.TeamId, t.TeamName
	FROM tb_Products p
	INNER JOIN tb_Teams t ON p.TeamId = t.TeamId
RETURN