CREATE TABLE WishList (
    WishListId INT PRIMARY KEY IDENTITY(1,1),
    BookId int ,
    UserId int,   
    FOREIGN KEY (BookId) REFERENCES Books(BookId),
	 FOREIGN KEY (UserId) REFERENCES Users(UserId)

);
Select * from WishList