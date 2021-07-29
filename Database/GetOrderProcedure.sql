alter Proc sp_GetOrder
@UserId int,
@CartId int
AS
BEGIN
	select Orders.UserId,Orders.CartId,Orders.AddressId,Orders.OrderId,Carts.BookId,Books.Name,Books.Author,Books.Language,Address.CustomerName,Address.City,Address.State,Address.Country,Address.Pincode,Address.MobileNumber,Carts.OrderQuantity,Carts.TotalPrice
from Orders INNER JOIN Carts on  Orders.CartId=Carts.CartId INNER JOIN  Books on Carts.BookId=Books.BookId INNER JOIN Address on Orders.AddressId=Address.AddressId
where Carts.CartId=@CartId
END
GO



drop proc sp_GetOrder
select * from Carts

UPDATE Orders
SET AddressId=2
WHERE CartId=3;

select * from Orders
select * from Address
select * from Books

select Orders.UserId,Orders.CartId,Orders.AddressId,Orders.OrderId,Carts.BookId,Books.Name,Books.Author,Books.Language,Books.Category,Books.Pages,Books.Price,Books.Quantity,
Address.AddressId,Address.CustomerName,Address.City,Address.State,Address.Country,Address.Pincode,Address.MobileNumber,Carts.OrderQuantity,Carts.TotalPrice
from Orders INNER JOIN Carts on  Orders.CartId=Carts.CartId INNER JOIN  Books on Carts.BookId=Books.BookId INNER JOIN Address on Orders.AddressId=Address.AddressId