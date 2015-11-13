using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;


namespace DataAccess
{
    public class UserDA : IDataAccess<User>
    {
        private ShowMeAroundContext dbContext;

        public UserDA()
        {
            dbContext = new ShowMeAroundContext();
        }


        public IEnumerable<User> GetAll()
        {
            using (var tempCtx = new ShowMeAroundContext())
            {
                return tempCtx.User.ToList();
            }
        }

        public User GetOneByID(int id)
        {
            using (var tempCtx = new ShowMeAroundContext())
            {
                if (id == null) throw new ArgumentNullException("UserDA.GetOneByID: 'id' null");
                return tempCtx.User.Find(id);
            }
        }

        public User GetOneByEmail(string email)
        {
            using (var tempCtx = new ShowMeAroundContext())
            {
                if (email == null) throw new ArgumentNullException("UserDA.GetOneByEmail: 'email' null");
                return tempCtx.User.SingleOrDefault(u => u.Email == email);
            }
        }
        public void Insert(User model)
        {
            
            if (model == null) throw new ArgumentNullException("UserDA.Insert: 'model' null");
            if (GetOneByEmail(model.Email) != null)
                throw new ArgumentException("UserDA.Insert: User[" + model.Email + "] already exists in the database.");

            dbContext.User.Add(model);

            using (var tempCtx = new ShowMeAroundContext())
            {
                //FK violation fix
                if (model.Languages != null)
                {
                    foreach (var language in model.Languages)
                    {
                        Language dbLanguage = tempCtx.Language.Find(language.Name);
                        if (dbLanguage != null)
                        {
                            dbContext.Entry(language).State = System.Data.Entity.EntityState.Unchanged;
                        }
                    }
                }
                

                if (model.Interests != null)
                {
                    foreach (var interest in model.Interests)
                    {
                        Interest dbInterest = dbContext.Interest.Find(interest.Name);
                        if (dbInterest != null)
                        {
                            dbContext.Entry(interest).State = System.Data.Entity.EntityState.Unchanged;
                        }
                    }
                }
            }
            
        }

        public void Update(User model)
        {
            if (GetOneByEmail(model.Email) != null)
                throw new ArgumentException("UserDA.Update: No such user in the database [e-mail: " + model.Email + "]");

            using (var tempCtx = new ShowMeAroundContext())
            {

                foreach (var language in model.Languages)
                {
                    Language dbLanguage = tempCtx.Language.Find(language.Name);
                    if (dbLanguage != null)
                    {
                        dbContext.Entry(language).State = System.Data.Entity.EntityState.Unchanged;
                    }
                }
                foreach (var interest in model.Interests)
                {
                    Interest dbInterest = tempCtx.Interest.Find(interest.Name);
                    if (dbInterest != null)
                    {
                        dbContext.Entry(interest).State = System.Data.Entity.EntityState.Unchanged;
                    }
                }
            }
            

            dbContext.Entry(model).State = System.Data.Entity.EntityState.Modified;
            
        }

        public void Delete(User model)
        {
            if (model == null) throw new ArgumentNullException("UserDA.Delete: 'model' null");
            if (GetOneByEmail(model.Email) == null)
                throw new ArgumentException("UserDA.Remove: No such user in the database [e-mail: " + model.Email + "]");
            dbContext.User.Remove(model);
        }

        

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }
    }
}
