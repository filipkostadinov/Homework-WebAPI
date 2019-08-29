using DataAccess;
using DataModels;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class TicketService : ITicketService
    {
        private readonly IRepository<Ticket> _ticketRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Session> _sessionRepository;

        public TicketService(IRepository<Ticket> ticketRepo, IRepository<User> userRepo, IRepository<Session> sessionRepository)
        {
            _ticketRepository = ticketRepo;
            _userRepository = userRepo;
            _sessionRepository = sessionRepository;
        }

        public void AddTicket(TicketModel model)
        {
            if (model.ChosenNumbers.Distinct().Count() != model.ChosenNumbers.Count())
            {
                throw new Exception("Numbers should be different");
            }
            if (model.ChosenNumbers.Count() != 7)
            {
                throw new Exception("Invalid count of chosen numbers");
            }
            if (model.ChosenNumbers.Max() > 37 || model.ChosenNumbers.Min() < 0)
            {
                throw new Exception("Invalid range of numbers");
            }

            var user = _userRepository.GetById(model.UserId);

            var ticket = new Ticket()
            {
                ChosenNumbers = string.Join("-", model.ChosenNumbers),
                UserId = user.Id,
                SessionId = _sessionRepository.GetAll().SingleOrDefault(x => x.IsOpen).Id
            };

            _ticketRepository.Insert(ticket);
        }

        public IEnumerable<TicketModel> GetUserTickets(int userId)
        {
            var user = _userRepository.GetById(userId);

            //var tickets = _ticketRepository.GetAll().Where(x => x.UserId == userId);

            if (user.Tickets.Count() == 0) return null;

            var ticketModels = user.Tickets
                .Select(x => new TicketModel
                {
                    ChosenNumbers = x.ChosenNumbers.Split('-').Select(n => Convert.ToInt32(n)).ToList(),
                    UserId = x.UserId,
                    SessionId = x.SessionId,
                    IsWinner = x.IsWinner,
                    Prize = (Prize)x.Prize
                });
            return ticketModels;
        }
    }
}
