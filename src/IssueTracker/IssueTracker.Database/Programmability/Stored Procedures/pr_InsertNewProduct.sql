CREATE PROCEDURE [dbo].[pr_InsertNewProduct]
	@ProductName VARCHAR(30),
	@TeamId UNIQUEIDENTIFIER,
	@ResponseMessage VARCHAR(200) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		INSERT INTO tb_Products (ProductId, ProductName, TeamId) VALUES (NEWID(), @ProductName, @TeamId);
		SET @ResponseMessage = 'Product Added Successfully';
	END TRY
	BEGIN CATCH
		SET @ResponseMessage = ERROR_MESSAGE();
	END CATCH
END
