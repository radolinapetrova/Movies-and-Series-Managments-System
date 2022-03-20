namespace MoviesAndSeriesApplication
{
    partial class MainMenu
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
            this.lbCinematicPr = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbStreamingPlatform = new System.Windows.Forms.TextBox();
            this.tbReleaseDate = new System.Windows.Forms.TextBox();
            this.lblStreamingPlatform = new System.Windows.Forms.Label();
            this.lblReleaseDate = new System.Windows.Forms.Label();
            this.btnAdditionalInfo = new System.Windows.Forms.Button();
            this.rtbInfo = new System.Windows.Forms.RichTextBox();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cmbFilter = new System.Windows.Forms.ComboBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.btnShowShows = new System.Windows.Forms.Button();
            this.btnShowMovies = new System.Windows.Forms.Button();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tbPhoneNumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnEditInfo = new System.Windows.Forms.Button();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbCinematicPr
            // 
            this.lbCinematicPr.FormattingEnabled = true;
            this.lbCinematicPr.ItemHeight = 20;
            this.lbCinematicPr.Location = new System.Drawing.Point(27, 102);
            this.lbCinematicPr.Name = "lbCinematicPr";
            this.lbCinematicPr.Size = new System.Drawing.Size(306, 324);
            this.lbCinematicPr.TabIndex = 0;
            this.lbCinematicPr.SelectedIndexChanged += new System.EventHandler(this.lbCinematicPr_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbStreamingPlatform);
            this.groupBox1.Controls.Add(this.tbReleaseDate);
            this.groupBox1.Controls.Add(this.lblStreamingPlatform);
            this.groupBox1.Controls.Add(this.lblReleaseDate);
            this.groupBox1.Controls.Add(this.btnAdditionalInfo);
            this.groupBox1.Controls.Add(this.rtbInfo);
            this.groupBox1.Location = new System.Drawing.Point(635, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(426, 400);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Info";
            // 
            // tbStreamingPlatform
            // 
            this.tbStreamingPlatform.Location = new System.Drawing.Point(193, 300);
            this.tbStreamingPlatform.Name = "tbStreamingPlatform";
            this.tbStreamingPlatform.ReadOnly = true;
            this.tbStreamingPlatform.Size = new System.Drawing.Size(215, 27);
            this.tbStreamingPlatform.TabIndex = 11;
            this.tbStreamingPlatform.Visible = false;
            // 
            // tbReleaseDate
            // 
            this.tbReleaseDate.Location = new System.Drawing.Point(193, 253);
            this.tbReleaseDate.Name = "tbReleaseDate";
            this.tbReleaseDate.ReadOnly = true;
            this.tbReleaseDate.Size = new System.Drawing.Size(215, 27);
            this.tbReleaseDate.TabIndex = 9;
            this.tbReleaseDate.Visible = false;
            // 
            // lblStreamingPlatform
            // 
            this.lblStreamingPlatform.AutoSize = true;
            this.lblStreamingPlatform.Location = new System.Drawing.Point(41, 303);
            this.lblStreamingPlatform.Name = "lblStreamingPlatform";
            this.lblStreamingPlatform.Size = new System.Drawing.Size(146, 20);
            this.lblStreamingPlatform.TabIndex = 9;
            this.lblStreamingPlatform.Text = "Streaming platform: ";
            this.lblStreamingPlatform.Visible = false;
            // 
            // lblReleaseDate
            // 
            this.lblReleaseDate.AutoSize = true;
            this.lblReleaseDate.Location = new System.Drawing.Point(86, 260);
            this.lblReleaseDate.Name = "lblReleaseDate";
            this.lblReleaseDate.Size = new System.Drawing.Size(101, 20);
            this.lblReleaseDate.TabIndex = 10;
            this.lblReleaseDate.Text = "Release date: ";
            this.lblReleaseDate.Visible = false;
            // 
            // btnAdditionalInfo
            // 
            this.btnAdditionalInfo.Location = new System.Drawing.Point(55, 358);
            this.btnAdditionalInfo.Name = "btnAdditionalInfo";
            this.btnAdditionalInfo.Size = new System.Drawing.Size(329, 28);
            this.btnAdditionalInfo.TabIndex = 9;
            this.btnAdditionalInfo.Text = "Show additional information";
            this.btnAdditionalInfo.UseVisualStyleBackColor = true;
            this.btnAdditionalInfo.Visible = false;
            this.btnAdditionalInfo.Click += new System.EventHandler(this.btnAdditionalInfo_Click);
            // 
            // rtbInfo
            // 
            this.rtbInfo.Location = new System.Drawing.Point(19, 29);
            this.rtbInfo.Name = "rtbInfo";
            this.rtbInfo.ReadOnly = true;
            this.rtbInfo.Size = new System.Drawing.Size(386, 190);
            this.rtbInfo.TabIndex = 0;
            this.rtbInfo.Text = "";
            this.rtbInfo.Visible = false;
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(118, 49);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(215, 27);
            this.tbSearch.TabIndex = 7;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Search:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1100, 505);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cmbFilter);
            this.tabPage1.Controls.Add(this.lblFilter);
            this.tabPage1.Controls.Add(this.btnShowShows);
            this.tabPage1.Controls.Add(this.btnShowMovies);
            this.tabPage1.Controls.Add(this.btnShowAll);
            this.tabPage1.Controls.Add(this.lbCinematicPr);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.tbSearch);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1092, 472);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Movie/TV Show";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cmbFilter
            // 
            this.cmbFilter.FormattingEnabled = true;
            this.cmbFilter.Items.AddRange(new object[] {
            "Name ASC",
            "Name DESC",
            "Release date ASC",
            "Release date DESC"});
            this.cmbFilter.Location = new System.Drawing.Point(445, 106);
            this.cmbFilter.Name = "cmbFilter";
            this.cmbFilter.Size = new System.Drawing.Size(151, 28);
            this.cmbFilter.TabIndex = 13;
            this.cmbFilter.SelectedIndexChanged += new System.EventHandler(this.cmbFilter_SelectedIndexChanged_1);
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(358, 109);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(45, 20);
            this.lblFilter.TabIndex = 12;
            this.lblFilter.Text = "Filter:";
            // 
            // btnShowShows
            // 
            this.btnShowShows.Location = new System.Drawing.Point(416, 369);
            this.btnShowShows.Name = "btnShowShows";
            this.btnShowShows.Size = new System.Drawing.Size(152, 53);
            this.btnShowShows.TabIndex = 11;
            this.btnShowShows.Text = "Show all TV shows";
            this.btnShowShows.UseVisualStyleBackColor = true;
            this.btnShowShows.Click += new System.EventHandler(this.btnShowShows_Click_1);
            // 
            // btnShowMovies
            // 
            this.btnShowMovies.Location = new System.Drawing.Point(416, 291);
            this.btnShowMovies.Name = "btnShowMovies";
            this.btnShowMovies.Size = new System.Drawing.Size(152, 53);
            this.btnShowMovies.TabIndex = 10;
            this.btnShowMovies.Text = "Show all movies";
            this.btnShowMovies.UseVisualStyleBackColor = true;
            this.btnShowMovies.Click += new System.EventHandler(this.btnShowMovies_Click_1);
            // 
            // btnShowAll
            // 
            this.btnShowAll.Location = new System.Drawing.Point(416, 210);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(152, 53);
            this.btnShowAll.TabIndex = 9;
            this.btnShowAll.Text = "Show all ";
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click_1);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tbPhoneNumber);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.btnLogOut);
            this.tabPage2.Controls.Add(this.btnEditInfo);
            this.tabPage2.Controls.Add(this.tbEmail);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.tbPassword);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.tbUsername);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1092, 472);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Account settings";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tbPhoneNumber
            // 
            this.tbPhoneNumber.Location = new System.Drawing.Point(160, 284);
            this.tbPhoneNumber.Name = "tbPhoneNumber";
            this.tbPhoneNumber.Size = new System.Drawing.Size(244, 27);
            this.tbPhoneNumber.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 291);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Phone number:";
            // 
            // btnLogOut
            // 
            this.btnLogOut.Location = new System.Drawing.Point(879, 381);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(166, 54);
            this.btnLogOut.TabIndex = 7;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnEditInfo
            // 
            this.btnEditInfo.Location = new System.Drawing.Point(103, 381);
            this.btnEditInfo.Name = "btnEditInfo";
            this.btnEditInfo.Size = new System.Drawing.Size(166, 54);
            this.btnEditInfo.TabIndex = 6;
            this.btnEditInfo.Text = "Edit";
            this.btnEditInfo.UseVisualStyleBackColor = true;
            this.btnEditInfo.Click += new System.EventHandler(this.btnEditInfo_Click);
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(160, 219);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(244, 27);
            this.tbEmail.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 222);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Email:";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(160, 138);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(244, 27);
            this.tbPassword.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password:";
            // 
            // tbUsername
            // 
            this.tbUsername.Location = new System.Drawing.Point(160, 66);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(244, 27);
            this.tbUsername.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Username:";
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1117, 519);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ListBox lbCinematicPr;
        private GroupBox groupBox1;
        private TextBox tbStreamingPlatform;
        private TextBox tbReleaseDate;
        private Label lblStreamingPlatform;
        private Label lblReleaseDate;
        private Button btnAdditionalInfo;
        private RichTextBox rtbInfo;
        private TextBox tbSearch;
        private Label label1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private ComboBox cmbFilter;
        private Label lblFilter;
        private Button btnShowShows;
        private Button btnShowMovies;
        private Button btnShowAll;
        private TabPage tabPage2;
        private Label label2;
        private Button btnEditInfo;
        private TextBox tbEmail;
        private Label label4;
        private TextBox tbPassword;
        private Label label3;
        private TextBox tbUsername;
        private Button btnLogOut;
        private TextBox tbPhoneNumber;
        private Label label5;
    }
}