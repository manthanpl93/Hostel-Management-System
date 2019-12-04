namespace Hostel_Management_System
{
    partial class Webcamera
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbwebcam = new System.Windows.Forms.PictureBox();
            this.pbphoto = new System.Windows.Forms.PictureBox();
            this.btncapture = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbwebcam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbphoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btncapture)).BeginInit();
            this.SuspendLayout();
            // 
            // pbwebcam
            // 
            this.pbwebcam.Location = new System.Drawing.Point(161, 12);
            this.pbwebcam.Name = "pbwebcam";
            this.pbwebcam.Size = new System.Drawing.Size(642, 453);
            this.pbwebcam.TabIndex = 1;
            this.pbwebcam.TabStop = false;
            this.pbwebcam.WaitOnLoad = true;
            // 
            // pbphoto
            // 
            this.pbphoto.Location = new System.Drawing.Point(161, 12);
            this.pbphoto.Name = "pbphoto";
            this.pbphoto.Size = new System.Drawing.Size(642, 453);
            this.pbphoto.TabIndex = 2;
            this.pbphoto.TabStop = false;
            this.pbphoto.Visible = false;
            // 
            // btncapture
            // 
            this.btncapture.BackgroundImage = global::Hostel_Management_System.Properties.Resources.Podcast_Capture;
            this.btncapture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btncapture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btncapture.Location = new System.Drawing.Point(434, 475);
            this.btncapture.Name = "btncapture";
            this.btncapture.Size = new System.Drawing.Size(104, 82);
            this.btncapture.TabIndex = 3;
            this.btncapture.TabStop = false;
            this.btncapture.Click += new System.EventHandler(this.btncapture_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 12F);
            this.label8.Location = new System.Drawing.Point(373, 560);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(257, 19);
            this.label8.TabIndex = 192;
            this.label8.Text = "Capture Photo and Use In Registration";
            // 
            // Webcamera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1123, 595);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btncapture);
            this.Controls.Add(this.pbphoto);
            this.Controls.Add(this.pbwebcam);
            this.Name = "Webcamera";
            this.Text = "Webcamera";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Webcamera_FormClosed);
            this.Load += new System.EventHandler(this.Webcamera_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbwebcam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbphoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btncapture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbwebcam;
        private System.Windows.Forms.PictureBox pbphoto;
        private System.Windows.Forms.PictureBox btncapture;
        internal System.Windows.Forms.Label label8;

    }
}