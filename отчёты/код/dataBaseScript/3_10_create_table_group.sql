USE [SOPG]
GO

/****** Object:  Table [dbo].[group]    Script Date: 29.05.2015 22:33:22 ******/
DROP TABLE [dbo].[group]
GO

/****** Object:  Table [dbo].[group]    Script Date: 29.05.2015 22:33:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[group](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idEvent] [int] NOT NULL,
	[number_child] [int] NOT NULL,
	[numberResponsible] [int] NOT NULL,
	[numberOverall] [int] NOT NULL,
	[responsible] [nchar](150) NOT NULL,
	[school] [nchar](50) NOT NULL,
	[location] [nchar](50) NOT NULL,
	[date_start] [datetime] NOT NULL,
	[date_end] [datetime] NULL,
	[groupExist] [int] NOT NULL,
 CONSTRAINT [PK_group] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


