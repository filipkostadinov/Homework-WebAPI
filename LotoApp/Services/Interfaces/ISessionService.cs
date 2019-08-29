using DataModels;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface ISessionService
    {
        //IEnumerable<int> GetDrawnNumbers(int sessionId);
        SessionModel CloseSession(Session session);
        SessionModel GetWinners(int sessionId);
        SessionModel OpenSession(int adminId);
    }
}
