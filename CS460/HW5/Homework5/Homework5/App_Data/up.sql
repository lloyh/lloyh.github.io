-- AddressChanges table
CREATE TABLE AddressChanges
(
	ID					INT IDENTITY (1,1) NOT NULL,
	ODL					INT NOT NULL,
	DOB					DATE NOT NULL,		
	FullName			NVARCHAR(100) NOT NULL,
	NewStreetAddress	NVARCHAR(100) NOT NULL,
	NewCity				NVARCHAR(100) NOT NULL,
	NewState			NVARCHAR(100) NOT NULL,
	NewZipCode			INT NOT NULL,
	NewCounty			NVARCHAR(100) NOT NULL,
	DateSubmitted		DATE NOT NULL
	CONSTRAINT [PK_dbo.AddressChanges] PRIMARY KEY CLUSTERED (ID ASC)
);
	

INSERT INTO AddressChanges (ODL, DOB, FullName, NewStreetAddress, NewCity, NewState, NewZipCode, NewCounty, DateSubmitted) VALUES
	(12332132,'1984-11-05','James Tiberius Kirk','4550 Madrona Avenue','Salem','Oregon',97306,'Marion','2017-05-11');
INSERT INTO AddressChanges (ODL, DOB, FullName, NewStreetAddress, NewCity, NewState, NewZipCode, NewCounty, DateSubmitted) VALUES
	(45665465,'1974-07-01','Jean-Luc Picard','5370 Commercial Street','Salem','Oregon',97303,'Marion','2017-04-20');
INSERT INTO AddressChanges (ODL, DOB, FullName, NewStreetAddress, NewCity, NewState, NewZipCode, NewCounty, DateSubmitted) VALUES
	(78998798,'1970-05-07','Benjamin Sisko','309 SW 6th Avenue','Portland','Oregon',97204,'Multnomah','2016-01-01');
INSERT INTO AddressChanges (ODL, DOB, FullName, NewStreetAddress, NewCity, NewState, NewZipCode, NewCounty, DateSubmitted) VALUES
	(15995195,'1980-04-25','Kathryn Janeway','135 Oakway Road','Eugene','Oregon',97401,'Lane','2017-02-15');
INSERT INTO AddressChanges (ODL, DOB, FullName, NewStreetAddress, NewCity, NewState, NewZipCode, NewCounty, DateSubmitted) VALUES
	(75335735,'1980-04-25','Jonathan Archer','1001 North Arney Road','Woodburn','Oregon',97071,'Marion','2017-10-15');