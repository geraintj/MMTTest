USE [MMTShop]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Geraint Jones
-- Create date: 12/08/2020
-- Description:	returns products filtered by category
-- =============================================
CREATE PROCEDURE GetProductsByCategory
	@Category nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;

    SELECT p.* FROM [dbo].[Products] p 
	INNER JOIN 
		(SELECT  [Filter] +'%' as [FilterString]
		  FROM [dbo].[Categories] c INNER JOIN [dbo].[CategoryFilters] cf ON c.Id = cf.CategoryId
		  WHERE [Name] = @Category) q 
	ON p.Sku LIKE q.FilterString

END
GO
