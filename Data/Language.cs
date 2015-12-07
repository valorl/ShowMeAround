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

        public override bool Equals(Object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Language lang = (Language)obj;
            return lang.Name == this.Name;
        }
        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
    }
}
