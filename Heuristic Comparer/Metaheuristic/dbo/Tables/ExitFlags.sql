CREATE TABLE [dbo].[ExitFlags] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Description] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_ExitFlags] PRIMARY KEY CLUSTERED ([Id] ASC)
);

