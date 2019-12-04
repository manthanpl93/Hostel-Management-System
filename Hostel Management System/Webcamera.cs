using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using AForge.Video;
using AForge.Video.DirectShow;


namespace Hostel_Management_System
{
    public partial class Webcamera : Form
    {
       
        public Webcamera()
        {
            InitializeComponent();
        }
        VideoCaptureDevice videoSource;
        public static void SaveImageCapture(System.Drawing.Image image)
        {

           

            // Show save file dialog box
            // Process save file dialog box results
        
                // Save Image
            int i = 1;
        here: ;
            string imgpath = Directory.GetCurrentDirectory() + "//Images//Studentpic"+i+".jpeg";

            if (File.Exists(@imgpath))
            {
                i = i + 1;
                goto here;
            }
            else
            {
                FileStream fstream = new FileStream(imgpath, FileMode.Create);
                image.Save(fstream, System.Drawing.Imaging.ImageFormat.Jpeg);
                fstream.Close();
            }

            Hostelcodesource.webcam.imagepat = imgpath;


        }

        private void Webcamera_Load(object sender, EventArgs e)
        {
            //List all available video sources. (That can be webcams as well as tv cards, etc)
            FilterInfoCollection videosources = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            //Check if atleast one video source is available
            if (videosources != null)
            {
                //For example use first video device. You may check if this is your webcam.
                videoSource = new VideoCaptureDevice(videosources[0].MonikerString);

                try
                {
                    //Check if the video device provides a list of supported resolutions
                    if (videoSource.VideoCapabilities.Length > 0)
                    {
                        string highestSolution = "0;0";
                        //Search for the highest resolution
                        for (int i = 0; i < videoSource.VideoCapabilities.Length; i++)
                        {
                            if (videoSource.VideoCapabilities[i].FrameSize.Width > Convert.ToInt32(highestSolution.Split(';')[0]))
                                highestSolution = videoSource.VideoCapabilities[i].FrameSize.Width.ToString() + ";" + i.ToString();
                        }
                        //Set the highest resolution as active
                        videoSource.VideoResolution = videoSource.VideoCapabilities[Convert.ToInt32(highestSolution.Split(';')[1])];
                    }
                }
                catch { }

                //Create NewFrame event handler
                //(This one triggers every time a new frame/image is captured
                videoSource.NewFrame += new AForge.Video.NewFrameEventHandler(videoSource_NewFrame);

                //Start recording
                videoSource.Start();
            }
        }
        void videoSource_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            //Cast the frame as Bitmap object and don't forget to use ".Clone()" otherwise
            //you'll probably get access violation exceptions

            pbwebcam.BackgroundImage = (Bitmap)eventArgs.Frame.Clone();
        }

        private void Webcamera_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource = null;
            }
        }

        private void btncapture_Click(object sender, EventArgs e)
        {
       
            pbphoto.Image = pbwebcam.BackgroundImage;
            pbphoto.Visible = true;
         SaveImageCapture(pbphoto.Image);
         
           
            
        }

        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
          
        }

      
    }
}
