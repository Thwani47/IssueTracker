﻿CREATE TABLE [dbo].[tb_Products]
(
	[ProductId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [ProductName] VARCHAR(100) NOT NULL, 
    [TeamId] UNIQUEIDENTIFIER NOT NULL CONSTRAINT [FK_tb_Products_TeamId] FOREIGN KEY ([TeamId]) REFERENCES [tb_Teams]([TeamId])
)
