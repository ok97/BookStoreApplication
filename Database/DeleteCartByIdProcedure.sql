create procedure sp_DeleteCartByIdProcedure
@CartId int

as 
begin
	DELETE FROM   [dbo].[Carts] WHERE CartId=@CartId 
	End

	

	select * from Carts


	