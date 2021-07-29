alter Proc sp_GetListOrder
@UserId int
AS
BEGIN
	select Orders.UserId,Orders.CartId,Orders.AddressId,Orders.OrderId,Carts.BookId,Books.Name,Books.Author,Books.Language,Books.Category,Books.Pages,Books.Price,Books.Quantity,
Address.AddressId,Address.CustomerName,Address.City,Address.State,Address.Country,Address.Pincode,Address.MobileNumber,Carts.OrderQuantity,Carts.TotalPrice
from Orders INNER JOIN Carts on  Orders.CartId=Carts.CartId INNER JOIN  Books on Carts.BookId=Books.BookId INNER JOIN Address on Orders.AddressId=Address.AddressId where Carts.UserId=@UserId
END
GO
