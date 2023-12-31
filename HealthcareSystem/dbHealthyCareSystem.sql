USE [dbHealthcareSystem]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 12/28/2023 11:16:12 PM ******/
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
/****** Object:  Table [dbo].[Account]    Script Date: 12/28/2023 11:16:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[AcoountID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](255) NULL,
	[Email] [nvarchar](255) NULL,
	[Password] [nvarchar](255) NULL,
	[UserRoleNo] [int] NULL,
	[UserNo] [nchar](255) NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[AcoountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Appointments]    Script Date: 12/28/2023 11:16:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointments](
	[AppointmentID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[ServiceID] [int] NULL,
	[Description] [nvarchar](max) NULL,
	[Address] [nvarchar](255) NULL,
	[Price] [decimal](18, 0) NULL,
	[Payment] [nvarchar](255) NULL,
	[AppointmentTime] [datetime] NULL,
	[Status] [int] NULL,
	[CreateDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_Appointments] PRIMARY KEY CLUSTERED 
(
	[AppointmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HealthComments]    Script Date: 12/28/2023 11:16:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HealthComments](
	[HealthCommentID] [int] IDENTITY(1,1) NOT NULL,
	[HealthRecordID] [int] NULL,
	[ReviewID] [int] NULL,
	[CommentText] [nvarchar](max) NULL,
	[Recommendation] [nvarchar](max) NULL,
	[CommentedBy] [int] NULL,
	[CommentedAt] [datetime] NULL,
	[CreateDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[HealthCommentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HealthRecords]    Script Date: 12/28/2023 11:16:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HealthRecords](
	[HealthRecordID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[Allergies] [bit] NULL,
	[DiagnosedConditions] [bit] NULL,
	[CurrentMedications] [bit] NULL,
	[SportsPlayed] [bit] NULL,
	[DailyWaterIntake] [int] NULL,
	[HairLoss] [bit] NULL,
	[UrineColor] [nvarchar](255) NULL,
	[UrineSmell] [bit] NULL,
	[StoolCharacteristics] [nvarchar](max) NULL,
	[Height] [decimal](5, 2) NULL,
	[WaistCircumference] [decimal](5, 2) NULL,
	[Overweight] [bit] NULL,
	[CreateBy] [int] NULL,
	[CreateDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK__HealthRe__3BE0B89D2E8E6AF4] PRIMARY KEY CLUSTERED 
(
	[HealthRecordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Locations]    Script Date: 12/28/2023 11:16:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Locations](
	[LocationID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Parent] [int] NULL,
	[Levels] [int] NULL,
	[Slug] [nvarchar](100) NULL,
	[NameWithType] [nvarchar](100) NULL,
	[Type] [int] NULL,
	[Description] [nvarchar](max) NULL,
	[CreateDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[LocationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reviews]    Script Date: 12/28/2023 11:16:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reviews](
	[ReviewID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[ServiceID] [int] NULL,
	[Rating] [int] NULL,
	[ReviewText] [nvarchar](max) NULL,
	[CreateDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK__Reviews__74BC79AEC2B7F3D5] PRIMARY KEY CLUSTERED 
(
	[ReviewID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Services]    Script Date: 12/28/2023 11:16:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Services](
	[ServiceID] [int] IDENTITY(1,1) NOT NULL,
	[ServiceName] [nvarchar](255) NOT NULL,
	[StaffID] [int] NULL,
	[Description] [nvarchar](max) NULL,
	[StartHours] [int] NULL,
	[StartMinitues] [int] NULL,
	[EndHours] [int] NULL,
	[EndMinitues] [int] NULL,
	[Price] [decimal](10, 2) NULL,
	[Address] [nvarchar](255) NULL,
	[CreateDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK__Services__C51BB0EAC2E33B8E] PRIMARY KEY CLUSTERED 
(
	[ServiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staffs]    Script Date: 12/28/2023 11:16:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staffs](
	[StaffID] [int] IDENTITY(1,1) NOT NULL,
	[StaffNo] [nchar](255) NULL,
	[UserRoleNo] [int] NULL,
	[SupplierID] [int] NULL,
	[NationalID] [nchar](255) NULL,
	[Email] [nvarchar](255) NULL,
	[PhoneNumber] [nvarchar](15) NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Sex] [nvarchar](10) NULL,
	[Address] [nvarchar](255) NULL,
	[Birthday] [datetime] NULL,
	[Avatar] [nvarchar](max) NULL,
	[Position] [nvarchar](50) NULL,
	[Qualifications] [nvarchar](255) NULL,
	[LicenseNumber] [nchar](255) NULL,
	[Specialization] [nvarchar](100) NULL,
	[JoinDate] [date] NULL,
	[TerminationDate] [date] NULL,
	[Active] [bit] NULL,
	[SaltPassword] [nchar](255) NULL,
	[LastLogin] [datetime] NULL,
	[CreateDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK__Staffs__C33E2C4F4EB708A8] PRIMARY KEY CLUSTERED 
(
	[StaffID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Suppliers]    Script Date: 12/28/2023 11:16:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suppliers](
	[SupplierID] [int] IDENTITY(1,1) NOT NULL,
	[LocationNo] [int] NULL,
	[District] [int] NULL,
	[Ward] [int] NULL,
	[SupplierType] [nvarchar](255) NULL,
	[Avatar] [nvarchar](max) NULL,
	[TIN] [nchar](255) NULL,
	[SupplierName] [nvarchar](255) NOT NULL,
	[PhoneNumber] [nvarchar](15) NULL,
	[Fax] [nvarchar](15) NULL,
	[Website] [nvarchar](255) NULL,
	[Address] [nvarchar](255) NULL,
	[Phone] [nvarchar](15) NULL,
	[Email] [nvarchar](255) NULL,
	[ContactPerson] [nvarchar](100) NULL,
	[TaxID] [nvarchar](20) NULL,
	[RegistrationDate] [date] NULL,
	[LicenseNumber] [nvarchar](50) NULL,
	[ServicesProvided] [nvarchar](max) NULL,
	[Certification] [nvarchar](max) NULL,
	[Notes] [nvarchar](max) NULL,
	[CreateDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK__Supplier__4BE66694233456ED] PRIMARY KEY CLUSTERED 
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 12/28/2023 11:16:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[UserRoleID] [int] IDENTITY(1,1) NOT NULL,
	[UserRoleNo] [nchar](10) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
	[CreateDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserRoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/28/2023 11:16:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserNo] [nchar](255) NULL,
	[UserRoleNo] [int] NULL,
	[NationalID] [nchar](255) NULL,
	[Email] [nvarchar](255) NULL,
	[PhoneNumber] [nvarchar](15) NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Sex] [nvarchar](10) NULL,
	[Address] [nvarchar](255) NULL,
	[Birthday] [datetime] NULL,
	[Avatar] [nvarchar](max) NULL,
	[Active] [bit] NULL,
	[SaltPassword] [nchar](255) NULL,
	[LastLogin] [datetime] NULL,
	[CreateDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK__Users__1788CCAC3E8D8CFC] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkSchedules]    Script Date: 12/28/2023 11:16:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkSchedules](
	[WorkScheduleID] [int] IDENTITY(1,1) NOT NULL,
	[StaffID] [int] NULL,
	[WorkDate] [date] NULL,
	[StartTime] [time](7) NULL,
	[EndTime] [time](7) NULL,
	[Department] [nvarchar](100) NULL,
	[Notes] [nvarchar](max) NULL,
	[IsWorking] [bit] NULL,
	[IsAvailable] [bit] NULL,
	[CreateDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK__WorkSche__C6AC635E7CAFC7B3] PRIMARY KEY CLUSTERED 
(
	[WorkScheduleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([AcoountID], [UserName], [Email], [Password], [UserRoleNo], [UserNo], [CreateDate]) VALUES (4, N'nv', N'nv', N'$2b$10$OdtMqPIz/8IIOlQW50k9a.2CMX5UX20iFsaWEUMht8P3SHs86sUUK', 1, N'dcead6e1-d481-4c6c-9988-8469cbb0fda6                                                                                                                                                                                                                           ', CAST(N'2023-12-16T14:34:05.270' AS DateTime))
INSERT [dbo].[Account] ([AcoountID], [UserName], [Email], [Password], [UserRoleNo], [UserNo], [CreateDate]) VALUES (5, N'user', N'user', N'$2b$10$PUVWGLmGaYoNWqFx0MJhUuzj9q/hniaZ2Ev.2acTDTDipvAKm3he2', 2, N'9e1c7b78-7a42-4bf7-98dc-a6f14640dec9                                                                                                                                                                                                                           ', CAST(N'2023-12-16T14:34:33.800' AS DateTime))
INSERT [dbo].[Account] ([AcoountID], [UserName], [Email], [Password], [UserRoleNo], [UserNo], [CreateDate]) VALUES (6, N'1243', N'1234', N'$2b$10$BeWmb98ukkNxV/7An1o/i.idFxlkXljAj.eIhp7f4Lo0fXVQCHE3G', 1, N'2056865d-e6c3-42eb-a623-225d35c3feaa                                                                                                                                                                                                                           ', CAST(N'2023-12-17T00:06:24.057' AS DateTime))
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
SET IDENTITY_INSERT [dbo].[Appointments] ON 

INSERT [dbo].[Appointments] ([AppointmentID], [UserID], [ServiceID], [Description], [Address], [Price], [Payment], [AppointmentTime], [Status], [CreateDate], [ModifiedDate]) VALUES (0, 4, 1, NULL, N'test dia chi', CAST(50000000 AS Decimal(18, 0)), N'Chuyern khoản ngân hàng', CAST(N'2023-12-16T09:48:37.067' AS DateTime), 0, CAST(N'2023-12-16T16:49:23.157' AS DateTime), NULL)
INSERT [dbo].[Appointments] ([AppointmentID], [UserID], [ServiceID], [Description], [Address], [Price], [Payment], [AppointmentTime], [Status], [CreateDate], [ModifiedDate]) VALUES (1, 4, 2, NULL, N'testt', CAST(7777 AS Decimal(18, 0)), N'Thanh toán qua momo', CAST(N'2023-12-16T09:53:02.063' AS DateTime), 0, CAST(N'2023-12-16T16:53:33.880' AS DateTime), NULL)
INSERT [dbo].[Appointments] ([AppointmentID], [UserID], [ServiceID], [Description], [Address], [Price], [Payment], [AppointmentTime], [Status], [CreateDate], [ModifiedDate]) VALUES (2, 4, 2, NULL, N'123', CAST(11 AS Decimal(18, 0)), N'tessttt', CAST(N'2023-12-16T09:55:43.223' AS DateTime), 0, CAST(N'2023-12-16T16:56:13.997' AS DateTime), NULL)
INSERT [dbo].[Appointments] ([AppointmentID], [UserID], [ServiceID], [Description], [Address], [Price], [Payment], [AppointmentTime], [Status], [CreateDate], [ModifiedDate]) VALUES (3, 4, 1, NULL, N'ttt', CAST(77777 AS Decimal(18, 0)), N'123', CAST(N'2023-12-16T09:58:53.457' AS DateTime), 0, CAST(N'2023-12-16T16:59:22.193' AS DateTime), NULL)
INSERT [dbo].[Appointments] ([AppointmentID], [UserID], [ServiceID], [Description], [Address], [Price], [Payment], [AppointmentTime], [Status], [CreateDate], [ModifiedDate]) VALUES (6, 4, 2, NULL, N'tttt', CAST(0 AS Decimal(18, 0)), N'tesdsst', CAST(N'2023-12-16T10:17:45.540' AS DateTime), 0, CAST(N'2023-12-16T17:17:57.290' AS DateTime), NULL)
INSERT [dbo].[Appointments] ([AppointmentID], [UserID], [ServiceID], [Description], [Address], [Price], [Payment], [AppointmentTime], [Status], [CreateDate], [ModifiedDate]) VALUES (7, 4, 2, NULL, N'tttt', CAST(0 AS Decimal(18, 0)), N'tesdsst', CAST(N'2023-12-16T10:17:45.540' AS DateTime), 0, CAST(N'2023-12-16T17:19:09.133' AS DateTime), NULL)
INSERT [dbo].[Appointments] ([AppointmentID], [UserID], [ServiceID], [Description], [Address], [Price], [Payment], [AppointmentTime], [Status], [CreateDate], [ModifiedDate]) VALUES (8, 4, 3, NULL, N'string', CAST(0 AS Decimal(18, 0)), N'string', CAST(N'2023-12-16T10:21:35.400' AS DateTime), 1, CAST(N'2023-12-16T17:21:44.870' AS DateTime), CAST(N'2023-12-16T17:30:56.703' AS DateTime))
SET IDENTITY_INSERT [dbo].[Appointments] OFF
GO
SET IDENTITY_INSERT [dbo].[Locations] ON 

INSERT [dbo].[Locations] ([LocationID], [Name], [Parent], [Levels], [Slug], [NameWithType], [Type], [Description], [CreateDate], [ModifiedDate]) VALUES (1, N'TP Hồ chính Minh', 0, 1, N'HCM', N'TP', 0, N'Thành phố Hồ Chí Minh', CAST(N'2023-12-10T15:03:28.983' AS DateTime), NULL)
INSERT [dbo].[Locations] ([LocationID], [Name], [Parent], [Levels], [Slug], [NameWithType], [Type], [Description], [CreateDate], [ModifiedDate]) VALUES (2, N'Quận 1', 1, 2, N'Q.1', N'Q1', NULL, N'Quận 1', CAST(N'2023-12-16T15:49:00.710' AS DateTime), NULL)
INSERT [dbo].[Locations] ([LocationID], [Name], [Parent], [Levels], [Slug], [NameWithType], [Type], [Description], [CreateDate], [ModifiedDate]) VALUES (3, N'Bến Nghé', 2, 3, N'BN', N'BN', NULL, N'Bến Nghé', CAST(N'2023-12-16T15:50:03.040' AS DateTime), NULL)
INSERT [dbo].[Locations] ([LocationID], [Name], [Parent], [Levels], [Slug], [NameWithType], [Type], [Description], [CreateDate], [ModifiedDate]) VALUES (4, N'Bến Thành', 2, 3, N'BT', N'BT', NULL, N'Bến Thành', CAST(N'2023-12-16T15:50:30.963' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Locations] OFF
GO
SET IDENTITY_INSERT [dbo].[Services] ON 

INSERT [dbo].[Services] ([ServiceID], [ServiceName], [StaffID], [Description], [StartHours], [StartMinitues], [EndHours], [EndMinitues], [Price], [Address], [CreateDate], [ModifiedDate]) VALUES (1, N'Dịch chăm sóc sức khỏe', 2, N'Dịch chăm sóc sức khỏ', 8, 30, 22, 0, CAST(50000000.00 AS Decimal(10, 2)), N'6 test', CAST(N'2023-12-16T09:14:31.020' AS DateTime), CAST(N'2023-12-16T09:14:31.020' AS DateTime))
INSERT [dbo].[Services] ([ServiceID], [ServiceName], [StaffID], [Description], [StartHours], [StartMinitues], [EndHours], [EndMinitues], [Price], [Address], [CreateDate], [ModifiedDate]) VALUES (2, N'Khám bệnh tài nhà update', 2, N'test11111', 8, 30, 22, 0, CAST(1111111.00 AS Decimal(10, 2)), N'6 test', CAST(N'2023-12-16T09:26:11.233' AS DateTime), CAST(N'2023-12-16T16:28:09.030' AS DateTime))
INSERT [dbo].[Services] ([ServiceID], [ServiceName], [StaffID], [Description], [StartHours], [StartMinitues], [EndHours], [EndMinitues], [Price], [Address], [CreateDate], [ModifiedDate]) VALUES (3, N'Khám bệnh tài nhà 123', 2, N'testt', 0, 0, 0, 0, CAST(0.00 AS Decimal(10, 2)), N'string', CAST(N'2023-12-16T09:20:03.800' AS DateTime), CAST(N'2023-12-16T09:20:03.800' AS DateTime))
INSERT [dbo].[Services] ([ServiceID], [ServiceName], [StaffID], [Description], [StartHours], [StartMinitues], [EndHours], [EndMinitues], [Price], [Address], [CreateDate], [ModifiedDate]) VALUES (4, N'tesdtttt', 2, N'1111', 0, 0, 0, 0, CAST(0.00 AS Decimal(10, 2)), N'test', CAST(N'2023-12-16T17:02:20.870' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Services] OFF
GO
SET IDENTITY_INSERT [dbo].[Staffs] ON 

INSERT [dbo].[Staffs] ([StaffID], [StaffNo], [UserRoleNo], [SupplierID], [NationalID], [Email], [PhoneNumber], [FirstName], [LastName], [Sex], [Address], [Birthday], [Avatar], [Position], [Qualifications], [LicenseNumber], [Specialization], [JoinDate], [TerminationDate], [Active], [SaltPassword], [LastLogin], [CreateDate], [ModifiedDate]) VALUES (2, N'dcead6e1-d481-4c6c-9988-8469cbb0fda6                                                                                                                                                                                                                           ', 1, NULL, NULL, N'nv', NULL, N'test', N'test1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, CAST(N'2023-12-16T14:34:10.683' AS DateTime), NULL)
INSERT [dbo].[Staffs] ([StaffID], [StaffNo], [UserRoleNo], [SupplierID], [NationalID], [Email], [PhoneNumber], [FirstName], [LastName], [Sex], [Address], [Birthday], [Avatar], [Position], [Qualifications], [LicenseNumber], [Specialization], [JoinDate], [TerminationDate], [Active], [SaltPassword], [LastLogin], [CreateDate], [ModifiedDate]) VALUES (3, N'2056865d-e6c3-42eb-a623-225d35c3feaa                                                                                                                                                                                                                           ', 1, NULL, NULL, N'1234', NULL, N'test123', N'test', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, CAST(N'2023-12-17T00:06:24.313' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Staffs] OFF
GO
SET IDENTITY_INSERT [dbo].[UserRoles] ON 

INSERT [dbo].[UserRoles] ([UserRoleID], [UserRoleNo], [RoleName], [CreateDate], [ModifiedDate]) VALUES (1, N'S         ', N'Nhân viên chăm sóc y tế', CAST(N'2023-11-05T15:22:18.143' AS DateTime), CAST(N'2023-11-05T00:00:00.000' AS DateTime))
INSERT [dbo].[UserRoles] ([UserRoleID], [UserRoleNo], [RoleName], [CreateDate], [ModifiedDate]) VALUES (2, N'U         ', N'Người dùng', CAST(N'2023-12-16T10:26:59.203' AS DateTime), NULL)
INSERT [dbo].[UserRoles] ([UserRoleID], [UserRoleNo], [RoleName], [CreateDate], [ModifiedDate]) VALUES (3, N'ADMIN     ', N'Admin', CAST(N'2023-12-16T10:27:26.423' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[UserRoles] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [UserNo], [UserRoleNo], [NationalID], [Email], [PhoneNumber], [FirstName], [LastName], [Sex], [Address], [Birthday], [Avatar], [Active], [SaltPassword], [LastLogin], [CreateDate], [ModifiedDate]) VALUES (4, N'9e1c7b78-7a42-4bf7-98dc-a6f14640dec9                                                                                                                                                                                                                           ', 2, NULL, N'user', NULL, N'user', N'test1', NULL, NULL, NULL, NULL, 1, NULL, NULL, CAST(N'2023-12-16T14:34:33.850' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Appointments] ADD  CONSTRAINT [DF__Appointme__Creat__74794A92]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[HealthComments] ADD  DEFAULT (getdate()) FOR [CommentedAt]
GO
ALTER TABLE [dbo].[HealthComments] ADD  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[HealthRecords] ADD  CONSTRAINT [DF__HealthRec__Creat__0880433F]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Locations] ADD  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Reviews] ADD  CONSTRAINT [DF__Reviews__CreateD__7A3223E8]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Services] ADD  CONSTRAINT [DF__Services__Create__7D0E9093]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Staffs] ADD  CONSTRAINT [DF__Staffs__CreateDa__1209AD79]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Suppliers] ADD  CONSTRAINT [DF__Suppliers__Creat__0F2D40CE]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[UserRoles] ADD  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF__Users__CreateDat__02C769E9]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[WorkSchedules] ADD  CONSTRAINT [DF__WorkSched__Creat__05A3D694]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD  CONSTRAINT [FK_Appointments_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Appointments] CHECK CONSTRAINT [FK_Appointments_Users]
GO
ALTER TABLE [dbo].[HealthRecords]  WITH CHECK ADD  CONSTRAINT [FK_HealthRecords_Users1] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[HealthRecords] CHECK CONSTRAINT [FK_HealthRecords_Users1]
GO
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_Reviews_Services1] FOREIGN KEY([ServiceID])
REFERENCES [dbo].[Services] ([ServiceID])
GO
ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_Reviews_Services1]
GO
ALTER TABLE [dbo].[Services]  WITH CHECK ADD  CONSTRAINT [FK_Services_Staffs1] FOREIGN KEY([StaffID])
REFERENCES [dbo].[Staffs] ([StaffID])
GO
ALTER TABLE [dbo].[Services] CHECK CONSTRAINT [FK_Services_Staffs1]
GO
ALTER TABLE [dbo].[WorkSchedules]  WITH CHECK ADD  CONSTRAINT [FK_WorkSchedules_Staffs] FOREIGN KEY([StaffID])
REFERENCES [dbo].[Staffs] ([StaffID])
GO
ALTER TABLE [dbo].[WorkSchedules] CHECK CONSTRAINT [FK_WorkSchedules_Staffs]
GO
