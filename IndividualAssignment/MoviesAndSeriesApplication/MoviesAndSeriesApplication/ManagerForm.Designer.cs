namespace MoviesAndSeriesApplication
{
    partial class ManagerForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.lbCinematicPr = new System.Windows.Forms.ListBox();
            this.btnShowShows = new System.Windows.Forms.Button();
            this.btnShowMovies = new System.Windows.Forms.Button();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tbBudget = new System.Windows.Forms.TextBox();
            this.tbRuntime = new System.Windows.Forms.TextBox();
            this.tbEpisodes = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbSeasons = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.rbTVShow = new System.Windows.Forms.RadioButton();
            this.rbMovie = new System.Windows.Forms.RadioButton();
            this.tbStrPlt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbReleaseDate = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnRemoveUser = new System.Windows.Forms.Button();
            this.lbUsers = new System.Windows.Forms.ListBox();
            this.tbPhoneNumber = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnEditInfo = new System.Windows.Forms.Button();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cpPass = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Search:";
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(128, 22);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(215, 27);
            this.tbSearch.TabIndex = 10;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // lbCinematicPr
            // 
            this.lbCinematicPr.FormattingEnabled = true;
            this.lbCinematicPr.ItemHeight = 20;
            this.lbCinematicPr.Location = new System.Drawing.Point(37, 65);
            this.lbCinematicPr.Name = "lbCinematicPr";
            this.lbCinematicPr.Size = new System.Drawing.Size(306, 324);
            this.lbCinematicPr.TabIndex = 9;
            this.lbCinematicPr.SelectedIndexChanged += new System.EventHandler(this.lbCinematicPr_SelectedIndexChanged);
            // 
            // btnShowShows
            // 
            this.btnShowShows.Location = new System.Drawing.Point(195, 396);
            this.btnShowShows.Name = "btnShowShows";
            this.btnShowShows.Size = new System.Drawing.Size(148, 53);
            this.btnShowShows.TabIndex = 14;
            this.btnShowShows.Text = "Show all TV shows";
            this.btnShowShows.UseVisualStyleBackColor = true;
            this.btnShowShows.Click += new System.EventHandler(this.btnShowShows_Click);
            // 
            // btnShowMovies
            // 
            this.btnShowMovies.Location = new System.Drawing.Point(37, 396);
            this.btnShowMovies.Name = "btnShowMovies";
            this.btnShowMovies.Size = new System.Drawing.Size(152, 53);
            this.btnShowMovies.TabIndex = 13;
            this.btnShowMovies.Text = "Show all movies";
            this.btnShowMovies.UseVisualStyleBackColor = true;
            this.btnShowMovies.Click += new System.EventHandler(this.btnShowMovies_Click);
            // 
            // btnShowAll
            // 
            this.btnShowAll.Location = new System.Drawing.Point(108, 455);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(152, 53);
            this.btnShowAll.TabIndex = 12;
            this.btnShowAll.Text = "Show all ";
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnEdit);
            this.groupBox1.Controls.Add(this.btnRemove);
            this.groupBox1.Controls.Add(this.btnBrowse);
            this.groupBox1.Controls.Add(this.pbImage);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.tbBudget);
            this.groupBox1.Controls.Add(this.tbRuntime);
            this.groupBox1.Controls.Add(this.tbEpisodes);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tbSeasons);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.rbTVShow);
            this.groupBox1.Controls.Add(this.rbMovie);
            this.groupBox1.Controls.Add(this.tbStrPlt);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbReleaseDate);
            this.groupBox1.Controls.Add(this.tbName);
            this.groupBox1.Controls.Add(this.rtbDescription);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(371, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(919, 500);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Adding form";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(536, 97);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(148, 40);
            this.btnClear.TabIndex = 37;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(721, 420);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(148, 40);
            this.btnEdit.TabIndex = 36;
            this.btnEdit.Text = "Edit info";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(721, 363);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(148, 40);
            this.btnRemove.TabIndex = 35;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(536, 36);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(148, 40);
            this.btnBrowse.TabIndex = 34;
            this.btnBrowse.Text = "Browse ";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // pbImage
            // 
            this.pbImage.Location = new System.Drawing.Point(707, 26);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(174, 240);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImage.TabIndex = 33;
            this.pbImage.TabStop = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(721, 305);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(148, 40);
            this.btnAdd.TabIndex = 31;
            this.btnAdd.Text = "Add ";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tbBudget
            // 
            this.tbBudget.Location = new System.Drawing.Point(514, 407);
            this.tbBudget.Name = "tbBudget";
            this.tbBudget.Size = new System.Drawing.Size(125, 27);
            this.tbBudget.TabIndex = 19;
            // 
            // tbRuntime
            // 
            this.tbRuntime.Location = new System.Drawing.Point(367, 407);
            this.tbRuntime.Name = "tbRuntime";
            this.tbRuntime.Size = new System.Drawing.Size(125, 27);
            this.tbRuntime.TabIndex = 18;
            // 
            // tbEpisodes
            // 
            this.tbEpisodes.Location = new System.Drawing.Point(514, 318);
            this.tbEpisodes.Name = "tbEpisodes";
            this.tbEpisodes.Size = new System.Drawing.Size(125, 27);
            this.tbEpisodes.TabIndex = 30;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(514, 373);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 20);
            this.label8.TabIndex = 17;
            this.label8.Text = "Budget:";
            // 
            // tbSeasons
            // 
            this.tbSeasons.Location = new System.Drawing.Point(365, 318);
            this.tbSeasons.Name = "tbSeasons";
            this.tbSeasons.Size = new System.Drawing.Size(125, 27);
            this.tbSeasons.TabIndex = 29;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(367, 373);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 20);
            this.label9.TabIndex = 16;
            this.label9.Text = "Runtime:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(514, 292);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 20);
            this.label5.TabIndex = 28;
            this.label5.Text = "Episodes:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(365, 295);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 20);
            this.label7.TabIndex = 27;
            this.label7.Text = "Seasons:";
            // 
            // rbTVShow
            // 
            this.rbTVShow.AutoSize = true;
            this.rbTVShow.Location = new System.Drawing.Point(124, 52);
            this.rbTVShow.Name = "rbTVShow";
            this.rbTVShow.Size = new System.Drawing.Size(87, 24);
            this.rbTVShow.TabIndex = 26;
            this.rbTVShow.TabStop = true;
            this.rbTVShow.Text = "TV Show";
            this.rbTVShow.UseVisualStyleBackColor = true;
            this.rbTVShow.CheckedChanged += new System.EventHandler(this.rbTVShow_CheckedChanged);
            // 
            // rbMovie
            // 
            this.rbMovie.AutoSize = true;
            this.rbMovie.Location = new System.Drawing.Point(24, 52);
            this.rbMovie.Name = "rbMovie";
            this.rbMovie.Size = new System.Drawing.Size(71, 24);
            this.rbMovie.TabIndex = 25;
            this.rbMovie.TabStop = true;
            this.rbMovie.Text = "Movie";
            this.rbMovie.UseVisualStyleBackColor = true;
            this.rbMovie.CheckedChanged += new System.EventHandler(this.rbMovie_CheckedChanged);
            // 
            // tbStrPlt
            // 
            this.tbStrPlt.Location = new System.Drawing.Point(365, 239);
            this.tbStrPlt.Name = "tbStrPlt";
            this.tbStrPlt.Size = new System.Drawing.Size(125, 27);
            this.tbStrPlt.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(365, 216);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 20);
            this.label6.TabIndex = 23;
            this.label6.Text = "Streaming platform:";
            // 
            // tbReleaseDate
            // 
            this.tbReleaseDate.Location = new System.Drawing.Point(514, 239);
            this.tbReleaseDate.Name = "tbReleaseDate";
            this.tbReleaseDate.Size = new System.Drawing.Size(125, 27);
            this.tbReleaseDate.TabIndex = 22;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(23, 130);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(381, 27);
            this.tbName.TabIndex = 21;
            // 
            // rtbDescription
            // 
            this.rtbDescription.Location = new System.Drawing.Point(23, 225);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.Size = new System.Drawing.Size(319, 222);
            this.rtbDescription.TabIndex = 20;
            this.rtbDescription.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(514, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 20);
            this.label3.TabIndex = 19;
            this.label3.Text = "Release date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "Description:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 20);
            this.label4.TabIndex = 17;
            this.label4.Text = "Name:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1342, 559);
            this.tabControl1.TabIndex = 16;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnShowAll);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.tbSearch);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.lbCinematicPr);
            this.tabPage1.Controls.Add(this.btnShowShows);
            this.tabPage1.Controls.Add(this.btnShowMovies);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1334, 526);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Cinematic productions";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cpPass);
            this.tabPage2.Controls.Add(this.btnRemoveUser);
            this.tabPage2.Controls.Add(this.lbUsers);
            this.tabPage2.Controls.Add(this.tbPhoneNumber);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.btnLogOut);
            this.tabPage2.Controls.Add(this.btnEditInfo);
            this.tabPage2.Controls.Add(this.tbPassword);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.tbUsername);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1334, 526);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Account settings";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnRemoveUser
            // 
            this.btnRemoveUser.Location = new System.Drawing.Point(783, 383);
            this.btnRemoveUser.Name = "btnRemoveUser";
            this.btnRemoveUser.Size = new System.Drawing.Size(166, 54);
            this.btnRemoveUser.TabIndex = 19;
            this.btnRemoveUser.Text = "Remove user";
            this.btnRemoveUser.UseVisualStyleBackColor = true;
            this.btnRemoveUser.Click += new System.EventHandler(this.btnRemoveUser_Click);
            // 
            // lbUsers
            // 
            this.lbUsers.FormattingEnabled = true;
            this.lbUsers.ItemHeight = 20;
            this.lbUsers.Location = new System.Drawing.Point(713, 54);
            this.lbUsers.Name = "lbUsers";
            this.lbUsers.Size = new System.Drawing.Size(280, 304);
            this.lbUsers.TabIndex = 18;
            this.lbUsers.SelectedIndexChanged += new System.EventHandler(this.lbUsers_SelectedIndexChanged);
            // 
            // tbPhoneNumber
            // 
            this.tbPhoneNumber.Location = new System.Drawing.Point(172, 238);
            this.tbPhoneNumber.Name = "tbPhoneNumber";
            this.tbPhoneNumber.Size = new System.Drawing.Size(244, 27);
            this.tbPhoneNumber.TabIndex = 17;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(40, 245);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(108, 20);
            this.label13.TabIndex = 16;
            this.label13.Text = "Phone number:";
            // 
            // btnLogOut
            // 
            this.btnLogOut.Location = new System.Drawing.Point(1099, 407);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(166, 54);
            this.btnLogOut.TabIndex = 15;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnEditInfo
            // 
            this.btnEditInfo.Location = new System.Drawing.Point(128, 338);
            this.btnEditInfo.Name = "btnEditInfo";
            this.btnEditInfo.Size = new System.Drawing.Size(166, 54);
            this.btnEditInfo.TabIndex = 14;
            this.btnEditInfo.Text = "Edit";
            this.btnEditInfo.UseVisualStyleBackColor = true;
            this.btnEditInfo.Click += new System.EventHandler(this.btnEditInfo_Click);
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(172, 152);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(244, 27);
            this.tbPassword.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(40, 159);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 20);
            this.label11.TabIndex = 10;
            this.label11.Text = "Password:";
            // 
            // tbUsername
            // 
            this.tbUsername.Location = new System.Drawing.Point(172, 80);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(244, 27);
            this.tbUsername.TabIndex = 9;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(40, 83);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 20);
            this.label12.TabIndex = 8;
            this.label12.Text = "Username:";
            // 
            // cpPass
            // 
            this.cpPass.AutoSize = true;
            this.cpPass.Location = new System.Drawing.Point(439, 155);
            this.cpPass.Name = "cpPass";
            this.cpPass.Size = new System.Drawing.Size(134, 24);
            this.cpPass.TabIndex = 20;
            this.cpPass.Text = "Show password";
            this.cpPass.UseVisualStyleBackColor = true;
            this.cpPass.CheckedChanged += new System.EventHandler(this.cpPass_CheckedChanged);
            // 
            // ManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 580);
            this.Controls.Add(this.tabControl1);
            this.Name = "ManagerForm";
            this.Text = "ManagerForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Label label1;
        private TextBox tbSearch;
        private ListBox lbCinematicPr;
        private Button btnShowShows;
        private Button btnShowMovies;
        private Button btnShowAll;
        private GroupBox groupBox1;
        private RadioButton rbTVShow;
        private RadioButton rbMovie;
        private TextBox tbStrPlt;
        private Label label6;
        private TextBox tbReleaseDate;
        private TextBox tbName;
        private RichTextBox rtbDescription;
        private Label label3;
        private Label label2;
        private Label label4;
        private TextBox tbEpisodes;
        private TextBox tbSeasons;
        private Label label5;
        private Label label7;
        private TextBox tbBudget;
        private TextBox tbRuntime;
        private Label label8;
        private Label label9;
        private Button btnAdd;
        private Button btnBrowse;
        private PictureBox pbImage;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button btnLogOut;
        private Button btnEditInfo;
        private TextBox tbPassword;
        private Label label11;
        private TextBox tbUsername;
        private Label label12;
        private TextBox tbPhoneNumber;
        private Label label13;
        private Button btnRemove;
        private Button btnEdit;
        private Button btnClear;
        private Button btnRemoveUser;
        private ListBox lbUsers;
        private CheckBox cpPass;
    }
}