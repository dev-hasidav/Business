USE [StwPh_28890060_2019]
GO
/****** Object:  Trigger [dbo].[test]    Script Date: 21.10.2019 14:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER TRIGGER [dbo].[test]
   ON  [dbo].[FA]
   AFTER INSERT, UPDATE    
AS
BEGIN
	SET NOCOUNT ON;

	declare @IdRecord as integer = (SELECT ID FROM inserted);
	declare @GuidTask as varchar(max) = 'Guid-1';
	declare @AddressMain as varchar(max) = '192.168.88.6';
	declare @NameServer as varchar(max) = @@SERVERNAME;
	declare @NameBase as varchar(max) = DB_NAME();
	declare @NameTable as varchar(max) = OBJECT_NAME((select parent_object_id from sys.objects where object_id = @@PROCID));
	declare @NameTrigger as varchar(max) = OBJECT_NAME(@@PROCID);

declare @Act as varchar(2) = ( select 
		case 
			when i.Id is null then 'D' -- Delete
			when d.Id is null then 'I' --Insert
			else 'U' -- Update
			end -- Операция
	from inserted i	full join deleted d on d.Id = i.Id )

	INSERT INTO ASynchro.dbo.sEventTriggers
                         (GuidTask, ActionTrigger, NameTrigger, NameTable, NameBase, NameServer, AddressMain, IdRecord)
						VALUES  ( @GuidTask,  @Act,  @NameTrigger,  @NameTable,  @NameBase,  @NameServer, @AddressMain, @IdRecord)
END
