CREATE PROCEDURE [dbo].[pr_GetAllUsers]
AS
	SELECT UserId,FirstName, LastName, Email,UserType, TeamLead
	FROM tb_Users
	WHERE NOT UserType = 1
RETURN
