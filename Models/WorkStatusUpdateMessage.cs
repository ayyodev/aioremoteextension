using System;
using System.Collections.Generic;

namespace Models
{
    public class WorkStatusUpdateMessage
    {
        public DateTime? DateCreated { get; set; }
        public DateTime? DateReceived { get; set; }
        public List<string> AvailableCoins { get; set; }
        public List<string> GPUs { get; set; }
        public List<string> Temps { get; set; }
        public string SelectedCoin { get; set; }
        public string MiningSpeed { get; set; }
        public bool IsMining { get; set; }
        public string StatusMessage { get; set; }
    }
}
