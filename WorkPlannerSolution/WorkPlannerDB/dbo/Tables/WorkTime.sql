CREATE TABLE [dbo].[Worktime] (
    [WorkTimeID] INT      NOT NULL IDENTITY,
    [EInformationID] INT      NOT NULL,
    [Date]       DATETIME NOT NULL,
    [TimeStart]       DATETIME NOT NULL,
    [TimeEnd] DATETIME NOT NULL, 
    PRIMARY KEY CLUSTERED ([WorkTimeID] ASC),
    CONSTRAINT [EmployeeInformationIDFK] FOREIGN KEY ([EInformationID]) REFERENCES [dbo].[EmployeeInformation] ([EInformationID])
);
