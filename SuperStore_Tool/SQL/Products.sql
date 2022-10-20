USE [Superstore]
GO

/****** Object:  Table [dbo].[Products]    Script Date: 10/20/2022 8:56:25 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Products](
	[OrderId] [nvarchar](255) NULL,
	[ProductId] [nvarchar](255) NULL,
	[Category] [nvarchar](255) NULL,
	[SubCategory] [nvarchar](255) NULL,
	[ProductName] [nvarchar](255) NULL,
	[Sales] [float] NULL,
	[Quantity] [float] NULL,
	[Discount] [float] NULL,
	[Profit] [float] NULL
) ON [PRIMARY]
GO


