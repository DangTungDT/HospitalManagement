using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class DaiLyCare_DieuDuong : Form
    {
        public DaiLyCare_DieuDuong()
        {
            InitializeComponent();
        }
        DailyCareBLL bll = new DailyCareBLL();
        DailyCareDAL dal = new DailyCareDAL();
        private void DaiLyCare_DieuDuong_Load(object sender, EventArgs e)
        {
            dgvDailyCare.DataSource = bll.GetAll();
        }
    }
}
