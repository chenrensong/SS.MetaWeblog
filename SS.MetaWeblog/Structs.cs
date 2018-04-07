using System;

namespace SS.MetaWeblog
{
    public class MetaBlogInfo
    {
        public string blogid { get; set; }
        public string url { get; set; }
        public string blogName { get; set; }
    }

    public class MetaCategoryInfo
    {
        public string description{ get; set; }
        public string htmlUrl{ get; set; }
        public string rssUrl{ get; set; }
        public string title{ get; set; }
        public string categoryid{ get; set; }
    }

    public class MetaNewCategory
    {
        public string name{ get; set; }
        public int parent_id{ get; set; }
    }

    public class MetaEnclosure
    {
        public int length{ get; set; }
        public string type{ get; set; }
        public string url{ get; set; }
    }

    public class MetaPost
    {
        public DateTime dateCreated{ get; set; }
        public string description{ get; set; }
        public string title{ get; set; }
        public string[] categories{ get; set; }
        public string permalink{ get; set; }
        public object postid{ get; set; }
        public string userid{ get; set; }
        public string wp_slug{ get; set; }
    }

    public class MetaSource
    {
        public string name{ get; set; }
        public string url{ get; set; }
    }

    public class MetaUserInfo
    {
        public string userid{ get; set; }
        public string nickname{ get; set; }
        public string email{ get; set; }
        public string url{ get; set; }
    }

    public class MetaMediaObject
    {
        public string name{ get; set; }
        public string type{ get; set; }
        public string bits{ get; set; }
    }

    public class MetaMediaObjectInfo
    {
        public string url{ get; set; }
    }

}
