﻿CREATE TABLE [dbo].[tb_Teams]
(
	[TeamId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [TeamName] VARCHAR(100) NOT NULL, 
    [TeamLead] UNIQUEIDENTIFIER NOT NULL CONSTRAINT [FK_tb_Teams_TeamLead] FOREIGN KEY ([TeamLead]) REFERENCES [tb_Users]([UserId])
)
