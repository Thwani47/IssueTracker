CREATE PROCEDURE [dbo].[pr_GetAllUsers]
AS
	SELECT UserId,FirstName, LastName, Email,UserType 
	FROM tb_Users
	WHERE NOT UserType = 1
RETURN
