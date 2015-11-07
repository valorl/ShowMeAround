CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [Email] NVARCHAR(50) NOT NULL, 
    [BirthDate] DATE NOT NULL, 
    [Password] NVARCHAR(MAX) NOT NULL, 
    [Salt] NVARCHAR(MAX) NOT NULL
)
