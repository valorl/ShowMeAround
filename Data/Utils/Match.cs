using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Data.Utils
{   
    [DataContract]
    public class Match
    {
        public Match()
        {

        }
        [DataMember]
        public User Traveler { get; set; }
        [DataMember]
        public User Guide { get; set; }
        [DataMember]
        public int Score { get; set; }

        public int ScorePercentage
        {
            get
            {
                return (int)Math.Round(((double)Score / 300) * 100);
            }
        }

    }
}
