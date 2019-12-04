/*Devloper: Manthan Dineshbhai Patel
 Email:manthanpl93@live.com
If any C# Devloper is confuced in any Modules so you will contect me on My Email Id
*/
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
using System.Drawing.Imaging;
using System.IO;

namespace Hostel_Management_System
{
    public partial class Registration : Form
    {
     
        public static string Studentname;
        public static string Gender;
        public static string BirthDate;
        public static string Studentmobilenumber;
        public static string Fathermobilenumber;
        public static string Email;
        public static string College;
        public static string Branchorclass;
        public static string Division;
        public static string Idorrollno;
        public static string cast;
        public static string subcast;
        public static string Address;
        public static string Pincode;
        public static string City;
        public static string State;
        public static string Nationality;
        public static string Physical;
        public static string Bloodgroup;
        public static string year;
        public static string Admission;
        public static byte[] image;
        SqlConnection cn = new SqlConnection(Hostelcodesource.database.cs);
       public static int imgcheck = 0;
      
        public Registration()
        {
            InitializeComponent();
        }
        /* ********************************Section 1:panelmenu ************************************************/


        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));

        }

        private void DeleteFilesFromDirectory(string directoryPath)
{
    DirectoryInfo d = new DirectoryInfo(directoryPath);
    foreach (FileInfo fi in d.GetFiles())
    {
       fi.Delete();
    }
    foreach (DirectoryInfo di in d.GetDirectories())
    {
        DeleteFilesFromDirectory(di.FullName);
        di.Delete();
    }

}



        private void btnstudentdetails_Click(object sender, EventArgs e)
        {
            /* Module 1:
             * This  Module Open Student_Information form */
            
            var studentinfo = new Student_Information();
            studentinfo.Show();
            this.Hide();

            /* End-Module 1 */
        }

       


        private void btnroomdetails_Click(object sender, EventArgs e)
        {
            /* Module 2:
             * This  Module Open RoomDetails form */
            var roomdetailsform = new RoomDetails();
            roomdetailsform.Show();
            this.Hide();
            

            /* End-Module 2 */
        }

        private void btnmenu_Click(object sender, EventArgs e)
        {
            /* Module 3:
             * This  Module Open Homepage Form */
            var homepageform = new Homepage();
            homepageform.Show();
            this.Hide();
            /* End-Module 3 */
        }

        private void btnfeesdetails_Click(object sender, EventArgs e)
        {
            /* Module 4:
             * This  Module Open Fees_Details form */
            var feesdataform = new Fees_Details();
            feesdataform.Show();
            this.Hide();
            /* End-Module 4 */
        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            /* Module 5:
            * This  Module Minimize the form */
            this.WindowState = FormWindowState.Minimized;

            /* End-Module 5 */
        }
        private void close_Click(object sender, EventArgs e)
        {
            /* Module 6:
            * This  Module Close the application*/

            Application.Exit();
            
            /* End-Module 6 */
        }

        private void btnsignout_Click(object sender, EventArgs e)
        {
            /* Module 7:
           * This  Module Singout the application and redirect on Login Form*/

            var loginform = new Login();
            loginform.Show();
            this.Dispose();

            /* End-Module 7 */
        }
        /* *******************************End-Section 1:panelmenu********************************** */




        /* ********************************Section 2:Main Form ************************************************/
       
        private void txtstudentname_KeyPress(object sender, KeyPressEventArgs e)
        {
            /* Module 1:
           * This  Module Prevented User to unneccesarry keywords in Student name textbox */
            
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '!' || e.KeyChar == '~' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '^' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '_' || e.KeyChar == '-' || e.KeyChar == '+' || e.KeyChar == '=' || e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '{' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '"' || e.KeyChar == '.' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '`' || e.KeyChar == '!' || e.KeyChar == '~' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '^' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '_' || e.KeyChar == '-' || e.KeyChar == '+' || e.KeyChar == '=' || e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '{' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '"' || e.KeyChar == '.' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '`' || e.KeyChar == 39)
            {

                e.Handled = true;
            }

        }

        private void btndone_Click(object sender, EventArgs e)
        {

            try
            {
              
            txtstudentname_Leave(sender, e);
            txtstudentphone_Leave(sender, e);
            txtfatherphone_Leave(sender, e);
            textBox1_Leave(sender, e);
            cbdistrict_Leave(sender, e);
            cbstate_Leave(sender, e);
            cbnationality_Leave(sender, e);

            if (lblerror1.Visible == false && lblerror2.Visible == false && lblerror3.Visible == false && lblerror4.Visible == false && lblerror5.Visible == false && lblerror6.Visible == false && lblerror7.Visible == false && lblerror8.Visible == false)
            {
         
                Studentname = txtstudentname.Text;
                if (rbfemale.Checked==true)
                {
                    Gender = rbmale.Text;
                }
                else
                {
                    Gender = rbfemale.Text;
                }
                BirthDate = dob.Text;
               
               if (txtstudentemail.Text=="")
               {
                   Email = "Not Submitted";
               }
               else
               {
                   Email = txtstudentemail.Text;
               }
                if(cbcollege.Text=="")
                {
                    College = "Not Submitted";
                }
                else
                {
                    College = cbcollege.Text;
                }
                
                if (cbbranch.Text=="")
                {
                    Branchorclass = "Not Submitted";
                }
                else
                {
                    Branchorclass = cbbranch.Text;
                }

                if(cbdivision.Text=="")
                {
                    Division = "Not Submitted";
                }
               else
                {
                    Division = cbdivision.Text;
                }

                if(TXTROLLNO.Text=="")
                {
                    Idorrollno = "0";
                }
                else
                {
                    Idorrollno = TXTROLLNO.Text; ;
                }

                if (cbcast.Text=="")
                {
                    cast = "Not Submitted";
                }
                else
                {
                    cast = cbcast.Text;
                }

                if(cbsubcast.Text=="")
                {
                    subcast = "Not Submitted";
                }
                else
                {
                    subcast = cbsubcast.Text;
                }

                if (txtaddress.Text=="")
                {
                    Address = "Not Submitted";
                }
                else
                {
                    Address = txtaddress.Text;
                }

                if (txtpincode.Text=="")
                {
                    Pincode = "0";
                }
                else
                {
                    Pincode = txtpincode.Text;
                }

                if(cbdistrict.Text=="")
                {
                    City = "Not Submitted";

                }
                else
                {
                    City = cbdistrict.Text;
                }

                if(cbstate.Text=="")
                {
                    State = "Not Submitted";
                }

                else
                {
                    State = cbstate.Text;
                }

                if(cbnationality.Text=="")
                {
                    Nationality = "Not Submitted";
                }
                else
                {
                    Nationality = cbnationality.Text;
                }

                if(txtphysical.Text=="")
                {
                    Physical = "Not Submitted";
                }
                else
                {
                    Physical = txtphysical.Text;
                }

                if(cbBlood.Text=="")
                {
                    Bloodgroup = "Not Submitted";
                }
                else
                {
                    Bloodgroup = cbBlood.Text;
                }
                if(txtstudentphone.Text=="")
                {
                    Studentmobilenumber = "0";
                }

                else
                {
                    Studentmobilenumber = txtstudentphone.Text;
                   
                }

                
                if(imgcheck==1)
                {
                    image = ImageToByte(pbphoto.BackgroundImage);

                    Hostelcodesource.webcam.imagepat = "";
                }
               

                if(txtfatherphone.Text=="")
                {
                    Fathermobilenumber = "0";
                }
                else
                {
                    Fathermobilenumber = txtfatherphone.Text;
                }
                Admission = admissiondate.Text;
                year = cbyear.Text;
                var roomselectionform = new Room_Selection();
                roomselectionform.Show();
                this.Hide();
                DeleteFilesFromDirectory(@Directory.GetCurrentDirectory() + "//Images//");


            }
            else
            {
                MessageBox.Show("Must Enter Some Input");
            }
           
                }
            catch
            {
               
            }
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            var popup = new Popup();
            popup.Show();
            this.Enabled = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

      
        private void Registration_Load(object sender, EventArgs e)
        {
            Hostelcodesource.webcam.imagepat = "";

            double fade;
            for (fade = 0.0; fade < 1.1; fade += 0.1)
            {
                this.Opacity = fade;
                this.Refresh();
                Thread.Sleep(30);

            }

            SqlDataAdapter da3 = new SqlDataAdapter("select CollegeOrSchool from StudentDetails where CollegeOrSchool<>'Not Submitted' group by CollegeOrSchool", cn);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            cbcollege.DataSource = ds3.Tables[0];
            cbcollege.DisplayMember = "CollegeOrSchool";

            SqlDataAdapter da4 = new SqlDataAdapter("select BranchOrClass from StudentDetails where BranchOrClass<>'Not Submitted' group by BranchOrClass", cn);
            DataSet ds4 = new DataSet();
            da4.Fill(ds4);

            cbbranch.DataSource = ds4.Tables[0];
            cbbranch.DisplayMember = "BranchOrClass";

            SqlDataAdapter da5 = new SqlDataAdapter("select State from StudentDetails where State<>'Not Submitted' group by State", cn);
            DataSet ds5 = new DataSet();
            da5.Fill(ds5);
            cbstate.DataSource = ds5.Tables[0];
            cbstate.DisplayMember = "State";


            SqlDataAdapter da6 = new SqlDataAdapter("select City from StudentDetails where City<>'Not Submitted' group by City", cn);
            DataSet ds6 = new DataSet();
            da6.Fill(ds6);
            cbdistrict.DataSource = ds6.Tables[0];
            cbdistrict.DisplayMember = "City";

            SqlDataAdapter da7 = new SqlDataAdapter("select SubCast from StudentDetails where SubCast<>'Not Submitted' group by SubCast", cn);
            DataSet ds7 = new DataSet();
            da7.Fill(ds7);
            cbsubcast.DataSource = ds7.Tables[0];
            cbsubcast.DisplayMember = "SubCast";

            SqlDataAdapter da8 = new SqlDataAdapter("select Division from StudentDetails where Division<>'Not Submitted' group by Division", cn);
            DataSet ds8 = new DataSet();
            da8.Fill(ds8);
            cbdivision.DataSource = ds8.Tables[0];
            cbdivision.DisplayMember = "Division";


            SqlDataAdapter da9 = new SqlDataAdapter("select Cast from StudentDetails where Cast<>'Not Submitted' group by Cast", cn);
            DataSet ds9 = new DataSet();
            da9.Fill(ds9);
            cbcast.DataSource = ds9.Tables[0];
            cbcast.DisplayMember = "Cast";

            SqlDataAdapter da10 = new SqlDataAdapter("select Nationality from StudentDetails where Nationality<>'Not Submitted' group by Nationality", cn);
            DataSet ds10 = new DataSet();
            da10.Fill(ds10);
            cbnationality.DataSource = ds10.Tables[0];
            cbnationality.DisplayMember = "Nationality";


            SqlDataAdapter da11 = new SqlDataAdapter("select Blood from StudentDetails where Blood<>'Not Submitted' group by Blood", cn);
            DataSet ds11 = new DataSet();
            da11.Fill(ds11);
            cbBlood.DataSource = ds11.Tables[0];
            cbBlood.DisplayMember = "Blood";



            SqlDataAdapter da = new SqlDataAdapter("select Year from FeesDetail group by Year", cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cbyear.DataSource = ds.Tables[0];
            cbyear.DisplayMember = "Year";

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
            cmd2.CommandText = "select Year from FeesDetail where Id="+currentId +"";
            string currentyear = cmd2.ExecuteScalar().ToString();
            cbyear.Text = currentyear;
            cn.Close();
            cmd2.Dispose();
        }

        private void txtstudentname_Leave(object sender, EventArgs e)
        {
            if (txtstudentname.Text=="")
            {
                lblerror1.Visible = true;
            }
            else
            {
                lblerror1.Visible =false;
            }
        }

        private void rbmale_Leave(object sender, EventArgs e)
        {
            if (rbfemale.Checked==true)
            {
                lblerror5.Visible = true;
            }
            else
            {
                lblerror5.Visible = false;
            }
        }

        private void txtstudentphone_Leave(object sender, EventArgs e)
        {
            if (txtstudentphone.Text != "")
            {
                if (txtstudentphone.TextLength != 10 )
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
        }

        private void txtfatherphone_Leave(object sender, EventArgs e)
        {

            if (txtstudentphone.Text != "" && txtfatherphone.Text != "")
            {
                if (txtstudentphone.Text == txtfatherphone.Text)
                {
                    lblerror3.Visible = true;
                }
                else
                {
                    lblerror3.Visible = false;
                }

            }


             if (txtfatherphone.Text != "")
            {
                if (txtfatherphone.TextLength != 10)
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
                 lblerror3.Visible = false;
             }
       
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (txtstudentemail.Text!="")
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
            }

        private void rbfemale_Leave(object sender, EventArgs e)
        {
            if (rbmale.Checked == true)
            {
                lblerror5.Visible = true;
            }
            else
            {
                lblerror5.Visible = false;
            }
        }

        private void cbdistrict_Leave(object sender, EventArgs e)
        {
            if (cbdistrict.Text=="")
            {
                lblerror6.Visible = true;
            }
            else
            {
                lblerror6.Visible = false;
            }
        }

        private void cbstate_Leave(object sender, EventArgs e)
        {
            if (cbstate.Text=="")
            {
                lblerror7.Visible = true;
            }
            else
            {
                lblerror7.Visible = false;
            }
        }

        private void cbnationality_Leave(object sender, EventArgs e)
        {
            if (cbnationality.Text=="")
            {
                lblerror8.Visible = true;
            }
            else
            {
                lblerror8.Visible = false;
            }
        }

        private void txtstudentphone_KeyPress(object sender, KeyPressEventArgs e)
        {


            if (char.IsLetter(e.KeyChar) || e.KeyChar == '!' || e.KeyChar == '~' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '^' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '_' || e.KeyChar == '-' || e.KeyChar == '+' || e.KeyChar == '=' || e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '{' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '"' || e.KeyChar == '.' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '`' || e.KeyChar == '!' || e.KeyChar == '~' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '^' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '_' || e.KeyChar == '-' || e.KeyChar == '+' || e.KeyChar == '=' || e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '{' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '"' || e.KeyChar == '.' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '`' || e.KeyChar == 39 || e.KeyChar == 32)
            {

                e.Handled = true;
            }
        }

        private void txtfatherphone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || e.KeyChar == '!' || e.KeyChar == '~' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '^' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '_' || e.KeyChar == '-' || e.KeyChar == '+' || e.KeyChar == '=' || e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '{' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '"' || e.KeyChar == '.' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '`' || e.KeyChar == '!' || e.KeyChar == '~' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '^' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '_' || e.KeyChar == '-' || e.KeyChar == '+' || e.KeyChar == '=' || e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '{' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '"' || e.KeyChar == '.' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '`' || e.KeyChar == 39 || e.KeyChar==32)
            {

                e.Handled = true;
            }
        }

       

        private void cbcollege_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '!' || e.KeyChar == '~' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '^' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '_' || e.KeyChar == '-' || e.KeyChar == '+' || e.KeyChar == '=' || e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '{' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '"' || e.KeyChar == '.' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '`' || e.KeyChar == '!' || e.KeyChar == '~' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '^' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '_' || e.KeyChar == '-' || e.KeyChar == '+' || e.KeyChar == '=' || e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '{' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '"' || e.KeyChar == '.' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '`' || e.KeyChar == 39)
            {

                e.Handled = true;
            }
        }

        private void cbbranch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '!' || e.KeyChar == '~' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '^' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '_' || e.KeyChar == '-' || e.KeyChar == '+' || e.KeyChar == '=' || e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '{' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '"' || e.KeyChar == '.' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '`' || e.KeyChar == '!' || e.KeyChar == '~' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '^' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '_' || e.KeyChar == '-' || e.KeyChar == '+' || e.KeyChar == '=' || e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '{' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '"' || e.KeyChar == '.' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '`' || e.KeyChar == 39)
            {

                e.Handled = true;
            }
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '!' || e.KeyChar == '~' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '^' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '_' || e.KeyChar == '-' || e.KeyChar == '+' || e.KeyChar == '=' || e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '{' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '"' || e.KeyChar == '.' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '`' || e.KeyChar == '!' || e.KeyChar == '~' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '^' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '_' || e.KeyChar == '-' || e.KeyChar == '+' || e.KeyChar == '=' || e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '{' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '"' || e.KeyChar == '.' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '`' || e.KeyChar == 39)
            {

                e.Handled = true;
            }
        }

        private void cbcast_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '!' || e.KeyChar == '~' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '^' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '_' || e.KeyChar == '-' || e.KeyChar == '+' || e.KeyChar == '=' || e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '{' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '"' || e.KeyChar == '.' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '`' || e.KeyChar == '!' || e.KeyChar == '~' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '^' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '_' || e.KeyChar == '-' || e.KeyChar == '+' || e.KeyChar == '=' || e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '{' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '"' || e.KeyChar == '.' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '`' || e.KeyChar == 39)
            {

                e.Handled = true;
            }
        }

        private void cbsubcast_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '!' || e.KeyChar == '~' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '^' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '_' || e.KeyChar == '-' || e.KeyChar == '+' || e.KeyChar == '=' || e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '{' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '"' || e.KeyChar == '.' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '`' || e.KeyChar == '!' || e.KeyChar == '~' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '^' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '_' || e.KeyChar == '-' || e.KeyChar == '+' || e.KeyChar == '=' || e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '{' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '"' || e.KeyChar == '.' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '`' || e.KeyChar == 39)
            {

                e.Handled = true;
            }
        }

        private void cbdistrict_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '!' || e.KeyChar == '~' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '^' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '_' || e.KeyChar == '-' || e.KeyChar == '+' || e.KeyChar == '=' || e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '{' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '"' || e.KeyChar == '.' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '`' || e.KeyChar == '!' || e.KeyChar == '~' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '^' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '_' || e.KeyChar == '-' || e.KeyChar == '+' || e.KeyChar == '=' || e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '{' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '"' || e.KeyChar == '.' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '`' || e.KeyChar == 39)
            {

                e.Handled = true;
            }
        }

        private void cbstate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '!' || e.KeyChar == '~' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '^' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '_' || e.KeyChar == '-' || e.KeyChar == '+' || e.KeyChar == '=' || e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '{' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '"' || e.KeyChar == '.' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '`' || e.KeyChar == '!' || e.KeyChar == '~' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '^' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '_' || e.KeyChar == '-' || e.KeyChar == '+' || e.KeyChar == '=' || e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '{' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '"' || e.KeyChar == '.' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '`' || e.KeyChar == 39)
            {

                e.Handled = true;
            }
        }

        private void cbnationality_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '!' || e.KeyChar == '~' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '^' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '_' || e.KeyChar == '-' || e.KeyChar == '+' || e.KeyChar == '=' || e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '{' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '"' || e.KeyChar == '.' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '`' || e.KeyChar == '!' || e.KeyChar == '~' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '^' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '_' || e.KeyChar == '-' || e.KeyChar == '+' || e.KeyChar == '=' || e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '{' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '"' || e.KeyChar == '.' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '`' || e.KeyChar == 39)
            {

                e.Handled = true;
            }
        }

        private void physical_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '!' || e.KeyChar == '~' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '^' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '_' || e.KeyChar == '-' || e.KeyChar == '+' || e.KeyChar == '=' || e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '{' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '"' || e.KeyChar == '.' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '`' || e.KeyChar == '!' || e.KeyChar == '~' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '^' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '_' || e.KeyChar == '-' || e.KeyChar == '+' || e.KeyChar == '=' || e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '{' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '"' || e.KeyChar == '.' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '`' || e.KeyChar == 39)
            {

                e.Handled = true;
            }
        }

        private void Blood_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '!' || e.KeyChar == '~' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '^' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '_' || e.KeyChar == '=' || e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '{' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '"' || e.KeyChar == '.' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '`' || e.KeyChar == '!' || e.KeyChar == '~' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '^' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '_' || e.KeyChar == '=' || e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '{' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '"' || e.KeyChar == '.' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '`' || e.KeyChar == 39)
            {

                e.Handled = true;
            }
        }

        private void TXTROLLNO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || e.KeyChar == '!' || e.KeyChar == '~' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '^' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '_' || e.KeyChar == '-' || e.KeyChar == '+' || e.KeyChar == '=' || e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '{' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '"' || e.KeyChar == '.' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '`' || e.KeyChar == '!' || e.KeyChar == '~' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '^' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '_' || e.KeyChar == '-' || e.KeyChar == '+' || e.KeyChar == '=' || e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '{' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '"' || e.KeyChar == '.' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '`' || e.KeyChar == 39 || e.KeyChar == 32)
            {

                e.Handled = true;
            }
        }

        private void txtpincode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || e.KeyChar == '!' || e.KeyChar == '~' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '^' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '_' || e.KeyChar == '-' || e.KeyChar == '+' || e.KeyChar == '=' || e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '{' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '"' || e.KeyChar == '.' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '`' || e.KeyChar == '!' || e.KeyChar == '~' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '^' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '_' || e.KeyChar == '-' || e.KeyChar == '+' || e.KeyChar == '=' || e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '{' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '"' || e.KeyChar == '.' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '`' || e.KeyChar == 39 || e.KeyChar == 32)
            {

                e.Handled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(Hostelcodesource.webcam.imagepat!="")
            {
                this.pbphoto.BackgroundImage = Image.FromFile(Hostelcodesource.webcam.imagepat);
         
                imgcheck = 1;
            }
        }

        private void pbphoto_Click(object sender, EventArgs e)
        {
            var webcam = new Webcamera();
            webcam.Show();
            pbphoto.BackgroundImage = null;
            pbphoto.Image = null;
        }

        private void btnusersetting_Click(object sender, EventArgs e)
        {
            var usersettingform = new Usersettings();
            usersettingform.Show();
            this.Dispose();
        }

       

       
        
   
       
           
    }
}
