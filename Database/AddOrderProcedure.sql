alter procedure sp_AddOrder
	@UserId int,
	@CartId int,
	@AddressId int
	
	as 
	begin
	Insert into [dbo].[Orders] (UserId ,CartId,AddressId) values (@UserId,@CartId,@AddressId)
	End


	select * from [Orders]