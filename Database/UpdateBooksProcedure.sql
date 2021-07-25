create procedure sp_UpdateBooksProcedure
	@BookId int,
	@AdminId int,
	@Name varchar(20) ,
	@Author varchar(20) ,
	@Language varchar(30),
	@Category varchar(30) ,
	@Pages varchar(30) ,
	@Price varchar(30)
	
	AS
BEGIN
	UPDATE [dbo].[Books]SET Name=@Name, Author=@Author, Language=@Language, Category=@Category, Pages=@Pages, Price=@Price 
 WHERE BookId=@BookId AND AdminId=@AdminId
	End


	drop proc sp_UpdateBooksProcedure
	select * from Books

	UPDATE [dbo].[Books]SET Name= 'Omprakash',Author= 'data',Language = 'maza',Category = 'string',Pages = '5000',Price='20' 
 WHERE BookId=5 AND AdminId=7