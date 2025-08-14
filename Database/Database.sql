-- Creating the database
CREATE DATABASE HospitalManagement
GO

USE HospitalManagement
GO

set dateformat dmy
go

--Table Staff
--Bảng nhân viên
CREATE TABLE Staff (
    id CHAR(10) PRIMARY KEY,
    name NVARCHAR(255) NOT NULL,
    role NVARCHAR(50),
    dob DATE,
    gender NVARCHAR(10) CHECK (gender IN ('Male', 'Female', 'Other')),
    phoneNumber VARCHAR(15),
    email VARCHAR(100),
    homeAddress VARCHAR(255),
    citizenID VARCHAR(12),
    departmentID char(10),
    position NVARCHAR(50),
    qualification NVARCHAR(100),
    degree VARCHAR(100),
    status NVARCHAR(20) DEFAULT 'Active' CHECK (status IN ('Active', 'Inactive', 'On Leave')),
	startDate date,
    Notes ntext
)
go

--Table Account
create table Account
(
	id int primary key identity(1,1),
	username char(50),
	password char(255),
	startDate date,
	staffID char(10),
	status char(100),
	CONSTRAINT UQ_Account_Username UNIQUE (username)
)
go

--Table Room
create table Room
(
	id int identity(1,1) primary key,
	roomName nvarchar(100),
	bedCount int,
	departmentID char(10)
)
go

--Table Appointment
create table Appointment
(
	id int primary key identity(1,1),
	startDate dateTime,
	note ntext,
	status nvarchar(100),
	doctorID char(10),
	patientID char(10)
)
go
--Table DailyCare
create table DailyCare
(
	id int primary key identity(1,1),
	shift nvarchar(100),
	bloodPressure varchar(20),
	bodyTempearature DECIMAL(4,1), --Unit độ C
	pulseRate int,
	dateCare date,
	note ntext,
	patientID char(10),
	roomID int,
	nurseID char(10)
)
go

--Table MedicalOrder
CREATE TABLE MedicalOrder (
		id INT PRIMARY KEY IDENTITY(1,1),
		PatientID CHAR(10) NOT NULL,
		DoctorID CHAR(10) NOT NULL,
		OrderType VARCHAR(50) NOT NULL,
		ItemID CHAR(10) NULL,
		TestTypeID INT NULL,
		HasLabTest BIT DEFAULT 0,
		Dosage VARCHAR(100) NULL,
		Quantity DECIMAL(8,2) NULL,
		Unit VARCHAR(20) NULL,
		Frequency VARCHAR(50) NULL,
		StartDate DATE NULL,
		EndDate DATE NULL,
		Status VARCHAR(20) DEFAULT 'Active',
		CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
		SignedAt DATETIME NULL,
		Note NTEXT NULL
	);
go

--Table LabTestType
CREATE TABLE LabTestType (
		id INT IDENTITY(1,1) PRIMARY KEY,
		testTypeName NVARCHAR(100) NOT NULL
);
	GO

--table Patient
CREATE TABLE Patient (
    id CHAR(10) PRIMARY KEY,
    fullName NVARCHAR(255) NOT NULL,
    gender NVARCHAR(10),                -- Giới tính: Nam/Nữ/Khác
    dob DATE,                           -- Ngày sinh
    phoneNumber VARCHAR(15),
	TypePatient varchar(20)CHECK (TypePatient IN ('Inpatient', 'Outpatient', 'Other')),		   -- Loại bệnh nhân (Nội trú, ngoại trú, khác)
    citizenID VARCHAR(20),             -- CCCD/CMND
    InsuranceID VARCHAR(20),           -- Mã bảo hiểm y tế
    address NVARCHAR(255),             -- Địa chỉ
    EmergencyContact NVARCHAR(255),    -- Tên người liên hệ khẩn cấp
    EmergencyPhone VARCHAR(15),
    status NVARCHAR(50),               -- Trạng thái (đang điều trị, xuất viện,...)
    createdDate DATETIME DEFAULT GETDATE(),
    updatedDate DATETIME DEFAULT GETDATE(),
    weight FLOAT,                      -- Cân nặng (kg)
    height FLOAT                       -- Chiều cao (cm)
)
go

--Table Doctor_Patient
create table DoctorPatient
(
	doctorID char(10),
	patientID char(10),
	startDate date,
	endDate date,
	role varchar(50), --vai trò bác sĩ: khám chính, hội chẩn, điều trị, khám ngoại trú, khám nội trú,...
	note ntext,
	primary key(doctorID, patientID, startDate) 
)
go

