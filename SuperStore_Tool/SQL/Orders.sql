USE [Superstore]
GO

/****** Object:  Table [dbo].[Orders]    Script Date: 10/20/2022 8:57:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Orders](
	[OrderId] [nvarchar](255) NULL,
	[OrderDate] [datetime] NULL,
	[ShipDate] [datetime] NULL,
	[ShipMode] [nvarchar](255) NULL,
	[CustomerId] [nvarchar](255) NULL,
	[CustomerName] [nvarchar](255) NULL,
	[Segment] [nvarchar](255) NULL,
	[Country] [nvarchar](255) NULL,
	[City] [nvarchar](255) NULL,
	[State] [nvarchar](255) NULL,
	[Postal Code] [float] NULL,
	[Region] [nvarchar](255) NULL
) ON [PRIMARY]
GO


