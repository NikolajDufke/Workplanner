CREATE TABLE [dbo].[Worktime] (
    [WorkTimeID] INT      NOT NULL,
    [EmployeeID] INT      NOT NULL,
    [Date]       DATETIME NOT NULL,
    [Time]       DATETIME NOT NULL,
    PRIMARY KEY CLUSTERED ([WorkTimeID] ASC),
    CONSTRAINT [EmployeeIDFK] FOREIGN KEY ([EmployeeID]) REFERENCES [dbo].[Employee] ([EmployeeId])
);
