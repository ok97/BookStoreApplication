create procedure AdminLogin 
(@Email varchar(30),
	@Password varchar(30),
	@AdminId int out )
	as 
	begin
	Select @AdminId=AdminId from Admin
	where Email= @Email AND Password=@Password 
	End



	declare @AdminId int
	exec AdminLogin 'string','Xoh55Xv3+n3sBRxoeIDv+Q==',@AdminId out
	print @AdminId



	
	select * from Admin

	select * from Users WHERE Email='omkhawshi0@gmail.com';
