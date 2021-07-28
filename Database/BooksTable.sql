USE [BookStoreDB]
GO

	CREATE TABLE [dbo].[Books](
	[BookId] int IDENTITY(1,1) NOT NULL,
	[AdminId] int,
	[Name] varchar(20) ,
	[Author] varchar(20) ,
	[Language] varchar(30),
	[Category] varchar(30) ,
	[Pages] varchar(30) ,
	[Price] varchar (30),
	[Quantity] int 
	PRIMARY KEY(BookId));


	select * from Admin
	select * from Books
	select * from Users

delete from Books





	drop table Books