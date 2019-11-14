CREATE TABLE [dbo].[Access] (
    [AccessLevel]       INT        NOT NULL,
    [AccessDescription] NCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([AccessLevel] ASC)
);

