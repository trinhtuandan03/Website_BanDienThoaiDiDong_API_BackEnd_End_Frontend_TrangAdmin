USE [master]
GO
/****** Object:  Database [DoAnCuoiKiNhom3BanDienThoaiDiDongAPI]    Script Date: 06/03/2025 01:19:29 ******/
CREATE DATABASE [DoAnCuoiKiNhom3BanDienThoaiDiDongAPI]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DoAnCuoiKiNhom3BanDienThoaiDiDongAPI', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\DoAnCuoiKiNhom3BanDienThoaiDiDongAPI.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DoAnCuoiKiNhom3BanDienThoaiDiDongAPI_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\DoAnCuoiKiNhom3BanDienThoaiDiDongAPI_log.ldf' , SIZE = 816KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DoAnCuoiKiNhom3BanDienThoaiDiDongAPI] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DoAnCuoiKiNhom3BanDienThoaiDiDongAPI].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DoAnCuoiKiNhom3BanDienThoaiDiDongAPI] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DoAnCuoiKiNhom3BanDienThoaiDiDongAPI] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DoAnCuoiKiNhom3BanDienThoaiDiDongAPI] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DoAnCuoiKiNhom3BanDienThoaiDiDongAPI] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DoAnCuoiKiNhom3BanDienThoaiDiDongAPI] SET ARITHABORT OFF 
GO
ALTER DATABASE [DoAnCuoiKiNhom3BanDienThoaiDiDongAPI] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DoAnCuoiKiNhom3BanDienThoaiDiDongAPI] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DoAnCuoiKiNhom3BanDienThoaiDiDongAPI] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DoAnCuoiKiNhom3BanDienThoaiDiDongAPI] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DoAnCuoiKiNhom3BanDienThoaiDiDongAPI] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DoAnCuoiKiNhom3BanDienThoaiDiDongAPI] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DoAnCuoiKiNhom3BanDienThoaiDiDongAPI] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DoAnCuoiKiNhom3BanDienThoaiDiDongAPI] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DoAnCuoiKiNhom3BanDienThoaiDiDongAPI] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DoAnCuoiKiNhom3BanDienThoaiDiDongAPI] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DoAnCuoiKiNhom3BanDienThoaiDiDongAPI] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DoAnCuoiKiNhom3BanDienThoaiDiDongAPI] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DoAnCuoiKiNhom3BanDienThoaiDiDongAPI] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DoAnCuoiKiNhom3BanDienThoaiDiDongAPI] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DoAnCuoiKiNhom3BanDienThoaiDiDongAPI] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DoAnCuoiKiNhom3BanDienThoaiDiDongAPI] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [DoAnCuoiKiNhom3BanDienThoaiDiDongAPI] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DoAnCuoiKiNhom3BanDienThoaiDiDongAPI] SET RECOVERY FULL 
GO
ALTER DATABASE [DoAnCuoiKiNhom3BanDienThoaiDiDongAPI] SET  MULTI_USER 
GO
ALTER DATABASE [DoAnCuoiKiNhom3BanDienThoaiDiDongAPI] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DoAnCuoiKiNhom3BanDienThoaiDiDongAPI] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DoAnCuoiKiNhom3BanDienThoaiDiDongAPI] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DoAnCuoiKiNhom3BanDienThoaiDiDongAPI] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [DoAnCuoiKiNhom3BanDienThoaiDiDongAPI] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'DoAnCuoiKiNhom3BanDienThoaiDiDongAPI', N'ON'
GO
USE [DoAnCuoiKiNhom3BanDienThoaiDiDongAPI]
GO
/****** Object:  Schema [identity]    Script Date: 06/03/2025 01:19:29 ******/
CREATE SCHEMA [identity]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 06/03/2025 01:19:29 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [identity].[AspNetRoleClaims]    Script Date: 06/03/2025 01:19:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [identity].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [identity].[AspNetRoles]    Script Date: 06/03/2025 01:19:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [identity].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [identity].[AspNetUserClaims]    Script Date: 06/03/2025 01:19:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [identity].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [identity].[AspNetUserLogins]    Script Date: 06/03/2025 01:19:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [identity].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [identity].[AspNetUserRoles]    Script Date: 06/03/2025 01:19:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [identity].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [identity].[AspNetUsers]    Script Date: 06/03/2025 01:19:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [identity].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[Initials] [nvarchar](5) NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [identity].[AspNetUserTokens]    Script Date: 06/03/2025 01:19:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [identity].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [identity].[Blogs]    Script Date: 06/03/2025 01:19:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [identity].[Blogs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Content] [nvarchar](max) NULL,
	[AuthorId] [nvarchar](450) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ImageUrl] [nvarchar](max) NULL,
	[Category] [nvarchar](max) NULL,
 CONSTRAINT [PK_Blogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [identity].[CartDetails]    Script Date: 06/03/2025 01:19:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [identity].[CartDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CartId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_CartDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [identity].[Carts]    Script Date: 06/03/2025 01:19:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [identity].[Carts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[PaymentMethod] [nvarchar](max) NULL,
 CONSTRAINT [PK_Carts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [identity].[Categorys]    Script Date: 06/03/2025 01:19:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [identity].[Categorys](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Categorys] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [identity].[OrderDetails]    Script Date: 06/03/2025 01:19:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [identity].[OrderDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [identity].[Orders]    Script Date: 06/03/2025 01:19:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [identity].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[OrderDate] [datetime2](7) NOT NULL,
	[OrderStatus] [nvarchar](max) NOT NULL,
	[TotalPrice] [decimal](18, 2) NOT NULL,
	[PaymentMethod] [nvarchar](max) NOT NULL,
	[ShippingAddress] [nvarchar](max) NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [identity].[OtpRecords]    Script Date: 06/03/2025 01:19:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [identity].[OtpRecords](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PhoneNumber] [nvarchar](max) NOT NULL,
	[Otp] [nvarchar](max) NOT NULL,
	[Expiry] [datetime2](7) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_OtpRecords] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [identity].[Products]    Script Date: 06/03/2025 01:19:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [identity].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Image1] [nvarchar](max) NULL,
	[Image2] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[CategoryId] [int] NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250107121258_Update', N'9.0.0')
INSERT [identity].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'b2e12996-4894-48a0-a901-66e07cec8383', N'Us', N'US', NULL)
INSERT [identity].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'd713b2e0-4f46-4a55-992c-0c76e62d366b', N'Admin', N'ADMIN', NULL)
INSERT [identity].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'ee2aeb6d-9685-459e-80bf-2387339b2577', N'User', N'USER', NULL)
INSERT [identity].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'097a2b84-df16-4ba6-bc39-4402b20b5e65', N'b2e12996-4894-48a0-a901-66e07cec8383')
INSERT [identity].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd168d47f-7acb-484c-8519-3e50c3d1f918', N'd713b2e0-4f46-4a55-992c-0c76e62d366b')
INSERT [identity].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'23db265e-7423-466a-9bcd-cc495d0d32a5', N'ee2aeb6d-9685-459e-80bf-2387339b2577')
INSERT [identity].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5060e869-f6d1-45b1-9180-1b5919b00c24', N'ee2aeb6d-9685-459e-80bf-2387339b2577')
INSERT [identity].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f67952a4-d58e-4288-b189-d659d600cfb1', N'ee2aeb6d-9685-459e-80bf-2387339b2577')
INSERT [identity].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f9e23c65-95fc-4156-9386-57a71a480304', N'ee2aeb6d-9685-459e-80bf-2387339b2577')
INSERT [identity].[AspNetUsers] ([Id], [Initials], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'097a2b84-df16-4ba6-bc39-4402b20b5e65', N'K1@', N'khanh', N'KHANH', N'khanh1@gmail.com', N'KHANH1@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEJuFE/2v92vF71xd/q359l9fMxQ5cXE6oQKqgKe8HDPVeaN2zutH76FASABnXZBlAA==', N'4TKLROCKBM4RYKC4C5XHO2N4PA53MRC3', N'50748826-9e14-4279-ad40-c6ffc9e1304a', N'1234567890', 0, 0, NULL, 1, 0)
INSERT [identity].[AspNetUsers] ([Id], [Initials], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'23db265e-7423-466a-9bcd-cc495d0d32a5', N'N1@', N'duc', N'DUC', N'duc1@gmail.com', N'DUC1@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEBxFxexjpXgDpo5/aahJttiMng66KQI3nTiavWJhebQ/gHMvWx1/nwy9zpPRj6XDFA==', N'ZWYXEPQYMY52FJP743QREJNJOWKBSDEA', N'6da95869-a68a-4832-a322-7a4a1a0d489f', N'0384414936', 0, 0, NULL, 1, 0)
INSERT [identity].[AspNetUsers] ([Id], [Initials], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'5060e869-f6d1-45b1-9180-1b5919b00c24', N'dan2', N'tuandan2', N'TUANDAN2', N'tuandan2@gmail.com', N'TUANDAN2@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEPtzanJKv5Yg99n1VtF9Aw7ehZLvJN3O28DAFjmsmuOj534F8XWuPlcJGkAJ4ksxXQ==', N'6ALURB3OBMRCK5YLXQ4H54J73PRRAWZN', N'27296fc2-289c-4553-b83f-7966770e925c', N'0336656538', 0, 0, NULL, 1, 0)
INSERT [identity].[AspNetUsers] ([Id], [Initials], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'd168d47f-7acb-484c-8519-3e50c3d1f918', N'dan1', N'tuandan1', N'TUANDAN1', N'tuandan1@gmail.com', N'TUANDAN1@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEA7i2BZE+QHFWPUeYBO9/Xx/Kps5BdKnuweQaVnezXJfP0u5OH6P8ecahV2tEtCzIQ==', N'XYEKGFBNX4H7P5YZ7QJBVTOASOX5OPWY', N'ce98ffa1-a050-47c7-840c-3e7bd1f88559', N'0336656538', 0, 0, NULL, 1, 0)
INSERT [identity].[AspNetUsers] ([Id], [Initials], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'f67952a4-d58e-4288-b189-d659d600cfb1', N'N2@', N'duc2', N'DUC2', N'duc2@gmail.com', N'DUC2@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAELGJLg2nnUpDQ4wdAxjxzwalnldagj+5fV05kOE3ToubOyYdxj5K1N+764rDjo5yog==', N'6626QG2CC3MTVGAALO4CBY7L2YQ25AVY', N'4cb1bf3a-af7f-42cc-ad53-c1343bccfb6c', N'0384474676', 0, 0, NULL, 1, 0)
INSERT [identity].[AspNetUsers] ([Id], [Initials], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'f9e23c65-95fc-4156-9386-57a71a480304', N'H24', N'hien24', N'HIEN24', N'hien24@gmail.com', N'HIEN24@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEDT4vFcBSD9Eboxbhi9Z+1Ce52RDITHhoq/y/ZoBh6fD/3NMr0HzEc3q9ZLTruqbZw==', N'LOSGJVKWOQULV3PLBWUJQS7ADJXHT4P7', N'67464327-852a-4eff-b11a-c92f725ae9e9', N'0919078540', 0, 0, NULL, 1, 0)
SET IDENTITY_INSERT [identity].[Blogs] ON 

