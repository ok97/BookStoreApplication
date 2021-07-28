

	CREATE TABLE [dbo].[Address](	
	[UserId] int,
	[AddressId] int IDENTITY(1,1) NOT NULL,
	[CustomerName] varchar(20) ,
	[City] varchar(20) ,
	[State] varchar(30),
	[Country] varchar(30) ,
	[Pincode] varchar(30) ,
	[MobileNumber] varchar(30)
	PRIMARY KEY(AddressId));

