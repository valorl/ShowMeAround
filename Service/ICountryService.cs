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
    // ShowMeAround API - Country:
    // /countries:
    //     GET - Return all countries
    [ServiceContract]
    public interface ICountryService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/countries/",
            ResponseFormat = WebMessageFormat.Xml)]
        List<Country> GetAll();
    }
}
