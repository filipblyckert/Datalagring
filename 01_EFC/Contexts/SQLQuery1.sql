CREATE TABLE Addresses (
Id int not null identity primary key,
StreetName nvarchar(50) not null,
PostalCode char(6) not null,
City nvarchar(50) not null
)


CREATE TABLE Customers(
Id uniqueidentifier not null identity primary key,
FirstName nvarchar(50) not null,
LastName nvarchar(50) not null,
Email nvarchar(100) not null unique,
PhoneNumber char(13) null,
AddressId int not null references AddressId(Id)
)

CREATE TABLE Products(
ArticleNumber nvarchar(450) not null primary key,
Name nvarchar(max) not null,
description nvarchar(max) null,
Price money not null
)