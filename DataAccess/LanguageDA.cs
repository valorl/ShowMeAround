﻿using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class LanguageDA : IDataAccess<Language>
    {
        private ShowMeAroundContext dbContext;

        public LanguageDA()
        {
            dbContext = new ShowMeAroundContext();
        }

        public IEnumerable<Language> GetAll()
        {
            using (var tempCtx = new ShowMeAroundContext())
            {
                return tempCtx.Language.ToList();
            }
        }

        public void Delete(Language model)
        {
            throw new NotImplementedException();
        }

        public void Insert(Language model)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(Language model)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Language> IDataAccess<Language>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}