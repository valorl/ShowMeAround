using Data;
using Data.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class Matching
    {
        public List<Match> Matches { get; set; }
        public User User { get; set; }
        public int Age
        {
            get
            {
                DateTime now = DateTime.Today;
                int age = now.Year - User.BirthDate.Year;
                if (User.BirthDate > now.AddYears(-age)) age--;
                return age;
            }
        }

        public Matching()
        {
            User = new User();
            Matches = new List<Match>();
        }
    }

    
}