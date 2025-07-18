using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class StaffDoctorBLL
    {
        private StaffDoctorDAL dal = new StaffDoctorDAL();

        public StaffDoctorDTO GetDoctorInfo(string id)
        {
            return dal.GetStaffById(id);
        }
    }
}
