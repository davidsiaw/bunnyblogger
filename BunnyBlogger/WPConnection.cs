using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CookComputing.XmlRpc;
using System.Reflection;

namespace BunnyBlogger
{



    [Serializable]
    public class CategoryFullInfo
    {
        public int categoryId;
        public int parentId;
        public string description;
        public string categoryName;
        public string htmlUrl;
        public string rssUrl;
    }

    public class CustomFieldInfo
    {
        public int id;
        public string key;
        public string value;
    }

    public class PageFullInfo
    {
        public DateTime dateCreated;
        public int userid;
        public int page_id;
        public string page_status;
        public string description;
        public string title;
        public string link;
        public string permaLink;
        public string[] categories;
        public string excerpt;
        public string text_more;
        public int mt_allow_comments;
        public int mt_allow_pings;
        public string wp_slug;
        public string wp_password;
        public string wp_author;
        public int wp_page_parent_id;
        public string wp_page_parent_title;
        public int wp_page_order;
        public int wp_author_id;
        public string wp_author_display_name;
        public DateTime date_created_gmt;
        public CustomFieldInfo[] custom_fields;
        public string wp_page_template;
    }

    public class PageInfo
    {
        public int page_id;
        public string page_title;
        public int page_parent_id;
        public DateTime dateCreated;
    }

    public class PageCreationInfo
    {
        public string wp_slug;
        public string wp_password;
        public int wp_page_parent_id;
        public int wp_page_order;
        public int wp_author_id;
        public string title;
        public string description;
        public string mt_excerpt;
        public string mt_text_more;
        public int mt_allow_comments;
        public int mt_allow_pings;
        public DateTime dateCreated;
        public CustomFieldInfo[] custom_fields;
    }

    public class AuthorInfo
    {
        public int user_id;
        public string user_login;
        public string display_name;
        public string user_email;
        public string meta_value;
    }

    public class CategoryCreationInfo
    {
        public string name;
        public string slug;
        public int parent_id;
        public string description;
    }

    public class CategorySuggestInfo
    {
        public int category_id;
        public string category_name;
    }

    public class FileUploadInfo
    {
        public string name;
        public string type;
        public byte[] bits;
        public bool overwrite;
    }

    public class FileUploadReturnInfo
    {
        public string file;
        public string url;
        public string type;
    }

    public class MWPost
    {
        public string permaLink;
        public string postid;
        public string wp_password;
        public string wp_author_display_name;
        public DateTime date_created_gmt;
        public string mt_text_more;
        public string mt_excerpt;
        public string description;
        public int mt_allow_pings;
        public string title;
        public string wp_slug;
        public string wp_author_id;
        public string userid;
        public string mt_keywords;
        public string post_status;
        public string link;
        public string dateCreated;
        public CustomFieldInfo[] custom_fields;
        public string[] categories;
        public string mt_allow_comments;

    }


    public class XMLRPCConnection<T> where T : IXmlRpcProxy
    {
        protected T proxy = XmlRpcProxyGen.Create<T>();

        public XMLRPCConnection(string url)
        {
            proxy.Url = url;
        }

        public string URL
        {
            get
            {
                return proxy.Url;
            }
        }

        public T Proxy
        {
            get
            {
                return proxy;
            }
        }

        public XmlRpcStruct MapTypeToData(object structure)
        {
            XmlRpcStruct result = new XmlRpcStruct();

            FieldInfo[] fis = structure.GetType().GetFields();
            foreach (FieldInfo fi in fis)
            {
                if (fi.FieldType == typeof(int) || fi.FieldType == typeof(string) || fi.FieldType == typeof(DateTime) || fi.FieldType == typeof(bool) || fi.FieldType == typeof(byte[]))
                {
                    result[fi.Name] = fi.GetValue(structure);
                }
            }
            return result;
        }

        // Map an XmlRpcStruct to a type
        public object MapDataToType(Type structuretype, XmlRpcStruct input)
        {
            object result = structuretype.GetConstructors()[0].Invoke(null);
            FieldInfo[] fis = structuretype.GetFields();
            foreach (FieldInfo fi in fis)
            {
                if (fi.FieldType.IsArray)
                {
                    // If the input data is in an XmlRpcStruct, we need to map this.
                    Array arr = input[fi.Name] as Array;
                    if (arr.GetType().GetElementType() == typeof(XmlRpcStruct) || arr.GetType().GetElementType() == typeof(object))
                    {
                        XmlRpcStruct[] structs = new XmlRpcStruct[arr.Length];
                        for (int i = 0; i < arr.Length; i++)
                        {
                            structs[i] = (XmlRpcStruct)arr.GetValue(i);
                        }
                        fi.SetValue(result, MapDataToType(fi.FieldType.GetElementType(), structs));
                    }
                    else
                    {
                        Array res = Array.CreateInstance(fi.FieldType.GetElementType(), arr.Length);
                        arr.CopyTo(res, 0);
                        fi.SetValue(result, res);
                    }

                }
                else if (fi.FieldType == typeof(int))
                {
                    fi.SetValue(result, int.Parse(input[fi.Name].ToString()));
                }
                else if (fi.FieldType == typeof(DateTime))
                {
                    fi.SetValue(result, DateTime.Parse(input[fi.Name].ToString()));
                }
                else if (fi.FieldType == typeof(byte[]))
                {
                    fi.SetValue(result, (byte[])input[fi.Name]);
                }
                else
                {
                    if (input[fi.Name] != null)
                    {
                        fi.SetValue(result, input[fi.Name].ToString());
                    }
                }
            }
            return result;
        }

