using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LabTestTypeAdminBLL
    {
        private LabTestTypeAdminDAL dal = new LabTestTypeAdminDAL();

        public List<LabTestTypeDocTorDTO> GetAll()
        {
            return dal.GetAll();
        }

        public bool Add(LabTestTypeDocTorDTO dto)
        {
            return dal.Add(dto);
        }

        public bool Update(LabTestTypeDocTorDTO dto)
        {
            return dal.Update(dto);
        }

        public bool IsTestTypeNameExists(string name, int? excludeId = null)
        {
            return dal.IsTestTypeNameExists(name, excludeId);
        }

        public bool IsInUse(int id)
        {
            return dal.IsInUse(id);
        }

        public bool Delete(int id)
        {
            return dal.Delete(id);
        }

    }
}
