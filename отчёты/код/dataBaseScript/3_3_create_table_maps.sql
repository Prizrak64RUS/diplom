USE [SOPG]
GO

ALTER TABLE [dbo].[maps] DROP CONSTRAINT [FK_maps_event]
GO

/****** Object:  Table [dbo].[maps]    Script Date: 14.11.2014 19:13:14 ******/
DROP TABLE [dbo].[maps]
GO

/****** Object:  Table [dbo].[maps]    Script Date: 14.11.2014 19:13:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[maps](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[id_event] [int] NOT NULL,
	[description] [nvarchar](500) NOT NULL,
	[image] [image] NULL,
 CONSTRAINT [PK_maps] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[maps]  WITH CHECK ADD  CONSTRAINT [FK_maps_event] FOREIGN KEY([id_event])
REFERENCES [dbo].[event] ([id])
GO

ALTER TABLE [dbo].[maps] CHECK CONSTRAINT [FK_maps_event]
GO


