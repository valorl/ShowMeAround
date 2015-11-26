using Data;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CountryService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CountryService.svc or CountryService.svc.cs at the Solution Explorer and start debugging.
    public class CountryService : ICountryService
    {
        private CountryDA countryDA;

        public CountryService()
        {
            countryDA = new CountryDA();
        }
        public List<Country> GetAll()
        {
            var list = new List<Country>();
            return countryDA.GetAll().ToList();
        }
    }
}
