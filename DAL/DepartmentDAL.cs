using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DepartmentDAL
    {
        HospitalManagementDataContext db = new HospitalManagementDataContext();
        public IQueryable HienThi()
        {
            IQueryable DPM = (from dpm in db.Departments
                              select new { dpm.id, dpm.departmentName,dpm.description });
            return DPM;
        }
        public bool ThemDPM(DepartmentDTO dtodpm)
        {
            if (db.Departments.Any(sp => sp.id == dtodpm.Id))
            {
                return false;
            }
            try
            {
                Department dpm = new Department
                {
                    id = dtodpm.Id,
                    departmentName = dtodpm.DepartmentName,
                    description = dtodpm.Description,
                };
                db.Departments.InsertOnSubmit(dpm);
                return true;
            }
            finally
            {
                db.SubmitChanges();
            }
        }
        public bool XoaDPNM(string maDPM)
        {
            try
            {
                var xoa = from dpm in db.Departments
                          where dpm.id == maDPM
                          select dpm;
                foreach (var x in xoa)
                {
                    db.Departments.DeleteOnSubmit(x);
                    db.SubmitChanges();
                }
                return true;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                if (ex.Number == 547)
                {
                    return false;
                }
                return false;
            }
        }
        public bool CapnhatDPM(DepartmentDTO dtodpm)
        {
            try
            {
                if (db.Departments.Where(x => x.id == dtodpm.Id).FirstOrDefault() != null)
                {
                    var update = db.Departments.Single(sp => sp.id == dtodpm.Id);
                    update.departmentName = dtodpm.DepartmentName;  
                    update.description = dtodpm.Description;
                    db.SubmitChanges();
                    return true;
                }
                return false;
            }
            finally
            {
                db.SubmitChanges();
            }
        }
    }
}
