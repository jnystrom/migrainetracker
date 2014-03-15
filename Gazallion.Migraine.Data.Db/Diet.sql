CREATE TABLE [dbo].[Diet]
(
	[DietId] INT NOT NULL PRIMARY KEY identity, 
    [UserId] INT NOT NULL, 
    [MedHistoryId] INT NOT NULL, 
    [FoodItemName] VARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_Diet_User] FOREIGN KEY ([UserId]) REFERENCES [User]([UserId]), 
    CONSTRAINT [FK_Diet_MedHistory] FOREIGN KEY ([MedHistoryId]) REFERENCES [MedHistory]([MedHistoryId])
)
