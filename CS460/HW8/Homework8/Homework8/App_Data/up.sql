CREATE TABLE Artists
(		
	ArtistID	INT IDENTITY(1,1) NOT NULL,
	ArtistName	NVARCHAR(100) NOT NULL,
	DOB			DATE NOT NULL,
	BirthCity	NVARCHAR(100),
	CONSTRAINT	[PK_dbo.Artists] PRIMARY KEY CLUSTERED (ArtistID ASC)
);

CREATE TABLE ArtWorks
(
	ArtWorkID	INT IDENTITY (1,1) NOT NULL,
	ArtistID	INT NOT NULL,
	Title		NVARCHAR(100) NOT NULL,
	CONSTRAINT [PK.dbo.ArtWorks] PRIMARY KEY CLUSTERED (ArtWorkID ASC),
	CONSTRAINT [FK_dbo.ArtWorks_Artists] FOREIGN KEY (ArtistID) REFERENCES dbo.Artists(ArtistID)
);

CREATE TABLE Genres
(
	GenreID		INT IDENTITY (1,1) NOT NULL,
	GenreName	NVARCHAR(100) NOT NULL,
	CONSTRAINT [PK_dbo.Genres] PRIMARY KEY CLUSTERED (GenreID ASC)
);

CREATE TABLE Classifications
(
	ClassificationID	INT IDENTITY (1,1) NOT NULL,
	ArtWorkID			INT NOT NULL,
	GenreID				INT NOT NULL,
	CONSTRAINT [PK.dbo.Classifications] PRIMARY KEY CLUSTERED (ClassificationID ASC),
	CONSTRAINT [FK_dbo.Classifications_]
);

CREATE TABLE dbo.Classifications
(
	ClassificationID int Identity(1,1) NOT NULL,
	ArtWorkID INT NOT NULL,
	GenreID INT NOT NULL,
	CONSTRAINT [PK_dbo.Classifications] PRIMARY KEY CLUSTERED (ClassificationID ASC),
	CONSTRAINT [FK_dbo.ArtWorks_Classifications] FOREIGN KEY (ArtWorkID) REFERENCES dbo.ArtWorks(ArtWorkID),
	CONSTRAINT [FK_dbo.Genre_Classifications] FOREIGN KEY (GenreID) REFERENCES dbo.Genres(GenreID)
);