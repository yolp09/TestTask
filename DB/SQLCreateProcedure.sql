--������� � �� TestTask
use TestTask
go
--�������� ��������� ���������� �����
create procedure sp_InsertCurrencies
@id varchar(7),
@name nvarchar(200),
@engName varchar(200),
@nominal int,
@parentCode varchar(7),
@numCode varchar(5),
@charCode char(3)
As
Insert into Currencies (Id, Name, EngName, Nominal, ParentCode, NumCode, CharCode)
values (@id, @name, @engName, @nominal, @parentCode, @numCode, @charCode)
go
--�������� ��������� ���������� ����� �����
create procedure sp_InsertExchangeRate
@currenciesId varchar(7),
@value money,
@date date
AS
insert into ExchangeRate (CurrenciesId, Value, Date)
values (@currenciesId, @value, @date)
go
--�������� ��������� ��������� ���� �����
create procedure sp_GetCurrencies
as
select * from Currencies
go
--�������� ��������� �������� ������� � ������� �����
create procedure sp_CheckingAvailabilityCurrencies
as
declare @result bit
set @result = IIF((select COUNT(*) from Currencies) > 0, 1, 0)
return @result
go
--�������� ��������� �������� ������� � ������� ����� ����� �� ��������� ����
create procedure sp_CheckingAvailabilityExchangeRate
@date date
as
declare @result bit
set @result = IIF((select COUNT(*) from ExchangeRate as er where er.Date = @date) > 0, 1, 0)
return @result
go
--�������� ��������� ������ ����� ������ �� ���� � id
create procedure sp_CurrencySearch
@id varchar(7),
@date date,
@result decimal(38,4) output
as
set @result = (select top 1 er.Value from ExchangeRate as er
where er.Date = @date and er.CurrenciesId = @id)
go