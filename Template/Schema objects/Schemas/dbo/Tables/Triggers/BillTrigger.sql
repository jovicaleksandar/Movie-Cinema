CREATE TRIGGER [BillTrigger]
ON [dbo].bill

AFTER INSERT
AS

BEGIN
	
	DECLARE @tableID INT;
	DECLARE @billID BIGINT;
	DECLARE @billAmount INT;
	DECLARE @billDateTime datetime;

	SELECT @tableID = i.table_tableid from inserted i;
	SELECT @billID = i.billid1 from inserted i;
	SELECT @billAmount = i.billamount FROM inserted i;
	SELECT @billDateTime = i.billdatetime FROM inserted i;

		if (@tableID < 4)
			BEGIN
				SELECT @billAmount = @billAmount * 2;
				UPDATE bill SET billamount = @billAmount WHERE billid = @billID
			END
END