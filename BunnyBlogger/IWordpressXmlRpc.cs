using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CookComputing.XmlRpc;

namespace BunnyBlogger
{

    public interface IWordpressXmlRpc : IXmlRpcProxy
    {
        // Reference http://codex.wordpress.org/XML-RPC_wp


        [XmlRpcMethod("wp.getPage")]
        XmlRpcStruct GetPage(int blog_id, int page_id, string username, string password);

        [XmlRpcMethod("wp.getPages")]
        XmlRpcStruct[] GetPages(int blog_id, string username, string password);

        [XmlRpcMethod("wp.getPageList")]
        XmlRpcStruct[] GetPageList(int blog_id, string username, string password);

        [XmlRpcMethod("wp.newPage")]
        string NewPage(int blog_id, string username, string password, XmlRpcStruct content, bool publish);

        [XmlRpcMethod("wp.deletePage")]
        bool DeletePage(int blog_id, string username, string password, int page_id);

        [XmlRpcMethod("wp.editPage")]
        bool EditPage(int blog_id, int page_id, string username, string password, XmlRpcStruct content, bool publish);

        [XmlRpcMethod("wp.getAuthors")]
        XmlRpcStruct[] GetAuthors(int blog_id, string username, string password);

        [XmlRpcMethod("wp.getCategories")]
        XmlRpcStruct[] GetCategories(int blog_id, string username, string password);

        [XmlRpcMethod("wp.newCategory")]
        int NewCategory(int blog_id, string username, string password, XmlRpcStruct info);

        [XmlRpcMethod("wp.suggestCategories")]
        XmlRpcStruct[] SuggestCategories(int blog_id, string username, string password, string category, int max_results);


        [XmlRpcMethod("wp.uploadFile")]
        XmlRpcStruct UploadFile(int blog_id, string username, string password, XmlRpcStruct data);

        [XmlRpcMethod("wp.getComment")]
        XmlRpcStruct GetComment(int blog_id, string username, string password, int comment_id);

        [XmlRpcMethod("wp.getComments")]
        XmlRpcStruct GetComments(int blog_id, string username, string password, XmlRpcStruct post);

        [XmlRpcMethod("wp.getOptions")]
        XmlRpcStruct GetOptions(int blog_id, string username, string password, XmlRpcStruct[] options);


        [XmlRpcMethod("blogger.getUsersBlogs")]
        XmlRpcStruct[] GetUsersBlogs(int site_id, string username, string password);

        [XmlRpcMethod("blogger.getPost")]
        XmlRpcStruct GetPost(int site_id, int post_id, string username, string password);

        [XmlRpcMethod("blogger.getRecentPosts")]
        XmlRpcStruct[] GetRecentPosts(int site_id, int blog_id, string username, string password, int num_posts);

        [XmlRpcMethod("blogger.newPost")]
        int NewPost(int site_id, int blog_id, string username, string password, string content, bool publish);

        [XmlRpcMethod("blogger.editPost")]
        bool EditPost(int site_id, int post_id, string username, string password, string content, bool publish);

        [XmlRpcMethod("blogger.deletePost")]
        bool DeletePost(int site_id, int post_id, string username, string password, bool publish);

        [XmlRpcMethod("mt.setPostCategories")]
        bool SetPostCategories(string post_ID, string username, string password, XmlRpcStruct[] cats);

        [XmlRpcMethod("metaWeblog.getPost")]
        XmlRpcStruct MWGetPost(string post_ID, string username, string password);

        [XmlRpcMethod("metaWeblog.editPost")]
        bool MWEditPost(string postId, string username, string password, XmlRpcStruct content, bool publish);
    }
}
