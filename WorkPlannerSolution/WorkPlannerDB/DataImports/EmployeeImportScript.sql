DELETE from Worktime
DELETE from Employee
DELETE from Users
DELETE from Access

--DBCC CHECKIDENT ('Users', RESEED,0)
--DBCC CHECKIDENT ('Employee', RESEED,0)
INSERT INTO Access(AccessLevel,AccessDescription) VALUES (1, 'Admin')
INSERT INTO Access(AccessLevel,AccessDescription) VALUES (2, 'User')

DECLARE @OutputTbluser TABLE (ID INT)
DECLARE @OutpusTblemployee TABLE (ID INT)

INSERT INTO Users(UserPassword,AccessLevel)OUTPUT INSERTED.UserId INTO @OutputTbluser(ID) VALUES ('kode1', 1)
INSERT INTO Employee(FirstName,LastName,PhoneNumber,Email,Adress,City,ZipPostal, UserID)OUTPUT INSERTED.EmployeeID INTO @OutpusTblemployee(ID) VALUES ('Benjamin', 'Sørensen', 23232323, 'Benjamin@WorkPlanner.dk', 'Bredager 8', 'Greve', 2670, (SELECT ID from @OutputTbluser))
DELETE FROM @OutputTbluser

INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20191230 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20191230 15:30:00 PM','20191230 10:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20191231 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20191231 15:30:00 PM','20191231 10:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200101 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200101 16:30:00 PM','20200101 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200102 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200102 18:30:00 PM','20200102 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200103 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200103 19:30:00 PM','20200103 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200104 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200104 11:30:00 PM','20200104 09:30:00 AM')

INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200105 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200105 15:30:00 PM','20200105 10:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200106 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200106 15:30:00 PM','20200106 10:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200107 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200107 16:30:00 PM','20200107 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200108 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200108 18:30:00 PM','20200108 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200109 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200109 19:30:00 PM','20200109 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200110 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200110 11:30:00 PM','20200110 09:30:00 AM')

INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200111 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200111 15:30:00 PM','20200111 10:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200112 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200112 15:30:00 PM','20200112 10:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200113 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200113 16:30:00 PM','20200113 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200114 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200114 18:30:00 PM','20200114 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200115 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200115 19:30:00 PM','20200115 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200116 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200116 11:30:00 PM','20200116 09:30:00 AM')

DELETE FROM @OutpusTblemployee

INSERT INTO Users(UserPassword,AccessLevel)OUTPUT INSERTED.UserId INTO @OutputTbluser(ID) VALUES ('kode2', 2)
INSERT INTO Employee(FirstName,LastName,PhoneNumber,Email,Adress,City,ZipPostal, UserID)OUTPUT INSERTED.EmployeeID INTO @OutpusTblemployee(ID) VALUES ('Nikolaj', 'Dufke', 24242424, 'Nikolaj@WorkPlanner.dk', 'højre 2', 'Taastrup', 2630, (SELECT ID from @OutputTbluser))
DELETE FROM @OutputTbluser

INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20191230 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20191230 15:30:00 PM','20191230 10:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20191231 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20191231 15:30:00 PM','20191231 10:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200101 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200101 16:30:00 PM','20200101 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200102 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200102 18:30:00 PM','20200102 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200103 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200103 19:30:00 PM','20200103 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200104 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200104 11:30:00 PM','20200104 09:30:00 AM')

INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200105 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200105 15:30:00 PM','20200105 10:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200106 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200106 15:30:00 PM','20200106 10:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200107 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200107 16:30:00 PM','20200107 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200108 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200108 18:30:00 PM','20200108 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200109 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200109 19:30:00 PM','20200109 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200110 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200110 11:30:00 PM','20200110 09:30:00 AM')

INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200111 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200111 15:30:00 PM','20200111 10:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200112 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200112 15:30:00 PM','20200112 10:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200113 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200113 16:30:00 PM','20200113 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200114 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200114 18:30:00 PM','20200114 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200115 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200115 19:30:00 PM','20200115 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200116 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200116 11:30:00 PM','20200116 09:30:00 AM')

DELETE FROM @OutpusTblemployee

INSERT INTO Users(UserPassword,AccessLevel)OUTPUT INSERTED.UserId INTO @OutputTbluser(ID) VALUES ('kode3', 1)
INSERT INTO Employee(FirstName,LastName,PhoneNumber,Email,Adress,City,ZipPostal, UserID)OUTPUT INSERTED.EmployeeID INTO @OutpusTblemployee(ID) VALUES ('Sarah', 'Waest', 25252525, 'Sarah@WorkPlanner.dk', 'Ageren 112', 'Næstved', 4700, (SELECT ID from @OutputTbluser))
DELETE FROM @OutputTbluser

INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20191230 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20191230 15:30:00 PM','20191230 10:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20191231 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20191231 15:30:00 PM','20191231 10:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200101 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200101 16:30:00 PM','20200101 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200102 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200102 18:30:00 PM','20200102 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200103 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200103 19:30:00 PM','20200103 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200104 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200104 11:30:00 PM','20200104 09:30:00 AM')

INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200105 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200105 15:30:00 PM','20200105 10:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200106 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200106 15:30:00 PM','20200106 10:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200107 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200107 16:30:00 PM','20200107 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200108 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200108 18:30:00 PM','20200108 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200109 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200109 19:30:00 PM','20200109 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200110 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200110 11:30:00 PM','20200110 09:30:00 AM')

INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200111 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200111 15:30:00 PM','20200111 10:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200112 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200112 15:30:00 PM','20200112 10:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200113 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200113 16:30:00 PM','20200113 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200114 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200114 18:30:00 PM','20200114 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200115 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200115 19:30:00 PM','20200115 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200116 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200116 11:30:00 PM','20200116 09:30:00 AM')

