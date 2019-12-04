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
   
    public partial class Room_Selection : Form
    {
        SqlConnection cn = new SqlConnection(Hostelcodesource.database.cs);
        public static string roomnumber;
        public static string roomid;
        public static string building;
        public Room_Selection()
        {
            InitializeComponent();
        }

        

        private void Room_Selection_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hostelSystemHostelRoomDetailsDataSet.HostelRoomDetails' table. You can move, or remove it, as needed.
            //this.hostelRoomDetailsTableAdapter.Fill(this.hostelSystemHostelRoomDetailsDataSet.HostelRoomDetails);
            /* Graphics Effect */
            double fade;
            for (fade = 0.0; fade < 1.1; fade += 0.1)
            {
                this.Opacity = fade;
                this.Refresh();
                Thread.Sleep(50);

            }
            /* Graphics Effect */


         

            /* Fill Buildings in building combobox */
            SqlDataAdapter da2 = new SqlDataAdapter("Select Building from HostelRoomDetails group by Building", cn);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);

            for(int i=0;i<ds2.Tables[0].Rows.Count;i++)
            {
                cbbuilding.Items.Add(ds2.Tables[0].Rows[i][0].ToString());
            }
            cbbuilding.Items.Add("All Building");
            cbbuilding.Text = "All Building";


            SqlDataAdapter da3 = new SqlDataAdapter("Select Building from HostelRoomDetails group by Building", cn);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            cbspecificroombuilding.DataSource = ds3.Tables[0];
            cbspecificroombuilding.DisplayMember = "Building";


            SqlDataAdapter da4 = new SqlDataAdapter("Select CollegeOrSchool from HostelRoomDetails where CollegeOrSchool<>'Not Submitted' group by CollegeOrSchool", cn);
            DataSet ds4 = new DataSet();
            da4.Fill(ds4);
            cbcollegeorschool.DataSource = ds4.Tables[0];
            cbcollegeorschool.DisplayMember = "CollegeOrSchool";

            SqlDataAdapter da5 = new SqlDataAdapter("Select BranchOrClass from HostelRoomDetails where BranchOrClass<>'Not Submitted' group by BranchOrClass", cn);
            DataSet ds5 = new DataSet();
            da5.Fill(ds5);
           
            for (int i = 0; i < ds5.Tables[0].Rows.Count; i++)
            {
                cbbranchorclass.Items.Add(ds5.Tables[0].Rows[i][0].ToString());
            }
            cbbranchorclass.Items.Add("Not Use");
            cbbranchorclass.Text = "Not Use";

            SqlDataAdapter da6 = new SqlDataAdapter("Select State from HostelRoomDetails where State<>'Not Submitted' group by State", cn);
            DataSet ds6 = new DataSet();
            da6.Fill(ds6);
            cbstate.DataSource = ds6.Tables[0];
            cbstate.DisplayMember = "State";


            SqlDataAdapter da7 = new SqlDataAdapter("Select City from HostelRoomDetails where City<>'Not Submitted' group by City", cn);
            DataSet ds7 = new DataSet();
            da7.Fill(ds7);
          
            for (int i = 0; i < ds5.Tables[0].Rows.Count; i++)
            {
                cbcity.Items.Add(ds7.Tables[0].Rows[i][0].ToString());
            }
            cbcity.Items.Add("Not Use");
            cbcity.Text = "Not Use";


        }
           /* Fill Buildings in building combobox */
        private void btnregistration_Click(object sender, EventArgs e)
        {
            var registrationform = new Registration();
            registrationform.Show();
            this.Hide();
        }

        private void btnstudentdetails_Click(object sender, EventArgs e)
        {
            var roomdetailsform = new RoomDetails();
            roomdetailsform.Show();
            this.Hide();
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

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnfeessubmit_Click(object sender, EventArgs e)
        {
            if (lblfeeserror1.Visible != true && lblfeeserror2.Visible !=true)
            {
                if (Registration.imgcheck == 1)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cn.Open();
                    cmd.CommandText = "Insert into StudentDetails(StudentName,Image,Gender,BirthDate,MobileNumber,FatherNumber,Email,CollegeOrSchool,BranchOrClass,Division,IDOrRollNumber,Cast,SubCast,Address,Pincode,City,State,Nationality,Physical,AdmissionDate,Blood,Year) values ('" + Registration.Studentname + "',@pic,'" + Registration.Gender + "',@p1," + Registration.Studentmobilenumber + "," + Registration.Fathermobilenumber + ",'" + Registration.Email + "','" + Registration.College + "','" + Registration.Branchorclass + "','" + Registration.Division + "'," + Registration.Idorrollno + ",'" + Registration.cast + "','" + Registration.subcast + "','" + Registration.Address + "'," + Registration.Pincode + ",'" + Registration.City + "','" + Registration.State + "','" + Registration.Nationality + "','" + Registration.Physical + "',@p2,'" + Registration.Bloodgroup + "','" + Registration.year + "')";
                    SqlParameter sqlpara1 = new SqlParameter("@p1", SqlDbType.Date);
                    sqlpara1.Value = Registration.BirthDate;
                    SqlParameter sqlpara2 = new SqlParameter("@p2", SqlDbType.Date);
                    sqlpara2.Value = Registration.Admission;
                    SqlParameter sqlparapic = new SqlParameter("@pic",SqlDbType.Image);
                    sqlparapic.Value = Registration.image;
                    cmd.Parameters.Add(sqlpara1);
                    cmd.Parameters.Add(sqlpara2);
                    cmd.Parameters.Add(sqlparapic);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    cmd.Dispose();
                }
                else
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cn.Open();
                    cmd.CommandText = "Insert into StudentDetails(StudentName,Gender,BirthDate,MobileNumber,FatherNumber,Email,CollegeOrSchool,BranchOrClass,Division,IDOrRollNumber,Cast,SubCast,Address,Pincode,City,State,Nationality,Physical,AdmissionDate,Blood,Year) values ('" + Registration.Studentname + "','" + Registration.Gender + "',@p1," + Registration.Studentmobilenumber + "," + Registration.Fathermobilenumber + ",'" + Registration.Email + "','" + Registration.College + "','" + Registration.Branchorclass + "','" + Registration.Division + "'," + Registration.Idorrollno + ",'" + Registration.cast + "','" + Registration.subcast + "','" + Registration.Address + "'," + Registration.Pincode + ",'" + Registration.City + "','" + Registration.State + "','" + Registration.Nationality + "','" + Registration.Physical + "',@p2,'" + Registration.Bloodgroup + "','" + Registration.year + "')";
                    SqlParameter sqlpara1 = new SqlParameter("@p1", SqlDbType.Date);
                    sqlpara1.Value = Registration.BirthDate;
                    SqlParameter sqlpara2 = new SqlParameter("@p2", SqlDbType.Date);
                    sqlpara2.Value = Registration.Admission;
                    cmd.Parameters.Add(sqlpara1);
                    cmd.Parameters.Add(sqlpara2);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    cmd.Dispose();

                }


                SqlCommand cmd5 = new SqlCommand();
                cmd5.Connection = cn;
                cn.Open();
                cmd5.CommandText = "select max(Id) from StudentDetails";
                string id = cmd5.ExecuteScalar().ToString();
                cn.Close();
                cmd5.Dispose();


                //var popupmenu = new Popup();
                //popupmenu.Show();
                //this.Enabled = false;

                SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = cn;
                cn.Open();
                cmd2.CommandText = "update HostelRoomDetails set StudentName='" + Registration.Studentname + "',CollegeOrSchool='" + Registration.College + "',BranchOrClass='" + Registration.Branchorclass + "',Division='" + Registration.Division + "',IDOrRollNumber=" + Registration.Idorrollno + ",Cast='" + Registration.cast + "',SubCast='" + Registration.subcast + "',City='" + Registration.City + "',State='" + Registration.State + "',Nationality='" + Registration.Nationality + "',AdmissionDate=@p1,StudentId="+ id +" where RoomNumber='" + roomnumber + "' and RoomID=" + roomid + " and Building='" + building + "'";

                SqlParameter sqlpara3 = new SqlParameter("@p1", SqlDbType.Date);
                sqlpara3.Value = Registration.Admission;
                cmd2.Parameters.Add(sqlpara3);
                cmd2.ExecuteNonQuery();
                cn.Close();
                

                //Fees info

               int totalfees = Convert.ToInt32(txthostelfees.Text) + Convert.ToInt32(txtactivityfees.Text);
             int submittedfees = Convert.ToInt32(txtsubmittedfees.Text);
          int remainingfees = totalfees - submittedfees;
          string cheque;
          if (txtchequenumber.Text != "")
          {
              cheque = txtchequenumber.Text;
          }
          else
          {
              cheque = "-";
          }



          SqlCommand cmd3 = new SqlCommand();
          cmd3.Connection = cn;
          cn.Open();
          string Smobilenumber;
                if(Registration.Studentmobilenumber=="Not Submitted")
                {
                    Smobilenumber = "'"+ Registration.Studentmobilenumber +"'";
                }
                else
                {
                    Smobilenumber = "NULL";
                }


                string sfathernumber;
                if(Registration.Fathermobilenumber=="Not Submitted")
                {
                    sfathernumber = "'" + Registration.Fathermobilenumber + "'";
                }
                else
                {
                    sfathernumber = "NULL";
                }

                string scollege;
                if (Registration.College == "Not Submitted")
                {
                   scollege = "'" + Registration.College + "'";
                }
                else
                {
                    scollege = "NULL";
                }

                string sbranch;
                if (Registration.Branchorclass == "Not Submitted")
                {
                    sbranch = "'" + Registration.Branchorclass + "'";
                }
                else
                {
                    sbranch = "NULL";
                }


                string sDivision;
                if (Registration.Division == "Not Submitted")
                {
                    sDivision = "'" + Registration.Division + "'";
                }
                else
                {
                    sDivision = "NULL";
                }


                string sIDOrRollNumber;
                if (Registration.Idorrollno == "Not Submitted")
                {
                    sIDOrRollNumber = "'" + Registration.Idorrollno + "'";
                }
                else
                {
                    sIDOrRollNumber = "NULL";
                }


                string sAddress;
                if (Registration.Address == "Not Submitted")
                {
                    sAddress = "'" + Registration.Address + "'";
                }
                else
                {
                    sAddress = "NULL";
                }


                string sPincode;
                if (Registration.Pincode == "Not Submitted")
                {
                    sPincode = "'" + Registration.Pincode + "'";
                }
                else
                {
                    sPincode = "NULL";
                }


                string scheque;
                if(txtchequenumber.Text=="")
                {
                    scheque = "NULL";
                }
                else
                {
                    scheque=txtchequenumber.Text;
                }



                cmd3.CommandText = "Insert into StudentFees(StudentName,MobileNumber,FatherNumber,CollegeOrSchool,BranchOrClass,Division,IDOrRollNumber,Address,Pincode,City,State,Nationality,TotalFees,SubmitedFees,RemainingFees,Feesby,ChequeNumber,Date,StudentId,Year) values ('" + Registration.Studentname + "'," + Smobilenumber + "," + sfathernumber + "," + scollege + "," + sbranch + "," + sDivision + "," + sIDOrRollNumber + "," + sAddress + "," + sPincode + ",'" + Registration.City + "','" + Registration.State + "','" + Registration.Nationality + "'," + txttotalfees.Text + "," + txtsubmittedfees.Text + "," + txtremainingfees.Text + ",'" + cbfeesstatus.Text + "'," + scheque + ",@p3,"+ id +",'"+ Registration.year +"')";

          SqlParameter sqlpara5 = new SqlParameter("@p3", SqlDbType.Date);
          sqlpara5.Value = Registration.Admission;
          cmd3.Parameters.Add(sqlpara5);
          cmd3.ExecuteNonQuery();
          cn.Close();


         

              
                SqlCommand cmd4 = new SqlCommand();
                cmd4.Connection = cn;
                cn.Open();
                cmd4.CommandText = "insert into StudentYearFees (RoomNumber,Name,Building,SubmittedFees,RemainingFees,Date,StudentId,Year,TotalFees) values ('" + roomnumber + "','" + Registration.Studentname + "','" + building + "'," + submittedfees + "," + remainingfees + ",@p4," + id + ",'" + Registration.year + "','"+ txttotalfees.Text +"')";
                SqlParameter sqlpara6 = new SqlParameter("@p4", SqlDbType.Date);
                sqlpara6.Value = Registration.Admission;
                cmd4.Parameters.Add(sqlpara6);
                cmd4.ExecuteNonQuery();
                cn.Close();
                cmd4.Dispose();

                SoundPlayer sound = new SoundPlayer(@"c:\Windows\Media\chimes.wav");
                sound.Play();
                MessageBox.Show("Student Sucessfully Transfer To Room "+ building +"-" + roomnumber,"Student Information Saved",MessageBoxButtons.OK);

                var studentinfoform = new Student_Information();
                studentinfoform.Show();
                this.Dispose();


             

            }
        }

        private void cbbuilding_TextChanged(object sender, EventArgs e)
        {/* Show total Room and total Space */

            if (cbbuilding.Text == "All Building")
            {

                SqlDataAdapter da = new SqlDataAdapter("select RoomNumber,Building from HostelRoomDetails where StudentName='Free Space' group by RoomNumber,Building", cn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                string totalroom = ds.Tables[0].Rows.Count.ToString();
                txttotalroom.Text = totalroom;
                ds.Dispose();
                da.Dispose();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cn.Open();
                cmd.CommandText = "select Count(*) from HostelRoomDetails where StudentName='Free Space'";
                string totalspace = cmd.ExecuteScalar().ToString();
                txttotalspace.Text = totalspace;
                cn.Close();
                cmd.Dispose();

            }
            else
            {
                SqlDataAdapter da = new SqlDataAdapter("select RoomNumber from HostelRoomDetails where StudentName='Free Space' and Building='" + cbbuilding.Text + "' group by RoomNumber", cn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                string totalroom = ds.Tables[0].Rows.Count.ToString();
                txttotalroom.Text = totalroom;
                ds.Dispose();
                da.Dispose();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cn.Open();
                cmd.CommandText = "select Count(*) from HostelRoomDetails where StudentName='Free Space' and Building='" + cbbuilding.Text + "'";
                string totalspace = cmd.ExecuteScalar().ToString();
                txttotalspace.Text = totalspace;
                cn.Close();
                cmd.Dispose();
            }

            /* Show total Room and total Space */




        }

        private void btnrandom_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cn.Open();
            cmd.CommandText = "select Building from HostelRoomDetails where StudentName='Free Space' order by Building ASC";
            building= cmd.ExecuteScalar().ToString();
            cn.Close();
            cmd.Dispose();
           
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = cn;
            cn.Open();
            cmd2.CommandText = "select RoomNumber from HostelRoomDetails where StudentName='Free Space' and Building='" + building + "' order by RoomNumber ASC";
       roomnumber= cmd2.ExecuteScalar().ToString();
            cn.Close();
            cmd2.Dispose();

            SqlCommand cmd3 = new SqlCommand();
            cmd3.Connection = cn;
            cn.Open();
            cmd3.CommandText = "select Min(RoomID) from HostelRoomDetails where StudentName='Free Space' and Building='" + building + "' and RoomNumber='" + roomnumber + "'";
            roomid = cmd3.ExecuteScalar().ToString();
            cn.Close();
            cmd3.Dispose();


            panelfeesdetail.Enabled = true;
            btncustom.Enabled = false;

            SqlDataAdapter da = new SqlDataAdapter("select Fess,Deposite from FeesDetail where Year='"+ Registration.year +"'", cn);
            DataSet ds = new DataSet();
            da.Fill(ds);

            txthostelfees.Text = Convert.ToInt32(ds.Tables[0].Rows[0][0]).ToString();
            txtdeposite.Text = Convert.ToInt32(ds.Tables[0].Rows[0][1]).ToString();
           
        }

        private void cbfeesstatus_TextChanged(object sender, EventArgs e)
        {
            if (cbfeesstatus.Text=="Cheque")
            {
                txtchequenumber.Enabled = true;
            }
            else
            {
                txtchequenumber.Enabled = false;
            }
        }

        private void txtactivityfees_Leave(object sender, EventArgs e)
        {
            double activityfee = Convert.ToDouble(txtactivityfees.Text);
            double hostelfees = Convert.ToDouble(txthostelfees.Text);
            if (activityfee>hostelfees)
            {
                lblfeeserror1.Visible = true;
                txttotalfees.Text = txthostelfees.Text;
            }
            else
            {
                lblfeeserror1.Visible = false;
            }
            if(txtactivityfees.Text!="")
            {
               
                txtactivityfees.Text = activityfee.ToString();

                double totalfees=(Convert.ToDouble(txthostelfees.Text)+Convert.ToDouble(txtactivityfees.Text));
                txttotalfees.Text = totalfees.ToString();

            }
            else
            {
                txttotalfees.Text = txthostelfees.Text;
            }
        }

        private void txtsubmittedfees_Leave(object sender, EventArgs e)
        {
            double totalfees = Convert.ToDouble(Convert.ToDouble(txttotalfees.Text));
            double submittedfees = Convert.ToDouble(txtsubmittedfees.Text);
            double total = totalfees - submittedfees;

            if (submittedfees == totalfees)
            {
                double remainingfees = Convert.ToDouble(txttotalfees.Text) - Convert.ToDouble(txtsubmittedfees.Text);
                txtremainingfees.Text = remainingfees.ToString();
                lblfeeserror2.Visible = false;
                goto here;
            }

            if(submittedfees>totalfees)
            {
                lblfeeserror2.Visible = true;
            }
            else
            {
                double remainingfees = Convert.ToDouble(txttotalfees.Text) - Convert.ToDouble(txtsubmittedfees.Text);
                txtremainingfees.Text = remainingfees.ToString();
                lblfeeserror2.Visible =false;
            }
            here:;     
        }

        private void txtactivityfees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || e.KeyChar == '!' || e.KeyChar == '~' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '^' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '_' || e.KeyChar == '-' || e.KeyChar == '+' || e.KeyChar == '=' || e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '{' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '"' || e.KeyChar == '.' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '`' || e.KeyChar == '!' || e.KeyChar == '~' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '^' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '_' || e.KeyChar == '-' || e.KeyChar == '+' || e.KeyChar == '=' || e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '{' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '"' || e.KeyChar == '.' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '`' || e.KeyChar == 39 || e.KeyChar == 32)
            {

                e.Handled = true;
            }
        }

        private void txtsubmittedfees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || e.KeyChar == '!' || e.KeyChar == '~' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '^' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '_' || e.KeyChar == '-' || e.KeyChar == '+' || e.KeyChar == '=' || e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '{' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '"' || e.KeyChar == '.' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '`' || e.KeyChar == '!' || e.KeyChar == '~' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '^' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '_' || e.KeyChar == '-' || e.KeyChar == '+' || e.KeyChar == '=' || e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '{' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '"' || e.KeyChar == '.' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '`' || e.KeyChar == 39 || e.KeyChar == 32)
            {

                e.Handled = true;
            }
        }

        private void txtchequenumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ( e.KeyChar == '!' || e.KeyChar == '~' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '^' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '_' || e.KeyChar == '-' || e.KeyChar == '+' || e.KeyChar == '=' || e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '{' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '"' || e.KeyChar == '.' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '`' || e.KeyChar == '!' || e.KeyChar == '~' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '^' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '_' || e.KeyChar == '-' || e.KeyChar == '+' || e.KeyChar == '=' || e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '{' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '"' || e.KeyChar == '.' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '`' || e.KeyChar == 39 || e.KeyChar == 32)
            {

                e.Handled = true;
            }
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btncustom_Click(object sender, EventArgs e)
        {
            panelcustomselection.Enabled = true;
            btnrandom.Enabled = false;
        }

        private void txtroomnumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                SqlDataAdapter da = new SqlDataAdapter("select RoomNumber from HostelRoomDetails where StudentName='Free Space' and Building='" + cbspecificroombuilding.Text + "' and RoomNumber='"+txtroomnumber.Text +"' group by RoomNumber", cn);
                DataSet ds = new DataSet();
                da.Fill(ds);
              //  dgspecificroom.DataSource = ds.Tables[0];

                if (ds.Tables[0].Rows.Count ==1)
                {
                    lblerror1.Visible = false;


                    SqlDataAdapter da2 = new SqlDataAdapter("select * from HostelRoomDetails where StudentName='Free Space' and Building='" + cbspecificroombuilding.Text + "' and RoomNumber='" + txtroomnumber.Text + "'", cn);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    dgspecificroom.Rows[0].Cells[0].Value =txtroomnumber.Text;
                    dgspecificroom.Rows[0].Cells[1].Value = cbspecificroombuilding.Text;
                    dgspecificroom.Rows[0].Cells[2].Value = ds2.Tables[0].Rows.Count.ToString();
                    

                }

                else
                {
                    lblerror1.Visible = true;
                }
            }
        }

        private void dgspecificroom_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgspecificroom.Rows.Count==1)
            {
                roomnumber = dgspecificroom.Rows[0].Cells[0].Value.ToString();
                building = dgspecificroom.Rows[0].Cells[1].Value.ToString();

                SqlCommand cmd3 = new SqlCommand();
                cmd3.Connection = cn;
                cn.Open();
                cmd3.CommandText = "select Min(RoomID) from HostelRoomDetails where StudentName='Free Space' and Building='" + building + "' and RoomNumber='" + roomnumber + "'";
                roomid = cmd3.ExecuteScalar().ToString();
                cn.Close();
                cmd3.Dispose();

                SqlDataAdapter da = new SqlDataAdapter("select * from HostelRoomDetails where StudentName<>'Free Space' and Building='" + cbspecificroombuilding.Text + "' and RoomNumber='" + txtroomnumber.Text + "'", cn);
             DataSet ds = new DataSet();
                da.Fill(ds);
                dgstudentchoosenview.DataSource = ds.Tables[0];
                lblchoosenroomno.Text = building + "-" + roomnumber;
                lblfreespace.Text = dgspecificroom.Rows[0].Cells[2].Value.ToString();
                Panelstudentchoosenroom.Enabled = true;
            }
        }

        private void btnsubmit_Click(object sender, EventArgs e)
        {
            panelfeesdetail.Enabled = true;
            SqlDataAdapter da = new SqlDataAdapter("select Fess,Deposite from FeesDetail where Year='" + Registration.year + "'", cn);
            DataSet ds = new DataSet();
            da.Fill(ds);

            txthostelfees.Text = Convert.ToInt32(ds.Tables[0].Rows[0][0]).ToString();
            txtdeposite.Text = Convert.ToInt32(ds.Tables[0].Rows[0][1]).ToString();
           
        }

        private void tabcustomselection_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbspecificroombuilding_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void txtroomnumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void dgspecificroom_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblerror1_Click(object sender, EventArgs e)
        {

        }

        private void cbcollegeorschool_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dgstudentcollegeview.Rows.Clear();
                if (dgstudentcollegeview.Rows.Count != 1)
                {
                    for (int i = 0; i < dgstudentcollegeview.Rows.Count - 1; i++)
                    {

                        dgstudentcollegeview.Rows.Remove(dgstudentcollegeview.Rows[i]);
                    }
                }

                if (cbbranchorclass.Text == "Not Use")
                {
                    SqlDataAdapter da = new SqlDataAdapter("select Building,RoomNumber from HostelRoomDetails where CollegeOrSchool='" + cbcollegeorschool.Text + "' group by Building,RoomNumber order by Building,RoomNumber", cn);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    // dgstudentcollegeview.DataSource = ds.Tables[0];

                   if(ds.Tables[0].Rows.Count>0)
                   {
                       lblerror2.Visible = false;
                       string space;
                       int index = 0;
                       for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                       {

                           SqlCommand cmd = new SqlCommand();
                           cmd.Connection = cn;
                           cn.Open();
                           cmd.CommandText = "select count(*) from HostelRoomDetails where StudentName='Free Space' and Building='" + ds.Tables[0].Rows[i][0].ToString() + "' and RoomNumber='" + ds.Tables[0].Rows[i][1].ToString() + "'";
                           space = cmd.ExecuteScalar().ToString();
                           cn.Close();

                           if (Convert.ToInt32(space) != 0)
                           {

                               dgstudentcollegeview.Rows.Add();
                               dgstudentcollegeview.Rows[index].Cells[0].Value = ds.Tables[0].Rows[i][1].ToString();
                               dgstudentcollegeview.Rows[index].Cells[1].Value = ds.Tables[0].Rows[i][0].ToString();
                               dgstudentcollegeview.Rows[index].Cells[2].Value = space;
                               index = index + 1;

                           }
                           ds.Dispose();



                       }

                   }

                   else
                   {
                       lblerror2.Visible = true;
                   }

                }
                else
                {
                    SqlDataAdapter da = new SqlDataAdapter("select Building,RoomNumber from HostelRoomDetails where CollegeOrSchool='" + cbcollegeorschool.Text + "' and BranchOrClass='" + cbbranchorclass.Text + "' group by Building,RoomNumber order by Building,RoomNumber", cn);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    // dgstudentcollegeview.DataSource = ds.Tables[0];
                    string space;
                    int index = 0;
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = cn;
                        cn.Open();
                        cmd.CommandText = "select count(*) from HostelRoomDetails where StudentName='Free Space' and Building='" + ds.Tables[0].Rows[i][0].ToString() + "' and RoomNumber='" + ds.Tables[0].Rows[i][1].ToString() + "'";
                        space = cmd.ExecuteScalar().ToString();
                        cn.Close();

                        if (Convert.ToInt32(space) != 0)
                        {

                            dgstudentcollegeview.Rows.Add();
                            dgstudentcollegeview.Rows[index].Cells[0].Value = ds.Tables[0].Rows[i][1].ToString();
                            dgstudentcollegeview.Rows[index].Cells[1].Value = ds.Tables[0].Rows[i][0].ToString();
                            dgstudentcollegeview.Rows[index].Cells[2].Value = space;
                            index = index + 1;

                        }
                        ds.Dispose();



                    }

                }
               

            }

        }

        private void cbbranchorclass_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                cbcollegeorschool_KeyDown(sender, e);
            }
        }

        private void cbbranchorclass_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void dgstudentcollegeview_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            roomnumber=dgstudentcollegeview.Rows[e.RowIndex].Cells[0].Value.ToString();
            building = dgstudentcollegeview.Rows[e.RowIndex].Cells[1].Value.ToString();
            SqlCommand cmd3 = new SqlCommand();
            cmd3.Connection = cn;
            cn.Open();
            cmd3.CommandText = "select Min(RoomID) from HostelRoomDetails where StudentName='Free Space' and Building='" + building + "' and RoomNumber='" + roomnumber + "'";
            roomid = cmd3.ExecuteScalar().ToString();
            cn.Close();
            cmd3.Dispose();

            SqlDataAdapter da = new SqlDataAdapter("select * from HostelRoomDetails where StudentName<>'Free Space' and Building='" + building + "' and RoomNumber='" + roomnumber + "'", cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dgstudentchoosenview.DataSource = ds.Tables[0];
            lblchoosenroomno.Text = building + "-" + roomnumber;
            lblfreespace.Text = dgstudentcollegeview.Rows[e.RowIndex].Cells[2].Value.ToString();
            Panelstudentchoosenroom.Enabled = true;
        }

        private void cbstate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dgvstateview.Rows.Clear();
                if (dgvstateview.Rows.Count != 1)
                {
                    for (int i = 0; i < dgvstateview.Rows.Count - 1; i++)
                    {

                        dgvstateview.Rows.Remove(dgvstateview.Rows[i]);
                    }
                }

                if (cbcity.Text == "Not Use")
                {
                    SqlDataAdapter da = new SqlDataAdapter("select Building,RoomNumber from HostelRoomDetails where State='" + cbstate.Text + "' group by Building,RoomNumber order by Building,RoomNumber", cn);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    // dgstudentcollegeview.DataSource = ds.Tables[0];

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblerror2.Visible = false;
                        string space;
                        int index = 0;
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {

                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = cn;
                            cn.Open();
                            cmd.CommandText = "select count(*) from HostelRoomDetails where StudentName='Free Space' and Building='" + ds.Tables[0].Rows[i][0].ToString() + "' and RoomNumber='" + ds.Tables[0].Rows[i][1].ToString() + "'";
                            space = cmd.ExecuteScalar().ToString();
                            cn.Close();

                            if (Convert.ToInt32(space) != 0)
                            {

                                dgvstateview.Rows.Add();
                                dgvstateview.Rows[index].Cells[0].Value = ds.Tables[0].Rows[i][1].ToString();
                                dgvstateview.Rows[index].Cells[1].Value = ds.Tables[0].Rows[i][0].ToString();
                                dgvstateview.Rows[index].Cells[2].Value = space;
                                index = index + 1;

                            }
                            ds.Dispose();



                        }

                    }

                    else
                    {
                        lblerror2.Visible = true;
                    }

                }
                else
                {
                    SqlDataAdapter da = new SqlDataAdapter("select Building,RoomNumber from HostelRoomDetails where State='" + cbstate.Text + "' and City='" + cbcity.Text + "' group by Building,RoomNumber order by Building,RoomNumber", cn);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    // dgstudentcollegeview.DataSource = ds.Tables[0];
                    string space;
                    int index = 0;
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = cn;
                        cn.Open();
                        cmd.CommandText = "select count(*) from HostelRoomDetails where StudentName='Free Space' and Building='" + ds.Tables[0].Rows[i][0].ToString() + "' and RoomNumber='" + ds.Tables[0].Rows[i][1].ToString() + "'";
                        space = cmd.ExecuteScalar().ToString();
                        cn.Close();

                        if (Convert.ToInt32(space) != 0)
                        {

                            dgstudentcollegeview.Rows.Add();
                            dgstudentcollegeview.Rows[index].Cells[0].Value = ds.Tables[0].Rows[i][1].ToString();
                            dgstudentcollegeview.Rows[index].Cells[1].Value = ds.Tables[0].Rows[i][0].ToString();
                            dgstudentcollegeview.Rows[index].Cells[2].Value = space;
                            index = index + 1;

                        }
                        ds.Dispose();



                    }

                }


            }

        }

        private void cbcity_KeyPress(object sender, KeyPressEventArgs e)
        {
           
          
        }

        private void cbcity_KeyDown(object sender, KeyEventArgs e)
        {
           if (e.KeyCode == Keys.Enter)
           {
                cbstate_KeyDown(sender,e);
           }
             
        }

        private void dgvstateview_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            roomnumber = dgvstateview.Rows[e.RowIndex].Cells[0].Value.ToString();
            building = dgvstateview.Rows[e.RowIndex].Cells[1].Value.ToString();
            SqlCommand cmd3 = new SqlCommand();
            cmd3.Connection = cn;
            cn.Open();
            cmd3.CommandText = "select Min(RoomID) from HostelRoomDetails where StudentName='Free Space' and Building='" + building + "' and RoomNumber='" + roomnumber + "'";
            roomid = cmd3.ExecuteScalar().ToString();
            cn.Close();
            cmd3.Dispose();

            SqlDataAdapter da = new SqlDataAdapter("select * from HostelRoomDetails where StudentName<>'Free Space' and Building='" + building + "' and RoomNumber='" + roomnumber + "'", cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dgstudentchoosenview.DataSource = ds.Tables[0];
            lblchoosenroomno.Text = building + "-" + roomnumber;
            lblfreespace.Text = dgvstateview.Rows[e.RowIndex].Cells[2].Value.ToString();
            Panelstudentchoosenroom.Enabled = true;
        }

        private void btnusersetting_Click(object sender, EventArgs e)
        {
            var usersettingform = new Usersettings();
            usersettingform.Show();
            this.Dispose();
        }

        private void minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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
