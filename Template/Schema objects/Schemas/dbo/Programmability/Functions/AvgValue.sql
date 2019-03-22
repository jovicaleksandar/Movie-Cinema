CREATE FUNCTION [dbo].[AvgValue]
(
	@param1 BIGINT
)
RETURNS DECIMAL
AS
BEGIN
	
	DECLARE @prosek AS DECIMAL
	SELECT @prosek = AVG(billamount) FROM bill INNER JOIN "Table" ON bill.table_tableid = "Table".tableid
	WHERE "Table".tableid = @param1

	RETURN @prosek 

END
