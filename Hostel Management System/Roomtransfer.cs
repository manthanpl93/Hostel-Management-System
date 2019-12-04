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
    

    public partial class Roomtransfer : Form
    {
        SqlConnection cn = new SqlConnection(Hostelcodesource.database.cs);
        public Roomtransfer()
        {
            InitializeComponent();
        }


        //1st Student
        string firstidenity;
        string firstRoom;
        string firstBuilding;
        string firststudentname;
        string firstCollege;
        string firstBranch;
        string firstdivision;
        string firstidorroll;
        string firstcast;
        string firstsubcast;
        string firstcity;
        string firststate;
        string firstNationality;
        string firstAdmissiondate;
        string firstid;



        //2nd Student
        string secondidentity;
        string SecondRoom;
        string SecondBuilding;
        string Secondstudentname;
        string SecondCollege;
        string SecondBranch;
        string Seconddivision;
        string Secondidorroll;
        string Secondcast;
        string Secondsubcast;
        string Secondcity;
        string Secondstate;
        string SecondNationality;
        string SecondAdmissiondate;
        string Secondid;

        //1st Student

        string room;
        string building;
        string roomid;

        private void RoomExchange(string Name,string CurrentRoom,string ExchengedRoom,string id)
        {
            cn.Close();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection=cn;
            cn.Open();
            cmd.CommandText = "insert into RoomExchange values ('"+ Name +"','"+ CurrentRoom +"','"+ ExchengedRoom +"',@p1,"+ id +")";
            SqlParameter para1 = new SqlParameter("@p1",SqlDbType.Date);
            para1.Value = DateTime.Today.Date;
            cmd.Parameters.Add(para1);
            cmd.ExecuteNonQuery();
            cn.Close();


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

        private void Roomtransfer_Load(object sender, EventArgs e)
        {
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
            cbbuilding.DataSource = ds.Tables[0];
            cbbuilding.DisplayMember = "Building";

            SqlDataAdapter da2 = new SqlDataAdapter("select Building from HostelRoomDetails group by Building", cn);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            cbbuilding2.DataSource = ds2.Tables[0];
            cbbuilding2.DisplayMember = "Building";

            SqlDataAdapter da3 = new SqlDataAdapter("select Building from HostelRoomDetails group by Building", cn);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            cbs2sbuilding1.DataSource = ds3.Tables[0];
            cbs2sbuilding1.DisplayMember = "Building";


            SqlDataAdapter da4 = new SqlDataAdapter("select Building from HostelRoomDetails group by Building", cn);
            DataSet ds4 = new DataSet();
            da4.Fill(ds4);
            cbs2sbuilding2.DataSource = ds4.Tables[0];
            cbs2sbuilding2.DisplayMember = "Building";


        }

      

      
     

        private void btnmenu_Click(object sender, EventArgs e)
        {
            var homepageform = new Homepage();
            homepageform.Show();
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

        private void btnfeesdetails_Click(object sender, EventArgs e)
        {
            var feesdataform = new Fees_Details();
            feesdataform.Show();
            this.Hide();
        }

        private void btnstudentdetails_Click(object sender, EventArgs e)
        {
            var studentinfo = new Student_Information();
            studentinfo.Show();
            this.Dispose();
        }

        private void txtroomno_KeyDown(object sender, KeyEventArgs e)
        {
         

           
        }

       

    
        private void panel1studenttofreeroom_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtroomno_KeyDown_1(object sender, KeyEventArgs e)
        {
            if(txtroomno.Text!="")
            {
                if(e.KeyCode==Keys.Enter)
                {
                    SqlDataAdapter da = new SqlDataAdapter("select * from HostelRoomDetails where RoomNumber='" + txtroomno.Text + "' and Building='" + cbbuilding.Text + "' and StudentName!='Free Space'", cn);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dgstudentview.DataSource = ds.Tables[0];

                    if(ds.Tables[0].Rows.Count==0)
                    {
                        MessageBox.Show("No Room Found","Hostel Management Advance System ",MessageBoxButtons.OK);
                    }


                }
            }
        }

        private void cbbuilding2_TextChanged(object sender, EventArgs e)
        {
            if(cbbuilding2.Text!="")
            {
                SqlDataAdapter da = new SqlDataAdapter("select Building,RoomNumber from HostelRoomDetails where StudentName='Free Space' and Building='" + cbbuilding2.Text + "' group by Building,RoomNumber order by RoomNumber", cn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dgspaceview.DataSource = ds.Tables[0];

                for(int i=0;i<dgspaceview.Rows.Count-1;i++)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cn.Open();
                    cmd.CommandText = "select count(*) from HostelRoomDetails where Building='" + dgspaceview.Rows[i].Cells[0].Value + "' and RoomNumber='" + dgspaceview.Rows[i].Cells[1].Value + "' and StudentName='Free Space'";
                    string space = cmd.ExecuteScalar().ToString();
                    dgspaceview.Rows[i].Cells[2].Value = space;
                    cn.Close();

                }


            }
        }

        private void txtroomno2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtroomno2_KeyDown(object sender, KeyEventArgs e)
        {
            if(txtroomno2.Text!="")
            {
                if(e.KeyCode==Keys.Enter)
                {
                    SqlDataAdapter da = new SqlDataAdapter("select Building,RoomNumber from HostelRoomDetails where StudentName='Free Space' and Building='" + cbbuilding2.Text + "' and RoomNumber='"+ txtroomno2.Text +"' group by Building,RoomNumber order by RoomNumber", cn);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dgspaceview.DataSource = ds.Tables[0];

                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show("No Room Found", "Hostel Management Advance System ", MessageBoxButtons.OK);
                    }

                    for (int i = 0; i < dgspaceview.Rows.Count - 1; i++)
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = cn;
                        cn.Open();
                        cmd.CommandText = "select count(*) from HostelRoomDetails where Building='" + dgspaceview.Rows[i].Cells[0].Value + "' and RoomNumber='" + dgspaceview.Rows[i].Cells[1].Value + "' and StudentName='Free Space'";
                        string space = cmd.ExecuteScalar().ToString();
                        dgspaceview.Rows[i].Cells[2].Value = space;
                        cn.Close();

                    }

                }
            }

        }

        private void dgstudentview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
         
            if(dgstudentview.Rows.Count!=1)
            {
                dgstudentview.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Black;
                dgstudentview.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;

                SqlDataAdapter da = new SqlDataAdapter("select * from HostelRoomDetails where StudentId="+ dgstudentview.Rows[e.RowIndex].Cells[3].Value.ToString() +"", cn);
                DataSet ds = new DataSet();
                da.Fill(ds);

                firstidenity = ds.Tables[0].Rows[0]["RoomID"].ToString();
                firstRoom = ds.Tables[0].Rows[0]["RoomNumber"].ToString();
                firstBuilding = ds.Tables[0].Rows[0]["Building"].ToString();
                firststudentname = ds.Tables[0].Rows[0]["StudentName"].ToString();
                firstCollege = ds.Tables[0].Rows[0]["CollegeOrSchool"].ToString();
                firstBranch = ds.Tables[0].Rows[0]["BranchOrClass"].ToString();
                firstdivision = ds.Tables[0].Rows[0]["Division"].ToString();
                firstidorroll = ds.Tables[0].Rows[0]["IDOrRollNumber"].ToString();
                firstcast = ds.Tables[0].Rows[0]["Cast"].ToString();
                firstsubcast = ds.Tables[0].Rows[0]["SubCast"].ToString();
                firstcity = ds.Tables[0].Rows[0]["City"].ToString();
                firststate = ds.Tables[0].Rows[0]["State"].ToString();
                firstNationality = ds.Tables[0].Rows[0]["Nationality"].ToString();
                firstAdmissiondate = ds.Tables[0].Rows[0]["AdmissionDate"].ToString();
                firstid = ds.Tables[0].Rows[0]["StudentId"].ToString();
                
                for(int i=0;i<dgstudentview.Rows.Count-1;i++)
                {
                    if(i!=e.RowIndex)
                    {
                        dgstudentview.Rows[i].DefaultCellStyle.BackColor = Color.White;
                        dgstudentview.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
            }
        }

        private void dgspaceview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgspaceview.Rows.Count != 1)
            {
                dgspaceview.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Black;
                dgspaceview.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cn.Open();
                cmd.CommandText = "select min(RoomID) from HostelRoomDetails where StudentName='Free Space' and Building='" + dgspaceview.Rows[e.RowIndex].Cells[0].Value.ToString() + "' and RoomNumber='" + dgspaceview.Rows[e.RowIndex].Cells[1].Value.ToString() + "'";
                string roomid1=cmd.ExecuteScalar().ToString();
                cn.Close();
                room = dgspaceview.Rows[e.RowIndex].Cells[1].Value.ToString();
                building = dgspaceview.Rows[e.RowIndex].Cells[0].Value.ToString();
                roomid = roomid1;

                for (int i = 0; i < dgspaceview.Rows.Count - 1; i++)
                {
                    if (i != e.RowIndex)
                    {
                        dgspaceview.Rows[i].DefaultCellStyle.BackColor = Color.White;
                        dgspaceview.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
            }
        }

        private void btntransfer_Click(object sender, EventArgs e)
        {
            if (btnstudenttofreeroom.Enabled == false)
            {

                if (cbs2sbuilding1.Text == cbs2sbuilding2.Text && txts2sroom1.Text == txts2sroom2.Text)
                {
                   MessageBox.Show("Wrong Input - Same Room Selection","Hostel Manegemenet Syatem",MessageBoxButtons.OK);
                   goto here;
                }
                    if (firststudentname != null && room != null)
                    {
                        DialogResult dr = MessageBox.Show("Are You Sure You Want To Transfer " + firststudentname + " From " + firstBuilding + "-" + firstRoom + " To " + building + "-" + room, "", MessageBoxButtons.YesNo);

                        if (firstidorroll == "")
                        {
                            firstidorroll = "NULL";
                        }


                        if (dr == DialogResult.Yes)
                        {


                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = cn;
                            cn.Open();
                            cmd.CommandText = "update HostelRoomDetails set StudentName='" + firststudentname + "',CollegeOrSchool='" + firstCollege + "',BranchOrClass='" + firstBranch + "',Division='" + firstdivision + "',IDOrRollNumber=" + firstidorroll + ",Cast='" + firstcast + "',SubCast='" + firstsubcast + "',City='" + firstcity + "',State='" + firststate + "',Nationality='" + firstNationality + "',AdmissionDate=@p1,StudentId=" + firstid + " where RoomNumber=" + room + " and Building='" + building + "' and RoomID=" + roomid + "";
                            SqlParameter para1 = new SqlParameter("@p1", SqlDbType.Date);
                            para1.Value = firstAdmissiondate.Substring(0, 10);
                            cmd.Parameters.Add(para1);
                            cmd.ExecuteNonQuery();


                            cmd.CommandText = "update HostelRoomDetails set StudentName='Free Space',CollegeOrSchool=NULL,BranchOrClass=NULL,Division=NULL,IDOrRollNumber=NULL,Cast=NULL,SubCast=NULL,City=NULL,State=NULL,Nationality=NULL,AdmissionDate=NULL,StudentId=NULL where RoomNumber=" + firstRoom + " and Building='" + firstBuilding + "' and RoomID=" + firstidenity + ""; ;
                            cmd.ExecuteNonQuery();
                            RoomExchange(firststudentname, firstBuilding + "-" + firstRoom, building + "-" + room, firstid);


                            MessageBox.Show("Student Successfully Transfered To " + building + "-" + room, "", MessageBoxButtons.OK);

                            cn.Close();

                            firstidenity = null;
                            firstRoom = null;
                            firstBuilding = null;
                            firststudentname = null;
                            firstCollege = null;
                            firstBranch = null;
                            firstdivision = null;
                            firstidorroll = null;
                            firstcast = null;
                            firstsubcast = null;
                            firstcity = null;
                            firststate = null;
                            firstNationality = null;
                            firstAdmissiondate = null;
                            firstid = null;




                        }

                    }
                    else
                    {
                        MessageBox.Show("Must Select Some Input", "Hostel Management Advance System", MessageBoxButtons.OK);
                    }
                }


                if (btnstudenttostudent.Enabled == false)
                {
                    if (cbs2sbuilding1.Text == cbs2sbuilding2.Text && txts2sroom1.Text == txts2sroom2.Text)
                    {
                        MessageBox.Show("Wrong Input - Same Room Selection", "Hostel Manegemenet Syatem", MessageBoxButtons.OK);
                        goto here;
                    }
                    if (firststudentname != null && Secondstudentname != null && dgs2sview1.RowCount != 1 && dgs2sview2.RowCount != 1)
                    {
                        DialogResult dr = MessageBox.Show("Are You Sure You Want To Transfer Room Between " + firststudentname + " To " + Secondstudentname, "", MessageBoxButtons.YesNo);

                        if (firstidorroll == "" && Secondidorroll == "")
                        {
                            firstidorroll = "NULL";
                            Secondidorroll = "NULL";
                        }


                        if (dr == DialogResult.Yes)
                        {


                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = cn;
                            cn.Open();
                            cmd.CommandText = "update HostelRoomDetails set StudentName='" + firststudentname + "',CollegeOrSchool='" + firstCollege + "',BranchOrClass='" + firstBranch + "',Division='" + firstdivision + "',IDOrRollNumber=" + firstidorroll + ",Cast='" + firstcast + "',SubCast='" + firstsubcast + "',City='" + firstcity + "',State='" + firststate + "',Nationality='" + firstNationality + "',AdmissionDate=@p1,StudentId=" + firstid + " where RoomNumber=" + SecondRoom + " and Building='" + SecondBuilding + "' and RoomID=" + secondidentity + "";
                            SqlParameter para1 = new SqlParameter("@p1", SqlDbType.Date);
                            para1.Value = firstAdmissiondate.Substring(0, 10);
                            cmd.Parameters.Add(para1);
                            cmd.ExecuteNonQuery();

                            RoomExchange(firststudentname, firstBuilding + "-" + firstRoom, SecondBuilding + "-" + SecondRoom, firstid);

                            cmd.CommandText = "update HostelRoomDetails set StudentName='" + Secondstudentname + "',CollegeOrSchool='" + SecondCollege + "',BranchOrClass='" + SecondBranch + "',Division='" + Seconddivision + "',IDOrRollNumber=" + Secondidorroll + ",Cast='" + Secondcast + "',SubCast='" + Secondsubcast + "',City='" + Secondcity + "',State='" + Secondstate + "',Nationality='" + SecondNationality + "',AdmissionDate=@p2,StudentId=" + Secondid + " where RoomNumber=" + firstRoom + " and Building='" + firstBuilding + "' and RoomID=" + firstidenity + "";
                            SqlParameter para2 = new SqlParameter("@p2", SqlDbType.Date);
                            para2.Value = SecondAdmissiondate.Substring(0, 10);
                            cmd.Parameters.Add(para2);
                            cmd.ExecuteNonQuery();
                            RoomExchange(Secondstudentname, SecondBuilding + "-" + SecondRoom, firstBuilding + "-" + firstRoom, Secondid);

                            MessageBox.Show("Sucessfully Transfered " + firststudentname + " To " + SecondBuilding + "-" + SecondRoom + " And " + Secondstudentname + " To " + firstBuilding + "-" + firstRoom, "Hostel Management System", MessageBoxButtons.OK);

                            cn.Close();

                            firstidenity = null;
                            firstRoom = null;
                            firstBuilding = null;
                            firststudentname = null;
                            firstCollege = null;
                            firstBranch = null;
                            firstdivision = null;
                            firstidorroll = null;
                            firstcast = null;
                            firstsubcast = null;
                            firstcity = null;
                            firststate = null;
                            firstNationality = null;
                            firstAdmissiondate = null;
                            firstid = null;

                            secondidentity = null;
                            SecondRoom = null;
                            SecondBuilding = null;
                            Secondstudentname = null;
                            SecondCollege = null;
                            SecondBranch = null;
                            Seconddivision = null;
                            Secondidorroll = null;
                            Secondcast = null;
                            Secondsubcast = null;
                            Secondcity = null;
                            Secondstate = null;
                            SecondNationality = null;
                            SecondAdmissiondate = null;
                            Secondid = null;


                        }

                    }
                    else
                    {
                        MessageBox.Show("Must Select Some Input", "Hostel Management Advance System", MessageBoxButtons.OK);
                    }
               
           
            }
            here: ;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtroomno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || e.KeyChar == '!' || e.KeyChar == '~' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '^' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '_' || e.KeyChar == '-' || e.KeyChar == '+' || e.KeyChar == '=' || e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '{' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '"' || e.KeyChar == '.' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '`' || e.KeyChar == '!' || e.KeyChar == '~' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '^' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '_' || e.KeyChar == '-' || e.KeyChar == '+' || e.KeyChar == '=' || e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '{' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '"' || e.KeyChar == '.' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '`' || e.KeyChar == 39 || e.KeyChar == 32)
            {

                e.Handled = true;
            }
        }

        private void txtroomno2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || e.KeyChar == '!' || e.KeyChar == '~' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '^' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '_' || e.KeyChar == '-' || e.KeyChar == '+' || e.KeyChar == '=' || e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '{' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '"' || e.KeyChar == '.' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '`' || e.KeyChar == '!' || e.KeyChar == '~' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '^' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '_' || e.KeyChar == '-' || e.KeyChar == '+' || e.KeyChar == '=' || e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '{' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '"' || e.KeyChar == '.' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '`' || e.KeyChar == 39 || e.KeyChar == 32)
            {

                e.Handled = true;
            }
        }

        private void btnstudenttostudent_Click(object sender, EventArgs e)
        {
            btnstudenttofreeroom.Enabled = true;
            btnstudenttostudent.Enabled = false;
            pnlstudenttostudent.Visible = true;
        }

        private void btnstudenttofreeroom_Click(object sender, EventArgs e)
        {
            btnstudenttofreeroom.Enabled = false;
            btnstudenttostudent.Enabled = true;
            pnlstudenttostudent.Visible = false;
        }

        private void txts2sroom1_KeyDown(object sender, KeyEventArgs e)
        {
            if(txts2sroom1.Text!="")
            {
                if (e.KeyCode == Keys.Enter)
                {


                    SqlDataAdapter da = new SqlDataAdapter("select * from HostelRoomDetails where Building='" + cbs2sbuilding1.Text + "' and RoomNumber='" + txts2sroom1.Text + "' and StudentName!='Free Space'", cn);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dgs2sview1.DataSource = ds.Tables[0];
                    if (ds.Tables[0].Rows.Count ==0)
                    {
                        MessageBox.Show("Room Not Found", "Hostel Management System", MessageBoxButtons.OK);
                    }
                }
            }
           
        }

        private void txts2sroom1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || e.KeyChar == '!' || e.KeyChar == '~' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '^' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '_' || e.KeyChar == '-' || e.KeyChar == '+' || e.KeyChar == '=' || e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '{' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '"' || e.KeyChar == '.' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '`' || e.KeyChar == '!' || e.KeyChar == '~' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '^' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '_' || e.KeyChar == '-' || e.KeyChar == '+' || e.KeyChar == '=' || e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '{' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '"' || e.KeyChar == '.' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '`' || e.KeyChar == 39 || e.KeyChar == 32)
            {

                e.Handled = true;
            }
        
        }

        private void txts2sroom2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || e.KeyChar == '!' || e.KeyChar == '~' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '^' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '_' || e.KeyChar == '-' || e.KeyChar == '+' || e.KeyChar == '=' || e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '{' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '"' || e.KeyChar == '.' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '`' || e.KeyChar == '!' || e.KeyChar == '~' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '^' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '_' || e.KeyChar == '-' || e.KeyChar == '+' || e.KeyChar == '=' || e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '{' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '"' || e.KeyChar == '.' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '`' || e.KeyChar == 39 || e.KeyChar == 32)
            {

                e.Handled = true;
            }
        
        }

        private void txts2sroom2_KeyDown(object sender, KeyEventArgs e)
        {
            if(txts2sroom2.Text!="")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SqlDataAdapter da = new SqlDataAdapter("select * from HostelRoomDetails where Building='" + cbs2sbuilding2.Text + "' and RoomNumber='" + txts2sroom2.Text + "' and StudentName!='Free Space'", cn);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dgs2sview2.DataSource = ds.Tables[0];

                    if(ds.Tables[0].Rows.Count==0)
                    {
                        MessageBox.Show("Room Not Found","Hostel Management System",MessageBoxButtons.OK);
                    }
                    
                }
            }
           
        }

        private void dgs2sview1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgs2sview1.Rows.Count != 1)
            {
                dgs2sview1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Black;
                dgs2sview1.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;

              //  MessageBox.Show(dgs2sview1.Rows[e.RowIndex].Cells[3].Value.ToString());

                SqlDataAdapter da = new SqlDataAdapter("select * from HostelRoomDetails where StudentId=" + dgs2sview1.Rows[e.RowIndex].Cells[3].Value.ToString() + "", cn);
                DataSet ds = new DataSet();
                da.Fill(ds);

                firstidenity = ds.Tables[0].Rows[0]["RoomID"].ToString();
                firstRoom = ds.Tables[0].Rows[0]["RoomNumber"].ToString();
                firstBuilding = ds.Tables[0].Rows[0]["Building"].ToString();
                firststudentname = ds.Tables[0].Rows[0]["StudentName"].ToString();
                firstCollege = ds.Tables[0].Rows[0]["CollegeOrSchool"].ToString();
                firstBranch = ds.Tables[0].Rows[0]["BranchOrClass"].ToString();
                firstdivision = ds.Tables[0].Rows[0]["Division"].ToString();
                firstidorroll = ds.Tables[0].Rows[0]["IDOrRollNumber"].ToString();
                firstcast = ds.Tables[0].Rows[0]["Cast"].ToString();
                firstsubcast = ds.Tables[0].Rows[0]["SubCast"].ToString();
                firstcity = ds.Tables[0].Rows[0]["City"].ToString();
                firststate = ds.Tables[0].Rows[0]["State"].ToString();
                firstNationality = ds.Tables[0].Rows[0]["Nationality"].ToString();
                firstAdmissiondate = ds.Tables[0].Rows[0]["AdmissionDate"].ToString();
                firstid = ds.Tables[0].Rows[0]["StudentId"].ToString();
                
                
                
                
                //SqlCommand cmd = new SqlCommand();
                //cmd.Connection = cn;
                //cn.Open();
                //cmd.CommandText = "select min(RoomID) from HostelRoomDetails where StudentName='Free Space' and Building='" + dgspaceview.Rows[e.RowIndex].Cells[0].Value.ToString() + "' and RoomNumber='" + dgspaceview.Rows[e.RowIndex].Cells[1].Value.ToString() + "'";
                //string roomid1 = cmd.ExecuteScalar().ToString();
                //cn.Close();
                //room = dgspaceview.Rows[e.RowIndex].Cells[1].Value.ToString();
                //building = dgspaceview.Rows[e.RowIndex].Cells[0].Value.ToString();
                //roomid = roomid1;

                for (int i = 0; i < dgs2sview1.Rows.Count - 1; i++)
                {
                    if (i != e.RowIndex)
                    {
                        dgs2sview1.Rows[i].DefaultCellStyle.BackColor = Color.White;
                        dgs2sview1.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                    }
                }

            }
        }

        private void dgs2sview2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgs2sview2.Rows.Count != 1)
            {

               // MessageBox.Show(dgs2sview2.Rows[e.RowIndex].Cells[3].Value.ToString());

                dgs2sview2.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Black;
                dgs2sview2.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;


                SqlDataAdapter da = new SqlDataAdapter("select * from HostelRoomDetails where StudentId=" + dgs2sview2.Rows[e.RowIndex].Cells[3].Value.ToString() + "", cn);
                DataSet ds = new DataSet();
                da.Fill(ds);

            secondidentity = ds.Tables[0].Rows[0]["RoomID"].ToString();
                SecondRoom = ds.Tables[0].Rows[0]["RoomNumber"].ToString();
                SecondBuilding = ds.Tables[0].Rows[0]["Building"].ToString();
                Secondstudentname = ds.Tables[0].Rows[0]["StudentName"].ToString();
                SecondCollege = ds.Tables[0].Rows[0]["CollegeOrSchool"].ToString();
                SecondBranch = ds.Tables[0].Rows[0]["BranchOrClass"].ToString();
                Seconddivision = ds.Tables[0].Rows[0]["Division"].ToString();
                Secondidorroll = ds.Tables[0].Rows[0]["IDOrRollNumber"].ToString();
                Secondcast = ds.Tables[0].Rows[0]["Cast"].ToString();
                Secondsubcast = ds.Tables[0].Rows[0]["SubCast"].ToString();
                Secondcity = ds.Tables[0].Rows[0]["City"].ToString();
                Secondstate = ds.Tables[0].Rows[0]["State"].ToString();
                SecondNationality = ds.Tables[0].Rows[0]["Nationality"].ToString();
                SecondAdmissiondate = ds.Tables[0].Rows[0]["AdmissionDate"].ToString();
                Secondid = ds.Tables[0].Rows[0]["StudentId"].ToString();
                
                

                //SqlCommand cmd = new SqlCommand();
                //cmd.Connection = cn;
                //cn.Open();
                //cmd.CommandText = "select min(RoomID) from HostelRoomDetails where StudentName='Free Space' and Building='" + dgspaceview.Rows[e.RowIndex].Cells[0].Value.ToString() + "' and RoomNumber='" + dgspaceview.Rows[e.RowIndex].Cells[1].Value.ToString() + "'";
                //string roomid1 = cmd.ExecuteScalar().ToString();
                //cn.Close();
                //room = dgspaceview.Rows[e.RowIndex].Cells[1].Value.ToString();
                //building = dgspaceview.Rows[e.RowIndex].Cells[0].Value.ToString();
                //roomid = roomid1;

                for (int i = 0; i < dgs2sview2.Rows.Count - 1; i++)
                {
                    if (i != e.RowIndex)
                    {
                        dgs2sview2.Rows[i].DefaultCellStyle.BackColor = Color.White;
                        dgs2sview2.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                    }
                }

            }
        }

        private void minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnsignout_Click(object sender, EventArgs e)
        {
            var loginform = new Login();
            loginform.Show();
            this.Dispose();
        }
      
    }
}
