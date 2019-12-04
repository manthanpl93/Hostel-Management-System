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
using System.IO;

namespace Hostel_Management_System
{
    public partial class studentdetail : Form
    {
        SqlConnection cn = new SqlConnection(Hostelcodesource.database.cs);
        public static string studentid = null;
        public static string mobilenumber;
        public static string fathernumber;
        public static string college;
        public static string branch;
        public static string Division;
        public static string idorroll;
        public static string address;
        public static string pincode;
        public static string city;
        public static string State;
        public static string Nationality;
        public static byte[] image;
        public static string year;
        public studentdetail()
        {
            InitializeComponent();
        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }


        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));

        }
        private void btnfeesdetails_Click(object sender, EventArgs e)
        {
            var feesdataform = new Fees_Details();
            feesdataform.Show();
            this.Hide();
        }

        private void btnroomdetails_Click(object sender, EventArgs e)
        {
            var roomdetailsform = new RoomDetails();
            roomdetailsform.Show();
            this.Hide();
        }

        private void btnregistration_Click(object sender, EventArgs e)
        {
            var registrationform = new Registration();
            registrationform.Show();
            this.Hide();
        }

        private void btnmenu_Click(object sender, EventArgs e)
        {
            var homepageform = new Homepage();
            homepageform.Show();
            this.Hide();
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            txtstudentname.ReadOnly = false;
            txtstudentname.BorderStyle = BorderStyle.Fixed3D;
            txtgender.ReadOnly = false;
            txtgender.BorderStyle = BorderStyle.Fixed3D;
            txtstudentmobileno.ReadOnly = false;
            txtstudentmobileno.BorderStyle = BorderStyle.Fixed3D;
            txtbirthdate.ReadOnly = false;
            txtbirthdate.BorderStyle = BorderStyle.Fixed3D;
            txtstudentfatherno.ReadOnly = false;
            txtstudentfatherno.BorderStyle = BorderStyle.Fixed3D;
            txtstudentcollege.ReadOnly = false;
            txtstudentcollege.BorderStyle = BorderStyle.Fixed3D;
            txtstudentbranchorclass.ReadOnly = false;
            txtstudentbranchorclass.BorderStyle = BorderStyle.Fixed3D;
            txtdivision.ReadOnly = false;
            txtdivision.BorderStyle = BorderStyle.Fixed3D;
            txtcollegeidorrollno.ReadOnly = false;
            txtcollegeidorrollno.BorderStyle = BorderStyle.Fixed3D;
            txtstudentadmissiondate.ReadOnly = false;
            txtstudentadmissiondate.BorderStyle = BorderStyle.Fixed3D;
            txtcast.ReadOnly = false;
            txtcast.BorderStyle = BorderStyle.Fixed3D;
            txtstudentsubcast.ReadOnly = false;
            txtstudentsubcast.BorderStyle = BorderStyle.Fixed3D;
            txtstudentaddress.ReadOnly = false;
            txtstudentaddress.BorderStyle = BorderStyle.Fixed3D;
            txtstudentpincode.ReadOnly = false;
            txtstudentpincode.BorderStyle = BorderStyle.Fixed3D;
            txtstudentcity.ReadOnly = false;
            txtstudentcity.BorderStyle = BorderStyle.Fixed3D;
            txtstudentstate.ReadOnly = false;
            txtstudentstate.BorderStyle = BorderStyle.Fixed3D;
            txtnationality.ReadOnly = false;
            txtnationality.BorderStyle = BorderStyle.Fixed3D;
            txtstudentblood.ReadOnly = false;
            txtstudentblood.BorderStyle = BorderStyle.Fixed3D;
            txtstudentphysical.ReadOnly = false;
            txtstudentphysical.BorderStyle = BorderStyle.Fixed3D;
            txtstudentemail.ReadOnly = false;
            txtstudentemail.BorderStyle = BorderStyle.Fixed3D;
            btnsave.Enabled = true;
            btnedit.Enabled = false;
        }

        private void btnadvancedetail_Click(object sender, EventArgs e)
        {
            var advancedetailform = new studentadvancedetails();
            advancedetailform.Show();
            this.Dispose();

        }

        private void studentdetail_Load(object sender, EventArgs e)
        {
            double fade;
            for (fade = 0.0; fade < 1.1; fade += 0.1)
            {
                this.Opacity = fade;
                this.Refresh();
                Thread.Sleep(30);

            }
            DataSet ds = new DataSet();
            if(Fees_Details.feesdetailform!=null)
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from StudentDetails where Id='" + Fees_Details.studentid + "'", cn);
               
                da.Fill(ds);
                txtstudentid.Text = Fees_Details.studentid;
            }
            else
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from StudentDetails where Id='" + Student_Information.Id + "'", cn);
          
                da.Fill(ds);
                txtstudentid.Text = Student_Information.Id;
            }

            studentid = txtstudentid.Text;
      txtstudentname.Text = ds.Tables[0].Rows[0][1].ToString();
        
            txtgender.Text = ds.Tables[0].Rows[0][3].ToString();
            txtbirthdate.Text = ds.Tables[0].Rows[0][4].ToString();
            txtstudentmobileno.Text = ds.Tables[0].Rows[0][5].ToString();
            mobilenumber = ds.Tables[0].Rows[0][5].ToString();
            txtstudentfatherno.Text = ds.Tables[0].Rows[0][6].ToString();
            fathernumber = ds.Tables[0].Rows[0][6].ToString();
            txtstudentemail.Text = ds.Tables[0].Rows[0][7].ToString();
            txtstudentcollege.Text = ds.Tables[0].Rows[0][8].ToString();
            college = ds.Tables[0].Rows[0][8].ToString();
            txtstudentbranchorclass.Text = ds.Tables[0].Rows[0][9].ToString();
            branch = ds.Tables[0].Rows[0][9].ToString();
        
            txtdivision.Text = ds.Tables[0].Rows[0][10].ToString();
            Division = ds.Tables[0].Rows[0][10].ToString();
            txtcollegeidorrollno.Text = ds.Tables[0].Rows[0][11].ToString();
            idorroll = ds.Tables[0].Rows[0][11].ToString();
            txtcast.Text = ds.Tables[0].Rows[0][12].ToString();

            txtstudentsubcast.Text = ds.Tables[0].Rows[0][13].ToString();
            txtstudentaddress.Text = ds.Tables[0].Rows[0][14].ToString();
            address = ds.Tables[0].Rows[0][14].ToString();
            txtstudentpincode.Text = ds.Tables[0].Rows[0][15].ToString();
            pincode = ds.Tables[0].Rows[0][15].ToString();
            txtstudentcity.Text = ds.Tables[0].Rows[0][16].ToString();
            city = ds.Tables[0].Rows[0][16].ToString();
            txtstudentstate.Text = ds.Tables[0].Rows[0][17].ToString();
            State = ds.Tables[0].Rows[0][17].ToString();
            txtnationality.Text = ds.Tables[0].Rows[0][18].ToString();
            Nationality = ds.Tables[0].Rows[0][18].ToString();
            txtstudentphysical.Text = ds.Tables[0].Rows[0][19].ToString();
            txtstudentadmissiondate.Text = ds.Tables[0].Rows[0][20].ToString();
            txtstudentblood.Text = ds.Tables[0].Rows[0][21].ToString();

            var data = (Byte[])(ds.Tables[0].Rows[0][2]);
            var stream = new MemoryStream(data);

            pbphoto.BackgroundImage = Image.FromStream(stream);

            SqlDataAdapter da2 = new SqlDataAdapter("select RoomNumber,Building from HostelRoomDetails where StudentId='" + txtstudentid.Text + "'", cn);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);

            txtroomno.Text = ds2.Tables[0].Rows[0][0].ToString();
            txtbuilding.Text = ds2.Tables[0].Rows[0][1].ToString();

            SqlDataAdapter da4 = new SqlDataAdapter("select Year from FeesDetail group by Year", cn);
            DataSet ds4 = new DataSet();
            da4.Fill(ds4);
            cbyear.DataSource = ds4.Tables[0];
            cbyear.DisplayMember = "Year";


            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cn.Open();
            cmd.CommandText = "select max(Id) from FeesDetail";
            string currentId = cmd.ExecuteScalar().ToString();

            cmd.CommandText = "select Year from FeesDetail where Id=" + currentId + "";
            string currentyear = cmd.ExecuteScalar().ToString();
            cbyear.Text = currentyear;
            cn.Close();
            cmd.Dispose();

            SqlDataAdapter da3 = new SqlDataAdapter("select TotalFees,RemainingFees from StudentYearFees where StudentId='" + txtstudentid.Text + "' and Year='" + cbyear.Text + "'", cn);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            txtcurrentfees.Text = ds3.Tables[0].Rows[0][0].ToString();
            txtremaingfees.Text = ds3.Tables[0].Rows[0][1].ToString();

            if(txtremaingfees.Text=="0.00")
            {
                btncollectfee.Enabled = false;
            }
            else
            {
                btncollectfee.Enabled = true;
            }

           

        }

        private void txtstudentname_TextChanged(object sender, EventArgs e)
        {

        }

        private void panelmenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            SoundPlayer sound = new SoundPlayer(@"c:\Windows\Media\chimes.wav");
            sound.Play();
            DialogResult dr = MessageBox.Show("Are You Sure You want to Remove This Student  From Hostel ?", "Remove ", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cn.Open();
                cmd.CommandText = "update HostelRoomDetails set StudentName='Free Space',CollegeOrSchool=NULL,BranchOrClass=NULL,Division=NULL,IDOrRollNumber=NULL,Cast=NULL,SubCast=NULL,City=NULL,State=NULL,Nationality=NULL,AdmissionDate=NULL,StudentId=NULL where StudentId=" + txtstudentid.Text + "";
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Student Info Suceessfully deleted From Hostel", "Remove Suceessfully ", MessageBoxButtons.OK);
                var studentinform = new Student_Information();
                studentinform.Show();
                this.Dispose();

            }


        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            txtstudentname.ReadOnly = true;
            txtstudentname.BorderStyle = BorderStyle.None;
            txtgender.ReadOnly = true;
            txtgender.BorderStyle = BorderStyle.None;
            txtstudentmobileno.ReadOnly = true;
            txtstudentmobileno.BorderStyle = BorderStyle.None;
            txtbirthdate.ReadOnly = true;
            txtbirthdate.BorderStyle = BorderStyle.None;
            txtstudentfatherno.ReadOnly = true;
            txtstudentfatherno.BorderStyle = BorderStyle.None;
            txtstudentcollege.ReadOnly = true;
            txtstudentcollege.BorderStyle = BorderStyle.None;
            txtstudentbranchorclass.ReadOnly = true;
            txtstudentbranchorclass.BorderStyle = BorderStyle.None;
            txtdivision.ReadOnly = true;
            txtdivision.BorderStyle = BorderStyle.None;
            txtcollegeidorrollno.ReadOnly = true;
            txtcollegeidorrollno.BorderStyle = BorderStyle.None;
            txtstudentadmissiondate.ReadOnly = true;
            txtstudentadmissiondate.BorderStyle = BorderStyle.None;
            txtcast.ReadOnly = true;
            txtcast.BorderStyle = BorderStyle.Fixed3D;
            txtstudentsubcast.ReadOnly = true;
            txtstudentsubcast.BorderStyle = BorderStyle.None;
            txtstudentaddress.ReadOnly = true;
            txtstudentaddress.BorderStyle = BorderStyle.None;
            txtstudentpincode.ReadOnly = true;
            txtstudentpincode.BorderStyle = BorderStyle.None;
            txtstudentcity.ReadOnly = true;
            txtstudentcity.BorderStyle = BorderStyle.None;
            txtstudentstate.ReadOnly = true;
            txtstudentstate.BorderStyle = BorderStyle.None;
            txtnationality.ReadOnly = true;
            txtnationality.BorderStyle = BorderStyle.None;
            txtstudentblood.ReadOnly = true;
            txtstudentblood.BorderStyle = BorderStyle.None;
            txtstudentphysical.ReadOnly = true;
            txtstudentphysical.BorderStyle = BorderStyle.None;
            txtstudentemail.ReadOnly = true;
            txtstudentemail.BorderStyle = BorderStyle.None;
            
            
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cn.Open();
            cmd.CommandText = "update StudentDetails set StudentName='"+ txtstudentname.Text +"',Gender='"+ txtgender.Text +"',BirthDate=@p1,MobileNumber='"+ txtstudentmobileno.Text +"',FatherNumber='"+ txtstudentfatherno.Text +"',Email='"+ txtstudentemail.Text +"',CollegeOrSchool='"+txtstudentcollege.Text +"',BranchOrClass='"+ txtstudentbranchorclass.Text +"',Division='"+ txtdivision.Text +"',IDOrRollNumber='"+ txtstudentid.Text +"',Cast='"+ txtcast.Text +"',SubCast='"+ txtstudentsubcast.Text +"',Address='"+ txtstudentaddress.Text +"',Pincode='"+ txtstudentpincode.Text +"',City='"+ txtstudentcity.Text +"',State='"+ txtstudentstate.Text +"',Nationality='"+ txtnationality.Text +"',Physical='"+ txtstudentphysical.Text +"',Blood='"+ txtstudentblood.Text +"' where Id='"+txtstudentid.Text +"'";
            SqlParameter para1 = new SqlParameter("p1", SqlDbType.Date);
            para1.Value = txtbirthdate.Text;
            cmd.Parameters.Add(para1);
            cmd.ExecuteNonQuery();
           
         

            cmd.CommandText = "update HostelRoomDetails set StudentName='"+ txtstudentname.Text +"',CollegeOrSchool='"+ txtstudentcollege.Text +"',BranchOrClass='"+txtstudentbranchorclass.Text +"',Division='"+ txtdivision.Text +"',IDOrRollNumber='"+ txtstudentid.Text +"',Cast='"+ txtcast.Text +"',SubCast='"+ txtstudentsubcast.Text +"',City='"+ txtstudentcity.Text +"',State='"+ txtstudentstate.Text +"',Nationality='"+ txtnationality.Text+"' where StudentId='"+ txtstudentid.Text +"'";
            
            cmd.ExecuteNonQuery();


            cmd.CommandText = "update StudentYearFees set Name='" + txtstudentname.Text + "' where StudentId='" + txtstudentid.Text + "'";

            cmd.ExecuteNonQuery();


            cn.Close();
            
            SoundPlayer sound = new SoundPlayer(@"c:\Windows\Media\chimes.wav");
            sound.Play();
            MessageBox.Show("Student Update Successfully ","Information Updated");
            btnedit.Enabled = true;
            btnsave.Enabled = false;
        }

        private void txtstudentname_Leave(object sender, EventArgs e)
        {
            if (txtstudentname.Text == "")
            {
                lblerror1.Visible = true;
            }
            else
            {
                lblerror1.Visible = false;
            }
        }

        private void txtstudentmobileno_Leave(object sender, EventArgs e)
        {
           if(txtstudentmobileno.Text=="")
           {
               txtstudentmobileno.Text = "Not Submitted";
               goto here;
           }
            if (txtstudentmobileno.Text != "")
            {
                if (txtstudentmobileno.TextLength != 10)
                {
                    lblerror2.Visible = true;
                }
                else
                {
                    lblerror2.Visible = false;
                }
            }
            else
            {
                lblerror2.Visible = false;
            }

        here: ;

        }

        private void txtstudentfatherno_Leave(object sender, EventArgs e)
        {
            if(txtstudentfatherno.Text=="")
            {
                txtstudentfatherno.Text = "Not Submitted";
                goto here;
            }
            if (txtstudentfatherno.Text != "")
            {
                if (txtstudentfatherno.TextLength != 10)
                {
                    lblerror3.Visible = true;
                }
                else
                {
                    lblerror3.Visible = false;
                }
            }
            else
            {
                lblerror2.Visible = false;
            }

            here:;
        }

        private void txtstudentmobileno_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtstudentfatherno_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void txtstudentemail_Leave(object sender, EventArgs e)
        {
            if (txtstudentemail.Text == "")
            {
                txtstudentfatherno.Text = "Not Submitted";
                goto here;
            }
            if (txtstudentemail.Text != "")
            {
                int i;
                try
                {
                    var email = new System.Net.Mail.MailAddress(txtstudentemail.Text);

                    i = 0;
                }
                catch
                {
                    i = 1;
                }


                if (i == 1)
                {
                    lblerror4.Visible = true;
                }
                else
                {
                    lblerror4.Visible = false;
                }
            }
        here: ;
        }

        private void txtstudentmobileno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || e.KeyChar == '!' || e.KeyChar == '~' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '^' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '_' || e.KeyChar == '-' || e.KeyChar == '+' || e.KeyChar == '=' || e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '{' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '"' || e.KeyChar == '.' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '`' || e.KeyChar == '!' || e.KeyChar == '~' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '^' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '_' || e.KeyChar == '-' || e.KeyChar == '+' || e.KeyChar == '=' || e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '{' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '"' || e.KeyChar == '.' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '`' || e.KeyChar == 39 || e.KeyChar == 32)
            {

                e.Handled = true;
            }

        }

        private void txtstudentfatherno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || e.KeyChar == '!' || e.KeyChar == '~' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '^' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '_' || e.KeyChar == '-' || e.KeyChar == '+' || e.KeyChar == '=' || e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '{' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '"' || e.KeyChar == '.' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '`' || e.KeyChar == '!' || e.KeyChar == '~' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '^' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '_' || e.KeyChar == '-' || e.KeyChar == '+' || e.KeyChar == '=' || e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '{' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '"' || e.KeyChar == '.' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '`' || e.KeyChar == 39 || e.KeyChar == 32)
            {

                e.Handled = true;
            }
        }

        private void txtstudentcity_Leave(object sender, EventArgs e)
        {
            if(txtstudentcity.Text=="")
            {
                lblerror6.Visible = true;

            }
            else
            {
                lblerror6.Visible = false;
            }
        }

        private void txtstudentstate_Leave(object sender, EventArgs e)
        {
            if(txtstudentstate.Text=="")
            {
                lblerror7.Visible = true;
            }
            else
            {
                lblerror7.Visible = false;
            }
        }

        private void txtnationality_Leave(object sender, EventArgs e)
        {
            if(txtnationality.Text=="")
            {
                lblerror8.Visible = true;
            }
            else
            {
                lblerror8.Visible = false;
            }
        }

        private void txtgender_Leave(object sender, EventArgs e)
        {
            if(txtgender.Text=="")
            {
                lblerror5.Text = "Must Enter Gender";
                lblerror5.Visible = true;
            }
            else
            {
                lblerror5.Visible = false;
            }

            if(txtgender.Text!="Male" && txtgender.Text!="Female" && txtgender.Text!="")
            {
                lblerror5.Text = "Enter Only Male Or Female In This Field";
                lblerror5.Visible = true;
            }
           
        }

        private void txtstudentcollege_Leave(object sender, EventArgs e)
        {
            if (txtstudentcollege.Text == "")
            {
                txtstudentcollege.Text = "Not Submitted";
               
            }
        }

        private void txtstudentbranchorclass_Leave(object sender, EventArgs e)
        {
            if (txtstudentbranchorclass.Text == "")
            {
                txtstudentbranchorclass.Text = "Not Submitted";

            }
        }

        private void txtdivision_Leave(object sender, EventArgs e)
        {
            if (txtdivision.Text == "")
            {
                txtdivision.Text = "Not Submitted";

            }
        }

        private void txtcollegeidorrollno_Leave(object sender, EventArgs e)
        {
            if (txtcollegeidorrollno.Text == "")
            {
                txtcollegeidorrollno.Text = "Not Submitted";

            }
        }

        private void txtbirthdate_Leave(object sender, EventArgs e)
        {
            if (txtbirthdate.Text == "")
            {
                txtbirthdate.Text = "Not Submitted";

            }
        }

        private void txtcast_Leave(object sender, EventArgs e)
        {
            if (txtcast.Text == "")
            {
                txtcast.Text = "Not Submitted";

            }
        }

        private void txtstudentsubcast_Leave(object sender, EventArgs e)
        {
            if (txtstudentsubcast.Text == "")
            {
                txtstudentsubcast.Text = "Not Submitted";

            }
        }

        private void txtstudentaddress_Leave(object sender, EventArgs e)
        {
            if (txtstudentaddress.Text == "")
            {
                txtstudentaddress.Text = "Not Submitted";

            }
        }

        private void txtstudentpincode_Leave(object sender, EventArgs e)
        {
            if (txtstudentpincode.Text == "")
            {
                txtstudentpincode.Text = "Not Submitted";

            }
        }

        private void txtstudentphysical_Leave(object sender, EventArgs e)
        {
            if (txtstudentphysical.Text == "")
            {
                txtstudentphysical.Text = "Not Submitted";

            }
        }

        private void txtstudentblood_Leave(object sender, EventArgs e)
        {
            if (txtstudentblood.Text == "")
            {
                txtstudentblood.Text = "Not Submitted";

            }
        }

        private void btnstudentdetails_Click(object sender, EventArgs e)
        {
            var studentinfo = new Student_Information();
            studentinfo.Show();
            this.Dispose();

        }

        private void btncollectfee_Click(object sender, EventArgs e)
        {
            year = cbyear.Text;
            var feesform = new RegularStudentFeesCollect();
            feesform.Show();
        
        }

        private void btnusersetting_Click(object sender, EventArgs e)
        {
            var usersettingform = new Usersettings();
            usersettingform.Show();
            this.Dispose();
        }

        private void pbphoto_Click(object sender, EventArgs e)
        {
            var webcamform = new Webcamera();
            webcamform.Show();
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Hostelcodesource.webcam.imagepat != "")
            {
                this.pbphoto.BackgroundImage = Image.FromFile(Hostelcodesource.webcam.imagepat);
                btnconfirm.Visible = true;
                
            }
        }

        private void btnconfirm_Click(object sender, EventArgs e)
        {
            image = ImageToByte(pbphoto.BackgroundImage);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cn.Open();
            cmd.CommandText = "update StudentDetails set Image=@p1 where Id="+ txtstudentid.Text +"";
            SqlParameter para1 = new SqlParameter("p1", SqlDbType.Image);
            para1.Value = image;
            cmd.Parameters.Add(para1);
            cmd.ExecuteNonQuery();

            Hostelcodesource.webcam.imagepat = "";
            btnconfirm.Visible = false;
            SoundPlayer sound = new SoundPlayer(@"c:\Windows\Media\chimes.wav");
            sound.Play();
            MessageBox.Show("Student Image Change Succesfully ","Image Updated",MessageBoxButtons.OK);
        }

        private void minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void cbyear_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbyear.Text != "")
                {
                    SqlDataAdapter da3 = new SqlDataAdapter("select TotalFees,RemainingFees from StudentYearFees where StudentId='" + txtstudentid.Text + "' and Year='" + cbyear.Text + "'", cn);
                    DataSet ds3 = new DataSet();
                    da3.Fill(ds3);
                    txtcurrentfees.Text = ds3.Tables[0].Rows[0][0].ToString();
                    txtremaingfees.Text = ds3.Tables[0].Rows[0][1].ToString();

                    if(txtremaingfees.Text == "0.00")
                    {
                        btncollectfee.Enabled = false;
                    }
                    else
                    {
                        btncollectfee.Enabled = true;
                    }
                }

               
            }
           catch
            {

            }
           
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

