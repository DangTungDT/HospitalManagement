using System;
using System.Linq;
using DTO;
using DAL;
using System.Collections.Generic;

namespace BLL
{
    public class PrescriptionOfPatientBLL
    {
        private PrescriptionOfPatientDAL dal = new PrescriptionOfPatientDAL();

        public List<PrescriptionOfPatientDTO> GetPrescriptionReport(string patientId, DateTime? orderDate)
        {
            return dal.GetPrescriptionReport(patientId, orderDate);
        }

        public List<PatientComboDTO> GetAllPatients()
        {
            return dal.GetAllPatients();
        }
    }
}
