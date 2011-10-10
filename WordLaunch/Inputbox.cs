using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WordLaunch
{
    public partial class Inputbox : Form
    {
        public Inputbox(string title, string message) : this(message)
        {
            this.Text = title;
        }

        public Inputbox(string message)
        {
            InitializeComponent();
            this.label1.Text = message;
        }

        public string Result
        {
            get
            {
                return textBox1.Text;
            }
        }

        private void Inputbox_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
