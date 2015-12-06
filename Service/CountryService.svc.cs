using Data;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Service
{
   
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

        public List<City> GetCitiesByCountry(string country)
        {
            WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Origin", "*");
            country = country.Replace("+", " ");
            var cities = countryDA.GetAll().Where(c => c.Name.ToLower() == country.ToLower()).FirstOrDefault().Cities;
            return cities;
        }
    }
}
