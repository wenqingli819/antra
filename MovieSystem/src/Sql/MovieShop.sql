USE [MovieShop]
GO
create table dbo.Genre(
	Id int IDENTITY (1, 1),
	Name nvarchar(64),

	CONSTRAINT "PK_Genre" PRIMARY KEY  CLUSTERED 
	(
			Id
	)
)
GO

create table dbo.Movie(  
	Id int IDENTITY (1, 1),
	TmdbUrl nvarchar(2084),   
	Title nvarchar(256) not null,   
	OverView nvarchar(MAX),   
	Tagline  nvarchar(512),   
	RunTime  int,   
	Budget decimal(18,2),   
	Revenue decimal(18,2),   
	BackdropUrl nvarchar(2084),   
	PosterUrl nvarchar(2084),   
	ImdbUrl nvarchar(2084),   
	OriginalLanguage nvarchar(64),   
	ReleaseDate datetime2(7),  

	CONSTRAINT "PK_Movie" PRIMARY KEY  CLUSTERED 
		(
			Id
		)
)
GO

create table dbo.MovieGenre(
	MovieId int not null,
	GenreId int not null,

	CONSTRAINT "PK_Movie_Genre" PRIMARY KEY  CLUSTERED 
	(
		MovieId,
		GenreId
	),
	CONSTRAINT "FK_Movie_Genre_Movie" FOREIGN KEY 
	(
		MovieId
	) REFERENCES "dbo"."Movie" (
		Id
	),
	CONSTRAINT "FK_Movie_Genre_Genre" FOREIGN KEY 
	(
		GenreId
	) REFERENCES "dbo"."Genre" (
		Id
	)
)
GO

create table dbo.FilmCast(  
	Id int IDENTITY (1, 1),
	Name nvarchar(128),
    TmdbUrl nvarchar(MAX),
    Gender nvarchar(MAX) ,   
    ProfilePath nvarchar(2084),
    CONSTRAINT "PK_Cast" PRIMARY KEY  CLUSTERED 
	(
		Id
	)  
) 
GO

create table dbo.MovieCast(
	MovieId int not null,   
	CastId  int not null,   
	Character nvarchar(450) not null,
	CONSTRAINT "PK_Movie_Cast" PRIMARY KEY  CLUSTERED 
	(
		MovieId,
		CastId,
		Character
	),
	CONSTRAINT "FK_Movie_Cast_Movie" FOREIGN KEY 
	(
		MovieId
	) REFERENCES "dbo"."Movie" (
		Id
	),
	CONSTRAINT "FK_Movie_Cast_Cast" FOREIGN KEY 
	(
		CastId
	) REFERENCES "dbo"."FilmCast" (
		Id
	)
)
GO

create table dbo."User"(
	 Id int IDENTITY (1, 1),
     FirstName  nvarchar(128),
     LastName  nvarchar(128),
     DateOfBirth datetime2(7),
     Email nvarchar(256),
     HashedPassword nvarchar(256),
     Salt nvarchar(1024),
     PhoneNumber nvarchar(16),
     TwoFactorEnabled bit,
     LockoutEndDate  datetime2(7),
     LastLoginDateTime datetime2(7),
     IsLocked bit,
     AccessFailedCount int, 
     CONSTRAINT "PK_User" PRIMARY KEY  CLUSTERED 
	(
			Id
	)
)
GO

create table dbo.Review(
	MovieId int not null,
   	UserId  int not null,
    Rating  decimal(3,2) not null,
    ReviewText nvarchar(MAX), 
    CONSTRAINT "PK_Review" PRIMARY KEY  CLUSTERED 
	(
			MovieId,
   			UserId
	),
	CONSTRAINT "FK_Review_Movie" FOREIGN KEY 
	(
		MovieId
	) REFERENCES "dbo"."Movie" (
		Id
	),
	CONSTRAINT "FK_Review_User" FOREIGN KEY 
	(
		UserId
	) REFERENCES "dbo"."User" (
		Id
	)
)