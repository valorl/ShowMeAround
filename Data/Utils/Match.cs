using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Data.Utils
{   
    [DataContract]
    public class Match : IComparable
    {
        public Match()
        {

        }
        [DataMember]
        public User Traveler { get; set; }
        [DataMember]
        public User Guide { get; set; }
        [DataMember]
        public double Score { get; set; }

        public int CompareTo(object obj)
        {
            Match m = (Match)obj;
            return (int) (Math.Round(m.Score) - Math.Round(this.Score));
        }
    }
}