INSERT [identity].[Blogs] ([Id], [Title], [Content], [AuthorId], [CreatedAt], [ImageUrl], [Category]) VALUES (5, N'Galaxy S25 và S25 Plus có tính năng gì mới? Khi nào ra mắt và giá bao nhiêu?', N'Ở thời điểm hiện tại, nhờ các tin đồn và rò rỉ mà chúng ta đã có được bức tranh tương đối hoàn chỉnh về bộ đôi flagship tiếp theo đến từ Samsung là Galaxy S25 và Galaxy S25 Plus.', N'd168d47f-7acb-484c-8519-3e50c3d1f918', CAST(N'2025-01-09 00:41:57.9310057' AS DateTime2), N'https://cdn-media.sforum.vn/storage/app/media/trannghia/thong-tin-Galaxy-S25-S25-Plus-cover.jpg', N'Chia Sẻ')
INSERT [identity].[Blogs] ([Id], [Title], [Content], [AuthorId], [CreatedAt], [ImageUrl], [Category]) VALUES (6, N'Nguyên nhân và cách khắc phục lỗi không quét được CCCD để xác thực sinh trắc học? ', N'Trong thời gian gần đây, các ngân hàng đã yêu cầu người dùng cập nhật thông sinh trắc học để đảm bảo an toàn cho tài khoản. Tuy nhiên, nhiều người gặp khó khăn khi không quét được CCCD để xác thực sinh trắc học qua NFC. Nguyên nhân và cách khắc phục như thế nào?', N'd168d47f-7acb-484c-8519-3e50c3d1f918', CAST(N'2025-01-09 00:42:03.7764670' AS DateTime2), N'https://cdn-media.sforum.vn/storage/app/media/nhuy/Nhu-Y/khong-quet-duoc-cccd-de-xac-thuc-sinh-trac-hoc-2.jpg', N'Chia Sẻ')
INSERT [identity].[Blogs] ([Id], [Title], [Content], [AuthorId], [CreatedAt], [ImageUrl], [Category]) VALUES (7, N'Galaxy S25 và S25 Plus có tính năng gì mới? Khi nào ra mắt và giá bao nhiêu?', N'Ở thời điểm hiện tại, nhờ các tin đồn và rò rỉ mà chúng ta đã có được bức tranh tương đối hoàn chỉnh về bộ đôi flagship tiếp theo đến từ Samsung là Galaxy S25 và Galaxy S25 Plus.', N'd168d47f-7acb-484c-8519-3e50c3d1f918', CAST(N'2025-01-09 00:42:07.8247142' AS DateTime2), N'https://cdn-media.sforum.vn/storage/app/media/trannghia/thong-tin-Galaxy-S25-S25-Plus-cover.jpg', N'Chia Sẻ')
INSERT [identity].[Blogs] ([Id], [Title], [Content], [AuthorId], [CreatedAt], [ImageUrl], [Category]) VALUES (8, N'Nguyên nhân và cách khắc phục lỗi không quét được CCCD để xác thực sinh trắc học? ', N'Trong thời gian gần đây, các ngân hàng đã yêu cầu người dùng cập nhật thông sinh trắc học để đảm bảo an toàn cho tài khoản. Tuy nhiên, nhiều người gặp khó khăn khi không quét được CCCD để xác thực sinh trắc học qua NFC. Nguyên nhân và cách khắc phục như thế nào?', N'd168d47f-7acb-484c-8519-3e50c3d1f918', CAST(N'2025-01-09 00:42:15.4263262' AS DateTime2), N'https://cdn-media.sforum.vn/storage/app/media/nhuy/Nhu-Y/khong-quet-duoc-cccd-de-xac-thuc-sinh-trac-hoc-2.jpg', N'Chia Sẻ')
INSERT [identity].[Blogs] ([Id], [Title], [Content], [AuthorId], [CreatedAt], [ImageUrl], [Category]) VALUES (9, N'Galaxy S25 và S25 Plus có tính năng gì mới? Khi nào ra mắt và giá bao nhiêu?', N'Ở thời điểm hiện tại, nhờ các tin đồn và rò rỉ mà chúng ta đã có được bức tranh tương đối hoàn chỉnh về bộ đôi flagship tiếp theo đến từ Samsung là Galaxy S25 và Galaxy S25 Plus.', N'd168d47f-7acb-484c-8519-3e50c3d1f918', CAST(N'2025-01-09 00:42:20.9897857' AS DateTime2), N'https://cdn-media.sforum.vn/storage/app/media/trannghia/thong-tin-Galaxy-S25-S25-Plus-cover.jpg', N'Chia Sẻ')
INSERT [identity].[Blogs] ([Id], [Title], [Content], [AuthorId], [CreatedAt], [ImageUrl], [Category]) VALUES (10, N'Nguyên nhân và cách khắc phục lỗi không quét được CCCD để xác thực sinh trắc học? ', N'Trong thời gian gần đây, các ngân hàng đã yêu cầu người dùng cập nhật thông sinh trắc học để đảm bảo an toàn cho tài khoản. Tuy nhiên, nhiều người gặp khó khăn khi không quét được CCCD để xác thực sinh trắc học qua NFC. Nguyên nhân và cách khắc phục như thế nào?', N'd168d47f-7acb-484c-8519-3e50c3d1f918', CAST(N'2025-01-09 00:42:24.9331968' AS DateTime2), N'https://cdn-media.sforum.vn/storage/app/media/nhuy/Nhu-Y/khong-quet-duoc-cccd-de-xac-thuc-sinh-trac-hoc-2.jpg', N'Chia Sẻ')
INSERT [identity].[Blogs] ([Id], [Title], [Content], [AuthorId], [CreatedAt], [ImageUrl], [Category]) VALUES (11, N'Galaxy S25 và S25 Plus có tính năng gì mới? Khi nào ra mắt và giá bao nhiêu?', N'Ở thời điểm hiện tại, nhờ các tin đồn và rò rỉ mà chúng ta đã có được bức tranh tương đối hoàn chỉnh về bộ đôi flagship tiếp theo đến từ Samsung là Galaxy S25 và Galaxy S25 Plus.', N'd168d47f-7acb-484c-8519-3e50c3d1f918', CAST(N'2025-01-09 00:42:59.1602709' AS DateTime2), N'https://cdn-media.sforum.vn/storage/app/media/trannghia/thong-tin-Galaxy-S25-S25-Plus-cover.jpg', N'Chia Sẻ')
INSERT [identity].[Blogs] ([Id], [Title], [Content], [AuthorId], [CreatedAt], [ImageUrl], [Category]) VALUES (12, N'Nguyên nhân và cách khắc phục lỗi không quét được CCCD để xác thực sinh trắc học? ', N'Trong thời gian gần đây, các ngân hàng đã yêu cầu người dùng cập nhật thông sinh trắc học để đảm bảo an toàn cho tài khoản. Tuy nhiên, nhiều người gặp khó khăn khi không quét được CCCD để xác thực sinh trắc học qua NFC. Nguyên nhân và cách khắc phục như thế nào?', N'd168d47f-7acb-484c-8519-3e50c3d1f918', CAST(N'2025-01-09 00:43:02.7434564' AS DateTime2), N'https://cdn-media.sforum.vn/storage/app/media/nhuy/Nhu-Y/khong-quet-duoc-cccd-de-xac-thuc-sinh-trac-hoc-2.jpg', N'Chia Sẻ')
SET IDENTITY_INSERT [identity].[Blogs] OFF
SET IDENTITY_INSERT [identity].[CartDetails] ON 

