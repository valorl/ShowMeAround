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
        public User User { get; set; }
        public Language Languages { get; set; }
        public List<InterestModel> Interests { get; set; }
        public List<Language> LanguageContainer { get; set; }

        public Registration()
        {
            User = new User();
            Interests = new List<InterestModel>();
            LanguageContainer = new List<Language>();
        }
    }

    public class InterestModel
    {
        public Interest Interest { get; set; }
        public bool IsSelected { set; get; }
    }
}