
create Proc sp_DeletewishlistidById
@UserId int,
@WishListId int

AS
BEGIN
	DELETE FROM WishList WHERE WishlistId=@WishListId AND UserId=@UserId;
END
GO

select * from WishList
