-- Creating the database
CREATE DATABASE HospitalManagement
GO

USE HospitalManagement
GO

set dateformat dmy
go

---- Table User (Tài khoản)
-- Giải thích : Lưu thông tin tài khoản (admin, bác sĩ, bệnh nhân, v.v.), với mật khẩu được mã hóa (PasswordHash)



CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username VARCHAR(50) NOT NULL UNIQUE,
    PasswordHash VARCHAR(255) NOT NULL,
    FullName NVARCHAR(100) NOT NULL,
    Email VARCHAR(100) UNIQUE,
    Role VARCHAR(20) NOT NULL CHECK (Role IN ('Admin', 'Doctor', 'Nurse', 'Receptionist')),
    CreatedAt DATETIME DEFAULT GETDATE(),
	Address NVARCHAR(255),
    IsActive BIT DEFAULT 1 --Xác định tài khoản có đang hoạt động hay bị vô hiệu hóa (1 là hoạt động, 0 là vô hiệu hóa)
)
go

---- Table for Department (Khoa)
--Giải thích: Quản lý các khoa trong bệnh viện.
CREATE TABLE Department (
    DepartmentID INT PRIMARY KEY IDENTITY(1,1),
    DepartmentName NVARCHAR(100) NOT NULL UNIQUE,
    Description NVARCHAR(255)
)
go

---- Table for Doctor (Bác sĩ)
-- Giải thích: Lưu thông tin bác sĩ, liên kết với Users (Tài khoản) và Department (Khoa)
CREATE TABLE Doctor (
    DoctorID char(10) PRIMARY KEY,
    UserID INT NOT NULL,
    DepartmentID INT NOT NULL,
    Specialty NVARCHAR(100),
    Phone VARCHAR(15),
	Address NVARCHAR(255), 
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    FOREIGN KEY (DepartmentID) REFERENCES Department(DepartmentID)
)
go

-- Table for Doctor Qualifications (Bằng cấp bác sĩ)
-- Giải thích: Lưu các bằng cấp cho Doctor (Vì 1 doctor bằng buộc phải ít nhất 1 bằng cấp và có thể có nhiều)
CREATE TABLE DoctorQualifications (
    QualificationID INT PRIMARY KEY IDENTITY(1,1),
    DoctorID char(10) NOT NULL,
    QualificationName NVARCHAR(100) NOT NULL,
    IssuingOrganization NVARCHAR(100),
    IssueDate DATE,
    FOREIGN KEY (DoctorID) REFERENCES Doctor(DoctorID)
)
go

-- Table for Patient (Bệnh nhân)
-- Giải thích: Lưu thông tin bệnh nhân, liên kết với Users.
CREATE TABLE Patient (
    PatientID char(10) PRIMARY KEY,
    DateOfBirth DATE,
    Gender VARCHAR(10) CHECK (Gender IN ('Male', 'Female', 'Other')),
    Address NVARCHAR(255),
	Weight float check (Weight >0),
	Height float check (Height >0),
    Phone VARCHAR(15),
	Role nvarchar(25) check (Role in ('Outpatient', 'Inpatient')),
	DoctorID char(10) not null,
	Foreign key (DoctorID) REFERENCES Doctor(DoctorID)
)
go

----Table for Nurse
-- Giải thích: Quản lý thông tin nhân viên điều dưỡng
CREATE TABLE Nurse
(
	NurseID char(10) PRIMARY KEY,
    UserID INT NOT NULL,
    DepartmentID INT NOT NULL,
    Phone VARCHAR(15),
	Address NVARCHAR(255), 
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    FOREIGN KEY (DepartmentID) REFERENCES Department(DepartmentID)
)
--Table for Room
---- Giải thích: bảng quản lý thông tin phòng
CREATE TABLE ROOM
(
	RoomID char(10) primary key,
	RoomName nvarchar(100) UNIQUE,
	NumberBed int default(0),

)
go

--Table for Shift
---- Giải thích : bảng quản lý thông tin phân công điều dưỡng
Create table ShiftNurse
(
	ShiftNurse int primary key identity(1,1),
	ShiftType VARCHAR(50) check (ShiftType in ('Morning', 'Afternoon', 'Evening')),
	NurseID char(10) not null,
	ShiftDate date not null,
	StartTime time not null,
	EndTime time not null,
	Notes nvarchar(255),
	FOREIGN KEY (NurseID) REFERENCES Nurse(NurseID)
)

create table Room_ShiftNurse
(
	RoomID char(10),
	ShiftNurse int,
	primary key(RoomID, ShiftNurse),
	FOREIGN KEY (RoomID) REFERENCES Room(RoomID),
	FOREIGN KEY (ShiftNurse) REFERENCES ShiftNurse(ShiftNurse)
)

---- Table for Appointment (Lịch hẹn)
-- Giải thích: Quản lý lịch hẹn, liên kết với Patient và Doctor.
CREATE TABLE Appointment 
(
    AppointmentID INT PRIMARY KEY IDENTITY(1,1),
    PatientID CHAR(10) NOT NULL,
    DoctorID CHAR(10) NOT NULL,
    AppointmentDate DATETIME NOT NULL,
    Status VARCHAR(20) CHECK (Status IN ('Scheduled', 'Completed', 'Cancelled')),
    Notes NVARCHAR(500),
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (PatientID) REFERENCES Patient(PatientID),
    FOREIGN KEY (DoctorID) REFERENCES Doctor(DoctorID)
)
go


--USE master;
--ALTER DATABASE HospitalManagement SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
--DROP DATABASE HospitalManagement;