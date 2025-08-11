using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PatientNurseDAL
    {
        HospitalManagementDataContext db = new HospitalManagementDataContext();
        public string GetDepartmentIdOfStaff(string staffId)
        {
            return db.Staffs
                     .Where(s => s.id == staffId)
                     .Select(s => s.departmentID)
                     .FirstOrDefault();
        }

        public List<PatientNurseDTO> GetPatientsByDoctorDepartment(string doctorId)
        {
            var departmentId = db.Staffs
                .Where(s => s.id == doctorId)
                .Select(s => s.departmentID)
                .FirstOrDefault();

            if (departmentId == null) return new List<PatientNurseDTO>();

            // Lấy tất cả các lần chuyển phòng thuộc khoa của bác sĩ
            var validTransfers = from t in db.RoomTransferHistories
                                 join r in db.Rooms on t.toRoomID equals r.id
                                 where r.departmentID == departmentId
                                 select new { Transfer = t, Room = r };

            // Lấy lần chuyển mới nhất cho mỗi bệnh nhân
            var latestTransfers = validTransfers
                .GroupBy(x => x.Transfer.patientID)
                .Select(g => g.OrderByDescending(x => x.Transfer.transferDate).FirstOrDefault());

            // Join lại với bệnh nhân và lọc loại "Inpatient"
            var query = from lt in latestTransfers
                        join p in db.Patients on lt.Transfer.patientID equals p.id
                        where p.TypePatient == "Inpatient" // ✅ CHỈ bệnh nhân nội trú
                        select new PatientNurseDTO
                        {
                            Id = p.id,
                            FullName = p.fullName,
                            Gender = p.gender,
                            DOB = p.dob,
                            PhoneNumber = p.phoneNumber,
                            TypePatient = p.TypePatient,
                            CitizenID = p.citizenID,
                            InsuranceID = p.InsuranceID,
                            Address = p.address,
                            EmergencyContact = p.EmergencyContact,
                            EmergencyPhone = p.EmergencyPhone,
                            Status = p.status,
                            CreatedDate = p.createdDate,
                            UpdatedDate = p.updatedDate,
                            Weight = (float?)p.weight,
                            Height = (float?)p.height
                        };

            return query.ToList();
        }
        public List<PatientNurseDTO> GetPatientsByDepartment(string departmentId)
        {
            if (string.IsNullOrEmpty(departmentId)) return new List<PatientNurseDTO>();

            var validTransfers = from t in db.RoomTransferHistories
                                 join r in db.Rooms on t.toRoomID equals r.id
                                 where r.departmentID == departmentId
                                 select new { Transfer = t, Room = r };

            var latestTransfers = validTransfers
                .GroupBy(x => x.Transfer.patientID)
                .Select(g => g.OrderByDescending(x => x.Transfer.transferDate).FirstOrDefault());

            var query = from lt in latestTransfers
                        join p in db.Patients on lt.Transfer.patientID equals p.id
                        select new PatientNurseDTO
                        {
                            Id = p.id,
                            FullName = p.fullName,
                            Gender = p.gender,
                            DOB = p.dob,
                            PhoneNumber = p.phoneNumber,
                            TypePatient = p.TypePatient,
                            CitizenID = p.citizenID,
                            InsuranceID = p.InsuranceID,
                            Address = p.address,
                            EmergencyContact = p.EmergencyContact,
                            EmergencyPhone = p.EmergencyPhone,
                            Status = p.status,
                            CreatedDate = p.createdDate,
                            UpdatedDate = p.updatedDate,
                            Weight = (float?)p.weight,
                            Height = (float?)p.height
                        };

            return query.ToList();
        }

        // ✅ 2. Tìm kiếm gần đúng bệnh nhân trong khoa
        public List<PatientNurseDTO> SearchPatientsByDoctorDepartment(string doctorId, string fullName, string phone, string insuranceId)
        {
            var departmentId = db.Staffs
                .Where(s => s.id == doctorId)
                .Select(s => s.departmentID)
                .FirstOrDefault();

            if (string.IsNullOrEmpty(departmentId)) return new List<PatientNurseDTO>();

            var validTransfers = from t in db.RoomTransferHistories
                                 join r in db.Rooms on t.toRoomID equals r.id
                                 where r.departmentID == departmentId
                                 select new { Transfer = t, Room = r };

            var latestTransfers = validTransfers
                .GroupBy(x => x.Transfer.patientID)
                .Select(g => g.OrderByDescending(x => x.Transfer.transferDate).FirstOrDefault());

            var query = from lt in latestTransfers
                        join p in db.Patients on lt.Transfer.patientID equals p.id
                        where (string.IsNullOrEmpty(fullName) || p.fullName.ToLower().Contains(fullName.ToLower()))
                           && (string.IsNullOrEmpty(phone) || p.phoneNumber.Contains(phone))
                           && (string.IsNullOrEmpty(insuranceId) || p.InsuranceID.Contains(insuranceId))
                        select new PatientNurseDTO
                        {
                            Id = p.id,
                            FullName = p.fullName,
                            Gender = p.gender,
                            DOB = p.dob,
                            PhoneNumber = p.phoneNumber,
                            TypePatient = p.TypePatient,
                            CitizenID = p.citizenID,
                            InsuranceID = p.InsuranceID,
                            Address = p.address,
                            EmergencyContact = p.EmergencyContact,
                            EmergencyPhone = p.EmergencyPhone,
                            Status = p.status,
                            CreatedDate = p.createdDate,
                            UpdatedDate = p.updatedDate,
                            Weight = (float?)p.weight,
                            Height = (float?)p.height
                        };

            return query.ToList();
        }

        public List<PatientListbyDepartmentDTO> GetPatientsByDepartment_ForReport(string departmentId)
        {
            if (string.IsNullOrEmpty(departmentId)) return new List<PatientListbyDepartmentDTO>();

            var query = from t in db.RoomTransferHistories
                        join r in db.Rooms on t.toRoomID equals r.id
                        join d in db.Departments on r.departmentID equals d.id
                        join p in db.Patients on t.patientID equals p.id
                        where r.departmentID == departmentId
                        group new { t, p, d } by p.id into g
                        let latestTransfer = g.OrderByDescending(x => x.t.transferDate).FirstOrDefault()
                        select new PatientListbyDepartmentDTO
                        {
                            PatientID = latestTransfer.p.id,
                            fullName = latestTransfer.p.fullName,
                            gender = latestTransfer.p.gender,
                            dob = latestTransfer.p.dob,
                            DepartmentName = latestTransfer.d.departmentName, // ✅ Gán tên khoa
                            status = latestTransfer.p.status,
                            createdDate = latestTransfer.p.createdDate
                        };

            return query.ToList();
        }

    }

}
