using System.Collections.Generic;
using System.Threading.Tasks;

namespace SS.MetaWeblog
{
    public interface IMetaWeblogProvider
    {
        Task<UserInfo> GetUserInfoAsync(string key, string username, string password);
        Task<IList<BlogInfo>> GetUsersBlogsAsync(string key, string username, string password);

        Task<Post> GetPostAsync(string postid, string username, string password);
        Task<IList<Post>> GetRecentPostsAsync(string blogid, string username, string password, int numberOfPosts);

        string AddPost(string blogid, string username, string password, Post post, bool publish);
        bool DeletePost(string key, string postid, string username, string password, bool publish);
        bool EditPost(string postid, string username, string password, Post post, bool publish);

        CategoryInfo[] GetCategories(string blogid, string username, string password);
        int AddCategory(string key, string username, string password, NewCategory category);

        MediaObjectInfo NewMediaObject(string blogid, string username, string password, MediaObject mediaObject);
    }
}