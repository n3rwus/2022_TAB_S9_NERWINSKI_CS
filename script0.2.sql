USE [master]
GO
/****** Object:  Database [TAB_DB]    Script Date: 24.06.2022 14:56:19 ******/
CREATE DATABASE [TAB_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TAB_DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\TAB_DB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TAB_DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\TAB_DB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TAB_DB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TAB_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TAB_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TAB_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TAB_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TAB_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TAB_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [TAB_DB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [TAB_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TAB_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TAB_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TAB_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TAB_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TAB_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TAB_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TAB_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TAB_DB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [TAB_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TAB_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TAB_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TAB_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TAB_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TAB_DB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [TAB_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TAB_DB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TAB_DB] SET  MULTI_USER 
GO
ALTER DATABASE [TAB_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TAB_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TAB_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TAB_DB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TAB_DB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TAB_DB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [TAB_DB] SET QUERY_STORE = OFF
GO
USE [TAB_DB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 24.06.2022 14:56:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 24.06.2022 14:56:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [text] NULL,
	[Email] [text] NULL,
	[PasswordHash] [text] NULL,
	[AcceptTerms] [bit] NOT NULL,
	[Role] [int] NOT NULL,
	[VerificationToken] [text] NULL,
	[Verified] [text] NULL,
	[ResetToken] [text] NULL,
	[ResetTokenExpires] [text] NULL,
	[PasswordReset] [text] NULL,
	[Created] [text] NOT NULL,
	[Updated] [text] NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 24.06.2022 14:56:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](200) NULL,
	[AccountId] [int] NULL,
	[ImageId] [int] NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Folder]    Script Date: 24.06.2022 14:56:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Folder](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FolderName] [text] NOT NULL,
	[FolderDescription] [text] NULL,
	[ParentFolderId] [int] NULL,
	[AccountId] [int] NULL,
 CONSTRAINT [PK_Folder] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Image]    Script Date: 24.06.2022 14:56:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Image](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ImageTitle] [nvarchar](200) NULL,
	[ImageData] [varbinary](max) NOT NULL,
	[ImageDescription] [nvarchar](200) NULL,
	[ImageSize] [int] NULL,
	[ImageFormat] [nvarchar](200) NULL,
	[ImageDateOfCreate] [datetime] NULL,
	[AccountId] [int] NULL,
	[FolderId] [int] NULL,
	[CategoryId] [int] NULL,
 CONSTRAINT [PK_Image] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ImageCategory]    Script Date: 24.06.2022 14:56:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImageCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ImageId] [int] NULL,
	[CategoryId] [int] NULL,
 CONSTRAINT [PK_ImageCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RefreshToken]    Script Date: 24.06.2022 14:56:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RefreshToken](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Token] [text] NULL,
	[Expires] [text] NOT NULL,
	[Created] [text] NOT NULL,
	[CreatedByIp] [text] NULL,
	[Revoked] [text] NULL,
	[RevokedByIp] [text] NULL,
	[ReplacedByToken] [text] NULL,
	[ReasonRevoked] [text] NULL,
	[AccountId] [int] NOT NULL,
 CONSTRAINT [PK_RefreshToken] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_Category_AccountId]    Script Date: 24.06.2022 14:56:19 ******/
CREATE NONCLUSTERED INDEX [IX_Category_AccountId] ON [dbo].[Category]
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Folder_AccountId]    Script Date: 24.06.2022 14:56:19 ******/
CREATE NONCLUSTERED INDEX [IX_Folder_AccountId] ON [dbo].[Folder]
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Folder_ParentFolderId]    Script Date: 24.06.2022 14:56:19 ******/
CREATE NONCLUSTERED INDEX [IX_Folder_ParentFolderId] ON [dbo].[Folder]
(
	[ParentFolderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Image_AccountId]    Script Date: 24.06.2022 14:56:19 ******/
CREATE NONCLUSTERED INDEX [IX_Image_AccountId] ON [dbo].[Image]
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Image_FolderId]    Script Date: 24.06.2022 14:56:19 ******/
CREATE NONCLUSTERED INDEX [IX_Image_FolderId] ON [dbo].[Image]
(
	[FolderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ImageCategory_CategoryId]    Script Date: 24.06.2022 14:56:19 ******/
CREATE NONCLUSTERED INDEX [IX_ImageCategory_CategoryId] ON [dbo].[ImageCategory]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ImageCategory_ImageId]    Script Date: 24.06.2022 14:56:19 ******/
CREATE NONCLUSTERED INDEX [IX_ImageCategory_ImageId] ON [dbo].[ImageCategory]
(
	[ImageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_RefreshToken_AccountId]    Script Date: 24.06.2022 14:56:19 ******/
CREATE NONCLUSTERED INDEX [IX_RefreshToken_AccountId] ON [dbo].[RefreshToken]
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Category]  WITH CHECK ADD  CONSTRAINT [FK_Category_Account] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([Id])
GO
ALTER TABLE [dbo].[Category] CHECK CONSTRAINT [FK_Category_Account]
GO
ALTER TABLE [dbo].[Folder]  WITH CHECK ADD  CONSTRAINT [FK_Folder_Account] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([Id])
GO
ALTER TABLE [dbo].[Folder] CHECK CONSTRAINT [FK_Folder_Account]
GO
ALTER TABLE [dbo].[Folder]  WITH CHECK ADD  CONSTRAINT [FK_Folder_ParentFolder] FOREIGN KEY([ParentFolderId])
REFERENCES [dbo].[Folder] ([Id])
GO
ALTER TABLE [dbo].[Folder] CHECK CONSTRAINT [FK_Folder_ParentFolder]
GO
ALTER TABLE [dbo].[Image]  WITH CHECK ADD  CONSTRAINT [FK_Image_Account] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([Id])
GO
ALTER TABLE [dbo].[Image] CHECK CONSTRAINT [FK_Image_Account]
GO
ALTER TABLE [dbo].[Image]  WITH CHECK ADD  CONSTRAINT [FK_Image_Folder] FOREIGN KEY([FolderId])
REFERENCES [dbo].[Folder] ([Id])
GO
ALTER TABLE [dbo].[Image] CHECK CONSTRAINT [FK_Image_Folder]
GO
ALTER TABLE [dbo].[ImageCategory]  WITH CHECK ADD  CONSTRAINT [FK_ImageCategory_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[ImageCategory] CHECK CONSTRAINT [FK_ImageCategory_Category]
GO
ALTER TABLE [dbo].[ImageCategory]  WITH CHECK ADD  CONSTRAINT [FK_ImageCategory_Image] FOREIGN KEY([ImageId])
REFERENCES [dbo].[Image] ([Id])
GO
ALTER TABLE [dbo].[ImageCategory] CHECK CONSTRAINT [FK_ImageCategory_Image]
GO
ALTER TABLE [dbo].[RefreshToken]  WITH CHECK ADD  CONSTRAINT [FK__RefreshTo__Accou__2645B050] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([Id])
GO
ALTER TABLE [dbo].[RefreshToken] CHECK CONSTRAINT [FK__RefreshTo__Accou__2645B050]
GO
USE [master]
GO
ALTER DATABASE [TAB_DB] SET  READ_WRITE 
GO
