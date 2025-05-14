using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKMJ_TubesKPL.Interface
{

    // NANCIL
    interface IRepository<T> where T : IEntity
    {
        void Add(T item);
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Update(T item);
        void Delete(int id);
    }
}
