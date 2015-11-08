using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Data;
namespace Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UserService.svc or UserService.svc.cs at the Solution Explorer and start debugging.
    public class UserService : IUserService
    {

        public List<User> GetAll()
        {
            // testing purposes
            var list = new List<User>();

            list.Add(new User
            {
                Id = 5,
                FirstName = "Valer",
                LastName = "Orlovsky",
                Email = "valer@gmail",
                BirthDate = DateTime.Now
                
            });

            return list;

        }

        public List<User> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public User Create(User user)
        {
            throw new NotImplementedException();
        }

        public User Update(string id, User user)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}
