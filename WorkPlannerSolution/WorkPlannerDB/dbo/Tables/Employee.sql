CREATE TABLE [dbo].[Employee] (
    [EmployeeId]  INT          NOT NULL IDENTITY ,
    [UserID] INT NOT NULL, 
    [EInformationID] INT NOT NULL, 
    CONSTRAINT [PK_Employee] PRIMARY KEY ([EmployeeId]), 
    CONSTRAINT [FK_Employee_Users] FOREIGN KEY ([UserID]) REFERENCES [Users]([UserID]), 
    CONSTRAINT [FK_Employee_EmployeeInformation] FOREIGN KEY ([EInformationID]) REFERENCES [EmployeeInformation]([EInformationID]), 
    );