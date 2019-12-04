using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Data.SqlClient;
using System.IO;

namespace Hostel_Management_System
{
    public partial class studentadvancedetails : Form
    {
        SqlConnection cn = new SqlConnection(Hostelcodesource.database.cs);
        string studentid = null;
        public studentadvancedetails()
        {
            InitializeComponent();
        }

        private void studentadvancedetails_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hostelSystemAttendanceds.Attendance' table. You can move, or remove it, as needed.
            //this.attendanceTableAdapter.Fill(this.hostelSystemAttendanceds.Attendance);
            // TODO: This line of code loads data into the 'hostelSystemDataSetRoomExchanged.RoomExchange' table. You can move, or remove it, as needed.
            //this.roomExchangeTableAdapter.Fill(this.hostelSystemDataSetRoomExchanged.RoomExchange);
            // TODO: This line of code loads data into the 'hostelSystemDataSet1.StudentFees' table. You can move, or remove it, as needed.
           // this.studentFeesTableAdapter.Fill(this.hostelSystemDataSet1.StudentFees);
            double fade;
            for (fade = 0.0; fade < 1.1; fade += 0.1)
            {
                this.Opacity = fade;
                this.Refresh();
                Thread.Sleep(30);

            }

            SqlDataAdapter da = new SqlDataAdapter("select * from StudentFees where StudentId=" + studentdetail.studentid + "", cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dgfeesview.DataSource = ds.Tables[0];
        
           
            SqlDataAdapter da2 = new SqlDataAdapter("select StudentName,RoomNumber,Building from HostelRoomDetails where StudentId=" + studentdetail.studentid + "", cn);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            txtstudentname.Text = ds2.Tables[0].Rows[0][0].ToString();
            txtroomno.Text = ds2.Tables[0].Rows[0][1].ToString();
            txtbuilding.Text = ds2.Tables[0].Rows[0][2].ToString();

            SqlDataAdapter da3 = new SqlDataAdapter("select Image from StudentDetails where Id="+ studentdetail.studentid +"", cn);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            var data = (Byte[])(ds3.Tables[0].Rows[0][0]);
            var stream = new MemoryStream(data);

            pbphoto.BackgroundImage = Image.FromStream(stream);



            SqlDataAdapter da4 = new SqlDataAdapter("select * from RoomExchange where Id=" + studentdetail.studentid + "", cn);
            DataSet ds4 = new DataSet();
            da4.Fill(ds4);
            dgroomexchangedview.DataSource = ds4.Tables[0];

            studentid = studentdetail.studentid;

            SqlDataAdapter da5 = new SqlDataAdapter("select * from Attendance where StudentId="+ studentid +"", cn);
            DataSet ds5 = new DataSet();
            da5.Fill(ds5);
            attendanceview.DataSource = ds5.Tables[0];
           
            //for(int i=0;i<attendanceview.Rows.Count-1;i++)
            //{

            //    if (Convert.ToInt32(attendanceview.Rows[i].Cells[1].Value) == 1)
            //    {
            //        attendanceview.Rows[i].Cells[1].Value = "Present";
            //    }
            //    else
            //    {
            //        attendanceview.Rows[i].Cells[1].Value = "Ap-sent";
            //    }
            //}

        }

        private void panelmenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnusersetting_Click(object sender, EventArgs e)
        {
            var usersettingform = new Usersettings();
            usersettingform.Show();
            this.Dispose();
        }

        private void btnregistration_Click(object sender, EventArgs e)
        {
            var registrationform = new Registration();
            registrationform.Show();
            this.Hide();
        }

        private void btnroomdetails_Click(object sender, EventArgs e)
        {
            var roomdetailsform = new RoomDetails();
            roomdetailsform.Show();
            this.Hide();
        }

        private void btnstudentdetails_Click(object sender, EventArgs e)
        {
             var studentinfo = new Student_Information();
            studentinfo.Show();
            this.Dispose();
        }

        private void btnfeesdetails_Click(object sender, EventArgs e)
        {
            var feesdataform = new Fees_Details();
            feesdataform.Show();
            this.Hide();
        }

        private void minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txtdate_KeyDown(object sender, KeyEventArgs e)
        {
            if(txtdate.Text!="")
            {
                
                if(e.KeyCode==Keys.Enter)
                {

                    SqlDataAdapter da = new SqlDataAdapter("select * from StudentFees where StudentId="+ studentid +" and Date=@p1", cn);
                    da.SelectCommand.Parameters.Add("@p1", SqlDbType.Date).Value = txtdate.Text;
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dgfeesview.DataSource = ds.Tables[0];

                }
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Attendance where Date Between @p1 and @p2 and StudentId="+ studentid +"", cn);
            da.SelectCommand.Parameters.Add("@p1", SqlDbType.Date).Value=fromdate.Text;
            da.SelectCommand.Parameters.Add("@p2",SqlDbType.Date).Value=todate.Text;
            DataSet ds = new DataSet();
            da.Fill(ds);
            attendanceview.DataSource = ds.Tables[0];
        }

        private void btnsignout_Click(object sender, EventArgs e)
        {
            var loginform = new Login();
            loginform.Show();
            this.Dispose();
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
