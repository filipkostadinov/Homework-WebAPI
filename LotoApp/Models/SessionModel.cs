using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class SessionModel
    {
        public int Id { get; set; }
        public List<int> DrawnNumbers { get; set; }
        public List<TicketModel> Tickets { get; set; } = new List<TicketModel>();
        public int AdminId { get; set; }
        public bool IsOpen { get; set; }
        //public List<TicketModel> Winners { get; set; } = new List<TicketModel>();
    }
}
