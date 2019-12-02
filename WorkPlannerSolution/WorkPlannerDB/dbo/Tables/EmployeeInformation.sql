CREATE TABLE [dbo].[Employee] (
    [EmployeeID] INT NOT NULL IDENTITY,
    [FirstName]      VARCHAR (50) NOT NULL,
    [LastName]       VARCHAR (50) NOT NULL,
    [PhoneNumber]    INT          NULL,
    [Email]          VARCHAR (50) NULL,
    [Adress]         VARCHAR (50) NULL,
    [City]           VARCHAR (50) NULL,
    [ZipPostal]      INT          NULL, 
    [UserID] INT NULL, 
    CONSTRAINT [PK_Employee] PRIMARY KEY ([EmployeeID]), 
    CONSTRAINT [FK_Employee_User] FOREIGN KEY (UserID) REFERENCES [Users]([UserID]),

);