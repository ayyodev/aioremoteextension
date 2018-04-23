using System;

namespace Models
{
    public class WorkerCommandMessage
    {
        public DateTime? DateCreated { get; set; }
        public DateTime? DateReceived { get; set; }
        public WorkerCommandType CommandType { get; set; }
        public string Coin { get; set; }
    }

    public enum WorkerCommandType
    {
        GetStatus = 1,
        StartMining = 2,
        StopMining = 3
    }
}
