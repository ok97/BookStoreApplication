alter procedure UserLogin 
(@Email  varchar(30),
	@Password varchar(30),
	@UserId int out ,
	@EmailOut varchar(30) out)
	as 
	begin
	Select @UserId=UserId , @EmailOut=Email from Users
	where Email= @Email AND Password=@Password 
	End

		declare @EmailOut varchar(30)
	declare @UserId int
	exec UserLogin 'omkhawshi0@gmail.com','7i8AukX1uBbn8WYRjM80fht9wutjlc',@UserId out ,@EmailOut out
	print @UserId
	print @EmailOut

	delete from Users

	select * from Carts

	select * from Users WHERE Email='omkhawshi0@gmail.com';