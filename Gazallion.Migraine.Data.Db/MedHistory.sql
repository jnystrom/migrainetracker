CREATE TABLE [dbo].[MedHistory]
(
	[MedHistoryId] INT NOT NULL PRIMARY KEY identity, 
    [UserId] INT NOT NULL, 
    [StartDate] DATETIME NOT NULL, 
    [EndDate] DATETIME NULL, 
    [ConditionId] INT NOT NULL, 
    [MedId] INT NULL, 
    CONSTRAINT [FK_MedHistory_User] FOREIGN KEY ([UserId]) REFERENCES [User]([UserId]), 
    CONSTRAINT [FK_MedHistory_ConditionType] FOREIGN KEY ([ConditionId]) REFERENCES [Condition]([ConditionId]), 
    CONSTRAINT [FK_MedHistory_Medicine] FOREIGN KEY ([MedId]) REFERENCES [Medicine]([MedId])
)
