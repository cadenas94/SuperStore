USE [Superstore]
GO

/****** Object:  StoredProcedure [dbo].[GetStateSales]    Script Date: 10/20/2022 8:54:04 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_GetStateSales] AS


Select 
O.State,
YEAR(CONVERT(datetime,OrderDate))as SaleYear,
SUM(Sales)as Sales
from
Products P
INNER JOIN Orders O
ON O.OrderId = P.OrderId
LEFT OUTER JOIN OrdersReturns ORE
ON P.OrderId = ORE.OrderId
WHERE ORE.OrderId IS NULL
group by State, YEAR(CONVERT(datetime,OrderDate))
GO


