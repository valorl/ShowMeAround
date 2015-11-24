using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class InterestDA : IDataAccess<Interest>
    {
        private ShowMeAroundContext dbContext;

        public InterestDA()
        {
            dbContext = new ShowMeAroundContext();
        }

        public IEnumerable<Interest> GetAll()
        {
            using (var tempCtx = new ShowMeAroundContext())
            {
                var interests = tempCtx.Interest.ToList();
                foreach (var interest in interests)
                {
                    interest.Users = null;
                }
                return interests;
            }
        }
        public void Delete(Interest model)
        {
            throw new NotImplementedException();
        }

        public void Insert(Interest model)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(Interest model)
        {
            throw new NotImplementedException();
        }
    }
}

