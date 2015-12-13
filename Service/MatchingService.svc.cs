using Data;
using Data.Utils;
using DataAccess;
using Service.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MatchingService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MatchingService.svc or MatchingService.svc.cs at the Solution Explorer and start debugging.
    public class MatchingService : IMatchingService
    {
        private ShowMeAroundContext dbContext;
        private UserDA userDA;
        private MatchingProvider provider;
        private Authentication auth;

        public MatchingService()
        {
            dbContext = new ShowMeAroundContext();
            userDA = new UserDA();
            provider = new MatchingProvider();
            auth = new Authentication();
        }

        public IEnumerable<Match> GetMatchesAsync(string userid, string city, string minAge, string maxAge)
        {
            int minAgeInt = Convert.ToInt32(minAge);
            int maxAgeInt = Convert.ToInt32(maxAge);
            if (minAgeInt == 0) minAgeInt = 18;
            if (maxAgeInt == 0) maxAgeInt = 100;

            User user = auth.Authorize(WebOperationContext.Current.IncomingRequest);
            if (user.Id != Convert.ToInt32(userid)) throw new WebFaultException(System.Net.HttpStatusCode.Unauthorized);

            var guides = userDA.GetAll()
                .Where(
                u => u.Id != user.Id 
                && u.City != null
                && u.City.Name.ToLower() == city.ToLower() 
                && u.Age >= minAgeInt
                && u.Age <= maxAgeInt)
                .ToList();
            var matches = new Match[guides.Count];

            Parallel.For(0, guides.Count, index =>
            {   
                matches[index] = provider.GetMatch(user, guides[index]);
            });

            var matchList = matches.OrderByDescending(m => m.Score).ToList();
            return matchList;
        }
    }
}
