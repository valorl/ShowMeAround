using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Data;
using DataAccess;
using System.ServiceModel.Web;
using Service.Utils;

namespace Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MeetUpService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MeetUpService.svc or MeetUpService.svc.cs at the Solution Explorer and start debugging.
    public class MeetUpService : IMeetUpService
    {
        private MeetUpDA meetUpDA;
        private SessionDA sessionDA;
        private Authentication auth;

        public MeetUpService()
        {
            meetUpDA = new MeetUpDA();
        }
        public List<MeetUp> GetAll()
        {
            var list = new List<MeetUp>();
            return meetUpDA.GetAll().ToList();
        }

        public MeetUp GetById(string id)
        {
            int intID = Convert.ToInt32(id);
            return meetUpDA.GetOneByID(intID);
        }

        public MeetUp Create(MeetUp meetup)
        {
            //Auth
            User authUser = auth.Authorize(WebOperationContext.Current.IncomingRequest);
            if (authUser.Id != meetup.Traveler.Id) throw new WebFaultException(System.Net.HttpStatusCode.Unauthorized);

            meetUpDA.Insert(meetup);
            meetUpDA.SaveChanges();
            return meetUpDA.GetOneByID(meetup.Id);
        }

        public MeetUp Update(string id, MeetUp meetUp)
        {
            User authUser = auth.Authorize(WebOperationContext.Current.IncomingRequest);
            if (authUser.Id != meetUp.Traveler.Id) throw new WebFaultException(System.Net.HttpStatusCode.Unauthorized);

            meetUp.Id = Convert.ToInt32(id);
            meetUpDA.Update(meetUp);
            meetUpDA.SaveChanges();
            return meetUpDA.GetOneByID(meetUp.Id);
        }

        public void Delete(string id)
        {
            var toBeDeleted = meetUpDA.GetOneByID(Convert.ToInt32(id));

            if (toBeDeleted != null)
            {
                meetUpDA.Delete(toBeDeleted);
                meetUpDA.SaveChanges();
            }
        }
    }

}
