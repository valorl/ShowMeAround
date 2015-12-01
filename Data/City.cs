using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Key]
        [DataMember]
        public string Name { get; set; }

        public List<User> Users { get; set; }
    }
}
