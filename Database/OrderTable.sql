


CREATE TABLE [dbo].[Orders](	
	[UserId] [int] ,
	[CartId] [int] ,
	[AddressId] [int] ,
	[OrderId] [int] IDENTITY(1,1) NOT NULL
	PRIMARY KEY ([OrderId]));


select * from [Orders]