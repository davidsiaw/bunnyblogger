using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BunnyBlogger;
using System.Xml;
using System.Security.Policy;
using System.Web;

namespace WordLaunch
{
    public partial class Form1 : Form
    {
        WPConnection conn;

        Dictionary<int, TreeNode> pageidToTreeMap = new Dictionary<int, TreeNode>();

        string url;
        string username;
        string password;

        // Timer for scrolling
        private Timer timer = new Timer();
        public Form1(string url, string username, string password)
        {
            InitializeComponent();

            this.url = url;
            this.username = username;
            this.password = password;
            conn = new WPConnection(url);

            ReloadPageInformation();

            timer.Interval = 200;
            timer.Tick += new EventHandler(timer_Tick);

        }

        void ReloadPageInformation()
        {
            treeView1.Nodes.Clear();
            pageidToTreeMap.Clear();

            PageFullInfo[] pfis = conn.GetPages(0, username, password);
            foreach (PageFullInfo pfi in pfis)
            {
                TreeNode t = new TreeNode(pfi.wp_slug);
                t.Tag = pfi;
                pageidToTreeMap.Add(pfi.page_id, t);
                if (pfi.wp_page_parent_id == 0)
                {
                    treeView1.Nodes.Add(t);
                }
                else
                {
                    pageidToTreeMap[pfi.wp_page_parent_id].Nodes.Add(t);
                }
            }

        }

        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            geckoWebBrowser1.Navigate("about:blank");
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SelectPage(e.Node);
        }

        TreeNode lastnode = null;
        bool m_textchanged = false;

        bool textchanged
        {
            get
            {
                return m_textchanged;
            }
            set
            {
                m_textchanged = value;
                saveToolStripMenuItem.Enabled = m_textchanged;
            }
        }

        void CheckEditor()
        {
            if (textchanged)
            {
                DialogResult dr = MessageBox.Show("Do you wish to save your changes?", "Page changed",  MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    saveToolStripMenuItem_Click(this, null);
                }
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            textchanged = true;
        }

        private void SelectPage(TreeNode node)
        {
            // Update UI
            PageFullInfo page = (node.Tag as PageFullInfo);
            richTextBox1.Text = page.description + page.text_more;
            geckoWebBrowser1.Navigate(page.link);
            txt_Pagename.Text = page.title;
            txt_pageslug.Text = page.wp_slug;

            textchanged = false;
            lastnode = node;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] more = { "<!--more-->"};
            richTextBox1.Text.Split(more, 2, StringSplitOptions.None);

            PageFullInfo pfi = lastnode.Tag as PageFullInfo;
            pfi.description = richTextBox1.Text;
            pfi.title = txt_Pagename.Text;
            pfi.wp_slug = txt_pageslug.Text;

            PageCreationInfo pci = new PageCreationInfo();
            pci.dateCreated = pfi.date_created_gmt;
            pci.description = pfi.description;
            pci.mt_allow_comments = pfi.mt_allow_comments;
            pci.mt_allow_pings = pfi.mt_allow_pings;
            pci.mt_excerpt = pfi.excerpt;
            pci.mt_text_more = pfi.text_more;
            pci.title = pfi.title;
            pci.wp_author_id = pfi.wp_author_id;
            pci.wp_page_order = pfi.wp_page_order;
            pci.wp_page_parent_id = pfi.wp_page_parent_id;
            pci.wp_password = pfi.wp_password;
            pci.wp_slug = pfi.wp_slug;
            conn.EditPage(0, pfi.page_id, "admin", "davsiaw", pci, true);

            textchanged = false;
            ReloadPageInformation();
        }

