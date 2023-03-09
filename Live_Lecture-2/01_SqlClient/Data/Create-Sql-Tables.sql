DROP TABLE Customers
DROP TABLE Addresses
DROP TABLE Products

CREATE TABLE [Products] (
	[Id] INT NOT NULL IDENTITY PRIMARY KEY,
	[Name] NVARCHAR(200) NOT NULL,
	[Description] NVARCHAR(max) NULL,
	[StockPrice] MONEY NOT NULL
)

CREATE TABLE Addresses (
	Id int not null identity primary key,
	SteetName nvarchar(50) not null,
	PostalCode char(6) not null,
	City nvarchar(50) not null
)


CREATE TABLE Customers (
	Id int not null identity primary key,
	FirstName nvarchar(20) not null,
	LastName nvarchar(20) not null,
	Email varchar(100) not null unique,
	AddressId int not null references Addresses(Id)
)

