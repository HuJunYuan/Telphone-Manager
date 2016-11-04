USE [master]
GO
/****** Object:  Database [Phone_Dealer_Manage]    Script Date: 2016/11/4 星期五 18:08:54 ******/
CREATE DATABASE [Phone_Dealer_Manage]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Phone_Dealer_Manage', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Phone_Dealer_Manage.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Phone_Dealer_Manage_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Phone_Dealer_Manage_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Phone_Dealer_Manage] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Phone_Dealer_Manage].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Phone_Dealer_Manage] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Phone_Dealer_Manage] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Phone_Dealer_Manage] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Phone_Dealer_Manage] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Phone_Dealer_Manage] SET ARITHABORT OFF 
GO
ALTER DATABASE [Phone_Dealer_Manage] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Phone_Dealer_Manage] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Phone_Dealer_Manage] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Phone_Dealer_Manage] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Phone_Dealer_Manage] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Phone_Dealer_Manage] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Phone_Dealer_Manage] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Phone_Dealer_Manage] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Phone_Dealer_Manage] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Phone_Dealer_Manage] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Phone_Dealer_Manage] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Phone_Dealer_Manage] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Phone_Dealer_Manage] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Phone_Dealer_Manage] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Phone_Dealer_Manage] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Phone_Dealer_Manage] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Phone_Dealer_Manage] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Phone_Dealer_Manage] SET RECOVERY FULL 
GO
ALTER DATABASE [Phone_Dealer_Manage] SET  MULTI_USER 
GO
ALTER DATABASE [Phone_Dealer_Manage] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Phone_Dealer_Manage] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Phone_Dealer_Manage] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Phone_Dealer_Manage] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Phone_Dealer_Manage] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Phone_Dealer_Manage', N'ON'
GO
USE [Phone_Dealer_Manage]
GO
/****** Object:  Table [dbo].[Address_code]    Script Date: 2016/11/4 星期五 18:08:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address_code](
	[Code] [int] NOT NULL,
	[A_Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK8] PRIMARY KEY NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DealerInfo]    Script Date: 2016/11/4 星期五 18:08:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DealerInfo](
	[Dealer_ID] [int] NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[Province] [int] NULL,
	[City] [int] NULL,
	[County] [int] NULL,
	[Tel] [int] NULL,
	[Address] [nvarchar](50) NULL,
 CONSTRAINT [PK4] PRIMARY KEY NONCLUSTERED 
(
	[Dealer_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PhoneInfo]    Script Date: 2016/11/4 星期五 18:08:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PhoneInfo](
	[P_Model] [varchar](20) NOT NULL,
	[P_Address] [nvarchar](50) NULL,
	[P_Color] [nvarchar](10) NOT NULL,
	[P_Deploy] [nvarchar](20) NOT NULL,
	[P_Brand] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK6] PRIMARY KEY NONCLUSTERED 
(
	[P_Model] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Stock_Manage]    Script Date: 2016/11/4 星期五 18:08:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Stock_Manage](
	[Dealer_ID] [int] NOT NULL,
	[P_Model] [varchar](20) NOT NULL,
	[Inventory] [int] NOT NULL,
 CONSTRAINT [PK7] PRIMARY KEY NONCLUSTERED 
(
	[Dealer_ID] ASC,
	[P_Model] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UseLog]    Script Date: 2016/11/4 星期五 18:08:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UseLog](
	[Log_ID] [int] IDENTITY(1,1) NOT NULL,
	[Method] [nvarchar](20) NOT NULL,
	[Time] [datetime] NOT NULL,
	[Number] [int] NULL,
	[Dealer_ID] [int] NULL,
	[P_Model] [varchar](20) NULL,
 CONSTRAINT [PK10] PRIMARY KEY NONCLUSTERED 
(
	[Log_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2016/11/4 星期五 18:08:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[Dealer_ID] [int] IDENTITY(1,1) NOT NULL,
	[Dealer_Name] [varchar](20) NOT NULL,
	[Dealer_Psw] [varchar](20) NOT NULL,
	[Parent_ID] [int] NOT NULL,
	[Dealer_Level] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Dealer_Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Stock_Manage]  WITH CHECK ADD  CONSTRAINT [RefPhoneInfo10] FOREIGN KEY([P_Model])
REFERENCES [dbo].[PhoneInfo] ([P_Model])
GO
ALTER TABLE [dbo].[Stock_Manage] CHECK CONSTRAINT [RefPhoneInfo10]
GO
USE [master]
GO
ALTER DATABASE [Phone_Dealer_Manage] SET  READ_WRITE 
GO
