
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/26/2014 20:00:20
-- Generated from EDMX file: C:\Users\fernando\Source\Repos\BoardingList\RandomSorterGenerator\RandomSorterDAL\App_Data\RandomSorterModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_GameAssociationTeamTeam]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GameAssociationTeamSet] DROP CONSTRAINT [FK_GameAssociationTeamTeam];
GO
IF OBJECT_ID(N'[dbo].[FK_GameAssociationTeamGame]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GameAssociationTeamSet] DROP CONSTRAINT [FK_GameAssociationTeamGame];
GO
IF OBJECT_ID(N'[dbo].[FK_GameAssociationTeamPlayer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GameAssociationTeamSet] DROP CONSTRAINT [FK_GameAssociationTeamPlayer];
GO
IF OBJECT_ID(N'[dbo].[FK_UserProfile]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserSet] DROP CONSTRAINT [FK_UserProfile];
GO
IF OBJECT_ID(N'[dbo].[FK_PlayerUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PlayerSet] DROP CONSTRAINT [FK_PlayerUser];
GO
IF OBJECT_ID(N'[dbo].[FK_PlayerRepository_inherits_Player]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PlayerSet_PlayerRepository] DROP CONSTRAINT [FK_PlayerRepository_inherits_Player];
GO
IF OBJECT_ID(N'[dbo].[FK_PlayerStaging_inherits_Player]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PlayerSet_PlayerStaging] DROP CONSTRAINT [FK_PlayerStaging_inherits_Player];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[TeamSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TeamSet];
GO
IF OBJECT_ID(N'[dbo].[GameSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GameSet];
GO
IF OBJECT_ID(N'[dbo].[PlayerSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PlayerSet];
GO
IF OBJECT_ID(N'[dbo].[GameAssociationTeamSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GameAssociationTeamSet];
GO
IF OBJECT_ID(N'[dbo].[UserSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserSet];
GO
IF OBJECT_ID(N'[dbo].[ProfileSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProfileSet];
GO
IF OBJECT_ID(N'[dbo].[PlayerSet_PlayerRepository]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PlayerSet_PlayerRepository];
GO
IF OBJECT_ID(N'[dbo].[PlayerSet_PlayerStaging]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PlayerSet_PlayerStaging];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'TeamSet'
CREATE TABLE [dbo].[TeamSet] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [DateCreated] datetime  NOT NULL,
    [DateModified] datetime  NULL,
    [UserModified] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'GameSet'
CREATE TABLE [dbo].[GameSet] (
    [Id] uniqueidentifier  NOT NULL,
    [Date] datetime  NOT NULL,
    [DateCreated] datetime  NOT NULL,
    [DateModified] datetime  NULL,
    [UserModified] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PlayerSet'
CREATE TABLE [dbo].[PlayerSet] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Rating] smallint  NOT NULL,
    [DateCreated] datetime  NOT NULL,
    [DateModified] datetime  NULL,
    [UserModified] nvarchar(max)  NOT NULL,
    [User_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'GameAssociationTeamSet'
CREATE TABLE [dbo].[GameAssociationTeamSet] (
    [Id] uniqueidentifier  NOT NULL,
    [GameId] uniqueidentifier  NOT NULL,
    [TeamId] uniqueidentifier  NOT NULL,
    [PlayerId] uniqueidentifier  NOT NULL,
    [DateCreated] datetime  NOT NULL,
    [DateModified] datetime  NULL,
    [UserModified] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'UserSet'
CREATE TABLE [dbo].[UserSet] (
    [Id] uniqueidentifier  NOT NULL,
    [Username] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [IsActivated] bit  NOT NULL,
    [DateCreated] datetime  NOT NULL,
    [DateModified] datetime  NULL,
    [UserModified] nvarchar(max)  NOT NULL,
    [IdProfile] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'ProfileSet'
CREATE TABLE [dbo].[ProfileSet] (
    [Id] uniqueidentifier  NOT NULL,
    [Designation] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PlayerSet_PlayerRepository'
CREATE TABLE [dbo].[PlayerSet_PlayerRepository] (
    [Email] nvarchar(max)  NOT NULL,
    [MobilePhone] int  NOT NULL,
    [Active] bit  NOT NULL,
    [Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'PlayerSet_PlayerStaging'
CREATE TABLE [dbo].[PlayerSet_PlayerStaging] (
    [AcceptanceDate] datetime  NOT NULL,
    [Id] uniqueidentifier  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'TeamSet'
ALTER TABLE [dbo].[TeamSet]
ADD CONSTRAINT [PK_TeamSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'GameSet'
ALTER TABLE [dbo].[GameSet]
ADD CONSTRAINT [PK_GameSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PlayerSet'
ALTER TABLE [dbo].[PlayerSet]
ADD CONSTRAINT [PK_PlayerSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'GameAssociationTeamSet'
ALTER TABLE [dbo].[GameAssociationTeamSet]
ADD CONSTRAINT [PK_GameAssociationTeamSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [PK_UserSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProfileSet'
ALTER TABLE [dbo].[ProfileSet]
ADD CONSTRAINT [PK_ProfileSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PlayerSet_PlayerRepository'
ALTER TABLE [dbo].[PlayerSet_PlayerRepository]
ADD CONSTRAINT [PK_PlayerSet_PlayerRepository]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PlayerSet_PlayerStaging'
ALTER TABLE [dbo].[PlayerSet_PlayerStaging]
ADD CONSTRAINT [PK_PlayerSet_PlayerStaging]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [TeamId] in table 'GameAssociationTeamSet'
ALTER TABLE [dbo].[GameAssociationTeamSet]
ADD CONSTRAINT [FK_GameAssociationTeamTeam]
    FOREIGN KEY ([TeamId])
    REFERENCES [dbo].[TeamSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_GameAssociationTeamTeam'
CREATE INDEX [IX_FK_GameAssociationTeamTeam]
ON [dbo].[GameAssociationTeamSet]
    ([TeamId]);
GO

-- Creating foreign key on [GameId] in table 'GameAssociationTeamSet'
ALTER TABLE [dbo].[GameAssociationTeamSet]
ADD CONSTRAINT [FK_GameAssociationTeamGame]
    FOREIGN KEY ([GameId])
    REFERENCES [dbo].[GameSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_GameAssociationTeamGame'
CREATE INDEX [IX_FK_GameAssociationTeamGame]
ON [dbo].[GameAssociationTeamSet]
    ([GameId]);
GO

-- Creating foreign key on [PlayerId] in table 'GameAssociationTeamSet'
ALTER TABLE [dbo].[GameAssociationTeamSet]
ADD CONSTRAINT [FK_GameAssociationTeamPlayer]
    FOREIGN KEY ([PlayerId])
    REFERENCES [dbo].[PlayerSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_GameAssociationTeamPlayer'
CREATE INDEX [IX_FK_GameAssociationTeamPlayer]
ON [dbo].[GameAssociationTeamSet]
    ([PlayerId]);
GO

-- Creating foreign key on [IdProfile] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [FK_UserProfile]
    FOREIGN KEY ([IdProfile])
    REFERENCES [dbo].[ProfileSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserProfile'
CREATE INDEX [IX_FK_UserProfile]
ON [dbo].[UserSet]
    ([IdProfile]);
GO

-- Creating foreign key on [User_Id] in table 'PlayerSet'
ALTER TABLE [dbo].[PlayerSet]
ADD CONSTRAINT [FK_PlayerUser]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PlayerUser'
CREATE INDEX [IX_FK_PlayerUser]
ON [dbo].[PlayerSet]
    ([User_Id]);
GO

-- Creating foreign key on [Id] in table 'PlayerSet_PlayerRepository'
ALTER TABLE [dbo].[PlayerSet_PlayerRepository]
ADD CONSTRAINT [FK_PlayerRepository_inherits_Player]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[PlayerSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'PlayerSet_PlayerStaging'
ALTER TABLE [dbo].[PlayerSet_PlayerStaging]
ADD CONSTRAINT [FK_PlayerStaging_inherits_Player]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[PlayerSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------