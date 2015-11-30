using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Data;
using Data.Utils;

namespace Service
{
    // ShowMeAround API - Session:
    // /login
    //     POST - Login - Check e-mail and password, then create a session and return it
    // /user/{id}
    //     GET - Return a specific user using their {id}
    //     POST - No action
    //     PUT - No action
    //     DELETE - Delete a specific session using the userid it contains

    [ServiceContract]
    public interface ISessionService
    {

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/login/", RequestFormat = WebMessageFormat.Xml)]
        Session Login(LoginCredentials credentials);

        [OperationContract]
        [WebInvoke(Method = "POST",UriTemplate = "/session/", 
            ResponseFormat = WebMessageFormat.Xml, RequestFormat = WebMessageFormat.Xml)]
        Session GetOneByToken(string token);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/session/{userid}/", RequestFormat = WebMessageFormat.Xml)]
        void Delete(string userid);

    }
}
