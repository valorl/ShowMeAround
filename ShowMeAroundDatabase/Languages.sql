﻿CREATE TABLE [dbo].[Languages]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [UserID] INT NOT NULL, 
    [Language] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_LANGUAGES_TO_USERS] FOREIGN KEY ([UserID]) REFERENCES [Users]([Id])
)
