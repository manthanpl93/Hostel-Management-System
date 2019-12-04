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

    public partial class RoomDetails : Form
    {

        SqlConnection cn = new SqlConnection(Hostelcodesource.database.cs);

        public RoomDetails()
        {
            InitializeComponent();
        }


        private void btnregistration_Click(object sender, EventArgs e)
        {
            var registrationform = new Registration();
            registrationform.Show();
            this.Hide();
        }

        private void btnstudentdetails_Click(object sender, EventArgs e)
        {
            var studentinfoform = new Student_Information();
            studentinfoform.Show();
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

        private void btnroomdetails_Click(object sender, EventArgs e)
        {

        }

        private void btnroomexchange_Click(object sender, EventArgs e)
        {
            var roomexchangeform = new Roomtransfer();
            roomexchangeform.Show();
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void RoomDetails_Load(object sender, EventArgs e)
        {


            double fade;
            for (fade = 0.0; fade < 1.1; fade += 0.1)
            {
                this.Opacity = fade;
                this.Refresh();
                Thread.Sleep(30);

            }

            SqlDataAdapter da = new SqlDataAdapter("select Building from HostelRoomDetails group by Building", cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
          
            for(int i=0;i<ds.Tables[0].Rows.Count;i++)
            {
                cbbuilding.Items.Add(ds.Tables[0].Rows[i][0]);
            }
            cbbuilding.Items.Add("All Building");
            cbbuilding.Text = "All Building";


           



        }

        private void cbbuilding_TextChanged(object sender, EventArgs e)
        {
            if (cbbuilding.Text != "")
            {
                dgspaceview.Rows.Clear();

                dgroomview.Rows.Clear();

        

                    if (cbbuilding.Text == "All Building")
                    {
                        SqlDataAdapter da2 = new SqlDataAdapter("select RoomNumber,Building from HostelRoomDetails group by RoomNumber,Building order by Building,RoomNumber", cn);
                        DataSet ds2 = new DataSet();
                        da2.Fill(ds2);
                        string totalroom = ds2.Tables[0].Rows.Count.ToString();
                        txttotalroom.Text = totalroom;
                        ds2.Dispose();
                        da2.Dispose();

                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = cn;
                        cn.Open();
                        cmd.CommandText = "select Count(*) from HostelRoomDetails where StudentName='Free Space'";
                        string totalspace = cmd.ExecuteScalar().ToString();
                        txttotalfreebads.Text = totalspace;
                        cn.Close();
                        cmd.Dispose();

                        SqlCommand cmd2 = new SqlCommand();
                        cmd2.Connection = cn;
                        cn.Open();
                        cmd2.CommandText = "select Count(*) from HostelRoomDetails where StudentName<>'Free Space'";
                        string totalstudents = cmd2.ExecuteScalar().ToString();
                        txttotalstudent.Text = totalstudents;
                        cn.Close();
                        cmd.Dispose();

                        SqlDataAdapter da3 = new SqlDataAdapter("select RoomNumber,Building from HostelRoomDetails where StudentName='Free Space' group by RoomNumber,Building", cn);
                        DataSet ds3 = new DataSet();
                        da3.Fill(ds3);
                        string freeroom = ds3.Tables[0].Rows.Count.ToString();
                        txttotalfreeroom.Text = freeroom;
                        ds3.Dispose();
                        da3.Dispose();

                        SqlDataAdapter da4 = new SqlDataAdapter("select Building,RoomNumber from HostelRoomDetails group by Building,RoomNumber Order by Building,RoomNumber", cn);
                        DataSet ds4 = new DataSet();
                        da4.Fill(ds4);
                        int index = 0;
                        for (int i = 0; i < ds4.Tables[0].Rows.Count; i++)
                        {


                            SqlCommand cmd3 = new SqlCommand();
                            cmd3.Connection = cn;
                            cn.Open();
                            cmd3.CommandText = "select count(*) from HostelRoomDetails where StudentName='Free Space' and Building='" + ds4.Tables[0].Rows[i][0].ToString() + "' and RoomNumber='" + ds4.Tables[0].Rows[i][1].ToString() + "'";
                            int roomspace = Convert.ToInt32(cmd3.ExecuteScalar().ToString());
                            
                            cn.Close();
                            SqlCommand cmd4 = new SqlCommand();
                            cmd4.Connection = cn;
                            cn.Open();
                            cmd4.CommandText = "select count(*) from HostelRoomDetails where Building='" + ds4.Tables[0].Rows[i][0].ToString() + "' and RoomNumber='" + ds4.Tables[0].Rows[i][1].ToString() + "'";
                            int roomspace2 = Convert.ToInt32(cmd4.ExecuteScalar().ToString());
                 
                            dgspaceview.Rows.Add();
                            dgspaceview.Rows[i].Cells[0].Value = ds4.Tables[0].Rows[i][0].ToString();
                            dgspaceview.Rows[i].Cells[1].Value = ds4.Tables[0].Rows[i][1].ToString();
                            dgspaceview.Rows[i].Cells[2].Value = roomspace2;
                            
                            if (roomspace != 0)
                            {
                                dgroomview.Rows.Add();
                                dgroomview.Rows[index].Cells[0].Value = ds4.Tables[0].Rows[i][0].ToString();
                                dgroomview.Rows[index].Cells[1].Value = ds4.Tables[0].Rows[i][1].ToString();
                                dgroomview.Rows[index].Cells[2].Value = roomspace;
                                index += 1;

                            }

                            cn.Close();


                        }


                    }
                    else
                    {
                        SqlDataAdapter da2 = new SqlDataAdapter("select RoomNumber,Building from HostelRoomDetails where Building='" + cbbuilding.Text + "' group by RoomNumber,Building order by Building,RoomNumber", cn);
                        DataSet ds2 = new DataSet();
                        da2.Fill(ds2);
                        string totalroom = ds2.Tables[0].Rows.Count.ToString();
                        txttotalroom.Text = totalroom;
                        ds2.Dispose();
                        da2.Dispose();

                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = cn;
                        cn.Open();
                        cmd.CommandText = "select Count(*) from HostelRoomDetails where StudentName='Free Space' and Building='" + cbbuilding.Text + "'";
                        string totalspace = cmd.ExecuteScalar().ToString();
                        txttotalfreebads.Text = totalspace;
                        cn.Close();
                        cmd.Dispose();

                        SqlCommand cmd2 = new SqlCommand();
                        cmd2.Connection = cn;
                        cn.Open();
                        cmd2.CommandText = "select Count(*) from HostelRoomDetails where StudentName<>'Free Space' and Building='" + cbbuilding.Text + "'";
                        string totalstudents = cmd2.ExecuteScalar().ToString();
                        txttotalstudent.Text = totalstudents;
                        cn.Close();
                        cmd.Dispose();

                        SqlDataAdapter da3 = new SqlDataAdapter("select RoomNumber,Building from HostelRoomDetails where StudentName='Free Space' and Building='" + cbbuilding.Text + "' group by RoomNumber,Building", cn);
                        DataSet ds3 = new DataSet();
                        da3.Fill(ds3);
                        string freeroom = ds3.Tables[0].Rows.Count.ToString();
                        txttotalfreeroom.Text = freeroom;
                        ds3.Dispose();
                        da3.Dispose();

                        SqlDataAdapter da4 = new SqlDataAdapter("select Building,RoomNumber from HostelRoomDetails where Building='" + cbbuilding.Text + "' group by Building,RoomNumber Order by Building,RoomNumber", cn);
                        DataSet ds4 = new DataSet();
                        da4.Fill(ds4);
                        int index = 0;
                        for (int i = 0; i < ds4.Tables[0].Rows.Count; i++)
                        {


                            SqlCommand cmd3 = new SqlCommand();
                            cmd3.Connection = cn;
                            cn.Open();
                            cmd3.CommandText = "select count(*) from HostelRoomDetails where StudentName='Free Space' and Building='" + ds4.Tables[0].Rows[i][0].ToString() + "' and RoomNumber='" + ds4.Tables[0].Rows[i][1].ToString() + "'";
                            int roomspace = Convert.ToInt32(cmd3.ExecuteScalar().ToString());
                            
                            cn.Close();
                            SqlCommand cmd4 = new SqlCommand();
                            cmd4.Connection = cn;
                            cn.Open();
                            cmd4.CommandText = "select count(*) from HostelRoomDetails where Building='" + ds4.Tables[0].Rows[i][0].ToString() + "' and RoomNumber='" + ds4.Tables[0].Rows[i][1].ToString() + "'";
                            int roomspace2 = Convert.ToInt32(cmd4.ExecuteScalar().ToString());
                            
                            dgspaceview.Rows.Add();
                            dgspaceview.Rows[i].Cells[0].Value = ds4.Tables[0].Rows[i][0].ToString();
                            dgspaceview.Rows[i].Cells[1].Value = ds4.Tables[0].Rows[i][1].ToString();
                            dgspaceview.Rows[i].Cells[2].Value = roomspace2;


                            if (roomspace != 0)
                            {
                                dgroomview.Rows.Add();
                                dgroomview.Rows[index].Cells[0].Value = ds4.Tables[0].Rows[i][0].ToString();
                                dgroomview.Rows[index].Cells[1].Value = ds4.Tables[0].Rows[i][1].ToString();
                                dgroomview.Rows[index].Cells[2].Value = roomspace;
                                index += 1;
                            }

                            cn.Close();


                        }


                    }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgroomview_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           // string room = dgroomview.Rows[e.RowIndex].Cells[1].Value.ToString();
            //string building = dgroomview.Rows[e.RowIndex].Cells[0].Value.ToString();
            if (dgroomview.Rows.Count!=1)
            {
                SqlDataAdapter da = new SqlDataAdapter("select StudentName,CollegeOrSchool,BranchOrClass from HostelRoomDetails where RoomNumber='" + dgroomview.Rows[e.RowIndex].Cells[1].Value + "' and Building='" + dgroomview.Rows[e.RowIndex].Cells[0].Value + "' and StudentName<>'Free Space'", cn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dgstudentview.DataSource = ds.Tables[0];

                SqlDataAdapter da2 = new SqlDataAdapter("select StudentName,CollegeOrSchool,BranchOrClass from HostelRoomDetails where RoomNumber='" + dgroomview.Rows[e.RowIndex].Cells[1].Value + "' and Building='" + dgroomview.Rows[e.RowIndex].Cells[0].Value + "' and StudentName='Free Space'", cn);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2);
                lblchoosenroomno.Text = dgroomview.Rows[e.RowIndex].Cells[0].Value.ToString() + "-" + dgroomview.Rows[e.RowIndex].Cells[1].Value;
                lblfreespace.Text = ds2.Tables[0].Rows.Count.ToString();
                            
            }

            else
            {
                SoundPlayer sound = new SoundPlayer(@"c:\Windows\Media\chimes.wav");
                sound.Play();
                MessageBox.Show("You Select A Wrong Input", "Wrong Selection", MessageBoxButtons.OK);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtroomsearch_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void txtroomsearch_KeyDown(object sender, KeyEventArgs e)
        {
           

            if (e.KeyCode == Keys.Enter)
            {
                dgroomview.Rows.Clear();

                if(txtroomsearch.Text=="")
                {
                    cbbuilding_TextChanged(sender, e);
                }

                if (cbbuilding.Text == "All Building")
                {
                    SqlDataAdapter da4 = new SqlDataAdapter("select Building,RoomNumber from HostelRoomDetails where RoomNumber='"+ txtroomsearch.Text +"' group by Building,RoomNumber Order by Building,RoomNumber", cn);
                    DataSet ds4 = new DataSet();
                    da4.Fill(ds4);
                    int index = 0;
                    for (int i = 0; i < ds4.Tables[0].Rows.Count; i++)
                    {


                        SqlCommand cmd3 = new SqlCommand();
                        cmd3.Connection = cn;
                        cn.Open();
                        cmd3.CommandText = "select count(*) from HostelRoomDetails where StudentName='Free Space' and Building='" + ds4.Tables[0].Rows[i][0].ToString() + "' and RoomNumber='" + ds4.Tables[0].Rows[i][1].ToString() + "'";
                        int roomspace = Convert.ToInt32(cmd3.ExecuteScalar().ToString());
                      
                        if (roomspace != 0)
                        {
                           
                            dgroomview.Rows.Add();
                            dgroomview.Rows[index].Cells[0].Value = ds4.Tables[0].Rows[i][0].ToString();
                            dgroomview.Rows[index].Cells[1].Value = ds4.Tables[0].Rows[i][1].ToString();
                            dgroomview.Rows[index].Cells[2].Value = roomspace;
                            index += 1;
                        }

                        cn.Close();


                    }

                }
                else
                {
                    SqlDataAdapter da4 = new SqlDataAdapter("select Building,RoomNumber from HostelRoomDetails RoomNumber='" + txtroomsearch.Text + "' and Building='"+ cbbuilding.Text +"' group by Building,RoomNumber Order by Building,RoomNumber", cn);
                    DataSet ds4 = new DataSet();
                    da4.Fill(ds4);

                    for (int i = 0; i < ds4.Tables[0].Rows.Count; i++)
                    {


                        SqlCommand cmd3 = new SqlCommand();
                        cmd3.Connection = cn;
                        cn.Open();
                        cmd3.CommandText = "select count(*) from HostelRoomDetails where StudentName='Free Space' and Building='" + cbbuilding.Text + "' and RoomNumber='" + ds4.Tables[0].Rows[i][1].ToString() + "'";
                        int roomspace = Convert.ToInt32(cmd3.ExecuteScalar().ToString());
                        int index = 0;
                        if (roomspace != 0)
                        {
                         

                            dgroomview.Rows.Add();
                            dgroomview.Rows[index].Cells[0].Value = ds4.Tables[0].Rows[i][0].ToString();
                            dgroomview.Rows[index].Cells[1].Value = ds4.Tables[0].Rows[i][1].ToString();
                            dgroomview.Rows[index].Cells[2].Value = roomspace;
                            index += 1;
                        }

                        cn.Close();


                    }
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnusersetting_Click(object sender, EventArgs e)
        {
            var usersettingform = new Usersettings();
            usersettingform.Show();
            this.Dispose();
        }

        private void btnroomexchange_Click_1(object sender, EventArgs e)
        {


            var roomexchangeform = new Roomtransfer();
            roomexchangeform.Show();
            this.Dispose();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                dgspaceview.Rows.Clear();
            
                if(txtroomnumber2.Text=="")
                {
                    cbbuilding_TextChanged(sender, e);
                }
                
                if (cbbuilding.Text == "All Building")
                {
                   
                    SqlDataAdapter da = new SqlDataAdapter("select Building,RoomNumber from HostelRoomDetails where RoomNumber='" + txtroomnumber2.Text + "'  group by Building,RoomNumber order by Building,RoomNumber", cn);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                   // dgspaceview.DataSource = ds.Tables[0];
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        dgspaceview.Rows.Add();
                        dgspaceview.Rows[i].Cells[0].Value = ds.Tables[0].Rows[i][0].ToString();
                        dgspaceview.Rows[i].Cells[1].Value = ds.Tables[0].Rows[i][1].ToString();

                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = cn;
                        cn.Open();
                        cmd.CommandText = "select count(*) from HostelRoomDetails where Building='" + ds.Tables[0].Rows[i][0].ToString() + "' and RoomNumber='" + ds.Tables[0].Rows[i][1].ToString() + "'";
                        string space = cmd.ExecuteScalar().ToString();
                        cn.Close();
                        dgspaceview.Rows[i].Cells[0].Value = ds.Tables[0].Rows[i][0].ToString();
                        dgspaceview.Rows[i].Cells[1].Value = ds.Tables[0].Rows[i][1].ToString();
                        dgspaceview.Rows[i].Cells[2].Value = space;
                    }
                }

                else
                {
                    dgspaceview.Rows.Clear();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cn.Open();
                    cmd.CommandText = "Select count(*) from HostelRoomDetails where RoomNumber='" + txtroomnumber2.Text + "' and Building='" + cbbuilding.Text + "'";
                    string space = cmd.ExecuteScalar().ToString();
                    cn.Close();
                    dgspaceview.Rows.Add();
                    dgspaceview.Rows[0].Cells[0].Value = cbbuilding.Text;
                    dgspaceview.Rows[0].Cells[1].Value = txtroomnumber2.Text;
                    dgspaceview.Rows[0].Cells[2].Value = space;
                }
            }
        }

        private void btnsignout_Click(object sender, EventArgs e)
        {
            var loginform = new Login();
            loginform.Show();
            this.Dispose();
        }
    }
}
