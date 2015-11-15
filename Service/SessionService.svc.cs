using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Data;
using Data.Utils;
using DataAccess;
using Service.Utils;
using System.ServiceModel.Web;
namespace Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SessionService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SessionService.svc or SessionService.svc.cs at the Solution Explorer and start debugging.
    public class SessionService : ISessionService
    {
        SessionDA sessionDA;
        UserDA userDA;
        public SessionService()
        {
            sessionDA = new SessionDA();
            userDA = new UserDA();
        }
        public Session Login(LoginWrapper credentials)
        {
            var auth = new Authentication();
            if (auth.ValidateCredentials(credentials.Email, credentials.Pwd))
            {
                var session = new Session(userDA.GetOneByEmail(credentials.Email));
                sessionDA.Insert(session);
                sessionDA.SaveChanges();
                return session;
            }
            else
            {
                throw new WebFaultException(System.Net.HttpStatusCode.Unauthorized);
            }
        }

        public void Delete(string userid)
        {
            int intID = Convert.ToInt32(userid);
            if (sessionDA.GetAll().SingleOrDefault(s => s.UserID == intID) == null)
                throw new ArgumentException("SessionService.Delete: No such session. [UserId: " + userid + "]");

            
        }


    }
}
