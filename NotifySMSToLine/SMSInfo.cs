namespace NotifySMSToLine
{
    public class SMSInfo
    {
        /// <summary>
        /// 送信元電話番号
        /// </summary>
        public string senderPhoneNumber { get; set; }
        /// <summary>
        /// SMSの内容
        /// </summary>
        public string messageContent{ get; set; }
        /// <summary>
        /// 受信日時
        /// </summary>
        public long sentTimestamp { get; set; }
    }
}