        TreeNode tempDropNode = null;
        TreeNode dragNode = null;
        ImageList dragImageList = new ImageList();
        private void treeView1_DragOver(object sender, DragEventArgs e)
        {
            // Compute drag position and move image
            Point formP = this.PointToClient(new Point(e.X, e.Y));
            DragHelper.ImageList_DragMove(formP.X - this.treeView1.Left, formP.Y - this.treeView1.Top);

            // Get actual drop node
            TreeNode dropNode = this.treeView1.GetNodeAt(this.treeView1.PointToClient(new Point(e.X, e.Y)));
            if (dropNode == null)
            {
                e.Effect = DragDropEffects.Move;
                return;
            }

            e.Effect = DragDropEffects.Move;

            // if mouse is on a new node select it
            if (this.tempDropNode != dropNode)
            {
                DragHelper.ImageList_DragShowNolock(false);
                this.treeView1.SelectedNode = dropNode;
                DragHelper.ImageList_DragShowNolock(true);
                tempDropNode = dropNode;
            }

            // Avoid that drop node is child of drag node 
            TreeNode tmpNode = dropNode;
            while (tmpNode.Parent != null)
            {
                if (tmpNode.Parent == this.dragNode) e.Effect = DragDropEffects.None;
                tmpNode = tmpNode.Parent;
            }
        }

        private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            // Get drag node and select it
            this.dragNode = (TreeNode)e.Item;
            this.treeView1.SelectedNode = this.dragNode;

            // Reset image list used for drag image
            this.dragImageList.Images.Clear();
            this.dragImageList.ImageSize = new Size(this.dragNode.Bounds.Size.Width + this.treeView1.Indent, this.dragNode.Bounds.Height);

            // Create new bitmap
            // This bitmap will contain the tree node image to be dragged
            Bitmap bmp = new Bitmap(this.dragNode.Bounds.Width + this.treeView1.Indent, this.dragNode.Bounds.Height);

            // Get graphics from bitmap
            Graphics gfx = Graphics.FromImage(bmp);


            // Draw node label into bitmap
            gfx.DrawString(this.dragNode.Text,
                this.treeView1.Font,
                new SolidBrush(this.treeView1.ForeColor),
                (float)this.treeView1.Indent, 1.0f);

            // Add bitmap to imagelist
            this.dragImageList.Images.Add(bmp);

            // Get mouse position in client coordinates
            Point p = this.treeView1.PointToClient(Control.MousePosition);

            // Compute delta between mouse position and node bounds
            int dx = p.X + this.treeView1.Indent - this.dragNode.Bounds.Left;
            int dy = p.Y - this.dragNode.Bounds.Top;

