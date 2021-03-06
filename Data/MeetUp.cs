﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

public enum RequestState
{
    Undefined = 0,
    Sent = 1,
    Received = 2,
    Accepted = 3,
    Declined = 4,
    Confirmed = 5,
}

namespace Data
{

    [DataContract]
    public class MeetUp
    {
        public MeetUp()
        {

        }
 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember(Order = 0)]
        public int Id { get; set; }

        [DataMember(Order = 1)]
        public User Traveler { get; set; }

        [DataMember(Order = 2)]
        public User Guide { get; set; }
        [Required]
        [DataMember(Order = 3)]
        public DateTime StartDate { get; set; }
        [Required]
        [DataMember(Order = 4)]
        public DateTime FinishDate { get; set; }
        [Required]
        [DataMember(Order = 5)]
        [ForeignKey("City")]
        public string City_Name { get; set; }

        [DataMember(Order = 6)]
        public City City { get; set; }
        [Required]
        [DataMember(Order = 7)]
        public RequestState TravelerState { get; set; }
        [Required]
        [DataMember(Order = 8)]
        public RequestState GuideState { get; set; }
    }
}
