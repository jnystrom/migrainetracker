CREATE TABLE [dbo].[Medicine]
(
	[MedId] INT NOT NULL PRIMARY KEY identity, 
    [MedTypeId] INT NOT NULL, 
    [Name] VARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_Medicine_MedType] FOREIGN KEY ([MedTypeId]) REFERENCES [MedType]([MedTypeId])
)
