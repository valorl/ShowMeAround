﻿using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class SessionDA : IDataAccess<Session>
    {
        ShowMeAroundContext dbContext;
        public SessionDA()
        {
            dbContext = new ShowMeAroundContext();
        }



        public IEnumerable<Session> GetAll()
        {
            using (var tempCtx = new ShowMeAroundContext())
            {
                return dbContext.Session.ToList();
            }
        }

        public Session GetOneByToken(string token)
        {
            if (token == null) throw new ArgumentNullException("SessionDA.GetOneByToken: 'token' null");
            return dbContext.Session.Find(token);
        }

        public void Insert(Session model)
        {
            if (model == null) throw new ArgumentNullException("SessionDA.Insert: 'model' null");
            if (GetOneByToken(model.Token) != null)
            {
                Update(model);
            }
            else
            {
                dbContext.Session.Add(model);
            }
        }

        public void Update(Session model)
        {
            if (model == null) throw new ArgumentNullException("SessionDA.Update: 'model'null");
            if (GetOneByToken(model.Token) == null)
                throw new ArgumentException("SessionDA.Update: Session[" + model.Token + "] doesn't exists.");
            dbContext.Entry(model).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(Session model)
        {
            if (model == null) throw new ArgumentNullException("SessionDA.Update: 'model'null");
            if (GetOneByToken(model.Token) == null)
                throw new ArgumentException("SessionDA.Update: Session[" + model.Token + "] doesn't exist.");
            dbContext.Session.Remove(model);
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }
    }
}
