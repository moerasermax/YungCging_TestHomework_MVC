using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using YungChing_TestHomeWork_Client.DataSet;

namespace YungCging_TestHomework_MVC.Interface
{
    public interface I_Query_API
    {
        DataSet_ExcuteResult Excute(string API_Method, string action_name,DataSet_User_CRUD Post_User_Data, HttpRequestBase HttpRequest);
    }
}
