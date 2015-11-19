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
    public class Session
    {
        public Session()
        {

        }

        public Session(User user)
        {
            UserID = user.Id;
            Token = Guid.NewGuid().ToString("N");
            TimeStamp = DateTime.Now;
        }

        [Key]
        [DataMember(Order = 0)]
        public string Token { get; set; }
        [DataMember(Order = 1)]
        public int UserID { get; set; }
        [DataMember(Order = 2)]
        public DateTime TimeStamp { get; set; }
    }
}
