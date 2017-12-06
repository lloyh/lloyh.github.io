CREATE TABLE Buyers
(		
	BuyerID		INT IDENTITY(1,1) NOT NULL,
	BuyerName	NVARCHAR(50) NOT NULL,
	CONSTRAINT	[PK_dbo.Buyers] PRIMARY KEY CLUSTERED (BuyerID ASC)
);

CREATE TABLE Sellers
(		
	SellerID	INT IDENTITY(1,1) NOT NULL,
	SellerName	NVARCHAR(50) NOT NULL,
	CONSTRAINT	[PK_dbo.Sellers] PRIMARY KEY CLUSTERED (SellerID ASC)
);

CREATE TABLE Items
(		
	ItemID			INT IDENTITY(1001,1) NOT NULL,
	ItemName		NVARCHAR(50) NOT NULL,
	ItemDescription	NVARCHAR(100) NOT NULL,
	SellerID		INT NOT NULL,
	CONSTRAINT	[PK_dbo.Items] PRIMARY KEY CLUSTERED (ItemID ASC),
	CONSTRAINT	[FK_dbo.Items_Sellers] FOREIGN KEY (SellerID) REFERENCES dbo.Sellers(SellerID)
);

CREATE TABLE Bids
(
	BidID	INT IDENTITY(1,1) NOT NULL,
	ItemID	INT NOT NULL,
	BuyerID	INT NOT NULL,
	Price	INT NOT NULL,
	BidDate	DATETIME NOT NULL,
	CONSTRAINT	[PK_dbo.Bids] PRIMARY KEY CLUSTERED (BidID ASC),
	CONSTRAINT	[FK_dbo.Items_Bids] FOREIGN KEY (ItemID) REFERENCES dbo.Items(ItemID),
	CONSTRAINT	[PK_dbo.Buyers_Bids] FOREIGN KEY (BuyerID) REFERENCES dbo.Buyers(BuyerID)	
);

-- Buyers
INSERT INTO dbo.Buyers
(
	BuyerName
)
VALUES
('Jane Stone'),
('Tom McMasters'),
('Otto Vanderwall');

-- Sellers
INSERT INTO dbo.Sellers
(
	SellerName
)
VALUES
('Gayle Hardy'),
('Lyle Banks'),
('Pearl Greene');

-- Items
INSERT INTO dbo.Items
(
	ItemName,
	ItemDescription,
	SellerID
)
VALUES
('Abraham Lincoln Hammer'    ,'A bench mallet fashioned from a broken rail-splitting maul in 1829 and owned by Abraham Lincoln', 3),
('Albert Einsteins Telescope','A brass telescope owned by Albert Einstein in Germany, circa 1927', 1),
('Bob Dylan Love Poems'      ,'Five versions of an original unpublished, handwritten, love poem by Bob Dylan', 2);

--Bids
INSERT INTO dbo.Bids
(
	ItemID,
	Price,
	BidDate,
	BuyerID
)
VALUES
(1001,250000,'12/04/2017 09:04:22',3),
(1003,95000 ,'12/04/2017 08:44:03',1);