--Table Department
create table Department
(
	id char(10),
	departmentName nvarchar(255),
	description ntext,
	primary key(id)
)
go

--Table MedicalRecord
CREATE TABLE MedicalRecord (
    id INT IDENTITY(1,1) PRIMARY KEY,
    patientID CHAR(10) NOT NULL,
    doctorID CHAR(10) NOT NULL,
    diagnosis NVARCHAR(500),
    treatmentPlan NVARCHAR(500),
    prescription NVARCHAR(500),
    vitalSigns NVARCHAR(255),
    createdDate DATETIME DEFAULT GETDATE(),
    notes NVARCHAR(1000),
)
go

--Table laboratoryTest
CREATE TABLE LaboratoryTest (
    id INT IDENTITY(1,1) PRIMARY KEY,
    MedicalOrderID INT NOT NULL,
    startDate DATETIME NULL,
    resultValue NVARCHAR(100) NULL,
    resultUnit NVARCHAR(50) NULL,
    result NVARCHAR(255) NULL,
    status NVARCHAR(50) NULL,
    note NTEXT NULL,
);
go

--Table SupplyHistory 
CREATE TABLE SupplyHistory (
    id CHAR(10) PRIMARY KEY,
    itemID CHAR(10) NOT NULL,
    roomID int NOT NULL,
    nurseID CHAR(10) NOT NULL,
    dosage VARCHAR(255),
    quantity INT,
    unit nVARCHAR(255),
    note Ntext,
	PatientID char(10) null,
	typeSupply nvarchar(100) CHECK (typeSupply IN (       -- Phân loại để nhận biết là loại xuất (cho bệnh nhân, cho khoa,..).
    N'Patient', N'Department', N'Other Supplies')), 
	dateSupply date
)
go	

--Table Items
CREATE TABLE Items (
    ID        CHAR(10) PRIMARY KEY,                          -- Mã vật tư (duy nhất)
    ItemName      NVARCHAR(255) NOT NULL,                    -- Tên vật tư
    ItemType NVARCHAR(100) CHECK (ItemType IN (
    N'Medicine', N'Equipment', N'Tool', N'Other Supplies')), -- Loại vật tư có ràng buộc phân loại
    Unit          NVARCHAR(20) NOT NULL DEFAULT N'Chiếc',    -- Đơn vị (viên, hộp, chiếc,...)
    Price         DECIMAL(18, 2) CHECK (Price >= 0),         -- Giá không âm
    CreatedAt     DATETIME DEFAULT GETDATE(),                -- Ngày thêm vào hệ thống
    IsActive      BIT NOT NULL DEFAULT 1                     -- Đang được sử dụng?
);
go

--Table Inventory
CREATE TABLE Inventory (
	id int identity(1,1) primary key,
    ItemID     CHAR(10) FOREIGN KEY REFERENCES Items(ID),
    Quantity   INT NOT NULL CHECK (Quantity >= 0),
    LastUpdated DATETIME DEFAULT GETDATE()
);
go

--Table Salaries
CREATE TABLE SalaryDetail (
    SalaryID INT not null,                          -- Mã lương  
    StaffId CHAR(10) NOT NULL,                      -- Mã nhân viên
    SalaryPeriod VARCHAR(20) NOT NULL,              -- Kỳ lương, ví dụ '2025-06'
    SalaryDate DATE NOT NULL,                       -- Ngày trả lương
    BasicSalary DECIMAL(18,2) NOT NULL,             -- Lương cơ bản
    WorkingDays INT NOT NULL,                       -- Số ngày công thực tế
    OvertimeHours DECIMAL(5,2) DEFAULT 0,           -- Số giờ tăng ca
    Allowance DECIMAL(18,2) DEFAULT 0,              -- Phụ cấp
    Bonus DECIMAL(18,2) DEFAULT 0,                  -- Thưởng
    Deduction DECIMAL(18,2) DEFAULT 0,              -- Các khoản bị trừ
    IncomeTax DECIMAL(18,2) DEFAULT 0,              -- Thuế TNCN
    SocialInsurance DECIMAL(18,2) DEFAULT 0,        -- Bảo hiểm xã hội
	NetSalary AS (                                  -- Lương thực nhận (cột tính toán)
        BasicSalary + Allowance + Bonus 
        - Deduction - IncomeTax - SocialInsurance
    ) PERSISTED,
    Note Ntext NULL,                                 -- Ghi chú thêm
    CreatedAt DATETIME DEFAULT GETDATE(),           -- Ngày tạo
    CreatedBy NVARCHAR(100) NULL,                   -- Người tạo
	primary key(SalaryID, StaffId, SalaryDate)
)
go
 
