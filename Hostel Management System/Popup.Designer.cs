namespace Hostel_Management_System
{
    partial class Popup
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnyes = new System.Windows.Forms.Button();
            this.btnno = new System.Windows.Forms.Button();
            this.txtmessage = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(118, 295);
            this.panel1.TabIndex = 0;
            // 
            // btnyes
            // 
            this.btnyes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnyes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnyes.Location = new System.Drawing.Point(333, 222);
            this.btnyes.Name = "btnyes";
            this.btnyes.Size = new System.Drawing.Size(120, 48);
            this.btnyes.TabIndex = 1;
            this.btnyes.Text = "Yes";
            this.btnyes.UseVisualStyleBackColor = true;
            this.btnyes.Click += new System.EventHandler(this.btnyes_Click);
            // 
            // btnno
            // 
            this.btnno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnno.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnno.Location = new System.Drawing.Point(487, 222);
            this.btnno.Name = "btnno";
            this.btnno.Size = new System.Drawing.Size(120, 48);
            this.btnno.TabIndex = 2;
            this.btnno.Text = "No";
            this.btnno.UseVisualStyleBackColor = true;
            // 
            // txtmessage
            // 
            this.txtmessage.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtmessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtmessage.Enabled = false;
            this.txtmessage.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmessage.ForeColor = System.Drawing.Color.Black;
            this.txtmessage.Location = new System.Drawing.Point(136, 12);
            this.txtmessage.Multiline = true;
            this.txtmessage.Name = "txtmessage";
            this.txtmessage.Size = new System.Drawing.Size(500, 147);
            this.txtmessage.TabIndex = 49;
            this.txtmessage.Text = "Do you want to save this student details";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(124, 184);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(118, 19);
            this.checkBox1.TabIndex = 50;
            this.checkBox1.Text = "Print Fees Recipt";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox2.Location = new System.Drawing.Point(264, 184);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(135, 19);
            this.checkBox2.TabIndex = 51;
            this.checkBox2.Text = "Print Deposit Recipt";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox3.Location = new System.Drawing.Point(415, 184);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(130, 19);
            this.checkBox3.TabIndex = 52;
            this.checkBox3.Text = "Print Official Recipt";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // Popup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(648, 293);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.txtmessage);
            this.Controls.Add(this.btnno);
            this.Controls.Add(this.btnyes);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Popup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Popup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnyes;
        private System.Windows.Forms.Button btnno;
        internal System.Windows.Forms.TextBox txtmessage;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
    }
}