using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Hostel_Management_System
{
    public partial class GenralPopup : Form
    {
        public GenralPopup()
        {
            InitializeComponent();
        }

        private void GenralPopup_Load(object sender, EventArgs e)
        {
            double fade;
            for (fade = 0.0; fade < 1.1; fade += 0.1)
            {
                this.Opacity = fade;
                this.Refresh();
                Thread.Sleep(30);

            }
           
        }

        private void btnyes_Click(object sender, EventArgs e)
        {
            var usersettingform = new Usersettings();
            if(btnyes.Text!="Ok")
            {

                Usersettings.popupresult = 1;
               
               
                usersettingform.txtbuilding.Text = Usersettings.building;
                usersettingform.txtroom.Text = Usersettings.Room;
                usersettingform.txtspace.Text = Usersettings.space; 

                usersettingform.btnroominsert_Click(sender, e);
                usersettingform.Dispose();
                this.Dispose();
                usersettingform.Enabled = true;
                usersettingform.Show();
               // MessageBox.Show(usersettingform.txtspace.Text);
              
                
               
            }
            else
            {
                usersettingform.Dispose();
                this.Dispose();
                usersettingform.Enabled = true;
                usersettingform.Show();
            }
        }
    }
}
