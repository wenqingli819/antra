--- DB for [Company Project Management System]
use master
go
DROP DATABASE IF EXISTS CompnayProject
GO
CREATE DATABASE CompnayProject
GO
USE CompnayProject

drop table if exists Employee
drop table if exists Office
drop table if exists Project
drop table if exists [Project Operation]
drop table if exists Location

CREATE TABLE Location
(
	City VARCHAR(50),
	Country VARCHAR(50),
	NumberOfInhabitants  INT NOT NULL,

    PRIMARY KEY CLUSTERED (City, Country)
);


CREATE TABLE [Project Operation]
(
    OperationID  INT PRIMARY KEY IDENTITY(1,1),
	Operation VARCHAR(200),
	City  VARCHAR(50),
	Country VARCHAR(50),

	FOREIGN KEY (City, Country)
		REFERENCES Location (City,Country)
);



CREATE TABLE Project
(
    ProjectCode  VARCHAR(50) PRIMARY KEY,
	Title NVARCHAR(50) NOT NULL UNIQUE,
	StartDate  DATETIME,
	EndDate  DATETIME,
	Budget  MONEY,
	OperationID  INT

	FOREIGN KEY (OperationID)
		REFERENCES [Project Operation] (OperationID),
);



CREATE TABLE Office
(
    ID INT PRIMARY KEY IDENTITY(1,1),
	OfficeName NVARCHAR(50) NOT NULL UNIQUE,
	City VARCHAR(50),
	Country VARCHAR(50),
	Address VARCHAR(150),
	PhoneNumber INT NOT NULL,
	DirectorName VARCHAR(50),
	ProjectCode VARCHAR(50),

	FOREIGN KEY (City, Country)
		REFERENCES Location (City,Country),
	
	FOREIGN KEY (ProjectCode) 
		REFERENCES Project(ProjectCode)

);

CREATE TABLE Employee
(
    EmpID INT PRIMARY KEY IDENTITY(1,1),
	Name  nvarchar(50),
	JobTitle VARCHAR(50),
	OfficeID  INT,
	ProjectCode  VARCHAR(50)

	FOREIGN KEY (OfficeID) 
		REFERENCES Office(ID),

	FOREIGN KEY (ProjectCode) 
		REFERENCES Project(ProjectCode)
);


-- DB for [Lending Company Management System]
use master
go
DROP DATABASE IF EXISTS Lending
GO
CREATE DATABASE Lending
GO
USE Lending

CREATE TABLE Loan
(
    LoanCode INT PRIMARY KEY IDENTITY(1,1),
	Amount  MONEY,
	Deadline  DATETIME,
	InterestRate  Float,
	Purpose  VARCHAR(200),
	TotalAmount AS Amount*(1+InterestRate)

);

CREATE TABLE Investment
(
    InvestmentID INT PRIMARY KEY IDENTITY(1,1),
	MoneyToInvest Money,
	LoanCode  INT,

	FOREIGN KEY (LoanCode) 
		REFERENCES Loan(LoanCode)
);


CREATE TABLE Lender
(
    LenderID INT PRIMARY KEY IDENTITY(1,1),
	Name  nvarchar(50),
	AvailableMoney  MONEY,
	InvestmentID  int,
	FOREIGN KEY (InvestmentID) 
		REFERENCES Investment(InvestmentID)
);

CREATE TABLE Borrower
(
    BorrowerID  INT  PRIMARY KEY IDENTITY(1,1),
	Name  nvarchar(50),
	RiskID  INT,
	LoanCode  INT,

	FOREIGN KEY (LoanCode) 
		REFERENCES Loan(LoanCode)
);


-- DB for [Restaurant Menu Management System]
use master
go
DROP DATABASE IF EXISTS Restaurant
GO
CREATE DATABASE Restaurant
GO
USE Restaurant

drop table if exists  [Course Category]
drop table if exists Ingredient
drop table if exists Recipe

CREATE TABLE [Course Category]
(
    CategoryID  INT PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(50)  NOT NULL UNIQUE,
	Description  NVARCHAR(100),
	EmpInCharge  NVARCHAR(50)
);

CREATE TABLE Ingredient
(
    IngredientID INT PRIMARY KEY IDENTITY(1,1),
	IngredientName  nvarchar(50) NOT NULL UNIQUE,
	UnitOfMeasurement  VARCHAR(10),
	TotalAmount INT,
	AmountLeft  INT
);

CREATE TABLE Recipe
(
    RecipeID INT PRIMARY KEY IDENTITY(1,1),
	RecipeName  NVARCHAR(50) NOT NULL UNIQUE,
	IngredientID  INT,
	UnitOfMeasurement  VARCHAR(10),
	RequiredAmount  INT,
	FOREIGN KEY (IngredientID) 
		REFERENCES Ingredient(IngredientID)
);

CREATE TABLE Dish
(
    DishID INT PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(50)  NOT NULL UNIQUE,
	Description  NVARCHAR(100),
	Photo  VARBINARY(MAX),
	Price  MONEY,
	RecipeID  INT,

	FOREIGN KEY (RecipeID) 
		REFERENCES Recipe(RecipeID)

);

CREATE TABLE Course
(
    CourseID INT PRIMARY KEY IDENTITY(1,1),
	CourseName NVARCHAR(50)  NOT NULL UNIQUE,
	Description NVARCHAR(200),
	DishID  INT,
	FinalPrice Money,
	CategoryID INT,

	FOREIGN KEY (DishID) 
		REFERENCES Dish(DishID),
	FOREIGN KEY (CategoryID) 
		REFERENCES [Course Category](CategoryID)

);

CREATE TABLE Menu
(
    MenuID INT PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(50)  NOT NULL UNIQUE,
	CourseID  INT,

	FOREIGN KEY (CourseID) 
		REFERENCES Course(CourseID)

);
