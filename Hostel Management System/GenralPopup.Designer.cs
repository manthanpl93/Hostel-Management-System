namespace Hostel_Management_System
{
    public partial class GenralPopup
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
       public void InitializeComponent()
        {
            this.txtmessage = new System.Windows.Forms.TextBox();
            this.btnno = new System.Windows.Forms.Button();
            this.btnyes = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // txtmessage
            // 
            this.txtmessage.BackColor = System.Drawing.SystemColors.Control;
            this.txtmessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtmessage.Enabled = false;
            this.txtmessage.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmessage.ForeColor = System.Drawing.Color.Black;
            this.txtmessage.Location = new System.Drawing.Point(128, 12);
            this.txtmessage.Multiline = true;
            this.txtmessage.Name = "txtmessage";
            this.txtmessage.Size = new System.Drawing.Size(412, 162);
            this.txtmessage.TabIndex = 53;
            this.txtmessage.Text = "Do you want to save this student details";
            // 
            // btnno
            // 
            this.btnno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnno.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnno.Location = new System.Drawing.Point(405, 208);
            this.btnno.Name = "btnno";
            this.btnno.Size = new System.Drawing.Size(120, 34);
            this.btnno.TabIndex = 52;
            this.btnno.Text = "No";
            this.btnno.UseVisualStyleBackColor = true;
            // 
            // btnyes
            // 
            this.btnyes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnyes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnyes.Location = new System.Drawing.Point(259, 208);
            this.btnyes.Name = "btnyes";
            this.btnyes.Size = new System.Drawing.Size(120, 34);
            this.btnyes.TabIndex = 51;
            this.btnyes.Text = "Yes";
            this.btnyes.UseVisualStyleBackColor = true;
            this.btnyes.Click += new System.EventHandler(this.btnyes_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel1.Location = new System.Drawing.Point(-2, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(123, 254);
            this.panel1.TabIndex = 50;
            // 
            // GenralPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 254);
            this.Controls.Add(this.txtmessage);
            this.Controls.Add(this.btnno);
            this.Controls.Add(this.btnyes);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GenralPopup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GenralPopup";
            this.Load += new System.EventHandler(this.GenralPopup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnno;
        public System.Windows.Forms.Button btnyes;
       public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TextBox txtmessage;
    }
}