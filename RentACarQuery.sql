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