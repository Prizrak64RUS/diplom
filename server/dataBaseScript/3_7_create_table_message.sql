USE [SOPG]
GO

/****** Object:  Table [dbo].[message]    Script Date: 25.12.2014 16:10:38 ******/
DROP TABLE [dbo].[message]
GO

/****** Object:  Table [dbo].[message]    Script Date: 25.12.2014 16:10:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[message](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idUserTo] [int] NOT NULL,
	[message] [nchar](100) NOT NULL,
	[idUser] [int] NOT NULL,
	[Date] [datetime] NOT NULL
) ON [PRIMARY]

GO


