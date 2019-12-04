DELETE from Employee
DELETE from Users
DELETE from Access
DELETE from Worktime
--TRUNCATE table Employee
--TRUNCATE table Users
--TRUNCATE table Access

--DBCC CHECKIDENT ('Users', RESEED,0)
--DBCC CHECKIDENT ('Employee', RESEED,0)

INSERT INTO Employee(FirstName,LastName,PhoneNumber,Email,Adress,City,ZipPostal) VALUES ('Benjamin', 'Sørensen', 23232323, 'Benjamin@WorkPlanner.dk', 'Avej', 'Aby', 1234)
INSERT INTO Employee(FirstName,LastName,PhoneNumber,Email,Adress,City,ZipPostal) VALUES ('Nikolaj', 'Dufke', 24242424, 'Nikolaj@WorkPlanner.dk', 'Bvej', 'Bby', 2345)
INSERT INTO Employee(FirstName,LastName,PhoneNumber,Email,Adress,City,ZipPostal) VALUES ('Sarah', 'Waest', 25252525, 'Sarah@WorkPlanner.dk', 'Bvej', 'Bby', 2345)
INSERT INTO Employee(FirstName,LastName,PhoneNumber,Email,Adress,City,ZipPostal) VALUES ('Daniel', 'Palmqvist', 26262626, 'Daniel@WorkPlanner.dk', 'Cvej', 'Cby', 3456)
INSERT INTO Employee(FirstName,LastName,PhoneNumber,Email,Adress,City,ZipPostal) VALUES ('Mohammed', 'El-Ali', 27272727, 'Mohammed@WorkPlanner.dk', 'Dvej', 'Dby', 4567)
INSERT INTO Employee(FirstName,LastName,PhoneNumber,Email,Adress,City,ZipPostal) VALUES ('Charlotte', 'Something', 28282828, 'Charlotte@WorkPlanner.dk', 'Evej', 'Eby', 5678)

INSERT INTO Access(AccessLevel,AccessDescription) VALUES (1, 'Guest')
INSERT INTO Access(AccessLevel,AccessDescription) VALUES (2, 'User')
INSERT INTO Access(AccessLevel,AccessDescription) VALUES (3, 'Admin')
INSERT INTO Access(AccessLevel,AccessDescription) VALUES (4, 'SuperAdmin')

INSERT INTO Users(UserPassword,AccessLevel) VALUES ('kode1',1)
INSERT INTO Users(UserPassword,AccessLevel) VALUES ('kode2',1)
INSERT INTO Users(UserPassword,AccessLevel) VALUES ('kode3',1)
INSERT INTO Users(UserPassword,AccessLevel) VALUES ('kode4',2)
INSERT INTO Users(UserPassword,AccessLevel) VALUES ('kode5',3)
INSERT INTO Users(UserPassword,AccessLevel) VALUES ('kode6',1)


INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20191203 00:00:00 AM',1,'20191203 11:30:00 AM','20191203 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20191204 00:00:00 AM',1,'20191204 11:30:00 AM','20191204 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20191205 00:00:00 AM',1,'20191205 11:30:00 AM','20191205 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20191206 00:00:00 AM',1,'20191206 11:30:00 AM','20191206 08:30:00 AM')

INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20190312 00:00:00 AM',2,'20190312 11:30:00 AM','20190312 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20190412 00:00:00 AM',2,'20190412 04:30:00 PM','20190412 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20190512 00:00:00 AM',2,'20190512 11:30:00 AM','20190512 08:30:00 AM')
INSERT INTO Worktime(Date,EmployeeID,TimeEnd,TimeStart) VALUES('20190612 00:00:00 AM',2,'20190612 11:30:00 AM','20190612 08:30:00 AM')