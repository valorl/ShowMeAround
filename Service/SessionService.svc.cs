using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Data;
using DataAccess;

namespace Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SessionService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SessionService.svc or SessionService.svc.cs at the Solution Explorer and start debugging.
    public class SessionService : ISessionService
    {
        SessionDA sessionDA;
        public SessionService()
        {
            sessionDA = new SessionDA();
        }
        public Session Create(Session session)
        {
            sessionDA.Insert(session);
            sessionDA.SaveChanges();
            return sessionDA.GetOneByToken(session.Token);
        }

        public void Delete(string userid)
        {
            int intID = Convert.ToInt32(userid);
            if (sessionDA.GetAll().SingleOrDefault(s => s.UserID == intID) == null)
                throw new ArgumentException("SessionService.Delete: No such session. [UserId: " + userid + "]");

            
        }


    }
}
