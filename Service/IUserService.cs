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


    [ServiceContract]
    public interface IUserService
    {

        [WebGet(UriTemplate = "/users",
            RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml)]
        [OperationContract]
        List<User> GetAll();

        [WebGet(UriTemplate = "/user/{id}",
            RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml)]
        [OperationContract]
        List<User> GetById(int id);
        
        [WebInvoke(Method="POST", UriTemplate="/users", 
            RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml)]
        [OperationContract]
        User Create(User user);

        [WebInvoke(Method="PUT", UriTemplate = "/user/{id}", 
            RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml)]
        [OperationContract]
        User Update(int id, User user);

        [WebInvoke(Method="DELETE", UriTemplate = "/user/{id}",
            RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml)]
        [OperationContract]
        void Delete(int id);


    }
}
