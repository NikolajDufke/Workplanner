CREATE TABLE [dbo].[Employee] (
    [EmployeeId]  INT          NOT NULL,
    [FirstName]   VARCHAR (50) NOT NULL,
    [LastName]    VARCHAR (50) NOT NULL,
    [PhoneNumber] INT          NOT NULL,
    [Email]       VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([EmployeeId] ASC)
);

