﻿-- AddressChanges table
CREATE TABLE Searches
(
	ID					INT IDENTITY (1,1) NOT NULL,
	QUERY				NVARCHAR(100) NOT NULL,
	
	CONSTRAINT [PK_dbo.Searches] PRIMARY KEY CLUSTERED (ID ASC)
);