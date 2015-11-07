using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Interest
    {
        public Interest(string name)
        {
            this.Name = name;
        }
        public Interest() { }

        [Key]
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
