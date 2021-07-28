

create procedure sp_GetListOfAddressid
	@UserId int,
	@AddressId int
	as begin
	select * from  [dbo].[Address] where UserId=@UserId AND AddressId=@AddressId
	End


	select * from Address