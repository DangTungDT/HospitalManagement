using DAL;
using DTO;
using System.Collections.Generic;

namespace BLL
{
    public class TestTypeInfoDoctorBLL
    {
        private TestTypeInfoDoctorDAL dal = new TestTypeInfoDoctorDAL();

        // Lấy tất cả loại xét nghiệm
        public List<TestTypeInfoDoctorDTO> GetAll()
        {
            return dal.GetAll();
        }

        // Tìm kiếm loại xét nghiệm theo tên
        public List<TestTypeInfoDoctorDTO> Search(string testTypeName)
        {
            return dal.Search(testTypeName);
        }
    }
}
