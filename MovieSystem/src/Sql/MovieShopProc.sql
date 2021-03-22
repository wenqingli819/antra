USE [MovieShop]
GO

create proc [dbo].spUpdateCast
	@Id int,
	@Name nvarchar(128),
    @TmdbUrl nvarchar(MAX),
    @Gender nvarchar(MAX) ,   
    @ProfilePath nvarchar(2084)
as
	update dbo.FilmCast 
	set Name=@Name, Gender=@Gender, TmdbUrl=@TmdbUrl, ProfilePath=@ProfilePath
	where Id = @Id
GO

create proc [dbo].spDeleteCast
	@Id int
as
	delete from dbo.FilmCast where Id = @Id
GO


create proc [dbo].spGetAllCasts
as
	select * from dbo.FilmCast 
	order by Id
GO

EXECUTE [dbo].spGetAllCasts

create proc [dbo].spGetCastByID
	@Id INT  
AS  
    SELECT * from dbo.FilmCast
	WHERE Id = @Id   
GO  