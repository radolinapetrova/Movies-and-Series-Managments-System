namespace MoviesAndSeriesApplication
{
    partial class CPInfo
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbReleaseDate = new System.Windows.Forms.TextBox();
            this.tb2 = new System.Windows.Forms.TextBox();
            this.tb1 = new System.Windows.Forms.TextBox();
            this.tbStrPlt = new System.Windows.Forms.TextBox();
            this.pbMovie = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbMovie)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(280, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 309);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Description:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(280, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Release date:";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(467, 200);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(13, 20);
            this.lbl2.TabIndex = 3;
            this.lbl2.Text = "!";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(467, 116);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(13, 20);
            this.lbl1.TabIndex = 4;
            this.lbl1.Text = "!";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(280, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Streaming platform:";
            // 
            // rtbDescription
            // 
            this.rtbDescription.Location = new System.Drawing.Point(77, 332);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.ReadOnly = true;
            this.rtbDescription.Size = new System.Drawing.Size(328, 186);
            this.rtbDescription.TabIndex = 6;
            this.rtbDescription.Text = "";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(280, 52);
            this.tbName.Name = "tbName";
            this.tbName.ReadOnly = true;
            this.tbName.Size = new System.Drawing.Size(312, 27);
            this.tbName.TabIndex = 7;
            // 
            // tbReleaseDate
            // 
            this.tbReleaseDate.Location = new System.Drawing.Point(280, 136);
            this.tbReleaseDate.Name = "tbReleaseDate";
            this.tbReleaseDate.ReadOnly = true;
            this.tbReleaseDate.Size = new System.Drawing.Size(125, 27);
            this.tbReleaseDate.TabIndex = 8;
            // 
            // tb2
            // 
            this.tb2.Location = new System.Drawing.Point(467, 223);
            this.tb2.Name = "tb2";
            this.tb2.ReadOnly = true;
            this.tb2.Size = new System.Drawing.Size(125, 27);
            this.tb2.TabIndex = 9;
            // 
            // tb1
            // 
            this.tb1.Location = new System.Drawing.Point(467, 139);
            this.tb1.Name = "tb1";
            this.tb1.ReadOnly = true;
            this.tb1.Size = new System.Drawing.Size(125, 27);
            this.tb1.TabIndex = 10;
            // 
            // tbStrPlt
            // 
            this.tbStrPlt.Location = new System.Drawing.Point(280, 223);
            this.tbStrPlt.Name = "tbStrPlt";
            this.tbStrPlt.ReadOnly = true;
            this.tbStrPlt.Size = new System.Drawing.Size(125, 27);
            this.tbStrPlt.TabIndex = 11;
            // 
            // pbMovie
            // 
            this.pbMovie.Image = global::MoviesAndSeriesApplication.Properties.Resources.no_image;
            this.pbMovie.Location = new System.Drawing.Point(77, 29);
            this.pbMovie.Name = "pbMovie";
            this.pbMovie.Size = new System.Drawing.Size(174, 240);
            this.pbMovie.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMovie.TabIndex = 12;
            this.pbMovie.TabStop = false;
            // 
            // CPInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 530);
            this.Controls.Add(this.pbMovie);
            this.Controls.Add(this.tbStrPlt);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.tb2);
            this.Controls.Add(this.tbReleaseDate);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.rtbDescription);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CPInfo";
            this.Text = "MovieInfo";
            this.Load += new System.EventHandler(this.MovieInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbMovie)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label lbl2;
        private Label lbl1;
        private Label label6;
        private RichTextBox rtbDescription;
        private TextBox tbName;
        private TextBox tbReleaseDate;
        private TextBox tb2;
        private TextBox tb1;
        private TextBox tbStrPlt;
        private PictureBox pbMovie;
    }
}