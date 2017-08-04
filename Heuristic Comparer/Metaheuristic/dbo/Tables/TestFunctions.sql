CREATE TABLE [dbo].[TestFunctions] (
    [Id]                INT            IDENTITY (1, 1) NOT NULL,
    [Name]              NVARCHAR (MAX) NOT NULL,
    [DifficultyLevel]   INT NOT NULL,
    [FunctionGraphLink] NVARCHAR (MAX) NOT NULL,
    [LowerBoundX]       INT NOT NULL,
    [LowerBoundY]       INT NOT NULL,
    [UpperBoundX]       INT NOT NULL,
    [UpperBoundY]       INT NOT NULL,
    CONSTRAINT [PK_TestFunctions] PRIMARY KEY CLUSTERED ([Id] ASC)
);

