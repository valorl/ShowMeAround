using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Data
{
    [DataContract]
    public class Language
    {
        public Language(string name)
        {
            this.Name = name;
        }
        public Language() { }

        [DataMember]
        [Key]
        public string Name { get; set; }
        public List<User> Users { get; set; }
    }
}
