using System;

namespace com.gameon.data.Models
{
    public class Dota
    {
        public Tournament tournament { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public bool isCompleted { get; set; }
    }
}
