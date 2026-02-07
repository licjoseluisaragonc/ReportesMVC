USE [master]
GO

/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [examen]    Script Date: 06/02/2026 03:14:54 p. m. ******/
CREATE LOGIN [examen] WITH PASSWORD=N'IZteQBYStndS3XerfXLyZu+/pxPqu3xq2FkLtb8/VgI=', DEFAULT_DATABASE=[BDReportes], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=ON, CHECK_POLICY=ON
GO

ALTER LOGIN [examen] DISABLE
GO

ALTER SERVER ROLE [sysadmin] ADD MEMBER [examen]
GO

ALTER SERVER ROLE [securityadmin] ADD MEMBER [examen]
GO

ALTER SERVER ROLE [serveradmin] ADD MEMBER [examen]
GO

ALTER SERVER ROLE [setupadmin] ADD MEMBER [examen]
GO

ALTER SERVER ROLE [processadmin] ADD MEMBER [examen]
GO

ALTER SERVER ROLE [diskadmin] ADD MEMBER [examen]
GO

ALTER SERVER ROLE [dbcreator] ADD MEMBER [examen]
GO

ALTER SERVER ROLE [bulkadmin] ADD MEMBER [examen]
GO

ALTER SERVER ROLE [##MS_ServerStateReader##] ADD MEMBER [examen]
GO

ALTER SERVER ROLE [##MS_ServerStateManager##] ADD MEMBER [examen]
GO

ALTER SERVER ROLE [##MS_DefinitionReader##] ADD MEMBER [examen]
GO

ALTER SERVER ROLE [##MS_DatabaseConnector##] ADD MEMBER [examen]
GO

ALTER SERVER ROLE [##MS_DatabaseManager##] ADD MEMBER [examen]
GO

ALTER SERVER ROLE [##MS_LoginManager##] ADD MEMBER [examen]
GO

ALTER SERVER ROLE [##MS_SecurityDefinitionReader##] ADD MEMBER [examen]
GO

ALTER SERVER ROLE [##MS_PerformanceDefinitionReader##] ADD MEMBER [examen]
GO

ALTER SERVER ROLE [##MS_ServerSecurityStateReader##] ADD MEMBER [examen]
GO

ALTER SERVER ROLE [##MS_ServerPerformanceStateReader##] ADD MEMBER [examen]
GO


