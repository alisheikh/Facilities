﻿CREATE TABLE [dbo].[Jobs]
(
	[MbcJobNo] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ClientJobNo] INT NULL, 
    [Priority] INT NULL, 
    [ClientName] VARCHAR(50) NULL, 
    [CurrentStatus] VARCHAR(50) NULL, 
    [OrderType] VARCHAR(50) NULL, 
    [SitePhoneNo] VARCHAR(50) NULL, 
    [Problem] VARCHAR(MAX) NULL, 
    [SubContractor] INT NULL, 
    [Notes] VARCHAR(MAX) NULL, 
	[ArrivalTime] DATETIME NULL, 
    [DepartureTime] DATETIME NULL, 
    [MaterialsUsed] VARCHAR(MAX) NULL, 
    [CostsOfMaterials] VARCHAR(MAX) NULL, 
    [MetrialsRequired] VARCHAR(MAX) NULL, 
    [DurationToComplete] VARCHAR(50) NULL, 
    CONSTRAINT [FK_Jobs_ToUsers] FOREIGN KEY (SubContractor) REFERENCES Users(UserId)
)
