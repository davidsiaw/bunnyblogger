using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BunnyBlogger;

namespace WordLaunch
{
    public class ServerInfo
    {
        public ServerInfo(WPConnection conn, string username, string password)
        {
            this.conn = conn;
            this.username = username;
            this.password = password;
        }
        public WPConnection conn;
        public string username;
        public string password;

        public override string ToString()
        {
            return conn.URL;
        }
    }
}
