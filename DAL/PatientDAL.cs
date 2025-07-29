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
                return db.Patients.Select(x => new
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

            } catch (Exception ex)
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
                if (Exists(dto.Id) != null)
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
            } catch (Exception ex)
            {
                return 1;
            }
        }

        public bool Delete(string id)
        {
            try
            {
                Patient itemDelete = Exists(id);
                if (itemDelete != null)
                {
                    db.Patients.DeleteOnSubmit(itemDelete);
                    db.SubmitChanges();
                    return true;
                }
                return false;
            } catch (Exception ex)
            {
                return false;
            }
        }

        public bool SuaBenhNhan(PatientDTO dto)
        {
            Patient benhNhan = db.Patients.SingleOrDefault(e => e.id == dto.Id);
            if (benhNhan != null)
            {
                try
                {
                    benhNhan.fullName = dto.FullName;
                    benhNhan.gender = dto.Gender;
                    benhNhan.dob = dto.Dob;
                    benhNhan.phoneNumber = dto.PhoneNumber;
                    benhNhan.TypePatient = dto.TypePatient;
                    benhNhan.citizenID = dto.CitizenID;
                    benhNhan.InsuranceID = dto.InsuranceID;
                    benhNhan.address = dto.Address;
                    benhNhan.EmergencyContact = dto.EmergencyContact;
                    benhNhan.EmergencyPhone = dto.EmergencyPhone;
                    benhNhan.status = dto.Status;
                    benhNhan.updatedDate = DateTime.Now;
                    benhNhan.weight = dto.Weight;
                    benhNhan.height = dto.Height;

                    db.SubmitChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi " + ex.Message);
                }
            }
            return false;
        }              
        public string TaoMaBNTuDong()
        {
            // Lấy tất cả mã chức vụ dưới dạng chuỗi từ database
            var danhsachMaBN = db.Patients
                                    .Select(p => p.id)
                                    .ToList();
            // Tìm mã chức vụ có số lớn nhất sau khi chuyển đổi phần số trong bộ nhớ
            int maBenhNhanlonnhat = danhsachMaBN
                                 .Select(maBN => int.Parse(maBN.Substring(2)))
                                 .Max();  // Lấy số lớn nhất

            // Tăng số chức vụ hiện tại lên 1
            int maBNHT = maBenhNhanlonnhat + 1;
            // Tạo mã chức vụ mới với phần số mới, đảm bảo 3 chữ số
            string maBNmoi = "P" + maBNHT.ToString("D3");

            return maBNmoi; // Trả về mã chức vụ mới
        }
        public bool KTBHYT(string maBN)
        {
            string maBHYT = (db.Patients.Where(x => x.id == maBN).Select(y=> y.InsuranceID )).FirstOrDefault();
            return maBHYT != null;
        }
        public string HienThiBHYT(string maBN)
        {
            string maBHYT = "";
            if(KTBHYT(maBN)==true)
            {
                 maBHYT = (db.Patients.Where(x => x.id == maBN).Select(y => y.InsuranceID)).FirstOrDefault();
            }           
            return maBHYT;
        }
        public IQueryable TimKiemPatient(string TenBN, string sdt)
        {
            IQueryable timKiemBN = (from patient in db.Patients                                   
                                    where patient.fullName.Contains(TenBN)  && patient.phoneNumber == sdt
                                    select new { patient.id, patient.fullName, patient.gender, patient.dob, patient.phoneNumber, patient.TypePatient, patient.citizenID, patient.InsuranceID, patient.address, patient.EmergencyContact, patient.EmergencyPhone, patient.status, patient.createdDate, patient.updatedDate,patient.weight,patient.height });
            return timKiemBN;
        }
    }
}
