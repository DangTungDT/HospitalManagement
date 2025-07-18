using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class StaffDoctorDAL
    {
        private HospitalManagementDataContext db = new HospitalManagementDataContext();

        public StaffDoctorDTO GetStaffById(string id)
        {
            var result = db.Staffs.FirstOrDefault(s => s.id == id);
            if (result == null) return null;

            return new StaffDoctorDTO  
            {
                Id = result.id,
                Name = result.name,
                Role = result.role,
                Dob = result.dob,
                Gender = result.gender,
                PhoneNumber = result.phoneNumber,
                Email = result.email,
                HomeAddress = result.homeAddress,
                CitizenID = result.citizenID,
                DepartmentID = result.departmentID,
                Position = result.position,
                Qualification = result.qualification,
                Degree = result.degree,
                Status = result.status,
                StartDate = result.startDate,
                Notes = result.Notes
            };
        }
    }
}
