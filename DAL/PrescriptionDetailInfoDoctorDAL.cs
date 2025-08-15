using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class PrescriptionDetailInfoDoctorDAL
    {
        private HospitalManagementDataContext db = new HospitalManagementDataContext();

        // Lấy tất cả chi tiết đơn thuốc
        public List<PrescriptionDetailInfoDoctorDTO> GetAll()
        {
            // Lấy tất cả bản ghi chi tiết (có ItemID) và join với đơn thuốc gốc
            var query = from detail in db.MedicalOrders
                        join original in db.MedicalOrders on new { detail.PatientID, detail.DoctorID, detail.CreatedAt } 
                        equals new { original.PatientID, original.DoctorID, original.CreatedAt }
                        join i in db.Items on detail.ItemID equals i.ID
                        where detail.OrderType == "Thuốc" && detail.ItemID != null 
                        && original.OrderType == "Thuốc" && original.ItemID == null
                        select new PrescriptionDetailInfoDoctorDTO
                        {
                            MedicalOrderID = detail.id, // ID của bản ghi chi tiết
                            PrescriptionID = original.id.ToString(), // ID của đơn thuốc gốc
                            ItemID = detail.ItemID,
                            Quantity = detail.Quantity ?? 0,
                            Unit = FixUnitEncoding(detail.Unit),
                            Dosage = detail.Dosage,
                            Frequency = detail.Frequency,
                            Note = detail.Note,
                            ItemName = i.ItemName,
                            ItemType = i.ItemType,
                            Price = i.Price ?? 0
                        };
            return query.ToList();
        }

        // Lấy chi tiết đơn thuốc theo mã đơn thuốc
        public List<PrescriptionDetailInfoDoctorDTO> GetByPrescriptionID(string prescriptionID)
        {
            int id = int.Parse(prescriptionID);
            var query = from detail in db.MedicalOrders
                        join original in db.MedicalOrders on new { detail.PatientID, detail.DoctorID, detail.CreatedAt } 
                        equals new { original.PatientID, original.DoctorID, original.CreatedAt }
                        join i in db.Items on detail.ItemID equals i.ID
                        where original.id == id && detail.OrderType == "Thuốc" && detail.ItemID != null 
                        && original.OrderType == "Thuốc" && original.ItemID == null
                        select new PrescriptionDetailInfoDoctorDTO
                        {
                            MedicalOrderID = detail.id,
                            PrescriptionID = original.id.ToString(),
                            ItemID = detail.ItemID,
                            Quantity = detail.Quantity ?? 0,
                            Unit = FixUnitEncoding(detail.Unit),
                            Dosage = detail.Dosage,
                            Frequency = detail.Frequency,
                            Note = detail.Note,
                            ItemName = i.ItemName,
                            ItemType = i.ItemType,
                            Price = i.Price ?? 0
                        };
            return query.ToList();
        }

        // Helper method để xử lý đơn vị một cách nhất quán
        private string FixUnitEncoding(string unit)
        {
            if (string.IsNullOrEmpty(unit))
                return unit;
                
            // Xử lý các trường hợp lỗi encoding phổ biến
            if (unit.Contains("?") || unit.Contains("H?p") || unit.Contains("Hộp") == false && unit.Contains("H") && unit.Contains("p"))
            {
                return "Hộp";
            }
            
            // Xử lý các trường hợp khác nếu có
            if (unit.Contains("Viên") == false && unit.Contains("V") && unit.Contains("n"))
            {
                return "Viên";
            }
            
            if (unit.Contains("Chai") == false && unit.Contains("C") && unit.Contains("i"))
            {
                return "Chai";
            }
            
            return unit;
        }

        // Thêm chi tiết đơn thuốc mới (thêm thuốc vào đơn thuốc đã có PrescriptionID)
        public bool Insert(PrescriptionDetailInfoDoctorDTO dto)
        {
            try
            {
                int prescriptionId = int.Parse(dto.PrescriptionID);
                
                // Kiểm tra đơn thuốc gốc có tồn tại không
                var originalPrescription = db.MedicalOrders.FirstOrDefault(x => x.id == prescriptionId && x.ItemID == null);
                if (originalPrescription == null) 
                {
                    return false; // Đơn thuốc không tồn tại
                }

                // Kiểm tra thuốc đã tồn tại trong đơn thuốc này chưa
                var duplicateItem = db.MedicalOrders.Any(x => 
                    x.PatientID == originalPrescription.PatientID && 
                    x.DoctorID == originalPrescription.DoctorID && 
                    x.CreatedAt == originalPrescription.CreatedAt && 
                    x.OrderType == "Thuốc" && 
                    x.ItemID == dto.ItemID);
                
                if (duplicateItem)
                {
                    return false; // Thuốc này đã có trong đơn
                }

                var mo = new MedicalOrder
                {
                    PatientID = originalPrescription.PatientID,
                    DoctorID = originalPrescription.DoctorID,
                    OrderType = "Thuốc",
                    ItemID = dto.ItemID,
                    Quantity = dto.Quantity,
                    Unit = FixUnitEncoding(dto.Unit),
                    Dosage = dto.Dosage,
                    Frequency = dto.Frequency,
                    Note = dto.Note,
                    CreatedAt = originalPrescription.CreatedAt
                };
                db.MedicalOrders.InsertOnSubmit(mo);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // Cập nhật chi tiết đơn thuốc
        public bool Update(PrescriptionDetailInfoDoctorDTO dto)
        {
            try
            {
                int medicalOrderId = dto.MedicalOrderID; // Sử dụng MedicalOrderID thay vì PrescriptionID
                var mo = db.MedicalOrders.FirstOrDefault(x => x.id == medicalOrderId);
                if (mo == null) return false;
                
                mo.ItemID = dto.ItemID;
                mo.Quantity = dto.Quantity;
                mo.Unit = FixUnitEncoding(dto.Unit);
                mo.Dosage = dto.Dosage;
                mo.Frequency = dto.Frequency;
                mo.Note = dto.Note;
                
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // Xóa chi tiết đơn thuốc
        public bool Delete(string medicalOrderID)
        {
            try
            {
                int medicalOrderId = int.Parse(medicalOrderID); // Đây là MedicalOrderID
                var mo = db.MedicalOrders.FirstOrDefault(x => x.id == medicalOrderId);
                if (mo == null) return false;
                
                db.MedicalOrders.DeleteOnSubmit(mo);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // Lấy danh sách đơn thuốc để hiển thị trong ComboBox
        public List<PrescriptionComboDTO> GetPrescriptions()
        {
            var query = from original in db.MedicalOrders
                        join p in db.Patients on original.PatientID equals p.id
                        join s in db.Staffs on original.DoctorID equals s.id
                        where original.OrderType == "Thuốc" && original.ItemID == null // Chỉ lấy đơn thuốc gốc
                        select new PrescriptionComboDTO
                        {
                            PrescriptionID = original.id.ToString(),
                            PrescriptionName = $"Đơn {original.id} - {p.fullName} - {s.name}"
                        };
            return query.ToList();
        }

        // Lấy danh sách thuốc cho ComboBox
        public List<ItemComboDTO> GetItems()
        {
            return db.Items.Where(i => i.ItemType == "Medicine" && i.IsActive == true)
                .Select(i => new ItemComboDTO 
                { 
                    ItemID = i.ID, 
                    ItemName = i.ItemName,
                    Price = i.Price ?? 0,
                    Unit = FixUnitEncoding(i.Unit)
                })
                .ToList();
        }
    }
}