            // Begin dragging image
            if (DragHelper.ImageList_BeginDrag(this.dragImageList.Handle, 0, dx, dy))
            {
                // Begin dragging
                this.treeView1.DoDragDrop(bmp, DragDropEffects.Move);
                // End dragging image
                DragHelper.ImageList_EndDrag();
            }		
        }

        private void treeView1_DragLeave(object sender, EventArgs e)
        {
            DragHelper.ImageList_DragLeave(this.treeView1.Handle);

            // Disable timer for scrolling dragged item
            this.timer.Enabled = false;
        }

        private void treeView1_DragEnter(object sender, DragEventArgs e)
        {
            DragHelper.ImageList_DragEnter(this.treeView1.Handle, e.X - this.treeView1.Left,
                e.Y - this.treeView1.Top);

            // Enable timer for scrolling dragged item
            this.timer.Enabled = true;
        }

        private void treeView1_DragDrop(object sender, DragEventArgs e)
        {
            // Unlock updates
            DragHelper.ImageList_DragLeave(this.treeView1.Handle);

            // Get drop node
            TreeNode dropNode = this.treeView1.GetNodeAt(this.treeView1.PointToClient(new Point(e.X, e.Y)));

            // If drop node isn't equal to drag node, add drag node as child of drop node
            if (this.dragNode != dropNode)
            {
                PageFullInfo draggedpage = (dragNode.Tag as PageFullInfo);
                SelectPage(dragNode);

                // Remove drag node from parent
                if (this.dragNode.Parent == null)
                {
                    this.treeView1.Nodes.Remove(this.dragNode);
                }
                else
                {
                    this.dragNode.Parent.Nodes.Remove(this.dragNode);
                }

                if (dropNode == null)
                { 
                    // Make it a parent
                    treeView1.Nodes.Add(this.dragNode);

                    // Change the drag node page's parent too
                    draggedpage.wp_page_parent_id = 0;
                }
                else
                {
                    // Add drag node to drop node
                    dropNode.Nodes.Add(this.dragNode);
                    dropNode.ExpandAll();

                    // Change the drag node page's parent too
                    draggedpage.wp_page_parent_id = (dropNode.Tag as PageFullInfo).page_id;
                }

                // Update page
                PageCreationInfo pci = new PageCreationInfo();
                pci.dateCreated = draggedpage.date_created_gmt;
                pci.description = draggedpage.description;
                pci.mt_allow_comments = draggedpage.mt_allow_comments;
                pci.mt_allow_pings = draggedpage.mt_allow_pings;
                pci.mt_excerpt = draggedpage.excerpt;
                pci.mt_text_more = draggedpage.text_more;
                pci.title = draggedpage.title;
                pci.wp_author_id = draggedpage.wp_author_id;
                pci.wp_page_order = draggedpage.wp_page_order;
                pci.wp_page_parent_id = draggedpage.wp_page_parent_id;
                pci.wp_password = draggedpage.wp_password;
                pci.wp_slug = draggedpage.wp_slug;

                conn.EditPage(0, draggedpage.page_id, "admin", "davsiaw", pci, true);

                SelectPage(this.dragNode);

                // Set drag node to null
                this.dragNode = null;

                // Disable scroll timer
                this.timer.Enabled = false;
            }
        }


        private void treeView1_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            if (e.Effect == DragDropEffects.Move)
            {
                // Show pointer cursor while dragging

                e.UseDefaultCursors = false;
                this.treeView1.Cursor = Cursors.Default;
            }
            else e.UseDefaultCursors = true;
        }


        private void timer_Tick(object sender, EventArgs e)
        {
            // get node at mouse position
            Point pt = PointToClient(Control.MousePosition);
            TreeNode node = this.treeView1.GetNodeAt(pt);

            if (node == null) return;

            // if mouse is near to the top, scroll up
            if (pt.Y < 30)
            {
                // set actual node to the upper one
                if (node.PrevVisibleNode != null)
                {
                    node = node.PrevVisibleNode;

                    // hide drag image
                    DragHelper.ImageList_DragShowNolock(false);
                    // scroll and refresh
                    node.EnsureVisible();
                    this.treeView1.Refresh();
                    // show drag image
                    DragHelper.ImageList_DragShowNolock(true);

                }
            }
            // if mouse is near to the bottom, scroll down
            else if (pt.Y > this.treeView1.Size.Height - 30)
            {
                if (node.NextVisibleNode != null)
                {
                    node = node.NextVisibleNode;

                    DragHelper.ImageList_DragShowNolock(false);
                    node.EnsureVisible();
                    this.treeView1.Refresh();
                    DragHelper.ImageList_DragShowNolock(true);
                }
            }
        }

        private void newPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PageCreationInfo pci = new PageCreationInfo();
            pci.dateCreated = DateTime.UtcNow;
            pci.description = "";
            pci.mt_allow_comments = 0;
            pci.mt_allow_pings = 0;
            pci.mt_excerpt = "";
            pci.mt_text_more = "";
            pci.title = "New Page";
            pci.wp_author_id = 0;
            pci.wp_page_order = 0;
            pci.wp_page_parent_id = 0;
            pci.wp_password = "";
            pci.wp_slug = "new-page";

            conn.NewPage(0, "admin", "davsiaw", pci, true);
            ReloadPageInformation();
        }

        private void deletePageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void backupAllYourPagesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void txt_Pagename_TextChanged(object sender, EventArgs e)
        {
            textchanged = true;
            txt_pageslug.Text = HttpUtility.UrlEncode(txt_Pagename.Text.ToLower().Replace(' ', '-'));
        }
    }
}
