using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKMJ_TubesKPL.Interface
{
    interface IAppFileInteractor<R>
    {
        public void SaveToFile<T>(T data, string filepath);

        public R ReadFile(string filepath);
        
    }

}
