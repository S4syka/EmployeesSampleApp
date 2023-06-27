USE [master]
GO
/****** Object:  Database [EmployeeSample]    Script Date: 6/23/2023 1:27:04 PM ******/
CREATE DATABASE [EmployeeSample]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EmployeeSample', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\EmployeeSample.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EmployeeSample_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\EmployeeSample_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [EmployeeSample] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EmployeeSample].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EmployeeSample] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EmployeeSample] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EmployeeSample] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EmployeeSample] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EmployeeSample] SET ARITHABORT OFF 
GO
ALTER DATABASE [EmployeeSample] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EmployeeSample] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EmployeeSample] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EmployeeSample] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EmployeeSample] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EmployeeSample] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EmployeeSample] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EmployeeSample] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EmployeeSample] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EmployeeSample] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EmployeeSample] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EmployeeSample] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EmployeeSample] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EmployeeSample] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EmployeeSample] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EmployeeSample] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EmployeeSample] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EmployeeSample] SET RECOVERY FULL 
GO
ALTER DATABASE [EmployeeSample] SET  MULTI_USER 
GO
ALTER DATABASE [EmployeeSample] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EmployeeSample] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EmployeeSample] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EmployeeSample] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EmployeeSample] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EmployeeSample] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'EmployeeSample', N'ON'
GO
ALTER DATABASE [EmployeeSample] SET QUERY_STORE = OFF
GO
USE [EmployeeSample]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 6/23/2023 1:27:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Firstname] [nvarchar](50) NOT NULL,
	[Lastname] [nvarchar](50) NOT NULL,
	[Profession] [nvarchar](50) NOT NULL,
	[Salary] [money] NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
	[PhoneNumber] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 
GO
INSERT [dbo].[Employee] ([Id], [Firstname], [Lastname], [Profession], [Salary], [Status], [PhoneNumber]) VALUES (6, N'aaaaaaaaaa', N'aaaaaaaa', N'aaaaaaa', 1.0000, N'aaaaaaaaa', N'aaaaaaaaaa')
GO
INSERT [dbo].[Employee] ([Id], [Firstname], [Lastname], [Profession], [Salary], [Status], [PhoneNumber]) VALUES (8, N'aaaaaaaaaaa', N'gsdddddd', N'gsddddd', 111111111.0000, N'6236326', N'aaaaaaaaa')
GO
INSERT [dbo].[Employee] ([Id], [Firstname], [Lastname], [Profession], [Salary], [Status], [PhoneNumber]) VALUES (10, N'aaaaaaaa', N'6126', N'26126216126', 44444444.0000, N'1261261266', N'aaaaaaaa')
GO
INSERT [dbo].[Employee] ([Id], [Firstname], [Lastname], [Profession], [Salary], [Status], [PhoneNumber]) VALUES (11, N'asscafs', N'asdasd', N'asfga', 15125.0000, N'afgasf', N'5125')
GO
INSERT [dbo].[Employee] ([Id], [Firstname], [Lastname], [Profession], [Salary], [Status], [PhoneNumber]) VALUES (12, N'asdasdqw', N'adfs', N'asfd', 125.0000, N'sbsvdacsd', N't1qwfd')
GO
INSERT [dbo].[Employee] ([Id], [Firstname], [Lastname], [Profession], [Salary], [Status], [PhoneNumber]) VALUES (14, N'UIJK', N'AS', N'QWD', 1.0000, N'AWFS', N'K')
GO
INSERT [dbo].[Employee] ([Id], [Firstname], [Lastname], [Profession], [Salary], [Status], [PhoneNumber]) VALUES (15, N'JJJJJJJ', N'JJJJJJJJ', N'JJJJJ', 9999999.0000, N'JJJJJJJ', N'JJJJJJJJ')
GO
INSERT [dbo].[Employee] ([Id], [Firstname], [Lastname], [Profession], [Salary], [Status], [PhoneNumber]) VALUES (17, N'KKKKKKK', N'LLLLLLLL', N'LLLLLL', 0.0000, N'LLLLLLL', N'KKKKKKK')
GO
INSERT [dbo].[Employee] ([Id], [Firstname], [Lastname], [Profession], [Salary], [Status], [PhoneNumber]) VALUES (18, N'3333333', N'333333333', N'33333333333', 333333333.0000, N'3333333333', N'33333333')
GO
INSERT [dbo].[Employee] ([Id], [Firstname], [Lastname], [Profession], [Salary], [Status], [PhoneNumber]) VALUES (19, N'aaaaaaaaa', N'55555555', N'5555555555', 55555555.0000, N'5555555555', N'555555555')
GO
INSERT [dbo].[Employee] ([Id], [Firstname], [Lastname], [Profession], [Salary], [Status], [PhoneNumber]) VALUES (20, N'eeeeeeeeee', N'eeeeeeee', N'eeeeeeeeeee', 44444444444444.0000, N'eeeeeeee', N'eeeeeeee')
GO
INSERT [dbo].[Employee] ([Id], [Firstname], [Lastname], [Profession], [Salary], [Status], [PhoneNumber]) VALUES (21, N'222', N'222222222222', N'2', 2222222222.0000, N'2', N'2222222')
GO
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
USE [master]
GO
ALTER DATABASE [EmployeeSample] SET  READ_WRITE 
GO
