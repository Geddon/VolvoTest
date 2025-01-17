USE [master]
GO
/****** Object:  Database [CongestionTax]    Script Date: 2021-03-14 22:19:06 ******/
CREATE DATABASE [CongestionTax]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CongestionTax', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\CongestionTax.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CongestionTax_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\CongestionTax_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CongestionTax] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CongestionTax].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CongestionTax] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CongestionTax] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CongestionTax] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CongestionTax] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CongestionTax] SET ARITHABORT OFF 
GO
ALTER DATABASE [CongestionTax] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CongestionTax] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CongestionTax] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CongestionTax] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CongestionTax] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CongestionTax] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CongestionTax] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CongestionTax] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CongestionTax] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CongestionTax] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CongestionTax] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CongestionTax] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CongestionTax] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CongestionTax] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CongestionTax] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CongestionTax] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CongestionTax] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CongestionTax] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CongestionTax] SET  MULTI_USER 
GO
ALTER DATABASE [CongestionTax] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CongestionTax] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CongestionTax] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CongestionTax] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CongestionTax] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CongestionTax] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [CongestionTax] SET QUERY_STORE = OFF
GO
USE [CongestionTax]
GO
/****** Object:  Table [dbo].[Passage]    Script Date: 2021-03-14 22:19:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Passage](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VehicleId] [int] NOT NULL,
	[ZoneId] [int] NOT NULL,
	[TimeStamp] [datetime2](7) NOT NULL,
	[StartOfPaymentPeriod] [bit] NOT NULL,
	[TariffId] [int] NOT NULL,
	[ZeroCost] [bit] NOT NULL,
 CONSTRAINT [PK_Passage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tariff]    Script Date: 2021-03-14 22:19:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tariff](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DateFrom] [datetime2](7) NOT NULL,
	[DateTo] [datetime2](7) NOT NULL,
	[ZoneId] [int] NOT NULL,
	[Price] [int] NOT NULL,
 CONSTRAINT [PK_Tariff] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaxFreeDay]    Script Date: 2021-03-14 22:19:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaxFreeDay](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[Name] [nchar](10) NOT NULL,
	[RecurringWeekly] [bit] NOT NULL,
	[ZoneId] [int] NOT NULL,
 CONSTRAINT [PK_TaxFreeDays] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaxFreePeriod]    Script Date: 2021-03-14 22:19:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaxFreePeriod](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[PeriodStart] [datetime2](7) NOT NULL,
	[PeriodEnd] [datetime2](7) NOT NULL,
	[RecurringYearly] [bit] NOT NULL,
	[ZoneId] [int] NOT NULL,
 CONSTRAINT [PK_TaxFreePeriods] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehicle]    Script Date: 2021-03-14 22:19:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicle](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RegNumber] [nvarchar](10) NOT NULL,
	[VehicleTypeId] [int] NOT NULL,
 CONSTRAINT [PK_Vehicle] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VehicleType]    Script Date: 2021-03-14 22:19:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehicleType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[IsTaxExempt] [bit] NOT NULL,
 CONSTRAINT [PK_VehicleType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VehicleTypeZone]    Script Date: 2021-03-14 22:19:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehicleTypeZone](
	[VehicleTypeId] [int] NOT NULL,
	[ZoneId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Zone]    Script Date: 2021-03-14 22:19:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Zone](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[SingleChargeRule] [bit] NOT NULL,
 CONSTRAINT [PK_Zone] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Tariff] ON 

INSERT [dbo].[Tariff] ([Id], [DateFrom], [DateTo], [ZoneId], [Price]) VALUES (1, CAST(N'1900-01-01T06:00:00.0000000' AS DateTime2), CAST(N'1900-01-01T06:30:00.0000000' AS DateTime2), 1, 8)
INSERT [dbo].[Tariff] ([Id], [DateFrom], [DateTo], [ZoneId], [Price]) VALUES (2, CAST(N'1900-01-01T06:30:00.0000000' AS DateTime2), CAST(N'1900-01-01T07:00:00.0000000' AS DateTime2), 1, 13)
INSERT [dbo].[Tariff] ([Id], [DateFrom], [DateTo], [ZoneId], [Price]) VALUES (3, CAST(N'1900-01-01T07:00:00.0000000' AS DateTime2), CAST(N'1900-01-01T08:00:00.0000000' AS DateTime2), 1, 18)
INSERT [dbo].[Tariff] ([Id], [DateFrom], [DateTo], [ZoneId], [Price]) VALUES (6, CAST(N'1900-01-01T08:00:00.0000000' AS DateTime2), CAST(N'1900-01-01T08:30:00.0000000' AS DateTime2), 1, 13)
INSERT [dbo].[Tariff] ([Id], [DateFrom], [DateTo], [ZoneId], [Price]) VALUES (7, CAST(N'1900-01-01T08:30:00.0000000' AS DateTime2), CAST(N'1900-01-01T15:00:00.0000000' AS DateTime2), 1, 8)
INSERT [dbo].[Tariff] ([Id], [DateFrom], [DateTo], [ZoneId], [Price]) VALUES (8, CAST(N'1900-01-01T15:00:00.0000000' AS DateTime2), CAST(N'1900-01-01T15:30:00.0000000' AS DateTime2), 1, 13)
INSERT [dbo].[Tariff] ([Id], [DateFrom], [DateTo], [ZoneId], [Price]) VALUES (9, CAST(N'1900-01-01T15:30:00.0000000' AS DateTime2), CAST(N'1900-01-01T17:00:00.0000000' AS DateTime2), 1, 18)
INSERT [dbo].[Tariff] ([Id], [DateFrom], [DateTo], [ZoneId], [Price]) VALUES (10, CAST(N'1900-01-01T17:00:00.0000000' AS DateTime2), CAST(N'1900-01-01T18:00:00.0000000' AS DateTime2), 1, 13)
INSERT [dbo].[Tariff] ([Id], [DateFrom], [DateTo], [ZoneId], [Price]) VALUES (11, CAST(N'1900-01-01T18:00:00.0000000' AS DateTime2), CAST(N'1900-01-01T18:30:00.0000000' AS DateTime2), 1, 8)
INSERT [dbo].[Tariff] ([Id], [DateFrom], [DateTo], [ZoneId], [Price]) VALUES (12, CAST(N'1900-01-01T18:30:00.0000000' AS DateTime2), CAST(N'1900-01-01T06:00:00.0000000' AS DateTime2), 1, 0)
SET IDENTITY_INSERT [dbo].[Tariff] OFF
GO
SET IDENTITY_INSERT [dbo].[TaxFreeDay] ON 

INSERT [dbo].[TaxFreeDay] ([Id], [Date], [Name], [RecurringWeekly], [ZoneId]) VALUES (1, CAST(N'2021-03-13T00:00:00.0000000' AS DateTime2), N'Saturday  ', 1, 1)
INSERT [dbo].[TaxFreeDay] ([Id], [Date], [Name], [RecurringWeekly], [ZoneId]) VALUES (3, CAST(N'2021-03-14T00:00:00.0000000' AS DateTime2), N'Sunday    ', 1, 1)
SET IDENTITY_INSERT [dbo].[TaxFreeDay] OFF
GO
SET IDENTITY_INSERT [dbo].[TaxFreePeriod] ON 

INSERT [dbo].[TaxFreePeriod] ([Id], [Name], [PeriodStart], [PeriodEnd], [RecurringYearly], [ZoneId]) VALUES (1, N'July', CAST(N'2021-07-01T00:00:00.0000000' AS DateTime2), CAST(N'2021-08-01T00:00:00.0000000' AS DateTime2), 1, 1)
SET IDENTITY_INSERT [dbo].[TaxFreePeriod] OFF
GO
SET IDENTITY_INSERT [dbo].[Vehicle] ON 

INSERT [dbo].[Vehicle] ([Id], [RegNumber], [VehicleTypeId]) VALUES (1, N'AAA111', 6)
INSERT [dbo].[Vehicle] ([Id], [RegNumber], [VehicleTypeId]) VALUES (2, N'BBB111', 6)
INSERT [dbo].[Vehicle] ([Id], [RegNumber], [VehicleTypeId]) VALUES (2, N'CCC111', 7)
SET IDENTITY_INSERT [dbo].[Vehicle] OFF
GO
SET IDENTITY_INSERT [dbo].[VehicleType] ON 

INSERT [dbo].[VehicleType] ([Id], [Name], [IsTaxExempt]) VALUES (1, N'Emergency', 1)
INSERT [dbo].[VehicleType] ([Id], [Name], [IsTaxExempt]) VALUES (2, N'Bus', 1)
INSERT [dbo].[VehicleType] ([Id], [Name], [IsTaxExempt]) VALUES (3, N'Diplomat', 1)
INSERT [dbo].[VehicleType] ([Id], [Name], [IsTaxExempt]) VALUES (4, N'Military', 1)
INSERT [dbo].[VehicleType] ([Id], [Name], [IsTaxExempt]) VALUES (5, N'Foreign', 1)
INSERT [dbo].[VehicleType] ([Id], [Name], [IsTaxExempt]) VALUES (6, N'Normal', 0)
INSERT [dbo].[VehicleType] ([Id], [Name], [IsTaxExempt]) VALUES (7, N'Motorcycle', 1)
SET IDENTITY_INSERT [dbo].[VehicleType] OFF
GO
INSERT [dbo].[VehicleTypeZone] ([VehicleTypeId], [ZoneId]) VALUES (1, 1)
INSERT [dbo].[VehicleTypeZone] ([VehicleTypeId], [ZoneId]) VALUES (2, 1)
INSERT [dbo].[VehicleTypeZone] ([VehicleTypeId], [ZoneId]) VALUES (3, 1)
INSERT [dbo].[VehicleTypeZone] ([VehicleTypeId], [ZoneId]) VALUES (4, 1)
INSERT [dbo].[VehicleTypeZone] ([VehicleTypeId], [ZoneId]) VALUES (5, 1)
INSERT [dbo].[VehicleTypeZone] ([VehicleTypeId], [ZoneId]) VALUES (6, 1)
INSERT [dbo].[VehicleTypeZone] ([VehicleTypeId], [ZoneId]) VALUES (7, 1)
GO
SET IDENTITY_INSERT [dbo].[Zone] ON 

INSERT [dbo].[Zone] ([Id], [Name], [SingleChargeRule]) VALUES (1, N'Göteborg', 1)
SET IDENTITY_INSERT [dbo].[Zone] OFF
GO
ALTER TABLE [dbo].[TaxFreeDay] ADD  CONSTRAINT [DF_TaxFreeDays_Recurring]  DEFAULT ((0)) FOR [RecurringWeekly]
GO
ALTER TABLE [dbo].[Zone] ADD  CONSTRAINT [DF_Zone_SingleChargeRule]  DEFAULT ((1)) FOR [SingleChargeRule]
GO
ALTER TABLE [dbo].[Passage]  WITH CHECK ADD  CONSTRAINT [FK_Passage_Tariff] FOREIGN KEY([TariffId])
REFERENCES [dbo].[Tariff] ([Id])
GO
ALTER TABLE [dbo].[Passage] CHECK CONSTRAINT [FK_Passage_Tariff]
GO
ALTER TABLE [dbo].[Passage]  WITH CHECK ADD  CONSTRAINT [FK_Passage_Vehicle] FOREIGN KEY([VehicleId])
REFERENCES [dbo].[Vehicle] ([Id])
GO
ALTER TABLE [dbo].[Passage] CHECK CONSTRAINT [FK_Passage_Vehicle]
GO
ALTER TABLE [dbo].[Passage]  WITH CHECK ADD  CONSTRAINT [FK_Passage_Zone] FOREIGN KEY([ZoneId])
REFERENCES [dbo].[Zone] ([Id])
GO
ALTER TABLE [dbo].[Passage] CHECK CONSTRAINT [FK_Passage_Zone]
GO
ALTER TABLE [dbo].[Tariff]  WITH CHECK ADD  CONSTRAINT [FK_Tariff_Zone] FOREIGN KEY([ZoneId])
REFERENCES [dbo].[Zone] ([Id])
GO
ALTER TABLE [dbo].[Tariff] CHECK CONSTRAINT [FK_Tariff_Zone]
GO
ALTER TABLE [dbo].[TaxFreeDay]  WITH CHECK ADD  CONSTRAINT [FK_TaxFreeDay_Zone] FOREIGN KEY([ZoneId])
REFERENCES [dbo].[Zone] ([Id])
GO
ALTER TABLE [dbo].[TaxFreeDay] CHECK CONSTRAINT [FK_TaxFreeDay_Zone]
GO
ALTER TABLE [dbo].[TaxFreePeriod]  WITH CHECK ADD  CONSTRAINT [FK_TaxFreePeriod_Zone] FOREIGN KEY([ZoneId])
REFERENCES [dbo].[Zone] ([Id])
GO
ALTER TABLE [dbo].[TaxFreePeriod] CHECK CONSTRAINT [FK_TaxFreePeriod_Zone]
GO
ALTER TABLE [dbo].[Vehicle]  WITH CHECK ADD  CONSTRAINT [FK_Vehicle_VehicleType] FOREIGN KEY([VehicleTypeId])
REFERENCES [dbo].[VehicleType] ([Id])
GO
ALTER TABLE [dbo].[Vehicle] CHECK CONSTRAINT [FK_Vehicle_VehicleType]
GO
ALTER TABLE [dbo].[VehicleTypeZone]  WITH CHECK ADD  CONSTRAINT [FK_VehicleTypeZone_VehicleType] FOREIGN KEY([VehicleTypeId])
REFERENCES [dbo].[VehicleType] ([Id])
GO
ALTER TABLE [dbo].[VehicleTypeZone] CHECK CONSTRAINT [FK_VehicleTypeZone_VehicleType]
GO
ALTER TABLE [dbo].[VehicleTypeZone]  WITH CHECK ADD  CONSTRAINT [FK_VehicleTypeZone_Zone] FOREIGN KEY([ZoneId])
REFERENCES [dbo].[Zone] ([Id])
GO
ALTER TABLE [dbo].[VehicleTypeZone] CHECK CONSTRAINT [FK_VehicleTypeZone_Zone]
GO
USE [master]
GO
ALTER DATABASE [CongestionTax] SET  READ_WRITE 
GO
