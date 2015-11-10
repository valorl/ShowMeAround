using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Data
{
    [DataContract]
    public class Interest
    {
        public Interest(string name)
        {
            this.Name = name;
        }
        public Interest() { }
        [DataMember]
        [Key]
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
