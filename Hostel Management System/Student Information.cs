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
using System.Media;

namespace Hostel_Management_System
{
    public partial class Student_Information : Form
    {
        SqlConnection cn = new SqlConnection(Hostelcodesource.database.cs);
        public static string Id;
        public Student_Information()
        {
            InitializeComponent();
        }

        public void EFFECT()
        {
            int height = datagridstudentview.Height;

            for (int i = height; i > 0; i -= 10)
            {
                datagridstudentview.Height = i;
                this.Refresh();
                Thread.Sleep(5);
            }

            for (int i = 0; i < height + 1; i += 10)
            {
                datagridstudentview.Height = i;
                this.Refresh();
                Thread.Sleep(5);
            }
               
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

        private void btnmenu_Click(object sender, EventArgs e)
        {
            var homepageform = new Homepage();
            homepageform.Show();
            this.Hide();
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnfeesdetails_Click(object sender, EventArgs e)
        {
            var feesdataform = new Fees_Details();
            feesdataform.Show();
            this.Hide();
        }

        private void datagridstudentview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void datagridstudentview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void Student_Information_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hostelSystemStudentDetailDataset.StudentDetails' table. You can move, or remove it, as needed.
            //this.studentDetailsTableAdapter.Fill(this.hostelSystemStudentDetailDataset.StudentDetails);
            // TODO: This line of code loads data into the 'hostelSystemHostelRoomDetails2.HostelRoomDetails' table. You can move, or remove it, as needed.
            //this.hostelRoomDetailsTableAdapter.Fill(this.hostelSystemHostelRoomDetails2.HostelRoomDetails);
            // TODO: This line of code loads data into the 'hostelSystemHostelRoomDetailsDataSet.HostelRoomDetails' table. You can move, or remove it, as needed.
           // this.hostelRoomDetailsTableAdapter.Fill(this.hostelSystemHostelRoomDetailsDataSet.HostelRoomDetails);
            // TODO: This line of code loads data into the 'hostelSystemDataSet1.HostelRoomDetails' table. You can move, or remove it, as needed.
            //.hostelRoomDetailsTableAdapter.Fill(this.hostelSystemDataSet1.HostelRoomDetails);
            // TODO: This line of code loads data into the 'hostelSystemDataSet.StudentDetails' table. You can move, or remove it, as needed.
          //  this.studentDetailsTableAdapter.Fill(this.hostelSystemDataSet.StudentDetails);
            double fade;
            for (fade = 0.0; fade < 1.1; fade += 0.1)
            {
                this.Opacity = fade;
                this.Refresh();
                Thread.Sleep(30);

            }

            SqlDataAdapter da2 = new SqlDataAdapter("Select Building from HostelRoomDetails group by Building", cn);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);

            for(int i=0;i<ds2.Tables[0].Rows.Count;i++)
            {
               
               cbhostel.Items.Add(ds2.Tables[0].Rows[i][0].ToString());
            }
            cbhostel.Items.Add("All Building");
            cbhostel.Text = "All Building";

            SqlDataAdapter da = new SqlDataAdapter("Select * from HostelRoomDetails where StudentName<>'Free Space' order by Building,RoomNumber", cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            datagridstudentview.DataSource = ds.Tables[0];


            SqlDataAdapter da3 = new SqlDataAdapter("select CollegeOrSchool from HostelRoomDetails  where CollegeOrSchool<>'Not Submitted' group by CollegeOrSchool", cn);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            cbcollege.DataSource = ds3.Tables[0];
            cbcollege.DisplayMember = "CollegeOrSchool";

            SqlDataAdapter da4 = new SqlDataAdapter("select BranchOrClass from HostelRoomDetails  where CollegeOrSchool<>'Not Submitted' group by BranchOrClass", cn);
            DataSet ds4 = new DataSet();
            da4.Fill(ds4);

            cbbranch.DataSource = ds4.Tables[0];
            cbbranch.DisplayMember = "BranchOrClass";

            SqlDataAdapter da5 = new SqlDataAdapter("select State from HostelRoomDetails  where CollegeOrSchool<>'Not Submitted' group by State", cn);
            DataSet ds5 = new DataSet();
            da5.Fill(ds5);
            cbstate.DataSource= ds5.Tables[0];
            cbstate.DisplayMember = "State";


          SqlDataAdapter da6 = new SqlDataAdapter("select City from HostelRoomDetails  where CollegeOrSchool<>'Not Submitted' group by City", cn);
          DataSet ds6 = new DataSet();
          da6.Fill(ds6);
          cbdistrict.DataSource = ds6.Tables[0];
          cbdistrict.DisplayMember = "City";

          SqlDataAdapter da7 = new SqlDataAdapter("select SubCast from HostelRoomDetails  where CollegeOrSchool<>'Not Submitted' group by SubCast", cn);
          DataSet ds7 = new DataSet();
          da7.Fill(ds7);
          cbsubcast.DataSource= ds7.Tables[0];
          cbsubcast.DisplayMember = "SubCast";


          SqlDataAdapter da8 = new SqlDataAdapter("select IDOrRollNumber from HostelRoomDetails  where CollegeOrSchool<>'Not Submitted' group by IDOrRollNumber", cn);
          DataSet ds8 = new DataSet();
          da8.Fill(ds8);
          cbid.DataSource = ds8.Tables[0];
          cbid.DisplayMember = "IDOrRollNumber";


         

           
        }


        

        private void txtnamesearch_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void txtroomsearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EFFECT();
            }
        }

