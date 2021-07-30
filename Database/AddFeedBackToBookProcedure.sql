

create Proc sp_ReviewBackToBook
@UserId int,
@BookId int,
@Review int,
@Feedback varchar(30)
AS
BEGIN
Insert into Review (UserId ,BookId,Review,Feedback) values (@UserId,@BookId,@Review,@Feedback)
	
	END
GO
