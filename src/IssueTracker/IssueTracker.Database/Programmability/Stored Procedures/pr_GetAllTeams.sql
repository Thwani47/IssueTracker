CREATE PROCEDURE [dbo].[pr_GetAllTeams]
AS
	SELECT t.TeamId, t.TeamName, u.UserId, u.FirstName, u.LastName
	FROM tb_Teams t
	INNER JOIN tb_Users u ON t.TeamLead = u.UserId
RETURN
