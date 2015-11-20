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
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        List<User> GetAllUsers();

        [OperationContract]
        User GetUserById(string id);

        [OperationContract]
        User CreateUser(User user);
        
        [OperationContract]
        User UpdateUser(string id, User user);
        
        [OperationContract]
        void DeleteUser(string id);


    }
}
