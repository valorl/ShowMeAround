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
    // ShowMeAround API - MeetUp:
    // /meetup:
    //     GET - Return all meetups
    //     POST - Create and add a new meetup
    //     PUT - No action
    //     DELETE - No action
    // /meetup/{id}
    //     GET - Return a specific meetup using their {id}
    //     POST - No action
    //     PUT - Update a specific meetup using their {id}
    //     DELETE - Delete a specific meetup using their {id}


    [ServiceContract]
    public interface IMeetUpService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/meetup/",
            ResponseFormat = WebMessageFormat.Xml)]
        List<MeetUp> GetAll();

        [OperationContract]
        [WebGet(UriTemplate = "/meetup/{id}/",
            ResponseFormat = WebMessageFormat.Xml)]
        MeetUp GetById(string id);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/meetup/",
            RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml)]
        MeetUp Create(MeetUp meetup);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/meetup/{id}/",
            RequestFormat = WebMessageFormat.Xml)]
        MeetUp Update(string id, MeetUp meetup);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/meetup/{id}/",
            RequestFormat = WebMessageFormat.Xml)]
        void Delete(string id);
    }
}