using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class WinnerModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public List<int> ChosenNumbers { get; set; }
        public Prize Prize { get; set; }
    }
}
