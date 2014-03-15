CREATE TABLE [dbo].[Address]
(
	[AddressId] INT NOT NULL PRIMARY KEY identity, 
    [UserId] INT NOT NULL, 
    [StreetName] VARCHAR(50) NOT NULL, 
    [StreetNumber] VARCHAR(50) NOT NULL, 
    [City] VARCHAR(50) NOT NULL, 
    [Region] VARCHAR(50) NOT NULL, 
    [ZipCode] VARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_Address_User] FOREIGN KEY ([UserId]) REFERENCES [User]([UserId])
)
