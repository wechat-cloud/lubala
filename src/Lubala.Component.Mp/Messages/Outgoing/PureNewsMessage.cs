﻿using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Lubala.Component.Mp.Messages
{
    [XmlRoot("xml")]
    public class PureNewsMessage : MpOutgoingMessage
    {
        public PureNewsMessage()
        {
            Articles = new List<ArticleItem>();
        }

        [XmlElement("ArticleCount")]
        public int ArticleCount { get; set; }

        [XmlArray("Articles")]
        [XmlArrayItem("item", typeof (ArticleItem))]
        public List<ArticleItem> Articles { get; set; }

        [XmlElement("Title")]
        public string Title { get; set; }

        [XmlElement("Description")]
        public string Description { get; set; }

        [XmlElement("PicUrl")]
        public string PictureUrl { get; set; }

        [XmlElement("Url")]
        public string Url { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class ArticleItem
    {
        [XmlElement("Title")]
        public string Title { get; set; }

        [XmlElement("Description")]
        public string Description { get; set; }

        [XmlElement("PicUrl")]
        public string PicUrl { get; set; }

        [XmlElement("Url")]
        public string Url { get; set; }
    }
}