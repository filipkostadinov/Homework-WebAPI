using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface ITicketService
    {
        //TicketModel GetTicket(int id);
        IEnumerable<TicketModel> GetUserTickets(int userId);
        void AddTicket(TicketModel model);

    }
}
