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
    public partial class Popup : Form
    {
        public Popup()
        {
            InitializeComponent();
        }

        private void btnyes_Click(object sender, EventArgs e)
        {
            var studentinfoform = new Student_Information();
            studentinfoform.Show();
            this.Hide();
        }
    }
}
