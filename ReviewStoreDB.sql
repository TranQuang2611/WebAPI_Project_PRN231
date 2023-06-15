drop database ReviewStore
create database ReviewStore

CREATE TABLE Users (
    UserID INT PRIMARY KEY identity(1,1),
    Username NVARCHAR(50) NOT NULL,
    Password VARCHAR(50) NOT NULL
);

Create TABLE Category(
	CategoryID int primary key identity(1,1),
	CategoryName nvarchar(100)
)

Create TABLE Brand(
	BrandID int primary key identity(1,1),
	BrandName nvarchar(100)
)

Create TABLE Color(
	ColorID int primary key identity(1,1),
	ColorName nvarchar(100)
)

Create TABLE Size(
	SizeID int primary key identity(1,1),
	Size decimal
)

Create TABLE Ram(
	RamID int primary key identity(1,1),
	RamSize int
)

CREATE TABLE Products (
    ProductID INT PRIMARY KEY identity(1,1),
    ProductName NVARCHAR(100),
    ProductImg NVARCHAR(max),
	RamID int,
	BrandID int,
	UnitPrice decimal,
	ColorID int,
	SizeID int,
	UnitSellPrice decimal,
	UnitInStock INT,
	[Description]  NVARCHAR(max),
	CategoryID int,
	FOREIGN KEY (CategoryID) REFERENCES Category(CategoryID),
	FOREIGN KEY (BrandID) REFERENCES Brand(BrandID),
	FOREIGN KEY (ColorID) REFERENCES Color(ColorID),
	FOREIGN KEY (SizeID) REFERENCES Size(SizeID),
	FOREIGN KEY (RamID) REFERENCES Ram(RamID),
);


CREATE TABLE Reviews (
    ReviewID INT PRIMARY KEY identity(1,1),
    UserID INT,
    ProductID INT,
    Rating INT,
	ReviewDate Datetime,
	LikeReact int,
    [Content] NVARCHAR(MAX),
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

CREATE TABLE Comments (
    CommentID INT PRIMARY KEY identity(1,1),
    UserID INT,
    ReviewID INT,
	CommentDate Datetime,
	LikeReact int,
    Comment NVARCHAR(MAX),
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    FOREIGN KEY (ReviewID) REFERENCES Reviews(ReviewID)
);