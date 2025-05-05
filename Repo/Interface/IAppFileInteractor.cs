using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKMJ_TubesKPL.Repo.Interface
{
    interface IAppFileInteractor<T>
    {

        public void SaveToFile<T>(T data, string filepath);

        public void InsertToFile<T>(T data, string filepath);

        public T ReadFile(string filepath);
        
    }
}
