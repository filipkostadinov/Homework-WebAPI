using DataAccess;
using DataModels;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class SessionService : ISessionService
    {
        private readonly IRepository<Session> _sessionRepository;
        private readonly IRepository<Ticket> _ticketRepository;

        public SessionService(IRepository<Session> sessionRepo, IRepository<Ticket> ticketRepo)
        {
            _sessionRepository = sessionRepo;
            _ticketRepository = ticketRepo;
        }

        public SessionModel CloseSession(Session session)
        {
            List<int> numbers = new List<int>();
            int count = 0;
            while (count < 8)
            {
                var random = new Random().Next(1, 38);
                if (!numbers.Contains(random))
                {
                    numbers.Add(random);
                    count++;
                }
            }

            session.IsOpen = false;
            session.DrawnNumbers = string.Join('-', numbers);
            _sessionRepository.Update(session);

            //var tickets = _ticketRepository.GetAll().Where(x => x.SessionId == session.Id);
            var tickets = session.Tickets;

            foreach (var ticket in tickets)
            {
                int correctNumbers = 0;
                var chosenNumbers = ticket.ChosenNumbers.Split('-').Select(x => Convert.ToInt32(x));

                foreach (var number in chosenNumbers)
                {
                    if (numbers.Contains(number))
                    {
                        correctNumbers++;
                    }
                }

                if (correctNumbers >= 3)
                {
                    ticket.IsWinner = true;
                    ticket.Prize = correctNumbers;
                    _ticketRepository.Update(ticket);
                }
            }
            return GetWinners(session.Id);
        }

        public SessionModel GetWinners(int sessionId)
        {
            var session = _sessionRepository.GetById(sessionId);

            if (session == null || session.IsOpen)
            {
                return null;
            }
            var winners = _ticketRepository
                .GetAll()
                .Where(x => x.SessionId == sessionId && x.IsWinner)
                .Select(x => new WinnerModel
                {
                    FirstName = x.User.FirstName,
                    LastName = x.User.LastName,
                    ChosenNumbers = x.ChosenNumbers.Split('-').Select(n => Convert.ToInt32(n)).ToList(),
                    Prize = (Prize)x.Prize
                });
            var sessionModel = new SessionModel()
            {
                DrawnNumbers = session.DrawnNumbers.Split('-').Select(x => Convert.ToInt32(x)).ToList(),
                Winners = winners
            };
            return sessionModel;
        }

        public SessionModel OpenSession(int adminId)
        {
            Session session = new Session()
            {
                AdminId = adminId,
                IsOpen = true
            };

            var openSession = _sessionRepository.GetAll().FirstOrDefault(x => x.IsOpen);

            if (openSession == null)
            {
                _sessionRepository.Insert(session);
                return null;
            }
            _sessionRepository.Insert(session);
            return CloseSession(openSession);
        }
    }
}
