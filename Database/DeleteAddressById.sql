

create procedure sp_DeleteAddressById
@UserId int,
@AddressId int
as begin
	DELETE FROM   [dbo].[Address] WHERE UserId=@UserId AND AddressId= @AddressId
	End