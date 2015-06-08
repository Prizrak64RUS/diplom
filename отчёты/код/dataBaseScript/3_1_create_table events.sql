USE [SOPG]
GO

EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'event'

GO

/****** Object:  Table [dbo].[event]    Script Date: 14.11.2014 18:55:51 ******/
DROP TABLE [dbo].[event]
GO

/****** Object:  Table [dbo].[event]    Script Date: 14.11.2014 18:55:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[event](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[description] [nvarchar](500) NOT NULL,
	[date] [date] NOT NULL,
	[isActiv] [int] NOT NULL,
	[isDelete] [int],
 CONSTRAINT [PK_event] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[event] SET (LOCK_ESCALATION = AUTO)
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Мероприятие' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'event'
GO


