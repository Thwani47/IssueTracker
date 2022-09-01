CREATE PROCEDURE [dbo].[pr_LogUserIn]
	@Username VARCHAR(30),
	@Password VARCHAR(30),
	@ResponseMessage VARCHAR(100) OUTPUT,
	@UserId UNIQUEIDENTIFIER OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @Id UNIQUEIDENTIFIER;

	IF EXISTS (SELECT TOP 1 UserId from tb_Users WHERE Username = @Username)
	BEGIN
		SET @Id = (SELECT UserId from tb_Users WHERE Username = @Username AND PasswordHash = HASHBYTES('SHA2_512', @Password + CAST(Salt AS NVARCHAR(36))))

		IF (@Id IS NULL)
			SET @ResponseMessage = 'Incorrect Password';
		ELSE
			BEGIN
				SET @ResponseMessage = 'Login Successful';
				SET @UserId = @Id;
			END
	END
	ELSE
		SET @ResponseMessage = 'Invalid Login';
END
