create procedure sp_AddOrder
	@UserId int,
	@CartId int,
	@AddressId int
	
	as 
	begin
	Insert into [dbo].[Order] (UserId ,CartId,AddressId) values (@UserId,@CartId,@AddressId)
	End