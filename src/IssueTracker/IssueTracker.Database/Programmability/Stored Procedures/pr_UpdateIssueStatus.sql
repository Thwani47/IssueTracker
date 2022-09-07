CREATE PROCEDURE [dbo].[pr_UpdateIssueStatus]
	@IssueId UNIQUEIDENTIFIER,
	@Status INT,
	@ResponseMessage VARCHAR(200) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		UPDATE tb_Issues SET IssueStatus =  @Status
		WHERE IssueId = @IssueId
		SET @ResponseMessage = 'Issue Updated Successfully';
	END TRY
	BEGIN CATCH
		SET @ResponseMessage = ERROR_MESSAGE();
	END CATCH
END

