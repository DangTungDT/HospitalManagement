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

        public StaffDTO(string id, string name, string role, string gender, string phoneNumber, string email, string homeAddress, string citizenID, string departmentID, string position, string qualification, string degree, string status, string notes, DateTime dob, DateTime startDate)
        {
            this.id = id;
            this.name = name;
            this.role = role;
            this.gender = gender;
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.homeAddress = homeAddress;
            this.citizenID = citizenID;
            this.departmentID = departmentID;
            this.position = position;
            this.qualification = qualification;
            this.degree = degree;
            this.status = status;
            this.notes = notes;
            this.dob = dob;
            this.startDate = startDate;
        }

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
