using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using YungCging_TestHomework_MVC.Interface;
using YungChing_TestHomeWork_Client.DataSet;

namespace YungCging_TestHomework_MVC.Models
{
    public class Query_API : I_Query_API
    {

        public DataSet_ExcuteResult Excute(string API_Method, string action_name, DataSet_User_CRUD Post_User_Data, HttpContext httpContext)
        {
            DataSet_ExcuteResult result = new DataSet_ExcuteResult();
            try
            {
                string hostname = httpContext.Request.Url.Host;
                string port = httpContext.Request.Url.Port.ToString();

                string API_CreateUser_URL = string.Format("http://{0}:{1}/api/User/{2}", hostname, port, action_name);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(API_CreateUser_URL);
                request.Method = API_Method;
                request.ContentType = "application/json";

                string postBody = JsonConvert.SerializeObject(Post_User_Data);//將匿名物件序列化為json字串
                byte[] byteArray = Encoding.UTF8.GetBytes(postBody);//要發送的字串轉為byte[]

                using (Stream reqStream = request.GetRequestStream())
                {
                    reqStream.Write(byteArray, 0, byteArray.Length);
                }//end using

                //發出Request
                string responseStr = "";
                HttpWebResponse response1 = (HttpWebResponse)request.GetResponse();

                using (WebResponse response = request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    {
                        responseStr = reader.ReadToEnd();
                    }
                }
                result.Success = true;
                result.FeedBackMessage = responseStr;   
            }
            catch (Exception ex)
            {
                result.Success = true;
                result.FeedBackMessage = ex.Message;
            }
            return result;
        }
        #region Singleton

        public static Query_API Instance = new Query_API();
        public static Query_API getInstance()
        {
            return Instance;
        }
        private Query_API()
        {

        }
        #endregion

    }
}