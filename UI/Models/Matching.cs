using Data.Utils;
using System;
using System.Collections.Generic;

namespace UI.Models
{
    public class Matching
    {
        public List<MatchingModel> Matches { get; set; }

        public Matching()
        {
            Matches = new List<MatchingModel>();
        }
    }

    public class MatchingModel
    {
        public Match Match { get; set; }
        public int Age
        {
            get
            {
                DateTime now = DateTime.Today;
                int age = now.Year - Match.Guide.BirthDate.Year;
                if (Match.Guide.BirthDate > now.AddYears(-age)) age--;
                return age;
            }
        }
    }
}