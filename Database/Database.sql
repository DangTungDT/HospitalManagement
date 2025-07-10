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
    position VARCHAR(50),
    qualification VARCHAR(100),
    degree VARCHAR(100),
    status NVARCHAR(20) DEFAULT 'Active' CHECK (status IN ('Active', 'Inactive', 'On Leave')),
	startDate date,
    Notes text
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
	note text,
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
	note text,
	patientID char(10),
	roomID int,
	nurseID char(10)
)
go

--Table MedicalOrder
CREATE TABLE MedicalOrder (
    id INT PRIMARY KEY identity(1,1),     -- Mã y lệnh
    PatientID CHAR(10) NOT NULL,               -- FK → Patient
    DoctorID CHAR(10) NOT NULL,                -- FK → Doctor
    OrderType VARCHAR(50) NOT NULL,            -- Loại y lệnh: Thuốc / Xét nghiệm / Chỉ định khác
    ItemID char(10) NULL,                      -- FK → Medicine hoặc LabTestType
    TestTypeID INT NULL,                       -- FK → LabTestType (nếu là xét nghiệm)
    Dosage VARCHAR(100) NULL,                  -- Liều lượng (Dosage)
    Quantity DECIMAL(8,2) NULL,                -- Số lượng (Quantity)
    Unit VARCHAR(20) NULL,                     -- Đơn vị (Unit)
    Frequency VARCHAR(50) NULL,                -- Tần suất (ví dụ: 2 lần/ngày)
    StartDate DATE NULL,                       -- Ngày bắt đầu y lệnh
    EndDate DATE NULL,                         -- Ngày kết thúc (nếu có)
    Status VARCHAR(20) DEFAULT 'Active',       -- Trạng thái: Active / Completed / Discontinued
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,  -- Thời gian ghi y lệnh
    SignedAt DATETIME NULL,                    -- Thời gian bác sĩ ký duyệt
    Note TEXT NULL                            -- Ghi chú thêm
    -- có thể thêm FK tới các bảng Medicine hoặc LabTestType nếu lưu chi tiết
)
go

--table Patient
CREATE TABLE Patient (
    id CHAR(10) PRIMARY KEY,
    fullName NVARCHAR(255) NOT NULL,
    gender NVARCHAR(10),                -- Giới tính: Nam/Nữ/Khác
    dob DATE,                           -- Ngày sinh
    phoneNumber VARCHAR(15),
    citizenID VARCHAR(20),             -- CCCD/CMND
    InsuranceID VARCHAR(20),           -- Mã bảo hiểm y tế
    address NVARCHAR(255),
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
	note text,
	primary key(doctorID, patientID, startDate) 
)
go

--Table Department
create table Department
(
	id char(10),
	departmentName nvarchar(255),
	description text,
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
    testName NVARCHAR(255) NOT NULL,
    patientID CHAR(10) NOT NULL,
    doctorID CHAR(10) NOT NULL,
    startDate DATETIME,
    resultValue NVARCHAR(100),
    resultUnit NVARCHAR(50),
    result NVARCHAR(255),
    testType NVARCHAR(100),
    status NVARCHAR(50),
    note text,
)
go

--Table SupplyHistory 
CREATE TABLE SupplyHistory (
    id CHAR(10) PRIMARY KEY,
    itemID CHAR(10) NOT NULL,
    roomID int NOT NULL,
    nurseID CHAR(10) NOT NULL,
    dosage VARCHAR(255),
    quantity INT,
    unit VARCHAR(255),
    note text
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
    ItemID     CHAR(10) PRIMARY KEY FOREIGN KEY REFERENCES Items(ID),
    Quantity   INT NOT NULL CHECK (Quantity >= 0),
    LastUpdated DATETIME DEFAULT GETDATE()
);
go

