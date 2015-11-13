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
            this.Languages = new HashSet<Language>();
            this.Interests = new HashSet<Interest>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public DateTime BirthDate { get; set; }
        [DataMember]
        public ICollection<Language> Languages { get; set; }
        [DataMember]
        public ICollection<Interest> Interests { get; set; }

        //Auth
        [Column(TypeName = "varchar(MAX)")]
        [DataMember]
        public string PwdHash { get; set; }
        [Column(TypeName = "varchar(MAX)")]
        [DataMember]
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