INSERT [identity].[CartDetails] ([Id], [CartId], [ProductId], [Quantity]) VALUES (2, 1, 8, 1)
INSERT [identity].[CartDetails] ([Id], [CartId], [ProductId], [Quantity]) VALUES (3, 1, 8, 1)
INSERT [identity].[CartDetails] ([Id], [CartId], [ProductId], [Quantity]) VALUES (4, 1, 8, 1)
INSERT [identity].[CartDetails] ([Id], [CartId], [ProductId], [Quantity]) VALUES (5, 1, 8, 1)
INSERT [identity].[CartDetails] ([Id], [CartId], [ProductId], [Quantity]) VALUES (6, 1, 8, 1)
INSERT [identity].[CartDetails] ([Id], [CartId], [ProductId], [Quantity]) VALUES (7, 1, 8, 1)
INSERT [identity].[CartDetails] ([Id], [CartId], [ProductId], [Quantity]) VALUES (8, 1, 8, 1)
INSERT [identity].[CartDetails] ([Id], [CartId], [ProductId], [Quantity]) VALUES (9, 1, 8, 1)
INSERT [identity].[CartDetails] ([Id], [CartId], [ProductId], [Quantity]) VALUES (10, 1, 8, 1)
INSERT [identity].[CartDetails] ([Id], [CartId], [ProductId], [Quantity]) VALUES (11, 1, 8, 1)
INSERT [identity].[CartDetails] ([Id], [CartId], [ProductId], [Quantity]) VALUES (12, 1, 8, 1)
INSERT [identity].[CartDetails] ([Id], [CartId], [ProductId], [Quantity]) VALUES (13, 1, 8, 1)
INSERT [identity].[CartDetails] ([Id], [CartId], [ProductId], [Quantity]) VALUES (14, 1, 8, 1)
INSERT [identity].[CartDetails] ([Id], [CartId], [ProductId], [Quantity]) VALUES (15, 1, 15, 1)
INSERT [identity].[CartDetails] ([Id], [CartId], [ProductId], [Quantity]) VALUES (16, 1, 15, 1)
INSERT [identity].[CartDetails] ([Id], [CartId], [ProductId], [Quantity]) VALUES (17, 1, 14, 1)
INSERT [identity].[CartDetails] ([Id], [CartId], [ProductId], [Quantity]) VALUES (18, 1, 14, 1)
SET IDENTITY_INSERT [identity].[CartDetails] OFF
SET IDENTITY_INSERT [identity].[Carts] ON 

