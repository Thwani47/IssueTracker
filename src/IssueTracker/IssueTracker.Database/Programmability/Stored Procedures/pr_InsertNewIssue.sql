CREATE PROCEDURE [dbo].[pr_InsertNewIssue]
	@IssueTitle VARCHAR(100),
	@IssueDescription VARCHAR(MAX),
	@ProductId UNIQUEIDENTIFIER,
	@IssuePriority INT,
	@AssignedTo UNIQUEIDENTIFIER,
	@ResponseMessage VARCHAR(200) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		INSERT INTO tb_Issues (IssueId, IssueTitle, IssueDescription, IssuePriority,IssueStatus, ProductId, AssignedTo) 
		VALUES (NEWID(), @IssueTitle, @IssueDescription, @IssuePriority, 0, @ProductId, @AssignedTo);
		SET @ResponseMessage = 'Issue Added Successfully';
	END TRY
	BEGIN CATCH
		SET @ResponseMessage = ERROR_MESSAGE();
	END CATCH
END
