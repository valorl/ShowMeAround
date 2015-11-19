using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
namespace Data
{
    [DataContract]
    public class User
    {
        public User()
        {
            this.Languages = new List<Language>();
            this.Interests = new List<Interest>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember(Order = 0)]
        public int Id { get; set; }
        [DataMember(Order = 1)]
        public string FirstName { get; set; }
        [DataMember(Order = 2)]
        public string LastName { get; set; }
        [DataMember(Order = 3)]
        public string Email { get; set; }
        [DataMember(Order = 4)]
        public DateTime BirthDate { get; set; }
        [DataMember(Order = 5)]
        public List<Language> Languages { get; set; }
        [DataMember(Order = 6)]
        public List<Interest> Interests { get; set; }

        //Auth
        [Column(TypeName = "varchar(MAX)")]
        [DataMember(Order = 7)]
        public string PwdHash { get; set; }
        [Column(TypeName = "varchar(MAX)")]
        [DataMember(Order = 8)]
        public string PwDSalt { get; set; }


        public void AddLanguage(Language language)
        {
            if (!Languages.Any(l => l.Name == language.Name))
            {
                Languages.Add(language);
            }
        }
        public void RemoveLanguage(Language language)
        {
            if (Languages.Any(l => l.Name == language.Name))
            {
                Languages.Remove(language); 
            }
        }

        public void AddInterest(Interest interest)
        {
            if (!Interests.Any(i => i.Name == interest.Name))
            {
                Interests.Add(interest);
            }
        }
        public void RemoveInterest(Interest interest)
        {
            if (Interests.Any(i => i.Name == interest.Name))
            {
                Interests.Remove(interest);
            }
        }
    }
}
