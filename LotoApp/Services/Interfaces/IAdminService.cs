using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IAdminService
    {
        AdminModel Authenticate(string username, string password);
    }
}
