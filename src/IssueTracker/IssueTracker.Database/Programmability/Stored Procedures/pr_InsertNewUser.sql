CREATE PROCEDURE [dbo].[pr_InsertNewUser]
	@FirstName VARCHAR(30),
	@LastName VARCHAR(30),
	@Username VARCHAR(30),
	@Email VARCHAR(30),
	@Password VARCHAR(30),
	@ResponseMessage VARCHAR(200) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	BEGIN TRY
		DECLARE @UserId UNIQUEIDENTIFIER = NEWID();
		DECLARE @Salt UNIQUEIDENTIFIER = NEWID();

		INSERT INTO tb_Users (UserId, FirstName, LastName, Username, Email, Salt, PasswordHash )
		VALUES (@UserId, @FirstName, @LastName, @Username, @Email, @Salt, HASHBYTES('SHA2_512', @Password + CAST(@Salt AS NVARCHAR(36))));

		SET @ResponseMessage = 'User Added Successfully';
	END TRY
	BEGIN CATCH
		SET @ResponseMessage = ERROR_MESSAGE();
	END CATCH
END
