using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using BlueBlocksLib.FileAccess;

namespace WordLaunch
{

    [StructLayout(LayoutKind.Sequential)]
    struct UserdataFileFormat
    {
        public static UserdataFileFormat Init()
        {
            UserdataFileFormat udf = new UserdataFileFormat();
            udf.numOfEntries = 0;
            udf.entries = new UserdataEntry[0];
            return udf;
        }

        [LittleEndian]
        public int numOfEntries;

        [ArraySize("numOfEntries")]
        public UserdataEntry[] entries;

        public void AddNew()
        {
            List<UserdataEntry> entrylist = new List<UserdataEntry>(entries);
            entrylist.Add(UserdataEntry.Init());
            entries = entrylist.ToArray();
            numOfEntries = entries.Length;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    struct UserdataEntry
    {
        public static UserdataEntry Init()
        {
            UserdataEntry ude = new UserdataEntry();
            ude.Name = "New Blog";
            ude.Username = "yourusername";
            ude.Password = "";
            ude.URL = "http://yourblog.com/";
            return ude;
        }

        [LittleEndian]
        public int nameLength;

        [LittleEndian]
        public int userNameLength;

        [LittleEndian]

        public int passwordLength;

        [LittleEndian]
        public int urlLength;


        [ArraySize("nameLength")]
        public byte[] name;

        [ArraySize("userNameLength")]
        public byte[] username;

        [ArraySize("passwordLength")]
        public byte[] password;

        [ArraySize("urlLength")]
        public byte[] url;

        public string Name
        {
            get
            {
                return Encoding.UTF8.GetString(name);
            }
            set
            {
                name = Encoding.UTF8.GetBytes(value);
                nameLength = name.Length;
            }
        }

        public string Username
        {
            get { 
                return Encoding.UTF8.GetString(username); 
            }
            set {
                username = Encoding.UTF8.GetBytes(value);
                userNameLength = username.Length;
            }
        }

        public string Password
        {
            get
            {
                return Encoding.UTF8.GetString(password);
            }
            set
            {
                password = Encoding.UTF8.GetBytes(value);
                passwordLength = password.Length;
            }
        }

        public string URL
        {
            get
            {
                return Encoding.UTF8.GetString(url);
            }
            set
            {
                url = Encoding.UTF8.GetBytes(value);
                urlLength = url.Length;
            }
        }
    }
}
