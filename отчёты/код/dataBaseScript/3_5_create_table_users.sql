USE [SOPG]
GO

ALTER TABLE [dbo].[users] DROP CONSTRAINT [FK_users_event]
GO

/****** Object:  Table [dbo].[users]    Script Date: 14.11.2014 19:01:03 ******/
DROP TABLE [dbo].[users]
GO

/****** Object:  Table [dbo].[users]    Script Date: 14.11.2014 19:01:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Gradebook] [int] NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[role] [nvarchar](20) NOT NULL,
	[description] [nvarchar](500) NOT NULL,
	[login] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[id_event] [int],
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[users]  WITH CHECK ADD  CONSTRAINT [FK_users_event] FOREIGN KEY([id_event])
REFERENCES [dbo].[event] ([id])
GO

ALTER TABLE [dbo].[users] CHECK CONSTRAINT [FK_users_event]
GO


