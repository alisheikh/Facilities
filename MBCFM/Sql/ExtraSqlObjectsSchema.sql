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

