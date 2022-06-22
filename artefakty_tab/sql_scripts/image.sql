CREATE TABLE [dbo].[Image] (
    [Id]                INT             IDENTITY (1, 1) NOT NULL,
    [ImageTitle]        NVARCHAR (200)  NULL,
    [ImageData]         VARBINARY (MAX) NOT NULL,
    [ImageDescription]  NVARCHAR (200)  NULL,
    [ImageSize]         INT             NULL,
    [ImageFormat]       NVARCHAR (200)  NULL,
    [ImageDateOfCreate] DATETIME        NULL, 
    CONSTRAINT [PK_Image] PRIMARY KEY ([Id])
);