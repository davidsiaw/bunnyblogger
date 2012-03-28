using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Skybound.Gecko;
using ScintillaNet;
using System.IO;
using BunnyBlogger;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Threading;
using HttpServer;
using HttpServer.Headers;
using HttpServer.BodyDecoders;
using HttpServer.Resources;
using HttpServer.Modules;
using BlueBlocksLib.UITools;

namespace WordLaunch
{
    public partial class WordLaunch : Form
    {
        ServerInfo targetserver;

        PluginRpc plugin;
        PicSize medsize;
        Server webserv;
        int webservport = 30124;

        string url = "http://localhost/wordpress/?page_id=2";
        string originalTitleContent = "@@bunnyblogger_dummy_title";
        string originalBodyContent = "@@bunnyblogger_dummy_body";

        public WordLaunch(ServerInfo targetserver)
        {
            InitializeComponent();
            this.targetserver = targetserver;
            plugin = new PluginRpc(targetserver.conn.URL);
            medsize = plugin.GetMediumSize();

            txt_Content.NativeInterface.SetCodePage((int)Constants.SC_CP_UTF8);

            CategoryFullInfo[] cfi = targetserver.conn.GetCategories(0, targetserver.username, targetserver.password);
            foreach (CategoryFullInfo cf in cfi)
            {
                CheckBox cb = new CheckBox();
                cb.Name = "cb_" + cf.categoryName;
                cb.Text = cf.categoryName;
                cb.Tag = cf;
                flow_Categories.Controls.Add(cb);
            }

            postResources = GetNextAvailableDir();
            Directory.CreateDirectory(postResources);

            var module = new FileModule();
            webserv = new Server();
            module.Resources.Add(new FileResources("/",postResources));
            webserv.Add(module);
            webserv.Add(new MultiPartDecoder());
            webserv.RequestReceived+=new EventHandler<RequestEventArgs>(webserv_RequestReceived);

            // use one http listener.
            webserv.Add(HttpListener.Create(System.Net.IPAddress.Any, webservport));
            webserv.Start(5);

            // Find a valid post to use
            url = targetserver.conn.URL.Replace("xmlrpc.php", "?p=2147483646");

        }

        void webserv_RequestReceived(object sender, RequestEventArgs e)
        {
            string url = e.Request.Uri.ToString();

            if (url.EndsWith("jpg") || url.EndsWith("jpeg"))
            {
                e.Response.ContentType = new ContentTypeHeader("image/jpeg");
            }
            if (url.EndsWith("png"))
            {
                e.Response.ContentType = new ContentTypeHeader("image/png");
            }
            if (url.EndsWith("bmp"))
            {
                e.Response.ContentType = new ContentTypeHeader("image/bmp");
            }
            if (url.EndsWith("gif"))
            {
                e.Response.ContentType = new ContentTypeHeader("image/gif");
            }

        }


        string postResources = "";

        string GetNextAvailableDir()
        {
            int i = 0;
            string dir = Directory.GetCurrentDirectory() + "\\" + 0;
            while (Directory.Exists(dir))
            {
                dir = Directory.GetCurrentDirectory() + "\\" + i++;
            }
            return dir;
        }


        private void WordLaunch_Load(object sender, EventArgs e)
        {
            txt_Title.Enabled = false;
            txt_Content.Enabled = false;
            txt_Title.Text = "Please wait while we load the page...";

            DragDropTools.EnableFileDrop(list_images, files =>
            {
                foreach (var file in files)
                {
                    AddToImageList(file);
                }
            });

            geckoWebBrowser1.Navigate(url);
            geckoWebBrowser1.DocumentCompleted += new EventHandler(geckoWebBrowser1_DocumentCompleted);
                        
        }

        void geckoWebBrowser1_Navigated(object sender, GeckoNavigatedEventArgs e)
        {
            //geckoWebBrowser1.Navigate(url);
        }

        void geckoWebBrowser1_Navigating(object sender, Skybound.Gecko.GeckoNavigatingEventArgs e)
        {
            //geckoWebBrowser1.Navigate(url);
        }

        GeckoElement titleElem;
        GeckoElement entryElem;

