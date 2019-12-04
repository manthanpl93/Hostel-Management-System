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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            double fade;
            for (fade = 0.1; fade < 1.5; fade += 0.1)
            {
                this.Opacity = fade;
                this.Refresh();
                Thread.Sleep(5);

            }
        }
    }
}
