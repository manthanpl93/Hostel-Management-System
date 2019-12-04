using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Data.SqlClient;
namespace Hostel_Management_System
{
    public partial class Login : Form
    {
        SqlConnection cn = new SqlConnection(Hostelcodesource.database.cs);
        public Login()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            //Remark: This Event Is Used For Login Process

            SqlDataAdapter da = new SqlDataAdapter("select * from login where username='" + txtusername.Text + "' and password='" + txtpassword.Text + "'", cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                var homepageform = new Homepage();
                homepageform.Show();
                this.Hide();
            }

            else
            {
                SoundPlayer sound = new SoundPlayer(@"c:\Windows\Media\chimes.wav");
                sound.Play();
                MessageBox.Show("User-name and Password Incorrect enter valid username& password", "Wrong Username-Password", MessageBoxButtons.OK);
            }
            
            

        }

        private void txtpassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                btnlogin_Click(sender,e);
            }
        }
    }
}
