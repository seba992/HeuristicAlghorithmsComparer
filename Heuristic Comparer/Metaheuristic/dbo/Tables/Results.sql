CREATE TABLE [dbo].[Results] (
    [Id]                INT IDENTITY (1, 1) NOT NULL,
    [AlghoritmId]       INT NOT NULL,
    [InputParametersId] INT NOT NULL,
    [ResultDetailsId]   INT NOT NULL,
    [TestFunctionId]    INT NOT NULL,
    CONSTRAINT [PK_Results] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AlghoritmsResults] FOREIGN KEY ([AlghoritmId]) REFERENCES [dbo].[Alghoritms] ([Id]),
    CONSTRAINT [FK_InputParametersResults] FOREIGN KEY ([InputParametersId]) REFERENCES [dbo].[InputParameters] ([Id]),
    CONSTRAINT [FK_ResultDetailsResults] FOREIGN KEY ([ResultDetailsId]) REFERENCES [dbo].[ResultDetails] ([Id]),
    CONSTRAINT [FK_TestFunctionResult] FOREIGN KEY ([TestFunctionId]) REFERENCES [dbo].[TestFunctions] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_FK_AlghoritmsResults]
    ON [dbo].[Results]([AlghoritmId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_FK_InputParametersResults]
    ON [dbo].[Results]([InputParametersId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_FK_ResultDetailsResults]
    ON [dbo].[Results]([ResultDetailsId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_FK_TestFunctionResult]
    ON [dbo].[Results]([TestFunctionId] ASC);