DELETE FROM @OutpusTblemployee

INSERT INTO Users(UserPassword,AccessLevel)OUTPUT INSERTED.UserId INTO @OutputTbluser(ID) VALUES ('kode4', 1)
INSERT INTO Employee(FirstName,LastName,PhoneNumber,Email,Adress,City,ZipPostal, UserID)OUTPUT INSERTED.EmployeeID INTO @OutpusTblemployee(ID) VALUES ('Daniel', 'Palmqvist', 26262626, 'Daniel@WorkPlanner.dk', 'Eriksmindevej 5', 'Greve', 2670, (SELECT ID from @OutputTbluser))
DELETE FROM @OutputTbluser

INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20191230 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20191230 15:30:00 PM','20191230 10:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20191231 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20191231 15:30:00 PM','20191231 10:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200101 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200101 16:30:00 PM','20200101 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200102 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200102 18:30:00 PM','20200102 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200103 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200103 19:30:00 PM','20200103 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200104 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200104 11:30:00 PM','20200104 09:30:00 AM')

INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200105 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200105 15:30:00 PM','20200105 10:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200106 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200106 15:30:00 PM','20200106 10:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200107 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200107 16:30:00 PM','20200107 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200108 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200108 18:30:00 PM','20200108 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200109 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200109 19:30:00 PM','20200109 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200110 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200110 11:30:00 PM','20200110 09:30:00 AM')

INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200111 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200111 15:30:00 PM','20200111 10:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200112 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200112 15:30:00 PM','20200112 10:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200113 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200113 16:30:00 PM','20200113 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200114 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200114 18:30:00 PM','20200114 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200115 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200115 19:30:00 PM','20200115 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200116 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200116 11:30:00 PM','20200116 09:30:00 AM')

DELETE FROM @OutpusTblemployee

INSERT INTO Users(UserPassword,AccessLevel)OUTPUT INSERTED.UserId INTO @OutputTbluser(ID) VALUES ('kode5', 1)
INSERT INTO Employee(FirstName,LastName,PhoneNumber,Email,Adress,City,ZipPostal, UserID)OUTPUT INSERTED.EmployeeID INTO @OutpusTblemployee(ID) VALUES ('Mohammed', 'El-Ali', 27272727, 'Mohammed@WorkPlanner.dk', 'Askerød 1125', 'Greve', 2670, (SELECT ID from @OutputTbluser))
DELETE FROM @OutputTbluser

INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20191230 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20191230 15:30:00 PM','20191230 10:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20191231 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20191231 15:30:00 PM','20191231 10:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200101 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200101 16:30:00 PM','20200101 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200102 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200102 18:30:00 PM','20200102 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200103 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200103 19:30:00 PM','20200103 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200104 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200104 11:30:00 PM','20200104 09:30:00 AM')

INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200105 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200105 15:30:00 PM','20200105 10:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200106 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200106 15:30:00 PM','20200106 10:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200107 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200107 16:30:00 PM','20200107 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200108 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200108 18:30:00 PM','20200108 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200109 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200109 19:30:00 PM','20200109 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200110 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200110 11:30:00 PM','20200110 09:30:00 AM')

INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200111 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200111 15:30:00 PM','20200111 10:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200112 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200112 15:30:00 PM','20200112 10:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200113 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200113 16:30:00 PM','20200113 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200114 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200114 18:30:00 PM','20200114 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200115 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200115 19:30:00 PM','20200115 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200116 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200116 11:30:00 PM','20200116 09:30:00 AM')

DELETE FROM @OutpusTblemployee

INSERT INTO Users(UserPassword,AccessLevel)OUTPUT INSERTED.UserId INTO @OutputTbluser(ID) VALUES ('kode6', 1)
INSERT INTO Employee(FirstName,LastName,PhoneNumber,Email,Adress,City,ZipPostal, UserID)OUTPUT INSERTED.EmployeeID INTO @OutpusTblemployee(ID) VALUES ('Charlotte', 'Heegaard', 28282828, 'Charlotte@WorkPlanner.dk', 'Vordinborgvej 27', 'København', 2300, (SELECT ID from @OutputTbluser))
DELETE FROM @OutputTbluser

INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20191230 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20191230 15:30:00 PM','20191230 10:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20191231 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20191231 15:30:00 PM','20191231 10:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200101 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200101 16:30:00 PM','20200101 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200102 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200102 18:30:00 PM','20200102 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200103 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200103 19:30:00 PM','20200103 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200104 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200104 11:30:00 PM','20200104 09:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200105 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200105 15:30:00 PM','20200105 10:30:00 AM')

INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200106 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200106 15:30:00 PM','20200106 10:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200107 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200107 16:30:00 PM','20200107 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200108 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200108 18:30:00 PM','20200108 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200109 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200109 19:30:00 PM','20200109 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200110 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200110 11:30:00 PM','20200110 09:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200111 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200111 15:30:00 PM','20200111 10:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200112 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200112 15:30:00 PM','20200112 10:30:00 AM')

INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200113 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200113 16:30:00 PM','20200113 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200114 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200114 18:30:00 PM','20200114 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200115 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200115 19:30:00 PM','20200115 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200116 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200116 11:30:00 PM','20200116 09:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200117 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200117 19:30:00 PM','20200117 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200118 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200118 11:30:00 PM','20200118 09:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20200119 00:00:00 AM',(SELECT ID from @OutpusTblemployee),'20200119 11:30:00 PM','20200119 09:30:00 AM')

DELETE FROM @OutpusTblemployee
