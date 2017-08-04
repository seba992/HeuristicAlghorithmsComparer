CREATE TABLE [dbo].[ResultDetails] (
    [Id]                  INT              IDENTITY (1, 1) NOT NULL,
    [Iterations]          INT              NOT NULL,
    [FunctionEvaluations] INT              NOT NULL,
    [BestFunctionValue]   DECIMAL (18, 10) NOT NULL,
    [TotalTime]           DECIMAL (10)     NOT NULL,
    [TerminatedMessage]   NVARCHAR (MAX)   NULL,
    [ExitFlagId]          INT              NULL,
    CONSTRAINT [PK_ResultDetails] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ExitFlagsResultDetails] FOREIGN KEY ([ExitFlagId]) REFERENCES [dbo].[ExitFlags] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_FK_ExitFlagsResultDetails]
    ON [dbo].[ResultDetails]([ExitFlagId] ASC);

