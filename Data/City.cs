using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    [DataContract]
    public class City
    {
        public City()
        {
            
        }
        [DataMember]
        public string Name { get; set; }
    }
}