        GeckoElement FindTagContainingText(GeckoDocument doc, string text)
        {
            string[] tagtypes = {
                                    "h1",
                                    "h2",
                                    "h3",
                                    "h4",
                                    "h5",
                                    "h6",
                                    "a",
                                    "div",
                                    "p",
                                    "span",
                                };

            foreach (string tagtype in tagtypes)
            {
                foreach (GeckoElement elem in doc.GetElementsByTagName(tagtype))
                {
                    if (elem.InnerHtml.Trim() == text.Trim())
                    {
                        return elem;
                    }
                }
            }

            return null;
        }

        void geckoWebBrowser1_DocumentCompleted(object sender, EventArgs e)
        {

            txt_Title.Text = "";

            GeckoDocument doc = geckoWebBrowser1.Document;
            titleElem = FindTagContainingText(doc, originalTitleContent);
            entryElem = FindTagContainingText(doc, originalBodyContent);


            if (titleElem != null && entryElem != null)
            {
                titleElem.InnerHtml = txt_Title.Text;
                entryElem.InnerHtml = txt_Content.Text;
            }
            geckoWebBrowser1.DocumentCompleted -= new EventHandler(geckoWebBrowser1_DocumentCompleted);

            txt_Title.Enabled = true;
            txt_Content.Enabled = true;
        }

        private void txt_Title_TextChanged(object sender, EventArgs e)
        {
            if (titleElem != null)
            {
                titleElem.InnerHtml = txt_Title.Text;
            }
        }

        
        
        private void txt_Content_TextChanged(object sender, EventArgs e)
        {
            entryElem.InnerHtml = "";
            if (entryElem != null)
            {
                entryElem.InnerHtml += txt_Content.Text.Replace("\r\n", "<br />");
            }
        }

        private void txt_Content_TextInserted(object sender, TextModifiedEventArgs e)
        {
            txt_Content_TextChanged(sender, e);
        }

        private void txt_Content_TextDeleted(object sender, TextModifiedEventArgs e)
        {
            txt_Content_TextChanged(sender, e);
        }

        private void btn_AddImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
            ofd.ShowDialog();

            if (ofd.FileNames != null && ofd.FileNames.Length != 0)
            {
                ProgressForm p = new ProgressForm();
                p.Text = "Uploading files...";
                Thread t = new Thread(new ThreadStart(delegate()
                {
                    // Wait for the window to open
                    while (!p.Visible) { };
                    double count = 0;
                    foreach (string filename in ofd.FileNames)
                    {
                        p.DisplayText = filename;
                        Invoke(new Invoker(delegate()
                        {
                            AddToImageList(filename);
                        }));
                        count++;
                        p.Progress = count / (double)ofd.FileNames.Length;
                    }

                    Invoke(new Invoker(delegate()
                    {
                        p.Close();
                    }));
                }));
                t.Start();
                p.ShowDialog();
            }
        }

        private void AddToImageList(string filename)
        {
            try
            {
                string file = Path.GetFileName(filename);

                Bitmap b;

                using (Bitmap tempholder = new Bitmap(filename))
                {
                    b = new Bitmap(tempholder);
                }

                Bitmap thumb = new Bitmap(100, 100, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                using (Graphics g = Graphics.FromImage(thumb))
                {
                    g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                    g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    if (b.Width > b.Height)
                    {
                        int height = (int)((double)100.0 / (double)b.Width * (double)b.Height);
                        g.DrawImage(b, new Rectangle(0, 50 - height / 2, 100, height));
                    }
                    else
                    {
                        int width = (int)((double)100.0 / (double)b.Height * (double)b.Width);
                        g.DrawImage(b, new Rectangle(50 - width / 2, 0, width, 100));
                    }
                }

                ilist_thumbnails.Images.Add(file, thumb);

                ListViewItem lvi = list_images.Items.Add(file);
                lvi.ImageKey = file;

                ImageInformation ii = new ImageInformation();
                ii.bitmap = b;
                ii.uploadedToDevServer = false;
                ii.filename = file;
                ii.fullpath = filename;

                lvi.Tag = ii;
            }
            catch { }
        }

        [Serializable]
        public class ImageInformation
        {
            public string fullpath;
            public string filename;

            [NonSerialized]
            [XmlIgnore]
            public Bitmap bitmap;

            public bool uploadedToDevServer;
            public string medurl;
            public string fullurl;
            public int medwidth;
            public int medheight;

            [OnDeserializing]
            void ClearBitmap(StreamingContext ctx)
            {
                bitmap = null;
            }
        }

        private void list_images_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem lvi = list_images.GetItemAt(e.X, e.Y);
            AddToPost(lvi);
        }

