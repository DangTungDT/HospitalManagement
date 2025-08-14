using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ApmentDAL
    {
        HospitalManagementDataContext db = new HospitalManagementDataContext();
        public IQueryable HienThi()
        {
            IQueryable Aptm = (from aptm in db.Appointments
                               select new { aptm.id, aptm.startDate, aptm.note, aptm.status, aptm.doctorID, aptm.patientID });
            return Aptm;
        }
        public IQueryable LaydsBacsi()
        {
            IQueryable BS = (from bs in db.DoctorPatients
                             join nv in db.Staffs on bs.doctorID equals nv.id
                             select new { bs.doctorID, nv.name }
                             );
            return BS;
        }
        public IQueryable LaydsBN()
        {
            IQueryable BN = (from bn in db.Patients
                             select new { bn.id, bn.fullName });
            return BN;
        }
        public bool Themappointment(ApmentDTO dtoivt)
        {
            if (db.Appointments.Any(sp => sp.startDate == dtoivt.StarDate && sp.doctorID == dtoivt.DoctorID))
            {
                return false;
            }
            try
            {
                Appointment ivt = new Appointment
                {
                    startDate = dtoivt.StarDate,
                    note = dtoivt.Note,
                    status = dtoivt.Status,
                    doctorID = dtoivt.DoctorID,
                    patientID = dtoivt.PatientID,
                };
                db.Appointments.InsertOnSubmit(ivt);
                return true;
            }
            finally
            {
                db.SubmitChanges();
            }
        }
        public bool Xoaappointment(int id)
        {
            try
            {
                Appointment xoa = (from apm in db.Appointments
                                   where apm.id == id
                                   select apm).FirstOrDefault();
                if (xoa != null)
                {
                    db.Appointments.DeleteOnSubmit(xoa);
                    db.SubmitChanges();
                    return true;
                }
                return false;
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
        public bool CapnhatLichHen(ApmentDTO dtoapm)
        {
            try
            {
                var update = db.Appointments.SingleOrDefault(sp => sp.id == dtoapm.Id);
                if (update != null)
                {
                    update.startDate = dtoapm.StarDate;
                    update.note = dtoapm.Note;
                    update.status = dtoapm.Status;
                    update.doctorID = dtoapm.DoctorID;
                    update.patientID = dtoapm.PatientID;
                    db.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi khi cập nhật lịch hẹn: {ex.Message}");
                return false;
            }
        }
        public List<Appointment> TimKiemAppointmentTheoStartDate(DateTime ngayBatDau)
        {
            DateTime ngayTiepTheo = ngayBatDau.Date.AddDays(1);

            var ketQua = db.Appointments
                           .Where(ap => ap.startDate >= ngayBatDau.Date
                                     && ap.startDate < ngayTiepTheo)
                           .ToList();

            return ketQua;
        }
    }
}

