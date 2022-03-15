namespace MoviesAndSeriesApplication
{
    partial class TVShowInfo
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
            this.tbReleaseDate = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbStrPlt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbEpisodes = new System.Windows.Forms.TextBox();
            this.tbSeasons = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pbTVShow = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbTVShow)).BeginInit();
            this.SuspendLayout();
            // 
            // tbReleaseDate
            // 
            this.tbReleaseDate.Location = new System.Drawing.Point(250, 161);
            this.tbReleaseDate.Name = "tbReleaseDate";
            this.tbReleaseDate.Size = new System.Drawing.Size(125, 27);
            this.tbReleaseDate.TabIndex = 14;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(250, 65);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(334, 27);
            this.tbName.TabIndex = 13;
            // 
            // rtbDescription
            // 
            this.rtbDescription.Location = new System.Drawing.Point(58, 329);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.Size = new System.Drawing.Size(343, 186);
            this.rtbDescription.TabIndex = 12;
            this.rtbDescription.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(250, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Release date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 306);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Description:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(250, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Name:";
            // 
            // tbStrPlt
            // 
            this.tbStrPlt.Location = new System.Drawing.Point(250, 239);
            this.tbStrPlt.Name = "tbStrPlt";
            this.tbStrPlt.Size = new System.Drawing.Size(125, 27);
            this.tbStrPlt.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(250, 216);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "Streaming platform:";
            // 
            // tbEpisodes
            // 
            this.tbEpisodes.Location = new System.Drawing.Point(459, 239);
            this.tbEpisodes.Name = "tbEpisodes";
            this.tbEpisodes.Size = new System.Drawing.Size(125, 27);
            this.tbEpisodes.TabIndex = 20;
            // 
            // tbSeasons
            // 
            this.tbSeasons.Location = new System.Drawing.Point(459, 161);
            this.tbSeasons.Name = "tbSeasons";
            this.tbSeasons.Size = new System.Drawing.Size(125, 27);
            this.tbSeasons.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(459, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 20);
            this.label5.TabIndex = 18;
            this.label5.Text = "Episodes:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(459, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 17;
            this.label4.Text = "Seasons:";
            // 
            // pbTVShow
            // 
            this.pbTVShow.Location = new System.Drawing.Point(58, 26);
            this.pbTVShow.Name = "pbTVShow";
            this.pbTVShow.Size = new System.Drawing.Size(174, 240);
            this.pbTVShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTVShow.TabIndex = 21;
            this.pbTVShow.TabStop = false;
            // 
            // TVShowInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 527);
            this.Controls.Add(this.pbTVShow);
            this.Controls.Add(this.tbEpisodes);
            this.Controls.Add(this.tbSeasons);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbStrPlt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbReleaseDate);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.rtbDescription);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "TVShowInfo";
            this.Text = "TVShowInfo";
            this.Load += new System.EventHandler(this.TVShowInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbTVShow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox tbReleaseDate;
        private TextBox tbName;
        private RichTextBox rtbDescription;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox tbStrPlt;
        private Label label6;
        private TextBox tbEpisodes;
        private TextBox tbSeasons;
        private Label label5;
        private Label label4;
        private PictureBox pbTVShow;
    }
}