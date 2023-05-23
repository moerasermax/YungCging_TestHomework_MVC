using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YungChing_TestHomeWork_Client.Controller;
using YungChing_TestHomeWork_Client.DataSet;
using YungChing_TestHomeWork_Client.Model;

namespace YungCging_TestHomework_MVC.Controllers
{
    public class UserController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        public string Create([FromBody] object request)
        {
            /// 解析請求資料
            string Request_Data = request.ToString().Replace("\r\n","");
            DataSet_User_CRUD User_Data = JsonConvert.DeserializeObject<DataSet_User_CRUD>(Request_Data);

            /// 建立連線
            SetServerConn();

            /// 建立抽象實作
            RequestAction_CreateUser requestAction_CreateUser = new RequestAction_CreateUser()
            {
                UserData = User_Data
            };

            try
            {
                ///請反向代理-的後端伺服器進行動作
                DataSet_ExcuteResult result = Client_Controller.getInstance().Request_Action(requestAction_CreateUser);
                if (result.Success) { result = Client_Controller.getInstance().Receive_ResponseRsult(); }

                return (string.Format("伺服器訊息：{0}", result.FeedBackMessage));
            }
            catch (Exception ex)
            {
                return (string.Format("伺服器訊息：{0}", ex.Message));
            }
        }
        [HttpPost]
        public string Delete([FromBody] object request)
        {
            /// 解析請求資料
            string Request_Data = request.ToString().Replace("\r\n", "");
            DataSet_User_CRUD User_Data = JsonConvert.DeserializeObject<DataSet_User_CRUD>(Request_Data);

            /// 建立連線
            SetServerConn();

            ///建立抽象實作
            RequestAction_DeleteUser requestAction_DeleteUser = new RequestAction_DeleteUser()
            {
                UserData = User_Data
            };
            try
            {
                DataSet_ExcuteResult result = Client_Controller.getInstance().Request_Action(requestAction_DeleteUser);
                if (result.Success) { result = Client_Controller.getInstance().Receive_ResponseRsult(); }

                return (string.Format("伺服器訊息：{0}", result.FeedBackMessage));
            }
            catch (Exception ex)
            {
                return (string.Format("伺服器訊息：{0}", ex.Message));
            }
        }
        [HttpPost]
        public string Update([FromBody] object request)
        {
            /// 解析請求資料
            string Request_Data = request.ToString().Replace("\r\n", "");
            DataSet_User_CRUD User_Data = JsonConvert.DeserializeObject<DataSet_User_CRUD>(Request_Data);

            /// 建立連線
            SetServerConn();

            /// 建立抽象實作
            RequestAction_UpdateUser requestAction_UpdateUser = new RequestAction_UpdateUser()
            {
                UserData = User_Data
            };

            try
            {
                DataSet_ExcuteResult result = Client_Controller.getInstance().Request_Action(requestAction_UpdateUser);
                if (result.Success) { result = Client_Controller.getInstance().Receive_ResponseRsult(); }

                return (string.Format("伺服器訊息：{0}", result.FeedBackMessage));
            }
            catch (Exception ex)
            {
                return (string.Format("伺服器訊息：{0}", ex.Message));
            }
        }
        [HttpPost]
        public string Read([FromBody] object request)
        {
            /// 解析請求資料
            string Request_Data = request.ToString().Replace("\r\n", "");
            DataSet_User_CRUD User_Data = JsonConvert.DeserializeObject<DataSet_User_CRUD>(Request_Data);

            /// 建立連線
            SetServerConn();

            ///建立抽象實作
            RequestAction_ReadUser requestAction_ReadUser = new RequestAction_ReadUser()
            {
                UserData = User_Data
            };

            try
            {
                DataSet_ExcuteResult result = Client_Controller.getInstance().Request_Action(requestAction_ReadUser);
                if (result.Success) { result = Client_Controller.getInstance().Receive_ResponseRsult(); }

                return (string.Format("伺服器訊息：{0}", result.FeedBackMessage));
            }
            catch (Exception ex)
            {
                return (string.Format("伺服器訊息：{0}", ex.Message));
            }
        }


        #region SetServerConn
        public string SetServerConn()
        {
            byte[] receive_buffer = new byte[1024];
            /// 需再寫防呆
            try
            {
                /// 設定伺服器
                if (Client_Controller.getInstance().SetConnectObject("127.0.0.1", 5050).Success)
                {
                    return(string.Format("伺服器訊息：{0}", "已成功連入伺服器"));
                }
                else
                {
                    return(string.Format("伺服器訊息：{0}", "發生問題請檢查連線"));

                }
            }
            catch (Exception ex)
            {
                return(string.Format("伺服器訊息：{0}", ex.Message));
            }
        }
        #endregion
    }
}