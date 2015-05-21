USE [SOPG]
GO

/****** Object:  Table [dbo].[busy]    Script Date: 19.05.2015 16:37:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[busy](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idUser] [int] NOT NULL,
	[idPoint] [int] NOT NULL,
	[idEvent] [int] NOT NULL,
 CONSTRAINT [PK_busy] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

