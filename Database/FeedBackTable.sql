
CREATE TABLE Review (
    UserId int,
    BookId int ,
	ReviewId INT PRIMARY KEY IDENTITY(1,1),
	Review int default 0,
	Feedback varchar(30)
    FOREIGN KEY (BookId) REFERENCES Books(BookId),
	FOREIGN KEY (UserId) REFERENCES Users(UserId)

);
Select * from Review


