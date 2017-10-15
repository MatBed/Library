USE [Library]
GO

/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 15.10.2017 19:27:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[SecondName] [nvarchar](max) NULL,
	[NumberOfBooks] [tinyint] NULL,
	[Discriminator] [nvarchar](128) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

