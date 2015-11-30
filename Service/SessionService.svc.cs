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
        Authentication auth;
        public SessionService()
        {
            sessionDA = new SessionDA();
            userDA = new UserDA();
            auth = new Authentication();

        }
        public Session Login(LoginCredentials credentials)
        {
            if (auth.ValidateCredentials(credentials.Email, credentials.Pwd))
            {
                var user = userDA.GetOneByEmail(credentials.Email);
                var userSession = sessionDA.GetAll().Where(s => s.UserID == user.Id).FirstOrDefault();
                Session session = null;
                if (userSession != null && auth.ValidateToken(userSession.Token))
                {
                    session = userSession;
                }
                else
                {
                    session = new Session(user);
                }
                sessionDA.Insert(session);
                sessionDA.SaveChanges();
                return session;
            }
            else
            {
                throw new WebFaultException(System.Net.HttpStatusCode.Unauthorized);
            }
        }

        public Session GetOneByToken(string token)
        {
            return sessionDA.GetOneByToken(token);
        }

        public void Delete(string userid)
        {
            int intID = Convert.ToInt32(userid);
            var session = sessionDA.GetAll().SingleOrDefault(s => s.UserID == intID);
            if (session == null)
                throw new ArgumentException("SessionService.Delete: No such session. [UserId: " + userid + "]");
        
            User authUser = auth.Authorize(WebOperationContext.Current.IncomingRequest);
            if (authUser.Id != intID) throw new WebFaultException(System.Net.HttpStatusCode.Unauthorized);

            sessionDA.Delete(session);
            sessionDA.SaveChanges();
            
        }



    }
}
