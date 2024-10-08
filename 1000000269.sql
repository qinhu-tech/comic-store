USE [ComicsStore]
GO
/****** Object:  Table [dbo].[AdminUser]    Script Date: 10/31/2022 7:03:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminUser](
	[ID] [int] NOT NULL,
	[NameUser] [nvarchar](50) NULL,
	[RoleUser] [nvarchar](50) NULL,
	[PasswordUser] [nchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 10/31/2022 7:03:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[IDCate] [int] IDENTITY(1,1) NOT NULL,
	[NameCate] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IDCate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 10/31/2022 7:03:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[IDCus] [int] IDENTITY(1,1) NOT NULL,
	[NameCus] [nvarchar](50) NULL,
	[PhoneCus] [nvarchar](15) NULL,
	[EmailCus] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IDCus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 10/31/2022 7:03:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDProduct] [int] NULL,
	[IDOrder] [int] NULL,
	[Quantity] [int] NULL,
	[UnitPrice] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderPro]    Script Date: 10/31/2022 7:03:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderPro](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DateOrder] [date] NULL,
	[IDCus] [int] NULL,
	[AddressDeliverry] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 10/31/2022 7:03:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[NamePro] [nvarchar](50) NULL,
	[DecriptionPro] [nvarchar](50) NULL,
	[Category] [int] NULL,
	[Price] [decimal](18, 2) NULL,
	[ImagePro] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[AdminUser] ([ID], [NameUser], [RoleUser], [PasswordUser]) VALUES (1, NULL, NULL, N'1                                                 ')
INSERT [dbo].[AdminUser] ([ID], [NameUser], [RoleUser], [PasswordUser]) VALUES (68, NULL, NULL, N'68                                                ')
INSERT [dbo].[AdminUser] ([ID], [NameUser], [RoleUser], [PasswordUser]) VALUES (69, NULL, NULL, N'69                                                ')
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([IDCate], [NameCate]) VALUES (5, N'Romance')
INSERT [dbo].[Category] ([IDCate], [NameCate]) VALUES (6, N'Đời Thường')
INSERT [dbo].[Category] ([IDCate], [NameCate]) VALUES (7, N'Học Đường')
INSERT [dbo].[Category] ([IDCate], [NameCate]) VALUES (8, N'Kinh Dị')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([IDCus], [NameCus], [PhoneCus], [EmailCus]) VALUES (1, N'Nguyễn Văn Cùi Bắp', N'0903784512', N'cuibap@gmail.com')
INSERT [dbo].[Customer] ([IDCus], [NameCus], [PhoneCus], [EmailCus]) VALUES (2, N'Lê thị Mắm Tôm', N'0913678345', N'mamtom@gmail.com')
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderDetail] ON 

INSERT [dbo].[OrderDetail] ([ID], [IDProduct], [IDOrder], [Quantity], [UnitPrice]) VALUES (1, 1, 1, 5, 600)
SET IDENTITY_INSERT [dbo].[OrderDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderPro] ON 

INSERT [dbo].[OrderPro] ([ID], [DateOrder], [IDCus], [AddressDeliverry]) VALUES (1, CAST(N'2022-01-01' AS Date), 1, N'155 Sư Vạn Hạnh,q10')
SET IDENTITY_INSERT [dbo].[OrderPro] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ProductID], [NamePro], [DecriptionPro], [Category], [Price], [ImagePro]) VALUES (14, N'Spy x Family 3', N'Truyện cũng ok ấy', 5, CAST(69000.00 AS Decimal(18, 2)), N'~/Content/images/Spy.jpg')
INSERT [dbo].[Product] ([ProductID], [NamePro], [DecriptionPro], [Category], [Price], [ImagePro]) VALUES (15, N'Chainsaw Man 4', N'Truyện cũng ok ấy', 8, CAST(960000.00 AS Decimal(18, 2)), N'~/Content/images/Chain.jpg')
INSERT [dbo].[Product] ([ProductID], [NamePro], [DecriptionPro], [Category], [Price], [ImagePro]) VALUES (16, N'Bạn Quỳnh Như', N'không ok tí nào', 5, CAST(1.00 AS Decimal(18, 2)), N'~/Content/images/Bạn Quỳnh Như.jpg')
INSERT [dbo].[Product] ([ProductID], [NamePro], [DecriptionPro], [Category], [Price], [ImagePro]) VALUES (21, N'Chainsaw Man 2', N'Truyện cũng ok ấy', 6, CAST(69000.00 AS Decimal(18, 2)), N'~/Content/images/Chain-22.jpg')
INSERT [dbo].[Product] ([ProductID], [NamePro], [DecriptionPro], [Category], [Price], [ImagePro]) VALUES (22, N'JJS 17', N'Truyện ok', NULL, CAST(200000.00 AS Decimal(18, 2)), N'~/Content/images/Jjs-17.jpg')
INSERT [dbo].[Product] ([ProductID], [NamePro], [DecriptionPro], [Category], [Price], [ImagePro]) VALUES (23, N'Doreamon 3', N'Truyện cũng ok ấy', NULL, CAST(69000.00 AS Decimal(18, 2)), N'~/Content/images/doraemon-tap-3.jpg')
INSERT [dbo].[Product] ([ProductID], [NamePro], [DecriptionPro], [Category], [Price], [ImagePro]) VALUES (24, N'Doreamon 1', NULL, NULL, CAST(69000.00 AS Decimal(18, 2)), N'~/Content/images/D1.jpg')
INSERT [dbo].[Product] ([ProductID], [NamePro], [DecriptionPro], [Category], [Price], [ImagePro]) VALUES (25, N'Spider Man', N'Truyện ok', 6, CAST(1000000000000000.00 AS Decimal(18, 2)), N'~/Content/images/Spider1.jpg')
INSERT [dbo].[Product] ([ProductID], [NamePro], [DecriptionPro], [Category], [Price], [ImagePro]) VALUES (26, N'Attack On Titan 5', NULL, NULL, CAST(69000.00 AS Decimal(18, 2)), N'~/Content/images/AOT5.jpg')
INSERT [dbo].[Product] ([ProductID], [NamePro], [DecriptionPro], [Category], [Price], [ImagePro]) VALUES (27, N'Spy x Family 5', NULL, NULL, CAST(69000.00 AS Decimal(18, 2)), N'~/Content/images/spy-x-family-tap-5.jpg')
INSERT [dbo].[Product] ([ProductID], [NamePro], [DecriptionPro], [Category], [Price], [ImagePro]) VALUES (33, N'Spy x Family', N'Truyện cũng ok ấy', 5, CAST(69000.00 AS Decimal(18, 2)), N'~/Content/images/wallpaperflare.com_wallpaper.jpg')
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
ALTER TABLE [dbo].[OrderDetail]  WITH NOCHECK ADD FOREIGN KEY([IDOrder])
REFERENCES [dbo].[OrderPro] ([ID])
GO
ALTER TABLE [dbo].[OrderDetail]  WITH NOCHECK ADD FOREIGN KEY([IDProduct])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[OrderPro]  WITH CHECK ADD FOREIGN KEY([IDCus])
REFERENCES [dbo].[Customer] ([IDCus])
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Pro_Category] FOREIGN KEY([Category])
REFERENCES [dbo].[Category] ([IDCate])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Pro_Category]
GO
