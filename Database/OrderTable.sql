sp_AddOrder


CREATE TABLE [dbo].[Order](	
	[UserId] [int] ,
	[CartId] [int] ,
	[AddressId] [int] ,
	[OrderId] [int] IDENTITY(1,1) NOT NULL
	PRIMARY KEY ([OrderId]));