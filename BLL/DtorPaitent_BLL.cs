using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class DtorPaitent_BLL
    {
        DtorPaitentDAL dal = new DtorPaitentDAL();
        public List<DoctorPatientDTO> GetAll()
        {
            return dal.GetAll();
        }
        public bool Add(DoctorPatientDTO dto)
        {
            return dal.InsertWithPatientCheck(dto);
        }

        public bool Edit(DoctorPatientDTO dto)
        {
            return dal.UpdateWithPatientCheck(dto);
        }

        public bool Remove(string doctorID, string patientID, bool deletePatient = false)
        {
            return dal.DeleteWithCheck(doctorID, patientID, deletePatient);
        }
    }
}
