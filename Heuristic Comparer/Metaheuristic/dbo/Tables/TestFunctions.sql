CREATE TABLE [dbo].[TestFunctions] (
    [Id]                INT            IDENTITY (1, 1) NOT NULL,
    [Name]              NVARCHAR (MAX) NOT NULL,
    [DifficultyLevel]   INT            NOT NULL,
    [FunctionGraphLink] NVARCHAR (MAX) NOT NULL,
    [BoundRange]        INT            NOT NULL,
    [Dimension]         INT            NOT NULL,
    CONSTRAINT [PK_TestFunctions] PRIMARY KEY CLUSTERED ([Id] ASC)
);



