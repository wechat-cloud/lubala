namespace Lubala.Messages {
    public sealed class LocationMessage : MessageBase {
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
        /// location
        /// </summary>
        public string MsgType { get; internal set; }
        /// <summary>
        /// 地理位置维度
        /// </summary>
        public string Location_X { get; internal set; }
        /// <summary>
        /// 地理位置经度
        /// </summary>
        public string Location_Y { get; internal set; }
        /// <summary>
        /// 地图缩放大小
        /// </summary>
        public string Scale { get; internal set; }
        /// <summary>
        /// 地理位置信息
        /// </summary>
        public string Label { get; internal set; }
        /// <summary>
        /// 消息id，64位整型
        /// </summary>
        public string MsgId { get; internal set; }
    } 
}
