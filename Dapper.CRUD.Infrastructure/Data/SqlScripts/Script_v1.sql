USE [chinook]
GO
/****** Object:  Table [dbo].[album]    Script Date: 23-09-2022 00:18:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[album](
	[AlbumId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NULL,
	[ArtistId] [int] NULL,
 CONSTRAINT [PK_album] PRIMARY KEY CLUSTERED 
(
	[AlbumId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[artist]    Script Date: 23-09-2022 00:18:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[artist](
	[ArtistId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ArtistId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[customer]    Script Date: 23-09-2022 00:18:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customer](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Company] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[State] [nvarchar](50) NULL,
	[Country] [nvarchar](50) NULL,
	[PostalCode] [nvarchar](10) NULL,
	[Phone] [int] NULL,
	[Fax] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[SupportRepId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[employee]    Script Date: 23-09-2022 00:18:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employee](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Title] [nvarchar](50) NULL,
	[ReportsTo] [int] NULL,
	[BirthDate] [date] NULL,
	[HireDate] [date] NULL,
	[Address] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[State] [nvarchar](50) NULL,
	[Country] [nvarchar](50) NULL,
	[PostalCode] [nvarchar](10) NULL,
	[Phone] [int] NULL,
	[Fax] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[genre]    Script Date: 23-09-2022 00:18:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[genre](
	[GenreId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[GenreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[invoice]    Script Date: 23-09-2022 00:18:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[invoice](
	[InvoiceId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NULL,
	[InvoiceDate] [date] NULL,
	[BillingAddress] [nvarchar](50) NULL,
	[BillingCity] [nvarchar](50) NULL,
	[BillingState] [nvarchar](50) NULL,
	[BillingCountry] [nvarchar](50) NULL,
	[BillingPostalCode] [nvarchar](50) NULL,
	[Total] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[InvoiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[invoiceline]    Script Date: 23-09-2022 00:18:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[invoiceline](
	[InvoiceLineId] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceId] [int] NULL,
	[TrackId] [int] NULL,
	[UnitPrice] [int] NULL,
	[Quantity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[InvoiceLineId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mediatype]    Script Date: 23-09-2022 00:18:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mediatype](
	[MediatypeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MediatypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[playlist]    Script Date: 23-09-2022 00:18:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[playlist](
	[PlayListId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[PlayListTrackId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[PlayListId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[track]    Script Date: 23-09-2022 00:18:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[track](
	[TrackId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[AlbumId] [int] NULL,
	[MediaTypeId] [int] NULL,
	[GenreId] [int] NULL,
	[Composer] [nvarchar](50) NULL,
	[Miliseconds] [int] NULL,
	[Bytes] [int] NULL,
	[UnitPrice] [int] NULL,
	[PlayListTrackId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[TrackId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[album] ON 

INSERT [dbo].[album] ([AlbumId], [Title], [ArtistId]) VALUES (1, N'test 1', 1)
INSERT [dbo].[album] ([AlbumId], [Title], [ArtistId]) VALUES (2, N'test', 1)
INSERT [dbo].[album] ([AlbumId], [Title], [ArtistId]) VALUES (3, N'Album 1', 1)
SET IDENTITY_INSERT [dbo].[album] OFF
GO
SET IDENTITY_INSERT [dbo].[artist] ON 

INSERT [dbo].[artist] ([ArtistId], [Name]) VALUES (1, N'test 1')
INSERT [dbo].[artist] ([ArtistId], [Name]) VALUES (2, N'Artist1')
SET IDENTITY_INSERT [dbo].[artist] OFF
GO
SET IDENTITY_INSERT [dbo].[customer] ON 

INSERT [dbo].[customer] ([CustomerId], [FirstName], [LastName], [Company], [Address], [City], [State], [Country], [PostalCode], [Phone], [Fax], [Email], [SupportRepId]) VALUES (3, N'test12', N'TEST', N'test', N'test', N'teste', N'tste', N'estst', N'76', 76567, N'test', N'test', 1)
INSERT [dbo].[customer] ([CustomerId], [FirstName], [LastName], [Company], [Address], [City], [State], [Country], [PostalCode], [Phone], [Fax], [Email], [SupportRepId]) VALUES (5, N'Customer 1', N'Test', N'test', N'test', N'etse', N'tset', N'test', N'32423', 5, N'test', N'test', 1)
SET IDENTITY_INSERT [dbo].[customer] OFF
GO
SET IDENTITY_INSERT [dbo].[employee] ON 

INSERT [dbo].[employee] ([EmployeeId], [FirstName], [LastName], [Title], [ReportsTo], [BirthDate], [HireDate], [Address], [City], [State], [Country], [PostalCode], [Phone], [Fax], [Email]) VALUES (1, N'test456', N'test', N'test', 1, CAST(N'2022-09-06' AS Date), CAST(N'2022-09-15' AS Date), N'Sep 15 2022 12:00AM', N'test', N'teste', N'tset', N'1251', 3252, N'test', N'test')
INSERT [dbo].[employee] ([EmployeeId], [FirstName], [LastName], [Title], [ReportsTo], [BirthDate], [HireDate], [Address], [City], [State], [Country], [PostalCode], [Phone], [Fax], [Email]) VALUES (2, N'Emp1', N'tetste', N'test', 1, CAST(N'2022-09-07' AS Date), CAST(N'2022-09-28' AS Date), N'tes', N'test', N'test', N'est', N'7657', 2, N'2', N'test')
SET IDENTITY_INSERT [dbo].[employee] OFF
GO
SET IDENTITY_INSERT [dbo].[genre] ON 

INSERT [dbo].[genre] ([GenreId], [Name]) VALUES (1, N'test35')
INSERT [dbo].[genre] ([GenreId], [Name]) VALUES (2, N'Genre 1')
SET IDENTITY_INSERT [dbo].[genre] OFF
GO
SET IDENTITY_INSERT [dbo].[invoice] ON 

INSERT [dbo].[invoice] ([InvoiceId], [CustomerId], [InvoiceDate], [BillingAddress], [BillingCity], [BillingState], [BillingCountry], [BillingPostalCode], [Total]) VALUES (2, 3, NULL, N'test', N'test', N'test', N'test', N'test', 251)
INSERT [dbo].[invoice] ([InvoiceId], [CustomerId], [InvoiceDate], [BillingAddress], [BillingCity], [BillingState], [BillingCountry], [BillingPostalCode], [Total]) VALUES (3, 3, CAST(N'2022-09-27' AS Date), N'test 757', N'test', N'test', N'test', N'757', 6)
SET IDENTITY_INSERT [dbo].[invoice] OFF
GO
SET IDENTITY_INSERT [dbo].[invoiceline] ON 

INSERT [dbo].[invoiceline] ([InvoiceLineId], [InvoiceId], [TrackId], [UnitPrice], [Quantity]) VALUES (5, 2, 3, 34, 24)
INSERT [dbo].[invoiceline] ([InvoiceLineId], [InvoiceId], [TrackId], [UnitPrice], [Quantity]) VALUES (6, 2, 3, 234, 21)
SET IDENTITY_INSERT [dbo].[invoiceline] OFF
GO
SET IDENTITY_INSERT [dbo].[mediatype] ON 

INSERT [dbo].[mediatype] ([MediatypeId], [Name]) VALUES (1, N'test54')
INSERT [dbo].[mediatype] ([MediatypeId], [Name]) VALUES (2, N'Test 1')
SET IDENTITY_INSERT [dbo].[mediatype] OFF
GO
SET IDENTITY_INSERT [dbo].[playlist] ON 

INSERT [dbo].[playlist] ([PlayListId], [Name], [PlayListTrackId]) VALUES (1, N'test', 1)
SET IDENTITY_INSERT [dbo].[playlist] OFF
GO
SET IDENTITY_INSERT [dbo].[track] ON 

INSERT [dbo].[track] ([TrackId], [Name], [AlbumId], [MediaTypeId], [GenreId], [Composer], [Miliseconds], [Bytes], [UnitPrice], [PlayListTrackId]) VALUES (3, N'test 1', 1, 1, 1, N'TEST', 124, 124, 41, 1)
INSERT [dbo].[track] ([TrackId], [Name], [AlbumId], [MediaTypeId], [GenreId], [Composer], [Miliseconds], [Bytes], [UnitPrice], [PlayListTrackId]) VALUES (4, N'Track 1', 1, 1, 1, N'Test', 0, 6, 2, 1)
SET IDENTITY_INSERT [dbo].[track] OFF
GO
ALTER TABLE [dbo].[customer]  WITH CHECK ADD  CONSTRAINT [FK_employee_customer] FOREIGN KEY([SupportRepId])
REFERENCES [dbo].[employee] ([EmployeeId])
GO
ALTER TABLE [dbo].[customer] CHECK CONSTRAINT [FK_employee_customer]
GO
ALTER TABLE [dbo].[employee]  WITH CHECK ADD  CONSTRAINT [FK_employee_employee] FOREIGN KEY([ReportsTo])
REFERENCES [dbo].[employee] ([EmployeeId])
GO
ALTER TABLE [dbo].[employee] CHECK CONSTRAINT [FK_employee_employee]
GO
ALTER TABLE [dbo].[invoice]  WITH CHECK ADD  CONSTRAINT [FK_customer_invoice] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[customer] ([CustomerId])
GO
ALTER TABLE [dbo].[invoice] CHECK CONSTRAINT [FK_customer_invoice]
GO
ALTER TABLE [dbo].[invoiceline]  WITH CHECK ADD  CONSTRAINT [FK_invoice_invoiceline] FOREIGN KEY([InvoiceId])
REFERENCES [dbo].[invoice] ([InvoiceId])
GO
ALTER TABLE [dbo].[invoiceline] CHECK CONSTRAINT [FK_invoice_invoiceline]
GO
ALTER TABLE [dbo].[invoiceline]  WITH CHECK ADD  CONSTRAINT [FK_track_invoiceline] FOREIGN KEY([TrackId])
REFERENCES [dbo].[track] ([TrackId])
GO
ALTER TABLE [dbo].[invoiceline] CHECK CONSTRAINT [FK_track_invoiceline]
GO
ALTER TABLE [dbo].[track]  WITH CHECK ADD  CONSTRAINT [FK_album_track] FOREIGN KEY([AlbumId])
REFERENCES [dbo].[album] ([AlbumId])
GO
ALTER TABLE [dbo].[track] CHECK CONSTRAINT [FK_album_track]
GO
ALTER TABLE [dbo].[track]  WITH CHECK ADD  CONSTRAINT [FK_genre_track] FOREIGN KEY([GenreId])
REFERENCES [dbo].[genre] ([GenreId])
GO
ALTER TABLE [dbo].[track] CHECK CONSTRAINT [FK_genre_track]
GO
ALTER TABLE [dbo].[track]  WITH CHECK ADD  CONSTRAINT [FK_mediatype_track] FOREIGN KEY([MediaTypeId])
REFERENCES [dbo].[mediatype] ([MediatypeId])
GO
ALTER TABLE [dbo].[track] CHECK CONSTRAINT [FK_mediatype_track]
GO
ALTER TABLE [dbo].[track]  WITH CHECK ADD  CONSTRAINT [FK_playlist_track] FOREIGN KEY([PlayListTrackId])
REFERENCES [dbo].[playlist] ([PlayListId])
GO
ALTER TABLE [dbo].[track] CHECK CONSTRAINT [FK_playlist_track]
GO
