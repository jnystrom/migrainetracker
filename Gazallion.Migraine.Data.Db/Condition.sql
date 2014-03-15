CREATE TABLE [dbo].[Condition]
(
	[ConditionId] INT NOT NULL PRIMARY KEY identity, 
    [Name] VARCHAR(50) NOT NULL, 
    [Description] VARCHAR(250) NULL
)
