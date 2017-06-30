using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaConginterface
{
   public interface form2_NewThreadInterface
    {
        void ShowForm2();
        //列表填充
        void AddListString(List<List<string>> list);
        //列表项填充
        void AddListitemString(List<string> list); 
    }

}
