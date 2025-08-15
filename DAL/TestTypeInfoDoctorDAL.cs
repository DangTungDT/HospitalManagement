using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class TestTypeInfoDoctorDAL
    {
        private HospitalManagementDataContext db = new HospitalManagementDataContext();

        // Lấy tất cả loại xét nghiệm
        public List<TestTypeInfoDoctorDTO> GetAll()
        {
            try
            {
                var query = from lt in db.LabTestTypes
                            select new TestTypeInfoDoctorDTO
                            {
                                TestTypeID = lt.id,
                                TestTypeName = lt.testTypeName
                            };
                return query.ToList();
            }
            catch (Exception ex)
            {
                // Trả về list rỗng nếu có lỗi
                return new List<TestTypeInfoDoctorDTO>();
            }
        }

        // Tìm kiếm loại xét nghiệm theo tên
        public List<TestTypeInfoDoctorDTO> Search(string testTypeName)
        {
            try
            {
                var query = from lt in db.LabTestTypes
                            where string.IsNullOrEmpty(testTypeName) || lt.testTypeName.Contains(testTypeName)
                            select new TestTypeInfoDoctorDTO
                            {
                                TestTypeID = lt.id,
                                TestTypeName = lt.testTypeName
                            };
                return query.ToList();
            }
            catch (Exception ex)
            {
                // Trả về list rỗng nếu có lỗi
                return new List<TestTypeInfoDoctorDTO>();
            }
        }
    }
}
