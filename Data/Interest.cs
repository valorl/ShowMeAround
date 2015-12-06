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
        public List<User> Users { get; set; }


        // Equality logic - mainly for Matching intersections
        public override bool Equals(Object obj)
        {
            // Check for null and compare
            if (obj == null || GetType() != obj.GetType())
                return false;

            Interest interest = (Interest)obj;
            return interest.Name == this.Name;
        }
        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
    }
}
