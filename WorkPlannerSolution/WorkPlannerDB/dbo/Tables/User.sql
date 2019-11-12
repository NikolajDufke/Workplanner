CREATE TABLE [dbo].[User] (
    [UserID]     INT           NOT NULL,
    [EmployeeID] INT           NOT NULL,
    [Password]   NVARCHAR (50) NOT NULL,
    [Access]     INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([UserID] ASC)
);

