using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Data.Sql;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
namespace GUI.Helpers
{
    public static class CrystalReportHelper
    {
        private static readonly string ServerName = GetServerName();
        private static readonly string DatabaseName = "HospitalManagement";
        private static readonly string UserId = "";   // Nếu dùng SQL Auth sau này
        private static readonly string Password = "";

        private static string GetServerName()
        {
            try
            {
                // Lấy từ connection string trong App.config
                var connStr = ConfigurationManager.ConnectionStrings["HospitalManagementConnection"]?.ConnectionString;
                if (!string.IsNullOrEmpty(connStr))
                {
                    var builder = new SqlConnectionStringBuilder(connStr);
                    if (!string.IsNullOrEmpty(builder.DataSource))
                        return builder.DataSource;
                }
            }
            catch
            {
                // Bỏ qua lỗi, sẽ fallback
            }

            // Nếu không tìm thấy connection string -> dùng mặc định
            return Environment.MachineName + "\\SQLEXPRESS";
        }

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

            // Apply cho tất cả bảng chính
            foreach (Table table in report.Database.Tables)
            {
                TableLogOnInfo logonInfo = table.LogOnInfo;
                logonInfo.ConnectionInfo = connectionInfo;
                table.ApplyLogOnInfo(logonInfo);
            }

            // Apply cho subreport (nếu có)
            foreach (ReportDocument subreport in report.Subreports)
            {
                foreach (Table table in subreport.Database.Tables)
                {
                    TableLogOnInfo logonInfo = table.LogOnInfo;
                    logonInfo.ConnectionInfo = connectionInfo;
                    table.ApplyLogOnInfo(logonInfo);
                }
            }

            // Gán tham số nếu có
            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    ParameterValues values = new ParameterValues();
                    ParameterDiscreteValue value = new ParameterDiscreteValue
                    {
                        Value = param.Value
                    };
                    values.Add(value);

                    report.DataDefinition.ParameterFields[param.Key].ApplyCurrentValues(values);
                }
            }

            return report;
        }
    }
}