--Table Salary
create table Salary (
	id int identity(1,1) primary key,
	BasicSalary DECIMAL(18,2) NOT NULL unique
)
--SalaryDetail
--Salary

--Foreign key
alter table Account
add constraint fk_Staff_Account foreign key(staffID) references Staff(id);
go

alter table Appointment
add constraint fk_Doctor_Appointment foreign key(doctorID) references Staff(id),
	constraint fk_patient_Appointment foreign key(patientID) references Patient(id);
go

alter table DailyCare
add constraint fk_Patient_DailyCare foreign key(patientID) references Patient(id),
	constraint fk_Room_DailyCare foreign key(roomID) references Room(id),
	constraint fk_Nurse_DailyCare foreign key(nurseID) references Staff(id);
go

ALTER TABLE MedicalOrder
ADD CONSTRAINT fk_Patient_MedicalOrder FOREIGN KEY (PatientID)
    REFERENCES Patient(id) ON DELETE CASCADE,
    
    CONSTRAINT fk_Doctor_MedicalOrder FOREIGN KEY (DoctorID)
    REFERENCES Staff(id) ON DELETE CASCADE,
    
    CONSTRAINT fk_Items_MedicalOrder FOREIGN KEY (ItemID)
    REFERENCES Items(id) ON DELETE SET NULL,
    
    CONSTRAINT fk_TestType_MedicalOrder FOREIGN KEY (TestTypeID)
    REFERENCES LabTestType(id) ON DELETE SET NULL;
GO

alter table DoctorPatient
add constraint fk_Doctor_DP foreign key(doctorID) references Staff(id),
	constraint fk_Patient_DP foreign key(patientID) references Patient(id);
go

alter table Staff
add constraint fk_Department_Staff foreign key(departmentID) references Department(id);
go

alter table MedicalRecord
add constraint fk_Doctor_MedicalRecord foreign key(doctorID) references Staff(id),
	constraint fk_Patient_MedicalRecord foreign key(patientID) references Patient(id);
go

ALTER TABLE LaboratoryTest
ADD CONSTRAINT fk_MedicalOrder_LaboratoryTestt
    FOREIGN KEY (MedicalOrderID) REFERENCES MedicalOrder(id) ON DELETE CASCADE;
go

alter table SupplyHistory
add constraint fk_Item_SupplyHistory foreign key(itemID) references Items(id),
	constraint fk_Room_SupplyHistory foreign key(roomID) references Room(id),
	constraint fk_Nurse_SupplyHistory foreign key(nurseID) references Staff(id),
	constraint fk_Patient_SupplyHistory foreign key(PatientID) references Patient(id);
go

alter table SalaryDetail
add constraint fk_Staff_SalaryDetail foreign key(StaffId) references Staff(id),
   constraint fk_Salary_SalaryDetail foreign key(SalaryId) references Salary(id);
go

-- create procedure đơn thuốc
CREATE PROCEDURE sp_GetPrescriptionReport
    @PatientID CHAR(10),
    @OrderDate DATE = NULL -- Nếu muốn lọc theo ngày kê đơn, có thể để NULL để lấy tất cả
AS
BEGIN
    SELECT
        mo.id AS PrescriptionID,
        p.fullName AS PatientName,
        p.gender AS PatientGender,
        p.dob AS PatientDOB,
        p.phoneNumber AS PatientPhone,
        p.address AS PatientAddress,
        p.InsuranceID AS PatientInsurance,
        s.name AS DoctorName,
        s.position AS DoctorPosition,
        s.qualification AS DoctorQualification,
        s.degree AS DoctorDegree,
        d.departmentName AS DepartmentName,
        mo.CreatedAt AS OrderDate,
        mo.SignedAt AS DoctorSignedAt,
        i.ItemName AS MedicineName,
        mo.Dosage,
        mo.Quantity,
        mo.Unit,
        mo.Frequency,
        mo.Note
    FROM MedicalOrder mo
    INNER JOIN Patient p ON mo.PatientID = p.id
    INNER JOIN Staff s ON mo.DoctorID = s.id
    LEFT JOIN Department d ON s.departmentID = d.id
    LEFT JOIN Items i ON mo.ItemID = i.ID
    WHERE mo.PatientID = @PatientID
      AND mo.OrderType = N'Thuốc'
      AND (@OrderDate IS NULL OR CAST(mo.CreatedAt AS DATE) = @OrderDate)
    ORDER BY mo.CreatedAt DESC, mo.id
