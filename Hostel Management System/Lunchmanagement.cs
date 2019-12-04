using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hostel_Management_System
{
    public partial class Lunchmanagement : Form
    {
        public Lunchmanagement()
        {
            InitializeComponent();
        }

        private void btnmenu_Click(object sender, EventArgs e)
        {
            var homeform = new Homepage();
            homeform.Show();
            this.Dispose();
        }
    }
}
