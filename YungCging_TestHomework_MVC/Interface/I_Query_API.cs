using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YungChing_TestHomeWork_Client.DataSet;

namespace YungCging_TestHomework_MVC.Interface
{
    public interface I_Query_API
    {
        DataSet_ExcuteResult Excute(string Method, string action_name)
    }
}