        PicSize resizePic(PicSize size)
        {
            if (size.width > medsize.width)
            {
                size.height = size.height * medsize.width / size.width;
                size.width = medsize.width;
            }

            if (size.height > medsize.height)
            {
                size.width = size.width * medsize.height / size.height;
                size.height = medsize.height;
            }

            return size;
        }

        private void AddToPost(ListViewItem lvi)
        {
            ImageInformation ii = lvi.Tag as ImageInformation;

            if (!ii.uploadedToDevServer)
            {
                
                //FileUploadReturnInfo retval = UploadFile(ii, localdevserver);
                //if (retval == null) return;

                ii.uploadedToDevServer = true;

                using (Bitmap b = new Bitmap(ii.fullpath))
                {
                    PicSize sz = resizePic(new PicSize() { width = b.Width, height = b.Height });
                    using (Bitmap med = new Bitmap(sz.width, sz.height))
                    {
                        using (Graphics g = Graphics.FromImage(med))
                        {
                            g.DrawImage(b, new Rectangle(0, 0, sz.width, sz.height));
                        }
                        
                        string medpath = Path.Combine(postResources, GetMedFilename(ii, sz));
                        med.Save(medpath);
                        ii.medurl = "http://localhost:" + webservport + "/" + GetMedFilename(ii, sz);
                        ii.medwidth = sz.width;
                        ii.medheight = sz.height;
                    }

                    b.Save(Path.Combine(postResources, ii.filename));
                    ii.fullurl = "http://localhost:" + webservport + "/" + ii.filename;
                    
                }

            
            }

            if (ii.medwidth <= ii.bitmap.Width && ii.medheight <= ii.bitmap.Height)
            {
                txt_Content.AppendText("<a href=\"" +
                    Uri.EscapeUriString(ii.fullurl) +
                    "\" rel=\"lightbox\"><img src=\"" + Uri.EscapeUriString(ii.fullurl) +
                    "\" alt=\"\" title=\"Picture\" width=\"" + ii.medwidth +
                    "\" height=\"" + ii.medheight +
                    "\" class=\"alignnone size-medium wp-image-1204\" /></a>"
                    );
            }
            else
            {
                txt_Content.AppendText("<a href=\"" +
                    Uri.EscapeUriString(ii.fullurl) +
                    "\" rel=\"lightbox\"><img src=\"" + Uri.EscapeUriString(ii.medurl) +
                    "\" alt=\"\" title=\"Picture\" width=\"" + ii.medwidth +
                    "\" height=\"" + ii.medheight +
                    "\" class=\"alignnone size-medium wp-image-1204\" /></a>"
                    );
            }

        }

        private static string GetMedFilename(ImageInformation ii, PicSize sz)
        {
            return Path.GetFileNameWithoutExtension(ii.filename)
                                        + "-" + sz.width + "x" + sz.height
                                        + Path.GetExtension(ii.filename);
        }

        private void GetMedWidth(ImageInformation ii)
        {
            var actualsize = resizePic(new PicSize() { width = ii.bitmap.Width, height = ii.bitmap.Height });
            ii.medwidth = actualsize.width;
            ii.medheight = actualsize.height;

            int indexOfDot = ii.fullurl.LastIndexOf('.');
            string file = ii.fullurl.Substring(0, indexOfDot) + "-" + ii.medwidth + "x" + ii.medheight + ii.fullurl.Substring(indexOfDot);
            ii.medurl = file;
        }


