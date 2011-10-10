using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CookComputing.XmlRpc;

namespace BunnyBlogger
{
    public interface IPluginRpc : IXmlRpcProxy
    {
        [XmlRpcMethod("bunny.mediumPictureSize")]
        XmlRpcStruct GetMediumPictureSize();

        [XmlRpcMethod("bunny.getAPostId")]
        string GetAPostId(string username, string password);
    }

    public class PicSize
    {
        public int width;
        public int height;
    }

    public class PluginRpc : XMLRPCConnection<IPluginRpc>
    {
        public PluginRpc(string url)
            : base(url)
        {
        }

        public PicSize GetMediumSize()
        {
            return (PicSize)MapDataToType(typeof(PicSize), Proxy.GetMediumPictureSize());
        }


    }
}
