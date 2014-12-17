USE [FMHelpdeskSQLV4]
GO

CREATE TABLE [dbo].[WebExtraJobData](
	[MBCJobNo] [int] NOT NULL,
	[HelpDeskNotified] [bit] NULL,
	[MaterialsUsed] [varchar](max) NULL,
	[MaterialsRequired] [varchar](max) NULL,
 CONSTRAINT [PK_WebExtraJobData] PRIMARY KEY CLUSTERED 
(
	[MBCJobNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO




CREATE TABLE [dbo].[WebUsers](
	[UserName] [varchar](50) NOT NULL,
	[Password] [varbinary](max) NOT NULL,
	[FullName] [varchar](150) NOT NULL,
	[Salt] [varbinary](max) NOT NULL,
	[UserType] [varchar](50) NULL,
 CONSTRAINT [PK_WebUsers] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE VIEW [dbo].[WebJobs]
AS
SELECT     [MBC Job No], [Client Job No], Priority, SiteNo AS ClientName, currentStatus, OrderType, SiteTelNo AS SitePhoneNo, Problem, SubContractor AS UserName, 
                      Note AS Notes, timeOnSite AS ArrivalTime, timeOffSite AS DepartureTime, materials AS CostsOfMaterials, EnteredBy, 
                      estimatedTimeOfCompletion AS DurationToCompletion, siteNotes, siteName, siteAddress, siteTown, siteCounty
FROM         dbo.FMIncidentsFM261 AS J

GO

-- Add siteNotes to Reactive Table
BEGIN TRANSACTION
GO
ALTER TABLE dbo.reactiveCallOut ADD
	siteNotes ntext NULL
GO
ALTER TABLE dbo.reactiveCallOut SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


-- create WebJobsJoined

USE [FMHelpdeskSQLV4]
GO

/****** Object:  View [dbo].[WebJobsJoined]    Script Date: 17/12/2014 10:40:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[WebJobsJoined]
AS
SELECT        
J.[MBC Job No], 
j.[Client Job No], 
j.priority, 
j.siteNo as ClientName, 
j.currentStatus, 
j.ordertype, 
j.SiteTelNo as SitePhoneNo,
j.problem, 
j.subContractor as UserName, 
j.note as Notes, 
cast(j.timeOnSite as nvarchar(50)) as ArrivalTime, 
cast(j.timeOffSite as nvarchar(50)) as DepartureTime, 
j.materials as CostOfMaterials,
j.Enteredby,
j.siteName,
j.siteAddress,
j.siteTown,
j.siteCounty,
j.siteNotes
FROM            dbo.FMIncidentsFM261 as j

union all

SELECT
J.[MBC Job No], 
j.[Client Job No], 
j.priority, 
j.sitename as ClientName,
j.currentStatus, 
j.ordertype, 
j.Sitephone as SitePhoneNo,
j.problem, 
j.subContractor as UserName, 
j.note as Notes, 
j.timeOnSite as ArrivalTime, 
j.timeOffSite as DepartureTime, 
j.materials as CostOfMaterials,
j.Enteredby,
j.siteName,
j.siteAddress,
j.siteTown,
j.siteCounty,
j.siteNotes

FROM             dbo.reactiveCallOut as j
                        

GO

