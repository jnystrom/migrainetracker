CREATE TABLE [dbo].[UserMed]
(
	[UserMedId] INT NOT NULL PRIMARY KEY identity, 
    [UserId] INT NOT NULL, 
    [MedId] INT NOT NULL, 
    [StartDate] DATETIME NOT NULL, 
    [EndDate] DATETIME NULL, 
    CONSTRAINT [FK_UserMeds_User] FOREIGN KEY ([UserId]) REFERENCES [User]([UserId]), 
    CONSTRAINT [FK_UserMed_Med] FOREIGN KEY (MedId) REFERENCES [Medicine]([MedId])
)
