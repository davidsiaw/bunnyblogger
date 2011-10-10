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
    public partial class ProgressForm : Form
    {
        public ProgressForm()
        {
            InitializeComponent();
            this.progressBar1.Maximum = int.MaxValue;
            this.progressBar1.Minimum = 0;
        }

        private void ProgressForm_Load(object sender, EventArgs e)
        {

        }

        delegate void Invoker();

        public double Progress
        {
            get
            {
                return (double)this.progressBar1.Value / (double)int.MaxValue;
            }
            set
            {
                Invoke(new Invoker(delegate()
                {
                    this.progressBar1.Value = (int)((double)value * (double)int.MaxValue);
                }));
            }
        }

        public string DisplayText
        {
            get
            {
                return label1.Text;
            }
            set
            {
                Invoke(new Invoker(delegate()
                {
                    label1.Text = value;
                }));
            }
        }
    }
}
