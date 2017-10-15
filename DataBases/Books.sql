USE [Library]
GO

/****** Object:  Table [dbo].[Books]    Script Date: 15.10.2017 19:28:01 ******/
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

