Set ANSI_NULLS OFF
go
Set ANSI_PADDING ON
go
Set ANSI_WARNINGS ON
go
Set ARITHABORT ON
go
Set CONCAT_NULL_YIELDS_NULL ON
go
set NUMERIC_ROUNDABORT OFF
go
Set QUOTED_IDENTIFIER ON
go
set DATEFORMAT dmy
go

declare @timestamp varchar(100),
		@filename varchar(100);

set @timestamp = (select convert(varchar(30), getdate(),112) + 
       replace(convert(varchar(30), getdate(),108),':',''));
Select @timestamp

set @filename =  N'C:\Users\joel.marty\Documents\GitHub\Help\Dump' + @timestamp + '.bak';

select @filename

Print 'DB: Help wird gesichert!'
BACKUP DATABASE [Help] TO DISK = @filename
WITH  INIT , NOSKIP ,  STATS = 50,  NOFORMAT, COMPRESSION
Print 'Sicherung beendet!'