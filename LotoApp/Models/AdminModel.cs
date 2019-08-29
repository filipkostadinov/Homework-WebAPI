using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class AdminModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Token { get; set; }
        //public List<SessionModel> Sessions { get; set; } = new List<SessionModel>();
    }
}
