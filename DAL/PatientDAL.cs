using System;
using System.Collections.Generic;
using System.Data.Sql;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class PatientDAL
    {
        public static string GetFirstSqlServerInstanceName()
        {
            SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
            DataTable table = instance.GetDataSources();

            foreach (DataRow row in table.Rows)
            {
                string serverName = row["ServerName"].ToString();
                string instanceName = row["InstanceName"].ToString();

                string fullName = string.IsNullOrEmpty(instanceName)
                    ? serverName
                    : $"{serverName}\\{instanceName}";

                string stringConnection = $"Data Source={fullName};Initial Catalog=HospitalManagement;Integrated Security=True;Encrypt=False";
                return stringConnection;
                //return "Data Source=DESKTOP-6LE6PT2\\SQLEXPRESS;Initial Catalog=HospitalManagement;Integrated Security=True;Encrypt=False"; // Trả về instance đầu tiên tìm thấy

            }

            return "Data Source=DESKTOP-6LE6PT2\\SQLEXPRESS;Initial Catalog=HospitalManagement;Integrated Security=True;Encrypt=False"; // Không tìm thấy
        }
        HospitalManagementDataContext db = new HospitalManagementDataContext(GetFirstSqlServerInstanceName());

        public IQueryable GetAll()
        {
            try
            {
                return db.Patients.Select(x=> new
                {
                    x.id, 
                    x.fullName,
                    x.gender,
                    x.dob,
                    x.phoneNumber,
                    x.TypePatient,
                    x.citizenID,
                    x.InsuranceID,
                    x.address,
                    x.EmergencyContact,
                    x.EmergencyPhone,
                    x.status,
                    x.createdDate,
                    x.updatedDate,
                    x.weight,
                    x.height
                });

            }catch (Exception ex)
            {
                return null;
            }
        }

        private Patient Exists(string id)
        {
            Patient itemSelect = db.Patients.Where(x => x.id == id).FirstOrDefault();
            if (itemSelect == null)
            {
                return null;
            }
            return itemSelect;
        }
        public int Add(PatientDTO dto)
        {
            try
            {
                if(Exists(dto.Id) != null)
                {
                    return -1; //Đã tồn tại dũ liệu trùng id
                }
                Patient newP = new Patient()
                {
                    id = dto.Id,
                    fullName = dto.FullName,
                    gender = dto.Gender,
                    dob = dto.Dob,
                    phoneNumber = dto.PhoneNumber,
                    TypePatient = dto.TypePatient,
                    citizenID = dto.CitizenID,
                    InsuranceID = dto.InsuranceID,
                    address = dto.Address,
                    EmergencyContact = dto.EmergencyContact,
                    EmergencyPhone = dto.EmergencyPhone,
                    status = dto.Status,
                    createdDate = DateTime.Now,
                    updatedDate = DateTime.Now
                };
                if (dto.Weight > 0)
                {
                    newP.weight = dto.Weight;
                }
                if (dto.Height > 0)
                {
                    newP.height = dto.Height;
                }
                db.Patients.InsertOnSubmit(newP);
                db.SubmitChanges();
                return 0;
            }catch(Exception ex)
            {
                return 1;
            }
        }

        public bool Delete(string id)
        {
            try
            {
                Patient itemDelete = Exists(id);
                if(itemDelete != null)
                {
                    db.Patients.DeleteOnSubmit(itemDelete);
                    db.SubmitChanges();
                    return true;
                }
                return false;
            }catch(Exception ex)
            {
                return false;
            }
        }

        public int Update(PatientDTO dto)
        {
            try
            {
                if (Exists(dto.Id) != null)
                {
                    return -1; //Đã tồn tại dũ liệu trùng id
                }
                Patient itemNew = db.Patients.Where(x=> x.id == dto.Id).FirstOrDefault();
                itemNew = new Patient()
                {
                    id = dto.Id,
                    fullName = dto.FullName,
                    gender = dto.Gender,
                    dob = dto.Dob,
                    phoneNumber = dto.PhoneNumber,
                    citizenID = dto.CitizenID,
                    InsuranceID = dto.InsuranceID,
                    TypePatient = dto.TypePatient,
                    address = dto.Address,
                    EmergencyContact = dto.EmergencyContact,
                    EmergencyPhone = dto.EmergencyPhone,
                    status = dto.Status,
                    updatedDate = dto.UpdatedDate,
                    weight = dto.Weight,
                    height = dto.Height
                };
                db.Patients.InsertOnSubmit(itemNew);
                db.SubmitChanges();
                return 0;
            }
            catch (Exception ex)
            {
                return 1; //Lỗi
            }
        }
    }
}
