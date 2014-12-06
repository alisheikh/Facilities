CREATE TABLE [dbo].[Users]
(
    [Username] VARCHAR(50) NOT NULL primary key, 
    [Password] VARCHAR(50) NOT NULL, 
    [FullName] VARCHAR(150) NULL
)
