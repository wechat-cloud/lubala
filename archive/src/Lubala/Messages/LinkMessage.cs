namespace Lubala.Messages {
    public sealed class LinkMessage : MessageBase {
        /// <summary>
        /// 接收方微信号
        /// </summary>
        public string ToUserName { get; internal set; }
        /// <summary>
        /// 发送方微信号，若为普通用户，则是一个OpenID
        /// </summary>
        public string FromUserName { get; internal set; }
        /// <summary>
        /// 消息创建时间
        /// </summary>
        public string CreateTime { get; internal set; }
        /// <summary>
        /// 消息类型，link
        /// </summary>
        public string MsgType { get; internal set; }
        /// <summary>
        /// 消息标题
        /// </summary>
        public string Title { get; internal set; }
        /// <summary>
        /// 消息描述
        /// </summary>
        public string Description { get; internal set; }
        /// <summary>
        /// 消息链接
        /// </summary>
        public string Url { get; internal set; }
        /// <summary>
        /// 消息id，64位整型
        /// </summary>
        public string MsgId { get; internal set; }
    } 
}
