CREATE PROCEDURE [dbo].[pr_InsertNewTeam]
	@TeamName VARCHAR(30),
	@TeamLead UNIQUEIDENTIFIER,
	@ResponseMessage VARCHAR(200) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		INSERT INTO tb_Teams (TeamId, TeamName, TeamLead) VALUES (NEWID(), @TeamName, @TeamLead);
		SET @ResponseMessage = 'Team Added Successfully';
	END TRY
	BEGIN CATCH
		SET @ResponseMessage = ERROR_MESSAGE();
	END CATCH
END
