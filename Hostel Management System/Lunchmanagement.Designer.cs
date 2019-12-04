namespace Hostel_Management_System
{
    partial class Lunchmanagement
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
            this.btnmenu = new System.Windows.Forms.Button();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.Panel4 = new System.Windows.Forms.Panel();
            this.cbbranch = new System.Windows.Forms.ComboBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.txtroomsearch = new System.Windows.Forms.TextBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Label6 = new System.Windows.Forms.Label();
            this.cbcollege = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Panel2.SuspendLayout();
            this.Panel4.SuspendLayout();
            this.Panel3.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnmenu
            // 
            this.btnmenu.BackColor = System.Drawing.Color.Black;
            this.btnmenu.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.btnmenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnmenu.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnmenu.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnmenu.Location = new System.Drawing.Point(3, 3);
            this.btnmenu.Name = "btnmenu";
            this.btnmenu.Size = new System.Drawing.Size(170, 112);
            this.btnmenu.TabIndex = 65;
            this.btnmenu.Text = "Menu";
            this.btnmenu.UseVisualStyleBackColor = false;
            this.btnmenu.Click += new System.EventHandler(this.btnmenu_Click);
            // 
            // Panel2
            // 
            this.Panel2.AutoScroll = true;
            this.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel2.Controls.Add(this.Panel4);
            this.Panel2.Controls.Add(this.Panel3);
            this.Panel2.Controls.Add(this.Panel1);
            this.Panel2.Location = new System.Drawing.Point(3, 203);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(471, 343);
            this.Panel2.TabIndex = 74;
            // 
            // Panel4
            // 
            this.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel4.Controls.Add(this.cbbranch);
            this.Panel4.Controls.Add(this.Label8);
            this.Panel4.Location = new System.Drawing.Point(11, 204);
            this.Panel4.Name = "Panel4";
            this.Panel4.Size = new System.Drawing.Size(422, 98);
            this.Panel4.TabIndex = 67;
            // 
            // cbbranch
            // 
            this.cbbranch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbbranch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbbranch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbranch.FormattingEnabled = true;
            this.cbbranch.ItemHeight = 20;
            this.cbbranch.Location = new System.Drawing.Point(8, 34);
            this.cbbranch.Name = "cbbranch";
            this.cbbranch.Size = new System.Drawing.Size(409, 28);
            this.cbbranch.TabIndex = 15;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold);
            this.Label8.Location = new System.Drawing.Point(7, 5);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(121, 26);
            this.Label8.TabIndex = 12;
            this.Label8.Text = "Lunch Status";
            // 
            // Panel3
            // 
            this.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel3.Controls.Add(this.txtroomsearch);
            this.Panel3.Controls.Add(this.Label7);
            this.Panel3.Location = new System.Drawing.Point(12, 111);
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(425, 76);
            this.Panel3.TabIndex = 67;
            // 
            // txtroomsearch
            // 
            this.txtroomsearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtroomsearch.Location = new System.Drawing.Point(11, 38);
            this.txtroomsearch.Name = "txtroomsearch";
            this.txtroomsearch.Size = new System.Drawing.Size(409, 26);
            this.txtroomsearch.TabIndex = 7;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold);
            this.Label7.Location = new System.Drawing.Point(9, 5);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(167, 26);
            this.Label7.TabIndex = 11;
            this.Label7.Text = "Search By Date To";
            // 
            // Panel1
            // 
            this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel1.Controls.Add(this.cbcollege);
            this.Panel1.Controls.Add(this.Label6);
            this.Panel1.Location = new System.Drawing.Point(10, 20);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(429, 74);
            this.Panel1.TabIndex = 66;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold);
            this.Label6.Location = new System.Drawing.Point(4, 0);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(193, 26);
            this.Label6.TabIndex = 10;
            this.Label6.Text = "Search By Date From";
            // 
            // cbcollege
            // 
            this.cbcollege.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbcollege.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbcollege.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbcollege.FormattingEnabled = true;
            this.cbcollege.ItemHeight = 20;
            this.cbcollege.Location = new System.Drawing.Point(9, 29);
            this.cbcollege.Name = "cbcollege";
            this.cbcollege.Size = new System.Drawing.Size(409, 28);
            this.cbcollege.TabIndex = 14;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(9, 124);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(108, 26);
            this.Label1.TabIndex = 65;
            this.Label1.Text = "Today Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 26);
            this.label2.TabIndex = 75;
            this.label2.Text = "Today Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(188, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 26);
            this.label3.TabIndex = 77;
            this.label3.Text = "Today Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(147, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(194, 26);
            this.label4.TabIndex = 76;
            this.label4.Text = "Today Lunch Request";
            // 
            // Lunchmanagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1338, 695);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.btnmenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Lunchmanagement";
            this.Text = "Lunchmanagement";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Panel2.ResumeLayout(false);
            this.Panel4.ResumeLayout(false);
            this.Panel4.PerformLayout();
            this.Panel3.ResumeLayout(false);
            this.Panel3.PerformLayout();
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button btnmenu;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Panel Panel4;
        internal System.Windows.Forms.ComboBox cbbranch;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Panel Panel3;
        internal System.Windows.Forms.TextBox txtroomsearch;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.ComboBox cbcollege;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label4;
    }
}