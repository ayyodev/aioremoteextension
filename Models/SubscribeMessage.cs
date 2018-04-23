using System;

namespace Models
{
    public class SubscribeMessage
    {
        public string WorkerName { get; set; }
        public string UserId { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateReceived { get; set; }
    }
}
