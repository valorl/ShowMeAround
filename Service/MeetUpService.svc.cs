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
using System.Threading.Tasks;

namespace Service
{
    public class MeetUpService : IMeetUpService
    {
        private MeetUpDA meetUpDA;
        private SessionDA sessionDA;
        private Authentication auth;

        public MeetUpService()
        {
            meetUpDA = new MeetUpDA();
            sessionDA = new SessionDA();
            auth = new Authentication();
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
            User authUser = auth.Authorize(WebOperationContext.Current.IncomingRequest);
            if (authUser.Id != meetup.Traveler.Id) throw new WebFaultException(System.Net.HttpStatusCode.Unauthorized);

            MeetUp result = null;

            using (var muTransaction = meetUpDA.BeginTransaction())
            {
                try
                {
                    if (IsGuideAvailable(meetup))
                    {
                        meetUpDA.Insert(meetup);
                        meetUpDA.SaveChanges();
                        result = meetUpDA.GetOneByID(meetup.Id);
                    }
                }
                catch(Exception)
                {
                    muTransaction.Rollback();
                }

            }
            return result;      
        }

        public MeetUp Update(string id, MeetUp meetUp)
        {
            User authUser = auth.Authorize(WebOperationContext.Current.IncomingRequest);
            if (authUser.Id != meetUp.Traveler.Id && authUser.Id != meetUp.Guide.Id) throw new WebFaultException(System.Net.HttpStatusCode.Unauthorized);

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



        //Utility methods
        private bool IsGuideAvailable(MeetUp meetup)
        {
            var gMeetUps = meetUpDA.GetAll().Where(m => m.Guide.Id == meetup.Guide.Id).ToArray();
            if (gMeetUps.Length == 0) return true;

            bool isAvailable = true;

            Parallel.For(0, gMeetUps.Length, i =>
            {
                bool datesOverlap = DatesOverlap(meetup.StartDate, meetup.FinishDate, gMeetUps[i].StartDate, gMeetUps[i].FinishDate);
                if(datesOverlap)
                {
                        isAvailable = false;
                }
            });

            return isAvailable;
        }
        public bool DatesOverlap(DateTime startA, DateTime endA, DateTime startB, DateTime endB)
        {
            if (startA < endB && startB < endA) return true;
            return false;
        }
    }

}
