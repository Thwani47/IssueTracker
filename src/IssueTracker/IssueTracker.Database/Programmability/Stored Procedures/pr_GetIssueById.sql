CREATE PROCEDURE [dbo].[pr_GetIssueById]
	@IssueId UNIQUEIDENTIFIER
AS
	SELECT i.IssueId, i.IssueTitle, i.IssueDescription, i.IssuePriority, i.IssueStatus, p.ProductId, u.UserId
	FROM tb_Issues i
	INNER JOIN tb_Products p ON i.ProductId= p.ProductId
	INNER JOIN tb_Users u on i.AssignedTo = u.UserId
	WHERE IssueId = @IssueId
RETURN