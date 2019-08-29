using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class SessionModel
    {
        public List<int> DrawnNumbers { get; set; }
        public IEnumerable<WinnerModel> Winners { get; set; } = new List<WinnerModel>();
    }
}
