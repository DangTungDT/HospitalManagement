using GUI;

static void Main()
{
    Application.EnableVisualStyles();
    Application.SetCompatibleTextRenderingDefault(false);
    // Chạy thử form thông tin nhân viên với username mẫu
    Application.Run(new frmUserInformation("admin"));
} 