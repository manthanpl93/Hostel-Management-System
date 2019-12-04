using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Media;
using System.Threading;
namespace Hostel_Management_System
{
    public partial class Attendance : Form
    {
        SqlConnection cn = new SqlConnection(Hostelcodesource.database.cs);
       
        public Attendance()
        {
            InitializeComponent();
          
        }

        int modifpermission = 0;
      
       void showpresentstudents()
        {
            for (int i = 0; i < dgattendanceview.Rows.Count - 1; i++)
            {
                SqlCommand cmd = new SqlCommand();
                cn.Close();
                cmd.Connection = cn;
                cn.Open();
                cmd.CommandText = "select Status from Attendance where StudentId=" + dgattendanceview.Rows[i].Cells[5].Value.ToString() + " and Date=@p3";

                SqlParameter para2 = new SqlParameter("p3", SqlDbType.Date);
                para2.Value = UserDate.Text;
                cmd.Parameters.Add(para2);
                string status = cmd.ExecuteScalar().ToString();
                if (status == "Present")
                {
                    dgattendanceview.Rows[i].Cells[0].Value = true;
                }
               
                cn.Close();
              //  lbldate.Text = DateTime.Today.ToString("dd-MM-yy");
               
               
            }
            SqlDataAdapter da = new SqlDataAdapter("select * from Attendance where Status='Absent' and Date=@p1", cn);
            da.SelectCommand.Parameters.Add("@p1", SqlDbType.Date).Value = UserDate.Text;
            DataSet ds = new DataSet();
            da.Fill(ds);
          
            lblabsentstudent.Text = ds.Tables[0].Rows.Count.ToString();

            SqlDataAdapter da2 = new SqlDataAdapter("select * from Attendance where Status='Present' and Date=@p1", cn);
            da2.SelectCommand.Parameters.Add("@p1", SqlDbType.Date).Value = UserDate.Text;
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            lblpresentstudent.Text = ds2.Tables[0].Rows.Count.ToString();
        }
        
        void attendancefill()
        {
            for (int i = 0; i < dgattendanceview.Rows.Count - 1; i++)
            {

                if (Convert.ToBoolean(dgattendanceview.Rows[i].Cells[0].Value) == true)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cn.Open();
                    cmd.CommandText = "update Attendance set Status='Present' where StudentId=" + dgattendanceview.Rows[i].Cells[5].Value.ToString() + " and Date=@p1";
                    SqlParameter para1 = new SqlParameter("p1", SqlDbType.Date);
                    para1.Value = UserDate.Text;
                    cmd.Parameters.Add(para1);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                 
                }
                else
                {
                  
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cn.Open();
                    cmd.CommandText = "update Attendance set Status='Absent' where StudentId=" + dgattendanceview.Rows[i].Cells[5].Value.ToString() + " and Date=@p1";
                    SqlParameter para1 = new SqlParameter("p1", SqlDbType.Date);
                    para1.Value = UserDate.Text;
                    cmd.Parameters.Add(para1);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                  
                }
            }
        }


