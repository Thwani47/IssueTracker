CREATE PROCEDURE [dbo].[pr_InsertNewIssue]
	@IssueTitle VARCHAR(100),
	@IssueDescription VARCHAR(MAX),
	@ProductId UNIQUEIDENTIFIER,
	@IssuePriority INT,
	@ResponseMessage VARCHAR(200) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		INSERT INTO tb_Issues (IssueId, IssueTitle, IssueDescription, IssuePriority,IssueStatus, ProductId) 
		VALUES (NEWID(), @IssueTitle, @IssueDescription, @IssuePriority, 0, @ProductId);
		SET @ResponseMessage = 'Issue Added Successfully';
	END TRY
	BEGIN CATCH
		SET @ResponseMessage = ERROR_MESSAGE();
	END CATCH
END
