USE [Library]
GO

/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 15.10.2017 19:27:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL
) ON [PRIMARY]
GO

