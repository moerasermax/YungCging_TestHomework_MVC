﻿using System;
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

        [HttpGet]
        public string Add(string Account)
        {
            SetServerConn();
            DataSet_User_CRUD User_Data = new DataSet_User_CRUD()
            {
                Account = "YC",
                Password = "A123456",
                Name = "Bboy_Yc",
                Age = "26"
            };
            RequestAction_CreateUser requestAction_CreateUser = new RequestAction_CreateUser();
            requestAction_CreateUser.UserData = User_Data;
            try
            {
                DataSet_ExcuteResult result = Client_Controller.getInstance().Request_Action(requestAction_CreateUser);
                if (result.Success) { result = Client_Controller.getInstance().Receive_ResponseRsult(); }

                return(string.Format("伺服器訊息：{0}", result.FeedBackMessage));
            }
            catch (Exception ex)
            {
                return (string.Format("伺服器訊息：{0}", ex.Message));
            }
        }
        [HttpGet]
        public string Delete(string Account)
        {
            SetServerConn();
            DataSet_User_CRUD User_Data = new DataSet_User_CRUD()
            {
                Account = "YC",
                Password = "A123456",
                Name = "Bboy_Yc",
                Age = "18"
            };
            RequestAction_DeleteUser requestAction_DeleteUser = new RequestAction_DeleteUser();
            requestAction_DeleteUser.UserData = User_Data;
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
        [HttpGet]
        public string Update(string Account)
        {
            SetServerConn();
            DataSet_User_CRUD User_Data = new DataSet_User_CRUD()
            {
                Account = "YC",
                Password = "A123456",
                Name = "Bboy_Yc",
                Age = "18"
            };
            RequestAction_UpdateUser requestAction_UpdateUser = new RequestAction_UpdateUser();
            requestAction_UpdateUser.UserData = User_Data;
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
        [HttpGet]
        public string Read(string Account)
        {
            SetServerConn();
            DataSet_User_CRUD User_Data = new DataSet_User_CRUD()
            {
                Account = "YC",
            };
            RequestAction_ReadUser requestAction_ReadUser = new RequestAction_ReadUser();
            requestAction_ReadUser.UserData = User_Data;
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

        [HttpGet]
        public string TestAdd(DataSet_User_CRUD User_Data)
        {
            SetServerConn();

            RequestAction_CreateUser requestAction_CreateUser = new RequestAction_CreateUser();
            requestAction_CreateUser.UserData = User_Data;
            try
            {
                DataSet_ExcuteResult result = Client_Controller.getInstance().Request_Action(requestAction_CreateUser);
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