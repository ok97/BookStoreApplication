create procedure UserLogin 
(@Email varchar(30),
	@Password varchar(30),
	@UserId int out )
	as 
	begin
	Select @UserId=UserId from Users
	where Email= @Email AND Password=@Password 
	End


	declare @UserId int
	exec UserLogin 'string','Xoh55Xv3+n3sBRxoeIDv+Q==',@UserId out
	print @UserId

	delete from Users

	select * from Users

	select * from Users WHERE Email='omkhawshi0@gmail.com';