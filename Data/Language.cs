using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class Language
    {
        public Language(string name)
        {
            this.Name = name;
        }
        public Language() { }

        [Key]
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
