using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace UI.Models
{
    public class Registration
    {
        public User user { get; set; }
        public Language languages { get; set; }
        public Interest interest { get; set; }
    }
}