namespace DesktopClient
{
    partial class Users
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
            this.listUsers = new System.Windows.Forms.ListBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblSpeaks = new System.Windows.Forms.Label();
            this.lblInterested = new System.Windows.Forms.Label();
            this.lblBirthDate = new System.Windows.Forms.Label();
            this.lblNameContent = new System.Windows.Forms.Label();
            this.tboxEmail = new System.Windows.Forms.TextBox();
            this.tboxBirthDate = new System.Windows.Forms.TextBox();
            this.tboxCity = new System.Windows.Forms.TextBox();
            this.lblSpeaksContent = new System.Windows.Forms.Label();
            this.lblInterestedContent = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listUsers
            // 
            this.listUsers.FormattingEnabled = true;
            this.listUsers.Location = new System.Drawing.Point(29, 21);
            this.listUsers.Name = "listUsers";
            this.listUsers.Size = new System.Drawing.Size(286, 394);
            this.listUsers.TabIndex = 1;
            this.listUsers.SelectedIndexChanged += new System.EventHandler(this.listUsers_SelectedIndexChanged);
            this.listUsers.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.listUsers_Format);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.IndianRed;
            this.btnDelete.Location = new System.Drawing.Point(233, 430);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(82, 30);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(29, 430);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(198, 30);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(335, 21);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(62, 18);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "Name:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(335, 112);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(65, 18);
            this.lblEmail.TabIndex = 6;
            this.lblEmail.Text = "E-Mail:";
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCity.Location = new System.Drawing.Point(336, 190);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(47, 18);
            this.lblCity.TabIndex = 8;
            this.lblCity.Text = "City:";
            // 
            // lblSpeaks
            // 
            this.lblSpeaks.AutoSize = true;
            this.lblSpeaks.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeaks.Location = new System.Drawing.Point(336, 228);
            this.lblSpeaks.Name = "lblSpeaks";
            this.lblSpeaks.Size = new System.Drawing.Size(73, 18);
            this.lblSpeaks.TabIndex = 9;
            this.lblSpeaks.Text = "Speaks:";
            // 
            // lblInterested
            // 
            this.lblInterested.AutoSize = true;
            this.lblInterested.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInterested.Location = new System.Drawing.Point(334, 270);
            this.lblInterested.Name = "lblInterested";
            this.lblInterested.Size = new System.Drawing.Size(122, 18);
            this.lblInterested.TabIndex = 10;
            this.lblInterested.Text = "Interested in:";
            // 
            // lblBirthDate
            // 
            this.lblBirthDate.AutoSize = true;
            this.lblBirthDate.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBirthDate.Location = new System.Drawing.Point(335, 152);
            this.lblBirthDate.Name = "lblBirthDate";
            this.lblBirthDate.Size = new System.Drawing.Size(93, 18);
            this.lblBirthDate.TabIndex = 7;
            this.lblBirthDate.Text = "BirthDate:";
            // 
            // lblNameContent
            // 
            this.lblNameContent.AutoEllipsis = true;
            this.lblNameContent.AutoSize = true;
            this.lblNameContent.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameContent.Location = new System.Drawing.Point(455, 21);
            this.lblNameContent.Name = "lblNameContent";
            this.lblNameContent.Size = new System.Drawing.Size(0, 18);
            this.lblNameContent.TabIndex = 14;
            // 
            // tboxEmail
            // 
            this.tboxEmail.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxEmail.Location = new System.Drawing.Point(451, 108);
            this.tboxEmail.MaximumSize = new System.Drawing.Size(175, 26);
            this.tboxEmail.MinimumSize = new System.Drawing.Size(175, 26);
            this.tboxEmail.Name = "tboxEmail";
            this.tboxEmail.Size = new System.Drawing.Size(175, 26);
            this.tboxEmail.TabIndex = 15;
            // 
            // tboxBirthDate
            // 
            this.tboxBirthDate.Font = new System.Drawing.Font("Verdana", 11.25F);
            this.tboxBirthDate.Location = new System.Drawing.Point(451, 149);
            this.tboxBirthDate.MaximumSize = new System.Drawing.Size(175, 26);
            this.tboxBirthDate.MinimumSize = new System.Drawing.Size(175, 26);
            this.tboxBirthDate.Name = "tboxBirthDate";
            this.tboxBirthDate.Size = new System.Drawing.Size(175, 26);
            this.tboxBirthDate.TabIndex = 16;
            // 
            // tboxCity
            // 
            this.tboxCity.Font = new System.Drawing.Font("Verdana", 11.25F);
            this.tboxCity.Location = new System.Drawing.Point(451, 188);
            this.tboxCity.MaximumSize = new System.Drawing.Size(175, 26);
            this.tboxCity.MinimumSize = new System.Drawing.Size(175, 26);
            this.tboxCity.Name = "tboxCity";
            this.tboxCity.Size = new System.Drawing.Size(175, 26);
            this.tboxCity.TabIndex = 17;
            // 
            // lblSpeaksContent
            // 
            this.lblSpeaksContent.AutoEllipsis = true;
            this.lblSpeaksContent.AutoSize = true;
            this.lblSpeaksContent.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeaksContent.Location = new System.Drawing.Point(412, 228);
            this.lblSpeaksContent.Name = "lblSpeaksContent";
            this.lblSpeaksContent.Size = new System.Drawing.Size(0, 16);
            this.lblSpeaksContent.TabIndex = 18;
            // 
            // lblInterestedContent
            // 
            this.lblInterestedContent.AutoEllipsis = true;
            this.lblInterestedContent.AutoSize = true;
            this.lblInterestedContent.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInterestedContent.Location = new System.Drawing.Point(463, 270);
            this.lblInterestedContent.Name = "lblInterestedContent";
            this.lblInterestedContent.Size = new System.Drawing.Size(0, 16);
            this.lblInterestedContent.TabIndex = 19;
            // 
            // Users
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 472);
            this.Controls.Add(this.lblInterestedContent);
            this.Controls.Add(this.lblSpeaksContent);
            this.Controls.Add(this.tboxCity);
            this.Controls.Add(this.tboxBirthDate);
            this.Controls.Add(this.tboxEmail);
            this.Controls.Add(this.lblNameContent);
            this.Controls.Add(this.lblInterested);
            this.Controls.Add(this.lblSpeaks);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.lblBirthDate);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.listUsers);
            this.Name = "Users";
            this.Text = "Users";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox listUsers;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label lblSpeaks;
        private System.Windows.Forms.Label lblInterested;
        private System.Windows.Forms.Label lblBirthDate;
        private System.Windows.Forms.Label lblNameContent;
        private System.Windows.Forms.TextBox tboxEmail;
        private System.Windows.Forms.TextBox tboxBirthDate;
        private System.Windows.Forms.TextBox tboxCity;
        private System.Windows.Forms.Label lblSpeaksContent;
        private System.Windows.Forms.Label lblInterestedContent;
    }
}

