
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/16/2022 20:51:12
-- Generated from EDMX file: D:\github\FIT5032\FIT5032_ASS2\FIT5032_ASS2\Models\Appointment.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [aspnet-FIT5032_ASS2-20220916084159];
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

-- Creating table 'PatientSet'
CREATE TABLE [dbo].[PatientSet] (
    [PatientId] nvarchar(max)  NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [Age] nvarchar(max)  NOT NULL,
    [Gender] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'DoctorSet'
CREATE TABLE [dbo].[DoctorSet] (
    [DoctorId] nvarchar(max)  NOT NULL,
    [YearsOfService] nvarchar(max)  NOT NULL,
    [Category] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'BookingSet'
CREATE TABLE [dbo].[BookingSet] (
    [BookingId] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Price] nvarchar(max)  NOT NULL,
    [Available] nvarchar(max)  NOT NULL,
    [PatientPatientId] nvarchar(max)  NOT NULL,
    [DoctorDoctorId] nvarchar(max)  NOT NULL,
    [AdministratorAdministratorId] int  NOT NULL
);
GO

-- Creating table 'AdministratorSet'
CREATE TABLE [dbo].[AdministratorSet] (
    [AdministratorId] int IDENTITY(1,1) NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [PatientId] in table 'PatientSet'
ALTER TABLE [dbo].[PatientSet]
ADD CONSTRAINT [PK_PatientSet]
    PRIMARY KEY CLUSTERED ([PatientId] ASC);
GO

-- Creating primary key on [DoctorId] in table 'DoctorSet'
ALTER TABLE [dbo].[DoctorSet]
ADD CONSTRAINT [PK_DoctorSet]
    PRIMARY KEY CLUSTERED ([DoctorId] ASC);
GO

-- Creating primary key on [BookingId] in table 'BookingSet'
ALTER TABLE [dbo].[BookingSet]
ADD CONSTRAINT [PK_BookingSet]
    PRIMARY KEY CLUSTERED ([BookingId] ASC);
GO

-- Creating primary key on [AdministratorId] in table 'AdministratorSet'
ALTER TABLE [dbo].[AdministratorSet]
ADD CONSTRAINT [PK_AdministratorSet]
    PRIMARY KEY CLUSTERED ([AdministratorId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [PatientPatientId] in table 'BookingSet'
ALTER TABLE [dbo].[BookingSet]
ADD CONSTRAINT [FK_PatientBooking]
    FOREIGN KEY ([PatientPatientId])
    REFERENCES [dbo].[PatientSet]
        ([PatientId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PatientBooking'
CREATE INDEX [IX_FK_PatientBooking]
ON [dbo].[BookingSet]
    ([PatientPatientId]);
GO

-- Creating foreign key on [DoctorDoctorId] in table 'BookingSet'
ALTER TABLE [dbo].[BookingSet]
ADD CONSTRAINT [FK_DoctorBooking]
    FOREIGN KEY ([DoctorDoctorId])
    REFERENCES [dbo].[DoctorSet]
        ([DoctorId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DoctorBooking'
CREATE INDEX [IX_FK_DoctorBooking]
ON [dbo].[BookingSet]
    ([DoctorDoctorId]);
GO

-- Creating foreign key on [AdministratorAdministratorId] in table 'BookingSet'
ALTER TABLE [dbo].[BookingSet]
ADD CONSTRAINT [FK_AdministratorBooking]
    FOREIGN KEY ([AdministratorAdministratorId])
    REFERENCES [dbo].[AdministratorSet]
        ([AdministratorId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AdministratorBooking'
CREATE INDEX [IX_FK_AdministratorBooking]
ON [dbo].[BookingSet]
    ([AdministratorAdministratorId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------