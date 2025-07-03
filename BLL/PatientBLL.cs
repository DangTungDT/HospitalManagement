using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.Sql;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PatientBLL
    {
        PatientBLL bll = new PatientBLL();

        private IQueryable GetAll()
        {
            return bll.GetAll();
        }
        private int Add(PatientDTO dto)
        {
            return bll.Add(dto);
        }

        private bool Delete(string id)
        { 
            return bll.Delete(id);
        }

        private int Update(PatientDTO dto)
        {
            return bll.Update(dto);
        }
    }
}
