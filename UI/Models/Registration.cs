﻿using Data;
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
        public Interest Interest { get; set; }
        

    }
}