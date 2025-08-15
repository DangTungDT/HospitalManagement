using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LabTestTypeAdminDAL
    {
        HospitalManagementDataContext db = new HospitalManagementDataContext();

        // Lấy tất cả
        public List<LabTestTypeDocTorDTO> GetAll()
        {
            return db.LabTestTypes
                     .Select(t => new LabTestTypeDocTorDTO
                     {
                         Id = t.id,
                         TestTypeName = t.testTypeName
                     })
                     .ToList();
        }

        // Kiểm tra tên có tồn tại chưa
        public bool IsTestTypeNameExists(string name, int? excludeId = null)
        {
            name = name.Trim().ToLower();
            return db.LabTestTypes.Any(t => t.testTypeName.ToLower() == name && (excludeId == null || t.id != excludeId));
        }

        // Thêm mới
        public bool Add(LabTestTypeDocTorDTO dto)
        {
            if (IsTestTypeNameExists(dto.TestTypeName)) return false;

            var newType = new LabTestType
            {
                testTypeName = dto.TestTypeName.Trim()
            };

            db.LabTestTypes.InsertOnSubmit(newType);
            db.SubmitChanges();
            return true;
        }

        // Kiểm tra đang được sử dụng trong MedicalOrder
        public bool IsInUse(int id)
        {
            return db.MedicalOrders.Any(m => m.TestTypeID == id);
        }
        public bool Update(LabTestTypeDocTorDTO dto)
        {
            var existing = db.LabTestTypes.FirstOrDefault(x => x.id == dto.Id);
            if (existing == null) return false;
            if (CheckNameExistsExceptId(dto.TestTypeName, dto.Id)) return false;

            existing.testTypeName = dto.TestTypeName;
            db.SubmitChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var existing = db.LabTestTypes.FirstOrDefault(x => x.id == id);
            if (existing == null) return false;

            // Xóa các MedicalOrder liên quan
            var relatedOrders = db.MedicalOrders.Where(o => o.TestTypeID == id).ToList();
            db.MedicalOrders.DeleteAllOnSubmit(relatedOrders);

            db.LabTestTypes.DeleteOnSubmit(existing);
            db.SubmitChanges();
            return true;
        }
        public bool CheckNameExists(string name)
        {
            return db.LabTestTypes.Any(x => x.testTypeName.ToLower() == name.ToLower());
        }

        public bool CheckNameExistsExceptId(string name, int id)
        {
            return db.LabTestTypes.Any(x => x.testTypeName.ToLower() == name.ToLower() && x.id != id);
        }

    }
}

