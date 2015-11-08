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
            return dbContext.User.ToList();
        }

        public User GetOneByID(int id)
        {
            if (id == null) throw new ArgumentNullException("UserDA.GetOneByID: 'id' null");
            return dbContext.User.Find(id);
        }

        public User GetOneByEmail(string email)
        {
            if (email == null) throw new ArgumentNullException("UserDA.GetOneByEmail: 'email' null");
            return dbContext.User.Where(u => u.Email == email).FirstOrDefault();
        }
        public void Insert(User model)
        {
            if (model == null) throw new ArgumentNullException("UserDA.Insert: 'model' null");
            if (GetOneByEmail(model.Email) != null) 
                throw new ArgumentException("UserDA.Insert: User[" + model.Email + "] already exists in the database.");
            dbContext.User.Add(model);
        }

        public void Update(User model)
        {
            if (GetOneByEmail(model.Email) != null)
                throw new ArgumentException("UserDA.Update: No such user in the database [e-mail: " + model.Email + "]");
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
