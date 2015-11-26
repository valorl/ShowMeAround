using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CityDA : IDataAccess<City>
    {
        private ShowMeAroundContext dbContext;

        public CityDA()
        {
            dbContext = new ShowMeAroundContext();
        }

        public IEnumerable<City> GetAll()
        {
            using (var tempCtx = new ShowMeAroundContext())
            {
                var cities = tempCtx.City.ToList();
                return cities;
            }
        }

        public void Delete(City model)
        {
            throw new NotImplementedException();
        }

        public void Insert(City model)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(City model)
        {
            throw new NotImplementedException();
        }
    }
}