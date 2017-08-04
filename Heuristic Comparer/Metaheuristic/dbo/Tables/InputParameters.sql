CREATE TABLE [dbo].[InputParameters] (
    [Id]                     INT IDENTITY (1, 1) NOT NULL,
    [MaxTime]                INT NOT NULL,
    [MaxIterations]          INT NOT NULL,
    [MaxFunctionEvaluations] INT NOT NULL,
    [SwarmSize]              INT NULL,
    [PopulationSize]         INT NULL,
    [MaxStallIterations]     INT NOT NULL,
    CONSTRAINT [PK_InputParameters] PRIMARY KEY CLUSTERED ([Id] ASC)
);

