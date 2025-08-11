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
CREATE TABLE RoomTransferHistory (
    id INT PRIMARY KEY IDENTITY(1,1),
    patientID CHAR(10) NOT NULL,
    fromRoomID INT NULL,
    toRoomID INT NOT NULL,
    transferDate DATETIME DEFAULT GETDATE(),
    note NVARCHAR(255)
);
GO

 
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

ALTER TABLE RoomTransferHistory
ADD CONSTRAINT FK_Transfer_Patient 
    FOREIGN KEY (patientID) REFERENCES Patient(id) ON DELETE CASCADE;

ALTER TABLE RoomTransferHistory
ADD CONSTRAINT FK_Transfer_FromRoom 
    FOREIGN KEY (fromRoomID) REFERENCES Room(id) ON DELETE SET NULL;

ALTER TABLE RoomTransferHistory
ADD CONSTRAINT FK_Transfer_ToRoom 
    FOREIGN KEY (toRoomID) REFERENCES Room(id)  ON DELETE NO ACTION;
GO

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
go
CREATE OR ALTER PROCEDURE sp_GetMedicalOrdersOfPatientInDoctorDepartment
    @DoctorId CHAR(10),
    @PatientId CHAR(10)
AS
BEGIN
    DECLARE @DepartmentId CHAR(10);

    -- Lấy khoa của bác sĩ
    SELECT @DepartmentId = departmentID
    FROM Staff
    WHERE id = @DoctorId;

    IF @DepartmentId IS NULL
    BEGIN
        SELECT TOP 0 
            CAST(NULL AS CHAR(10)) AS [Mã y lệnh],
            CAST(NULL AS NVARCHAR(100)) AS [Tên bệnh nhân],
            CAST(NULL AS NVARCHAR(100)) AS [Tên khoa],
            CAST(NULL AS NVARCHAR(100)) AS [Loại y lệnh],
            CAST(NULL AS NVARCHAR(50)) AS [Liều lượng],
            CAST(NULL AS INT) AS [Số lượng],
            CAST(NULL AS NVARCHAR(50)) AS [Đơn vị],
            CAST(NULL AS NVARCHAR(50)) AS [Tần suất],
            CAST(NULL AS DATETIME) AS [Ngày bắt đầu],
            CAST(NULL AS DATETIME) AS [Ngày kết thúc],
            CAST(NULL AS NVARCHAR(50)) AS [Trạng thái],
            CAST(NULL AS NVARCHAR(MAX)) AS [Ghi chú],
            CAST(NULL AS DATETIME) AS [Ngày ký]
        WHERE 1 = 0;
        RETURN;
    END

    ;WITH ValidTransfers AS (
        SELECT 
            t.patientID,
            t.transferDate,
            r.departmentID
        FROM RoomTransferHistory t
        JOIN Room r ON t.toRoomID = r.id
        WHERE r.departmentID = @DepartmentId
    ),
    LatestTransfers AS (
        SELECT vt.patientID, vt.departmentID
        FROM ValidTransfers vt
        WHERE vt.transferDate = (
            SELECT MAX(vt2.transferDate)
            FROM ValidTransfers vt2
            WHERE vt2.patientID = vt.patientID
        )
    )
    SELECT 
        mo.id AS [Mã y lệnh],
        p.fullName AS [Tên bệnh nhân],
        d.departmentName AS [Tên khoa],
        mo.OrderType AS [Loại y lệnh],
        mo.Dosage AS [Liều lượng],
        mo.Quantity AS [Số lượng],
        mo.Unit AS [Đơn vị],
        mo.Frequency AS [Tần suất],
        mo.StartDate AS [Ngày bắt đầu],
        mo.EndDate AS [Ngày kết thúc],
        mo.Status AS [Trạng thái],
        mo.Note AS [Ghi chú],
        mo.SignedAt AS [Ngày ký]
    FROM MedicalOrder mo
    JOIN Patient p ON mo.PatientID = p.id
    JOIN LatestTransfers lt ON p.id = lt.patientID
    JOIN Department d ON lt.departmentID = d.id
    WHERE 
        p.TypePatient = 'Inpatient'
        AND p.id = @PatientId
    ORDER BY mo.CreatedAt DESC;
END
GO

