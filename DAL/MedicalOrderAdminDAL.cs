using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// Lớp DAL cho Y lệnh, thực hiện các thao tác trên CSDL.
    /// </summary>
    public class MedicalOrderDAL
    {
        HospitalManagementDataContext db = new HospitalManagementDataContext();

        private List<LoaiYLenhDTO> listLoaiYLenh = new List<LoaiYLenhDTO>
        {
            new LoaiYLenhDTO { MaLoai = "THUOC", TenLoai = "Thuốc" },
            new LoaiYLenhDTO { MaLoai = "XETNGHIEM", TenLoai = "Xét nghiệm" },
            new LoaiYLenhDTO { MaLoai = "KHAC", TenLoai = "Chỉ định khác" }
        };

        /// <summary>
        /// Lấy tất cả y lệnh, join với các bảng khác để có tên.
        /// </summary>
        public List<MedicalOrderDTO> GetAll()
        {
            var query = from mo in db.MedicalOrders
                        join p in db.Patients on mo.PatientID equals p.id
                        join d in db.Staffs on mo.DoctorID equals d.id
                        // Left Join với bảng Items vì ItemID có thể null
                        join it in db.Items on mo.ItemID equals it.ID into itemGroup
                        from item in itemGroup.DefaultIfEmpty()
                        // Left Join với bảng LaboratoryTest vì TestTypeID có thể null
                        join lt in db.LaboratoryTests on mo.TestTypeID equals lt.id into testGroup
                        from test in testGroup.DefaultIfEmpty()
                        orderby mo.CreatedAt descending
                        select new MedicalOrderDTO
                        {
                            id = mo.id,
                            PatientID = mo.PatientID,
                            DoctorID = mo.DoctorID,
                            OrderType = mo.OrderType,
                            ItemID = mo.ItemID,
                            TestTypeID = mo.TestTypeID,
                            Dosage = mo.Dosage,
                            Quantity = mo.Quantity,
                            Unit = mo.Unit,
                            Frequency = mo.Frequency,
                            StartDate = mo.StartDate,
                            EndDate = mo.EndDate,
                            Status = mo.Status,
                            CreatedAt = (DateTime)mo.CreatedAt,
                            SignedAt = mo.SignedAt,
                            Note = mo.Note,
                            // Lấy tên từ các bảng đã join
                            PatientName = p.fullName,
                            DoctorName = d.name,
                            ItemName = item != null ? item.ItemName : "N/A", // Nếu item null thì hiển thị N/A
                            TestName = test != null ? test.testName : "N/A"  // Nếu test null thì hiển thị N/A
                        };
            return query.ToList();
        }

        #region "Lấy dữ liệu cho ComboBox"
        public List<PatientComboboxDTO> GetPatients()
        {
            return db.Patients
                     .Select(p => new PatientComboboxDTO { Id = p.id, Name = p.fullName })
                     .ToList();
        }

        public List<StaffComboboxDTO> GetDoctors()
        {
            return db.Staffs.Where(s => s.role == "Bác sĩ")
                            .Select(s => new StaffComboboxDTO { Id = s.id, Name = s.name })
                            .ToList();
        }

        public List<ItemComboboxDTO> GetItems()
        {
            return db.Items.Where(it => it.ItemType == "Medicine")
                           .Select(i => new ItemComboboxDTO { Id = i.ID, Name = i.ItemName })
                           .ToList();
        }

        public List<LabTestComboboxDTO> GetLabTests()
        {
            // Lưu ý: CSDL của bạn có vẻ đang dùng bảng LaboratoryTest để lưu cả "loại xét nghiệm" và "kết quả xét nghiệm".
            // Tạm thời sẽ lấy các tên xét nghiệm không trùng lặp.
            return db.LaboratoryTests
                     .Select(t => new LabTestComboboxDTO { Id = t.id, Name = t.testName })
                     .Distinct() // Cân nhắc nếu có nhiều test trùng tên nhưng khác ID
                     .ToList();
        }
        #endregion

        /// <summary>
        /// Thêm một y lệnh mới.
        /// </summary>
        public bool Add(MedicalOrderDTO mo)
        {
            try
            {
                MedicalOrder newMo = new MedicalOrder
                {
                    PatientID = mo.PatientID,
                    DoctorID = mo.DoctorID,
                    OrderType = mo.OrderType,
                    ItemID = mo.ItemID,
                    TestTypeID = mo.TestTypeID,
                    Dosage = mo.Dosage,
                    Quantity = mo.Quantity,
                    Unit = mo.Unit,
                    Frequency = mo.Frequency,
                    StartDate = mo.StartDate,
                    EndDate = mo.EndDate,
                    Status = mo.Status,
                    CreatedAt = DateTime.Now, // Tự động lấy giờ hiện tại
                    SignedAt = mo.SignedAt,
                    Note = mo.Note
                };
                db.MedicalOrders.InsertOnSubmit(newMo);
                db.SubmitChanges();
                return true;
            }
            catch { return false; }
        }

        /// <summary>
        /// Cập nhật một y lệnh.
        /// </summary>
        public bool Update(MedicalOrderDTO mo)
        {
            try
            {
                MedicalOrder existingMo = db.MedicalOrders.SingleOrDefault(m => m.id == mo.id);
                if (existingMo == null) return false;

                existingMo.PatientID = mo.PatientID;
                existingMo.DoctorID = mo.DoctorID;
                existingMo.OrderType = mo.OrderType;
                existingMo.ItemID = mo.ItemID;
                existingMo.TestTypeID = mo.TestTypeID;
                existingMo.Dosage = mo.Dosage;
                existingMo.Quantity = mo.Quantity;
                existingMo.Unit = mo.Unit;
                existingMo.Frequency = mo.Frequency;
                existingMo.StartDate = mo.StartDate;
                existingMo.EndDate = mo.EndDate;
                existingMo.Status = mo.Status;
                existingMo.SignedAt = mo.SignedAt;
                existingMo.Note = mo.Note;

                db.SubmitChanges();
                return true;
            }
            catch { return false; }
        }

        /// <summary>
        /// Xóa một y lệnh theo ID.
        /// </summary>
        public bool Delete(int id)
        {
            try
            {
                MedicalOrder moToDelete = db.MedicalOrders.SingleOrDefault(m => m.id == id);
                if (moToDelete == null) return false;

                db.MedicalOrders.DeleteOnSubmit(moToDelete);
                db.SubmitChanges();
                return true;
            }
            catch { return false; }
        }
    }
}
