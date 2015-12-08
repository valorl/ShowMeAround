using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class MeetUpModel
    {
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public Country Country { get; set; }
        public City City { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }

        public MeetUpModel()
        {
            City = new City();
        }

    }
}