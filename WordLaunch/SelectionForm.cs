using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BunnyBlogger;
using System.IO;
using BlueBlocksLib.FileAccess;

namespace WordLaunch
{
    public partial class SelectionForm : Form
    {
        public SelectionForm()
        {
            InitializeComponent();
            UpdateServerListFromFile();
            UpdateUI();
            FormClosed += new FormClosedEventHandler(SelectionForm_FormClosed);
        }

        void SelectionForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            UpdateFileFromServerList();
        }

        void UpdateServerListFromFile()
        {
            listBox1.Items.Clear();
            UserdataFileFormat udf;

            udf = ReadUserData();
            foreach (var entry in udf.entries)
            {
                ServerInfo si = new ServerInfo(entry.Name, new WPConnection(entry.URL), entry.Username, entry.Password);
                listBox1.Items.Add(si);
            }
        }

        void UpdateFileFromServerList()
        {
            List<UserdataEntry> entries = new List<UserdataEntry>();
            foreach (ServerInfo si in listBox1.Items)
            {
                entries.Add(new UserdataEntry()
                {
                    Name = si.name,
                    Username = si.username,
                    Password = si.password,
                    URL = si.conn.URL
                });
            }
            UserdataFileFormat udf = new UserdataFileFormat();
            udf.entries = entries.ToArray();
            udf.numOfEntries = entries.Count;
            WriteUserData(udf);
        }

        private static UserdataFileFormat ReadUserData()
        {
            UserdataFileFormat udf;
            if (File.Exists("sites.info"))
            {
                using (FormattedReader fr = new FormattedReader("sites.info"))
                {
                    udf = fr.Read<UserdataFileFormat>();
                }
            }
            else
            {
                udf = UserdataFileFormat.Init();
            }
            return udf;
        }

        private static void WriteUserData(UserdataFileFormat udf)
        {
            using (FormattedWriter fw = new FormattedWriter("sites.info"))
            {
                fw.Write(udf);
            }
        }

        ServerInfo info = null;
        public ServerInfo ServerInfo
        {
            get
            {
                return info;
            }
        }

        private void start_Click(object sender, EventArgs e)
        {
            info = (ServerInfo)listBox1.SelectedItem;
            this.Close();
        }

        bool updating = false;
        void UpdateUI()
        {
            if (!updating)
            {
                if (listBox1.SelectedItem == null)
                {
                    btn_start.Enabled = false;
                    btn_test.Enabled = false;
                    txt_username.Enabled = false;
                    txt_password.Enabled = false;
                    txt_url.Enabled = false;
                }
                else
                {
                    btn_start.Enabled = true;
                    btn_test.Enabled = true;
                    txt_username.Enabled = true;
                    txt_password.Enabled = true;
                    txt_url.Enabled = true;

                    ServerInfo si = (ServerInfo)listBox1.SelectedItem;
                    txt_username.Text = si.username;
                    txt_password.Text = si.password;
                    txt_url.Text = si.conn.URL;
                    txt_name.Text = si.name;
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void btn_newSite_Click(object sender, EventArgs e)
        {
            var udf = ReadUserData();
            udf.AddNew();
            WriteUserData(udf);
            UpdateServerListFromFile();
            UpdateUI();
        }

        private void btn_test_Click(object sender, EventArgs e)
        {
            UpdateFileFromServerList();
            try
            {
                ServerInfo si = (ServerInfo)listBox1.SelectedItem;
                si.conn.GetCategories(0, si.username, si.password);

                try
                {
                    var plugin = new PluginRpc(si.conn.URL);
                    plugin.GetMediumSize();
                    MessageBox.Show("Success!");
                }
                catch
                {
                    MessageBox.Show("Please make sure you have the BunnyBlogger plugin installed.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed: " + ex.Message + " please check your blog URL or that you have enabled XML-RPC");
            }
        }

        private void txt_username_TextChanged(object sender, EventArgs e)
        {
            ServerInfo si = (ServerInfo)listBox1.SelectedItem;
            si.username = txt_username.Text;
        }

        private void txt_password_TextChanged(object sender, EventArgs e)
        {
            ServerInfo si = (ServerInfo)listBox1.SelectedItem;
            si.password = txt_password.Text;
        }

        private void txt_url_TextChanged(object sender, EventArgs e)
        {
            ServerInfo si = (ServerInfo)listBox1.SelectedItem;
            si.conn = new WPConnection(txt_url.Text);
        }

        private void txt_Name_TextChanged(object sender, EventArgs e)
        {
            ServerInfo si = (ServerInfo)listBox1.SelectedItem;
            si.name = txt_name.Text;
            int selectedidx = listBox1.SelectedIndex;
            updating = true;
            listBox1.Items[selectedidx] = si;
            updating = false;
            txt_name.Focus();
        }
    }
}
