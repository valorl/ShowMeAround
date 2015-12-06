using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class MeetUpModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Country Country { get; set; }
        public City City { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }

        public MeetUpModel()
        {
            City = new City();
            //test
            MinAge = 0;
            MaxAge = 100;
        }

    }
}