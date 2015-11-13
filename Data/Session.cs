﻿using System;
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

        [Key]
        [DataMember]
        public string Token { get; set; }
        [DataMember]
        public int UserID { get; set; }
        [DataMember]
        public DateTime TimeStamp { get; set; }
    }
}
