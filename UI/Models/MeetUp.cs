using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class MeetUp
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Country Country { get; set; }
        public City City { get; set; }

        public MeetUp()
        {
            City = new City();
        }

    }
}