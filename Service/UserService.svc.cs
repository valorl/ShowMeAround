using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Data;
using DataAccess;
using System.ServiceModel.Web;

namespace Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UserService.svc or UserService.svc.cs at the Solution Explorer and start debugging.
    public class UserService : IUserService
    {
        private UserDA userDA;

        public UserService()
        {
            userDA = new UserDA();
        }

        public List<User> GetAll()
        {
            // authenticate current user
            var request = WebOperationContext.Current.IncomingRequest;
            var headers = request.Headers;
            var auth_header = headers.Get("Authorization");
            if(auth_header == null) throw new WebFaultException(System.Net.HttpStatusCode.Unauthorized);  // Return 401
            
            string token = auth_header.Split()[1];


            var auth = new Utils.Authentication();
            if (!auth.ValidateToken(token)) throw new WebFaultException(System.Net.HttpStatusCode.Unauthorized);  // Return 401
            
            // Actual functionality
            return userDA.GetAll().ToList();

        }

        public User GetById(string id)
        {
            int intID = Convert.ToInt32(id);
            return userDA.GetOneByID(intID);
        }

        public User Create(User user)
        {
            // request info test
            //var request = WebOperationContext.Current.IncomingRequest;
            //var headers = request.Headers;
            //foreach (string name in headers)
            //{
            //    Console.WriteLine(name + " " + headers.Get(name));
            //}
            userDA.Insert(user);
            userDA.SaveChanges();
            return userDA.GetOneByEmail(user.Email);
        }

        public User Update(string id, User user)
        {
            user.Id = Convert.ToInt32(id);
            userDA.Update(user);
            userDA.SaveChanges();
            return userDA.GetOneByID(user.Id);
        }

        public void Delete(string id)
        {
            var toBeDeleted = userDA.GetOneByID(Convert.ToInt32(id));

            if (toBeDeleted != null)
            {
                userDA.Delete(toBeDeleted);
                userDA.SaveChanges();
            }
        }
    }
}
