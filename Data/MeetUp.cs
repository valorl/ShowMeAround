using System;
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
        //test
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public User Traveler { get; set; }
        [DataMember]
        public User Guide { get; set; }
        [DataMember]
        public DateTime StartDate { get; set; }
        [DataMember]
        public DateTime FinishDate { get; set; }
        [DataMember]
        public String City { get; set; }
        [DataMember]
        public Enum TravelerState { get; set; }
        [DataMember]
        public Enum GuideState { get; set; }
    }
}