INSERT [identity].[Carts] ([Id], [UserId], [CreatedAt], [PaymentMethod]) VALUES (1, N'd168d47f-7acb-484c-8519-3e50c3d1f918', CAST(N'2025-01-07 12:20:59.7960181' AS DateTime2), N'10000')
SET IDENTITY_INSERT [identity].[Carts] OFF
SET IDENTITY_INSERT [identity].[Categorys] ON 

INSERT [identity].[Categorys] ([Id], [Name], [Description]) VALUES (1, N'Iphone 16', N'Mô tả iphone 16')
INSERT [identity].[Categorys] ([Id], [Name], [Description]) VALUES (4, N'Samsung', N'Mô Tả SamSung')
SET IDENTITY_INSERT [identity].[Categorys] OFF
SET IDENTITY_INSERT [identity].[OrderDetails] ON 

INSERT [identity].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [Price]) VALUES (2, 3, 8, 4, CAST(0.00 AS Decimal(18, 2)))
INSERT [identity].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [Price]) VALUES (3, 4, 8, 4, CAST(0.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [identity].[OrderDetails] OFF
SET IDENTITY_INSERT [identity].[Orders] ON 

INSERT [identity].[Orders] ([Id], [UserId], [OrderDate], [OrderStatus], [TotalPrice], [PaymentMethod], [ShippingAddress]) VALUES (1, N'd168d47f-7acb-484c-8519-3e50c3d1f918', CAST(N'2025-01-07 12:21:36.3674621' AS DateTime2), N'Shipped', CAST(10000.00 AS Decimal(18, 2)), N'MOMO', N'Thu Duc Campus')
INSERT [identity].[Orders] ([Id], [UserId], [OrderDate], [OrderStatus], [TotalPrice], [PaymentMethod], [ShippingAddress]) VALUES (3, N'5060e869-f6d1-45b1-9180-1b5919b00c24', CAST(N'2025-01-09 02:30:45.4288265' AS DateTime2), N'Pending', CAST(400000.00 AS Decimal(18, 2)), N'kgdfjk', N'dgjjk')
INSERT [identity].[Orders] ([Id], [UserId], [OrderDate], [OrderStatus], [TotalPrice], [PaymentMethod], [ShippingAddress]) VALUES (4, N'5060e869-f6d1-45b1-9180-1b5919b00c24', CAST(N'2025-01-09 02:30:48.2134035' AS DateTime2), N'Pending', CAST(400000.00 AS Decimal(18, 2)), N'kgdfjk', N'dgjjk')
SET IDENTITY_INSERT [identity].[Orders] OFF
SET IDENTITY_INSERT [identity].[OtpRecords] ON 

INSERT [identity].[OtpRecords] ([Id], [PhoneNumber], [Otp], [Expiry], [UserId]) VALUES (1, N'0336656538', N'993098', CAST(N'2025-01-09 01:33:36.3672339' AS DateTime2), N'5060e869-f6d1-45b1-9180-1b5919b00c24')
SET IDENTITY_INSERT [identity].[OtpRecords] OFF
SET IDENTITY_INSERT [identity].[Products] ON 

INSERT [identity].[Products] ([Id], [Name], [Price], [Image1], [Image2], [Description], [CategoryId], [CreatedAt], [UpdatedAt]) VALUES (8, N'Samsung Galaxy ', CAST(100000.00 AS Decimal(18, 2)), N'https://cdn2.cellphones.com.vn/x/media/catalog/product/d/i/dien-thoai-samsung-galaxy-s24-fe_3__4.png', N'https://cdn2.cellphones.com.vn/x/media/catalog/product/d/i/dien-thoai-samsung-galaxy-s24-fe_2__4.png', N'áddd', 4, CAST(N'2025-01-08 20:54:34.7142332' AS DateTime2), CAST(N'2025-01-08 20:54:34.7142338' AS DateTime2))
INSERT [identity].[Products] ([Id], [Name], [Price], [Image1], [Image2], [Description], [CategoryId], [CreatedAt], [UpdatedAt]) VALUES (14, N'iPhone 16 Pro Max ', CAST(13990000.00 AS Decimal(18, 2)), N'https://cdn2.cellphones.com.vn/x/media/catalog/product/i/p/iphone-16-pro-max.png', N'https://cdn2.cellphones.com.vn/x/media/catalog/product/i/p/iphone-16-pro-max-3.png', N'Đặc điểm nổi bật của iPhone 16 Pro Max 256GB | Chính hãng VN/A', 1, CAST(N'2025-01-09 00:45:58.5100746' AS DateTime2), CAST(N'2025-01-09 00:45:58.5100749' AS DateTime2))
INSERT [identity].[Products] ([Id], [Name], [Price], [Image1], [Image2], [Description], [CategoryId], [CreatedAt], [UpdatedAt]) VALUES (15, N'Samsung Galaxy', CAST(12990000.00 AS Decimal(18, 2)), N'https://cdn2.cellphones.com.vn/x/media/catalog/product/d/i/dien-thoai-samsung-galaxy-s24-fe_3__4.png', N'https://cdn2.cellphones.com.vn/x/media/catalog/product/d/i/dien-thoai-samsung-galaxy-s24-fe_2__4.png', N'Đặc điểm nổi bật của Samsung Galaxy S24 FE 5G 8GB 128GB', 4, CAST(N'2025-01-09 00:48:21.3696918' AS DateTime2), CAST(N'2025-01-09 00:48:21.3696921' AS DateTime2))
INSERT [identity].[Products] ([Id], [Name], [Price], [Image1], [Image2], [Description], [CategoryId], [CreatedAt], [UpdatedAt]) VALUES (16, N'iPhone 16 Pro Max', CAST(13990000.00 AS Decimal(18, 2)), N'https://cdn2.cellphones.com.vn/x/media/catalog/product/i/p/iphone-16-pro-max.png', N'https://cdn2.cellphones.com.vn/x/media/catalog/product/i/p/iphone-16-pro-max-3.png', N'Đặc điểm nổi bật của iPhone 16 Pro Max 256GB | Chính hãng VN/A', 1, CAST(N'2025-01-09 00:48:25.5022891' AS DateTime2), CAST(N'2025-01-09 00:48:25.5022895' AS DateTime2))
INSERT [identity].[Products] ([Id], [Name], [Price], [Image1], [Image2], [Description], [CategoryId], [CreatedAt], [UpdatedAt]) VALUES (17, N'Samsung Galaxy', CAST(12990000.00 AS Decimal(18, 2)), N'https://cdn2.cellphones.com.vn/x/media/catalog/product/d/i/dien-thoai-samsung-galaxy-s24-fe_3__4.png', N'https://cdn2.cellphones.com.vn/x/media/catalog/product/d/i/dien-thoai-samsung-galaxy-s24-fe_2__4.png', N'Đặc điểm nổi bật của Samsung Galaxy S24 FE 5G 8GB 128GB', 4, CAST(N'2025-01-09 00:48:29.6090454' AS DateTime2), CAST(N'2025-01-09 00:48:29.6090457' AS DateTime2))
INSERT [identity].[Products] ([Id], [Name], [Price], [Image1], [Image2], [Description], [CategoryId], [CreatedAt], [UpdatedAt]) VALUES (18, N'iPhone 16 Pro Max', CAST(13990000.00 AS Decimal(18, 2)), N'https://cdn2.cellphones.com.vn/x/media/catalog/product/i/p/iphone-16-pro-max.png', N'https://cdn2.cellphones.com.vn/x/media/catalog/product/i/p/iphone-16-pro-max-3.png', N'Đặc điểm nổi bật của iPhone 16 Pro Max 256GB | Chính hãng VN/A', 1, CAST(N'2025-01-09 00:48:33.0817792' AS DateTime2), CAST(N'2025-01-09 00:48:33.0817794' AS DateTime2))
INSERT [identity].[Products] ([Id], [Name], [Price], [Image1], [Image2], [Description], [CategoryId], [CreatedAt], [UpdatedAt]) VALUES (19, N'Samsung Galaxy', CAST(12990000.00 AS Decimal(18, 2)), N'https://cdn2.cellphones.com.vn/x/media/catalog/product/d/i/dien-thoai-samsung-galaxy-s24-fe_3__4.png', N'https://cdn2.cellphones.com.vn/x/media/catalog/product/d/i/dien-thoai-samsung-galaxy-s24-fe_2__4.png', N'Đặc điểm nổi bật của Samsung Galaxy S24 FE 5G 8GB 128GB', 4, CAST(N'2025-01-09 00:48:36.3043954' AS DateTime2), CAST(N'2025-01-09 00:48:36.3043956' AS DateTime2))
INSERT [identity].[Products] ([Id], [Name], [Price], [Image1], [Image2], [Description], [CategoryId], [CreatedAt], [UpdatedAt]) VALUES (20, N'iPhone 16 Pro Max', CAST(13990000.00 AS Decimal(18, 2)), N'https://cdn2.cellphones.com.vn/x/media/catalog/product/i/p/iphone-16-pro-max.png', N'https://cdn2.cellphones.com.vn/x/media/catalog/product/i/p/iphone-16-pro-max-3.png', N'Đặc điểm nổi bật của iPhone 16 Pro Max 256GB | Chính hãng VN/A', 1, CAST(N'2025-01-09 00:48:39.3478817' AS DateTime2), CAST(N'2025-01-09 00:48:39.3478819' AS DateTime2))
INSERT [identity].[Products] ([Id], [Name], [Price], [Image1], [Image2], [Description], [CategoryId], [CreatedAt], [UpdatedAt]) VALUES (21, N'Samsung Galaxy', CAST(12990000.00 AS Decimal(18, 2)), N'https://cdn2.cellphones.com.vn/x/media/catalog/product/d/i/dien-thoai-samsung-galaxy-s24-fe_3__4.png', N'https://cdn2.cellphones.com.vn/x/media/catalog/product/d/i/dien-thoai-samsung-galaxy-s24-fe_2__4.png', N'Đặc điểm nổi bật của Samsung Galaxy S24 FE 5G 8GB 128GB', 4, CAST(N'2025-01-09 00:48:42.2457819' AS DateTime2), CAST(N'2025-01-09 00:48:42.2457821' AS DateTime2))
INSERT [identity].[Products] ([Id], [Name], [Price], [Image1], [Image2], [Description], [CategoryId], [CreatedAt], [UpdatedAt]) VALUES (22, N'iPhone 16 Pro Max', CAST(13990000.00 AS Decimal(18, 2)), N'https://cdn2.cellphones.com.vn/x/media/catalog/product/i/p/iphone-16-pro-max.png', N'https://cdn2.cellphones.com.vn/x/media/catalog/product/i/p/iphone-16-pro-max-3.png', N'Đặc điểm nổi bật của iPhone 16 Pro Max 256GB | Chính hãng VN/A', 1, CAST(N'2025-01-09 00:48:45.7368487' AS DateTime2), CAST(N'2025-01-09 00:48:45.7368492' AS DateTime2))
SET IDENTITY_INSERT [identity].[Products] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 06/03/2025 01:19:29 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [identity].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [RoleNameIndex]    Script Date: 06/03/2025 01:19:29 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [identity].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 06/03/2025 01:19:29 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [identity].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 06/03/2025 01:19:29 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [identity].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 06/03/2025 01:19:29 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [identity].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [EmailIndex]    Script Date: 06/03/2025 01:19:29 ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [identity].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UserNameIndex]    Script Date: 06/03/2025 01:19:29 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [identity].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Blogs_AuthorId]    Script Date: 06/03/2025 01:19:29 ******/
CREATE NONCLUSTERED INDEX [IX_Blogs_AuthorId] ON [identity].[Blogs]
(
	[AuthorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CartDetails_CartId]    Script Date: 06/03/2025 01:19:29 ******/
CREATE NONCLUSTERED INDEX [IX_CartDetails_CartId] ON [identity].[CartDetails]
(
	[CartId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CartDetails_ProductId]    Script Date: 06/03/2025 01:19:29 ******/
CREATE NONCLUSTERED INDEX [IX_CartDetails_ProductId] ON [identity].[CartDetails]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Carts_UserId]    Script Date: 06/03/2025 01:19:29 ******/
CREATE NONCLUSTERED INDEX [IX_Carts_UserId] ON [identity].[Carts]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderDetails_OrderId]    Script Date: 06/03/2025 01:19:29 ******/
CREATE NONCLUSTERED INDEX [IX_OrderDetails_OrderId] ON [identity].[OrderDetails]
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderDetails_ProductId]    Script Date: 06/03/2025 01:19:29 ******/
CREATE NONCLUSTERED INDEX [IX_OrderDetails_ProductId] ON [identity].[OrderDetails]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Orders_UserId]    Script Date: 06/03/2025 01:19:29 ******/
CREATE NONCLUSTERED INDEX [IX_Orders_UserId] ON [identity].[Orders]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_OtpRecords_UserId]    Script Date: 06/03/2025 01:19:29 ******/
CREATE NONCLUSTERED INDEX [IX_OtpRecords_UserId] ON [identity].[OtpRecords]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_CategoryId]    Script Date: 06/03/2025 01:19:29 ******/
CREATE NONCLUSTERED INDEX [IX_Products_CategoryId] ON [identity].[Products]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [identity].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [identity].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [identity].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [identity].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [identity].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [identity].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [identity].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [identity].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [identity].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [identity].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [identity].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [identity].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [identity].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [identity].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [identity].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [identity].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [identity].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [identity].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [identity].[Blogs]  WITH CHECK ADD  CONSTRAINT [FK_Blogs_AspNetUsers_AuthorId] FOREIGN KEY([AuthorId])
REFERENCES [identity].[AspNetUsers] ([Id])
GO
ALTER TABLE [identity].[Blogs] CHECK CONSTRAINT [FK_Blogs_AspNetUsers_AuthorId]
GO
ALTER TABLE [identity].[CartDetails]  WITH CHECK ADD  CONSTRAINT [FK_CartDetails_Carts_CartId] FOREIGN KEY([CartId])
REFERENCES [identity].[Carts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [identity].[CartDetails] CHECK CONSTRAINT [FK_CartDetails_Carts_CartId]
GO
ALTER TABLE [identity].[CartDetails]  WITH CHECK ADD  CONSTRAINT [FK_CartDetails_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [identity].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [identity].[CartDetails] CHECK CONSTRAINT [FK_CartDetails_Products_ProductId]
GO
ALTER TABLE [identity].[Carts]  WITH CHECK ADD  CONSTRAINT [FK_Carts_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [identity].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [identity].[Carts] CHECK CONSTRAINT [FK_Carts_AspNetUsers_UserId]
GO
ALTER TABLE [identity].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [identity].[Orders] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [identity].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Orders_OrderId]
GO
ALTER TABLE [identity].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [identity].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [identity].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Products_ProductId]
GO
ALTER TABLE [identity].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [identity].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [identity].[Orders] CHECK CONSTRAINT [FK_Orders_AspNetUsers_UserId]
GO
ALTER TABLE [identity].[OtpRecords]  WITH CHECK ADD  CONSTRAINT [FK_OtpRecords_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [identity].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [identity].[OtpRecords] CHECK CONSTRAINT [FK_OtpRecords_AspNetUsers_UserId]
GO
ALTER TABLE [identity].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categorys_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [identity].[Categorys] ([Id])
GO
ALTER TABLE [identity].[Products] CHECK CONSTRAINT [FK_Products_Categorys_CategoryId]
GO
USE [master]
GO
ALTER DATABASE [DoAnCuoiKiNhom3BanDienThoaiDiDongAPI] SET  READ_WRITE 
GO
