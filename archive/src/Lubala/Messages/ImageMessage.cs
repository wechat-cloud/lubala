﻿namespace Lubala.Messages {
    public sealed class ImageMessage : MessageBase {
        /// <summary>
        /// 开发者微信号
        /// </summary>
        public string ToUserName { get; internal set; }
        /// <summary>
        /// 发送方帐号（一个OpenID）
        /// </summary>
        public string FromUserName { get; internal set; }
        /// <summary>
        /// 消息创建时间 （整型）
        /// </summary>
        public string CreateTime { get; internal set; }
        /// <summary>
        /// image
        /// </summary>
        public string MsgType { get; internal set; }
        /// <summary>
        /// 图片链接
        /// </summary>
        public string PicUrl { get; internal set; }
        /// <summary>
        /// 图片消息媒体id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        public string MediaId { get; internal set; }
        /// <summary>
        /// 消息id，64位整型
        /// </summary>
        public string MsgId { get; internal set; }
    } 
}
