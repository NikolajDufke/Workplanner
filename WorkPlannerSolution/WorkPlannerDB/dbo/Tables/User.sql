CREATE TABLE [dbo].[User] (
    [UserID]     INT           NOT NULL,
    [Password]   NVARCHAR (50) NOT NULL,
    [AccessLevel]     INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([UserID] ASC), 
    CONSTRAINT [FK_User_Access] FOREIGN KEY ([AccessLevel]) REFERENCES [Access]([AccessLevel]), 
);

