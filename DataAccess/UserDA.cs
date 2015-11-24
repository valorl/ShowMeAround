using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Utils;


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

            var users = dbContext.User.ToList();
            foreach (var user in users)
            {
                dbContext.Entry(user).Collection(u => u.Languages).Load();
                dbContext.Entry(user).Collection(u => u.Interests).Load();
            }
            return users;


        }

        public User GetOneByID(int id)
        {

            if (id == 0) throw new ArgumentNullException("UserDA.GetOneByID: 'id' null");
            using (var tempCtx = new ShowMeAroundContext())
            {
                var user = tempCtx.User.Find(id);
                tempCtx.Entry(user).Collection(u => u.Languages).Load();
                tempCtx.Entry(user).Collection(u => u.Interests).Load();
                return user;
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

            model.PwDSalt = PasswordHasher.GetSalt();
            if(model.PwdHash !=null) model.PwdHash = PasswordHasher.HashPwd(model.PwdHash, model.PwDSalt);

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
                        Interest dbInterest = tempCtx.Interest.Find(interest.Name);
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
            if (GetOneByEmail(model.Email) == null)
                throw new ArgumentException("UserDA.Update: No such user in the database [e-mail: " + model.Email + "]");

            using (var tempCtx = new ShowMeAroundContext())
            {
                if (model.Languages != null && model.Languages.Count > 0)
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
                if (model.Interests != null && model.Interests.Count > 0)
                {
                    foreach (var interest in model.Interests)
                    {
                        Interest dbInterest = tempCtx.Interest.Find(interest.Name);
                        if (dbInterest != null)
                        {
                            dbContext.Entry(interest).State = System.Data.Entity.EntityState.Unchanged;
                        }
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
            try
            {
                dbContext.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
