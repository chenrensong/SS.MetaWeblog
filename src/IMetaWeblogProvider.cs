using System.Collections.Generic;
using System.Threading.Tasks;

namespace SS.MetaWeblog
{
    public interface IMetaWeblogProvider
    {
        Task<MetaUserInfo> GetUserInfoAsync(string key, string username, string password);

        Task<IList<MetaBlogInfo>> GetUsersBlogsAsync(string key, string username, string password);

        Task<MetaPost> GetPostAsync(string postid, string username, string password);

        Task<IList<MetaPost>> GetRecentPostsAsync(string blogid, string username, string password, int numberOfPosts);

        string AddPost(string blogid, string username, string password, MetaPost post, bool publish);

        bool DeletePost(string key, string postid, string username, string password, bool publish);

        bool EditPost(string postid, string username, string password, MetaPost post, bool publish);

        MetaCategoryInfo[] GetCategories(string blogid, string username, string password);

        int AddCategory(string key, string username, string password, MetaNewCategory category);

        MetaMediaObjectInfo NewMediaObject(string blogid, string username, string password, MetaMediaObject mediaObject);
    }
}