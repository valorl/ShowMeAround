using Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class MeetUpDA : IDataAccess<MeetUp>
    {
        private ShowMeAroundContext dbContext;
        private UserDA userDA;

        public MeetUpDA()
        {
            dbContext = new ShowMeAroundContext();
            userDA = new UserDA();
        }

        public IEnumerable<MeetUp> GetAll()
        {
            using (var tempCtx = new ShowMeAroundContext())
            {
                var meetups = tempCtx.MeetUp.ToList();
                foreach(var meetup in meetups)
                {
                    tempCtx.Entry(meetup).Reference(m => m.Guide).Load();
                    tempCtx.Entry(meetup).Reference(m => m.Traveler).Load();
                    tempCtx.Entry(meetup.Guide).Reference(u => u.City).Load();
                    tempCtx.Entry(meetup.Traveler).Reference(u => u.City).Load();
                }
                return meetups;
            }
        }

        public MeetUp GetOneByID(int id)
        {
            using (var tempCtx = new ShowMeAroundContext())
            {
                if (id == null) throw new ArgumentNullException("MeeUpDA.GetOneByID: 'id' null");
                var meetup = tempCtx.MeetUp.Find(id);
                if(meetup != null)
                {
                    tempCtx.Entry(meetup).Reference(m => m.Guide).Load();
                    tempCtx.Entry(meetup).Reference(m => m.Traveler).Load();
                    meetup.Guide = userDA.GetOneByID(meetup.Guide.Id);
                    meetup.Traveler = userDA.GetOneByID(meetup.Traveler.Id);
                }
                return meetup;
            }
        }

        public void Insert(MeetUp model)
        {
            if (model == null) throw new ArgumentNullException("MeetUpDA.Insert: 'model' null");
            if (GetOneByID(model.Id) != null)
                throw new ArgumentException("MeetUpDA.Insert: Meetup[" + model.Id + "] already exists in the database.");

            var newTraveler = new User() { Id = model.Traveler.Id };
            var newGuide = new User() { Id = model.Guide.Id };
            model.Traveler = newTraveler;
            model.Guide = newGuide;
            dbContext.MeetUp.Add(model);

            using (var tempCtx = new ShowMeAroundContext())
            {
                //FK violation fix
                if (model.Traveler != null)
                {
                    User dbTraveler = tempCtx.User.Find(model.Traveler.Id);

                    if (dbTraveler != null)
                    {
                        dbContext.Entry(model.Traveler).State = System.Data.Entity.EntityState.Unchanged;

                    }
                }

                if (model.Guide != null)
                {
                    User dbGuide = tempCtx.User.Find(model.Guide.Id);

                    if (dbGuide != null)
                    {
                        dbContext.Entry(model.Guide).State = System.Data.Entity.EntityState.Unchanged;
                    }
                }
            }
        }

        public void Update(MeetUp model)
        {
            if (GetOneByID(model.Id) == null)
                throw new ArgumentException("MeetUpDA.Update: No such Meetup in the database [Id: " + model.Id + "]");

            string sql = "UPDATE MeetUps SET TravelerState=@tState,GuideState=@gState";
            var parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@tState", (int)model.TravelerState);
            parameters[1] = new SqlParameter("@gState", (int)model.GuideState);

            dbContext.Database.ExecuteSqlCommand(sql, parameters);

            //using (var tempCtx = new ShowMeAroundContext())
            //{
            //    //FK violation fix
            //    if (model.Traveler != null)
            //    {
            //        User dbTraveler = tempCtx.User.Find(model.Traveler.Id);

            //        if (dbTraveler != null)
            //        {
            //            dbContext.Entry(model.Traveler).State = System.Data.Entity.EntityState.Unchanged;
            //        }
            //    }

            //    if (model.Guide != null)
            //    {
            //        User dbGuide = tempCtx.User.Find(model.Guide.Id);

            //        if (dbGuide != null)
            //        {
            //            foreach (var lang in dbGuide.Languages)
            //            {
            //                if (dbContext.Language.Local.Contains(lang))
            //                {
            //                    dbContext.Entry(lang).State = System.Data.Entity.EntityState.Detached;
            //                }
            //            }
            //            foreach (var interest in dbGuide.Interests)
            //            {
            //                if (dbContext.Interest.Local.Contains(interest))
            //                {
            //                    dbContext.Entry(interest).State = System.Data.Entity.EntityState.Detached;
            //                }
            //            }
            //            //dbContext.Entry(model.Guide).State = System.Data.Entity.EntityState.Unchanged;

            //        }
            //    }
            //}

            //dbContext.Entry(model).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(MeetUp model)
        {
            if (model == null) throw new ArgumentNullException("MeetUpDA.Delete: 'model' null");
            if (GetOneByID(model.Id) == null)
                throw new ArgumentException("MeetUpDA.Remove: No such Meetup in the database [Id: " + model.Id + "]");
            dbContext.MeetUp.Remove(model);
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }
    }
}
