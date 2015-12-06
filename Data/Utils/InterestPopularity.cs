using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Data.Utils
{
    [DataContract]
    public class InterestPopularity
    {
        public InterestPopularity() { }

        [DataMember]
        public Interest Interest { get; set; }
        [DataMember]
        public int Popularity { get; set; }
    }
}