--Table Salaries
CREATE TABLE Salaries (
    Id INT IDENTITY(1,1) PRIMARY KEY,               -- Mã bảng lương tự tăng
    StaffId CHAR(10) NOT NULL,                      -- Mã nhân viên (FK)
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
    Note text NULL,                                 -- Ghi chú thêm
    CreatedAt DATETIME DEFAULT GETDATE(),           -- Ngày tạo
    CreatedBy NVARCHAR(100) NULL                    -- Người tạo
)
go


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

alter table MedicalOrder
add constraint fk_Patient_MedicalOrder foreign key(PatientID) references Patient(id),
	constraint fk_Doctor_MedicalOrder foreign key(DoctorID) references Staff(id),
	constraint fk_Items_MedicalOrder foreign key(ItemID) references Items(id),
	constraint fk_TestType_MedicalOrder foreign key(TestTypeID) references LaboratoryTest(id);
go

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

alter table LaboratoryTest
add constraint fk_Doctor_LaboratoryTest foreign key(doctorID) references Staff(id),
	constraint fk_Patient_LaboratoryTest foreign key(patientID) references Patient(id);
go

alter table SupplyHistory
add constraint fk_Item_SupplyHistory foreign key(itemID) references Items(id),
	constraint fk_Room_SupplyHistory foreign key(roomID) references Room(id),
	constraint fk_Nurse_SupplyHistory foreign key(nurseID) references Staff(id);
go

alter table Salaries
add constraint fk_Staff_Salary foreign key(StaffId) references Staff(id);
go

----USE master;
----ALTER DATABASE HospitalManagement SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
----DROP DATABASE HospitalManagement;

-- Chèn dữ liệu vào bảng Department
INSERT INTO Department (id, departmentName, description)
VALUES 
    ('KHOA01', N'Nội khoa', N'Chuyên điều trị các bệnh lý nội khoa như tim mạch, tiêu hóa, hô hấp.'),
    ('KHOA02', N'Ngoại khoa', N'Chuyên phẫu thuật và điều trị các bệnh lý ngoại khoa.'),
    ('KHOA03', N'Nhi khoa', N'Chăm sóc và điều trị cho trẻ em.'),
    ('KHOA04', N'Sản khoa', N'Chăm sóc sức khỏe bà mẹ và thai nhi.'),
    ('KHOA05', N'Xét nghiệm', N'Thực hiện các xét nghiệm y khoa.');

-- Chèn dữ liệu vào bảng Room
INSERT INTO Room (roomName, bedCount, departmentID)
VALUES 
    (N'Phòng 101', 4, 'KHOA01'),
    (N'Phòng 102', 3, 'KHOA01'),
    (N'Phòng 201', 5, 'KHOA02'),
    (N'Phòng 301', 6, 'KHOA03'),
    (N'Phòng 401', 4, 'KHOA04'),
    (N'Phòng xét nghiệm 1', 0, 'KHOA05');

-- Chèn dữ liệu vào bảng Items
INSERT INTO Items (ID, ItemName, ItemType, Unit, Price, IsActive)
VALUES 
    ('VT001', N'Paracetamol 500mg', N'Medicine', N'Viên', 500.00, 1),
    ('VT002', N'Khẩu trang y tế', N'Other Supplies', N'Chiếc', 1000.00, 1),
    ('VT003', N'Kim tiêm 5ml', N'Tool', N'Chiếc', 2000.00, 1),
    ('VT004', N'Máy đo huyết áp', N'Equipment', N'Chiếc', 1500000.00, 1),
    ('VT005', N'Băng gạc y tế', N'Other Supplies', N'Hộp', 20000.00, 1),
    ('VT006', N'Amoxicillin 500mg', N'Medicine', N'Viên', 1000.00, 1);

-- Chèn dữ liệu vào bảng Inventory
INSERT INTO Inventory (ItemID, Quantity, LastUpdated)
VALUES 
    ('VT001', 1000, GETDATE()),
    ('VT002', 5000, GETDATE()),
    ('VT003', 2000, GETDATE()),
    ('VT004', 10, GETDATE()),
    ('VT005', 100, GETDATE()),
    ('VT006', 800, GETDATE());