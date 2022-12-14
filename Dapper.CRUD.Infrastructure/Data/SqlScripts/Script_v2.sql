USE [chinook]
GO
/****** Object:  Table [dbo].[album]    Script Date: 25-09-2022 15:22:45 ******/
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
/****** Object:  Table [dbo].[artist]    Script Date: 25-09-2022 15:22:45 ******/
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
/****** Object:  Table [dbo].[genre]    Script Date: 25-09-2022 15:22:45 ******/
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
/****** Object:  Table [dbo].[mediatype]    Script Date: 25-09-2022 15:22:45 ******/
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
/****** Object:  Table [dbo].[playlist]    Script Date: 25-09-2022 15:22:45 ******/
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
/****** Object:  Table [dbo].[track]    Script Date: 25-09-2022 15:22:45 ******/
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
SET IDENTITY_INSERT [dbo].[genre] ON 

INSERT [dbo].[genre] ([GenreId], [Name]) VALUES (1, N'test35')
INSERT [dbo].[genre] ([GenreId], [Name]) VALUES (2, N'Genre 1')
SET IDENTITY_INSERT [dbo].[genre] OFF
GO
SET IDENTITY_INSERT [dbo].[mediatype] ON 

INSERT [dbo].[mediatype] ([MediatypeId], [Name]) VALUES (1, N'test54')
INSERT [dbo].[mediatype] ([MediatypeId], [Name]) VALUES (2, N'Test 1')
SET IDENTITY_INSERT [dbo].[mediatype] OFF
GO
SET IDENTITY_INSERT [dbo].[playlist] ON 

INSERT [dbo].[playlist] ([PlayListId], [Name], [PlayListTrackId]) VALUES (1, N'test', 3)
INSERT [dbo].[playlist] ([PlayListId], [Name], [PlayListTrackId]) VALUES (3, N'MyList', 4)
SET IDENTITY_INSERT [dbo].[playlist] OFF
GO
SET IDENTITY_INSERT [dbo].[track] ON 

INSERT [dbo].[track] ([TrackId], [Name], [AlbumId], [MediaTypeId], [GenreId], [Composer], [Miliseconds], [Bytes], [UnitPrice], [PlayListTrackId]) VALUES (3, N'test 1', 1, 1, 1, N'TEST', 124, 124, 41, 3)
INSERT [dbo].[track] ([TrackId], [Name], [AlbumId], [MediaTypeId], [GenreId], [Composer], [Miliseconds], [Bytes], [UnitPrice], [PlayListTrackId]) VALUES (4, N'Track 1', 1, 1, 1, N'Test', 0, 6, 2, 1)
SET IDENTITY_INSERT [dbo].[track] OFF
GO
ALTER TABLE [dbo].[playlist]  WITH CHECK ADD  CONSTRAINT [fk_track_playlist] FOREIGN KEY([PlayListTrackId])
REFERENCES [dbo].[track] ([TrackId])
GO
ALTER TABLE [dbo].[playlist] CHECK CONSTRAINT [fk_track_playlist]
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
ALTER TABLE [dbo].[track]  WITH CHECK ADD  CONSTRAINT [fk_plalist_track] FOREIGN KEY([PlayListTrackId])
REFERENCES [dbo].[playlist] ([PlayListId])
GO
ALTER TABLE [dbo].[track] CHECK CONSTRAINT [fk_plalist_track]
GO
