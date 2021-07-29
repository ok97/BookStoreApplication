


create procedure sp_DeleteOrderById
@OrderId int,
@UserId int

as 
begin
	DELETE FROM [dbo].[Orders] WHERE OrderId=@OrderId AND UserId=@UserId
	End