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
        PatientDAL dal = new PatientDAL();

        public IQueryable GetAll()
        {
            return dal.GetAll();
        }
            public int Add(PatientDTO dto)
        {
            try
            {
                if(string.IsNullOrEmpty(dto.Id) || string.IsNullOrEmpty(dto.FullName) || string.IsNullOrEmpty(dto.Gender) || 
                    dto.Dob > DateTime.Now || string.IsNullOrEmpty(dto.PhoneNumber) || string.IsNullOrEmpty(dto.CitizenID) || 
                    string.IsNullOrEmpty(dto.Address) || string.IsNullOrEmpty(dto.EmergencyContact) || string.IsNullOrEmpty(dto.EmergencyPhone) || 
                    string.IsNullOrEmpty(dto.Status) || dto.Weight <= 0 || dto.Height <=0)
                {
                    return -2;
                }
                return dal.Add(dto);
            }
            catch(Exception ex)
            {
                return 2;
            }
            
        }

        public bool Delete(string id)
        {
            try
            {
                if(string.IsNullOrEmpty(id))
                {
                    return false;
                }
                return dal.Delete(id);
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public int Update(PatientDTO dto)
        {
            try
            {
                if (string.IsNullOrEmpty(dto.Id) || string.IsNullOrEmpty(dto.FullName) || string.IsNullOrEmpty(dto.Gender) ||
                    dto.Dob > DateTime.Now || string.IsNullOrEmpty(dto.PhoneNumber) || string.IsNullOrEmpty(dto.CitizenID) ||
                    string.IsNullOrEmpty(dto.Address) || string.IsNullOrEmpty(dto.EmergencyContact) || string.IsNullOrEmpty(dto.EmergencyPhone) ||
                    string.IsNullOrEmpty(dto.Status) || dto.Weight <= 0 || dto.Height <= 0)
                {
                    return -2;
                }
                return dal.Update(dto);
            }
            catch (Exception ex)
            {
                return 2;
            }
        }
    }
}
