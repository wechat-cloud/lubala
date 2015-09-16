using System.Collections.Generic;
using Lubala.Core.Serialization.Attributes;

namespace Lubala.Core.Pushing.Messages
{
    public class PassiveNewsMessage : WechatPassiveMessage
    {
        public PassiveNewsMessage()
        {
            Articles = new List<ArticleItem>();
        }

        [Node("ArticleCount")]
        public int ArticleCount { get; set; }

        [Array("Articles")]
        [ArrayItem("item", typeof (ArticleItem))]
        public List<ArticleItem> Articles { get; set; }

        [Node("Title")]
        public string Title { get; set; }

        [Node("Description")]
        public string Description { get; set; }

        [Node("PicUrl")]
        public string PictureUrl { get; set; }

        [Node("Url")]
        public string Url { get; set; }

        protected override string MsgType => "news";
    }

    public class ArticleItem
    {
        [Node("Title")]
        public string Title { get; set; }

        [Node("Description")]
        public string Description { get; set; }

        [Node("PicUrl")]
        public string PicUrl { get; set; }

        [Node("Url")]
        public string Url { get; set; }
    }
}