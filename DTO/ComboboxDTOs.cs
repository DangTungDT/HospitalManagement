using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    /// <summary>
    /// DTO chứa thông tin cơ bản (Id, Name) của Bác sĩ cho ComboBox.
    /// </summary>
    public class StaffComboboxDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    /// <summary>
    /// DTO chứa thông tin cơ bản (Id, Name) của Bệnh nhân cho ComboBox.
    /// </summary>
    public class PatientComboboxDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    /// <summary>
    /// DTO chứa thông tin cơ bản (Id, Name) của Vật tư/Thuốc cho ComboBox.
    /// </summary>
    public class ItemComboboxDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    /// <summary>
    /// DTO chứa thông tin cơ bản (Id, Name) của Xét nghiệm cho ComboBox.
    /// </summary>
    public class LabTestComboboxDTO
    {
        public int Id { get; set; } // Khóa chính của LaboratoryTest là INT
        public string Name { get; set; }
    }
}
