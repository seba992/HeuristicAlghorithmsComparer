CREATE TABLE [dbo].[Points] (
    [Id]              INT        IDENTITY (1, 1) NOT NULL,
    [ResultDetailId]  INT        NOT NULL,
    [PointValue]      FLOAT (53) NOT NULL,
    [ResultDimension] INT        NOT NULL,
    CONSTRAINT [PK_Points] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ResultDetailPoint] FOREIGN KEY ([ResultDetailId]) REFERENCES [dbo].[ResultDetails] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_FK_ResultDetailPoint]
    ON [dbo].[Points]([ResultDetailId] ASC);