---- Xoá thủ tục cũ nếu có
--IF OBJECT_ID('sp_GetDailyCaresByPatient', 'P') IS NOT NULL
--    DROP PROCEDURE sp_GetSupplyHistoryInSameDepartmentFromDate;
GO

-- Tạo lại thủ tục với thêm tên khoa
CREATE PROCEDURE sp_GetDailyCaresByPatient
    @PatientId CHAR(10)
AS
BEGIN
    SELECT 
        dc.id AS 'Mã chăm sóc',
        p.fullName AS 'Tên bệnh nhân',
        s.name AS 'Y tá chăm sóc',
        r.roomName AS 'Phòng',
        d.departmentName AS 'Khoa',
        dc.shift AS 'Ca trực',
        dc.bloodPressure AS 'Huyết áp',
        dc.bodyTempearature AS 'Nhiệt độ (°C)',
        dc.pulseRate AS 'Nhịp tim (lần/phút)',
        dc.dateCare AS 'Ngày chăm sóc',
        dc.note AS 'Ghi chú'
    FROM DailyCare dc
    INNER JOIN Patient p ON dc.patientID = p.id
    INNER JOIN Staff s ON dc.nurseID = s.id
    LEFT JOIN Room r ON dc.roomID = r.id
    LEFT JOIN Department d ON r.departmentID = d.id
    WHERE dc.patientID = @PatientId
    ORDER BY dc.dateCare DESC;
END
go
CREATE OR ALTER PROCEDURE sp_GetDailyCaresInSameDepartmentAsDoctorAndDate
    @DoctorId CHAR(10),
    @TargetDate DATE
AS
BEGIN
    SELECT 
        dc.id AS 'Mã chăm sóc',
        p.fullName AS 'Tên bệnh nhân',
        s.name AS 'Y tá chăm sóc',
        r.roomName AS 'Phòng',
        d.departmentName AS 'Khoa',
        dc.shift AS 'Ca trực',
        dc.bloodPressure AS 'Huyết áp',
        dc.bodyTempearature AS 'Nhiệt độ (°C)',
        dc.pulseRate AS 'Nhịp tim (lần/phút)',
        dc.dateCare AS 'Ngày chăm sóc',
        dc.note AS 'Ghi chú'
    FROM DailyCare dc
    JOIN Patient p ON dc.patientID = p.id
    JOIN Staff s ON dc.nurseID = s.id
    JOIN Room r ON dc.roomID = r.id
    JOIN Department d ON r.departmentID = d.id
    JOIN Staff doctor ON doctor.id = @DoctorId
    WHERE 
        r.departmentID = doctor.departmentID
        AND p.TypePatient = 'Inpatient'
        AND dc.dateCare >= @TargetDate
    ORDER BY dc.dateCare DESC;
END
GO
CREATE PROCEDURE sp_GetPatientSupplyHistoryInSameDepartment
    @DoctorId CHAR(10),
    @PatientId CHAR(10)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @DepartmentId CHAR(10);

    -- Lấy khoa của bác sĩ đăng nhập
    SELECT @DepartmentId = departmentID
    FROM Staff
    WHERE id = @DoctorId;

    -- Nếu không tìm thấy khoa => trả về rỗng
    IF @DepartmentId IS NULL
    BEGIN
        SELECT 
            CAST(NULL AS CHAR(10)) AS [Mã cấp thuốc],
            CAST(NULL AS NVARCHAR(255)) AS [Tên vật tư/thuốc],
            CAST(NULL AS NVARCHAR(255)) AS [Phòng],
            CAST(NULL AS NVARCHAR(255)) AS [Khoa],
            CAST(NULL AS NVARCHAR(255)) AS [Tên y tá],
            CAST(NULL AS NVARCHAR(255)) AS [Tên bệnh nhân],
            CAST(NULL AS DATE) AS [Ngày cấp],
            CAST(NULL AS NVARCHAR(255)) AS [Liều lượng],
            CAST(NULL AS INT) AS [Số lượng],
            CAST(NULL AS NVARCHAR(50)) AS [Đơn vị],
            CAST(NULL AS NVARCHAR(255)) AS [Ghi chú];
        RETURN;
    END

    -- Lấy danh sách lịch sử cấp thuốc
    SELECT 
        sh.id AS [Mã cấp thuốc],
        i.ItemName AS [Tên vật tư/thuốc],
        r.roomName AS [Phòng],
        d.departmentName AS [Khoa],
        n.name AS [Tên y tá],
        p.fullName AS [Tên bệnh nhân],
        sh.dateSupply AS [Ngày cấp],
        sh.dosage AS [Liều lượng],
        sh.quantity AS [Số lượng],
        sh.unit AS [Đơn vị],
        sh.note AS [Ghi chú]
    FROM SupplyHistory sh
    INNER JOIN Items i ON sh.itemID = i.ID
    INNER JOIN Room r ON sh.roomID = r.id
    INNER JOIN Department d ON r.departmentID = d.id
    INNER JOIN Staff n ON sh.nurseID = n.id
    LEFT JOIN Patient p ON sh.PatientID = p.id
    WHERE sh.typeSupply = N'Patient'
      AND sh.PatientID = @PatientId
      AND r.departmentID = @DepartmentId
    ORDER BY sh.dateSupply DESC;
