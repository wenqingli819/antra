USE [MovieShop]
GO

create proc [dbo].spUpdateCast
	@Id int,
	@Name nvarchar(128),
    @TmdbUrl nvarchar(MAX),
    @Gender nvarchar(MAX) ,   
    @ProfilePath nvarchar(2084)
as
	update dbo.Cast 
	set Name=@Name, Gender=@Gender, TmdbUrl=@TmdbUrl, ProfilePath=@ProfilePath
	where Id = @Id
GO

EXECUTE [dbo].spUpdateCast @Id = 35214, @Name = "life is hard", @Gender = "female", @TmdbUrl = "something", @ProfilePath = "some other thing";   --test ok 

create proc [dbo].spDeleteCastByID
	@Id int
as
	delete from dbo.Cast where Id = @Id
GO

EXECUTE [dbo].spDeleteCastByID @Id = 35215;   --test ok


create proc [dbo].spGetAllCasts
as
	select * from dbo.Cast 
	order by Id
GO

EXECUTE [dbo].spGetAllCasts   --test ok

create proc [dbo].spGetCastByID
	@Id INT  
AS  
    SELECT * from dbo.Cast
	WHERE Id = @Id   
GO  


EXECUTE [dbo].spGetCastByID @Id = 1;   --test ok