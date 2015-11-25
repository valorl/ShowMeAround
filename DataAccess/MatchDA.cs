using Data;
using Data.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class MatchDA
    {
        private ShowMeAroundContext dbContext;
        private UserDA userDA;
        private MatchingProvider provider;
        public MatchDA()
        {
            dbContext = new ShowMeAroundContext();
            userDA = new UserDA();
            provider = new MatchingProvider();
        }

        public IEnumerable<Match> GetMatchesAsync(User user, string city)
        {
            var guides = userDA.GetAll().Where(u => u.Id != user.Id);

            var matches = new List<Match>();

            Parallel.ForEach(guides, (guide) =>
            {
                matches.Add(this.provider.)
            });
        }
        
    }
}
