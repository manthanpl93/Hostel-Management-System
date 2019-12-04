using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Hostel_Management_System
{
    public partial class Aboutme : Form
    {
        public Aboutme()
        {
            InitializeComponent();
        }

        private void btnmenu_Click(object sender, EventArgs e)
        {
            var homepageform = new Homepage();
            homepageform.Show();
            this.Dispose();
        }

        private void Aboutme_Load(object sender, EventArgs e)
        {
            double fade;
            for (fade = 0.0; fade < 1.1; fade += 0.1)
            {
                this.Opacity = fade;
                this.Refresh();
                Thread.Sleep(30);

            }
        }
    }
}
