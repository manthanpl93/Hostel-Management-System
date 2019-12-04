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

namespace Hostel_Management_System
{
    public partial class Fees_Details : Form
    {

        SqlConnection cn = new SqlConnection(Hostelcodesource.database.cs);
        int effectallow = 0;
        public static string feesdetailform=null;
        public static string studentid = null;
        public Fees_Details()
        {
            InitializeComponent();
        }

        private void btnstudentdetails_Click(object sender, EventArgs e)
        {
            var studentinfo = new Student_Information();
            studentinfo.Show();
            this.Hide();
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

        private void btnroomdetails_Click(object sender, EventArgs e)
        {
            var roomdetailsform = new RoomDetails();
            roomdetailsform.Show();
            this.Hide();
        }

        private void cbpaidcategory_TextChanged(object sender, EventArgs e)
        {
            if(effectallow==1)
            {

          
            int height = pnlpaidlist.Height;
            for(int i=height;i>0;i-=10)
            {
                pnlpaidlist.Height = i;
                this.Refresh();
                Thread.Sleep(5);
            }
            btnlisttitle.Text = cbpaidcategory.Text + " Student Lists";
            for (int i = 0; i<height+1; i += 10)
            {
                pnlpaidlist.Height = i;
                this.Refresh();
                Thread.Sleep(5);
            }
        }
            if (cbpaidcategory.Text == "Unpaid")
            {
                SqlDataAdapter da = new SqlDataAdapter("select RoomNumber,Name,Building,SubmittedFees,RemainingFees,Date,StudentId from StudentYearFees where SubmittedFees=0 and Year='" + cbyear.Text + "' order by Building,RoomNumber", cn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dgstudentview.DataSource = ds.Tables[0];
                da.Dispose();
                ds.Dispose();
            }

            if (cbpaidcategory.Text == "Half-Paid")
            {
                SqlDataAdapter da = new SqlDataAdapter("select RoomNumber,Name,Building,SubmittedFees,RemainingFees,Date,StudentId from StudentYearFees where SubmittedFees!=0 and RemainingFees!=0 and Year='" + cbyear.Text + "' order by Building,RoomNumber", cn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dgstudentview.DataSource = ds.Tables[0];
                da.Dispose();
                ds.Dispose();

            }


            if (cbpaidcategory.Text == "Paid")
            {
                SqlDataAdapter da = new SqlDataAdapter("select RoomNumber,Name,Building,SubmittedFees,RemainingFees,Date,StudentId from StudentYearFees where RemainingFees=0 and Year='" + cbyear.Text + "' order by Building,RoomNumber", cn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dgstudentview.DataSource = ds.Tables[0];
                da.Dispose();
                ds.Dispose();

            }

        }

        private void Fees_Details_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hostelSystemDataSet.StudentYearFees' table. You can move, or remove it, as needed.
           // this.studentYearFeesTableAdapter.Fill(this.hostelSystemDataSet.StudentYearFees);
            double fade;
            for (fade = 0.0; fade < 1.1; fade += 0.1)
            {
                this.Opacity = fade;
                this.Refresh();
                Thread.Sleep(50);
            }
                SqlDataAdapter da = new SqlDataAdapter("select Year from FeesDetail group by Year", cn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                cbyear.DataSource = ds.Tables[0];
                cbyear.DisplayMember = "Year";
                ds.Dispose();

                SqlDataAdapter da2 = new SqlDataAdapter("select Building From StudentYearFees group by Building", cn);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2);
                cbbuilding.DataSource = ds2.Tables[0];
                cbbuilding.DisplayMember = "building";


                
               



                SqlCommand cmd=new SqlCommand();
            cmd.Connection=cn;
            cn.Open();
            cmd.CommandText = "select max(Id) from FeesDetail";
            string currentId=cmd.ExecuteScalar().ToString();
            cn.Close();
            cmd.Dispose();


                SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = cn;
                cn.Open();
                cmd2.CommandText = "select Year from FeesDetail where Id=" + currentId + "";
                string currentyear = cmd2.ExecuteScalar().ToString();
                cbyear.Text = currentyear;
                cn.Close();
                cmd2.Dispose();

                SqlDataAdapter da3 = new SqlDataAdapter("select Date From StudentYearFees where Year='" + cbyear.Text + "' group by Date", cn);
                DataSet ds3 = new DataSet();
                da3.Fill(ds3);
                cbfromdate.DataSource = ds3.Tables[0];
                cbfromdate.DisplayMember = "Date";



                SqlDataAdapter da4 = new SqlDataAdapter("select Date From StudentYearFees where Year='" + cbyear.Text + "' group by Date", cn);
                DataSet ds4 = new DataSet();
                da4.Fill(ds4);
                cbtodate.DataSource = ds4.Tables[0];
                cbtodate.DisplayMember = "Date";

                SqlDataAdapter da5 = new SqlDataAdapter("select ChequeNumber From StudentFees where Year='" + cbyear.Text + "' group by ChequeNumber", cn);
                DataSet ds5 = new DataSet();
                da5.Fill(ds5);

                cbcheque.DataSource = ds5.Tables[0];
                cbcheque.DisplayMember = "ChequeNumber";





            cbbuilding_TextChanged(sender,e);
                effectallow = 1;

        }

        private void cbyear_TextChanged(object sender, EventArgs e)
        {
            cn.Close();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cn.Open();
            cmd.CommandText = "select Sum(SubmittedFees) from StudentYearFees where Year='" + cbyear.Text + "'";
            string fees = cmd.ExecuteScalar().ToString();
            txtallfees.Text = fees;
          
            cmd.CommandText = "select Count(Name) from StudentYearFees where RemainingFees=0 and Year='" + cbyear.Text + "'";
             txttotalfeespaidstudent.Text = cmd.ExecuteScalar().ToString();
      
            cmd.CommandText = "select Count(Name) from StudentYearFees where Year='" + cbyear.Text + "'";
          txttotalstudent.Text = cmd.ExecuteScalar().ToString();

          cmd.CommandText = "select Sum(RemainingFees) from StudentYearFees where Year='" + cbyear.Text + "'";
         txtremainingfees.Text = cmd.ExecuteScalar().ToString();
         cmd.Dispose();
            cn.Close();

            SqlDataAdapter da3 = new SqlDataAdapter("select Date From StudentYearFees where Year='" + cbyear.Text + "' group by Date", cn);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            cbfromdate.DataSource = ds3.Tables[0];
            cbfromdate.DisplayMember = "Date";



            SqlDataAdapter da4 = new SqlDataAdapter("select Date From StudentYearFees where Year='" + cbyear.Text + "' group by Date", cn);
            DataSet ds4 = new DataSet();
            da4.Fill(ds4);
            cbtodate.DataSource = ds4.Tables[0];
            cbtodate.DisplayMember = "Date";

            cbpaidcategory_TextChanged(sender,e);




        }

        private void cbbuilding_TextChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cn.Open();
            cmd.CommandText = "select count(Name) from StudentYearFees where Year='"+ cbyear.Text +"' and Building='"+ cbbuilding.Text +"'";
           txttotalstudents1.Text= cmd.ExecuteScalar().ToString();
         
           cmd.Dispose();


           cmd.CommandText = "select Sum(SubmittedFees) from StudentYearFees where Year='" + cbyear.Text + "' and Building='" + cbbuilding.Text + "'";
           txttotalfees1.Text = cmd.ExecuteScalar().ToString();

           cmd.CommandText = "select Count(Name) from StudentYearFees where Year='" + cbyear.Text + "' and RemainingFees=0 and Building='" + cbbuilding.Text + "'"; 
           txtbuildingfullpaidstudents.Text = cmd.ExecuteScalar().ToString();

           cmd.CommandText = "select Count(Name) from StudentYearFees where Year='" + cbyear.Text + "' and SubmittedFees!=0 and RemainingFees!=0 and Building='" + cbbuilding.Text + "'";
           txthalffeespaidstudents.Text = cmd.ExecuteScalar().ToString();


           cmd.CommandText = "select Count(Name) from StudentYearFees where Year='" + cbyear.Text + "' and SubmittedFees=0 and Building='" + cbbuilding.Text + "'";
           txtunpaidfeesbuilding.Text = cmd.ExecuteScalar().ToString();
           cmd.Dispose();
           cn.Close();


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

        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (cbpaidcategory.Text == "Unpaid")
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from StudentYearFees where Date Between @p1 and @p2 and Year='" + cbyear.Text + "' and SubmittedFees=0", cn);
                da.SelectCommand.Parameters.Add("@p1", SqlDbType.Date).Value = cbfromdate.Text;
                da.SelectCommand.Parameters.Add("@p2", SqlDbType.Date).Value = cbtodate.Text;
                DataSet ds = new DataSet();
                da.Fill(ds);
                dgstudentview.DataSource = ds.Tables[0];


               
            }

            if (cbpaidcategory.Text == "Half-Paid")
            {

                SqlDataAdapter da = new SqlDataAdapter("select * from StudentYearFees where Date Between @p1 and @p2 and Year='" + cbyear.Text + "' and SubmittedFees!=0 and RemainingFees!=0", cn);
                da.SelectCommand.Parameters.Add("@p1", SqlDbType.Date).Value = cbfromdate.Text;
                da.SelectCommand.Parameters.Add("@p2", SqlDbType.Date).Value = cbtodate.Text;
                DataSet ds = new DataSet();
                da.Fill(ds);
                dgstudentview.DataSource = ds.Tables[0];


             

            }


            if (cbpaidcategory.Text == "Paid")
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from StudentYearFees where Date Between @p1 and @p2 and Year='" + cbyear.Text + "' and RemainingFees=0", cn);
                da.SelectCommand.Parameters.Add("@p1", SqlDbType.Date).Value = cbfromdate.Text;
                da.SelectCommand.Parameters.Add("@p2", SqlDbType.Date).Value = cbtodate.Text;
                DataSet ds = new DataSet();
                da.Fill(ds);
                dgstudentview.DataSource = ds.Tables[0];

               
            }

           

        }

