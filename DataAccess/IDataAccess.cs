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
        T GetOneByID();
        void Insert(T model);
        void Delete(int id);
        void Update(T model);
        void Save();
    }
}
