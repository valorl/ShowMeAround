using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Service
{
    [ServiceContract]
    public interface ICountryService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/countries/",
            ResponseFormat = WebMessageFormat.Xml)]
        List<Country> GetAll();

        [OperationContract]
        [WebGet(UriTemplate = "/cities/{country}/",
            ResponseFormat = WebMessageFormat.Json)]
        List<City> GetCitiesByCountry(string country);
    }
}
