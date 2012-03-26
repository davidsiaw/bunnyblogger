using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BunnyBlogger;

namespace WordLaunch
{
    public class ServerInfo
    {
        public ServerInfo(string name, WPConnection conn, string username, string password)
        {
            this.conn = conn;
            this.username = username;
            this.password = password;
            this.name = name;
        }
        public WPConnection conn;
        public string username;
        public string password;
        public string name;

        public override string ToString()
        {
            return name;
        }
    }
}
