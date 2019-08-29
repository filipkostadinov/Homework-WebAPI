using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class TicketModel
    {
        public List<int> ChosenNumbers { get; set; }
        public int UserId { get; set; }
        public int SessionId { get; set; }
        public bool IsWinner { get; set; }
        public Prize Prize { get; set; }
    }
}
