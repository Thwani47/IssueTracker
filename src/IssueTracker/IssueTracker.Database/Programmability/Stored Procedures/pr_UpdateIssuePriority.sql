CREATE PROCEDURE [dbo].[pr_UpdateIssuePriority]
	@IssueId UNIQUEIDENTIFIER,
	@Priority INT,
	@ResponseMessage VARCHAR(200) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		UPDATE tb_Issues SET IssuePriority = @Priority
		WHERE IssueId = @IssueId
		SET @ResponseMessage = 'Issue Updated Successfully';
	END TRY
	BEGIN CATCH
		SET @ResponseMessage = ERROR_MESSAGE();
	END CATCH
END