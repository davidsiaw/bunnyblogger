namespace WordLaunch
{
    partial class SelectionForm
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_newSite = new System.Windows.Forms.Button();
            this.txt_username = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_url = new System.Windows.Forms.TextBox();
            this.btn_test = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.IntegralHeight = false;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(337, 287);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // btn_start
            // 
            this.btn_start.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_start.Location = new System.Drawing.Point(355, 171);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(252, 186);
            this.btn_start.TabIndex = 5;
            this.btn_start.Text = "Start";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.start_Click);
            // 
            // btn_newSite
            // 
            this.btn_newSite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_newSite.Location = new System.Drawing.Point(12, 334);
            this.btn_newSite.Name = "btn_newSite";
            this.btn_newSite.Size = new System.Drawing.Size(337, 23);
            this.btn_newSite.TabIndex = 7;
            this.btn_newSite.Text = "New Site...";
            this.btn_newSite.UseVisualStyleBackColor = true;
            this.btn_newSite.Click += new System.EventHandler(this.btn_newSite_Click);
            // 
            // txt_username
            // 
            this.txt_username.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_username.Location = new System.Drawing.Point(355, 67);
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(252, 20);
            this.txt_username.TabIndex = 2;
            this.txt_username.TextChanged += new System.EventHandler(this.txt_username_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(355, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(355, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Password";
            // 
            // txt_password
            // 
            this.txt_password.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_password.Location = new System.Drawing.Point(355, 106);
            this.txt_password.Name = "txt_password";
            this.txt_password.PasswordChar = '*';
            this.txt_password.Size = new System.Drawing.Size(252, 20);
            this.txt_password.TabIndex = 3;
            this.txt_password.TextChanged += new System.EventHandler(this.txt_password_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(355, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(203, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "URL (i.e. http://myblog.com/xmlrpc.php\")";
            // 
            // txt_url
            // 
            this.txt_url.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_url.Location = new System.Drawing.Point(355, 145);
            this.txt_url.Name = "txt_url";
            this.txt_url.Size = new System.Drawing.Size(252, 20);
            this.txt_url.TabIndex = 4;
            this.txt_url.TextChanged += new System.EventHandler(this.txt_url_TextChanged);
            // 
            // btn_test
            // 
            this.btn_test.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_test.Location = new System.Drawing.Point(12, 305);
            this.btn_test.Name = "btn_test";
            this.btn_test.Size = new System.Drawing.Size(337, 23);
            this.btn_test.TabIndex = 6;
            this.btn_test.Text = "Test";
            this.btn_test.UseVisualStyleBackColor = true;
            this.btn_test.Click += new System.EventHandler(this.btn_test_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(355, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Name";
            // 
            // txt_name
            // 
            this.txt_name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_name.Location = new System.Drawing.Point(355, 28);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(252, 20);
            this.txt_name.TabIndex = 1;
            this.txt_name.TextChanged += new System.EventHandler(this.txt_Name_TextChanged);
            // 
            // SelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 369);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.btn_test);
            this.Controls.Add(this.txt_url);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_username);
            this.Controls.Add(this.btn_newSite);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.listBox1);
            this.Name = "SelectionForm";
            this.Text = "Choose a site to connect to...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_newSite;
        private System.Windows.Forms.TextBox txt_username;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_url;
        private System.Windows.Forms.Button btn_test;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_name;

    }
}