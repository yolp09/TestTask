--Переход на системную базу данных master
use master
--Проверка на существование и удаление БД с именем TestTask
if DB_ID('TestTask') is not null
drop database TestTask
GO
--Создание БД
create database TestTask
go
--Переход в БД TestTask
use TestTask
--Создание  таблицы с валютами
create table Currencies(
Id varchar(7) not null constraint PK_Currencies_Id primary key,
Name nvarchar(200) not null,
EngName varchar(200) not null,
Nominal int not null,
ParentCode varchar(7),
NumCode varchar(5),
CharCode char(3),
constraint UQ_Currencies_Id Unique(Id)
)
go
--Создание таблицы с курсами валют по дате
create table ExchangeRate(
Id int identity(1,1) not null constraint PK_ExchangeRate_Id primary key,
CurrenciesId varchar(7) not null,
Value money,
Date date,
constraint FK_ExchangeRate_CurrenciesId foreign key(CurrenciesId) references Currencies(Id)
)