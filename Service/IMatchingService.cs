using Data.Utils;
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
    public interface IMatchingService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/matches/{userid}?city={city}&minAge={minAge}&maxAge={maxAge}", 
            ResponseFormat = WebMessageFormat.Xml)]
        IEnumerable<Match> GetMatchesAsync(string userid, string city, string minAge, string maxAge);
    }
}
