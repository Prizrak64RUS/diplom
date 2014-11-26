USE [SOPG]
GO

ALTER TABLE [dbo].[log] DROP CONSTRAINT [FK_log_users]
GO

ALTER TABLE [dbo].[log] DROP CONSTRAINT [FK_log_point]
GO

ALTER TABLE [dbo].[log] DROP CONSTRAINT [FK_log_log_type]
GO

ALTER TABLE [dbo].[log] DROP CONSTRAINT [FK_log_event]
GO

/****** Object:  Table [dbo].[log]    Script Date: 18.11.2014 17:06:20 ******/
DROP TABLE [dbo].[log]
GO

/****** Object:  Table [dbo].[log]    Script Date: 18.11.2014 17:06:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[log](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_user] [int] NOT NULL,
	[id_log_type] [int] NOT NULL,
	[id_events] [int] NOT NULL,
	[description] [nvarchar](500) NOT NULL,
	[id_point] [int] NOT NULL,
	[date] [datetime] NOT NULL,
 CONSTRAINT [PK_log] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[log]  WITH CHECK ADD  CONSTRAINT [FK_log_event] FOREIGN KEY([id_events])
REFERENCES [dbo].[event] ([id])
GO

ALTER TABLE [dbo].[log] CHECK CONSTRAINT [FK_log_event]
GO

ALTER TABLE [dbo].[log]  WITH CHECK ADD  CONSTRAINT [FK_log_log_type] FOREIGN KEY([id_log_type])
REFERENCES [dbo].[log_type] ([id])
GO

ALTER TABLE [dbo].[log] CHECK CONSTRAINT [FK_log_log_type]
GO

ALTER TABLE [dbo].[log]  WITH CHECK ADD  CONSTRAINT [FK_log_point] FOREIGN KEY([id_point])
REFERENCES [dbo].[point] ([id])
GO

ALTER TABLE [dbo].[log] CHECK CONSTRAINT [FK_log_point]
GO

ALTER TABLE [dbo].[log]  WITH CHECK ADD  CONSTRAINT [FK_log_users] FOREIGN KEY([id_user])
REFERENCES [dbo].[users] ([id])
GO

ALTER TABLE [dbo].[log] CHECK CONSTRAINT [FK_log_users]
GO