END;
GO
CREATE OR ALTER PROCEDURE sp_GetSupplyHistoryInSameDepartmentFromDate
    @DoctorId CHAR(10),
    @FromDate DATE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @DepartmentId CHAR(10);

    -- Lấy khoa của bác sĩ đăng nhập
    SELECT @DepartmentId = departmentID
    FROM Staff
    WHERE id = @DoctorId;

    -- Nếu không tìm thấy khoa => trả về rỗng
    IF @DepartmentId IS NULL
    BEGIN
        SELECT 
            CAST(NULL AS CHAR(10)) AS [Mã cấp thuốc],
            CAST(NULL AS NVARCHAR(255)) AS [Tên vật tư/thuốc],
            CAST(NULL AS NVARCHAR(255)) AS [Phòng],
            CAST(NULL AS NVARCHAR(255)) AS [Khoa],
            CAST(NULL AS NVARCHAR(255)) AS [Tên y tá],
            CAST(NULL AS NVARCHAR(255)) AS [Tên bệnh nhân],
            CAST(NULL AS DATE) AS [Ngày cấp],
            CAST(NULL AS NVARCHAR(255)) AS [Liều lượng],
            CAST(NULL AS INT) AS [Số lượng],
            CAST(NULL AS NVARCHAR(50)) AS [Đơn vị],
            CAST(NULL AS NVARCHAR(255)) AS [Ghi chú];
        RETURN;
    END

    -- Lấy danh sách lịch sử cấp thuốc/vật tư theo khoa và ngày (chỉ bệnh nhân không null)
    SELECT 
        sh.id AS [Mã cấp thuốc],
        i.ItemName AS [Tên vật tư/thuốc],
        r.roomName AS [Phòng],
        d.departmentName AS [Khoa],
        n.name AS [Tên y tá],
        p.fullName AS [Tên bệnh nhân],
        sh.dateSupply AS [Ngày cấp],
        sh.dosage AS [Liều lượng],
        sh.quantity AS [Số lượng],
        sh.unit AS [Đơn vị],
        sh.note AS [Ghi chú]
    FROM SupplyHistory sh
    INNER JOIN Items i ON sh.itemID = i.ID
    INNER JOIN Room r ON sh.roomID = r.id
    INNER JOIN Department d ON r.departmentID = d.id
    INNER JOIN Staff n ON sh.nurseID = n.id
    LEFT JOIN Patient p ON sh.PatientID = p.id
    WHERE sh.typeSupply = N'Patient'
      AND r.departmentID = @DepartmentId
      AND sh.dateSupply >= @FromDate
      AND sh.PatientID IS NOT NULL
    ORDER BY sh.dateSupply DESC;
END;
GO
EXEC sp_GetSupplyHistoryInSameDepartmentFromDate
    @DoctorId = 'DD0001',
    @FromDate = '2025-08-01';


EXEC sp_GetPatientSupplyHistoryInSameDepartment 'BS0001', 'P003';
EXEC sp_GetDailyCaresInSameDepartmentAsDoctorAndDate 'DD0002', '1900-01-01';

EXEC sp_GetDailyCaresByPatient 'P001';
--USE master;
--ALTER DATABASE HospitalManagement SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
--DROP DATABASE HospitalManagement;