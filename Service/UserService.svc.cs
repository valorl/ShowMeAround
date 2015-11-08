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
            throw new NotImplementedException();
        }

        public List<User> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public User Create(User user)
        {
            throw new NotImplementedException();
        }

        public User Update(int id, User user)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