        // Map a bunch of XmlRpcStructs to a type
        public object[] MapDataToType(Type structuretype, XmlRpcStruct[] inputs)
        {
            object[] items = (object[])Array.CreateInstance(structuretype, inputs.Length);
            for (int i = 0; i < inputs.Length; i++)
            {
                items[i] = MapDataToType(structuretype, inputs[i]);
            }
            return items;
        }
    }

    public class WPConnection : XMLRPCConnection<IWordpressXmlRpc>
    {
        public WPConnection(string url)
            : base(url)
        {
        }

        public PageFullInfo GetPage(int blog_id, int page_id, string username, string password)
        {
            XmlRpcStruct resp = proxy.GetPage(blog_id, page_id, username, password);
            PageFullInfo page = (PageFullInfo)MapDataToType(typeof(PageFullInfo), resp);
            return page;
        }

        public PageFullInfo[] GetPages(int blog_id, string username, string password)
        {
            XmlRpcStruct[] resp = proxy.GetPages(blog_id, username, password);
            PageFullInfo[] pages = (PageFullInfo[])MapDataToType(typeof(PageFullInfo), resp);

            return pages;
        }

        public PageInfo[] GetPageList(int blog_id, string username, string password)
        {
            XmlRpcStruct[] resp = proxy.GetPageList(blog_id, username, password);
            PageInfo[] pages = (PageInfo[])MapDataToType(typeof(PageInfo), resp);

            return pages;
        }

        public int NewPage(int blog_id, string username, string password, PageCreationInfo content, bool publish)
        {
            return int.Parse(proxy.NewPage(blog_id, username, password, MapTypeToData(content), publish));
        }

        public bool DeletePage(int blog_id, string username, string password, int page_id)
        {
            return proxy.DeletePage(blog_id, username, password, page_id);
        }

        public bool EditPage(int blog_id, int page_id, string username, string password, PageCreationInfo content, bool publish)
        {
            return proxy.EditPage(blog_id,page_id, username, password, MapTypeToData(content), publish);
        }

        public AuthorInfo[] GetAuthors(int blog_id, string username, string password)
        {
            XmlRpcStruct[] resp = proxy.GetAuthors(blog_id, username, password);
            return (AuthorInfo[])MapDataToType(typeof(AuthorInfo), resp);
        }

        public CategoryFullInfo[] GetCategories(int blog_id, string username, string password)
        {
            XmlRpcStruct[] resp = proxy.GetCategories(blog_id, username, password);
            CategoryFullInfo[] cats = (CategoryFullInfo[])MapDataToType(typeof(CategoryFullInfo), resp);

            return cats;
        }

        public int NewCategory(int blog_id, string username, string password, CategoryCreationInfo info)
        {
            return proxy.NewCategory(blog_id, username, password, MapTypeToData(info));
        }

        public CategorySuggestInfo[] SuggestCategories(int blog_id, string username, string password, string category, int max_results)
        {
            XmlRpcStruct[] resp = proxy.SuggestCategories(blog_id, username, password, category, max_results);
            return (CategorySuggestInfo[])MapDataToType(typeof(CategorySuggestInfo), resp);
        }

        public FileUploadReturnInfo UploadFile(int blog_id, string username, string password, FileUploadInfo data)
        {
            XmlRpcStruct resp = proxy.UploadFile(blog_id, username, password, MapTypeToData(data));
            return (FileUploadReturnInfo)MapDataToType(typeof(FileUploadReturnInfo), resp);
        }

        public XmlRpcStruct GetOptions(int blog_id, string username, string password, XmlRpcStruct[] options)
        {
            return proxy.GetOptions(blog_id, username, password, options);
        }

        public int NewPost(int site_id, int blog_id, string username, string password, string content, bool publish)
        {
            return proxy.NewPost(site_id, blog_id, username, password, content, publish);
        }

        public bool EditPost(int site_id, int post_id, string username, string password, string content, bool publish)
        {
            return proxy.EditPost(site_id, post_id, username, password, content, publish);
        }

        public bool DeletePost(int site_id, int post_id, string username, string password, bool publish)
        {
            return DeletePost(site_id, post_id, username, password, publish);
        }

        public bool SetPostCategories(int post_ID, string username, string password, CategoryFullInfo[] cats)
        {
            XmlRpcStruct[] categories = new XmlRpcStruct[cats.Length];

            for (int i = 0; i < categories.Length; i++)
            {
                categories[i] = MapTypeToData(cats[i]);
            }

            return proxy.SetPostCategories(post_ID.ToString(), username, password, categories);

        }

        public MWPost MWGetPost(int post_ID, string username, string password)
        {
            XmlRpcStruct result = proxy.MWGetPost(post_ID.ToString(), username, password);
            MWPost post = MapDataToType(typeof(MWPost), result) as MWPost;
            return post;
        }

        public bool MWEditPost(int post_ID, string username, string password, MWPost content)
        {
            XmlRpcStruct post = MapTypeToData(content);
            return proxy.MWEditPost(post_ID.ToString(), username, password, post, true);
        }

    }
}
