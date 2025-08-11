using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Helpers
{
    public static class CrystalReportHelper
    {
        // Gắn cứng thông tin kết nối
        private static readonly string ServerName = @"LAPTOP-S013149L\SQLEXPRESS";
        private static readonly string DatabaseName = "HospitalManagement";
        private static readonly string UserId = "";   // Nếu dùng SQL Auth sau này
        private static readonly string Password = "";

        public static ReportDocument LoadReport(string reportFileName, Dictionary<string, object> parameters = null)
        {
            string reportPath = Path.Combine(Application.StartupPath, "Report", reportFileName);

            if (!File.Exists(reportPath))
            {
                MessageBox.Show("Không tìm thấy file báo cáo: " + reportPath, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            ReportDocument report = new ReportDocument();
            report.Load(reportPath);

            // Thiết lập kết nối
            ConnectionInfo connectionInfo = new ConnectionInfo
            {
                ServerName = ServerName,
                DatabaseName = DatabaseName,
                UserID = UserId,
                Password = Password,
                IntegratedSecurity = true
            };

            foreach (Table table in report.Database.Tables)
            {
                TableLogOnInfo logonInfo = table.LogOnInfo;
                logonInfo.ConnectionInfo = connectionInfo;
                table.ApplyLogOnInfo(logonInfo);
            }

            // Gán tham số nếu có
            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    ParameterValues values = new ParameterValues();
                    ParameterDiscreteValue value = new ParameterDiscreteValue();
                    value.Value = param.Value;
                    values.Add(value);

                    report.DataDefinition.ParameterFields[param.Key].ApplyCurrentValues(values);
                }
            }

            return report;
        }
    }
}

