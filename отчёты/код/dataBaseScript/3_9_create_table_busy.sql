USE [SOPG]
GO

/****** Object:  Table [dbo].[busy]    Script Date: 02.06.2015 15:37:16 ******/
DROP TABLE [dbo].[busy]
GO

/****** Object:  Table [dbo].[busy]    Script Date: 02.06.2015 15:37:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [SOPG].[dbo].[busy](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idGroup] [int] NULL,
	[idUser] [int] NULL,
	[idPoint] [int] NOT NULL,
 CONSTRAINT [PK_busy] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [SOPG].[dbo].[busy] ADD  CONSTRAINT [DF_busy_idGroup]  DEFAULT ((0)) FOR [idGroup]
ALTER TABLE [SOPG].[dbo].[busy] ADD  CONSTRAINT [DF_busy_idUser]  DEFAULT ((0)) FOR [idUser]
ALTER TABLE [SOPG].[dbo].[busy] ADD  CONSTRAINT [DF_busy_idPoint]  DEFAULT ((0)) FOR [idPoint]
GO

GO


