CREATE PROCEDURE [dbo].[pr_UpdateIssueAssignee]
	@IssueId UNIQUEIDENTIFIER,
	@Assignee UNIQUEIDENTIFIER,
	@ResponseMessage VARCHAR(200) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		UPDATE tb_Issues SET AssignedTo =  @Assignee
		WHERE IssueId = @IssueId
		SET @ResponseMessage = 'Status Updated Successfully';
	END TRY
	BEGIN CATCH
		SET @ResponseMessage = ERROR_MESSAGE();
	END CATCH
END
