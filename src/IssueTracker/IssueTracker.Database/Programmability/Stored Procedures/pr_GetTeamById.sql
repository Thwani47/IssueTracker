CREATE PROCEDURE [dbo].[pr_GetTeamById]
	@TeamId UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;
	SELECT TOP(1) t.TeamId, t.TeamName, t.TeamLead, u.UserId, u.FirstName, u.LastName 
	FROM tb_Teams t
	INNER JOIN tb_Users u ON t.TeamLead = u.UserId
	WHERE TeamId = @TeamId;
END