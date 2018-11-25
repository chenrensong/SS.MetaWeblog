using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SS.MetaWeblog
{
    public class MetaWeblogService : XmlRpcService
    {
        private IMetaWeblogProvider _provider = null;
        private ILogger<MetaWeblogService> _logger = null;

        public MetaWeblogService(IMetaWeblogProvider provider, ILogger<MetaWeblogService> logger) : base(logger)
        {
            _provider = provider;
            _logger = logger;
        }

        [XmlRpcMethod("blogger.getUsersBlogs")]
        public async Task<IList<MetaBlogInfo>> GetUsersBlogs(string key, string username, string password)
        {
            _logger.LogInformation($"MetaWeblog:GetUserBlogs is called");
            return await _provider.GetUsersBlogsAsync(key, username, password);
        }

        [XmlRpcMethod("blogger.getUserInfo")]
        public async Task<MetaUserInfo> GetUserInfoAsync(string key, string username, string password)
        {
            _logger.LogInformation($"MetaWeblog:GetUserInfo is called");
            return await _provider.GetUserInfoAsync(key, username, password);
        }

        [XmlRpcMethod("wp.newCategory")]
        public int AddCategory(string key, string username, string password, MetaNewCategory category)
        {
            _logger.LogInformation($"MetaWeblog:AddCategory is called");
            return _provider.AddCategory(key, username, password, category);
        }

        [XmlRpcMethod("metaWeblog.getPost")]
        public async Task<MetaPost> GetPostAsync(string postid, string username, string password)
        {
            _logger.LogInformation($"MetaWeblog:GetPost is called");
            return await _provider.GetPostAsync(postid, username, password);
        }

        [XmlRpcMethod("metaWeblog.getRecentPosts")]
        public async Task<IList<MetaPost>> GetRecentPosts(string blogid, string username, string password, int numberOfPosts)
        {
            _logger.LogInformation($"MetaWeblog:GetRecentPosts is called");
            return await _provider.GetRecentPostsAsync(blogid, username, password, numberOfPosts);
        }

        [XmlRpcMethod("metaWeblog.newPost")]
        public string AddPost(string blogid, string username, string password, MetaPost post, bool publish)
        {
            _logger.LogInformation($"MetaWeblog:AddPost is called");
            return _provider.AddPost(blogid, username, password, post, publish);
        }

        [XmlRpcMethod("metaWeblog.editPost")]
        public bool EditPost(string postid, string username, string password, MetaPost post, bool publish)
        {
            _logger.LogInformation($"MetaWeblog:EditPost is called");
            return _provider.EditPost(postid, username, password, post, publish);
        }

        [XmlRpcMethod("blogger.deletePost")]
        public bool DeletePost(string key, string postid, string username, string password, bool publish)
        {
            _logger.LogInformation($"MetaWeblog:DeletePost is called");
            return _provider.DeletePost(key, postid, username, password, publish);
        }

        [XmlRpcMethod("metaWeblog.getCategories")]
        public MetaCategoryInfo[] GetCategories(string blogid, string username, string password)
        {
            _logger.LogInformation($"MetaWeblog:GetCategories is called");
            return _provider.GetCategories(blogid, username, password);
        }

        [XmlRpcMethod("metaWeblog.newMediaObject")]
        public MetaMediaObjectInfo NewMediaObject(string blogid, string username, string password, MetaMediaObject mediaObject)
        {
            _logger.LogInformation($"MetaWeblog:NewMediaObject is called");
            return _provider.NewMediaObject(blogid, username, password, mediaObject);
        }
    }
}