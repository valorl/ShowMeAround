using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Data;

namespace Service
{
    // ShowMeAround API - Session:
    // /sessions/:
    //     GET - No action (clients should not be able to see all the sessions, only their own)
    //     POST - Create and add a new session
    //     PUT - No action
    //     DELETE - No action
    // /user/{id}
    //     GET - Return a specific user using their {id}
    //     POST - No action
    //     PUT - No action
    //     DELETE - Delete a specific session using the userid it contains

    [ServiceContract]
    public interface ISessionService
    {

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/sessions/", RequestFormat = WebMessageFormat.Xml)]
        Session Create(Session session);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/session/{userid}", RequestFormat = WebMessageFormat.Xml)]
        void Delete(string userid);

    }
}
