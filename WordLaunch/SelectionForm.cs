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

namespace WordLaunch
{
    public partial class SelectionForm : Form
    {
        public SelectionForm()
        {
            InitializeComponent();

            using (StreamReader sr = new StreamReader("userpass.txt"))
            {
				while (!sr.EndOfStream) {
					string user = sr.ReadLine();
					string pass = sr.ReadLine();
					string url = sr.ReadLine();
					ServerInfo si = new ServerInfo(new WPConnection(url), user, pass);

					listBox1.Items.Add(si);
				}
            }

            listBox1.SelectedIndex = 0;
        }

        public ServerInfo ServerInfo
        {
            get
            {
                return (ServerInfo)listBox1.SelectedItem;
            }
        }

        private void start_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
