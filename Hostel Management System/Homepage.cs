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
    public partial class Homepage : Form
    {
        public Homepage()
        {
            InitializeComponent();
        }

        
       
        
        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void Registraion_Click(object sender, EventArgs e)
        {
            var registrationform = new Registration();
            registrationform.Show();
            this.Hide();

        }

        private void StudentInfo_Click(object sender, EventArgs e)
        {
            var studentinfoform = new Student_Information();
            studentinfoform.Show();
            this.Hide();
        }

        private void RoomDetails_Click(object sender, EventArgs e)
        {
            var roomdetailsform = new RoomDetails();
            roomdetailsform.Show();
            this.Hide();
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void minimize_Click(object sender, EventArgs e)
        {
            
        }

        private void FeesData_Click(object sender, EventArgs e)
        {
            var feesdataform = new Fees_Details();
            feesdataform.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var usersettingform = new Usersettings();
            usersettingform.Show();
            this.Hide();
        }

        private void Homepage_Load(object sender, EventArgs e)
        {
           
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var webcamform = new Webcamera();
            webcamform.Show();
            //var popup = new GenralPopup();
            //popup.Show();
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            var aboutform = new Aboutme();
            aboutform.Show();
            this.Dispose();
        }

        private void btnlunchmanegement_Click(object sender, EventArgs e)
        {
            var lunchform = new Lunchmanagement();
            lunchform.Show();
            this.Dispose();
        }
    }
}
