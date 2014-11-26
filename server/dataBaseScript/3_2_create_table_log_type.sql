USE [SOPG]
GO

/****** Object:  Table [dbo].[log_type]    Script Date: 14.11.2014 18:58:20 ******/
DROP TABLE [dbo].[log_type]
GO

/****** Object:  Table [dbo].[log_type]    Script Date: 14.11.2014 18:58:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[log_type](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_log_type] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


