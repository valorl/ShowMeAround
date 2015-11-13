using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IDataAccess<T>
    {
        IEnumerable<T> GetAll();
        void Insert(T model);
        void Update(T model);
        void Delete(T model);
        void SaveChanges();
    }
}
