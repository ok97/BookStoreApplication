


create procedure sp_GetListOfAddress
	@UserId int
	as begin
	select * from  [dbo].[Address] where UserId=@UserId
	End