DELETE from Employee
DELETE from EmployeeInformation
DELETE from Users
DELETE from Access


--TRUNCATE table Employee
--TRUNCATE table EmployeeInformation
--TRUNCATE table Users
--TRUNCATE table Access

--DBCC CHECKIDENT ('Users', RESEED,0)
--DBCC CHECKIDENT ('Employee', RESEED,0)
--DBCC CHECKIDENT ('EmployeeInformation', RESEED,0)

INSERT INTO EmployeeInformation(FirstName,LastName,PhoneNumber,Email,Adress,City,ZipPostal) VALUES ('Benjamin', 'Sørensen', 23232323, 'Benjamin@WorkPlanner.dk', 'Avej', 'Aby', 1234)
INSERT INTO EmployeeInformation(FirstName,LastName,PhoneNumber,Email,Adress,City,ZipPostal) VALUES ('Nikolaj', 'Dufke', 24242424, 'Nikolaj@WorkPlanner.dk', 'Bvej', 'Bby', 2345)
INSERT INTO EmployeeInformation(FirstName,LastName,PhoneNumber,Email,Adress,City,ZipPostal) VALUES ('Sarah', 'Waest', 25252525, 'Sarah@WorkPlanner.dk', 'Bvej', 'Bby', 2345)
INSERT INTO EmployeeInformation(FirstName,LastName,PhoneNumber,Email,Adress,City,ZipPostal) VALUES ('Daniel', 'Palmqvist', 26262626, 'Daniel@WorkPlanner.dk', 'Cvej', 'Cby', 3456)
INSERT INTO EmployeeInformation(FirstName,LastName,PhoneNumber,Email,Adress,City,ZipPostal) VALUES ('Mohammed', 'El-Ali', 27272727, 'Mohammed@WorkPlanner.dk', 'Dvej', 'Dby', 4567)
INSERT INTO EmployeeInformation(FirstName,LastName,PhoneNumber,Email,Adress,City,ZipPostal) VALUES ('Charlotte', 'Something', 28282828, 'Charlotte@WorkPlanner.dk', 'Evej', 'Eby', 5678)

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

INSERT INTO Employee(UserID,EInformationID) VALUES (1,1)
INSERT INTO Employee(UserID,EInformationID) VALUES (2,2)
INSERT INTO Employee(UserID,EInformationID) VALUES (3,3)
INSERT INTO Employee(UserID,EInformationID) VALUES (4,4)
INSERT INTO Employee(UserID,EInformationID) VALUES (5,5)
INSERT INTO Employee(UserID,EInformationID) VALUES (6,6)