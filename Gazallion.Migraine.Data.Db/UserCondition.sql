CREATE TABLE [dbo].[UserCondition]
(
	[UserId] INT NOT NULL , 
    [ConditionId] INT NOT NULL, 
    [IncidentThreshold] INT NULL, 
    [ThresholdTimePeriod] INT NULL, 
    PRIMARY KEY ([UserId], [ConditionId]), 
    CONSTRAINT [FK_UserCondition_User] FOREIGN KEY ([UserId]) REFERENCES [User]([UserId]), 
    CONSTRAINT [FK_UserCondition_Condition] FOREIGN KEY ([ConditionId]) REFERENCES [Condition]([ConditionId])
)
