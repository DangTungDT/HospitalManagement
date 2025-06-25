using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class StaffDTO
    {
        string id, name, role, gender, phoneNumber, email, homeAddress, citizenID, departmentID, position, qualification, degree, status, notes;
        DateTime dob, startDate;

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Role { get => role; set => role = value; }
        public string Gender { get => gender; set => gender = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Email { get => email; set => email = value; }
        public string HomeAddress { get => homeAddress; set => homeAddress = value; }
        public string CitizenID { get => citizenID; set => citizenID = value; }
        public string DepartmentID { get => departmentID; set => departmentID = value; }
        public string Position { get => position; set => position = value; }
        public string Qualification { get => qualification; set => qualification = value; }
        public string Degree { get => degree; set => degree = value; }
        public string Status { get => status; set => status = value; }
        public string Notes { get => notes; set => notes = value; }
        public DateTime Dob { get => dob; set => dob = value; }
        public DateTime StartDate { get => startDate; set => startDate = DateTime.Now; }
    }
}
