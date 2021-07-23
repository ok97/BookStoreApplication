create procedure sp_AdminRegisterProcedure
	@FirstName varchar(20),
	@LastName varchar(20),
	@Email varchar(30),
	@Password varchar(30),
	@Role varchar (30)
	
	as begin
	Insert into Admin values ( @FirstName ,@LastName,@Email,@Password,@Role)
	End



