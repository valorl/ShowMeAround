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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMatchingService" in both code and config file together.
    [ServiceContract]
    public interface IMatchingService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/matches/{userid}?city={city}", ResponseFormat = WebMessageFormat.Xml)]
        IEnumerable<Match> GetMatchesAsync(string userid, string city);
    }
}
