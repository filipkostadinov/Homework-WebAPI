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
        IEnumerable<WinnerModel> CloseSession(Session session);
        IEnumerable<WinnerModel> GetWinners(int sessionId);
        IEnumerable<WinnerModel> OpenSession(int adminId);
    }
}
