USE [Library]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 16.10.2017 21:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[BookId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](140) NOT NULL,
	[Author] [nvarchar](80) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[NumberOfPages] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[BookingDate] [datetime] NULL,
	[EndBookingDate] [datetime] NULL,
	[BorrowingDate] [datetime] NULL,
	[ReturnDate] [datetime] NULL,
	[UserId] [nvarchar](128) NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Books] ON 
GO
INSERT [dbo].[Books] ([BookId], [Title], [Author], [Type], [NumberOfPages], [Status], [BookingDate], [EndBookingDate], [BorrowingDate], [ReturnDate], [UserId]) VALUES (1, N'Azazel', N'Boris Akunin', N'Crime', 224, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Books] ([BookId], [Title], [Author], [Type], [NumberOfPages], [Status], [BookingDate], [EndBookingDate], [BorrowingDate], [ReturnDate], [UserId]) VALUES (2, N'Gambit turecki', N'Boris Akunin', N'Crime', 200, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Books] ([BookId], [Title], [Author], [Type], [NumberOfPages], [Status], [BookingDate], [EndBookingDate], [BorrowingDate], [ReturnDate], [UserId]) VALUES (3, N'Lewiatan', N'Boris Akunin', N'Crime', 208, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Books] ([BookId], [Title], [Author], [Type], [NumberOfPages], [Status], [BookingDate], [EndBookingDate], [BorrowingDate], [ReturnDate], [UserId]) VALUES (4, N'Śmierć Achillesa', N'Boris Akunin', N'Crime', 304, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Books] ([BookId], [Title], [Author], [Type], [NumberOfPages], [Status], [BookingDate], [EndBookingDate], [BorrowingDate], [ReturnDate], [UserId]) VALUES (5, N'Walet pikowy', N'Boris Akunin', N'Crime', 144, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Books] ([BookId], [Title], [Author], [Type], [NumberOfPages], [Status], [BookingDate], [EndBookingDate], [BorrowingDate], [ReturnDate], [UserId]) VALUES (6, N'Dekorator', N'Boris Akunin', N'Crime', 192, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Books] ([BookId], [Title], [Author], [Type], [NumberOfPages], [Status], [BookingDate], [EndBookingDate], [BorrowingDate], [ReturnDate], [UserId]) VALUES (7, N'Radca stanu', N'Boris Akunin', N'Crime', 336, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Books] ([BookId], [Title], [Author], [Type], [NumberOfPages], [Status], [BookingDate], [EndBookingDate], [BorrowingDate], [ReturnDate], [UserId]) VALUES (8, N'Koronacja', N'Boris Akunin', N'Crime', 334, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Books] ([BookId], [Title], [Author], [Type], [NumberOfPages], [Status], [BookingDate], [EndBookingDate], [BorrowingDate], [ReturnDate], [UserId]) VALUES (9, N'Kochanka Śmierci', N'Boris Akunin', N'Crime', 254, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Books] ([BookId], [Title], [Author], [Type], [NumberOfPages], [Status], [BookingDate], [EndBookingDate], [BorrowingDate], [ReturnDate], [UserId]) VALUES (10, N'Kochanek Śmierci', N'Boris Akunin', N'Crime', 303, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Books] ([BookId], [Title], [Author], [Type], [NumberOfPages], [Status], [BookingDate], [EndBookingDate], [BorrowingDate], [ReturnDate], [UserId]) VALUES (11, N'Diamentowa karoca 1', N'Boris Akunin', N'Crime', 176, 1, NULL, NULL, NULL, CAST(N'2018-03-29T00:00:00.000' AS DateTime), NULL)
GO
INSERT [dbo].[Books] ([BookId], [Title], [Author], [Type], [NumberOfPages], [Status], [BookingDate], [EndBookingDate], [BorrowingDate], [ReturnDate], [UserId]) VALUES (12, N'Diamentowa karoca 2', N'Boris Akunin', N'Crime', 544, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Books] ([BookId], [Title], [Author], [Type], [NumberOfPages], [Status], [BookingDate], [EndBookingDate], [BorrowingDate], [ReturnDate], [UserId]) VALUES (13, N'Nefrytowy różaniec', N'Boris Akunin', N'Crime', 656, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Books] ([BookId], [Title], [Author], [Type], [NumberOfPages], [Status], [BookingDate], [EndBookingDate], [BorrowingDate], [ReturnDate], [UserId]) VALUES (14, N'Świat jest teatrem', N'Boris Akunin', N'Crime', 432, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Books] ([BookId], [Title], [Author], [Type], [NumberOfPages], [Status], [BookingDate], [EndBookingDate], [BorrowingDate], [ReturnDate], [UserId]) VALUES (15, N'Czarne miasto', N'Boris Akunin', N'Crime', 424, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Books] ([BookId], [Title], [Author], [Type], [NumberOfPages], [Status], [BookingDate], [EndBookingDate], [BorrowingDate], [ReturnDate], [UserId]) VALUES (16, N'Planeta Woda', N'Boris Akunin', N'Crime', 472, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Books] ([BookId], [Title], [Author], [Type], [NumberOfPages], [Status], [BookingDate], [EndBookingDate], [BorrowingDate], [ReturnDate], [UserId]) VALUES (17, N'Mężczyźni, którzy nienawidzą kobiet', N'Stieg Larsson', N'Crime', 640, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Books] ([BookId], [Title], [Author], [Type], [NumberOfPages], [Status], [BookingDate], [EndBookingDate], [BorrowingDate], [ReturnDate], [UserId]) VALUES (18, N'Dziewczyna, która igrała z ogniem', N'Stieg Larsson', N'Crime', 704, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Books] ([BookId], [Title], [Author], [Type], [NumberOfPages], [Status], [BookingDate], [EndBookingDate], [BorrowingDate], [ReturnDate], [UserId]) VALUES (19, N'Zamek z piasku, który runął', N'Stieg Larsson', N'Crime', 784, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Books] ([BookId], [Title], [Author], [Type], [NumberOfPages], [Status], [BookingDate], [EndBookingDate], [BorrowingDate], [ReturnDate], [UserId]) VALUES (20, N'Sługa Korony', N'Brian McClellan', N'Fantasy', 556, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Books] ([BookId], [Title], [Author], [Type], [NumberOfPages], [Status], [BookingDate], [EndBookingDate], [BorrowingDate], [ReturnDate], [UserId]) VALUES (21, N'Toy Wars', N'Andrzej Ziemiański', N'Fantasy', 578, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Books] ([BookId], [Title], [Author], [Type], [NumberOfPages], [Status], [BookingDate], [EndBookingDate], [BorrowingDate], [ReturnDate], [UserId]) VALUES (22, N'Galeon Wojny', N'Jacek Komuda', N'Fantasy', 688, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Books] ([BookId], [Title], [Author], [Type], [NumberOfPages], [Status], [BookingDate], [EndBookingDate], [BorrowingDate], [ReturnDate], [UserId]) VALUES (23, N'Zdrajca. Seria Akta Dresdena', N'Jim Butcher', N'Fantasy', 576, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Books] ([BookId], [Title], [Author], [Type], [NumberOfPages], [Status], [BookingDate], [EndBookingDate], [BorrowingDate], [ReturnDate], [UserId]) VALUES (24, N'Chłopaki Anansiego', N'Neil Gaiman', N'Fantasy', 352, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Books] ([BookId], [Title], [Author], [Type], [NumberOfPages], [Status], [BookingDate], [EndBookingDate], [BorrowingDate], [ReturnDate], [UserId]) VALUES (25, N'Pieśń o Kruku', N'Paweł Lach', N'Fantasy', 390, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Books] ([BookId], [Title], [Author], [Type], [NumberOfPages], [Status], [BookingDate], [EndBookingDate], [BorrowingDate], [ReturnDate], [UserId]) VALUES (26, N'Szamanka dla umarlaków', N'Martyna Raduchowska', N'Fantasy', 352, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Books] ([BookId], [Title], [Author], [Type], [NumberOfPages], [Status], [BookingDate], [EndBookingDate], [BorrowingDate], [ReturnDate], [UserId]) VALUES (27, N'Królewska Talia', N'Marcin Mortka', N'Fantasy', 510, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Books] ([BookId], [Title], [Author], [Type], [NumberOfPages], [Status], [BookingDate], [EndBookingDate], [BorrowingDate], [ReturnDate], [UserId]) VALUES (28, N'Młody świat', N'Chris Weitz', N'Fantasy', 358, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Books] ([BookId], [Title], [Author], [Type], [NumberOfPages], [Status], [BookingDate], [EndBookingDate], [BorrowingDate], [ReturnDate], [UserId]) VALUES (29, N'Olimp', N'Dan Simmons', N'Fantasy', 969, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Books] ([BookId], [Title], [Author], [Type], [NumberOfPages], [Status], [BookingDate], [EndBookingDate], [BorrowingDate], [ReturnDate], [UserId]) VALUES (30, N'Samozwaniec. Moskiewska ladacznica', N'Jacek Komuda', N'Fantasy', 512, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Books] ([BookId], [Title], [Author], [Type], [NumberOfPages], [Status], [BookingDate], [EndBookingDate], [BorrowingDate], [ReturnDate], [UserId]) VALUES (31, N'Motologia nordycka', N'Neil Gaiman', N'Fantasy', 228, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Books] ([BookId], [Title], [Author], [Type], [NumberOfPages], [Status], [BookingDate], [EndBookingDate], [BorrowingDate], [ReturnDate], [UserId]) VALUES (39, N'Początek', N'Dan Brown', N'Thriller', 576, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Books] ([BookId], [Title], [Author], [Type], [NumberOfPages], [Status], [BookingDate], [EndBookingDate], [BorrowingDate], [ReturnDate], [UserId]) VALUES (40, N'Labirynt duchów', N'Carlos Ruiz Zafon', N'Novel', 896, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Books] ([BookId], [Title], [Author], [Type], [NumberOfPages], [Status], [BookingDate], [EndBookingDate], [BorrowingDate], [ReturnDate], [UserId]) VALUES (41, N'Theodore Boone: Zbieg', N'John Grisham', N'Thriller', 256, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Books] ([BookId], [Title], [Author], [Type], [NumberOfPages], [Status], [BookingDate], [EndBookingDate], [BorrowingDate], [ReturnDate], [UserId]) VALUES (42, N'Młody świat', N'Chris Weitz', N'Fantasy', 358, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Books] ([BookId], [Title], [Author], [Type], [NumberOfPages], [Status], [BookingDate], [EndBookingDate], [BorrowingDate], [ReturnDate], [UserId]) VALUES (45, N'Silos. Trylogia Silos. Tom 1', N'Hugh Howey', N'Fantasy', 658, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Books] ([BookId], [Title], [Author], [Type], [NumberOfPages], [Status], [BookingDate], [EndBookingDate], [BorrowingDate], [ReturnDate], [UserId]) VALUES (49, N'Pył. Trylogia Silos. Tom 3', N'Hugh Howey', N'Fantasy', 496, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Books] ([BookId], [Title], [Author], [Type], [NumberOfPages], [Status], [BookingDate], [EndBookingDate], [BorrowingDate], [ReturnDate], [UserId]) VALUES (50, N'Na krawędzi wszystkiego', N'Jeff Giles', N'Adventure', 382, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Books] ([BookId], [Title], [Author], [Type], [NumberOfPages], [Status], [BookingDate], [EndBookingDate], [BorrowingDate], [ReturnDate], [UserId]) VALUES (51, N'Rycerze pożyczonego mroku', N'Dave Rudden', N'Fantasy', 310, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Books] ([BookId], [Title], [Author], [Type], [NumberOfPages], [Status], [BookingDate], [EndBookingDate], [BorrowingDate], [ReturnDate], [UserId]) VALUES (48, N'Zmiana. Trylogia Silos. Tom 2', N'Hugh Howey', N'Fantasy', 638, 1, NULL, NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Books] OFF
GO
