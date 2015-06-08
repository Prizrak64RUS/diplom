USE [SOPG]
GO
DROP TABLE [dbo].[news]
GO


/****** Object:  Table [dbo].[news]    Script Date: 21.03.2015 8:52:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[news](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_event] [int] NOT NULL,
	[description] [nchar](300) NOT NULL,
	[date_write] [datetime] NOT NULL,
	[date_news] [datetime] NULL,
	[id_map] [int] NULL,
 CONSTRAINT [PK_news] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


