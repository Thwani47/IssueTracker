CREATE PROCEDURE [dbo].[pr_GetUserById]
	@UserId UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;
	SELECT TOP(1) UserId, FirstName, LastName, Username, Email, TeamId FROM tb_Users WHERE UserId = @UserId;
END