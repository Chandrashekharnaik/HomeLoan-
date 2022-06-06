
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/04/2022 00:17:58
-- Generated from EDMX file: C:\Users\dss\source\repos\HomeLoan\Models\Model2.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [HomeLoanSite];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[LoanApplications]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LoanApplications];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'LoanApplications'
CREATE TABLE [dbo].[LoanApplications] (
    [LoanId] int IDENTITY(1,1) NOT NULL,
    [PropertyLocation] varchar(50)  NOT NULL,
    [PropertyName] varchar(50)  NOT NULL,
    [EstimatedCostOfProperty] decimal(19,4)  NOT NULL,
    [AmountRequired] decimal(19,4)  NOT NULL,
    [MonthlyIncome] decimal(19,4)  NOT NULL,
    [Name] varchar(50)  NOT NULL,
    [Age] int  NOT NULL,
    [DateOfBirth] datetime  NOT NULL,
    [AadharNumber] decimal(18,0)  NOT NULL,
    [PanNumber] varchar(50)  NOT NULL,
    [Verified] bit  NOT NULL,
    [Approved] bit  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [LoanId] in table 'LoanApplications'
ALTER TABLE [dbo].[LoanApplications]
ADD CONSTRAINT [PK_LoanApplications]
    PRIMARY KEY CLUSTERED ([LoanId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------