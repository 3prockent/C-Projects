namespace Lab2_XML
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Search = new System.Windows.Forms.Button();
            this.Transform = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.GenreCheck = new System.Windows.Forms.CheckBox();
            this.BandNameCheck = new System.Windows.Forms.CheckBox();
            this.AlbumCheck = new System.Windows.Forms.CheckBox();
            this.SongNameCheck = new System.Windows.Forms.CheckBox();
            this.DurationCheck = new System.Windows.Forms.CheckBox();
            this.ReleaseYearCheck = new System.Windows.Forms.CheckBox();
            this.GenreBox = new System.Windows.Forms.ComboBox();
            this.BandNameBox = new System.Windows.Forms.ComboBox();
            this.AlbumBox = new System.Windows.Forms.ComboBox();
            this.SongNameBox = new System.Windows.Forms.ComboBox();
            this.DurationBox = new System.Windows.Forms.ComboBox();
            this.ReleaseYearBox = new System.Windows.Forms.ComboBox();
            this.SAX = new System.Windows.Forms.RadioButton();
            this.DOM = new System.Windows.Forms.RadioButton();
            this.LINQ = new System.Windows.Forms.RadioButton();
            this.ResultBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(15, 499);
            this.Search.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(106, 49);
            this.Search.TabIndex = 0;
            this.Search.Text = "Search";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // Transform
            // 
            this.Transform.Location = new System.Drawing.Point(150, 499);
            this.Transform.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Transform.Name = "Transform";
            this.Transform.Size = new System.Drawing.Size(130, 49);
            this.Transform.TabIndex = 1;
            this.Transform.Text = "Transform";
            this.Transform.UseVisualStyleBackColor = true;
            this.Transform.Click += new System.EventHandler(this.Transform_Click);
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(310, 499);
            this.Clear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(135, 49);
            this.Clear.TabIndex = 2;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // GenreCheck
            // 
            this.GenreCheck.AutoSize = true;
            this.GenreCheck.Location = new System.Drawing.Point(36, 42);
            this.GenreCheck.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GenreCheck.Name = "GenreCheck";
            this.GenreCheck.Size = new System.Drawing.Size(84, 29);
            this.GenreCheck.TabIndex = 3;
            this.GenreCheck.Text = "Genre";
            this.GenreCheck.UseVisualStyleBackColor = true;
            this.GenreCheck.CheckedChanged += new System.EventHandler(this.Genre_CheckedChanged);
            // 
            // BandNameCheck
            // 
            this.BandNameCheck.AutoSize = true;
            this.BandNameCheck.Location = new System.Drawing.Point(36, 101);
            this.BandNameCheck.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BandNameCheck.Name = "BandNameCheck";
            this.BandNameCheck.Size = new System.Drawing.Size(130, 29);
            this.BandNameCheck.TabIndex = 4;
            this.BandNameCheck.Text = "Band Name";
            this.BandNameCheck.UseVisualStyleBackColor = true;
            // 
            // AlbumCheck
            // 
            this.AlbumCheck.AutoSize = true;
            this.AlbumCheck.Location = new System.Drawing.Point(36, 162);
            this.AlbumCheck.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AlbumCheck.Name = "AlbumCheck";
            this.AlbumCheck.Size = new System.Drawing.Size(91, 29);
            this.AlbumCheck.TabIndex = 5;
            this.AlbumCheck.Text = "Album";
            this.AlbumCheck.UseVisualStyleBackColor = true;
            // 
            // SongNameCheck
            // 
            this.SongNameCheck.AutoSize = true;
            this.SongNameCheck.Location = new System.Drawing.Point(36, 221);
            this.SongNameCheck.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SongNameCheck.Name = "SongNameCheck";
            this.SongNameCheck.Size = new System.Drawing.Size(132, 29);
            this.SongNameCheck.TabIndex = 6;
            this.SongNameCheck.Text = "Song Name";
            this.SongNameCheck.UseVisualStyleBackColor = true;
            // 
            // DurationCheck
            // 
            this.DurationCheck.AutoSize = true;
            this.DurationCheck.Location = new System.Drawing.Point(36, 282);
            this.DurationCheck.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DurationCheck.Name = "DurationCheck";
            this.DurationCheck.Size = new System.Drawing.Size(107, 29);
            this.DurationCheck.TabIndex = 7;
            this.DurationCheck.Text = "Duration";
            this.DurationCheck.UseVisualStyleBackColor = true;
            // 
            // ReleaseYearCheck
            // 
            this.ReleaseYearCheck.AutoSize = true;
            this.ReleaseYearCheck.Location = new System.Drawing.Point(36, 340);
            this.ReleaseYearCheck.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ReleaseYearCheck.Name = "ReleaseYearCheck";
            this.ReleaseYearCheck.Size = new System.Drawing.Size(133, 29);
            this.ReleaseYearCheck.TabIndex = 8;
            this.ReleaseYearCheck.Text = "Release Year";
            this.ReleaseYearCheck.UseVisualStyleBackColor = true;
            // 
            // GenreBox
            // 
            this.GenreBox.FormattingEnabled = true;
            this.GenreBox.Location = new System.Drawing.Point(194, 42);
            this.GenreBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GenreBox.Name = "GenreBox";
            this.GenreBox.Size = new System.Drawing.Size(214, 33);
            this.GenreBox.Sorted = true;
            this.GenreBox.TabIndex = 9;
            // 
            // BandNameBox
            // 
            this.BandNameBox.FormattingEnabled = true;
            this.BandNameBox.Location = new System.Drawing.Point(194, 101);
            this.BandNameBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BandNameBox.Name = "BandNameBox";
            this.BandNameBox.Size = new System.Drawing.Size(214, 33);
            this.BandNameBox.Sorted = true;
            this.BandNameBox.TabIndex = 10;
            // 
            // AlbumBox
            // 
            this.AlbumBox.FormattingEnabled = true;
            this.AlbumBox.Location = new System.Drawing.Point(194, 160);
            this.AlbumBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AlbumBox.Name = "AlbumBox";
            this.AlbumBox.Size = new System.Drawing.Size(214, 33);
            this.AlbumBox.Sorted = true;
            this.AlbumBox.TabIndex = 11;
            // 
            // SongNameBox
            // 
            this.SongNameBox.FormattingEnabled = true;
            this.SongNameBox.Location = new System.Drawing.Point(194, 219);
            this.SongNameBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SongNameBox.Name = "SongNameBox";
            this.SongNameBox.Size = new System.Drawing.Size(214, 33);
            this.SongNameBox.Sorted = true;
            this.SongNameBox.TabIndex = 12;
            // 
            // DurationBox
            // 
            this.DurationBox.FormattingEnabled = true;
            this.DurationBox.Location = new System.Drawing.Point(194, 282);
            this.DurationBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DurationBox.Name = "DurationBox";
            this.DurationBox.Size = new System.Drawing.Size(214, 33);
            this.DurationBox.TabIndex = 13;
            // 
            // ReleaseYearBox
            // 
            this.ReleaseYearBox.FormattingEnabled = true;
            this.ReleaseYearBox.Location = new System.Drawing.Point(194, 340);
            this.ReleaseYearBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ReleaseYearBox.Name = "ReleaseYearBox";
            this.ReleaseYearBox.Size = new System.Drawing.Size(214, 33);
            this.ReleaseYearBox.Sorted = true;
            this.ReleaseYearBox.TabIndex = 14;
            // 
            // SAX
            // 
            this.SAX.AutoSize = true;
            this.SAX.Location = new System.Drawing.Point(15, 425);
            this.SAX.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SAX.Name = "SAX";
            this.SAX.Size = new System.Drawing.Size(70, 29);
            this.SAX.TabIndex = 15;
            this.SAX.TabStop = true;
            this.SAX.Text = "SAX";
            this.SAX.UseVisualStyleBackColor = true;
            // 
            // DOM
            // 
            this.DOM.AutoSize = true;
            this.DOM.Location = new System.Drawing.Point(150, 425);
            this.DOM.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DOM.Name = "DOM";
            this.DOM.Size = new System.Drawing.Size(80, 29);
            this.DOM.TabIndex = 16;
            this.DOM.TabStop = true;
            this.DOM.Text = "DOM";
            this.DOM.UseVisualStyleBackColor = true;
            // 
            // LINQ
            // 
            this.LINQ.AutoSize = true;
            this.LINQ.Location = new System.Drawing.Point(292, 425);
            this.LINQ.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LINQ.Name = "LINQ";
            this.LINQ.Size = new System.Drawing.Size(77, 29);
            this.LINQ.TabIndex = 17;
            this.LINQ.TabStop = true;
            this.LINQ.Text = "LINQ";
            this.LINQ.UseVisualStyleBackColor = true;
            // 
            // ResultBox
            // 
            this.ResultBox.Location = new System.Drawing.Point(474, 15);
            this.ResultBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ResultBox.Name = "ResultBox";
            this.ResultBox.Size = new System.Drawing.Size(434, 536);
            this.ResultBox.TabIndex = 18;
            this.ResultBox.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 562);
            this.Controls.Add(this.ResultBox);
            this.Controls.Add(this.LINQ);
            this.Controls.Add(this.DOM);
            this.Controls.Add(this.SAX);
            this.Controls.Add(this.ReleaseYearBox);
            this.Controls.Add(this.DurationBox);
            this.Controls.Add(this.SongNameBox);
            this.Controls.Add(this.AlbumBox);
            this.Controls.Add(this.BandNameBox);
            this.Controls.Add(this.GenreBox);
            this.Controls.Add(this.ReleaseYearCheck);
            this.Controls.Add(this.DurationCheck);
            this.Controls.Add(this.SongNameCheck);
            this.Controls.Add(this.AlbumCheck);
            this.Controls.Add(this.BandNameCheck);
            this.Controls.Add(this.GenreCheck);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.Transform);
            this.Controls.Add(this.Search);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.Button Transform;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.CheckBox GenreCheck;
        private System.Windows.Forms.CheckBox BandNameCheck;
        private System.Windows.Forms.CheckBox AlbumCheck;
        private System.Windows.Forms.CheckBox SongNameCheck;
        private System.Windows.Forms.CheckBox DurationCheck;
        private System.Windows.Forms.ComboBox GenreBox;
        private System.Windows.Forms.ComboBox BandNameBox;
        private System.Windows.Forms.ComboBox AlbumBox;
        private System.Windows.Forms.ComboBox SongNameBox;
        private System.Windows.Forms.ComboBox DurationBox;
        private System.Windows.Forms.ComboBox ReleaseYearBox;
        private System.Windows.Forms.RadioButton SAX;
        private System.Windows.Forms.RadioButton DOM;
        private System.Windows.Forms.RadioButton LINQ;
        private System.Windows.Forms.RichTextBox ResultBox;
        private System.Windows.Forms.CheckBox ReleaseYearCheck;
    }
}