        private void cbcollege_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EFFECT();
            }
        }

        private void txtnamesearch_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txtnamesearch_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtnamesearch.Text!="")
                {
                    if (rbregular.Checked == true)
                    {


                        if (cbhostel.Text == "All Building")
                        {
                            EFFECT();
                            SqlDataAdapter da = new SqlDataAdapter("Select * from HostelRoomDetails where StudentName<>'Free Space' and StudentName like '%" + txtnamesearch.Text + "%'", cn);
                            DataSet ds = new DataSet();
                            da.Fill(ds);
                            datagridstudentview.DataSource = ds.Tables[0];

                        }
                        else
                        {
                           
                            SqlDataAdapter da = new SqlDataAdapter("Select * from HostelRoomDetails where StudentName<>'Free Space' and StudentName like '%" + txtnamesearch.Text + "%' and Building='" + cbhostel.Text + "'", cn);
                            DataSet ds = new DataSet();
                            da.Fill(ds);
                            datagridstudentview.DataSource = ds.Tables[0];
                        }
                        lblresult.Text = "Search result of " + "Student Name=" + txtnamesearch.Text;
                        lblresult.Visible = true;
                    }
                    else
                    {
            
                        SqlDataAdapter da = new SqlDataAdapter("Select * from StudentDetails where StudentName<>'Free Space' and StudentName like '%" + txtnamesearch.Text + "%'", cn);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        dgadvanceview.DataSource = ds.Tables[0];
                        lblresult.Text = "Search result of " + "Student Name=" + txtnamesearch.Text;
                        lblresult.Visible = true;
            
                    }
                    }
               
            }
        }

        private void txtnamesearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbhostel_TextChanged(object sender, EventArgs e)
        {
            EFFECT();
            
            if (cbhostel.Text == "All Building")
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from HostelRoomDetails where StudentName<>'Free Space' order by Building,RoomNumber", cn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                datagridstudentview.DataSource = ds.Tables[0];
                lblresult.Text = "Search result of All Building Students";
                lblresult.Visible = true;
            }
            else
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from HostelRoomDetails where StudentName<>'Free Space' and Building='"+ cbhostel.Text +"' order by RoomNumber", cn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                datagridstudentview.DataSource = ds.Tables[0];
                lblresult.Text = "Search result of building "+ cbhostel.Text +" Students";
                lblresult.Visible = true;
            }
           
        }

        private void txtroomsearch_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtroomsearch.Text !="")
                {
                    if (txtroomsearch.Text == "All Building")
                    {
                        EFFECT();
                        SqlDataAdapter da = new SqlDataAdapter("Select * from HostelRoomDetails where StudentName<>'Free Space' and RoomNumber='" + txtroomsearch.Text + "'", cn);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        datagridstudentview.DataSource = ds.Tables[0];
                    }
                    else
                    {
                        EFFECT();
                        SqlDataAdapter da = new SqlDataAdapter("Select * from HostelRoomDetails where StudentName<>'Free Space' and RoomNumber='" + txtroomsearch.Text + "' and Building='" + cbhostel.Text + "'", cn);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        datagridstudentview.DataSource = ds.Tables[0];
                    }
                    lblresult.Text = "Search result of " + "Room Number=" + txtroomsearch.Text;
                    lblresult.Visible = true;
                }

            }
        }

        private void cbcollege_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cbcollege.Text != "")
                {
                    if (rbregular.Checked == true)
                    {


                        if (cbhostel.Text == "All Building")
                        {
                            EFFECT();
                            SqlDataAdapter da = new SqlDataAdapter("Select * from HostelRoomDetails where StudentName<>'Free Space' and CollegeOrSchool='" + cbcollege.Text + "'", cn);
                            DataSet ds = new DataSet();
                            da.Fill(ds);
                            datagridstudentview.DataSource = ds.Tables[0];
                        }
                        else
                        {
                            EFFECT();
                            SqlDataAdapter da = new SqlDataAdapter("Select * from HostelRoomDetails where StudentName<>'Free Space' and CollegeOrSchool='" + cbcollege.Text + "' and Building='" + cbhostel.Text + "'", cn);
                            DataSet ds = new DataSet();
                            da.Fill(ds);
                            datagridstudentview.DataSource = ds.Tables[0];
                        }

                        lblresult.Text = "Search result of " + "CollegeorSchool=" + cbcollege.Text;
                        lblresult.Visible = true;
                    }
                    else
                    {
                        SqlDataAdapter da = new SqlDataAdapter("Select * from StudentDetails where StudentName<>'Free Space' and CollegeOrSchool='" + cbcollege.Text + "'", cn);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        dgadvanceview.DataSource = ds.Tables[0];
                        lblresult.Text = "Search result of " + "CollegeorSchool=" + cbcollege.Text;
                        lblresult.Visible = true;
                    }
                    }

            }
        }

        private void cbbranch_KeyDown(object sender, KeyEventArgs e)
        {
             if (e.KeyCode == Keys.Enter)
            {
                if (cbbranch.Text != "")
                {
                    if (rbregular.Checked == true)
                    {


                        if (cbhostel.Text == "All Building")
                        {
                            EFFECT();
                            SqlDataAdapter da = new SqlDataAdapter("Select * from HostelRoomDetails where StudentName<>'Free Space' and BranchOrClass='" + cbbranch.Text + "'", cn);
                            DataSet ds = new DataSet();
                            da.Fill(ds);
                            datagridstudentview.DataSource = ds.Tables[0];
                        }
                        else
                        {
                            EFFECT();
                            SqlDataAdapter da = new SqlDataAdapter("Select * from HostelRoomDetails where StudentName<>'Free Space' and BranchOrClass='" + cbbranch.Text + "' and Building='" + cbhostel.Text + "'", cn);
                            DataSet ds = new DataSet();
                            da.Fill(ds);
                            datagridstudentview.DataSource = ds.Tables[0];
                        }
                        lblresult.Text = "Search result of BranchorClass=" + cbbranch.Text;
                        lblresult.Visible = true;
                    }
                    else
                    {
                        SqlDataAdapter da = new SqlDataAdapter("Select * from StudentDetails where StudentName<>'Free Space' and BranchOrClass='" + cbbranch.Text + "'", cn);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        dgadvanceview.DataSource = ds.Tables[0];
                        lblresult.Text = "Search result of BranchorClass=" + cbbranch.Text;
                        lblresult.Visible = true;
                    }
                }

            }
        }

        private void cbid_KeyDown(object sender, KeyEventArgs e)
        {
             if (e.KeyCode == Keys.Enter)
            {
                if (cbid.Text != "")
                {
                    if (rbregular.Checked == true)
                    {


                        if (cbhostel.Text == "All Building")
                        {
                            EFFECT();
                            SqlDataAdapter da = new SqlDataAdapter("Select * from HostelRoomDetails where StudentName<>'Free Space' and IDOrRollNumber='" + cbid.Text + "'", cn);
                            DataSet ds = new DataSet();
                            da.Fill(ds);
                            datagridstudentview.DataSource = ds.Tables[0];
                        }
                        else
                        {
                            EFFECT();
                            SqlDataAdapter da = new SqlDataAdapter("Select * from HostelRoomDetails where StudentName<>'Free Space' and IDOrRollNumber='" + cbid.Text + "' and Building='" + cbhostel.Text + "'", cn);
                            DataSet ds = new DataSet();
                            da.Fill(ds);
                            datagridstudentview.DataSource = ds.Tables[0];
                        }


                        lblresult.Text = "Search result of CollegeIdorRollno=" + cbid.Text;
                        lblresult.Visible = true;
                    }
                    else
                    {
                        SqlDataAdapter da = new SqlDataAdapter("Select * from StudentDetails where StudentName<>'Free Space' and IDOrRollNumber='" + cbid.Text + "'", cn);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        dgadvanceview.DataSource = ds.Tables[0];
                    }
                    }

            }
        }

        private void cbstate_KeyDown(object sender, KeyEventArgs e)
        {
         if (e.KeyCode == Keys.Enter)
            {
                if (cbstate.Text != "")
                {
                    if (rbregular.Checked == true)
                    {


                        if (cbhostel.Text == "All Building")
                        {
                            EFFECT();
                            SqlDataAdapter da = new SqlDataAdapter("Select * from HostelRoomDetails where StudentName<>'Free Space' and State='" + cbstate.Text + "'", cn);
                            DataSet ds = new DataSet();
                            da.Fill(ds);
                            datagridstudentview.DataSource = ds.Tables[0];
                        }
                        else
                        {
                            EFFECT();
                            SqlDataAdapter da = new SqlDataAdapter("Select * from HostelRoomDetails where StudentName<>'Free Space' and State='" + cbstate.Text + "' and Building='" + cbhostel.Text + "'", cn);
                            DataSet ds = new DataSet();
                            da.Fill(ds);
                            datagridstudentview.DataSource = ds.Tables[0];
                        }
                        lblresult.Text = "Search result of State=" + cbstate.Text;
                        lblresult.Visible = true;
                    }
                    else
                    {
                        SqlDataAdapter da = new SqlDataAdapter("Select * from StudentDetails where StudentName<>'Free Space' and State='" + cbstate.Text + "'", cn);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        dgadvanceview.DataSource = ds.Tables[0];
                    }
                }

            }


        }

        private void cbdistrict_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cbdistrict.Text != "")
                {
                    if (rbregular.Checked == true)
                    {


                        if (cbhostel.Text == "All Building")
                        {
                            EFFECT();
                            SqlDataAdapter da = new SqlDataAdapter("Select * from HostelRoomDetails where StudentName<>'Free Space' and City='" + cbdistrict.Text + "'", cn);
                            DataSet ds = new DataSet();
                            da.Fill(ds);
                            datagridstudentview.DataSource = ds.Tables[0];
                        }
                        else
                        {
                            EFFECT();
                            SqlDataAdapter da = new SqlDataAdapter("Select * from HostelRoomDetails where StudentName<>'Free Space' and City='" + cbdistrict.Text + "' and Building='" + cbhostel.Text + "'", cn);
                            DataSet ds = new DataSet();
                            da.Fill(ds);
                            datagridstudentview.DataSource = ds.Tables[0];
                        }

                        lblresult.Text = "Search result of City=" + cbdistrict.Text;
                        lblresult.Visible = true;
                    }
                    else
                    {
                        SqlDataAdapter da = new SqlDataAdapter("Select * from StudentDetails where StudentName<>'Free Space' and City='" + cbdistrict.Text + "'", cn);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        dgadvanceview.DataSource = ds.Tables[0];
                    }
                }

            }

        }

        private void cbsubcast_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cbsubcast.Text != "")
                {
                    if (cbhostel.Text == "All Building")
                    {
                        EFFECT();
                        SqlDataAdapter da = new SqlDataAdapter("Select * from HostelRoomDetails where StudentName<>'Free Space' and SubCast='" + cbsubcast.Text + "'", cn);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        datagridstudentview.DataSource = ds.Tables[0];
                    }
                    else
                    {
                        EFFECT();
                        SqlDataAdapter da = new SqlDataAdapter("Select * from HostelRoomDetails where StudentName<>'Free Space' and SubCast='" + cbsubcast.Text + "' and Building='" + cbhostel.Text + "'", cn);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        datagridstudentview.DataSource = ds.Tables[0];
                    }
                    lblresult.Text = "Search result of Subcast=" + cbsubcast.Text;
                    lblresult.Visible = true;

                }

            }

        }

        private void datagridstudentview_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Id=datagridstudentview.Rows[e.RowIndex].Cells[5].Value.ToString();
            var studentdetailform = new studentdetail();
            studentdetailform.Show();
            this.Dispose();
        }

        private void btnusersetting_Click(object sender, EventArgs e)
        {
            var usersettingform = new Usersettings();
            usersettingform.Show();
            this.Dispose();
        }

        private void btnattendance_Click(object sender, EventArgs e)
        {
            //SoundPlayer sound = new SoundPlayer(@"c:\Windows\Media\chimes.wav");
            //sound.Play();
            //MessageBox.Show("Attendance Module is Under Devlopment Process","Devloper Message",MessageBoxButtons.OK);

            var attendanceform = new Attendance();
            attendanceform.Show();
            this.Dispose();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton2.Checked==true)
            {
                dgadvanceview.Visible = true;
                txtroomsearch.Enabled = false;
                cbsubcast.Enabled = false;
            }
        }

        private void rbregular_CheckedChanged(object sender, EventArgs e)
        {
            if(rbregular.Checked==true)
            {
                dgadvanceview.Visible = false;
                txtroomsearch.Enabled = true;
                cbsubcast.Enabled = true;
            }
        }

        private void dgadvanceview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Id = dgadvanceview.Rows[e.RowIndex].Cells[0].Value.ToString();
            var studentdetailform = new studentdetail();
            studentdetailform.Show();
            this.Dispose();
        }

        private void btnsignout_Click(object sender, EventArgs e)
        {
            var loginform = new Login();
            loginform.Show();
            this.Dispose();
        }
   
    }
}