        private FileUploadReturnInfo UploadFile(ImageInformation ii, ServerInfo si)
        {

            FileUploadInfo fui = new FileUploadInfo();
            fui.overwrite = true;
            fui.name = ii.filename;
            fui.type = Mimetypes.MimeType(ii.filename);

            BinaryReader br = new BinaryReader(File.Open(ii.fullpath, FileMode.Open));
            byte[] bytes = new byte[br.BaseStream.Length];
            br.Read(bytes, 0, (int)br.BaseStream.Length);
            br.Close();
            fui.bits = bytes;

            try
            {
                FileUploadReturnInfo retval = si.conn.UploadFile(0, si.username, si.password, fui);
                return retval;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

        delegate void Invoker();

        private void btn_PublishPost_Click(object sender, EventArgs e)
        {
            string content = txt_Content.Text;

            // Add title
            string title = "<title>" + titleElem.InnerHtml + "</title>";

            // Upload images
            ProgressForm p = new ProgressForm();
            p.Text = "Uploading files...";
            Thread t = new Thread(new ThreadStart(delegate()
            {
                while (!p.Visible) { }
                p.Progress = 0;
                double count = 0;
                int itemcount = list_images.Items.Count;

                for (int i = 0; i < itemcount; i++)
                {
                    ImageInformation ii = null;
                    Invoke(new Invoker(delegate()
                    {
                        ListViewItem lvi = list_images.Items[i];
                        ii = lvi.Tag as ImageInformation;
                    }));

                    if (ii.uploadedToDevServer)
                    {
                        FileUploadReturnInfo retval = UploadFile(ii, targetserver);
                        if (retval == null) {
                            MessageBox.Show("Unable to upload a file");
                            return; 
                        }

                        string localfullurl = Uri.EscapeUriString(ii.fullurl);
                        string localmedurl = Uri.EscapeUriString(ii.medurl);

                        ii.fullurl = retval.url;
                        GetMedWidth(ii);

                        content = content.Replace(localfullurl, ii.fullurl);
                        content = content.Replace(localmedurl, ii.medurl);
                    }
                    count++;
                    Invoke(new Invoker(delegate()
                    {
                        p.Progress = count / (double)list_images.Items.Count;
                        p.DisplayText = ii.filename;
                    }));
                }

                Invoke(new Invoker(delegate()
                {
                    p.Close();
                }));

            }));
            t.Start();
            p.ShowDialog();

            // Make the content string and send it off
            content = title + content;
            int postid = targetserver.conn.NewPost(0, 0, targetserver.username, targetserver.password, content, true);

            // Set the category
            List<CategoryFullInfo> cfis = new List<CategoryFullInfo>();
            foreach (Control ctl in flow_Categories.Controls)
            {
                CheckBox cb = ctl as CheckBox;
                if (cb.Checked)
                {
                    cfis.Add(cb.Tag as CategoryFullInfo);
                }
            }
            targetserver.conn.SetPostCategories(postid, targetserver.username, targetserver.password, cfis.ToArray());

            // Set the tags
            MWPost post = targetserver.conn.MWGetPost(postid, targetserver.username, targetserver.password);

            tags.ForEach(x => post.mt_keywords += (post.mt_keywords.Length == 0 ? "" : ",") + x);

            targetserver.conn.MWEditPost(postid, targetserver.username, targetserver.password, post);
        }

        private void btn_OpenVideo_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            if (string.IsNullOrEmpty(ofd.FileName))
            {
                return;
            }
            WMPLib.IWMPMedia w = axWindowsMediaPlayer1.newMedia(ofd.FileName);
            axWindowsMediaPlayer1.currentMedia = w;
            currentVideoImagesName = Path.GetFileNameWithoutExtension(ofd.FileName);
        }

        string currentVideoImagesName = null;

        [DllImport("framesnapper")]
        static extern void GrabFrame(string file, double seek, out int width, out int height, out IntPtr buffer, out int bufsize);

        [DllImport("framesnapper")]
        static extern void CleanUpFrame(IntPtr buffer);

        private void btn_SnapVideoFrame_Click(object sender, EventArgs e)
        {
            Bitmap frame = GetFrame();
            int count = 0;
            while (File.Exists(currentVideoImagesName + "_" + count + ".jpg"))
            {
                count++;
            }
            string filename = currentVideoImagesName + "_" + count + ".jpg";
            frame.Save(filename, ImageFormat.Jpeg);
            frame.Dispose();
            AddToImageList(Path.Combine(Directory.GetCurrentDirectory(), filename));
        }
        
        unsafe Bitmap GetFrame()
        {
            int width, height, bufsize;
            IntPtr buffer;

            GrabFrame(axWindowsMediaPlayer1.currentMedia.sourceURL, axWindowsMediaPlayer1.Ctlcontrols.currentPosition / axWindowsMediaPlayer1.currentMedia.duration, out width, out height, out buffer, out bufsize);


            byte[] managedbuf = new byte[bufsize];
            Marshal.Copy(buffer, managedbuf, 0, width * 3 * height);
            CleanUpFrame(buffer);

            fixed (byte* b = &managedbuf[0])
            {
                Bitmap pic = new Bitmap(width, height, width * 3, System.Drawing.Imaging.PixelFormat.Format24bppRgb, (IntPtr)b);

                if (axWindowsMediaPlayer1.currentMedia.imageSourceWidth != width || axWindowsMediaPlayer1.currentMedia.imageSourceHeight != height)
                {
                    Bitmap newpic = new Bitmap(axWindowsMediaPlayer1.currentMedia.imageSourceWidth, axWindowsMediaPlayer1.currentMedia.imageSourceHeight, PixelFormat.Format24bppRgb);

                    using (Graphics g = Graphics.FromImage(newpic))
                    {
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                        g.DrawImage(pic, new Rectangle(0, 0, newpic.Width, newpic.Height));

                    }

                    pic.Dispose();
                    pic = newpic;
                }
                return pic;
            }
        }

        private void btn_InsertBreak_Click(object sender, EventArgs e)
        {
            txt_Content.AppendText("<!--more-->");
        }

        [Serializable]
        public class Post
        {
            public string title;
            public string content;
            public List<CategoryFullInfo> categories = new List<CategoryFullInfo>();
            public List<ImageInformation> images = new List<ImageInformation>();
            public List<string> tags = new List<string>();
        }

        string postfilename = null;

        private void btn_SaveDraft_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "XML Document(*.XML)|*.xml";
            sfd.ShowDialog();

            SavePost(sfd.FileName);
        }

