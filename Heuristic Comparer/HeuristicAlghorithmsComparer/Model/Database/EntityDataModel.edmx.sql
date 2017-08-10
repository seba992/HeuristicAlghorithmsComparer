
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/10/2017 23:12:32
-- Generated from EDMX file: C:\Users\Sebastian Nalepka\Documents\HeuristicAlghorithmsComparer\Heuristic Comparer\HeuristicAlghorithmsComparer\Model\Database\EntityDataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Metaheuristic];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AlghoritmsResults]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Results] DROP CONSTRAINT [FK_AlghoritmsResults];
GO
IF OBJECT_ID(N'[dbo].[FK_InputParametersResults]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Results] DROP CONSTRAINT [FK_InputParametersResults];
GO
IF OBJECT_ID(N'[dbo].[FK_ExitFlagsResultDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ResultDetails] DROP CONSTRAINT [FK_ExitFlagsResultDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_ResultDetailsResults]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Results] DROP CONSTRAINT [FK_ResultDetailsResults];
GO
IF OBJECT_ID(N'[dbo].[FK_TestFunctionResult]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Results] DROP CONSTRAINT [FK_TestFunctionResult];
GO
IF OBJECT_ID(N'[dbo].[FK_ResultDetailPoint]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Points] DROP CONSTRAINT [FK_ResultDetailPoint];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Alghoritms]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Alghoritms];
GO
IF OBJECT_ID(N'[dbo].[InputParameters]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InputParameters];
GO
IF OBJECT_ID(N'[dbo].[Results]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Results];
GO
IF OBJECT_ID(N'[dbo].[ResultDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ResultDetails];
GO
IF OBJECT_ID(N'[dbo].[ExitFlags]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ExitFlags];
GO
IF OBJECT_ID(N'[dbo].[TestFunctions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TestFunctions];
GO
IF OBJECT_ID(N'[dbo].[Points]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Points];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Alghoritms'
CREATE TABLE [dbo].[Alghoritms] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'InputParameters'
CREATE TABLE [dbo].[InputParameters] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [MaxTime] int  NOT NULL,
    [MaxIterations] int  NOT NULL,
    [MaxFunctionEvaluations] int  NOT NULL,
    [SwarmSize] int  NULL,
    [PopulationSize] int  NULL,
    [MaxStallIterations] int  NOT NULL
);
GO

-- Creating table 'Results'
CREATE TABLE [dbo].[Results] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AlghoritmId] int  NOT NULL,
    [InputParametersId] int  NOT NULL,
    [ResultDetailsId] int  NOT NULL,
    [TestFunctionId] int  NOT NULL,
    [CreatedOn] datetime  NULL
);
GO

-- Creating table 'ResultDetails'
CREATE TABLE [dbo].[ResultDetails] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Iterations] int  NOT NULL,
    [FunctionEvaluations] int  NOT NULL,
    [BestFunctionValue] decimal(18,10)  NOT NULL,
    [TotalTime] decimal(18,10)  NOT NULL,
    [TerminatedMessage] nvarchar(max)  NULL,
    [ExitFlagId] int  NULL
);
GO

-- Creating table 'ExitFlags'
CREATE TABLE [dbo].[ExitFlags] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'TestFunctions'
CREATE TABLE [dbo].[TestFunctions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [DifficultyLevel] int  NOT NULL,
    [FunctionGraphLink] nvarchar(max)  NOT NULL,
    [BoundRange] int  NOT NULL,
    [Dimension] int  NOT NULL
);
GO

-- Creating table 'Points'
CREATE TABLE [dbo].[Points] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ResultDetailId] int  NOT NULL,
    [PointValue] float  NOT NULL,
    [ResultDimension] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Alghoritms'
ALTER TABLE [dbo].[Alghoritms]
ADD CONSTRAINT [PK_Alghoritms]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'InputParameters'
ALTER TABLE [dbo].[InputParameters]
ADD CONSTRAINT [PK_InputParameters]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Results'
ALTER TABLE [dbo].[Results]
ADD CONSTRAINT [PK_Results]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ResultDetails'
ALTER TABLE [dbo].[ResultDetails]
ADD CONSTRAINT [PK_ResultDetails]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ExitFlags'
ALTER TABLE [dbo].[ExitFlags]
ADD CONSTRAINT [PK_ExitFlags]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TestFunctions'
ALTER TABLE [dbo].[TestFunctions]
ADD CONSTRAINT [PK_TestFunctions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Points'
ALTER TABLE [dbo].[Points]
ADD CONSTRAINT [PK_Points]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AlghoritmId] in table 'Results'
ALTER TABLE [dbo].[Results]
ADD CONSTRAINT [FK_AlghoritmsResults]
    FOREIGN KEY ([AlghoritmId])
    REFERENCES [dbo].[Alghoritms]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AlghoritmsResults'
CREATE INDEX [IX_FK_AlghoritmsResults]
ON [dbo].[Results]
    ([AlghoritmId]);
GO

-- Creating foreign key on [InputParametersId] in table 'Results'
ALTER TABLE [dbo].[Results]
ADD CONSTRAINT [FK_InputParametersResults]
    FOREIGN KEY ([InputParametersId])
    REFERENCES [dbo].[InputParameters]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_InputParametersResults'
CREATE INDEX [IX_FK_InputParametersResults]
ON [dbo].[Results]
    ([InputParametersId]);
GO

-- Creating foreign key on [ExitFlagId] in table 'ResultDetails'
ALTER TABLE [dbo].[ResultDetails]
ADD CONSTRAINT [FK_ExitFlagsResultDetails]
    FOREIGN KEY ([ExitFlagId])
    REFERENCES [dbo].[ExitFlags]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ExitFlagsResultDetails'
CREATE INDEX [IX_FK_ExitFlagsResultDetails]
ON [dbo].[ResultDetails]
    ([ExitFlagId]);
GO

-- Creating foreign key on [ResultDetailsId] in table 'Results'
ALTER TABLE [dbo].[Results]
ADD CONSTRAINT [FK_ResultDetailsResults]
    FOREIGN KEY ([ResultDetailsId])
    REFERENCES [dbo].[ResultDetails]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ResultDetailsResults'
CREATE INDEX [IX_FK_ResultDetailsResults]
ON [dbo].[Results]
    ([ResultDetailsId]);
GO

-- Creating foreign key on [TestFunctionId] in table 'Results'
ALTER TABLE [dbo].[Results]
ADD CONSTRAINT [FK_TestFunctionResult]
    FOREIGN KEY ([TestFunctionId])
    REFERENCES [dbo].[TestFunctions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TestFunctionResult'
CREATE INDEX [IX_FK_TestFunctionResult]
ON [dbo].[Results]
    ([TestFunctionId]);
GO

-- Creating foreign key on [ResultDetailId] in table 'Points'
ALTER TABLE [dbo].[Points]
ADD CONSTRAINT [FK_ResultDetailPoint]
    FOREIGN KEY ([ResultDetailId])
    REFERENCES [dbo].[ResultDetails]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ResultDetailPoint'
CREATE INDEX [IX_FK_ResultDetailPoint]
ON [dbo].[Points]
    ([ResultDetailId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------