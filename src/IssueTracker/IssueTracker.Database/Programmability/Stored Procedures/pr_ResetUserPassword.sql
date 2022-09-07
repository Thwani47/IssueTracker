CREATE PROCEDURE [dbo].[pr_ResetUserPassword]
	@UserId UNIQUEIDENTIFIER,
	@Password VARCHAR(30),
	@ResponseMessage VARCHAR(100) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @Id UNIQUEIDENTIFIER;

	IF EXISTS (SELECT TOP 1 UserId from tb_Users WHERE UserId = @UserId)
	BEGIN
		DECLARE @Salt UNIQUEIDENTIFIER = NEWID();

		UPDATE tb_Users 
		SET Salt = @Salt, PasswordHash = HASHBYTES('SHA2_512', @Password + CAST(@Salt AS NVARCHAR(36)));

		SET @ResponseMessage = 'Password reset successfully';
	END
	ELSE
		SET @ResponseMessage = 'User not found';
END
