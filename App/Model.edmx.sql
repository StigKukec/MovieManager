
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/24/2024 02:26:45
-- Generated from EDMX file: C:\Users\natio\OneDrive\Dokumenti\Stig_Kukec_Algebra\Pristup podacima iz programskog koda\framework mvc\App\App\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Movie_database];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Movies'
CREATE TABLE [dbo].[Movies] (
    [IDMovie] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(95)  NOT NULL,
    [Description] nvarchar(3000)  NOT NULL,
    [TotalTime] int  NOT NULL,
    [DirectorIDDirector] int  NOT NULL
);
GO

-- Creating table 'Genres'
CREATE TABLE [dbo].[Genres] (
    [IDGenre] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(80)  NOT NULL,
    [Description] nvarchar(1500)  NOT NULL
);
GO

-- Creating table 'Actors'
CREATE TABLE [dbo].[Actors] (
    [IDActor] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(75)  NOT NULL,
    [LastName] nvarchar(75)  NOT NULL
);
GO

-- Creating table 'Directors'
CREATE TABLE [dbo].[Directors] (
    [IDDirector] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(75)  NOT NULL,
    [LastName] nvarchar(75)  NOT NULL
);
GO

-- Creating table 'UploadedPosters'
CREATE TABLE [dbo].[UploadedPosters] (
    [IDUploadedPoster] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(65)  NOT NULL,
    [ContentType] nvarchar(50)  NOT NULL,
    [Content] varbinary(max)  NOT NULL,
    [MovieIDMovie] int  NOT NULL
);
GO

-- Creating table 'MovieGenre'
CREATE TABLE [dbo].[MovieGenre] (
    [Movies_IDMovie] int  NOT NULL,
    [Genres_IDGenre] int  NOT NULL
);
GO

-- Creating table 'MovieActor'
CREATE TABLE [dbo].[MovieActor] (
    [Movies_IDMovie] int  NOT NULL,
    [Actors_IDActor] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IDMovie] in table 'Movies'
ALTER TABLE [dbo].[Movies]
ADD CONSTRAINT [PK_Movies]
    PRIMARY KEY CLUSTERED ([IDMovie] ASC);
GO

-- Creating primary key on [IDGenre] in table 'Genres'
ALTER TABLE [dbo].[Genres]
ADD CONSTRAINT [PK_Genres]
    PRIMARY KEY CLUSTERED ([IDGenre] ASC);
GO

-- Creating primary key on [IDActor] in table 'Actors'
ALTER TABLE [dbo].[Actors]
ADD CONSTRAINT [PK_Actors]
    PRIMARY KEY CLUSTERED ([IDActor] ASC);
GO

-- Creating primary key on [IDDirector] in table 'Directors'
ALTER TABLE [dbo].[Directors]
ADD CONSTRAINT [PK_Directors]
    PRIMARY KEY CLUSTERED ([IDDirector] ASC);
GO

-- Creating primary key on [IDUploadedPoster] in table 'UploadedPosters'
ALTER TABLE [dbo].[UploadedPosters]
ADD CONSTRAINT [PK_UploadedPosters]
    PRIMARY KEY CLUSTERED ([IDUploadedPoster] ASC);
GO

-- Creating primary key on [Movies_IDMovie], [Genres_IDGenre] in table 'MovieGenre'
ALTER TABLE [dbo].[MovieGenre]
ADD CONSTRAINT [PK_MovieGenre]
    PRIMARY KEY CLUSTERED ([Movies_IDMovie], [Genres_IDGenre] ASC);
GO

-- Creating primary key on [Movies_IDMovie], [Actors_IDActor] in table 'MovieActor'
ALTER TABLE [dbo].[MovieActor]
ADD CONSTRAINT [PK_MovieActor]
    PRIMARY KEY CLUSTERED ([Movies_IDMovie], [Actors_IDActor] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [DirectorIDDirector] in table 'Movies'
ALTER TABLE [dbo].[Movies]
ADD CONSTRAINT [FK_MovieDirector]
    FOREIGN KEY ([DirectorIDDirector])
    REFERENCES [dbo].[Directors]
        ([IDDirector])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MovieDirector'
CREATE INDEX [IX_FK_MovieDirector]
ON [dbo].[Movies]
    ([DirectorIDDirector]);
GO

-- Creating foreign key on [Movies_IDMovie] in table 'MovieGenre'
ALTER TABLE [dbo].[MovieGenre]
ADD CONSTRAINT [FK_MovieGenre_Movie]
    FOREIGN KEY ([Movies_IDMovie])
    REFERENCES [dbo].[Movies]
        ([IDMovie])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Genres_IDGenre] in table 'MovieGenre'
ALTER TABLE [dbo].[MovieGenre]
ADD CONSTRAINT [FK_MovieGenre_Genre]
    FOREIGN KEY ([Genres_IDGenre])
    REFERENCES [dbo].[Genres]
        ([IDGenre])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MovieGenre_Genre'
CREATE INDEX [IX_FK_MovieGenre_Genre]
ON [dbo].[MovieGenre]
    ([Genres_IDGenre]);
GO

-- Creating foreign key on [Movies_IDMovie] in table 'MovieActor'
ALTER TABLE [dbo].[MovieActor]
ADD CONSTRAINT [FK_MovieActor_Movie]
    FOREIGN KEY ([Movies_IDMovie])
    REFERENCES [dbo].[Movies]
        ([IDMovie])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Actors_IDActor] in table 'MovieActor'
ALTER TABLE [dbo].[MovieActor]
ADD CONSTRAINT [FK_MovieActor_Actor]
    FOREIGN KEY ([Actors_IDActor])
    REFERENCES [dbo].[Actors]
        ([IDActor])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MovieActor_Actor'
CREATE INDEX [IX_FK_MovieActor_Actor]
ON [dbo].[MovieActor]
    ([Actors_IDActor]);
GO

-- Creating foreign key on [MovieIDMovie] in table 'UploadedPosters'
ALTER TABLE [dbo].[UploadedPosters]
ADD CONSTRAINT [FK_MovieUploadedPoster]
    FOREIGN KEY ([MovieIDMovie])
    REFERENCES [dbo].[Movies]
        ([IDMovie])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MovieUploadedPoster'
CREATE INDEX [IX_FK_MovieUploadedPoster]
ON [dbo].[UploadedPosters]
    ([MovieIDMovie]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------