END
go
-- create procedure danh sách nhân viên theo khoa
CREATE PROCEDURE sp_GetStaffListByDepartment
    @DepartmentID CHAR(10)
AS
BEGIN
    SELECT
        s.id AS StaffID,
        s.name AS StaffName,
        s.role AS StaffRole,
        s.dob AS DateOfBirth,
        s.gender,
        s.phoneNumber,
        s.email,
        s.homeAddress,
        s.citizenID,
        s.position,
        s.qualification,
        s.degree,
        s.status,
        s.startDate,
        s.Notes,
        d.departmentName AS DepartmentName
    FROM Staff s
    LEFT JOIN Department d ON s.departmentID = d.id
    WHERE (@DepartmentID IS NULL OR s.departmentID = @DepartmentID)
    ORDER BY s.name
END

go
-- create procedure danh sách bệnh nhân theo khoa
CREATE PROCEDURE sp_GetPatientListByDepartment
    @DepartmentID CHAR(10)
AS
BEGIN
    SELECT DISTINCT
        p.id AS PatientID,
        p.fullName,
        p.gender,
        p.dob,
        p.phoneNumber,
        p.TypePatient,
        p.citizenID,
        p.InsuranceID,
        p.address,
        p.EmergencyContact,
        p.EmergencyPhone,
        p.status,
        p.createdDate,
        p.updatedDate,
        p.weight,
        p.height,
        d.departmentName AS DepartmentName
    FROM Patient p
    INNER JOIN DoctorPatient dp ON p.id = dp.patientID
    INNER JOIN Staff s ON dp.doctorID = s.id
    LEFT JOIN Department d ON s.departmentID = d.id
    WHERE (@DepartmentID IS NULL OR s.departmentID = @DepartmentID)
    ORDER BY p.fullName
END

go
-- create procedure danh sách bác sĩ theo khoa
CREATE PROCEDURE sp_GetDoctorListByDepartment
    @DepartmentID CHAR(10)
AS
BEGIN
    SELECT
        s.id AS DoctorID,
        s.name AS DoctorName,
        s.dob AS DateOfBirth,
        s.gender,
        s.phoneNumber,
        s.email,
        s.homeAddress,
        s.citizenID,
        s.position,
        s.qualification,
        s.degree,
        s.status,
        s.startDate,
        s.Notes,
        d.departmentName AS DepartmentName
    FROM Staff s
    LEFT JOIN Department d ON s.departmentID = d.id
    WHERE s.role = N'Bác sĩ'
      AND (@DepartmentID IS NULL OR s.departmentID = @DepartmentID)
    ORDER BY s.name
END
--USE master;
--ALTER DATABASE HospitalManagement SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
--DROP DATABASE HospitalManagement;

-- Thêm dữ liệu mẫu cho bảng LabTestType
INSERT INTO LabTestType (testTypeName) VALUES 
(N'Xét nghiệm máu tổng quát'),
(N'Xét nghiệm sinh hóa máu'),
(N'Xét nghiệm nước tiểu'),
(N'Xét nghiệm phân'),
(N'Xét nghiệm chức năng gan'),
(N'Xét nghiệm chức năng thận'),
(N'Xét nghiệm đường huyết'),
(N'Xét nghiệm mỡ máu'),
(N'Xét nghiệm điện giải đồ'),
(N'Xét nghiệm hormone tuyến giáp'),
(N'Xét nghiệm viêm gan'),
(N'Xét nghiệm HIV'),
(N'Xét nghiệm giang mai'),
(N'Xét nghiệm lao'),
(N'Xét nghiệm vi khuẩn kháng thuốc'),
(N'Xét nghiệm tế bào học'),
(N'Xét nghiệm mô bệnh học'),
(N'Xét nghiệm di truyền'),
(N'Xét nghiệm miễn dịch'),
(N'Xét nghiệm dị ứng');