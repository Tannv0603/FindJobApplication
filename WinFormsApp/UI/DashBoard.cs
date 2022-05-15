using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp.Services.CityServices;

namespace WinFormsApp.UI
{
    public partial class DashBoard : Form
    {
        private readonly ICityService _cityServices = new CityServices();
        
        public DashBoard()
        {
            InitializeComponent();
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _cityServices.GetAll();
        }
    }
}
