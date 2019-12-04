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
using System.IO;

namespace Hostel_Management_System
{
    public partial class RegularStudentFeesCollect : Form
    {
        SqlConnection cn = new SqlConnection(Hostelcodesource.database.cs);
        public RegularStudentFeesCollect()

        {
            InitializeComponent();
        }

        private void RegularStudentFeesCollect_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from StudentYearFees where StudentId=" + studentdetail.studentid + "", cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
          
            txtstudentname.Text = ds.Tables[0].Rows[0][1].ToString();
            txtbuilding.Text = ds.Tables[0].Rows[0][2].ToString();
          //  txtbuilding.Text = ds.Tables[0].Rows[0][2].ToString();
            txtroomno.Text = ds.Tables[0].Rows[0][0].ToString();
            txttotalfees.Text = ds.Tables[0].Rows[0][8].ToString();
            txttotalsubmittedfees.Text = ds.Tables[0].Rows[0][3].ToString();
            txtremainingfees.Text = ds.Tables[0].Rows[0][4].ToString();



            SqlDataAdapter da2 = new SqlDataAdapter("select Image from StudentDetails where Id=" + studentdetail.studentid + "", cn);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            var data = (Byte[])(ds2.Tables[0].Rows[0][0]);
            var stream = new MemoryStream(data);

            pbphoto.BackgroundImage = Image.FromStream(stream);

        }

        private void btnfeessubmit_Click(object sender, EventArgs e)
        {
            string totalstudentfees = (Convert.ToDouble(txtsubmitedfee.Text) + Convert.ToDouble(txttotalsubmittedfees.Text)).ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cn.Open();
            cmd.CommandText = "update StudentYearFees set SubmittedFees=" + totalstudentfees + ",RemainingFees=" + txttotalremaingfees.Text + ",Date=@p1 where StudentId="+ studentdetail.studentid +" and Year='"+ studentdetail.year +"'";
            SqlParameter para1 = new SqlParameter("@p1",SqlDbType.Date);
            para1.Value = DateTime.Today;
            cmd.Parameters.Add(para1);
            cmd.ExecuteNonQuery();
            cn.Close();
            string cheque;

            if(txtchequenumber.Text=="")
            {
                cheque = "NULL";
            }
            else
            {
                cheque = "'" + txtchequenumber.Text + "'";
            }
            string roll = null;
            string division1 = null;
            string pincode = null;
            string mobile = null;
            string fmobile = null;
            string college = null;
            string branch=null;
            string address = null;

           if(studentdetail.idorroll=="")

           {
               roll = "NULL";
           }
           else
           {
               roll = studentdetail.idorroll;
           }

            if(studentdetail.Division=="")
            {
                division1 = "-";
            }
            else
            {
                division1 = studentdetail.Division;
            }

            if(studentdetail.pincode=="")
            {
                pincode = "-";
            }
            else
            {
                pincode = studentdetail.pincode;
            }

            if(studentdetail.mobilenumber=="")
            {
                mobile = "NULL";
            }
            else
            {
                mobile = studentdetail.mobilenumber;
            }

            if(studentdetail.fathernumber=="")
            {
                fmobile = "NULL";   
            }
            else
            {
                fmobile = studentdetail.fathernumber;
            }

            if(studentdetail.college=="")
            {
                college = "-";
            }
            else
            {
                college = studentdetail.college;
            }

            if(studentdetail.branch=="")
            {
                branch = "-";

            }
            else
            {
                branch = studentdetail.branch;
            }

            if(studentdetail.address=="")
            {
                address = "-";
            }
            else
            {
                address = studentdetail.address;
            }



            SqlCommand cmd3 = new SqlCommand();
            cmd3.CommandText = "Insert into StudentFees(StudentName,MobileNumber,FatherNumber,CollegeOrSchool,BranchOrClass,Division,IDOrRollNumber,Address,Pincode,City,State,Nationality,TotalFees,SubmitedFees,RemainingFees,Feesby,ChequeNumber,Date,StudentId,Year) values ('" + txtstudentname.Text + "'," + mobile + "," + fmobile + ",'" + college + "','" + branch + "','" + division1 + "'," + roll + ",'" + address + "','" + pincode + "','" + studentdetail.city + "','" + studentdetail.State + "','" + studentdetail.Nationality + "'," + txttotalfees.Text + "," + totalstudentfees + "," + txttotalremaingfees.Text + ",'" + cbfeesstatus.Text + "'," + cheque + ",@p3,'" + studentdetail.studentid + "','"+ studentdetail.year +"')";
            cmd3.Connection = cn;
            cn.Open();
            SqlParameter sqlpara5 = new SqlParameter("@p3", SqlDbType.Date);
            sqlpara5.Value = DateTime.Today;
            cmd3.Parameters.Add(sqlpara5);
            cmd3.ExecuteNonQuery();
            cn.Close();
            cmd.Dispose();
            SoundPlayer sound = new SoundPlayer(@"c:\Windows\Media\chimes.wav");
            sound.Play();
            MessageBox.Show("Student Fees Collect Successfully ","Fees Added",MessageBoxButtons.OK);
            this.Dispose();

        }


        private void cbfeesstatus_TextChanged(object sender, EventArgs e)
        {
            if (cbfeesstatus.Text == "Cheque")
            {
                txtchequenumber.Enabled = true;
            }
        }

        private void txtsubmitedfee_Leave(object sender, EventArgs e)
        {
            if(Convert.ToDouble(txtsubmitedfee.Text)<=Convert.ToDouble(txtremainingfees.Text))
            {
             
                lblerror1.Visible = false;
                txttotalremaingfees.Text = (Convert.ToDouble(txtremainingfees.Text) - Convert.ToDouble(txtsubmitedfee.Text)).ToString();
            }
            else
            {
                lblerror1.Visible = true;
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
           
            this.Dispose();
        }

        private void txtsubmitedfee_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtsubmitedfee_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || e.KeyChar == '!' || e.KeyChar == '~' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '^' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '_' || e.KeyChar == '-' || e.KeyChar == '+' || e.KeyChar == '=' || e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '{' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '"' || e.KeyChar == '.' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '`' || e.KeyChar == '!' || e.KeyChar == '~' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '^' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '_' || e.KeyChar == '-' || e.KeyChar == '+' || e.KeyChar == '=' || e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '{' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '"' || e.KeyChar == '.' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '`' || e.KeyChar == 39 || e.KeyChar == 32)
            {

                e.Handled = true;
            }
        }
    }
}
