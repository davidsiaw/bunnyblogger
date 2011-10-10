namespace WordLaunch
{
    partial class WordLaunch
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WordLaunch));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.geckoWebBrowser1 = new Skybound.Gecko.GeckoWebBrowser();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.txt_Title = new System.Windows.Forms.TextBox();
            this.txt_Content = new ScintillaNet.Scintilla();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_SnapVideoFrame = new System.Windows.Forms.Button();
            this.btn_OpenVideo = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_NewPost = new System.Windows.Forms.Button();
            this.btn_SaveDraft = new System.Windows.Forms.Button();
            this.btn_PublishPost = new System.Windows.Forms.Button();
            this.btn_AddImage = new System.Windows.Forms.Button();
            this.btn_LoadDraft = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_InsertBreak = new System.Windows.Forms.Button();
            this.btn_addpics = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.list_images = new System.Windows.Forms.ListView();
            this.ilist_thumbnails = new System.Windows.Forms.ImageList(this.components);
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.flow_Categories = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.flow_tags = new System.Windows.Forms.FlowLayoutPanel();
            this.txt_tags = new System.Windows.Forms.TextBox();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Content)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1051, 711);
            this.splitContainer1.SplitterDistance = 849;
            this.splitContainer1.TabIndex = 0;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(849, 711);
            this.tabControl2.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.splitContainer2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(841, 685);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Post Editor";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.geckoWebBrowser1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(835, 679);
            this.splitContainer2.SplitterDistance = 465;
            this.splitContainer2.TabIndex = 0;
            // 
            // geckoWebBrowser1
            // 
            this.geckoWebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.geckoWebBrowser1.Location = new System.Drawing.Point(0, 0);
            this.geckoWebBrowser1.Name = "geckoWebBrowser1";
            this.geckoWebBrowser1.Size = new System.Drawing.Size(835, 465);
            this.geckoWebBrowser1.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3.IsSplitterFixed = true;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.txt_Title);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.txt_Content);
            this.splitContainer3.Size = new System.Drawing.Size(835, 210);
            this.splitContainer3.SplitterDistance = 25;
            this.splitContainer3.TabIndex = 1;
            // 
            // txt_Title
            // 
            this.txt_Title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Title.Location = new System.Drawing.Point(0, 0);
            this.txt_Title.Name = "txt_Title";
            this.txt_Title.Size = new System.Drawing.Size(835, 20);
            this.txt_Title.TabIndex = 0;
            this.txt_Title.TextChanged += new System.EventHandler(this.txt_Title_TextChanged);
            // 
            // txt_Content
            // 
            this.txt_Content.ConfigurationManager.ClearMarkers = true;
            this.txt_Content.ConfigurationManager.Language = "html";
            this.txt_Content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Content.DocumentNavigation.MaxHistorySize = 200;
            this.txt_Content.Font = new System.Drawing.Font("MS PGothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Content.LineWrap.Mode = ScintillaNet.WrapMode.Word;
            this.txt_Content.Location = new System.Drawing.Point(0, 0);
            this.txt_Content.Margins.Margin0.Width = 32;
            this.txt_Content.Name = "txt_Content";
            this.txt_Content.OverType = true;
            this.txt_Content.Size = new System.Drawing.Size(835, 181);
            this.txt_Content.Snippets.IsOneKeySelectionEmbedEnabled = true;
            this.txt_Content.TabIndex = 0;
            this.txt_Content.TextChanged += new System.EventHandler(this.txt_Content_TextChanged);
            this.txt_Content.TextDeleted += new System.EventHandler<ScintillaNet.TextModifiedEventArgs>(this.txt_Content_TextDeleted);
            this.txt_Content.TextInserted += new System.EventHandler<ScintillaNet.TextModifiedEventArgs>(this.txt_Content_TextInserted);
            this.txt_Content.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Content_KeyDown);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.axWindowsMediaPlayer1);
            this.tabPage4.Controls.Add(this.groupBox1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(841, 685);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Media Player";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(6, 6);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(829, 565);
            this.axWindowsMediaPlayer1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btn_SnapVideoFrame);
            this.groupBox1.Controls.Add(this.btn_OpenVideo);
            this.groupBox1.Location = new System.Drawing.Point(6, 577);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(829, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Media Player Controls";
            // 
            // btn_SnapVideoFrame
            // 
            this.btn_SnapVideoFrame.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_SnapVideoFrame.Location = new System.Drawing.Point(87, 19);
            this.btn_SnapVideoFrame.Name = "btn_SnapVideoFrame";
            this.btn_SnapVideoFrame.Size = new System.Drawing.Size(75, 75);
            this.btn_SnapVideoFrame.TabIndex = 1;
            this.btn_SnapVideoFrame.Text = "Snap Frame";
            this.btn_SnapVideoFrame.UseVisualStyleBackColor = true;
            this.btn_SnapVideoFrame.Click += new System.EventHandler(this.btn_SnapVideoFrame_Click);
            // 
            // btn_OpenVideo
            // 
            this.btn_OpenVideo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_OpenVideo.Location = new System.Drawing.Point(6, 19);
            this.btn_OpenVideo.Name = "btn_OpenVideo";
            this.btn_OpenVideo.Size = new System.Drawing.Size(75, 75);
            this.btn_OpenVideo.TabIndex = 0;
            this.btn_OpenVideo.Text = "Open File";
            this.btn_OpenVideo.UseVisualStyleBackColor = true;
            this.btn_OpenVideo.Click += new System.EventHandler(this.btn_OpenVideo_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Right;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(198, 711);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.flowLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(171, 703);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Controls";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btn_NewPost);
            this.flowLayoutPanel1.Controls.Add(this.btn_SaveDraft);
            this.flowLayoutPanel1.Controls.Add(this.btn_PublishPost);
            this.flowLayoutPanel1.Controls.Add(this.btn_AddImage);
            this.flowLayoutPanel1.Controls.Add(this.btn_LoadDraft);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(165, 697);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btn_NewPost
            // 
            this.btn_NewPost.Location = new System.Drawing.Point(3, 3);
            this.btn_NewPost.Name = "btn_NewPost";
            this.btn_NewPost.Size = new System.Drawing.Size(75, 23);
            this.btn_NewPost.TabIndex = 0;
            this.btn_NewPost.Text = "New Post";
            this.btn_NewPost.UseVisualStyleBackColor = true;
            // 
            // btn_SaveDraft
            // 
            this.btn_SaveDraft.Location = new System.Drawing.Point(84, 3);
            this.btn_SaveDraft.Name = "btn_SaveDraft";
            this.btn_SaveDraft.Size = new System.Drawing.Size(75, 23);
            this.btn_SaveDraft.TabIndex = 1;
            this.btn_SaveDraft.Text = "Save Draft";
            this.btn_SaveDraft.UseVisualStyleBackColor = true;
            this.btn_SaveDraft.Click += new System.EventHandler(this.btn_SaveDraft_Click);
            // 
            // btn_PublishPost
            // 
            this.btn_PublishPost.Location = new System.Drawing.Point(3, 32);
            this.btn_PublishPost.Name = "btn_PublishPost";
            this.btn_PublishPost.Size = new System.Drawing.Size(75, 23);
            this.btn_PublishPost.TabIndex = 2;
            this.btn_PublishPost.Text = "Publish";
            this.btn_PublishPost.UseVisualStyleBackColor = true;
            this.btn_PublishPost.Click += new System.EventHandler(this.btn_PublishPost_Click);
            // 
            // btn_AddImage
            // 
            this.btn_AddImage.Location = new System.Drawing.Point(84, 32);
            this.btn_AddImage.Name = "btn_AddImage";
            this.btn_AddImage.Size = new System.Drawing.Size(75, 23);
            this.btn_AddImage.TabIndex = 3;
            this.btn_AddImage.Text = "Add Image...";
            this.btn_AddImage.UseVisualStyleBackColor = true;
            this.btn_AddImage.Click += new System.EventHandler(this.btn_AddImage_Click);
            // 
            // btn_LoadDraft
            // 
            this.btn_LoadDraft.Location = new System.Drawing.Point(3, 61);
            this.btn_LoadDraft.Name = "btn_LoadDraft";
            this.btn_LoadDraft.Size = new System.Drawing.Size(75, 23);
            this.btn_LoadDraft.TabIndex = 4;
            this.btn_LoadDraft.Text = "Load Draft";
            this.btn_LoadDraft.UseVisualStyleBackColor = true;
            this.btn_LoadDraft.Click += new System.EventHandler(this.btn_LoadDraft_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.flowLayoutPanel2);
            this.tabPage5.Location = new System.Drawing.Point(4, 4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(171, 703);
            this.tabPage5.TabIndex = 2;
            this.tabPage5.Text = "Editing";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btn_InsertBreak);
            this.flowLayoutPanel2.Controls.Add(this.btn_addpics);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(165, 697);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // btn_InsertBreak
            // 
            this.btn_InsertBreak.Location = new System.Drawing.Point(3, 3);
            this.btn_InsertBreak.Name = "btn_InsertBreak";
            this.btn_InsertBreak.Size = new System.Drawing.Size(75, 23);
            this.btn_InsertBreak.TabIndex = 0;
            this.btn_InsertBreak.Text = "Insert Break";
            this.btn_InsertBreak.UseVisualStyleBackColor = true;
            this.btn_InsertBreak.Click += new System.EventHandler(this.btn_InsertBreak_Click);
            // 
            // btn_addpics
            // 
            this.btn_addpics.Location = new System.Drawing.Point(84, 3);
            this.btn_addpics.Name = "btn_addpics";
            this.btn_addpics.Size = new System.Drawing.Size(75, 23);
            this.btn_addpics.TabIndex = 1;
            this.btn_addpics.Text = "Add All Pics";
            this.btn_addpics.UseVisualStyleBackColor = true;
            this.btn_addpics.Click += new System.EventHandler(this.btn_addpics_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.list_images);
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(171, 703);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Images";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // list_images
            // 
            this.list_images.Dock = System.Windows.Forms.DockStyle.Fill;
            this.list_images.LargeImageList = this.ilist_thumbnails;
            this.list_images.Location = new System.Drawing.Point(3, 3);
            this.list_images.Name = "list_images";
            this.list_images.Size = new System.Drawing.Size(165, 697);
            this.list_images.TabIndex = 0;
            this.list_images.UseCompatibleStateImageBehavior = false;
            this.list_images.View = System.Windows.Forms.View.Tile;
            this.list_images.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.list_images_MouseDoubleClick);
            // 
            // ilist_thumbnails
            // 
            this.ilist_thumbnails.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.ilist_thumbnails.ImageSize = new System.Drawing.Size(100, 100);
            this.ilist_thumbnails.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.flow_Categories);
            this.tabPage6.Location = new System.Drawing.Point(4, 4);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(171, 703);
            this.tabPage6.TabIndex = 3;
            this.tabPage6.Text = "Categories";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // flow_Categories
            // 
            this.flow_Categories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flow_Categories.Location = new System.Drawing.Point(3, 3);
            this.flow_Categories.Name = "flow_Categories";
            this.flow_Categories.Size = new System.Drawing.Size(165, 697);
            this.flow_Categories.TabIndex = 0;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.flow_tags);
            this.tabPage7.Controls.Add(this.txt_tags);
            this.tabPage7.Location = new System.Drawing.Point(4, 4);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(171, 703);
            this.tabPage7.TabIndex = 4;
            this.tabPage7.Text = "Tags";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // flow_tags
            // 
            this.flow_tags.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.flow_tags.Location = new System.Drawing.Point(6, 34);
            this.flow_tags.Name = "flow_tags";
            this.flow_tags.Size = new System.Drawing.Size(159, 661);
            this.flow_tags.TabIndex = 1;
            // 
            // txt_tags
            // 
            this.txt_tags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_tags.Location = new System.Drawing.Point(6, 8);
            this.txt_tags.Name = "txt_tags";
            this.txt_tags.Size = new System.Drawing.Size(159, 20);
            this.txt_tags.TabIndex = 0;
            this.txt_tags.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_tags_KeyDown);
            // 
            // WordLaunch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 711);
            this.Controls.Add(this.splitContainer1);
            this.Name = "WordLaunch";
            this.Text = "WordLaunch";
            this.Load += new System.EventHandler(this.WordLaunch_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt_Content)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Skybound.Gecko.GeckoWebBrowser geckoWebBrowser1;
        private ScintillaNet.Scintilla txt_Content;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btn_NewPost;
        private System.Windows.Forms.Button btn_SaveDraft;
        private System.Windows.Forms.Button btn_PublishPost;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_SnapVideoFrame;
        private System.Windows.Forms.Button btn_OpenVideo;
        private System.Windows.Forms.ListView list_images;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btn_InsertBreak;
        private System.Windows.Forms.Button btn_AddImage;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TextBox txt_Title;
        private System.Windows.Forms.ImageList ilist_thumbnails;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.FlowLayoutPanel flow_Categories;
        private System.Windows.Forms.Button btn_LoadDraft;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.FlowLayoutPanel flow_tags;
        private System.Windows.Forms.TextBox txt_tags;
        private System.Windows.Forms.Button btn_addpics;
    }
}