create procedure sp_AddBooksProcedure
	@AdminId int,
	@Name varchar(20) ,
	@Author varchar(20) ,
	@Language varchar(30),
	@Category varchar(30) ,
	@Pages varchar(30) ,
	@Price varchar(30),
	@Quantity int
	
	as begin
	Insert into [dbo].[Books] values ( @AdminId ,@Name,@Author,@Language,@Category,@Pages,@Price,@Quantity)
	End

	drop proc sp_AddBooksProcedure