        private void btnsearch2_Click(object sender, EventArgs e)
        {
            if(cbcheque.Text!="")
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cn.Open();
                cmd.CommandText = "select StudentId from StudentFees where ChequeNumber='"+ cbcheque.Text +"'";
                string id = cmd.ExecuteScalar().ToString();
                cn.Close();

                if(id!="")
                {
                  


                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.Connection = cn;
                    cn.Open();
                    cmd2.CommandText = "select SubmittedFees from StudentYearFees where StudentId="+ id +" and Year='"+ cbyear.Text +"'";
                    string submittedfees = cmd2.ExecuteScalar().ToString();

                    cmd2.CommandText = "select RemainingFees from StudentYearFees where StudentId=" + id + " and Year='"+ cbyear.Text +"'";
                    string RemainingFees = cmd2.ExecuteScalar().ToString();

                    cn.Close();


                    if(submittedfees!="0.00" && RemainingFees!="0.00")
                    {
                        cbpaidcategory.Text = "Half-Paid";
                        SqlDataAdapter da = new SqlDataAdapter("select * from StudentYearFees where StudentId=" + id + " and Year='" + cbyear.Text + "'", cn);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        dgstudentview.DataSource = ds.Tables[0];
                    }

                    if(RemainingFees=="0.00")
                    {

                        cbpaidcategory.Text = "Paid";
                        SqlDataAdapter da = new SqlDataAdapter("select * from StudentYearFees where StudentId=" + id + " and Year='" + cbyear.Text + "'", cn);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        dgstudentview.DataSource = ds.Tables[0];
                    }


                }

            }
        }

        private void dgstudentview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           // MessageBox.Show(dgstudentview.Rows[e.RowIndex].Cells[6].Value.ToString());
          



        }

        private void dgstudentview_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            feesdetailform = "Allow";
           // MessageBox.Show(dgstudentview.Rows[e.RowIndex].Cells[6].Value.ToString());
            studentid = dgstudentview.Rows[e.RowIndex].Cells[6].Value.ToString();

            var studentdetailform1 = new studentdetail();
            studentdetailform1.Show();
            this.Dispose();
            feesdetailform = null;
        }
    }
}
