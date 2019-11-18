CREATE TABLE [dbo].[EmployeeInformation] (
    [EInformationID] INT NOT NULL IDENTITY,
    [FirstName]      VARCHAR (50) NOT NULL,
    [LastName]       VARCHAR (50) NOT NULL,
    [PhoneNumber]    INT          NOT NULL,
    [Email]          VARCHAR (50) NOT NULL,
    [Adress]         VARCHAR (50) NOT NULL,
    [City]           VARCHAR (50) NOT NULL,
    [ZipPostal]      INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([EInformationID] ASC)
);