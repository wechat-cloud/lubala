namespace Lubala.Messages {
    public sealed class TextMessage : MessageBase {
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
        /// text
        /// </summary>
        public string MsgType { get; internal set; }
        /// <summary>
        /// 文本消息内容
        /// </summary>
        public string Content { get; internal set; }
        /// <summary>
        /// 消息id，64位整型
        /// </summary>
        public string MsgId { get; internal set; }
    } 
}
