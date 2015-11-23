using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Web.Mvc;

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

        [Required(ErrorMessage ="Please enter your first name")]
        [DataType(DataType.Text)]
        [Display(Name = "FirstName")]
        [DataMember(Order = 1)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]
        [DataType(DataType.Text)]
        [Display(Name = "LastName")]
        [DataMember(Order = 2)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your e-mail address")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail address")]
        [EmailAddress(ErrorMessage = "Please enter a valid e-mail address.")]
        [DataMember(Order = 3)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please select your date of birth")]
        [DataType(DataType.Date)]
        [DataMember(Order = 4)]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Please select at least one language")]
        [DataMember(Order = 5)]
        public List<Language> Languages { get; set; }

        [Required(ErrorMessage = "Please select at least three interests")]
        [DataMember(Order = 6)]
        public List<Interest> Interests { get; set; }

        //Auth
        [Required(ErrorMessage = "Please enter your password")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*(_|[^\w])).+$", ErrorMessage = @"Password must have one capital, one special character and one numerical character")]
        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
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
