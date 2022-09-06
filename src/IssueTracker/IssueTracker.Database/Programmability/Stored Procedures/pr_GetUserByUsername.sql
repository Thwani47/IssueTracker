CREATE PROCEDURE [dbo].[pr_GetUserByUsername]
	@Username VARCHAR(30)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT TOP(1) UserId,FirstName, LastName, Email, Username, UserType,TeamId FROM tb_Users WHERE Username = @Username;
END
