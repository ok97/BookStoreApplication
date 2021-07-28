


CREATE TABLE [dbo].[Carts](	
	[UserId] [int] ,
	[CartId] [int] IDENTITY(1,1) NOT NULL,
	[BookId] [int] ,
	[OrderQuantity] [int] DEFAULT 1 NOT NULL
	PRIMARY KEY (CartId));

	drop table Carts
	select * from Carts
		select * from Admin
			select * from Books

INSERT INTO Carts ([UserId], [BookId])
VALUES (1, 1);

	TRUNCATE TABLE Carts