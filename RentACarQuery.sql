CREATE TABLE [dbo].[Cars] (
    [CarId]       INT          NOT NULL,
    [BrandId]     INT          NULL,
    [ColorId]     INT          NULL,
    [ModelYear]   NCHAR (10)   NULL,
    [DailyPrice]  DECIMAL (18) NULL,
    [Description] NCHAR (50)   NULL,
    PRIMARY KEY CLUSTERED ([CarId] ASC), 
    CONSTRAINT [FK_Cars_Brands] FOREIGN KEY ([BrandId]) REFERENCES [Brands]([BrandId]),
	CONSTRAINT [FK_Cars_Colors] FOREIGN KEY ([ColorId]) REFERENCES [Colors]([ColorId])
);
CREATE TABLE [dbo].[Brands] (
    [BrandId]   INT        NOT NULL,
    [BrandName] NCHAR (10) NULL,
    PRIMARY KEY CLUSTERED ([BrandId] ASC)
);
CREATE TABLE [dbo].[Colors] (
    [ColorId]   INT        NOT NULL,
    [ColorName] NCHAR (10) NULL,
    PRIMARY KEY CLUSTERED ([ColorId] ASC)
);
CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [FirstName] NCHAR(10) NULL, 
    [LastName] NCHAR(10) NULL, 
    [Email] NCHAR(20) NULL, 
    [Password] NCHAR(15) NULL
);
CREATE TABLE [dbo].[Customers]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [UserId] INT NULL, 
    [CompanyName] NCHAR(15) NULL, 
    CONSTRAINT [FK_Customers_Users] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id]) 
);
CREATE TABLE [dbo].[Rentals]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [CarId] INT NULL, 
    [CustomerId] INT NULL, 
    [RentDate] DATETIME NULL, 
    [ReturnDate] DATETIME NOT NULL, 
    CONSTRAINT [FK_Rentals_Cars] FOREIGN KEY ([CarId]) REFERENCES [Cars]([CarId]), 
    CONSTRAINT [FK_Rentals_Customers] FOREIGN KEY ([CustomerId]) REFERENCES [Customers]([Id])
);
CREATE TABLE [dbo].[CarImages] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [CarId]     INT            NULL,
    [ImagePath] NVARCHAR (MAX) NULL,
    [Date]      DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CarImages_Cars] FOREIGN KEY ([CarId]) REFERENCES [dbo].[Cars] ([CarId])
);