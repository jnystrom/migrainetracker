CREATE TABLE [dbo].[User]
(
	[UserId] INT NOT NULL PRIMARY KEY identity, 
    [UserToken] VARCHAR(50) NULL, 
    [FirstName] VARCHAR(50) NOT NULL, 
    [LastName] VARCHAR(100) NOT NULL, 
    [EmailAddress] VARCHAR(100) NOT NULL
)