        void presentabsent()
        {
              try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cn.Open();

                    cmd.CommandText = "select count(*) from Attendance where Date Between @p1 and @p2 and Status='Present'";
                    SqlParameter para1 = new SqlParameter("@p1", SqlDbType.Date);
                    para1.Value = cbfromdate.Text;
                    SqlParameter para2 = new SqlParameter("@p2", SqlDbType.Date);
                    para2.Value = cbtodate.Text.ToString();
                    cmd.Parameters.Add(para1);
                    cmd.Parameters.Add(para2);
                    lblpresentstudent.Text = cmd.ExecuteScalar().ToString();

                    cmd.CommandText = "select count(*) from Attendance where Date Between @p1 and @p2 and Status='Absent'";
                    lblabsentstudent.Text = cmd.ExecuteScalar().ToString();
                }
                catch
                {

                }
              
          
        }
        private void Attendance_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hostelSystemDataSet2.Attendance' table. You can move, or remove it, as needed.
          //  this.attendanceTableAdapter.Fill(this.hostelSystemDataSet2.Attendance);
            // TODO: This line of code loads data into the 'hostelSystemHostelRoomDetails2.HostelRoomDetails' table. You can move, or remove it, as needed.
            // this.hostelRoomDetailsTableAdapter.Fill(this.hostelSystemHostelRoomDetails2.HostelRoomDetails);




            double fade;
            for (fade = 0.0; fade < 1.1; fade += 0.1)
            {
                this.Opacity = fade;
                this.Refresh();
                Thread.Sleep(50);

            }




            SqlDataAdapter da = new SqlDataAdapter("select Building from HostelRoomDetails group by Building", cn);
            DataSet ds = new DataSet();
            da.Fill(ds);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cbbuilding.Items.Add(ds.Tables[0].Rows[i][0]);
                cbbuilding2.Items.Add(ds.Tables[0].Rows[i][0]);
            }
            cbbuilding2.Items.Add("All Building");
            cbbuilding.Items.Add("All Building");
            cbbuilding.Text = "All Building";
            cbbuilding2.Text = "All Building";
            cn.Close();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cn.Open();

            cmd.CommandText = "select min(Date) from Attendance";
            cbfromdate.Text = cmd.ExecuteScalar().ToString();
            cbfromdate.Text = cbfromdate.Text.Substring(0, 10);
            cmd.CommandText = "select max(Date) from Attendance";
            cbtodate.Text = cmd.ExecuteScalar().ToString();
            cbtodate.Text = cbtodate.Text.Substring(0, 10);
            cn.Close();


            SqlDataAdapter da2 = new SqlDataAdapter("select Date from Attendance group by Date",cn);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            cbfromdate.DataSource = ds2.Tables[0];
            cbfromdate.DisplayMember = "Date";

            SqlDataAdapter da3 = new SqlDataAdapter("select Date from Attendance group by Date", cn);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);

            cbtodate.DataSource = ds3.Tables[0];
            cbtodate.DisplayMember = "Date";
            cn.Close();
            


        }

        private void cbbuilding_TextChanged(object sender, EventArgs e)
        {
            if (cbbuilding.Text != "" && modifpermission == 1)
            {
                SqlDataAdapter da2 = new SqlDataAdapter("select * from Attendance where Date=@p1", cn);
                da2.SelectCommand.Parameters.Add("@p1", SqlDbType.Date).Value = DateTime.Today;
                DataSet ds2 = new DataSet();
                da2.Fill(ds2);
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    if (cbbuilding.Text == "All Building")
                    {
                        SqlDataAdapter da = new SqlDataAdapter("select * from HostelRoomDetails where StudentName!='Free Space' order by Building,RoomNumber", cn);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        dgattendanceview.DataSource = ds.Tables[0];
                        showpresentstudents();
                    }
                    else
                    {
                        SqlDataAdapter da = new SqlDataAdapter("select * from HostelRoomDetails where StudentName!='Free Space' and Building='" + cbbuilding.Text + "' order by Building,RoomNumber", cn);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        dgattendanceview.DataSource = ds.Tables[0];
                        showpresentstudents();

                    }
                }
                else
                {
                    MessageBox.Show("Must Genrate Today Date","Hostel Management Syatem",MessageBoxButtons.OK);
                }
            }
        }

        private void dgattendanceview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
           
        }

        private void cboxpresnt_Click(object sender, EventArgs e)
        {
            if (cboxpresnt.Text == "Present All")
            {
                cboxpresnt.Text = "Absent All";

                for (int i = 0; i < dgattendanceview.Rows.Count - 1; i++)
                {
                    dgattendanceview.Rows[i].Cells[0].Value = true;

                }
            }
            else
            {
                cboxpresnt.Text = "Present All";

                for (int i = 0; i < dgattendanceview.Rows.Count - 1; i++)
                {
                    dgattendanceview.Rows[i].Cells[0].Value = false;

                }
            }
        }

        private void dgattendanceview_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            

           
           
        }

        private void txtroomno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SqlDataAdapter da2 = new SqlDataAdapter("select * from Attendance where Date=@p1", cn);
                da2.SelectCommand.Parameters.Add("@p1", SqlDbType.Date).Value = DateTime.Today;
                DataSet ds2 = new DataSet();
                da2.Fill(ds2);
                if (ds2.Tables[0].Rows.Count > 0)
                {




                    if (cbbuilding.Text == "All Building")
                    {
                        SqlDataAdapter da = new SqlDataAdapter("select * from HostelRoomDetails where RoomNumber='" + txtroomno.Text + "' and StudentName!='Free Space'", cn);
                        //da.SelectCommand.Parameters.Add("@p1", SqlDbType.Date).Value = DateTime.Today;
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        dgattendanceview.DataSource = ds.Tables[0];
                        showpresentstudents();

                    }
                    else
                    {
                        SqlDataAdapter da = new SqlDataAdapter("select * from HostelRoomDetails where RoomNumber='" + txtroomno.Text + "' and StudentName!='Free Space' and Building='" + cbbuilding.Text + "'", cn);
                        //da.SelectCommand.Parameters.Add("@p1", SqlDbType.Date).Value = DateTime.Today;
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        dgattendanceview.DataSource = ds.Tables[0];
                        showpresentstudents();
                    }
                }
                else
                {
                    MessageBox.Show("Must Genrate Today Date","Hostel Management Syatem",MessageBoxButtons.OK);
                }
            }
        }

        private void dgattendanceview_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void btnsubmit_Click(object sender, EventArgs e)
        {
            attendancefill();
        }

        private void btnshowme_Click(object sender, EventArgs e)
        {
            showpresentstudents();
        }

        private void btngenrate_Click(object sender, EventArgs e)
        {
            SoundPlayer sound = new SoundPlayer(@"c:\Windows\Media\chimes.wav");
            sound.Play();
            MessageBox.Show("Dear User it takes few times","Hostel Management System",MessageBoxButtons.OK);
            SqlDataAdapter da2 = new SqlDataAdapter("select * from Attendance where Date=@p1", cn);

            //da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da2.SelectCommand.Parameters.Add("@p1", SqlDbType.Date).Value = UserDate.Text;
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);

            if (ds2.Tables[0].Rows.Count > 0)
            {
                sound.Play();
               DialogResult dr= MessageBox.Show("This Date Attendance Allready Taken Do You Want To Modify It ?","Modification Permission",MessageBoxButtons.YesNo);
                if(dr==DialogResult.Yes)
                {
                    showpresentstudents();
                    modifpermission = 1;
                    cbbuilding_TextChanged(sender,e);
                }
                else
                {
                    modifpermission = 0;
                }

            }
            else
            {
                SqlDataAdapter da3 = new SqlDataAdapter("select * from HostelRoomDetails where StudentName!='Free Space' order by Building,RoomNumber ", cn);
                DataSet ds3 = new DataSet();
                da3.Fill(ds3);

                for (int i = 0; i < ds3.Tables[0].Rows.Count; i++)
                {
                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.Connection = cn;
                    cn.Open();
                    cmd2.CommandText = "insert into Attendance values (" + ds3.Tables[0].Rows[i][14].ToString() + ",'" + ds3.Tables[0].Rows[i][3].ToString() + "','" + ds3.Tables[0].Rows[i][1].ToString() + "','" + ds3.Tables[0].Rows[i][2].ToString() + "','" + ds3.Tables[0].Rows[i][4].ToString() + "',@p1,'Absent')";
                    SqlParameter para1 = new SqlParameter("p1", SqlDbType.Date);
                    para1.Value = UserDate.Text;
                    cmd2.Parameters.Add(para1);
                    cmd2.ExecuteNonQuery();
                    cn.Close();
                }
                sound.Play();
                MessageBox.Show(UserDate.Text +" Attendance Suceessfully Created Fill Your Attendance","Hostel Management System",MessageBoxButtons.OK);
                modifpermission = 1;
                cbbuilding_TextChanged(sender, e);
            }
         
        }

        private void dgattendanceview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

          
        }

        private void txtroomno2_TextChanged(object sender, EventArgs e)
        {
            radioButton1_CheckedChanged(sender, e);
            rbpresent_CheckedChanged(sender, e);
      


            }
           
     

        private void btnmenu_Click(object sender, EventArgs e)
        {
            var homepageform = new Homepage();
            homepageform.Show();
            this.Hide();
        }

        private void btnregistration_Click(object sender, EventArgs e)
        {
            var registrationform = new Registration();
            registrationform.Show();
            this.Hide();
        }

        private void btnstudentdetails_Click(object sender, EventArgs e)
        {
            var studentinfo = new Student_Information();
            studentinfo.Show();
            this.Dispose();
        }

        private void btnroomdetails_Click(object sender, EventArgs e)
        {
            var roomdetailsform = new RoomDetails();
            roomdetailsform.Show();
            this.Hide();
        }

        private void btnfeesdetails_Click(object sender, EventArgs e)
        {
            var feesdataform = new Fees_Details();
            feesdataform.Show();
            this.Hide();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Attendance where Date Between @p1 and @p2 and Status='Present' order by StudentId", cn);
            da.SelectCommand.Parameters.Add("@p1", SqlDbType.Date).Value = cbfromdate.Text;
            da.SelectCommand.Parameters.Add("@p2", SqlDbType.Date).Value = cbtodate.Text;
            DataSet ds = new DataSet();
            da.Fill(ds);
            dgabsentview.DataSource = ds.Tables[0];

        }

        private void rbpresent_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

               
                if (cbfromdate.Text != "" && cbtodate.Text != "")
                {


                    //txtroomno2_TextChanged(sender, e);
                    if (rbpresent.Checked == true)
                    {
                        presentabsent();

                        if (cbbuilding2.Text == "All Building" && txtroomno2.Text == "")
                        {

                            SqlDataAdapter da = new SqlDataAdapter("select * from Attendance where Date Between @p1 and @p2 and Status='Present'  order by StudentId", cn);
                            da.SelectCommand.Parameters.Add("@p1", SqlDbType.Date).Value = cbfromdate.Text;
                            da.SelectCommand.Parameters.Add("@p2", SqlDbType.Date).Value = cbtodate.Text;
                            DataSet ds = new DataSet();
                            da.Fill(ds);
                            dgabsentview.DataSource = ds.Tables[0];



                        }
                        if (cbbuilding2.Text != "All Building" && txtroomno2.Text == "")
                        {
                            SqlDataAdapter da = new SqlDataAdapter("select * from Attendance where Date Between @p1 and @p2 and Status='Present' and Building='" + cbbuilding2.Text + "' order by StudentId", cn);
                            da.SelectCommand.Parameters.Add("@p1", SqlDbType.Date).Value = cbfromdate.Text;
                            da.SelectCommand.Parameters.Add("@p2", SqlDbType.Date).Value = cbtodate.Text;
                            DataSet ds = new DataSet();
                            da.Fill(ds);
                            dgabsentview.DataSource = ds.Tables[0];



                        }

                        if (cbbuilding2.Text == "All Building" && txtroomno2.Text != "")
                        {

                            SqlDataAdapter da = new SqlDataAdapter("select * from Attendance where Date Between @p1 and @p2 and Status='Present' and Room='" + txtroomno2.Text + "' order by StudentId", cn);
                            da.SelectCommand.Parameters.Add("@p1", SqlDbType.Date).Value = cbfromdate.Text;
                            da.SelectCommand.Parameters.Add("@p2", SqlDbType.Date).Value = cbtodate.Text;
                            DataSet ds = new DataSet();
                            da.Fill(ds);
                            dgabsentview.DataSource = ds.Tables[0];



                        }
                        if (cbbuilding2.Text != "All Building" && txtroomno2.Text != "")
                        {
                            SqlDataAdapter da = new SqlDataAdapter("select * from Attendance where Date Between @p1 and @p2 and Status='Present' and Building='" + cbbuilding2.Text + "' and Room='" + txtroomno2.Text + "' order by StudentId", cn);
                            da.SelectCommand.Parameters.Add("@p1", SqlDbType.Date).Value = cbfromdate.Text;
                            da.SelectCommand.Parameters.Add("@p2", SqlDbType.Date).Value = cbtodate.Text;
                            DataSet ds = new DataSet();
                            da.Fill(ds);
                            dgabsentview.DataSource = ds.Tables[0];

                         

                        }


                    }
                }
            }
            catch
            {

            }
        }

           
            
        

       

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        
        {
          //  txtroomno2_TextChanged(sender, e);

           
                if (cbfromdate.Text != "" && cbtodate.Text != "")
                {
                    

                    if (radioButton1.Checked == true)
                    {
                        presentabsent();
                        if (cbbuilding2.Text == "All Building" && txtroomno2.Text=="")
                        {
                         
                            SqlDataAdapter da = new SqlDataAdapter("select * from Attendance where Date Between @p1 and @p2 and Status='Absent'  order by StudentId", cn);
                            da.SelectCommand.Parameters.Add("@p1", SqlDbType.Date).Value = cbfromdate.Text;
                            da.SelectCommand.Parameters.Add("@p2", SqlDbType.Date).Value = cbtodate.Text;
                            DataSet ds = new DataSet();
                            da.Fill(ds);
                            dgabsentview.DataSource = ds.Tables[0];


                           
                          
                        }
                        if (cbbuilding2.Text != "All Building" && txtroomno2.Text == "")
                        {
                            SqlDataAdapter da = new SqlDataAdapter("select * from Attendance where Date Between @p1 and @p2 and Status='Absent' and Building='" + cbbuilding2.Text + "' order by StudentId", cn);
                            da.SelectCommand.Parameters.Add("@p1", SqlDbType.Date).Value = cbfromdate.Text;
                            da.SelectCommand.Parameters.Add("@p2", SqlDbType.Date).Value = cbtodate.Text;
                            DataSet ds = new DataSet();
                            da.Fill(ds);
                            dgabsentview.DataSource = ds.Tables[0];

                       
                            
                        }

                        if (cbbuilding2.Text == "All Building" && txtroomno2.Text != "")
                        {

                            SqlDataAdapter da = new SqlDataAdapter("select * from Attendance where Date Between @p1 and @p2 and Status='Absent' and Room='"+ txtroomno2.Text +"' order by StudentId", cn);
                            da.SelectCommand.Parameters.Add("@p1", SqlDbType.Date).Value = cbfromdate.Text;
                            da.SelectCommand.Parameters.Add("@p2", SqlDbType.Date).Value = cbtodate.Text;
                            DataSet ds = new DataSet();
                            da.Fill(ds);
                            dgabsentview.DataSource = ds.Tables[0];


               

                        }
                        if (cbbuilding2.Text != "All Building" && txtroomno2.Text != "")
                        {
                            SqlDataAdapter da = new SqlDataAdapter("select * from Attendance where Date Between @p1 and @p2 and Status='Absent' and Building='" + cbbuilding2.Text + "' and Room='" + txtroomno2.Text + "' order by StudentId", cn);
                            da.SelectCommand.Parameters.Add("@p1", SqlDbType.Date).Value = cbfromdate.Text;
                            da.SelectCommand.Parameters.Add("@p2", SqlDbType.Date).Value = cbtodate.Text;
                            DataSet ds = new DataSet();
                            da.Fill(ds);
                            dgabsentview.DataSource = ds.Tables[0];

       

                        }

                    }

                }
            }
          
        

        private void cbfromdate_TextChanged(object sender, EventArgs e)
        {
            if (cbfromdate.Text != "")
            {

                radioButton1_CheckedChanged(sender, e);
                rbpresent_CheckedChanged(sender, e);
             
            }

      
        }

        private void cbtodate_TextChanged(object sender, EventArgs e)
        {
         
         
            if (cbtodate.Text!="")
            {
                radioButton1_CheckedChanged(sender, e);
                rbpresent_CheckedChanged(sender, e);
             
            } 
        }

        private void cbbuilding2_TextChanged(object sender, EventArgs e)
        {
           
                radioButton1_CheckedChanged(sender, e);
                rbpresent_CheckedChanged(sender, e);
           
           
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnusersetting_Click(object sender, EventArgs e)
        {
            var usersetting = new Usersettings();
            usersetting.Show();
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
