USE [master]
GO
/****** Object:  Database [UserManagementDB]    Script Date: 2025/06/08 19:49:23 ******/
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'UserManagementDB')
BEGIN
CREATE DATABASE [UserManagementDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UserManagementDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\UserManagementDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'UserManagementDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\UserManagementDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
END
GO
ALTER DATABASE [UserManagementDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UserManagementDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UserManagementDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UserManagementDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UserManagementDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UserManagementDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UserManagementDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [UserManagementDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UserManagementDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UserManagementDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UserManagementDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UserManagementDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UserManagementDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UserManagementDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UserManagementDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UserManagementDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UserManagementDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [UserManagementDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UserManagementDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UserManagementDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UserManagementDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UserManagementDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UserManagementDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [UserManagementDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UserManagementDB] SET RECOVERY FULL 
GO
ALTER DATABASE [UserManagementDB] SET  MULTI_USER 
GO
ALTER DATABASE [UserManagementDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UserManagementDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UserManagementDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UserManagementDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [UserManagementDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [UserManagementDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'UserManagementDB', N'ON'
GO
ALTER DATABASE [UserManagementDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [UserManagementDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [UserManagementDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2025/06/08 19:49:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[__EFMigrationsHistory]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Groups]    Script Date: 2025/06/08 19:49:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Groups]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Groups](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Groups] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[GroupUser]    Script Date: 2025/06/08 19:49:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GroupUser]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[GroupUser](
	[GroupsId] [int] NOT NULL,
	[UsersId] [int] NOT NULL,
 CONSTRAINT [PK_GroupUser] PRIMARY KEY CLUSTERED 
(
	[GroupsId] ASC,
	[UsersId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Permissions]    Script Date: 2025/06/08 19:49:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Permissions]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Permissions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[GroupId] [int] NOT NULL,
 CONSTRAINT [PK_Permissions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2025/06/08 19:49:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Surname] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[ContactNumber] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250608142414_init', N'8.0.0')
GO
SET IDENTITY_INSERT [dbo].[Groups] ON 

INSERT [dbo].[Groups] ([Id], [Name], [Description]) VALUES (1, N'Third part cover Group', N'The most basic level of coverage, focusing on protecting you from legal liability if you cause damage to another person''s vehicle')
INSERT [dbo].[Groups] ([Id], [Name], [Description]) VALUES (2, N'Comprehensive cover Group', N'The most extensive protection, covering various risks like accidents, theft, vandalism, fire, and natural disasters, as well as third-party liability')
SET IDENTITY_INSERT [dbo].[Groups] OFF
GO
INSERT [dbo].[GroupUser] ([GroupsId], [UsersId]) VALUES (1, 1)
INSERT [dbo].[GroupUser] ([GroupsId], [UsersId]) VALUES (1, 2)
INSERT [dbo].[GroupUser] ([GroupsId], [UsersId]) VALUES (1, 3)
INSERT [dbo].[GroupUser] ([GroupsId], [UsersId]) VALUES (2, 4)
GO
SET IDENTITY_INSERT [dbo].[Permissions] ON 

INSERT [dbo].[Permissions] ([Id], [Name], [Description], [GroupId]) VALUES (1, N'Level 1', N'Level 1', 1)
INSERT [dbo].[Permissions] ([Id], [Name], [Description], [GroupId]) VALUES (2, N'Level 2', N'Level 2', 1)
INSERT [dbo].[Permissions] ([Id], [Name], [Description], [GroupId]) VALUES (3, N'Level 3', N'Level 3', 2)
SET IDENTITY_INSERT [dbo].[Permissions] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Name], [Surname], [Email], [ContactNumber]) VALUES (1, N'Wilson', N'Zulu', N'wilsonzulu10@gmail.com', N'0785005991')
INSERT [dbo].[Users] ([Id], [Name], [Surname], [Email], [ContactNumber]) VALUES (2, N'Brian', N'Tlean', N'Tlean@gmail.com', N'0885005991')
INSERT [dbo].[Users] ([Id], [Name], [Surname], [Email], [ContactNumber]) VALUES (3, N'Mpeke', N'Mathebula', N'Mathebula@gmail.com', N'0*85005991')
INSERT [dbo].[Users] ([Id], [Name], [Surname], [Email], [ContactNumber]) VALUES (4, N'Abram', N'Mmako', N'abramchesammako@gmail.com', N'0799610258')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
/****** Object:  Index [IX_GroupUser_UsersId]    Script Date: 2025/06/08 19:49:24 ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[GroupUser]') AND name = N'IX_GroupUser_UsersId')
CREATE NONCLUSTERED INDEX [IX_GroupUser_UsersId] ON [dbo].[GroupUser]
(
	[UsersId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Permissions_GroupId]    Script Date: 2025/06/08 19:49:24 ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Permissions]') AND name = N'IX_Permissions_GroupId')
CREATE NONCLUSTERED INDEX [IX_Permissions_GroupId] ON [dbo].[Permissions]
(
	[GroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_GroupUser_Groups_GroupsId]') AND parent_object_id = OBJECT_ID(N'[dbo].[GroupUser]'))
ALTER TABLE [dbo].[GroupUser]  WITH CHECK ADD  CONSTRAINT [FK_GroupUser_Groups_GroupsId] FOREIGN KEY([GroupsId])
REFERENCES [dbo].[Groups] ([Id])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_GroupUser_Groups_GroupsId]') AND parent_object_id = OBJECT_ID(N'[dbo].[GroupUser]'))
ALTER TABLE [dbo].[GroupUser] CHECK CONSTRAINT [FK_GroupUser_Groups_GroupsId]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_GroupUser_Users_UsersId]') AND parent_object_id = OBJECT_ID(N'[dbo].[GroupUser]'))
ALTER TABLE [dbo].[GroupUser]  WITH CHECK ADD  CONSTRAINT [FK_GroupUser_Users_UsersId] FOREIGN KEY([UsersId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_GroupUser_Users_UsersId]') AND parent_object_id = OBJECT_ID(N'[dbo].[GroupUser]'))
ALTER TABLE [dbo].[GroupUser] CHECK CONSTRAINT [FK_GroupUser_Users_UsersId]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Permissions_Groups_GroupId]') AND parent_object_id = OBJECT_ID(N'[dbo].[Permissions]'))
ALTER TABLE [dbo].[Permissions]  WITH CHECK ADD  CONSTRAINT [FK_Permissions_Groups_GroupId] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([Id])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Permissions_Groups_GroupId]') AND parent_object_id = OBJECT_ID(N'[dbo].[Permissions]'))
ALTER TABLE [dbo].[Permissions] CHECK CONSTRAINT [FK_Permissions_Groups_GroupId]
GO
USE [master]
GO
ALTER DATABASE [UserManagementDB] SET  READ_WRITE 
GO
