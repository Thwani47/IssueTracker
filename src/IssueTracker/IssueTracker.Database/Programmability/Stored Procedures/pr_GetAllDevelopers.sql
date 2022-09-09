CREATE PROCEDURE [dbo].[pr_GetAllDevelopers]
AS
	SELECT UserId,FirstName, LastName, Email,UserType, TeamLead
	FROM tb_Users
	WHERE UserType = 0
RETURN