CREATE TABLE Artists
(		
	ArtistID	INT IDENTITY(1,1) NOT NULL,
	ArtistName	NVARCHAR(50) NOT NULL,
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
	CONSTRAINT [PK_dbo.Classifications] PRIMARY KEY CLUSTERED (ClassificationID ASC),
	CONSTRAINT [FK_dbo.ArtWorks_Classifications] FOREIGN KEY (ArtWorkID) REFERENCES dbo.ArtWorks(ArtWorkID),
	CONSTRAINT [FK_dbo.Genre_Classifications] FOREIGN KEY (GenreID) REFERENCES dbo.Genres(GenreID)
);

INSERT INTO dbo.Artists
(
	ArtistName,
	DOB,
	BirthCity
)
VALUES
	('MC Escher','06/17/1898', 'Leeuwarden, Netherlands' ),
	('Leonardo Da Vinci', '05/02/1519', 'Vinci, Italy'),
	('Hatip Mehmed Efendi','11/18/1680','Unknown'),
	('Salvador Dali','05/11/1904','Figueres, Spain');

INSERT INTO dbo.Genres
(
    GenreName
)
VALUES
	('Tesselation'),
	('Surrealism'),
	('Portrait'),
	('Renaissance');

INSERT INTO dbo.ArtWorks
(
	Title,
	ArtistID
)
VALUES
	('Circle Limit III', '1'),
	('Twon Tree', '1'),
	('Mona Lisa', '2'),
	('The Vitruvian Man','2'),
	('Ebru','3'),
	('Honey Is Sweeter Than Blood','4');

INSERT INTO dbo.Classifications
(
    ArtWorkID,
    GenreID
)
VALUES
	( '1', '1' ),
	( '2', '1' ),
	( '2', '2' ),
	( '3', '3' ),
	( '3', '4' ),
	( '4', '4' ),
	( '5', '4' ),
	( '6', '2' );
GO