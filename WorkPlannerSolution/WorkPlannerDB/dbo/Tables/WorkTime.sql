CREATE TABLE [dbo].[Worktime] (
    [WorkTimeID] INT      NOT NULL IDENTITY,
    [EmployeeID] INT      NOT NULL,
    [Date]       DATETIME NOT NULL,
    [TimeStart]       DATETIME NOT NULL,
    [TimeEnd] DATETIME NOT NULL, 
    PRIMARY KEY CLUSTERED ([WorkTimeID] ASC),
    CONSTRAINT [EmployeeIDFK] FOREIGN KEY ([EmployeeID]) REFERENCES [dbo].[Employee] ([EmployeeID])
);
