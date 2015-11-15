using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Data.Utils
{
    [DataContract]
    public class LoginWrapper
    {
        public LoginWrapper()
        {

        }


        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Pwd { get; set; }
    }
}
