using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Lubala.Core.Serialization.Attributes;

namespace Lubala.Component.Mp.Messages
{
    public class PassiveNewsMessage : MpPassiveMessage
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