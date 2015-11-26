using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess

{
    public class CountryDA : IDataAccess<Country>
    {
        private ShowMeAroundContext dbContext;

        public CountryDA()
        {
            dbContext = new ShowMeAroundContext();
        }

        public IEnumerable<Country> GetAll()
        {
            using (var tempCtx = new ShowMeAroundContext())
            {
                var countries = tempCtx.Country.ToList();
                return countries;
            }
        }

        public void Delete(Country model)
        {
            throw new NotImplementedException();
        }

        public void Insert(Country model)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(Country model)
        {
            throw new NotImplementedException();
        }
    }
}
