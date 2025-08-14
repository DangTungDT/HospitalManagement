using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DepartmentInfoDoctorDAL
    {
        private HospitalManagementDataContext db = new HospitalManagementDataContext();

        public DepartmentInfoDoctorDTO GetDepartmentInfoByDoctorID(string doctorID)
        {
            try
            {
                var query = from s in db.Staffs
                            join d in db.Departments on s.departmentID equals d.id
                            where s.id == doctorID && s.role == "Bác sĩ"
                            select new DepartmentInfoDoctorDTO
                            {
                                DepartmentID = d.id,
                                DepartmentName = d.departmentName,
                                Description = d.description,
                                DoctorID = s.id,
                                DoctorName = s.name,
                                DoctorPosition = s.position,
                                DoctorQualification = s.qualification,
                                DoctorDegree = s.degree,
                                StartDate = s.startDate,
                                Status = s.status,
                                StaffCount = db.Staffs.Count(st => st.departmentID == d.id),
                                RoomCount = db.Rooms.Count(r => r.departmentID == d.id),
                                PatientCount = (from dp in db.DoctorPatients
                                               join st in db.Staffs on dp.doctorID equals st.id
                                               where st.departmentID == d.id
                                               select dp.patientID).Distinct().Count()
                            };

                return query.FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DepartmentInfoDoctorDTO GetDepartmentInfoByUsername(string username)
        {
            try
            {
                var query = from a in db.Accounts
                            join s in db.Staffs on a.staffID equals s.id
                            join d in db.Departments on s.departmentID equals d.id
                            where a.username == username && s.role == "Bác sĩ"
                            select new DepartmentInfoDoctorDTO
                            {
                                DepartmentID = d.id,
                                DepartmentName = d.departmentName,
                                Description = d.description,
                                DoctorID = s.id,
                                DoctorName = s.name,
                                DoctorPosition = s.position,
                                DoctorQualification = s.qualification,
                                DoctorDegree = s.degree,
                                StartDate = s.startDate,
                                Status = s.status,
                                StaffCount = db.Staffs.Count(st => st.departmentID == d.id),
                                RoomCount = db.Rooms.Count(r => r.departmentID == d.id),
                                PatientCount = (from dp in db.DoctorPatients
                                               join st in db.Staffs on dp.doctorID equals st.id
                                               where st.departmentID == d.id
                                               select dp.patientID).Distinct().Count()
                            };

                return query.FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<DepartmentInfoDoctorDTO> GetAllDepartments()
        {
            try
            {
                var query = from d in db.Departments
                            select new DepartmentInfoDoctorDTO
                            {
                                DepartmentID = d.id,
                                DepartmentName = d.departmentName,
                                Description = d.description,
                                StaffCount = db.Staffs.Count(s => s.departmentID == d.id),
                                RoomCount = db.Rooms.Count(r => r.departmentID == d.id),
                                PatientCount = (from dp in db.DoctorPatients
                                               join s in db.Staffs on dp.doctorID equals s.id
                                               where s.departmentID == d.id
                                               select dp.patientID).Distinct().Count()
                            };

                return query.ToList();
            }
            catch (Exception ex)
            {
                return new List<DepartmentInfoDoctorDTO>();
            }
        }
    }
}
