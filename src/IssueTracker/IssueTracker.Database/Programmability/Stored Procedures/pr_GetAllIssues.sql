CREATE PROCEDURE [dbo].[pr_GetAllIssues]
AS
	SELECT i.IssueId, i.IssueTitle, i.IssueDescription, i.IssuePriority, i.IssueStatus, p.ProductId, u.UserId
	FROM tb_Issues i
	INNER JOIN tb_Products p ON i.ProductId= p.ProductId
	LEFT JOIN tb_Users u on i.AssignedTo = u.UserId
RETURN