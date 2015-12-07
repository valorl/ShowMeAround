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
using Data.Utils;
using System.Threading.Tasks;

namespace Service
{
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
            if (!(incReq.Headers.Get("sma_admin_pass") != null && incReq.Headers.Get("sma_admin_pass") == auth.SMA_ADMIN_PASS))
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

        public List<InterestPopularity> GetAllTrendingInterestsAsync()
        {
            var interests = interestDA.GetAll().ToArray();
            var counts = new int[interests.Length];
            var users = userDA.GetAll().ToArray();
            var interestsPopularity = new InterestPopularity[interests.Length];

            Parallel.For(0, interests.Length, i =>
            {
                Parallel.For(0, users.Length, u =>
                {
                    if (users[u].Interests.Contains(interests[i]))
                    {
                        counts[i]++;
                    }
                });
            });

            Parallel.For(0, interests.Length, i =>
            {
                interestsPopularity[i] = new InterestPopularity()
                {
                    Interest = interests[i],
                    Popularity = (int)Math.Round((double)counts[i] / users.Length * 100)
                };
            });

            return interestsPopularity.OrderByDescending(i => i.Popularity).ToList();
        }

        public List<Language> GetAllLanguages()
        {
            return languageDA.GetAll().ToList();
        }

        public User GetById(string id)
        {
            int intID = Convert.ToInt32(id);
            var user = userDA.GetOneByID(intID);
            return user;
        }

        public User Create(User user)
        {
            userDA.Insert(user);
            userDA.SaveChanges();
            return userDA.GetOneByEmail(user.Email);
        }

        public User Update(string id, User user)
        {
            user.Id = Convert.ToInt32(id);
            User authUser = auth.Authorize(WebOperationContext.Current.IncomingRequest);
            if (authUser.Id != user.Id) throw new WebFaultException(System.Net.HttpStatusCode.Unauthorized);

            userDA.Update(user);
            userDA.SaveChanges();
            return userDA.GetOneByID(user.Id);
        }

        public void Delete(string id)
        {
            var incReq = WebOperationContext.Current.IncomingRequest;
            if (!(incReq.Headers.Get("sma_admin_pass") != null && incReq.Headers.Get("sma_admin_pass") == auth.SMA_ADMIN_PASS))
            {
                auth.Authorize(WebOperationContext.Current.IncomingRequest);
            }

            var toBeDeleted = userDA.GetOneByID(Convert.ToInt32(id));
            if (toBeDeleted != null)
            {
                userDA.Delete(toBeDeleted);
                userDA.SaveChanges();
            }
        }
    }
}