        List<string> tags = new List<string>();

        private void SavePost(string filename)
        {
            Post thispost = new Post();

            foreach (ListViewItem lvi in list_images.Items)
            {
                ImageInformation ii = lvi.Tag as ImageInformation;
                thispost.images.Add(ii);
            }

            thispost.title = titleElem.InnerHtml;
            thispost.content = txt_Content.Text;
            thispost.tags = tags;

            foreach (Control ctl in flow_Categories.Controls)
            {
                CheckBox cb = ctl as CheckBox;
                if (cb.Checked)
                {
                    thispost.categories.Add(cb.Tag as CategoryFullInfo);
                }
            }

            XmlSerializer ser = new XmlSerializer(typeof(Post));


            if (!string.IsNullOrEmpty(filename))
            {
                postfilename = filename;
                using (FileStream file = new FileStream(filename, FileMode.Create))
                {
                    ser.Serialize(file, thispost);
                }
            }
        }

        private void btn_LoadDraft_Click(object sender, EventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "XML Document(*.XML)|*.xml";
            ofd.ShowDialog();

            XmlSerializer ser = new XmlSerializer(typeof(Post));

            if (!string.IsNullOrEmpty(ofd.FileName))
            {
                using (FileStream file = new FileStream(ofd.FileName, FileMode.Open))
                {
                    Post p = ser.Deserialize(file) as Post;

                    txt_Content.Text = p.content;
                    txt_Title.Text = p.title;

                    Dictionary<string, CategoryFullInfo> nameToCat = new Dictionary<string, CategoryFullInfo>();

                    foreach (CategoryFullInfo cfi in p.categories)
                    {
                        nameToCat[cfi.categoryName] = cfi;
                    }

                    foreach (Control ctl in flow_Categories.Controls)
                    {
                        CheckBox cb = ctl as CheckBox;
                        cb.Checked = false;
                        if (nameToCat.ContainsKey(cb.Text))
                        {
                            cb.Checked = true;
                        }
                    }

                    list_images.Items.Clear();

                    foreach (ImageInformation ii in p.images)
                    {
                        AddToImageList(ii.fullpath);
                    }
                    postfilename = ofd.FileName;

                    tags = p.tags;
                }
            }
        }
        private void txt_Content_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S)
            {
                if (e.Modifiers == Keys.Control)
                {
                    if (postfilename == null)
                    {
                        btn_SaveDraft_Click(sender, e);
                    }
                    else
                    {
                        SavePost(postfilename);
                    }
                }
            }
        }

        private void txt_tags_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                Button b = new Button();
                b.Text = txt_tags.Text;
                b.AutoSize = true;

                b.Click += new EventHandler((o, evt) => { flow_tags.Controls.Remove(o as Button); tags.Remove((o as Button).Text); });

                flow_tags.Controls.Add(b);
                tags.Add(b.Text);
                txt_tags.Text = "";
            }
        }


        private void btn_addpics_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in list_images.Items)
            {
                AddToPost(lvi);
                txt_Content.AppendText("\n");
            }
        }

        private void list_images_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
