USE [BDReportes]
GO

/****** Object:  Table [dbo].[Accesos]    Script Date: 06/02/2026 03:19:45 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Accesos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userAccess] [nchar](25) NULL,
	[passwordAccess] [nchar](25) NULL,
	[rollAccess] [nchar](50) NOT NULL,
	[tokenAccess] [nvarchar](max) NOT NULL,
	[nameUser] [nchar](10) NOT NULL,
	[emailUser] [nchar](90) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Accesos] ADD  CONSTRAINT [DF_Accesos_rollAccess]  DEFAULT ('') FOR [rollAccess]
GO

ALTER TABLE [dbo].[Accesos] ADD  CONSTRAINT [DF_Accesos_tokenAccess]  DEFAULT ('') FOR [tokenAccess]
GO

ALTER TABLE [dbo].[Accesos] ADD  CONSTRAINT [DF_Table_1_Name]  DEFAULT ('') FOR [nameUser]
GO

ALTER TABLE [dbo].[Accesos] ADD  CONSTRAINT [DF_Table_1_Email]  DEFAULT ('') FOR [emailUser]
GO


