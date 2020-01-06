CREATE DATABASE WorkPlannerDB;
GO
use WorkPlannerDB;

CREATE TABLE [dbo].[Access] (
    [AccessLevel]       INT        NOT NULL,
    [AccessDescription] NCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([AccessLevel] ASC)
);

CREATE TABLE [dbo].[Users] (
    [UserID]       INT           IDENTITY (1, 1) NOT NULL,
    [UserPassword] NVARCHAR (50) NOT NULL,
    [AccessLevel]  INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([UserID] ASC),
    CONSTRAINT [FK_User_Access] FOREIGN KEY ([AccessLevel]) REFERENCES [dbo].[Access] ([AccessLevel])
);

CREATE TABLE [dbo].[Employee] (
    [EmployeeID]  INT          IDENTITY (1, 1) NOT NULL,
    [FirstName]   VARCHAR (50) NOT NULL,
    [LastName]    VARCHAR (50) NOT NULL,
    [PhoneNumber] INT          NULL,
    [Email]       VARCHAR (50) NULL,
    [Adress]      VARCHAR (50) NULL,
    [City]        VARCHAR (50) NULL,
    [ZipPostal]   INT          NULL,
    [UserID]      INT          NULL,
    CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED ([EmployeeID] ASC),
    CONSTRAINT [FK_Employee_User] FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([UserID])
);

CREATE TABLE [dbo].[Worktime] (
    [WorkTimeID] INT      IDENTITY (1, 1) NOT NULL,
    [EmployeeID] INT      NOT NULL,
    [Date]       DATETIME NOT NULL,
    [TimeStart]  DATETIME NOT NULL,
    [TimeEnd]    DATETIME NOT NULL,
    PRIMARY KEY CLUSTERED ([WorkTimeID] ASC),
    CONSTRAINT [EmployeeIDFK] FOREIGN KEY ([EmployeeID]) REFERENCES [dbo].[Employee] ([EmployeeID])
);
GO

INSERT INTO Access(AccessLevel,AccessDescription) VALUES (1, 'Admin')
INSERT INTO Access(AccessLevel,AccessDescription) VALUES (2, 'User')

DECLARE @OutputTbluser TABLE (ID INT)
DECLARE @OutpusTblemployee TABLE (ID INT)

INSERT INTO Users(UserPassword,AccessLevel)OUTPUT INSERTED.UserId INTO @OutputTbluser(ID) VALUES ('kode1', 1)
INSERT INTO Employee(FirstName,LastName,PhoneNumber,Email,Adress,City,ZipPostal, UserID)OUTPUT INSERTED.EmployeeID INTO @OutpusTblemployee(ID) VALUES ('Benjamin', 'Sørensen', 23232323, 'Benjamin@WorkPlanner.dk', 'Avej', 'Aby', 1234, (SELECT ID from @OutputTbluser))
DELETE FROM @OutputTbluser

INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20191202 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20191202 08:30:00 PM','20191202 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20191203 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20191203 11:30:00 AM','20191203 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20191204 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20191204 11:30:00 AM','20191204 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20191205 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20191205 11:30:00 AM','20191205 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20191206 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20191206 11:30:00 AM','20191206 08:30:00 AM')

DELETE FROM @OutpusTblemployee

INSERT INTO Users(UserPassword,AccessLevel)OUTPUT INSERTED.UserId INTO @OutputTbluser(ID) VALUES ('kode2', 2)
INSERT INTO Employee(FirstName,LastName,PhoneNumber,Email,Adress,City,ZipPostal, UserID)OUTPUT INSERTED.EmployeeID INTO @OutpusTblemployee(ID) VALUES ('Nikolaj', 'Dufke', 24242424, 'Nikolaj@WorkPlanner.dk', 'Bvej', 'Bby', 2345, (SELECT ID from @OutputTbluser))
DELETE FROM @OutputTbluser

INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20191202 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20191202 08:30:00 PM','20191202 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20191203 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20191203 11:30:00 AM','20191203 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20191204 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20191204 11:30:00 AM','20191204 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20191205 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20191205 11:30:00 AM','20191205 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20191206 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20191206 11:30:00 AM','20191206 08:30:00 AM')

DELETE FROM @OutpusTblemployee

INSERT INTO Users(UserPassword,AccessLevel)OUTPUT INSERTED.UserId INTO @OutputTbluser(ID) VALUES ('kode3', 1)
INSERT INTO Employee(FirstName,LastName,PhoneNumber,Email,Adress,City,ZipPostal, UserID)OUTPUT INSERTED.EmployeeID INTO @OutpusTblemployee(ID) VALUES ('Sarah', 'Waest', 25252525, 'Sarah@WorkPlanner.dk', 'Bvej', 'Bby', 2345, (SELECT ID from @OutputTbluser))
DELETE FROM @OutputTbluser

INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20191202 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20191202 08:30:00 PM','20191202 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20191203 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20191203 11:30:00 AM','20191203 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20191204 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20191204 11:30:00 AM','20191204 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20191205 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20191205 11:30:00 AM','20191205 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20191206 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20191206 11:30:00 AM','20191206 08:30:00 AM')

DELETE FROM @OutpusTblemployee

INSERT INTO Users(UserPassword,AccessLevel)OUTPUT INSERTED.UserId INTO @OutputTbluser(ID) VALUES ('kode4', 1)
INSERT INTO Employee(FirstName,LastName,PhoneNumber,Email,Adress,City,ZipPostal, UserID)OUTPUT INSERTED.EmployeeID INTO @OutpusTblemployee(ID) VALUES ('Daniel', 'Palmqvist', 26262626, 'Daniel@WorkPlanner.dk', 'Cvej', 'Cby', 3456, (SELECT ID from @OutputTbluser))
DELETE FROM @OutputTbluser
DELETE FROM @OutpusTblemployee

INSERT INTO Users(UserPassword,AccessLevel)OUTPUT INSERTED.UserId INTO @OutputTbluser(ID) VALUES ('kode5', 1)
INSERT INTO Employee(FirstName,LastName,PhoneNumber,Email,Adress,City,ZipPostal, UserID)OUTPUT INSERTED.EmployeeID INTO @OutpusTblemployee(ID) VALUES ('Mohammed', 'El-Ali', 27272727, 'Mohammed@WorkPlanner.dk', 'Dvej', 'Dby', 4567, (SELECT ID from @OutputTbluser))
DELETE FROM @OutputTbluser

INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20191202 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20191202 08:30:00 PM','20191202 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20191203 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20191203 11:30:00 AM','20191203 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20191204 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20191204 11:30:00 AM','20191204 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20191205 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20191205 11:30:00 AM','20191205 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20191206 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20191206 11:30:00 AM','20191206 08:30:00 AM')

DELETE FROM @OutpusTblemployee

INSERT INTO Users(UserPassword,AccessLevel)OUTPUT INSERTED.UserId INTO @OutputTbluser(ID) VALUES ('kode6', 1)
INSERT INTO Employee(FirstName,LastName,PhoneNumber,Email,Adress,City,ZipPostal, UserID)OUTPUT INSERTED.EmployeeID INTO @OutpusTblemployee(ID) VALUES ('Charlotte', 'Something', 28282828, 'Charlotte@WorkPlanner.dk', 'Evej', 'Eby', 5678, (SELECT ID from @OutputTbluser))
DELETE FROM @OutputTbluser

INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20191202 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20191202 08:30:00 PM','20191202 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20191203 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20191203 11:30:00 AM','20191203 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20191204 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20191204 11:30:00 AM','20191204 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20191205 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20191205 11:30:00 AM','20191205 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20191206 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20191206 11:30:00 AM','20191206 08:30:00 AM')

DELETE FROM @OutpusTblemployee
