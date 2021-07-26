


CREATE TABLE [dbo].[Carts](	
	[UserId] [int] ,
	[CartId] [int] IDENTITY(1,1) NOT NULL,
	[BookId] [int] ,
	[IsUsed]varchar(20) DEFAULT 'false'
	PRIMARY KEY (CartId));

	drop table Carts
	select * from Carts