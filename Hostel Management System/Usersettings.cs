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
    public partial class Usersettings : Form
    {
        public static SqlConnection cn = new SqlConnection(Hostelcodesource.database.cs);
        public static int popupresult=0;
        public int num;
        public static string building;
        public static string Room;
        public static string space;
        public Usersettings()
        {
            InitializeComponent();
        }

        private void lblrmarrengement_Click(object sender, EventArgs e)
        {
            int height = panel2roomarrengement.Height;
            panel2roomarrengement.Visible = true;
            panel3useraccount.Visible = false;
                  for (int i = 0; i < height + 1; i += 10)
                {
                    panel2roomarrengement.Height = i;
                    this.Refresh();
                    Thread.Sleep(3);
                }
        }

        private void lblfeessetting_Click(object sender, EventArgs e)
        {
            panel2roomarrengement.Visible = false;
            int height=panel1FeesSetting.Height;
           // panel2roomarrengement.Visible = true;
            for (int i = 0; i < height + 1; i += 10)
            {
                panel1FeesSetting.Height = i;
                this.Refresh();
                Thread.Sleep(5);
            }
        }

        private void lblmenu_Click(object sender, EventArgs e)
        {
            var homepageform = new Homepage();
            homepageform.Show();
            this.Hide();
        }

        private void Usersettings_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from FeesDetail",cn);
            DataSet ds=new DataSet();
            da.Fill(ds);
            int count=ds.Tables[0].Rows.Count;

            if (count>0)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cn.Open();
                cmd.CommandText = "select max(Id) from FeesDetail";
                string id = cmd.ExecuteScalar().ToString();
                cn.Close();
                cmd.Dispose();

                SqlDataAdapter da2 = new SqlDataAdapter("select Year,Fess,Deposite from FeesDetail where Id=" + id + "", cn);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2);
                lblcurrentyear.Text = "Current Year=" + ds2.Tables[0].Rows[0][0].ToString();
                lblcurrentfees.Text = "Current Fees=" + ds2.Tables[0].Rows[0][1].ToString();
                lbldeposite.Text = "Current Deposite=" + ds2.Tables[0].Rows[0][2].ToString();
            }
           

            double fade;
            for (fade = 0.0; fade < 1.1; fade += 0.1)
            {
                this.Opacity = fade;
                this.Refresh();
                Thread.Sleep(30);

            }

           
        }

        private void lblstartnewyear_Click(object sender, EventArgs e)
        {
           
        }

       public void btninsert_Click(object sender, EventArgs e)
        {
            if(txtnewyear.Text=="")
            {
                lblfeessettingerror1.Visible = true;
            }
            else
            {
                lblfeessettingerror1.Visible = false;
            }

            if (txthostelfee.Text== "")
            {
                lblfeessettingerror2.Visible = true;
            }
            else
            {
                lblfeessettingerror2.Visible = false;
            }


            if (txtdiposite.Text == "")
            {
                lblfeessettingerror3.Visible = true;
            }
            else
            {
                lblfeessettingerror3.Visible = false;
            }

            if (lblfeessettingerror1.Visible == false && lblfeessettingerror2.Visible == false && lblfeessettingerror3.Visible == false)
            {

                SqlDataAdapter da2 = new SqlDataAdapter("select * from FeesDetail", cn);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2);

                if(ds2.Tables[0].Rows.Count>0)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cn.Open();


                    cmd.CommandText = "select max(Id) from FeesDetail";
                    string currentId = cmd.ExecuteScalar().ToString();

                    cmd.CommandText = "select Year from FeesDetail where Id=" + currentId + "";
                    string currentyear = cmd.ExecuteScalar().ToString();


                    cmd.CommandText = "insert into FeesDetail values ('" + txtnewyear.Text + "'," + txthostelfee.Text + "," + txtdiposite.Text + ")";
                    cmd.ExecuteNonQuery();



                    cn.Close();
                    cmd.Dispose();

                    SqlDataAdapter da = new SqlDataAdapter("select RoomNumber,StudentName,Building,StudentId from HostelRoomDetails where StudentName!='Free Space' ", cn);
                    DataSet ds = new DataSet();
                    da.Fill(ds);



                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        SqlCommand cmd2 = new SqlCommand();
                        cmd2.Connection = cn;
                        cn.Open();
                        cmd2.CommandText = "insert into StudentYearFees values ('" + ds.Tables[0].Rows[i][0].ToString() + "','" + ds.Tables[0].Rows[i][1].ToString() + "','" + ds.Tables[0].Rows[i][2].ToString() + "',0," + txthostelfee.Text + ",@p1,'" + ds.Tables[0].Rows[i][3].ToString() + "','" + txtnewyear.Text + "','" + txthostelfee.Text + "')";
                        SqlParameter para1 = new SqlParameter("p1", SqlDbType.Date);
                        para1.Value = DateTime.Today;
                        cmd2.Parameters.Add(para1);
                        cmd2.ExecuteNonQuery();
                        cn.Close();

                    }
                }
                else
                {
                    
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cn.Open();

                    cmd.CommandText = "insert into FeesDetail values ('" + txtnewyear.Text + "'," + txthostelfee.Text + "," + txtdiposite.Text + ")";
                    cmd.ExecuteNonQuery();
                  


                    cmd.CommandText = "select max(Id) from FeesDetail";
                    string currentId = cmd.ExecuteScalar().ToString();

                    cmd.CommandText = "select Year from FeesDetail where Id=" + currentId + "";
                    string currentyear = cmd.ExecuteScalar().ToString();


                    cmd.CommandText = "insert into FeesDetail values ('" + txtnewyear.Text + "'," + txthostelfee.Text + "," + txtdiposite.Text + ")";
                    cmd.ExecuteNonQuery();



                    cn.Close();
                    cmd.Dispose();

                    SqlDataAdapter da = new SqlDataAdapter("select RoomNumber,StudentName,Building,StudentId from HostelRoomDetails where StudentName!='Free Space' ", cn);
                    DataSet ds = new DataSet();
                    da.Fill(ds);



                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        SqlCommand cmd2 = new SqlCommand();
                        cmd2.Connection = cn;
                        cn.Open();
                        cmd2.CommandText = "insert into StudentYearFees values ('" + ds.Tables[0].Rows[i][0].ToString() + "','" + ds.Tables[0].Rows[i][1].ToString() + "','" + ds.Tables[0].Rows[i][2].ToString() + "',0," + txthostelfee.Text + ",@p1,'" + ds.Tables[0].Rows[i][3].ToString() + "','" + txtnewyear.Text + "','" + txthostelfee.Text + "')";
                        SqlParameter para1 = new SqlParameter("p1", SqlDbType.Date);
                        para1.Value = DateTime.Today;
                        cmd2.Parameters.Add(para1);
                        cmd2.ExecuteNonQuery();
                        cn.Close();

                    }

                   
                    
                }


            }







          
        }

        public void btnroominsert_Click(object sender, EventArgs e)
        {
           
           
            
            if (txtbuilding.Text == "")
            {
                lblroomarrengementerror1.Visible = true;
            }
            else
            {
                lblroomarrengementerror1.Visible = false;
            }
            if (txtroom.Text == "")
            {
                lblroomarrengementerror2.Visible = true;
            }
            else
            {
                lblroomarrengementerror2.Visible = false;
            }
            if (txtspace.Text == "")
            {
                lblroomarrengementerror3.Visible = true;
            }
            else
            {
                lblroomarrengementerror3.Visible = false;
            }
            if (lblroomarrengementerror1.Visible==false && lblroomarrengementerror2.Visible==false && lblroomarrengementerror3.Visible==false)
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from HostelRoomDetails where Building='" + txtbuilding.Text + "' and RoomNumber='"+ txtroom.Text +"'", cn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                int count = ds.Tables[0].Rows.Count;
              //  MessageBox.Show(count.ToString());
                if (count==0)
                {
                    SoundPlayer sound = new SoundPlayer(@"c:\Windows\Media\chimes.wav");
                    sound.Play();
                    DialogResult rs = MessageBox.Show("Do You Want To Add New Room " + txtbuilding.Text + "-" + txtroom.Text + "?", "New Room", MessageBoxButtons.YesNo);


                    if (rs == DialogResult.Yes)
                    {


                        num = Convert.ToInt32(txtspace.Text);

                        for (int i = 0; i < num; i++)
                        {
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = cn;
                            cn.Open();
                            cmd.CommandText = "insert into HostelRoomDetails(RoomID,RoomNumber,Building,StudentName) values(" + i + ",'" + txtroom.Text + "','" + txtbuilding.Text + "','Free Space')";
                            cmd.ExecuteNonQuery();
                            cn.Close();
                            cmd.Dispose();
                        }
                       MessageBox.Show("Room Suceessfully Add On Hostel", "Room Saved", MessageBoxButtons.OK);


                    }
                }
               
                if (Convert.ToInt32(txtspace.Text)>count && count!=0)
                {

                    SoundPlayer sound = new SoundPlayer(@"c:\Windows\Media\chimes.wav");
                    sound.Play();
                   DialogResult rs= MessageBox.Show("Do You Want To Increesed The Size Of " + txtbuilding.Text + "-" + txtroom.Text + " Room ?","Increesed Room Size",MessageBoxButtons.YesNo);
                  
                   
                    if (rs==DialogResult.Yes)
                    {
                        
                        int space = 0;
                        for (int i = count-1; i < Convert.ToInt32(txtspace.Text)-1; i++)
                        {

                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = cn;
                            cn.Open();
                            cmd.CommandText = "insert into HostelRoomDetails(RoomID,RoomNumber,Building,StudentName) values(" + (i + Convert.ToInt32(1)) + ",'" + txtroom.Text + "','" + txtbuilding.Text + "','Free Space')";
                            cmd.ExecuteNonQuery();
                            cn.Close();
                            cmd.Dispose();
                            space += 1;
                        
                        }
                        MessageBox.Show("Room Size Successfully Increesed", "Room Increesed", MessageBoxButtons.OK);
  
                    }
                    
                     
                    
                }

                if (count == Convert.ToInt32(txtspace.Text))
                {
                    SoundPlayer sound = new SoundPlayer(@"c:\Windows\Media\chimes.wav");
                    sound.Play();
                    MessageBox.Show("This Room Has Allready This Space", "Wrong Input", MessageBoxButtons.OK);
                }

                if (Convert.ToInt32(txtspace.Text) < count)
                {
                    SoundPlayer sound = new SoundPlayer(@"c:\Windows\Media\chimes.wav");
                    sound.Play();
                    MessageBox.Show("This Room has Heigher Size than Space", "Wrong Input", MessageBoxButtons.OK);
                }
            }
          
           
           
        }

        private void txtroom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || e.KeyChar == '!' || e.KeyChar == '~' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '^' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '_' || e.KeyChar == '-' || e.KeyChar == '+' || e.KeyChar == '=' || e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '{' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '"' || e.KeyChar == '.' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '`' || e.KeyChar == '!' || e.KeyChar == '~' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '^' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '_' || e.KeyChar == '-' || e.KeyChar == '+' || e.KeyChar == '=' || e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '{' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '"' || e.KeyChar == '.' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '`' || e.KeyChar == 39 || e.KeyChar == 32)
            {

                e.Handled = true;
            }
        }

        private void txtspace_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || e.KeyChar == '!' || e.KeyChar == '~' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '^' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '_' || e.KeyChar == '-' || e.KeyChar == '+' || e.KeyChar == '=' || e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '{' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '"' || e.KeyChar == '.' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '`' || e.KeyChar == '!' || e.KeyChar == '~' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '^' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '_' || e.KeyChar == '-' || e.KeyChar == '+' || e.KeyChar == '=' || e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '{' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '"' || e.KeyChar == '.' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '`' || e.KeyChar == 39 || e.KeyChar == 32)
            {

                e.Handled = true;
            }
        }

        private void txtbuilding_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '!' || e.KeyChar == '~' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '^' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '_' || e.KeyChar == '-' || e.KeyChar == '+' || e.KeyChar == '=' || e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '{' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '"' || e.KeyChar == '.' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '`' || e.KeyChar == '!' || e.KeyChar == '~' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '^' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '_' || e.KeyChar == '-' || e.KeyChar == '+' || e.KeyChar == '=' || e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '{' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '"' || e.KeyChar == '.' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '`' || e.KeyChar == 39)
            {

                e.Handled = true;
            }
        }

        private void txtnewyear_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '!' || e.KeyChar == '~' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '^' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '_' || e.KeyChar == '+' || e.KeyChar == '=' || e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '{' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '"' || e.KeyChar == '.' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '`' || e.KeyChar == '!' || e.KeyChar == '~' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '^' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '_' ||  e.KeyChar == '+' || e.KeyChar == '=' || e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '{' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '"' || e.KeyChar == '.' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '`' || e.KeyChar == 39 || e.KeyChar == 32)
            {

                e.Handled = true;
            }
        }

        private void txthostelfee_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || e.KeyChar == '!' || e.KeyChar == '~' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '^' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '_' || e.KeyChar == '-' || e.KeyChar == '+' || e.KeyChar == '=' || e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '{' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '"' || e.KeyChar == '.' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '`' || e.KeyChar == '!' || e.KeyChar == '~' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '^' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '_' || e.KeyChar == '-' || e.KeyChar == '+' || e.KeyChar == '=' || e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '{' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '"' || e.KeyChar == '.' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '`' || e.KeyChar == 39 || e.KeyChar == 32)
            {

                e.Handled = true;
            }
        }

        private void txtdiposite_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || e.KeyChar == '!' || e.KeyChar == '~' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '^' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '_' || e.KeyChar == '-' || e.KeyChar == '+' || e.KeyChar == '=' || e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '{' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '"' || e.KeyChar == '.' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '`' || e.KeyChar == '!' || e.KeyChar == '~' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '^' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '_' || e.KeyChar == '-' || e.KeyChar == '+' || e.KeyChar == '=' || e.KeyChar == '/' || e.KeyChar == '*' || e.KeyChar == '{' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == ',' || e.KeyChar == '"' || e.KeyChar == '.' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '`' || e.KeyChar == 39 || e.KeyChar == 32)
            {

                e.Handled = true;
            }
        }

        private void btnroomdelete_Click(object sender, EventArgs e)
        {
            if (txtbuilding.Text == "")
            {
                lblroomarrengementerror1.Visible = true;
            }
            else
            {
                lblroomarrengementerror1.Visible = false;
            }
            if (txtroom.Text == "")
            {
                lblroomarrengementerror2.Visible = true;
            }
            else
            {
                lblroomarrengementerror2.Visible = false;
            }
            if (txtspace.Text == "")
            {
                lblroomarrengementerror3.Visible = true;
            }
            else
            {
                lblroomarrengementerror3.Visible = false;
            }
            if (lblroomarrengementerror1.Visible == false && lblroomarrengementerror2.Visible == false && lblroomarrengementerror3.Visible == false)
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from HostelRoomDetails where Building='" + txtbuilding.Text + "' and RoomNumber='" + txtroom.Text + "'", cn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                int Totalspace = ds.Tables[0].Rows.Count;


                SqlDataAdapter da2 = new SqlDataAdapter("select RoomID from HostelRoomDetails where Building='" + txtbuilding.Text + "' and RoomNumber='" + txtroom.Text + "' and StudentName='Free Space' group by RoomID order by RoomID DESC", cn);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2);
                int Freespace = ds2.Tables[0].Rows.Count;

                int userspace = Convert.ToInt32(txtspace.Text);

               
                
                if(Totalspace==0)
                
                {
                    SoundPlayer sound = new SoundPlayer(@"c:\Windows\Media\chimes.wav");
                    sound.Play();
                    MessageBox.Show("Room Number Not Avaialable","Wrong Input",MessageBoxButtons.OK);

                }

                if (userspace<Freespace)
                {
                    SoundPlayer sound = new SoundPlayer(@"c:\Windows\Media\chimes.wav");
                    sound.Play();
                    DialogResult = MessageBox.Show("Are You Sure You Want To Delete Room Space Of This Room ?","Delete Room",MessageBoxButtons.YesNo); 
                 if (DialogResult==DialogResult.Yes)
                 {
                     for (int i = 0; i < userspace; i++)
                     {
                         SqlCommand cmd = new SqlCommand();
                         cmd.Connection = cn;
                         cn.Open();
                         cmd.CommandText = "delete from HostelRoomDetails where RoomID='" + ds2.Tables[0].Rows[i][0].ToString() + "'";
                         cmd.ExecuteNonQuery();
                         cn.Close();

                     }

                     MessageBox.Show("Room Space Delete Sucessfully","Delete Space",MessageBoxButtons.OK);
                 }
                   
                }


                if(userspace>Totalspace && Totalspace!=0)
                {
                    SoundPlayer sound = new SoundPlayer(@"c:\Windows\Media\chimes.wav");
                    sound.Play();
                    MessageBox.Show("This Room Has Less Then Size with Enter Size","Wrong Input",MessageBoxButtons.OK);

                }

                if(userspace<Totalspace)

                {
                    SoundPlayer sound = new SoundPlayer(@"c:\Windows\Media\chimes.wav");
                    sound.Play();
                    MessageBox.Show("This Room has Student so you delete or move student and try later ", "Wrong Input", MessageBoxButtons.OK);

                }

                if(userspace==Freespace && Freespace==Totalspace)
                {
                    SoundPlayer sound = new SoundPlayer(@"c:\Windows\Media\chimes.wav");
                    sound.Play();
                  DialogResult dr=  MessageBox.Show("Are You Sure You Want to Delete This Room ?", "Wrong Input", MessageBoxButtons.YesNo);

                    if(dr==DialogResult.Yes)
                    {
                        for (int i = 0; i < userspace; i++)
                        {
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = cn;
                            cn.Open();
                            cmd.CommandText = "delete from HostelRoomDetails where RoomID='" + ds2.Tables[0].Rows[i][0].ToString() + "'";
                            cmd.ExecuteNonQuery();
                            cn.Close();

                        }

                        MessageBox.Show("Room Delete Sucessfully", "Delete Room", MessageBoxButtons.OK);
                
                    }


                }

                
            }
        }

        private void lbluseracoounts_Click(object sender, EventArgs e)
        {
            panel2roomarrengement.Visible = true;
            panel1FeesSetting.Visible = true;
            panel3useraccount.Visible = true;
            int height = panel3useraccount.Height;
          
            for (int i = 0; i < height + 1; i += 10)
            {
                panel3useraccount.Height = i;
                this.Refresh();
                Thread.Sleep(3);
            }
        }

        private void btnsubmit_Click(object sender, EventArgs e)
        {
            SoundPlayer sound = new SoundPlayer(@"c:\Windows\Media\chimes.wav");
            if(txtusername.Text!="" && txtpassword.Text!="" && txtconfirmpassword.Text!="" && txtnewpassword.Text!="")
            {
              //  SoundPlayer sound = new SoundPlayer(@"c:\Windows\Media\chimes.wav");
              
                SqlDataAdapter da = new SqlDataAdapter("select * from Login where Username='"+ txtusername.Text  +"' and Password='"+ txtpassword.Text +"'", cn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if(ds.Tables[0].Rows.Count>0)
                {

                    if (txtnewpassword.TextLength <= 8 && txtnewpassword.TextLength >= 6 && txtconfirmpassword.TextLength <= 8 && txtconfirmpassword.TextLength >= 6)
                    {
                        if(txtnewpassword.Text==txtconfirmpassword.Text)
                        {
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = cn;
                            cn.Open();
                            cmd.CommandText = "update login set Password='"+ txtnewpassword.Text +"' where Username='"+ txtusername.Text +"'";
                          int i=  cmd.ExecuteNonQuery();
                            if(i>0)
                            {
                                sound.Play();
                                MessageBox.Show("Password Changed Successfully","Hostel Management System",MessageBoxButtons.OK);
                                txtusername.Text = "";
                                txtpassword.Text = "";
                                txtnewpassword.Text = "";
                                txtconfirmpassword.Text = "";

                            }
                            cn.Close();


                        }
                        else
                        {
                            sound.Play();
                            MessageBox.Show("Must Enter Same Password","Hostel Management System",MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        sound.Play();
                        MessageBox.Show("Password Must Be Of 6-12","Hostel Management System",MessageBoxButtons.OK);
                    }
                }
                else
                {
                    sound.Play();
                    MessageBox.Show("Username or Password Incorrect","Hostel Management System",MessageBoxButtons.OK);
                }
            }
            else
            {
                sound.Play();             
                MessageBox.Show("Must Enter All Field","Hostel Management System",MessageBoxButtons.OK);
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            SoundPlayer sound = new SoundPlayer(@"c:\Windows\Media\chimes.wav");
            SqlDataAdapter da = new SqlDataAdapter("select * from login where Username='"+ txtusername2.Text +"'",cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
           
            if(ds.Tables[0].Rows.Count>0)
            {
                sound.Play();
                MessageBox.Show("Username Available choose Another Username","Hostel Management System",MessageBoxButtons.OK);
          
            }
            else
            {
                if (txtpassword2.TextLength >= 6 && txtconfirmpassword2.TextLength <= 8)
              {
                  if(txtpassword2.Text==txtconfirmpassword2.Text)
                  {
                      SqlCommand cmd = new SqlCommand();
                      cmd.Connection = cn;
                      cn.Open();
                      cmd.CommandText = "insert into login (username,password) values ('"+ txtusername2.Text +"','"+ txtpassword2.Text+"')";
                      cmd.ExecuteNonQuery();
                      cn.Close();

                      sound.Play();
                      MessageBox.Show("User Added","Hostel Management System",MessageBoxButtons.OK);
                      txtusername2.Text = "";
                      txtpassword2.Text = "";
                      txtconfirmpassword2.Text = "";
                  }
                  else
                  {
                      sound.Play();
                      MessageBox.Show("Must Enter Same Password ","Hostel Management System",MessageBoxButtons.OK);
                  }
              }
              else
              {
                  sound.Play();
                  MessageBox.Show("Password must be of 6-8","Hostel Managemenet System",MessageBoxButtons.OK);
              }
            }

        }
    }
}
