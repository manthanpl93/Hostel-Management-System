using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;

namespace Hostel_Management_System
{
    
    class Hostelcodesource
    {
      
        public static void checkdummy(string value)
        {
            string info = value;
         

            int i = 0;
            while((i=info.IndexOf(' ',i))!=-1)
            {
                i++;

            }


        }
        class graphics
        {
            // It is the Graphics Section here all effects code are writen 
        }

       public class database
        {
            // Here All database related code are written e.q Connection String
           //public static string cn = "Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\SOFTWARES\Projects\Hostel Management System\Hostel Management System\HostelSystem.mdf;Integrated Security=True";
         //  public static string cs="Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\HostelSystem.mdf;Integrated Security=True";
      public static string cs="Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\HostelSystem.mdf;Integrated Security=True";
       
          }

        public class webcam
        {

            public static string imagepat = "";
          

        }


    }
}
