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
        public MeetUp MeetUp { get; set; }

        public MeetUpModel()
        {
            City = new City();
            MeetUp = new MeetUp();
        }

    }
}