CREATE TABLE [dbo].[Category] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [CategoryName] NVARCHAR (200) NULL, 
    CONSTRAINT [PK_Category] PRIMARY KEY ([Id])
);