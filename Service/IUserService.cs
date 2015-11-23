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

    // ShowMeAround API - User:
    // /users:
    //     GET - Return all users
    //     POST - Create and add a new user
    //     PUT - No action
    //     DELETE - No action
    // /user/{id}
    //     GET - Return a specific user using their {id}
    //     POST - No action
    //     PUT - Update a specific user using their {id}
    //     DELETE - Delete a specific user using their {id}
    // /interests:
    //     GET - Return all interests
    // /languages:
    //     GET - Return all languages


    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/users/",
            ResponseFormat = WebMessageFormat.Xml)]
        List<User> GetAll();

        [OperationContract]
        [WebGet(UriTemplate = "/user/{id}/",
            ResponseFormat = WebMessageFormat.Xml)]
        User GetById(string id);

        [OperationContract]
        [WebInvoke(Method="POST", UriTemplate="/users/", 
            RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml)]
        User Create(User user);
        
        [OperationContract]
        [WebInvoke(Method="PUT", UriTemplate = "/user/{id}/", 
            RequestFormat = WebMessageFormat.Xml)]
        User Update(string id, User user);
        
        [OperationContract]
        [WebInvoke(Method="DELETE", UriTemplate = "/user/{id}/",
            RequestFormat = WebMessageFormat.Xml)]  
        void Delete(string id);

        [OperationContract]
        [WebGet(UriTemplate = "/interests/",
           ResponseFormat = WebMessageFormat.Xml)]
        List<Interest> GetAllInterests();

        [OperationContract]
        [WebGet(UriTemplate = "/languages/",
           ResponseFormat = WebMessageFormat.Xml)]
        List<Language> GetAllLanguages();

    }
}
