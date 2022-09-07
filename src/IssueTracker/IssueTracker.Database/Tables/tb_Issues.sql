CREATE TABLE [dbo].[tb_Issues]
(
	[IssueId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [IssueTitle] VARCHAR(100) NOT NULL, 
    [IssueDescription] VARCHAR(MAX) NOT NULL, 
    [IssuePriority] INT NULL DEFAULT 0, 
    [IssueStatus] INT NULL DEFAULT 0, 
    [ProductId] UNIQUEIDENTIFIER NOT NULL CONSTRAINT [FK_tb_Issues_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [tb_Products]([ProductId]), 
    [AssignedTo] UNIQUEIDENTIFIER NULL CONSTRAINT [FK_tb_Issues_AssignedTo] FOREIGN KEY ([AssignedTo]) REFERENCES [tb_Users]([UserId])
)
