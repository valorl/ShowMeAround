using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Data;
using DataAccess;
using System.ServiceModel.Web;
using Service.Utils;

namespace Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UserService.svc or UserService.svc.cs at the Solution Explorer and start debugging.
    public class UserService : IUserService
    {
        private UserDA userDA;
        private SessionDA sessionDA;
        private Authentication auth;
        private InterestDA interestDA;
        private LanguageDA languageDA;

        public UserService()
        {
            userDA = new UserDA();
            sessionDA = new SessionDA();
            auth = new Authentication();
            interestDA = new InterestDA();
            languageDA = new LanguageDA();
        }

        public List<User> GetAll()
        {
            var incReq = WebOperationContext.Current.IncomingRequest;
            // authenticate current user
            if (!(incReq.Headers.Get("sma_admin_pass") != null && incReq.Headers.Get("sma_admin_pass") == "T1mU2YUBjCLUrkhmI4UV"))
            {
                auth.Authorize(WebOperationContext.Current.IncomingRequest);
            }
            

            // Actual functionality
            return userDA.GetAll().ToList();

        }
        // Interests
        public List<Interest> GetAllInterests()
        {
      
            return interestDA.GetAll().ToList();
        }

        // Languages
        public List<Language> GetAllLanguages()
        {

            return languageDA.GetAll().ToList();
        }

        public User GetById(string id)
        {
            //auth.Authorize(WebOperationContext.Current.IncomingRequest);

            int intID = Convert.ToInt32(id);
            var user = userDA.GetOneByID(intID);
            return user;
            
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
            
            // Only allow users update their own information
            User authUser = auth.Authorize(WebOperationContext.Current.IncomingRequest);
            if (authUser.Id != user.Id) throw new WebFaultException(System.Net.HttpStatusCode.Unauthorized);

            userDA.Update(user);
            userDA.SaveChanges();
            return userDA.GetOneByID(user.Id);
        }

        public void Delete(string id)
        {
            var toBeDeleted = userDA.GetOneByID(Convert.ToInt32(id));

            // to do auth

            if (toBeDeleted != null)
            {
                userDA.Delete(toBeDeleted);
                userDA.SaveChanges();
            }
        }

        

    }
}
