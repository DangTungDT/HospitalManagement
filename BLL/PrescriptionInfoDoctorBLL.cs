using System;
using System.Collections.Generic;
using DTO;

namespace BLL
{
    public class PrescriptionInfoDoctorBLL
    {
        private DAL.PrescriptionInfoDoctorDAL dal = new DAL.PrescriptionInfoDoctorDAL();

        // Lấy tất cả đơn thuốc
        public List<PrescriptionInfoDoctorDTO> GetAll()
        {
            return dal.GetAll();
        }

        // Thêm đơn thuốc
        public bool Insert(PrescriptionInfoDoctorDTO dto)
        {
            return dal.Insert(dto);
        }

        // Cập nhật đơn thuốc
        public bool Update(PrescriptionInfoDoctorDTO dto)
        {
            return dal.Update(dto);
        }

        // Tìm kiếm/lọc đơn thuốc
        public List<PrescriptionInfoDoctorDTO> Search(string patientId, string doctorId, DateTime? orderDate)
        {
            return dal.Search(patientId, doctorId, orderDate);
        }

        // Lấy danh sách bệnh nhân cho ComboBox
        public List<PatientComboDTO> GetPatients()
        {
            return dal.GetPatients();
        }

        // Lấy danh sách bệnh nhân theo bác sĩ cho ComboBox
        public List<PatientComboDTO> GetPatientsByDoctor(string doctorId)
        {
            return dal.GetPatientsByDoctor(doctorId);
        }

        // Lấy danh sách bác sĩ cho ComboBox
        public List<DoctorListbyDepartmentDTO> GetDoctors()
        {
            return dal.GetDoctors();
        }
    }
}
