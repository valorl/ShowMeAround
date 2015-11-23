using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class InterestsDA : IDataAccess<Interest>
    {
        private ShowMeAroundContext dbContext;

        public InterestsDA()
        {
            dbContext = new ShowMeAroundContext();
        }

        public void Delete(Interest model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Interest> GetAll()
        {
            using (var tempCtx = new ShowMeAroundContext())
            {
                return tempCtx.Interest.ToList();
            }

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

    