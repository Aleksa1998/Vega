﻿/*
Deployment script for TimeSheetDB

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "TimeSheetDB"
:setvar DefaultFilePrefix "TimeSheetDB"
:setvar DefaultDataPath "C:\Users\Aleksa\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"
:setvar DefaultLogPath "C:\Users\Aleksa\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Creating [dbo].[Category]...';


GO
CREATE TABLE [dbo].[Category] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Client]...';


GO
CREATE TABLE [dbo].[Client] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (50) NOT NULL,
    [City]       NVARCHAR (50) NOT NULL,
    [Address]    NVARCHAR (50) NOT NULL,
    [PostalCode] NCHAR (5)     NOT NULL,
    [CountryId]  INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Country]...';


GO
CREATE TABLE [dbo].[Country] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Employee]...';


GO
CREATE TABLE [dbo].[Employee] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (50) NOT NULL,
    [Username]     NVARCHAR (50) NOT NULL,
    [Password]     NVARCHAR (50) NOT NULL,
    [IsActive]     BIT           NOT NULL,
    [Email]        NVARCHAR (50) NULL,
    [HoursPerWeek] FLOAT (53)    NOT NULL,
    [Role]         INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Lead]...';


GO
CREATE TABLE [dbo].[Lead] (
    [Id]         INT IDENTITY (1, 1) NOT NULL,
    [EmployeeId] INT NOT NULL,
    [ProjectId]  INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Project]...';


GO
CREATE TABLE [dbo].[Project] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (50) NOT NULL,
    [Description] NVARCHAR (50) NULL,
    [Status]      INT           NULL,
    [ClientId]    INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[TimeSheet]...';


GO
CREATE TABLE [dbo].[TimeSheet] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Date]        DATETIME      NOT NULL,
    [Description] NVARCHAR (50) NULL,
    [Time]        FLOAT (53)    NOT NULL,
    [Overtime]    FLOAT (53)    NOT NULL,
    [EmployeeId]  INT           NOT NULL,
    [ClientId]    INT           NOT NULL,
    [ProjectId]   INT           NOT NULL,
    [CategoryId]  INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[WorkingRelationships]...';


GO
CREATE TABLE [dbo].[WorkingRelationships] (
    [Id]         INT IDENTITY (1, 1) NOT NULL,
    [ProjectId]  INT NOT NULL,
    [EmployeeId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Update complete.';


GO