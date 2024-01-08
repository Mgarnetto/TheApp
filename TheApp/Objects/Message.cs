namespace TheApp.Objects
{
    public class Message
    {
        public int messageID { get; set; }
        public int senderID { get; set; }
        public int receiverID { get; set; }
        public int read { get; set; }
        public int sent { get; set; }
        public int deleted { get; set; }
        public string? messageText { get; set; }
        public DateTime DateTime { get; set; }

        public Message()
        {
            // Default constructor
        }

        public Message(int messageID, int senderID, int receiverID, int read, int sent, int deleted, string? messageText, DateTime DateTime)
        {
            this.messageID = messageID;
            this.senderID = senderID;
            this.receiverID = receiverID;
            this.read = read;
            this.sent = sent;
            this.deleted = deleted;
            this.messageText = messageText;
            this.DateTime = DateTime;
        }
    }
}
