using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiModul.Interface
{
    public interface IAppFileInteractor<R>
    {
         void SaveToFile<T>(T data, string filepath);

         R ReadFile(string filepath);
        
    }

}
