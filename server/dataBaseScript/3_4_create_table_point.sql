USE [SOPG]
GO

ALTER TABLE [dbo].[point] DROP CONSTRAINT [FK_point_users]
GO

ALTER TABLE [dbo].[point] DROP CONSTRAINT [FK_point_maps]
GO

/****** Object:  Table [dbo].[point]    Script Date: 18.11.2014 17:02:34 ******/
DROP TABLE [dbo].[point]
GO

/****** Object:  Table [dbo].[point]    Script Date: 18.11.2014 17:02:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[point](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[type] [nvarchar](30) NOT NULL,
	[x] [int] NOT NULL,
	[y] [int] NOT NULL,
	[size_w] [int] NOT NULL,
	[size_h] [int] NOT NULL,
	[description] [nvarchar](500) NOT NULL,
	[id_map] [int] NOT NULL,
	[isBusy] [int] NOT NULL,
	[id_user_Busy] [int] NULL,
 CONSTRAINT [PK_point] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[point]  WITH CHECK ADD  CONSTRAINT [FK_point_maps] FOREIGN KEY([id_map])
REFERENCES [dbo].[maps] ([id])
GO

ALTER TABLE [dbo].[point] CHECK CONSTRAINT [FK_point_maps]
GO

ALTER TABLE [dbo].[point]  WITH CHECK ADD  CONSTRAINT [FK_point_users] FOREIGN KEY([id_user_Busy])
REFERENCES [dbo].[users] ([id])
GO

ALTER TABLE [dbo].[point] CHECK CONSTRAINT [FK_point_users]
GO


