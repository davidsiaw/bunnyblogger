using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WordLaunch
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            LoadPreviousData(out m_url, out m_username, out m_password);
            txt_url.Text = m_url;
            txt_username.Text = m_username;
            txt_password.Text = m_password;
        }

        string m_url;
        string m_password;
        string m_username;
        bool m_go;

        public string URL
        {
            get
            {
                return m_url;
            }
        }

        public string Username
        {
            get
            {
                return m_username;
            }
        }

        public string Password
        {
            get
            {
                return m_password;
            }
        }

        public bool Go
        {
            get
            {
                return m_go;
            }
        }

        private void txt_url_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_go_Click(object sender, EventArgs e)
        {
            m_url = txt_url.Text;
            m_username = txt_username.Text;
            m_password = txt_password.Text;
            m_go = true;

            SaveData(m_url, m_username, m_password);
            Close();
        }


        bool LoadPreviousData(out string url, out string username, out string password)
        {
            if (!File.Exists("savedata.ini"))
            {
                url = "";
                username = "";
                password = "";
                return false;
            }

            StreamReader sr = new StreamReader("savedata.ini");
            url = sr.ReadLine();
            username = sr.ReadLine();
            password = sr.ReadLine();

            sr.Close();

            return true;
        }

        void SaveData(string url, string username, string password)
        {
            StreamWriter sw = new StreamWriter("savedata.ini");
            sw.WriteLine(url);
            sw.WriteLine(username);
            sw.WriteLine(password);
            sw.Close();
        }

        private void btn_no_Click(object sender, EventArgs e)
        {
            m_go = false;
            Close();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
