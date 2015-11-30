using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Data.Utils
{
    [DataContract]
    public class LoginCredentials
    {
        public LoginCredentials()
        {

        }

        [Required(ErrorMessage = "Please enter your e-mail.")]
        [DataMember]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your password")]
        [DataMember]
        public string Pwd { get; set; }
    }
}
