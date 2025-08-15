using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MedicalOrderYLenhDAL
    {
        HospitalManagementDataContext db = new HospitalManagementDataContext();
        public IQueryable HienThi()
        {
            IQueryable meditical = (from mdtc in db.MedicalOrders
                               select new { mdtc.id, mdtc.PatientID, mdtc.DoctorID, mdtc.OrderType, mdtc.ItemID, mdtc.TestTypeID, mdtc.HasLabTest, mdtc.Dosage, mdtc.Quantity, mdtc.Unit, mdtc.Frequency, mdtc.StartDate, mdtc.EndDate, mdtc.Status, mdtc.CreatedAt, mdtc.SignedAt, mdtc.Note });
            return meditical;
        }
        public bool ThemMediticalYlenh(MedicalOrderYLenhDTO dtoylenh)
        {
            if (db.MedicalOrders.Any(sp => sp.PatientID == dtoylenh.PatientId && sp.DoctorID == dtoylenh.DoctorId))
            {
                return false;
            }
            try
            {
                MedicalOrder mdtc = new MedicalOrder
                {
                    PatientID = dtoylenh.PatientId,
                    DoctorID = dtoylenh.DoctorId,
                    OrderType = dtoylenh.OrderType,
                    ItemID = dtoylenh.ItemId,
                    TestTypeID = dtoylenh.TestType,
                    HasLabTest = dtoylenh.HasLabTest,
                    Dosage = dtoylenh.Dosage,
                    Quantity = dtoylenh.Quantity,
                    Unit = dtoylenh.Unit,
                    Frequency = dtoylenh.Frequency,
                    StartDate = dtoylenh.StartDate,
                    EndDate = dtoylenh.EndDate,
                    Status = dtoylenh.Status,
                    CreatedAt = dtoylenh.CreatedAt,
                    SignedAt = dtoylenh.SignedAt,
                    Note = dtoylenh.Note
                };
                db.MedicalOrders.InsertOnSubmit(mdtc);
                return true;
            }
            finally
            {
                db.SubmitChanges();
            }
        }
        public bool CapnhatYlenh(MedicalOrderYLenhDTO dtoylenh)
        {
            try
            {
                if (db.MedicalOrders.Where(x => x.id == dtoylenh.Id).FirstOrDefault() != null)
                {
                    var update = db.MedicalOrders.Where(sp => sp.id == dtoylenh.Id).FirstOrDefault();
                    if (update != null)
                    {
                        update.PatientID = dtoylenh.PatientId;
                        update.DoctorID = dtoylenh.DoctorId;
                        update.OrderType = dtoylenh.OrderType;
                        update.ItemID = dtoylenh.ItemId;
                        update.TestTypeID = dtoylenh.TestType;                        update.HasLabTest = dtoylenh.HasLabTest;
                        update.Dosage = dtoylenh.Dosage;
                        update.Quantity = dtoylenh.Quantity;
                        update.Unit = dtoylenh.Unit;
                        update.Frequency = dtoylenh.Frequency;
                        update.StartDate = dtoylenh.StartDate;
                        update.EndDate = dtoylenh.EndDate;
                        update.Status = dtoylenh.Status;
                        update.CreatedAt = dtoylenh.CreatedAt;
                        update.SignedAt = dtoylenh.SignedAt;
                        update.Note = dtoylenh.Note;
                        db.SubmitChanges();
                        return true;
                    }
                    return false;
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

