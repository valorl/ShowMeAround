using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Utils
{
    public class Match
    {
        public Match()
        {

        }

        public User Traveler { get; set; }
        public User Guide { get; set; }
        public double Score { get; set; }
    }
}
