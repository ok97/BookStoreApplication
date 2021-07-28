
create procedure sp_AddAddressProcedure
	@UserId int,
	@CustomerName varchar(20) ,
	@City varchar(20) ,
	@State varchar(30),
	@Country varchar(30) ,
	@Pincode varchar(30) ,
	@MobileNumber varchar(30)
	
	as begin
	Insert into [dbo].[Address] values ( @UserId ,@CustomerName,@City,@State,@Country,@Pincode,@MobileNumber)
	End

select * from Address