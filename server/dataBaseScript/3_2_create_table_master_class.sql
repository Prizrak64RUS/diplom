USE [SOPG]
GO

/****** Object:  Table [dbo].[masterclass]    Script Date: 02.06.2015 15:06:18 ******/
DROP TABLE [dbo].[masterclass]
GO

/****** Object:  Table [dbo].[masterclass]    Script Date: 02.06.2015 15:06:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[masterclass](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_event] [int] NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[decription] [nvarchar](500) NOT NULL,
	[lecturer1] [nchar](50) NOT NULL,
	[lecturer2] [nchar](50) NULL,
	[lecturer3] [nchar](50) NULL,
 CONSTRAINT [PK_masterclass] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


