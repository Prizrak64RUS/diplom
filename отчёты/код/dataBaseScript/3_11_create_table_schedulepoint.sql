USE [SOPG]
GO

/****** Object:  Table [dbo].[schedulepoint]    Script Date: 02.06.2015 15:14:57 ******/
DROP TABLE [dbo].[schedulepoint]
GO

/****** Object:  Table [dbo].[schedulepoint]    Script Date: 02.06.2015 15:14:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[schedulepoint](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_masterclass] [int] NOT NULL,
	[id_point] [int] NOT NULL,
	[date_start] [date] NOT NULL,
	[time_start] [time] NOT NULL,
	[time_end] [time] NOT NULL,
 CONSTRAINT [PK_schedulepoint] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


