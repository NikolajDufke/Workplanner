CREATE TABLE [dbo].[Employee] (
    [EmployeeId]  INT          NOT NULL IDENTITY ,
    [FirstName]   VARCHAR (50) NOT NULL,
    [LastName]    VARCHAR (50) NOT NULL,
    [PhoneNumber] INT          NOT NULL,
    [Email]       VARCHAR (50) NOT NULL,
    [UserID] INT NOT NULL, 
    CONSTRAINT [PK_Employee] PRIMARY KEY ([EmployeeId]), 
    CONSTRAINT [FK_Employee_Users] FOREIGN KEY ([UserID]) REFERENCES [Users]([UserID]), 
    );