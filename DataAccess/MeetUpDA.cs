using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
   public class MeetUpDA : IDataAccess<MeetUp>
    {
        private ShowMeAroundContext dbContext;

        public MeetUpDA()
        {
            dbContext = new ShowMeAroundContext();
        }

        public IEnumerable<MeetUp> GetAll()
        {
            using (var tempCtx = new ShowMeAroundContext())
            {
                return tempCtx.MeetUp.ToList();
            }
        }

        public MeetUp GetOneByID(int id)
        {
            using (var tempCtx = new ShowMeAroundContext())
            {
                if (id == null) throw new ArgumentNullException("MeeUpDA.GetOneByID: 'id' null");
                return tempCtx.MeetUp.Find(id);
            }
        }

        public void Insert(MeetUp model)
        {
            if (model == null) throw new ArgumentNullException("MeetUpDA.Insert: 'model' null");
            if (GetOneByID(model.Id) != null)
                throw new ArgumentException("MeetUpDA.Insert: Meetup[" + model.Id + "] already exists in the database.");

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
            if (GetOneByID(model.Id) != null)
                throw new ArgumentException("MeetUpDA.Update: No such Meetup in the database [Id: " + model.Id + "]");

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


            dbContext.Entry(model).State = System.Data.Entity.EntityState.Modified;
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
